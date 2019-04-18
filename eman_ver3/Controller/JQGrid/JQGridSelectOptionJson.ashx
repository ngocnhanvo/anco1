<%@ WebHandler Language="C#" Class="JQGridSelectOptionJson" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;

public class JQGridSelectOptionJson : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
        switch (oper)
        {
            case "selHanSuDung":
                this.selHanSuDung(context);
                break;
        }
    }

    public void selHanSuDung(HttpContext context)
    {
        var db = new EntityContext();
        string id_parent = context.Request.Form["id_parent"];
        string khoId = db.md_baotrivthh.Where(s => s.md_baotrivthh_id == id_parent).Select(s => s.md_kho_id).FirstOrDefault();
        string ma_sanpham = context.Request.Form["ma_sanpham"];
        string spId = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Select(s => s.md_sanpham_id).FirstOrDefault();
        string khoSpId = db.md_kho_sanpham.Where(s => s.md_kho_id == khoId & s.md_sanpham_id == spId).Select(s => s.md_kho_sanpham_id).FirstOrDefault();
        var hsd = db.md_kho_sanpham_hansudung.Where(s => s.md_kho_sanpham_id == khoSpId).OrderBy(s => s.ngay_hethan).Select(s => s.ngay_hethan).ToList();
        context.Response.Write(
            string.Join(",", hsd.Select(s =>
                    s.Value.ToString(VNN_Config.get_FormatDate()).Split(' ')[0]
                )
            )
        );
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
