5
<%@ WebHandler Language="C#" Class="JQGridMD_02_CDHJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_CDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
        {
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
            userTK = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context), db);
        }

        switch (oper)
        {
            case "add":
                this.add(context);
                break;
            case "edit":
                this.edit(context);
                break;
            case "del":
                this.del(context);
                break;
            case "CA_01_CPX":
                this.CA_01_CPX(context);
                break;
            case "selectoption_px":
                this.selectoption_px(context);
                break;
            default:
                break;
        }
    }

    public void selectoption_px(HttpContext context)
    {
        string md_sanpham_id = context.Request.QueryString["md_sanpham_id"];
        string id = context.Request.QueryString["id"];
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "";

        c_kehoachdathang_dhcpx dhcpx = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == id).FirstOrDefault();
        //str += firstnull ? string.Format("<option value=\"\"></option>") : "";

        string md_phanxuong_id = db.md_phanxuong.Where(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id).Select(s => s.md_phanxuong_id).FirstOrDefault();
        foreach (var cn in db.md_phanxuong.
                Where(s =>
                !string.IsNullOrEmpty(s.md_phanxuong_id) &
                s.md_phanxuong_id != "76A5412072EC46C48207308E85904765")
                .OrderBy(d => d.ma_phanxuong).ToList())
        {
            string selected = "";
            if (md_phanxuong_id == cn.md_phanxuong_id) { selected = "selected"; }
            str += string.Format("<option {2} value=\"{0}\">{1}</option>", cn.md_phanxuong_id, cn.ten_phanxuong, selected);
        }
        context.Response.Write(str);
    }

    public void CA_01_CPX(HttpContext context)
    {
        var pb = new Public();
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string id_sp = context.Request.Form["id_sp"];
        string check_ = context.Request.Form["check_hieuluc"];
        string check_ghepxuong = context.Request.Form["check_ghepxuong"];
        check_ghepxuong = check_ghepxuong == "true" ? " " : "Cancel";
        string[] vnn = id_sp.Split(',');
        string md_phanxuong_id = context.Request.Form["md_phanxuong_id"];
        decimal soluong = decimal.Parse(context.Request.Form["soluong"]);
        string c_kehoachdathang_id = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                int i = 0;
                string id_kehoachdathang_dhcpx = "";
                foreach (var cdh_px in db.c_kehoachdathang_dhcpx_cdh.Where(s =>
                    vnn.Contains(s.c_kehoachdathang_dhcpx_cdh_id)).ToList())
                {
                    var dhcpx = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == cdh_px.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                    if (check_ == "true")
                    {
                        soluong = cdh_px.soluong.Value;
                    }
                    if (dhcpx.dongdathang != null & dhcpx.dongdathang != "" & dhcpx.dongdathang != " ")
                    {
                        msg += "<div style='color:red'>Lỗi: Dòng \"" + dhcpx.donhang + "\" đã tạo đơn đặt hàng cho phân xưởng, không thể thao tác.</div>";
                        break;
                    }
                    else if (cdh_px.soluong.Value < soluong)
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh_px.md_sanpham_id).FirstOrDefault();
                        msg = "<div style='color:red'>Lỗi: Dòng " + sp.ma_sanpham + " chỉ có thể chuyển tối đa là: " + cdh_px.soluong.Value + ".</div>";
                        break;
                    }
                    else if (soluong <= 0)
                    {
                        msg = "<div style='color:red'>Số lượng phải lớn hơn 0.</div>";
                        break;
                    }
                    else if (db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id
                         & db.c_nhucauvattu_dhpx.Where(t => t.md_dondathangphanxuong_id == s.c_kehoachdathang_dhcpx_id).Count() > 0).Count() > 0)
                    {
                        msg += string.Format(@"<div style='color:red'>Kế hoạch này đã tạo nhu cầu mua vật tư.</div>");
                    }
                    else
                    {
                        c_kehoachdathang_id = dhcpx.c_kehoachdathang_id;
                        if (i == 0)
                        {
                            var dhcpx_check = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id &
                            s.md_phanxuong_id == md_phanxuong_id & s.dongdathang == check_ghepxuong).Take(1).FirstOrDefault();
                            if (dhcpx_check == null)
                            {
                                id_kehoachdathang_dhcpx = Helper.getNewId();
                                c_kehoachdathang_dhcpx dhcpx_new = dhcpx.Clone();
                                dhcpx_new.c_kehoachdathang_dhcpx_id = id_kehoachdathang_dhcpx;
                                dhcpx_new.md_phanxuong_id = md_phanxuong_id;
                                db.c_kehoachdathang_dhcpx.Add(dhcpx_new);
                            }
                            else
                            {
                                id_kehoachdathang_dhcpx = dhcpx_check.c_kehoachdathang_dhcpx_id;
                            }
                        }
                        //--
                        var cdh_dhcpx_check = db.c_kehoachdathang_dhcpx_cdh.Where(s =>
                            s.c_kehoachdathang_dhcpx_id == id_kehoachdathang_dhcpx &
                            s.md_sanpham_id == cdh_px.md_sanpham_id).Take(1).FirstOrDefault();
                        if (cdh_dhcpx_check == null)
                        {
                            c_kehoachdathang_dhcpx_cdh cdh_px_new = cdh_px.Clone();
                            cdh_px_new.c_kehoachdathang_dhcpx_cdh_id = Helper.getNewId();
                            cdh_px_new.c_kehoachdathang_dhcpx_id = id_kehoachdathang_dhcpx;
                            cdh_px_new.soluong = soluong;
                            cdh_px_new.ngaycapnhat = null;
                            db.c_kehoachdathang_dhcpx_cdh.Add(cdh_px_new);
                        }
                        else
                        {
                            cdh_dhcpx_check.soluong += soluong;
                        }
                        //--
                        cdh_px.soluong -= soluong;
                        i = 1;
                    }
                }
                if (msg.Length <= 0)
                {
                    var px = db.md_phanxuong.Where(s => s.md_phanxuong_id == md_phanxuong_id).FirstOrDefault();
                    db.SaveChanges();
                    foreach (var dhcpx in db.c_kehoachdathang_dhcpx.Where(s =>
                        s.c_kehoachdathang_id == c_kehoachdathang_id).ToList())
                    {
                        decimal? tong_soluong = db.c_kehoachdathang_dhcpx_cdh.Where(s =>
                            s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id)
                            .Select(s => s.soluong).Sum();
                        if (tong_soluong.GetValueOrDefault(0) <= 0)
                        {
                            db.c_kehoachdathang_dhcpx.Remove(dhcpx);
                        }
                        else
                        {
                            foreach (var dhcpx_cdh in db.c_kehoachdathang_dhcpx_cdh.Where(s => s.soluong <= 0).ToList())
                            {
                                db.c_kehoachdathang_dhcpx_cdh.Remove(dhcpx_cdh);
                            }
                        }

                        db.c_kehoachdathang_dhcpx_vattu.RemoveRange(
                            db.c_kehoachdathang_dhcpx_vattu.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id));
                        db.SaveChanges();
                    }
                    db.SaveChanges();


                    msg_success = "<div style='color:blue'>Đặt hàng  \"" + px.ten_phanxuong + "\" thành công.</div>";
                }
            }
            catch (Exception ex)
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: {0}.</div>", ex.Message);
            }
            if (msg.Length <= 0)
            {
                msg = msg_success;
                transaction.Commit();
            }
            else
                transaction.Rollback();
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}