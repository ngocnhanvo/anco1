<%@ WebHandler Language="C#" Class="JQGridMD_00_VtroPquyenModify" %>
using System;
using System.Web;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_VtroPquyenModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];

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
            case "selectoption":
                this.SelectOption(context);
                break;
            case "CA_01_CopyVaiTro":
                this.CA_01_CopyVaiTro(context);
                break;
            default:
                break;
        }
    }
    public static T Clone<T>(T source)
    {
        var dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
        using (var ms = new System.IO.MemoryStream())
        {
            dcs.WriteObject(ms, source);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            return (T)dcs.ReadObject(ms);
        }
    }

    public void CA_01_CopyVaiTro(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var json = new ADmin_JSON();
        List<ad_role_mmc> lst = json.ad_role_mmcJSON();
        string msg = "", id_new = Helper.getNewId();
        string sel_vaitro_copy = context.Request.Form["sel_vaitro_copy"];
        string id = context.Request.Form["id"];
        ad_role role_cp = db.ad_role.FirstOrDefault(s => s.ad_role_id == sel_vaitro_copy);
        if (role_cp != null)
        {
            ad_role role = db.ad_role.FirstOrDefault(s => s.ad_role_id == id);
            if (role != null)
            {
                List<string> idDels = new List<string>();
                foreach (var r_m in db.ad_role_mmc.Where(s => s.ad_role_id == role.ad_role_id).ToList())
                {
                    db.ad_role_mmc.Remove(r_m);
                    idDels.Add(r_m.ad_role_mmc_id);
                }

                foreach (var r_m in db.ad_role_where.Where(s => s.ad_role_id == role.ad_role_id).ToList())
                {
                    db.ad_role_where.Remove(r_m);
                }

                db.SaveChanges();
                lst = lst.Where(s => !idDels.Contains(s.ad_role_mmc_id)).ToList();

                List<ad_role_mmc> idAdds = new List<ad_role_mmc>();
                foreach (var r_m in db.ad_role_mmc.Where(s => s.ad_role_id == sel_vaitro_copy).ToList())
                {
                    ad_role_mmc r_m_new = Clone(r_m);
                    r_m_new.ad_role_mmc_id = Helper.getNewId();
                    r_m_new.ad_role_id = role.ad_role_id;
                    db.ad_role_mmc.Add(r_m_new);
                    idAdds.Add(r_m_new);
                }

                foreach (var r_w in db.ad_role_where.Where(s => s.ad_role_id == sel_vaitro_copy).ToList())
                {
                    ad_role_where r_w_new = Clone(r_w);
                    r_w_new.ad_role_where_id = Helper.getNewId();
                    r_w_new.ad_role_id = role.ad_role_id;
                    db.ad_role_where.Add(r_w_new);
                }
                db.SaveChanges();
                if(idAdds.Count > 0)
                    lst.AddRange(idAdds);

                string jsonData = JsonConvert.SerializeObject(lst, Formatting.Indented);
                json.urlData = typeof(ad_role_mmc).Name;
                json.WriteJson(jsonData);

                msg += "<div class='nhan-thanhcong' style='color:blue'>\"" + role.ten_role + "\" đã copy lại vai trò \"" + role_cp.ten_role + "\"";
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ma_role = context.Request.Form["ma_role"];
            string loai_thuake = context.Request.Form["loai_thuake"];
            if (ma_role.Length <= 0)
            {
                msg = "false#Mã vai trò không thể bỏ trống!";
            }
            else if (db.ad_role.SingleOrDefault(p => p.ten_role.Equals(ma_role)) != null)
            {
                msg = "false#Mã vai trò này đã tồn tại!";
            }

            if (msg.Length <= 0)
            {
                ad_role vtr = new ad_role
                {
                    ad_role_id = id_new,
                    ma_role = ma_role,
                    ten_role = context.Request.Form["ten_role"],
                    role_thuake = (loai_thuake == "update_0") ? context.Request.Form["role_thuake"] : "",

                    ngaytao = DateTime.Now,
                    nguoitao = Security.id_taikhoan(context),
                    ngaycapnhat = DateTime.Now,
                    nguoicapnhat = Security.id_taikhoan(context),
                    mota = context.Request.Form["mota"],
                    hoatdong = true
                };
                db.ad_role.Add(vtr);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công!" + "#" + id_new;
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }


    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string loai_thuake = context.Request.Form["loai_thuake"];
            string id = context.Request.Form["id"];
            ad_role vtr = db.ad_role.SingleOrDefault(p => p.ad_role_id == id);
            if (vtr != null)
            {
                vtr.ten_role = context.Request.Form["ten_role"];
                vtr.ma_role = context.Request.Form["ma_role"];
                vtr.role_thuake = (loai_thuake == "update_0") ? context.Request.Form["role_thuake"] : "";
                vtr.ngaytao = DateTime.Now;
                vtr.nguoitao = Security.id_taikhoan(context);
                vtr.ngaycapnhat = DateTime.Now;
                vtr.nguoicapnhat = Security.id_taikhoan(context);
                vtr.mota = context.Request.Form["mota"];
                vtr.hoatdong = true;
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công!";
            }
            else
            {
                msg = "false#Không tìm thấy đối tượng.";
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.ad_role.Where(p => p.ad_role_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else
                    {
                        var checkUse = db.ad_user_role.Where(s => s.ad_role_id == object_.ad_role_id).Take(1).Count();
                        if (checkUse > 0)
                            msg += string.Format(@"<br><b>{0}</b>: Có liên kết với Tài Khoản.", object_.ten_role);
                        else
                        {
                            VNN_Function.Write_log(context, ma_module, null, oper, "MVT:" + object_.ma_role + ", TVT:" + object_.ten_role, db);
                            db.ad_role.Remove(object_);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                msg = @"true#Xóa vai trò đã chọn thành công.";
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

    public void SelectOption(HttpContext context)
    {
        EntityContext db = new EntityContext();
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "";
        str += "<select>";
        str += firstnull ? string.Format("<option value=\"\"></option>") : "";
        foreach (var ccv in db.ad_role.OrderBy(p => p.ten_role))
        {
            str += string.Format("<option value=\"{0}\">{1}</option>", ccv.ad_role_id, ccv.ten_role);
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
