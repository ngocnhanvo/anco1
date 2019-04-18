5
<%@ WebHandler Language="C#" Class="JQGridMD_02_CDHJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_CDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = "vnn";
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
            case "CA01CPX_MD01CDHHPXCP":
                this.CA01CPX_MD01CDHHPXCP(context);
                break;
            case "selectoption_px":
                this.selectoption_px(context);
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

    public void selectoption_px(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string md_sanpham_id = context.Request.QueryString["md_sanpham_id"];
        string id = context.Request.QueryString["id"];
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "";

        c_kehoachdathang_dhcpx dhcpx = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == id).FirstOrDefault();
        //str += firstnull ? string.Format("<option value=\"\"></option>") : "";

        string md_phanxuong_id = db.md_phanxuong.Where(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id).Select(s => s.md_phanxuong_id).FirstOrDefault();
        foreach (md_phanxuong cn in db.md_phanxuong.Where(s => s.md_phanxuong_id != null & s.md_phanxuong_id != "" & s.md_phanxuong_id != md_phanxuong_id & s.md_phanxuong_id != "76A5412072EC46C48207308E85904765"))
        {
            string selected = "";
            if (md_phanxuong_id == cn.md_phanxuong_id) { selected = "selected"; }
            str += string.Format("<option {2} value=\"{0}\">{1}</option>", cn.md_phanxuong_id, cn.ten_phanxuong, selected);
        }
        context.Response.Write(str);
    }

    public void CA01CPX_MD01CDHHPXCP(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string id_sp = context.Request.Form["id_sp"];
		string check_ = context.Request.Form["check_hieuluc"];
        string[] vnn = id_sp.Split(',');
        string md_phanxuong_id = context.Request.Form["md_phanxuong_id"];
        decimal soluong = decimal.Parse(context.Request.Form["soluong"]);
        string c_kehoachdathang_id = "";
        try
        {
            int dhpx_check = db.c_kehoachdathang_dhcpx.Where(s => s.md_phanxuong_id == md_phanxuong_id & s.c_kehoachdathang_dhcpx_id == id).Count();
            if (dhpx_check > 0)
            {
                msg += "<div style='color:red'>Lỗi: phân xưởng chuyển phải khác phân xưởng hiện tại.</div>";
            }
            else
            {
                if (msg.Length <= 0)
                {
                    int i = 0;
                    string id_kehoachdathang_dhcpx = "";
                    foreach (c_kehoachdathang_dhcpx_cdh cdh_px in db.c_kehoachdathang_dhcpx_cdh.Where(s => vnn.Contains(s.c_kehoachdathang_dhcpx_cdh_id)))
                    {
                        c_kehoachdathang_dhcpx dhcpx = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == cdh_px.c_kehoachdathang_dhcpx_id).FirstOrDefault();
						if(check_ == "true")
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
                            md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh_px.md_sanpham_id).FirstOrDefault();
                            msg = "<div style='color:red'>Lỗi: Dòng " + sp.ma_sanpham + " chỉ có thể chuyển tối đa là: " + cdh_px.soluong.Value + ".</div>";
                            break;
                        }
                        else if (soluong <= 0)
                        {
                            msg = "<div style='color:red'>Số lượng phải lớn hơn 0.</div>";
                            break;
                        }
                        else
                        {
                            c_kehoachdathang_id = dhcpx.c_kehoachdathang_id;
                            if (i == 0)
                            {
                                c_kehoachdathang_dhcpx dhcpx_check = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id &
                                s.md_phanxuong_id == md_phanxuong_id & s.dongdathang == " ").Take(1).FirstOrDefault();
                                if (dhcpx_check == null)
                                {
                                    id_kehoachdathang_dhcpx = Helper.getNewId();
                                    c_kehoachdathang_dhcpx dhcpx_new = Clone(dhcpx);
                                    dhcpx_new.c_kehoachdathang_dhcpx_id = id_kehoachdathang_dhcpx;
                                    dhcpx_new.md_phanxuong_id = md_phanxuong_id;
                                    db.c_kehoachdathang_dhcpx.Add(dhcpx_new);
                                }
                                else {
                                    id_kehoachdathang_dhcpx = dhcpx_check.c_kehoachdathang_dhcpx_id;
                                }
                            }
                            //--
                            c_kehoachdathang_dhcpx_cdh cdh_dhcpx_check = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == id_kehoachdathang_dhcpx
            & s.md_sanpham_id == cdh_px.md_sanpham_id).Take(1).FirstOrDefault();
                            if (cdh_dhcpx_check == null)
                            {
                                c_kehoachdathang_dhcpx_cdh cdh_px_new = Clone(cdh_px);
                                cdh_px_new.c_kehoachdathang_dhcpx_cdh_id = Helper.getNewId();
                                cdh_px_new.c_kehoachdathang_dhcpx_id = id_kehoachdathang_dhcpx;
                                cdh_px_new.soluong = soluong;
                                cdh_px_new.ngaycapnhat = null;
                                db.c_kehoachdathang_dhcpx_cdh.Add(cdh_px_new);
                            }
                            else {
                                cdh_dhcpx_check.soluong += soluong;
                            }
                            //--
                            cdh_px.soluong -= soluong;
                            i = 1;
                        }
                    }
                    if (msg.Length <= 0)
                    {
                        md_phanxuong px = db.md_phanxuong.Where(s => s.md_phanxuong_id == md_phanxuong_id).FirstOrDefault();
                        msg = "<div style='color:blue'>Đặt hàng  \"" + px.ten_phanxuong + "\" thành công.</div>";
                        db.SaveChanges();
                        foreach (c_kehoachdathang_dhcpx dhcpx in db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == c_kehoachdathang_id))
                        {
                            decimal tong_soluong = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).Select(s => s.soluong.Value).Sum();
                            if (tong_soluong <= 0)
                            {
                                db.c_kehoachdathang_dhcpx.Remove(dhcpx);
                            }
                            else {
                                foreach (c_kehoachdathang_dhcpx_cdh dhcpx_cdh in db.c_kehoachdathang_dhcpx_cdh.Where(s => s.soluong <= 0))
                                {
                                    db.c_kehoachdathang_dhcpx_cdh.Remove(dhcpx_cdh);
                                }
                            }
                        }
                        db.SaveChanges();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
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
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang_dhcpx_cdh";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;
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
            string id = context.Request.Form["id"];
            string object_ = db.c_kehoachdathang_dhcpx_cdh.Where(p => p.c_kehoachdathang_dhcpx_cdh_id == id).Select(s => s.c_kehoachdathang_dhcpx_cdh_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang_dhcpx_cdh";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
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
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "c_kehoachdathang_dhcpx_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
string object_ = db.c_kehoachdathang_dhcpx_cdh.Where(p => p.c_kehoachdathang_dhcpx_cdh_id == id_del_).Select(s => s.c_kehoachdathang_dhcpx_cdh_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                }
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
            if (msg.Length <= 0)
            {
                msg = "true#Xóa thành công.";
            }
            else
            {
                msg = "false#" + msg;
            }
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