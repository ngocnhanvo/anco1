<%@ WebHandler Language="C#" Class="JQGridMD_01_DDSDHModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using System.Collections.Generic;

public class JQGridMD_01_DDSDHModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;
    Public pub = new Public();

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
            case "CA_01_DSDHImport":
                this.CA_01_DSDHImport(context);
                break;
            case "add":
                this.add(context);
                break;
            case "edit":
                this.edit(context);
                break;
            case "del":
                this.del(context);
                break;
            case "selectBOM":
                this.selectBOM(context);
                break;

            default:
                break;
        }
    }

    public void CA_01_DSDHImport(HttpContext context)
    {
        var msg = new List<string>();
        var jsonStr = context.Request.Form["json"];
        var id = context.Request.Form["id_parent"];
        var ma_module = context.Request.QueryString["ma_module"];
        try
        {
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonStr);
            var hasErr = false;
            foreach(var item in json)
            {
                string msp = item.ElementAt(0).Value.removeAllSpaceOrTrimText(true);
                string sld = item.ElementAt(1).Value.removeAllSpaceOrTrimText(true);
                string tem = item.ElementAt(2).Value.removeAllSpaceOrTrimText(true);
                string mta = item.ElementAt(3).Value.removeAllSpaceOrTrimText(true);
                string cbm = item.ElementAt(4).Value.removeAllSpaceOrTrimText(true);
                string msgDT = add(context, ma_module, id, msp, sld, tem, mta, cbm, false);
                if (!string.IsNullOrWhiteSpace(msgDT))
                {
                    if (msgDT.LastIndexOf("error") > -1)
                        hasErr = true;
                    msg.Add(msgDT);
                }
            }

            if(!hasErr)
            {
                db.SaveChanges();
            }
        }
        catch(Exception ex)
        {
            msg.Add(ex.Message);
        }

        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
    }

    public void selectBOM(HttpContext context)
    {
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "<select>";

        str += firstnull ? string.Format(@"<option px="""" value=""""></option>") : "";
        foreach (var cn in db.md_sanpham_bom.Where(s =>
            string.IsNullOrEmpty(s.md_phanxuong_id) & string.IsNullOrEmpty(s.md_to_id))
                .OrderBy(s => s.trangthai).ToList())
        {
            str += string.Format(@"<option sp=""{2}"" value=""{0}"">{1}</option>", cn.md_sanpham_bom_id, cn.ten_phienban, cn.md_sanpham_id);
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public string add(HttpContext context, string ma_module = "", string id = "", string ma_sanpham = "", string sldathang = "", string temdan = "", string mota = "", string cbmStr = "", bool updated = true)
    {
        string msg = "", id_new = Helper.getNewId();
        string ten_phienban = context.Request.Form["md_sanpham_bom_id"];
        int sl_dathang = 0;
        if(string.IsNullOrWhiteSpace(ma_module))
            ma_module = context.Request.QueryString["ma_module"];
        if(string.IsNullOrWhiteSpace(ma_sanpham))
            ma_sanpham = context.Request.Form["md_sanpham_id"];
        if(string.IsNullOrWhiteSpace(id))
            id = context.Request.Form["id_parent"];

        try
        {
            var slDatHang = context.Request.Form["sl_dathang"];
            if (string.IsNullOrWhiteSpace(sldathang))
            {
                if(slDatHang.ToNullableDouble() == null)
                {
                    msg = "SL đặt hàng không thể bỏ trống";
                    goto EndEventHandler;
                }
                sl_dathang = int.Parse(slDatHang);
            }
            else
                sl_dathang = int.Parse(sldathang);

            var cbm = context.Request.Form["v2"].ToNullableDecimal().GetValueOrDefault(0);

            var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
            if(sp == null)
            {
                msg = $"Mã <b>{ma_sanpham}</b> không tồn tại.";
                goto EndEventHandler;
            }

            var dsdhServer = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id).FirstOrDefault();
            var dsdh = db.c_danhsachdathang.Local.Where(s => s.c_danhsachdathang_id == id).FirstOrDefault();
            if(dsdh == null)
            {
                msg = $"Mã <b>{ma_sanpham}</b> không tìm thấy đơn hàng.";
                goto EndEventHandler;
            }
            else if (dsdh.trangthai != Helper.SOANTHAO)
            {
                msg = string.Format(@"Ðơn hàng ""{0}"" đã xử lý.", dsdh.sochungtu);
                goto EndEventHandler;
            }
            else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
            {
                msg = string.Format(@"Ðơn hàng ""{0}"" đã giảm hạn ngạch.", dsdh.sochungtu);
                goto EndEventHandler;
            }

            int ddsdh = db.c_dongdsdh.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count();
            if (ddsdh > 0)
            {
                msg = $"Mã <b>{ma_sanpham}</b> đã được thêm trước đó.";
                goto EndEventHandler;
            }
            else if (sl_dathang <= 0)
            {
                msg = $"Mã {ma_sanpham}, số lượng đặt hàng phải lớn hơn 0";
                goto EndEventHandler;
            }
            else if (dsdh.sanxuatton.GetValueOrDefault(false))
            {
                var rgxBoS = new System.Text.RegularExpressions.Regex("^[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]-[BLXS][0-9]-[0-9][0-9]$");
                if (rgxBoS.IsMatch(sp.ma_sanpham))
                {
                    msg = $"Mã {ma_sanpham}, không thể sản xuất tồn theo bộ";
                    goto EndEventHandler;
                }
            }

            if (msg.Length <= 0)
            {
                //var strGN = string.Format(@"select isnull([dbo].[GET_GiaBanSP](N'{0}', N'{1}'),0)", sp.ma_sanpham, dsdh.khachhang);
                var gianhap = pub.getGiaBanSP(sp.md_sanpham_id, dsdh.khachhang, db);

                var object_ = new c_dongdsdh();
                object_.c_dongdsdh_id = id_new;
                object_.c_danhsachdathang_id = id;
                object_.sl_conlai = sl_dathang;
                object_.sl_dagiao = 0;
                object_.sl_hanngach = 0;
                object_.sl_giamhanngach = 0;
                object_.giadoichieu = gianhap;
                object_.phi = 0;
                object_.phidg = 0;
                VNN_Function.SetFormValue(object_.nameof(s=>s.sl_dathang), sl_dathang.ToString());
                VNN_Function.SetFormValue(object_.nameof(s=>s.gianhap), gianhap.ToString());
                VNN_Function.SetFormValue(object_.nameof(s=>s.md_sanpham_id), sp.md_sanpham_id);
                //VNN_Function.SetFormValue(object_.nameof(s=>s.md_sanpham_bom_id), bom_sp == null ? ten_phienban : bom_sp.md_sanpham_bom_id);
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                db.c_dongdsdh.Add(object_);

                var chungloai = sp.ma_sanpham.Substring(0, 2);
                var chungloais = dsdh.chungloai.Split(',').ToList();
                if(!chungloais.Contains(chungloai))
                {
                    chungloais.Add(chungloai);
                    dsdh.chungloai = string.Join(",", chungloais.OrderBy(s => s).Distinct());
                }

                if(updated)
                    db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;
        if (msg.Length <= 0)
        {
            if (updated)
            {
                msg = string.Format(@"true#Thêm thành công#{0}", id_new);
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = $"<div msp='{ma_sanpham}' style='color:blue'>Ðã đạt</div>";
            }
        }
        else
        {
            if (updated)
                msg = string.Format(@"false#{0}", msg);
            else
                msg = $"<div msp='{ma_sanpham}' style='color:red' error>{msg}</div>";
        }

        if (updated)
            context.Response.Write(msg);
        return msg;
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        string ten_phienban = context.Request.Form["md_sanpham_bom_id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                int sl_dathang = int.Parse(context.Request.Form["sl_dathang"]);
                decimal gianhap = decimal.Parse(context.Request.Form["gianhap"]);
                decimal cbm = decimal.Parse(context.Request.Form["v2"]);
                string id = context.Request.Form["id"];
                string id_parent = context.Request.Form["id_parent"];
                var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
                var object_ = db.c_dongdsdh.Where(p => p.c_dongdsdh_id == id).FirstOrDefault();
                var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id_parent).FirstOrDefault();
                //var bom_sp = db.md_sanpham_bom.Where(s =>
                //    s.md_sanpham_id == sp.md_sanpham_id &
                //    s.ten_phienban == ten_phienban &
                //    string.IsNullOrEmpty(s.md_phanxuong_id) &
                //    string.IsNullOrEmpty(s.md_to_id)).FirstOrDefault();

                if (object_ == null)
                {
                    msg = "Không tìm thấy dòng cần sửa ";
                }
                else if (dsdh.trangthai != Helper.SOANTHAO)
                {
                    msg = $@"Ðơn hàng ""{dsdh.sochungtu}"" đã xử lý";
                }
                else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
                {
                    msg = $@"Ðơn hàng ""{dsdh.sochungtu}"" đã giảm hạn ngạch.";
                }
                else if (sl_dathang <= 0)
                {
                    msg = $"Mã {ma_sanpham}, số lượng đặt hàng phải lớn hơn 0";
                }

                if (msg.Length <= 0)
                {
                    object_.sl_conlai = sl_dathang;
                    object_.sl_dagiao = 0;
                    VNN_Function.SetFormValue(object_.nameof(s => s.gianhap), gianhap.ToString());
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_sanpham_id), sp.md_sanpham_id);
                    //VNN_Function.SetFormValue(object_.nameof(s => s.md_sanpham_bom_id), bom_sp.md_sanpham_bom_id);
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
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

        try
        {
            var ids = context.Request.Form["id"].Split(',').Where(s=>!string.IsNullOrWhiteSpace(s)).ToList();

            foreach (var id_del_ in ids)
            {
                var object_ = db.c_dongdsdh.Where(p => p.c_dongdsdh_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy dòng cần xóa.", id_del_);
                }
                else
                {
                    var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).FirstOrDefault();
                    if (dsdh.trangthai == Helper.HIEULUC)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Ðã xử lý.", dsdh.sochungtu);
                    }
                    else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Ðã giảm hạn ngạch.", dsdh.sochungtu);
                    }
                    else
                    {
                        db.c_dongdsdh.Remove(object_);
                        db.SaveChanges();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

        if (msg.Length <= 0)
        {
            msg = string.Format(@"true#Xóa thành công");
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            msg = string.Format(@"false#{0}", msg.Substring(4));
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