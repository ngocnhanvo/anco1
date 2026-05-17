<%@ WebHandler Language="C#" Class="KHDH_PhienBanGiaMuaLoad" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;
public class KHDH_PhienBanGiaMuaLoad : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        EntityContext db = new EntityContext();
        //// filter
        String filter = Helper.getFilter(context);
        string dtkd = context.Request.QueryString["dtkd"];
        var ncc = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == dtkd).FirstOrDefault();
        if (ncc == null)
        {
            throw new Exception("Không tìm thấy nhà cung cấp");
        }

        if (!ncc.chophep_chonpbg.GetValueOrDefault(false))
        {
            throw new Exception($"NCC {dtkd} không cho phép chọn phiên bản giá");
        }

        string spid = context.Request.QueryString["spid"];
        string where_ex = context.Request.QueryString["where_ex"];
        int page = Helper.getPage(context);
        int limit = int.Parse(context.Request.QueryString["rows"]);
        String sidx = context.Request.QueryString["sidx"];
        String sord = context.Request.QueryString["sord"];
        String oper_action = context.Request.QueryString["oper_action"];

        int start, end;
        start = limit * page - limit;
        end = (page * limit) + 1;

        string ROW_NUMBER = "";
        string orderby = "pbg.ngay_hieuluc desc";

        ROW_NUMBER = $"ROW_NUMBER() OVER (ORDER BY {orderby}) as RowNum";

        string whereSE = "";
        if (limit < 999999)
            whereSE = $@"and RowNum > {start} AND RowNum < {end}";
        string fromSQL = $@"
            from 
                md_phienbangia pbg
                left join md_giasanpham gsp on gsp.md_phienbangia_id = pbg.md_phienbangia_id
            where 
                pbg.trangthai = '{Helper.HIEULUC}' 
                and gsp.md_sanpham_id = @p1
                and pbg.md_banggia_id in (
                    select bg.md_banggia_id from md_banggia bg where bg.lienket_bg = @p2
                ) {filter}
        ";
        string sql = $@"
            sELeCt P.* 
            fRoM (
                select 
                    pbg.*,
                    gsp.gia,
                    {ROW_NUMBER}
                {fromSQL}
            ) P 
            WHeRe 
                1=1 {whereSE}
            order by 
                RowNum asc
            
        ";
        var dt_select = Mbg.Data.SqlClient.SqlHelper.GetData(sql, "@p1", spid, "@p2", dtkd);

        int count = dt_select.Rows.Count;
        if (limit < 999999)
        {
            string sqlcount = $@"select count(1) {fromSQL}";
            var dt_count = Mbg.Data.SqlClient.SqlHelper.GetData(sqlcount, "@p1", spid, "@p2", dtkd);
            count = int.Parse(dt_count.Rows[0][0].ToString());
        }
        var rs = new Mbg.Web.JqGrid.JqGResult(dt_select, count, page, limit);
        context.Response.Write(rs.WriteJson());
    }
    public bool IsReusable
    {
        get { return false; }
    }
}
