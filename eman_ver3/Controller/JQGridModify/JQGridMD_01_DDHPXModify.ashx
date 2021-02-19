<%@ WebHandler Language="C#" Class="JQGridMD_01_DDHPXModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DDHPXModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            default:
                break;
        }
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
        string msg = "", msg_del = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                int count = context.Request.Form["id"].Split(',').Count();
                string[] id_del = new string[count];
                id_del = context.Request.Form["id"].Split(',');

                for (int i = 0; i < count; i++)
                {
                    msg_del = ""; var id_del_ = id_del[i];
                    c_nhucauvattu_dhpx object_ = db.c_nhucauvattu_dhpx.Where(p => p.c_nhucauvattu_dhpx_id == id_del_).Take(1).FirstOrDefault();
                    c_nhucauvattu nc = db.c_nhucauvattu.FirstOrDefault(s => s.c_nhucauvattu_id == object_.c_nhucauvattu_id);
                    if (object_ == null)
                    {
                        msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                        msg += msg_del + "\n";
                    }
                    else if (nc.c_yeucaumuavt_id != null & nc.c_yeucaumuavt_id != "" & nc.c_yeucaumuavt_id != " ")
                    {
                        msg_del = "Lỗi:Đã tạo yêu cầu : \"" + nc.c_yeucaumuavt_id + "\" không thể xóa " + i;
                        msg += msg_del + "\n";
                    }
                    if (msg_del.Length <= 0)
                    {
                        id = object_.c_nhucauvattu_id;
                        db.c_nhucauvattu_dhpx.Remove(object_);
                        var khdh_px = db.c_kehoachdathang_dhcpx.Where(s =>
                            s.c_kehoachdathang_dhcpx_id == object_.md_dondathangphanxuong_id).FirstOrDefault();
                        if (khdh_px != null)
                            khdh_px.tinh_ncvt = false;
                        db.SaveChanges();
                    }
                }

                var ncvt = db.c_nhucauvattu.Where(s => s.c_nhucauvattu_id == id).Take(1).FirstOrDefault();
                if (ncvt == null & msg == "")
                    msg = "Lỗi:Không tìm thấy nhu cầu vật tư.";

                if (msg.Length <= 0)
                {
                    db.c_nhucauvattu_ddhpx.RemoveRange(db.c_nhucauvattu_ddhpx.Where(s => s.c_nhucauvattu_id == id));
                    db.c_nhucauvattu_ycmvt.RemoveRange(db.c_nhucauvattu_ycmvt.Where(s => s.c_nhucauvattu_id == id));
                    ncvt.datinh_nhucau = false;
                    db.SaveChanges();
                    msg_success = "true#Xóa thành công.";
                }
                else
                {
                    msg = "false#" + msg;
                }
            }
            catch (Exception ex)
            {
                msg = "false#Lỗi: " + ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = msg_success;
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
                transaction.Rollback();
        }
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
