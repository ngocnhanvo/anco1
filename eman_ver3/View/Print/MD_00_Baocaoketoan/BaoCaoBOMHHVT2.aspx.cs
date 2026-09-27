using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

public partial class PrintControllers_MD_00_Baocaoketoan_BaoCaoBOMHHVT2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) RenderMatrix(LoadMatrix());
    }

    private DataTable LoadMatrix()
    {
        var source = new DataTable();
        using (var da = new SqlDataAdapter(CreateSql(HttpContext.Current), Mbg.Data.SqlClient.SqlHelper.GetConnection))
        {
            da.SelectCommand.CommandTimeout = 3600;
            da.Fill(source);
        }
        return BuildMatrix(source);
    }

    private DataTable BuildMatrix(DataTable source)
    {
        var result = new DataTable("BOMHHVT2");
        result.Columns.Add("MAHH", typeof(string));
        if (source == null || source.Rows.Count == 0) return result;

        var vatTus = source.AsEnumerable().Where(r => !r.IsNull("maVT"))
            .Select(r => Convert.ToString(r["maVT"]).Trim()).Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();
        foreach (string maVT in vatTus) result.Columns.Add(maVT, typeof(decimal));

        var hangHoas = source.AsEnumerable().GroupBy(r => new {
            MaHH = Convert.ToString(r["maHH"]), GroupOrder = Convert.ToInt32(r["group_order"]),
            SortType = Convert.ToInt32(r["sort_type"]), SortOrder = Convert.ToInt32(r["sort_order"])
        }).OrderBy(g => g.Key.GroupOrder).ThenBy(g => g.Key.SortType).ThenBy(g => g.Key.SortOrder)
          .ThenBy(g => g.Key.MaHH, StringComparer.OrdinalIgnoreCase);

        foreach (var hangHoa in hangHoas)
        {
            DataRow row = result.NewRow();
            row["MAHH"] = hangHoa.Key.MaHH;
            foreach (string maVT in vatTus) row[maVT] = 0m;
            foreach (DataRow item in hangHoa)
            {
                if (item.IsNull("maVT") || item.IsNull("sl")) continue;
                string maVT = Convert.ToString(item["maVT"]).Trim();
                if (result.Columns.Contains(maVT)) row[maVT] = Convert.ToDecimal(row[maVT]) + Convert.ToDecimal(item["sl"]);
            }
            result.Rows.Add(row);
        }
        return result;
    }

    private void RenderMatrix(DataTable matrix)
    {
        litSummary.Text = "<span class=\"summary\">" + matrix.Rows.Count + " mã hàng · " + Math.Max(0, matrix.Columns.Count - 1) + " vật tư</span>";
        if (matrix.Rows.Count == 0) { litMatrix.Text = "<div class=\"empty\">Không có dữ liệu</div>"; return; }

        var html = new StringBuilder("<table><thead><tr>");
        foreach (DataColumn col in matrix.Columns) html.Append("<th>").Append(HttpUtility.HtmlEncode(col.ColumnName)).Append("</th>");
        html.Append("</tr></thead><tbody>");
        foreach (DataRow row in matrix.Rows)
        {
            html.Append("<tr>");
            for (int c = 0; c < matrix.Columns.Count; c++)
            {
                if (c == 0) html.Append("<td class=\"code\">").Append(HttpUtility.HtmlEncode(Convert.ToString(row[c]))).Append("</td>");
                else html.Append("<td class=\"num\">").Append((row.IsNull(c) ? 0m : Convert.ToDecimal(row[c])).ToString("0.##########", CultureInfo.InvariantCulture)).Append("</td>");
            }
            html.Append("</tr>");
        }
        litMatrix.Text = html.Append("</tbody></table>").ToString();
    }

    protected void btnExportExcel_Click(object sender, EventArgs e) { ExportMatrixAsHtmlExcel(LoadMatrix()); }

    private void ExportMatrixAsHtmlExcel(DataTable matrix)
    {
        var html = new StringBuilder("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><style>table{border-collapse:collapse;font-family:Arial;font-size:10pt}th,td{border:1px solid #000;padding:4px;white-space:nowrap}th{font-weight:bold;text-align:center;background:#eee}td.txt{mso-number-format:'\\@';text-align:left}td.num{mso-number-format:'0.##########';text-align:right}</style></head><body><table><tr>");
        foreach (DataColumn col in matrix.Columns) html.Append("<th>").Append(HttpUtility.HtmlEncode(col.ColumnName)).Append("</th>");
        html.Append("</tr>");
        foreach (DataRow row in matrix.Rows)
        {
            html.Append("<tr>");
            for (int c = 0; c < matrix.Columns.Count; c++)
            {
                if (c == 0) html.Append("<td class=\"txt\">").Append(HttpUtility.HtmlEncode(Convert.ToString(row[c]))).Append("</td>");
                else {
                    string n = (row.IsNull(c) ? 0m : Convert.ToDecimal(row[c])).ToString("0.##########", CultureInfo.InvariantCulture);
                    html.Append("<td class=\"num\" x:num=\"").Append(n).Append("\">").Append(n).Append("</td>");
                }
            }
            html.Append("</tr>");
        }
        html.Append("</table></body></html>");
        Response.Clear(); Response.Buffer = true; Response.Charset = "utf-8"; Response.ContentEncoding = Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=BOM_HHVT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls");
        Response.Write(html.ToString()); Response.Flush(); HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    public string CreateSql(HttpContext context)
    {
        string khoValue = (context.Request.QueryString["kho"] ?? "").removeAllSpaceOrTrimText(true).Replace("'", "''");
        string maspValue = (context.Request.QueryString["masp"] ?? "").removeAllSpaceOrTrimText(true).Replace("'", "''");
        string kho = string.IsNullOrWhiteSpace(khoValue) ? "" : $@"and sp.khomacdinh = N'{khoValue}'";
        string masp = string.IsNullOrWhiteSpace(maspValue) ? "" : $@"and sp.ma_sanpham = N'{maspValue}'";
        return $@"
SET NOCOUNT ON;
DROP TABLE IF EXISTS #HangReport; DROP TABLE IF EXISTS #TPGroup; DROP TABLE IF EXISTS #BTPGroup;
DROP TABLE IF EXISTS #TP_BTP; DROP TABLE IF EXISTS #RootTP; DROP TABLE IF EXISTS #BomMoiNhat;
SELECT x.md_sanpham_bom_id,x.md_sanpham_id,x.ten_phienban,x.ngay_hieuluc INTO #BomMoiNhat
FROM (SELECT b.md_sanpham_bom_id,b.md_sanpham_id,b.ten_phienban,b.ngay_hieuluc,
ROW_NUMBER() OVER(PARTITION BY b.md_sanpham_id ORDER BY b.ngay_hieuluc DESC,b.md_sanpham_bom_id DESC) rn
FROM md_sanpham_bom b WHERE ISNULL(b.ten_phienban,'')<>'') x WHERE x.rn=1;
CREATE UNIQUE CLUSTERED INDEX IX_BomMoiNhat ON #BomMoiNhat(md_sanpham_id);
SELECT x.md_sanpham_id,x.ma_sanpham,ROW_NUMBER() OVER(ORDER BY x.ma_sanpham) root_order INTO #RootTP
FROM (SELECT sp.md_sanpham_id,sp.ma_sanpham FROM md_sanpham sp INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id=sp.md_sanpham_id
WHERE sp.sanpham=1 {kho} {masp} AND NOT EXISTS(SELECT 1 FROM #BomMoiNhat pb
INNER JOIN md_sanpham p ON p.md_sanpham_id=pb.md_sanpham_id INNER JOIN md_sanpham_bom_vattu pi ON pi.md_sanpham_bom_id=pb.md_sanpham_bom_id
WHERE pi.md_sanpham_id=sp.md_sanpham_id AND p.md_sanpham_id<>sp.md_sanpham_id AND p.sanpham=1)) x;
CREATE UNIQUE CLUSTERED INDEX IX_RootTP ON #RootTP(md_sanpham_id);
SELECT tp.md_sanpham_id tp_id,tp.ma_sanpham ma_tp,tp.root_order,btp.md_sanpham_id btp_id,btp.ma_sanpham ma_btp INTO #TP_BTP
FROM #RootTP tp INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id=tp.md_sanpham_id
INNER JOIN md_sanpham_bom_vattu bvt ON bvt.md_sanpham_bom_id=bom.md_sanpham_bom_id INNER JOIN md_sanpham btp ON btp.md_sanpham_id=bvt.md_sanpham_id
WHERE btp.ban_thanhpham=1 AND ISNULL(btp.vattu,0)=0;
SELECT btp_id,ma_btp,MIN(root_order) group_order INTO #BTPGroup FROM #TP_BTP GROUP BY btp_id,ma_btp;
SELECT x.tp_id,MIN(g.group_order) group_order INTO #TPGroup FROM #TP_BTP x INNER JOIN #BTPGroup g ON g.btp_id=x.btp_id GROUP BY x.tp_id;
CREATE TABLE #HangReport(md_sanpham_id NVARCHAR(32) NOT NULL,ma_sanpham NVARCHAR(255),group_order INT NOT NULL,sort_type INT NOT NULL,sort_order INT NOT NULL);
INSERT #HangReport SELECT tp.md_sanpham_id,tp.ma_sanpham,ISNULL(g.group_order,tp.root_order),0,tp.root_order FROM #RootTP tp LEFT JOIN #TPGroup g ON g.tp_id=tp.md_sanpham_id;
INSERT #HangReport SELECT g.btp_id,g.ma_btp,g.group_order,1,999999 FROM #BTPGroup g;
;WITH BomTree AS(
SELECT hr.md_sanpham_id report_id,hr.ma_sanpham ma_goc,hr.group_order,hr.sort_type,hr.sort_order,child.md_sanpham_id child_id,child.ma_sanpham ma_con,child.mota_tiengviet,
CAST(bvt.soluong AS DECIMAL(38,10)) sl_tich_luy,child.sanpham,child.ban_thanhpham,child.vattu,CAST(N'|'+hr.md_sanpham_id+N'|'+child.md_sanpham_id+N'|' AS NVARCHAR(MAX)) id_path
FROM #HangReport hr INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id=hr.md_sanpham_id INNER JOIN md_sanpham_bom_vattu bvt ON bvt.md_sanpham_bom_id=bom.md_sanpham_bom_id INNER JOIN md_sanpham child ON child.md_sanpham_id=bvt.md_sanpham_id
UNION ALL
SELECT bt.report_id,bt.ma_goc,bt.group_order,bt.sort_type,bt.sort_order,child.md_sanpham_id,child.ma_sanpham,child.mota_tiengviet,
CAST(bt.sl_tich_luy*bvt.soluong AS DECIMAL(38,10)),child.sanpham,child.ban_thanhpham,child.vattu,CAST(bt.id_path+child.md_sanpham_id+N'|' AS NVARCHAR(MAX))
FROM BomTree bt INNER JOIN md_sanpham parent ON parent.md_sanpham_id=bt.child_id INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id=parent.md_sanpham_id
INNER JOIN md_sanpham_bom_vattu bvt ON bvt.md_sanpham_bom_id=bom.md_sanpham_bom_id INNER JOIN md_sanpham child ON child.md_sanpham_id=bvt.md_sanpham_id
WHERE parent.ban_thanhpham=1 AND parent.vattu=1 AND CHARINDEX(N'|'+child.md_sanpham_id+N'|',bt.id_path)=0),
VatTuCuoi AS(SELECT bt.* FROM BomTree bt LEFT JOIN #BomMoiNhat cb ON cb.md_sanpham_id=bt.child_id
WHERE (bt.vattu=1 AND ISNULL(bt.ban_thanhpham,0)=0) OR (bt.ban_thanhpham=1 AND bt.vattu=1 AND cb.md_sanpham_bom_id IS NULL)),
KetQua AS(SELECT report_id,ma_goc,group_order,sort_type,sort_order,child_id vat_tu_id,ma_con ma_vattu,MAX(mota_tiengviet) ten_vattu,CAST(SUM(sl_tich_luy) AS DECIMAL(38,10)) soluong
FROM VatTuCuoi GROUP BY report_id,ma_goc,group_order,sort_type,sort_order,child_id,ma_con)
SELECT ma_goc maHH,ma_vattu maVT,ten_vattu tenVT,soluong sl,group_order,sort_type,sort_order FROM KetQua
ORDER BY group_order,sort_type,sort_order,ma_goc,ma_vattu OPTION(MAXRECURSION 100);";
    }
}
