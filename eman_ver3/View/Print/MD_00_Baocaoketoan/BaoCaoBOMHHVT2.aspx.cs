using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

public partial class PrintControllers_MD_00_Baocaoketoan_BaoCaoBOMHHVT2 : System.Web.UI.Page
{
    private const int FixedColumnCount = 4;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentEncoding = Encoding.UTF8;
        Response.Charset = "utf-8";

        if (IsPostBack) return;

        string masp = (Request.QueryString["masp"] ?? "").Trim();
        if (string.IsNullOrWhiteSpace(masp))
        {
            litSummary.Text = "<span class=\"summary\">Ch\u1ebf \u0111\u1ed9 to\u00e0n b\u1ed9 d\u1eef li\u1ec7u</span>";
            litMatrix.Text =
                "<div class=\"empty\">" +
                "D\u1eef li\u1ec7u to\u00e0n b\u1ed9 qu\u00e1 l\u1edbn n\u00ean kh\u00f4ng hi\u1ec3n th\u1ecb b\u1ea3n xem tr\u01b0\u1edbc. " +
                "Vui l\u00f2ng b\u1ea5m <b>Xu\u1ea5t Excel d\u1eef li\u1ec7u (.xlsx)</b> \u0111\u1ec3 t\u1ea3i to\u00e0n b\u1ed9." +
                "</div>";
            return;
        }

        RenderMatrix(LoadMatrix());
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
        result.Columns.Add("M\u00c3 HH", typeof(string));
        result.Columns.Add("T\u00caN TV", typeof(string));
        result.Columns.Add("\u0110VT", typeof(string));
        result.Columns.Add("TR\u1eccNG L\u01af\u1ee2NG", typeof(decimal));

        if (source == null || source.Rows.Count == 0) return result;

        var vatTus = source.AsEnumerable()
            .Where(r => !r.IsNull("maVT"))
            .Select(r => new
            {
                MaVT = Convert.ToString(r["maVT"]).Trim(),
                TenVT = r.IsNull("tenVT") ? "" : Convert.ToString(r["tenVT"]).Trim(),
                DvtVT = r.IsNull("dvtVT") ? "" : Convert.ToString(r["dvtVT"]).Trim()
            })
            .Where(x => !string.IsNullOrWhiteSpace(x.MaVT))
            .GroupBy(x => x.MaVT, StringComparer.OrdinalIgnoreCase)
            .Select(g => new
            {
                MaVT = g.Key,
                TenVT = g.Select(x => x.TenVT).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? "",
                DvtVT = g.Select(x => x.DvtVT).FirstOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? ""
            })
            .OrderBy(x => x.MaVT, StringComparer.OrdinalIgnoreCase)
            .ToList();

        foreach (var vatTu in vatTus)
        {
            DataColumn column = result.Columns.Add(vatTu.MaVT, typeof(decimal));
            column.ExtendedProperties["MaVT"] = vatTu.MaVT;
            column.ExtendedProperties["TenVT"] = vatTu.TenVT;
            column.ExtendedProperties["DvtVT"] = vatTu.DvtVT;
            column.ExtendedProperties["IsMaterial"] = true;
        }

        var hangHoas = source.AsEnumerable().GroupBy(r => new
        {
            MaHH = Convert.ToString(r["maHH"]),
            TenHH = r.IsNull("tenHH") ? "" : Convert.ToString(r["tenHH"]).Trim(),
            DvtHH = r.IsNull("dvtHH") ? "" : Convert.ToString(r["dvtHH"]).Trim(),
            TrongLuong = r.IsNull("trongluongHH") ? (decimal?)null : Convert.ToDecimal(r["trongluongHH"]),
            GroupOrder = Convert.ToInt32(r["group_order"]),
            SortType = Convert.ToInt32(r["sort_type"]),
            SortOrder = Convert.ToInt32(r["sort_order"])
        }).OrderBy(g => g.Key.GroupOrder).ThenBy(g => g.Key.SortType).ThenBy(g => g.Key.SortOrder)
          .ThenBy(g => g.Key.MaHH, StringComparer.OrdinalIgnoreCase);

