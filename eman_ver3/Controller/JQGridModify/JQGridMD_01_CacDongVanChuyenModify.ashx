<%@ WebHandler Language="C#" Class="JQGridMD_01_CacDongVanChuyenModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_01_CacDongVanChuyenModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLcanchuyen":
                this.CA_01_CapnhatSLcanchuyen(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapnhatSLcanchuyen(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        md_vanchuyennoibo vcnb = null;
        using (var transaction = db.Database.BeginTransaction())
        {
            foreach (var cdvc in db.md_vanchuyennoibo_cdvc.Where(s => vnn.Contains(s.md_vanchuyennoibo_cdvc_id)).ToList())
            {
                vcnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == cdvc.md_vanchuyennoibo_id).FirstOrDefault();
                if (vcnb.md_trangthai_id == "HIEULUC")
                {
                    msg = "<div style='color:red'>Lỗi:Dòng " + vcnb.sochungtu + " đã Hiệu lực.</div>";
                    break;
                }
                else
                {
                    decimal sltd = cdvc.soluong_toida.Value - cdvc.soluong_dachuyen.Value;
                    if (sel_val == "0")
                    {
                        cdvc.soluong_dichchuyen = sltd;
                    }
                    else
                    {
                        if (slvc_case <= sltd)
                        {
                            cdvc.soluong_dichchuyen = slvc_case;
                        }
                        else
                        {
                            md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdvc.md_sanpham_id).Take(1).FirstOrDefault();
                            msg = "<div style='color:red'>lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có thể chuyển tối đa là: " + Math.Round(sltd, 0) + "</div>";
                            break;
                        }
                    }
                    db.SaveChanges();
                }
            }

            if (vcnb.loaichuyen == "VANCNBCTKGH")
            {
                foreach (var cdvc in db.md_vanchuyennoibo_cdvc.Where(s => vnn.Contains(s.md_vanchuyennoibo_cdvc_id)).ToList())
                {
                    var slcl = new List<Dictionary<string, object>>();
                    foreach (var b in db.md_vanchuyennoibo_cdvc.Where(s =>
                        s.md_vanchuyennoibo_id == cdvc.md_vanchuyennoibo_id
                        & s.lsx_to == cdvc.lsx_to).ToList())
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == b.md_sanpham_id).FirstOrDefault();
                        var tsx = Extension.getLSXToId(b.lsx_to, db);
                        var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                            & s.macuoi.Contains(sp.ma_sanpham));

                        foreach (var cai in lsxSp.ToList())
                        {
                            var caiJSon = slcl.Where(s => s["md_sanpham_id"] + "" == cai.md_sanpham_id).FirstOrDefault();
                            if (caiJSon == null)
                            {
                                slcl.Add(new Dictionary<string, object>() {
                                { "md_sanpham_id", cai.md_sanpham_id },
                                { "soluong", b.soluong_dichchuyen },
                                { "sltd", cai.sl_dahoanthanh }
                            });
                            }
                            else
                            {
                                caiJSon["soluong"] = b.soluong_dichchuyen + decimal.Parse(caiJSon["soluong"].ToString());
                            }
                        }
                    }

                    foreach (var itemSLTH in slcl)
                    {
                        string spId = itemSLTH["md_sanpham_id"].ToString();
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == spId).FirstOrDefault();
                        var sl = decimal.Parse(itemSLTH["soluong"].ToString());
                        var sltd2 = decimal.Parse(itemSLTH["sltd"].ToString());
                        if (sl > sltd2)
                        {
                            msg += string.Format(@"Mã cái ""{0}"" không đáp ứng đủ.<br>", sp.ma_sanpham);
                        }
                    }
                }
            }

            if (msg.Length <= 0)
            {
                msg = "<div style='color:blue'>Cập nhật số lượng cần chuyển thành công</div>";
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        md_sanpham sp = db.md_sanpham.FirstOrDefault(s => s.ma_sanpham == ma_sanpham);

        try
        {
            decimal soluong_dichchuyen = decimal.Parse(context.Request.Form["soluong_dichchuyen"]);
            string id = context.Request.Form["id_parent"];
            int dem = db.md_vanchuyennoibo_cdvc.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.md_vanchuyennoibo_id == id).Count();
            var vnnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == id).FirstOrDefault();
            if (vnnb.md_trangthai_id == "HIEULUC")
                msg = "false#Lỗi:Dòng " + vnnb.sochungtu + " đã Hiệu lực.";
            else if (vnnb.chungtuthamchieu != "")
                msg = "false#Lỗi:Dòng \"" + vnnb.sochungtu + "\" thừa kế từ PXK \"" + vnnb.chungtuthamchieu + "\", không thể tạo dòng hàng.";
            else if (dem > 0)
                msg = "false#Lỗi:Mã " + sp.ma_sanpham + " đã tồn tại.";
            else if (soluong_dichchuyen <= 0)
                msg = "false#Lỗi:Số lượng dịch chuyển phải lớn hơn 0.";
            else if (db.md_kho_sanpham.Where(s => s.md_kho_id == vnnb.tukho & s.md_sanpham_id == sp.md_sanpham_id & s.soluong > 0).Count() <= 0)
                msg = string.Format(@"false#HHVT ""{0}"" không có trong kho.", ma_sanpham);

            string loaichuyen = context.Request.Form["loaichuyen"];
            if (loaichuyen == "VCNB")
            {
                VNN_Function.SetFormValue("chungtuthamchieu", "VNN_notpost");
            }
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_vanchuyennoibo_id", "denkho" };
                string ten_table = "md_vanchuyennoibo_cdvc";
                VNN_Function.SetFormValue("md_vanchuyennoibo_id", id);
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
                VNN_Function.SetFormValue("soluong_dichchuyen", soluong_dichchuyen + "");
                VNN_Function.SetFormValue("soluong_toida", soluong_dichchuyen + "");
                VNN_Function.SetFormValue("denkho", sp.khomacdinh);
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
        decimal soluong_dichchuyen = decimal.Parse(context.Request.Form["soluong_dichchuyen"]);

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                md_vanchuyennoibo_cdvc object_ = db.md_vanchuyennoibo_cdvc.Where(p => p.md_vanchuyennoibo_cdvc_id == id).Take(1).FirstOrDefault();
                md_vanchuyennoibo vnnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == object_.md_vanchuyennoibo_id).Take(1).FirstOrDefault();
                decimal soluong_td_dc = (object_.soluong_toida.Value - object_.soluong_dachuyen.Value);
                if (object_ == null)
                {
                    msg = "Lỗi: Không tìm thấy đối tượng cần sửa.";
                }
                else if (soluong_td_dc < soluong_dichchuyen)
                {
                    msg = "Lỗi: Số lượng dịch chuyển tối đa là:" + Math.Round(soluong_td_dc, 0);
                }
                else if (soluong_dichchuyen < 0)
                {
                    msg = "Lỗi: Số lượng dịch chuyển không được âm.";
                }
                else if (vnnb.md_trangthai_id == "HIEULUC")
                {
                    msg = "Lỗi:Dòng " + vnnb.sochungtu + " đã Hiệu lực";
                }

                if (msg.Length <= 0)
                {
                    object_.soluong_dichchuyen = soluong_dichchuyen;
                    db.SaveChanges();
                    var slcl = new List<Dictionary<string, object>>();
                    foreach (var b in db.md_vanchuyennoibo_cdvc.Where(s =>
                        s.md_vanchuyennoibo_id == object_.md_vanchuyennoibo_id
                        & s.lsx_to == object_.lsx_to).ToList())
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == b.md_sanpham_id).FirstOrDefault();
                        var tsx = Extension.getLSXToId(b.lsx_to, db);
                        var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                            & s.macuoi.Contains(sp.ma_sanpham));

                        foreach (var cai in lsxSp.ToList())
                        {
                            var caiJSon = slcl.Where(s => s["md_sanpham_id"] + "" == cai.md_sanpham_id).FirstOrDefault();
                            if (caiJSon == null)
                            {
                                slcl.Add(new Dictionary<string, object>() {
                                    { "md_sanpham_id", cai.md_sanpham_id },
                                    { "soluong", b.soluong_dichchuyen },
                                    { "sltd", cai.sl_dahoanthanh }
                                });
                            }
                            else
                            {
                                caiJSon["soluong"] = b.soluong_dichchuyen + decimal.Parse(caiJSon["soluong"].ToString());
                            }
                        }
                    }

                    foreach (var itemSLTH in slcl)
                    {
                        string spId = itemSLTH["md_sanpham_id"].ToString();
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == spId).FirstOrDefault();
                        var sl = decimal.Parse(itemSLTH["soluong"].ToString());
                        var sltd = decimal.Parse(itemSLTH["sltd"].ToString());
                        if (sl > sltd)
                        {
                            msg += string.Format(@"Mã cái ""{0}"" không đáp ứng đủ.<br>", sp.ma_sanpham);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Lỗi:" + ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "true#Cập nhật thành công.";
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "md_vanchuyennoibo_cdvc";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                var object_ = db.md_vanchuyennoibo_cdvc.Where(p => p.md_vanchuyennoibo_cdvc_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else
                {
                    var vcnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == object_.md_vanchuyennoibo_id).FirstOrDefault();
                    if (vcnb.md_trangthai_id == "HIEULUC")
                    {
                        msg_del = string.Format(@"Lỗi:Phiếu ""{0}"" đã ""Hiệu Lực""", vcnb.sochungtu);
                        msg += msg_del + "\n";
                    }

                    if (msg_del.Length <= 0)
                    {
                        string action = "del";
                        string[] column_ex = { };
                        VNN_Function.SetFormValue("id", object_.md_vanchuyennoibo_cdvc_id);
                        VNN_Function.Set_DefaultvalueColumn(context, action);
                        VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                    }
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