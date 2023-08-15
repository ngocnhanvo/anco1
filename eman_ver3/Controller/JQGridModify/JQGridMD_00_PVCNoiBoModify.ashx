<%@ WebHandler Language="C#" Class="JQGridMD_00_PVCNoiBoModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_PVCNoiBoModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    EntityContext db;
    EntityFunction entityFunc;
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
        {
            db = new EntityContext();
            entityFunc = new EntityFunction();
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
            case "CA_01_XuLyVanChuyen":
                this.CA_01_XuLyVanChuyen(context);
                break;
            case "CA_01_XacNhanVCNB":
                this.CA_01_XacNhanVCNB(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XacNhanVCNB(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void CA_01_XuLyVanChuyen(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        var pub = new Public();
        msg = pub.HieuLucPhieuVanChuyen(db, userTK, ma_module, id, context.Request.Form["koCapnhatDLSX"]);
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
        string ma_module = context.Request.QueryString["ma_module"];
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];
        string id = context.Request.Form["id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                var object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id).Take(1).FirstOrDefault();
                denkho = db.md_kho.Where(s => s.md_kho_id == denkho).Select(s => s.md_kho_id).FirstOrDefault();
                tukho = db.md_kho.Where(s => s.md_kho_id == tukho).Select(s => s.md_kho_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg = string.Format(@"Lỗi:Không tìm thấy đối tượng cần sửa.");
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                    msg = string.Format(@"Lỗi:Dòng {0} đã Hiệu lực", object_.sochungtu);
                }
                else if (tukho == denkho)
                {
                    msg = string.Format(@"Lỗi: Kho chuyển không được giống với kho đến");
                }
                else if (string.IsNullOrEmpty(tukho) | string.IsNullOrEmpty(denkho))
                {
                    msg = string.Format(@"Lỗi:Bạn phải chọn Kho chuyển và kho đến");
                }
                else if (ngaychuyen.IsDate() == false)
                {
                    msg = string.Format(@"Lỗi:Ngày chuyển không đúng định dạng");
                }

                if (msg.Length <= 0)
                {
                    if (object_.loaichuyen == "VANCNBCTKGH")
                        object_.denkho = denkho;
                    object_.ngaychuyen = ngaychuyen;
                    object_.ngaycapnhat = DateTime.Now;
                    object_.mota = context.Request.Form["mota"];
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Cập nhật thành công");
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id_del_).Take(1).FirstOrDefault();
                    var dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần trả.", id_del_);
                    }
                    else if (object_.md_trangthai_id == "HIEULUC")
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Đã được ""Hiệu Lực"".", object_.sochungtu, object_.donhang_thamchieu);
                    }
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "PVCNB:" + object_.sochungtu + " DHTC:" + object_.donhang_thamchieu , db);
                        object_.md_trangthai_id = "SOANTHAO";
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Trả phiếu đã chọn về ""Soạn Thảo"" thành công");
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg.Substring(4));
                transaction.Rollback();
            }
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