        foreach (var hangHoa in hangHoas)
        {
            DataRow row = result.NewRow();
            row[0] = hangHoa.Key.MaHH;
            row[1] = hangHoa.Key.TenHH;
            row[2] = hangHoa.Key.DvtHH;
            row[3] = hangHoa.Key.TrongLuong.HasValue ? (object)hangHoa.Key.TrongLuong.Value : DBNull.Value;

            for (int c = FixedColumnCount; c < result.Columns.Count; c++)
                row[c] = 0m;

            foreach (DataRow item in hangHoa)
            {
                if (item.IsNull("maVT") || item.IsNull("sl")) continue;
                string maVT = Convert.ToString(item["maVT"]).Trim();
                if (result.Columns.Contains(maVT))
                    row[maVT] = Convert.ToDecimal(row[maVT]) + Convert.ToDecimal(item["sl"]);
            }
            result.Rows.Add(row);
        }
        return result;
    }

    private void RenderMatrix(DataTable matrix)
    {
        litSummary.Text = "<span class=\"summary\">" + matrix.Rows.Count + " m\u00e3 h\u00e0ng \u00b7 " + Math.Max(0, matrix.Columns.Count - FixedColumnCount) + " v\u1eadt t\u01b0</span>";
        if (matrix.Rows.Count == 0)
        {
            litMatrix.Text = "<div class=\"empty\">Kh\u00f4ng c\u00f3 d\u1eef li\u1ec7u</div>";
            return;
        }

        var html = new StringBuilder("<table><thead>");

        html.Append("<tr><th></th><th></th><th></th><th>M\u00c3 VT</th>");
        for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
            html.Append("<th>").Append(HttpUtility.HtmlEncode(GetColumnProperty(matrix.Columns[c], "MaVT"))).Append("</th>");
        html.Append("</tr>");

        html.Append("<tr><th></th><th></th><th></th><th>T\u00caN VT</th>");
        for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
            html.Append("<th>").Append(HttpUtility.HtmlEncode(GetColumnProperty(matrix.Columns[c], "TenVT"))).Append("</th>");
        html.Append("</tr>");

        html.Append("<tr><th></th><th></th><th></th><th>\u0110VT</th>");
        for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
            html.Append("<th>").Append(HttpUtility.HtmlEncode(GetColumnProperty(matrix.Columns[c], "DvtVT"))).Append("</th>");
        html.Append("</tr>");

        html.Append("<tr>");
        for (int c = 0; c < FixedColumnCount; c++)
            html.Append("<th>").Append(HttpUtility.HtmlEncode(matrix.Columns[c].ColumnName)).Append("</th>");
        for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
            html.Append("<th></th>");
        html.Append("</tr></thead><tbody>");

        foreach (DataRow row in matrix.Rows)
        {
            html.Append("<tr>");
            html.Append("<td class=\"code\">").Append(HttpUtility.HtmlEncode(Convert.ToString(row[0]))).Append("</td>");
            html.Append("<td>").Append(HttpUtility.HtmlEncode(Convert.ToString(row[1]))).Append("</td>");
            html.Append("<td>").Append(HttpUtility.HtmlEncode(Convert.ToString(row[2]))).Append("</td>");
            html.Append("<td class=\"num\">");
            if (!row.IsNull(3)) html.Append(Convert.ToDecimal(row[3]).ToString("0.##########", CultureInfo.InvariantCulture));
            html.Append("</td>");

            for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
                html.Append("<td class=\"num\">").Append((row.IsNull(c) ? 0m : Convert.ToDecimal(row[c])).ToString("0.##########", CultureInfo.InvariantCulture)).Append("</td>");
            html.Append("</tr>");
        }
        litMatrix.Text = html.Append("</tbody></table>").ToString();
    }

    private static string GetColumnProperty(DataColumn column, string key)
    {
        object value = column.ExtendedProperties[key];
        return value == null ? "" : Convert.ToString(value);
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        BomHhvtSpreadsheetMlExporter.Export(Response, LoadMatrix());
    }

    public string CreateSql(HttpContext context)
    {
        string khoValue = (context.Request.QueryString["kho"] ?? "").removeAllSpaceOrTrimText(true).Replace("'", "''");
        string maspValue = (context.Request.QueryString["masp"] ?? "").removeAllSpaceOrTrimText(true).Replace("'", "''");
        string kho = string.IsNullOrWhiteSpace(khoValue) ? "" : $@"and sp.khomacdinh = N'{khoValue}'";
        // masp h\u1ed7 tr\u1ee3 wildcard SQL LIKE. V\u00ed d\u1ee5 URL masp=36-%25 s\u1ebd \u0111\u01b0\u1ee3c decode th\u00e0nh 36-%.
        // N\u1ebfu kh\u00f4ng c\u00f3 wildcard (v\u00ed d\u1ee5 36-00105-TC-01), LIKE v\u1eabn t\u01b0\u01a1ng \u0111\u01b0\u01a1ng so kh\u1edbp ch\u00ednh x\u00e1c.
        string masp = string.IsNullOrWhiteSpace(maspValue) ? "" : $@"and sp.ma_sanpham LIKE N'{maspValue}'";
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
SELECT kq.ma_goc maHH,
       hh.mota_tiengviet tenHH,
       dvthh.ten_dvt dvtHH,
       hh.trongluong trongluongHH,
       kq.ma_vattu maVT,
       kq.ten_vattu tenVT,
       dvtvt.ten_dvt dvtVT,
       kq.soluong sl,
       kq.group_order,kq.sort_type,kq.sort_order
FROM KetQua kq
LEFT JOIN md_sanpham hh ON hh.md_sanpham_id=kq.report_id
LEFT JOIN md_donvitinhsanpham dvthh ON dvthh.md_donvitinhsanpham_id=hh.md_donvitinhsanpham_id
LEFT JOIN md_sanpham vt ON vt.md_sanpham_id=kq.vat_tu_id
LEFT JOIN md_donvitinhsanpham dvtvt ON dvtvt.md_donvitinhsanpham_id=vt.md_donvitinhsanpham_id
ORDER BY kq.group_order,kq.sort_type,kq.sort_order,kq.ma_goc,kq.ma_vattu OPTION(MAXRECURSION 100);";
    }
}
