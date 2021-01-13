using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Lenhsanxuat_PhieuDeNghiSuaVaGiaoNhanHangTon : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Phiếu Đề Nghị Sửa và Giao Nhận Hàng Tồn.repx";
        string nameRpt = "Phiếu Đề Nghị Sửa và Giao Nhận Hàng Tồn {theodonhang}";
        string sql = CreateSql(context);

        var task = new System.Threading.Tasks.Task(() =>
        {
            viewReport(sql);
        });

        PrintAnco2.exportDataWithType(task, sql, inPDF, nameTemp, nameRpt, ReportViewer1, true);
    }

    public void viewReport(String SqlQuery)
    {
        var tbl = ((DataSet)ReportViewer1.Report.DataSource).Tables[0];

        tbl.Columns.Add("sum_sl_denghigiao", Type.GetType("System.Double"));
        tbl.Columns.Add("dd_yeucau", Type.GetType("System.String"));
        tbl.Columns.Add("MM_yeucau", Type.GetType("System.String"));
        tbl.Columns.Add("yyyy_yeucau", Type.GetType("System.String"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        var sum_sl_denghigiao = tbl.Compute("Sum(sl_denghigiao)", string.Empty).ToString();
        if (string.IsNullOrEmpty(sum_sl_denghigiao))
            tbl.Rows[lastRow]["sum_sl_denghigiao"] = DBNull.Value;
        else
            tbl.Rows[lastRow]["sum_sl_denghigiao"] = double.Parse(sum_sl_denghigiao);

        var sl_denghigiao_cell = ReportViewer1.Report.Report.FindControl("sl_denghigiao", true);
        sl_denghigiao_cell.DataBindings[0].FormatString = sothapphan;
        var sum_sl_denghigiao_cell = ReportViewer1.Report.Report.FindControl("sum_sl_denghigiao", true);
        sum_sl_denghigiao_cell.DataBindings[0].FormatString = sothapphan;
    }

    public String CreateSql(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));

        string slchiato = "sl_chiato";
        if (us.ma_phongban == "PKH")
        {
            slchiato = "sl_chiato2";
        }
        string lsxToId = context.Request.QueryString["id"];
        string vcnbId = context.Request.QueryString["vcnbid"];
        string sql = "";
        if (!string.IsNullOrEmpty(vcnbId))
        {
            sql = string.Format(@"
		        select 
	                A.*
                    , substring(A.cdcht, 0, len(A.cdcht) - 1) as congdoancanhoanthien
                    from
                    (
                        select 
		                    lsx.sochungtu
                            , lsx_tsx.phieulayht as sct_khmvt
		                    , lsx.ngayketthuc as ngayyeucauhoanthanh
		                    , sp.ma_sanpham as ma_vthh
		                    , dvtsp.ten_dvt as dvt
		                    , cdvc.soluong_muonchuyen as sl_denghigiao
		                    , dhpx.donhang_thamchieu as theodonhang
		                    , cdvc.mota as ghichu
		                    , pxto.ten_to as tosx
		                    , (
			                    SELECT isnull(T.congdoan + ' + ','')
			                    FROM md_phanxuong_to T
			                    WHERE 
			                    1 = 1
			                    and T.md_phanxuong_id = lsx_tsx.md_phanxuong_id
			                    and (cast(T.sapxep as int) > cast(pxto.sapxep as int) or (
                                    pxto.sapxep = T.sapxep and lsx_tsx.stt = 9999
                                ))
			                    order by T.sapxep
			                    FOR XML PATH(''), type
		                    ).value('.','nvarchar(max)') as cdcht
		                    , (select ten_phanxuong from md_phanxuong where lsx_tsx.md_phanxuong_id = md_phanxuong_id) as bophanyc
	                    from md_lenhsanxuat lsx
		                    left join md_dondathangphanxuong dhpx on lsx.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
		                    left join md_lenhsanxuat_tosx lsx_tsx on lsx_tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
		                    left join md_vanchuyennoibo_cdvc cdvc on cdvc.tukho = lsx_tsx.md_lenhsanxuat_tosx_id
			                left join md_vanchuyennoibo vcnb on vcnb.md_vanchuyennoibo_id = cdvc.md_vanchuyennoibo_id
		                    left join md_sanpham sp on cdvc.md_sanpham_id = sp.md_sanpham_id
		                    left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		                    left join md_phanxuong_to pxto on pxto.md_to_id = lsx_tsx.md_phanxuong_to_id
	                    where 1=1
		                    and vcnb.md_vanchuyennoibo_id in ('{0}')
		                    and cdvc.soluong_muonchuyen > 0
                    )A
                    order by A.ma_vthh asc
		        "
                , vcnbId
                , slchiato
            );
        }
        else
        {
            sql = string.Format(@"
		        select 
                    A.*
                    , substring(A.cdcht, 0, len(A.cdcht) - 1) as congdoancanhoanthien
                    from
                    (
                        select 
		                    lsx.sochungtu
                            , lsx_tsx.phieulayht as sct_khmvt
		                    , lsx.ngayketthuc as ngayyeucauhoanthanh
		                    , sp.ma_sanpham as ma_vthh
		                    , dvtsp.ten_dvt as dvt
		                    , lht.sl_layton as sl_denghigiao
		                    , dhpx.donhang_thamchieu as theodonhang
		                    , lht.mota as ghichu
		                    , pxto.ten_to as tosx
		                    , (
			                    SELECT isnull(T.congdoan + ' + ','')
			                    FROM md_phanxuong_to T
			                    WHERE 
			                    1 = 1
			                    and T.md_phanxuong_id = lsx_tsx.md_phanxuong_id
			                    and (cast(T.sapxep as int) > cast(pxto.sapxep as int) or (
                                    pxto.sapxep = T.sapxep and lsx_tsx.stt = 9999
                                ))
			                    order by T.sapxep
			                    FOR XML PATH(''), type
		                    ).value('.','nvarchar(max)') as cdcht
		                    , (select ten_phanxuong from md_phanxuong where lsx_tsx.md_phanxuong_id = md_phanxuong_id) as bophanyc
	                    from md_lenhsanxuat lsx
		                    left join md_dondathangphanxuong dhpx on lsx.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
		                    left join md_lenhsanxuat_tosx lsx_tsx on lsx_tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
		                    left join md_lenhsanxuat_tosx_dklht lht on lht.md_lenhsanxuat_tosx_id = lsx_tsx.md_lenhsanxuat_tosx_id
		                    left join md_sanpham sp on lht.md_sanpham_id = sp.md_sanpham_id
		                    left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		                    left join md_phanxuong_to pxto on pxto.md_to_id = lsx_tsx.md_phanxuong_to_id
	                    where 1=1
		                    and lsx_tsx.md_lenhsanxuat_tosx_id in ('{0}')
		                    and lht.sl_layton > 0
                    )A
                    order by A.ma_vthh asc
		        "
                , lsxToId
                , slchiato
            );
        }

        return sql;
    }
}