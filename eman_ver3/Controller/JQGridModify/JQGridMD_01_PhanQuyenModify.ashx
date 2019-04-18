<%@ WebHandler Language="C#" Class="JQGridMD_01_PhanQuyenModify" %>
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using DataAcess;
using Newtonsoft.Json;
public class JQGridMD_01_PhanQuyenModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {

        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];

        switch (oper)
        {
            case "phanquyen":
                this.phanquyen(context);
                break;
            case "delete":
                this.delete(context);
                break;
            default:
                break;
        }
    }

    public void phanquyen(HttpContext context)
    {
        ADmin_JSON json = new ADmin_JSON();
        List<ad_role_mmc> lst = json.ad_role_mmcJSON();
        List<ad_case> lstAdCase = json.ad_caseJSON();
        List<ad_menu> lstAdMenu = json.ad_menuJSON();
        List<ad_module> lstAdModule = json.ad_moduleJSON();

        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            string ad_menu_id = context.Request.Form["ad_menu_id"];
            string ad_module_id = context.Request.Form["ad_module_id"];
            string[] ad_case_id = context.Request.Form["ad_case_id"].Split('#');
            string[] ad_case_id2 = context.Request.Form["ad_case_id2"].Split('#');

            int count = ad_case_id.Count();
            int count2 = ad_case_id2.Count();
            ad_menu mn = lstAdMenu.SingleOrDefault(p => p.ad_menu_id.Equals(ad_menu_id));
            ad_module mod = lstAdModule.SingleOrDefault(p => p.ad_module_id.Equals(ad_module_id));
            var ds_pq = db.ad_role_mmc.Where(s => s.ad_menu_id == ad_menu_id & s.ad_module_id == ad_module_id & s.ad_role_id == id).ToList();
            List<string> idDels = new List<string>();
            foreach (ad_role_mmc pq_2 in ds_pq)
            {
                bool co = false;
                for (int i = 0; i < count - 1; i++)
                {
                    if (ad_case_id[i] != "" & ad_case_id[i] != null & ad_case_id[i] == pq_2.ad_case_id)
                    {
                        co = true;
                    }
                }

                for (int i = 0; i < count2 - 1; i++)
                {
                    if (ad_case_id2[i] != "" & ad_case_id2[i] != null & ad_case_id2[i] == pq_2.ad_case_id)
                    {
                        co = true;
                    }
                }

                if (co == false)
                {
                    msg += "<div class='nhan-thanhcong' style='color:red'>Đóng chức năng \"" + pq_2.ten_case +
                                    "\" của module:\"" + mod.ten_module + "\" trong menu:\"" + mn.ten_menu + "\" thành công!!!</div>";
                }
                db.ad_role_mmc.Remove(pq_2);
                idDels.Add(pq_2.ad_role_mmc_id);
            }
            db.SaveChanges();
            lst = lst.Where(s => !idDels.Contains(s.ad_role_mmc_id)).ToList();

            List<ad_role_mmc> idAdds = new List<ad_role_mmc>();
            for (int i = 0; i < count - 1; i++)
            {
                string ad_case_idI = ad_case_id[i];
                if (ad_case_idI != "" & ad_case_idI != null)
                {
                    ad_case cn = lstAdCase.SingleOrDefault(p => p.ad_case_id.Equals(ad_case_idI));
                    if (cn != null)
                    {
                        ad_role_mmc pqrole = VNN_Function.ThemPhanQuyen(context, id, mn.ad_menu_id, mod.ad_module_id, cn.ad_case_id);
                        idAdds.Add(pqrole);
                        msg += "<div class='nhan-thanhcong'>Kích hoạt chức năng \"" + cn.ten_case +
                            "\" của module:\"" + mod.ten_module + "\" trong menu:\"" + mn.ten_menu + "\" thành công!!!</div>";
                    }
                    else
                    {
                        msg += "<div class='nhan-thanhcong'  style='color:red'>Không tìm thấy chức năng.</div>";
                    }
                }
            }

            for (int i = 0; i < count2 - 1; i++)
            {
                string ad_case_id2I = ad_case_id2[i];
                if (ad_case_id2I != "" & ad_case_id2I != null)
                {
                    ad_case cn = lstAdCase.SingleOrDefault(p => p.ad_case_id.Equals(ad_case_id2I));
                    if (cn != null)
                    {
                        ad_role_mmc pqrole = VNN_Function.ThemPhanQuyen(context, id, mn.ad_menu_id, mod.ad_module_id, cn.ad_case_id);
                        idAdds.Add(pqrole);
                        msg += "<div class='nhan-thanhcong'>Kích hoạt chức năng \"" + cn.ten_case +
                        "\" của module:\"" + mod.ten_module + "\" trong menu:\"" + mn.ten_menu + "\" thành công!!!</div>";
                    }
                    else
                    {
                        msg += "<div class='nhan-thanhcong'  style='color:red'>Không tìm thấy chức năng.</div>";
                    }
                }
            }
            if(idAdds.Count > 0)
                lst.AddRange(idAdds);

            string jsonData = JsonConvert.SerializeObject(lst, Formatting.Indented);
            json.urlData = typeof(ad_role_mmc).Name;
            json.WriteJson(jsonData);
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void delete(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            string ad_menu_id = context.Request.Form["ad_menu_id"];
            string ad_module_id = context.Request.Form["ad_module_id"];
            ad_menu mn = db.ad_menu.SingleOrDefault(p => p.ad_menu_id == ad_menu_id);
            ad_module mod = db.ad_module.SingleOrDefault(p => p.ad_module_id == ad_module_id);

            foreach (ad_role_mmc pq in db.ad_role_mmc.Where(p => p.ad_menu_id == mn.ad_menu_id & p.ad_module_id == mod.ad_module_id & p.ad_role_id == id).ToList())
            {
                db.ad_role_mmc.Remove(pq);
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
            msg = "true#Xóa thành công!!!";
        }
        catch (Exception ex)
        {
            if (ex.Message.ToUpper().Contains("REFERENCE"))
            {
                msg = "false#Lỗi: Đang được sử dụng, không thể xóa";
            }
            else
            {
                msg = "false#Lỗi: " + ex.Message;
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
