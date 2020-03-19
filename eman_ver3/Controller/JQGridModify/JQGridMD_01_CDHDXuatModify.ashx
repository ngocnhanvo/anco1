<%@ WebHandler Language="C#" Class="JQGridMD_01_CDHDXuatModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
using Newtonsoft.Json;
public class JQGridMD_01_CDHDXuatModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLXNB":
                this.CA_01_CapnhatSLXNB(context);
                break;
            case "loadPBSL":
                this.loadPBSL(context);
                break;
            case "CA_01_PhanBoSoLuongTheoTo":
                this.CA_01_PhanBoSoLuongTheoTo(context);
                break;
            case "CA_01_GhepVatTuXuat":
                this.CA_01_GhepVatTuXuat(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_GhepVatTuXuat(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string id = context.Request.Form["id"];
        string idpr = context.Request.Form["idpr"];
        string[] vnn = id.Split(',');
        string type = context.Request.Form["type"];
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var xknb = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == idpr).FirstOrDefault();
                if (xknb == null)
                {
                    msg = "Không tìm thấy phiếu xuất kho";
                }
                else if (xknb.trangthai == "HIEULUC")
                {
                    msg = @"Phiếu xuất kho đã ""Hiệu Lực""";
                }
                else
                {
                    var tbl = db.md_xuatkhonb_cdh.Where(s => vnn.Contains(s.md_xuatkhonb_cdh_id)).ToList();
                    if (type == "1")
                    {
                        tbl = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == idpr).ToList();
                    }

                    var groupTBL = tbl.GroupBy(s => new { s.md_sanpham_id, s.md_donvitinhsanpham_id, s.md_donvitinhsanpham_id2 }).Select(s => new md_xuatkhonb_cdh
                    {
                        md_xuatkhonb_cdh_id = Helper.getNewId(),
                        md_sanpham_id = s.Key.md_sanpham_id,
                        md_donvitinhsanpham_id = s.Key.md_donvitinhsanpham_id2,
                        md_donvitinhsanpham_id2 = s.Key.md_donvitinhsanpham_id2,
                        lsx_to = string.Join(",", s.Select(t => t.lsx_to).OrderByDescending(t => t).ToList()),
                        sl_daxuat = s.Select(t => t.sl_daxuat).Sum(),
                        sl_xuat2 = 0,
                        sl_xuat = 0,
                        tong_sl_xuat = s.Select(t => t.tong_sl_xuat).Sum(),
                        sl_muonxuat = s.Select(t => t.sl_muonxuat).Sum(),
                        sl_thucxuat = 0,
                        md_xuatkhonb_id = idpr,
                        ghino = s.Select(t => t.ghino).Sum(),
                        saiso = s.Select(t => t.saiso).Sum(),
                        bophancapnhat = us.md_phongban_id,
                        bophantao = us.md_phongban_id,
                        nguoicapnhat = us.ad_user_id,
                        nguoitao = us.ad_user_id,
                        vaitrocapnhat = us.ad_role_id,
                        vaitrotao = us.ad_role_id,
                        value_bophancapnhat = us.ten_phongban,
                        value_bophantao = us.ten_phongban,
                        value_nguoicapnhat = us.ma_user,
                        value_nguoitao = us.ma_user,
                        value_vaitrocapnhat = us.ten_role,
                        value_vaitrotao = us.ten_role,
                        ngaycapnhat = DateTime.Now,
                        ngaytao = DateTime.Now,
                        hoatdong = true,
                        mota = ""
                    });

                    db.md_xuatkhonb_cdh.RemoveRange(tbl);
                    foreach (var item in groupTBL.ToList())
                    {
                        db.md_xuatkhonb_cdh.Add(item);
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
                msg = string.Format(@"<div style=""color:blue"">Ghép vật tư thành công</div>");
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style=""color:red"">Lỗi:{0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_PhanBoSoLuongTheoTo(HttpContext context)
    {
        var db = new EntityContext();
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var jsonPost = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request.Form["jsonPost"]);
                string id = context.Request.Form["id"];
                foreach (var a in jsonPost)
                {
                    var b = a["items"].ToString();
                    var items = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(b);
                    foreach (var item in items)
                    {
                        string spid = item["md_sanpham_id"] + "", lsx_to = item["lsx_to"] + "", tong_sl_xuat = item["tong_sl_xuat"] + "";
                        var dongxk = db.md_xuatkhonb_cdh.Where(s =>
                            s.md_xuatkhonb_id == id
                            & s.md_sanpham_id == spid
                            & s.lsx_to == lsx_to).FirstOrDefault();

                        var tongsl = items.Where(s => s["md_sanpham_id"] + "" == spid).Select(s => decimal.Parse(s["tong_sl_xuat"] + "")).Sum();

                        if (dongxk == null)
                        {
                            msg = string.Format(@"HHVT ""{0}"" không tìm thấy", item["ma_sanpham"]);
                        }
                        else
                        {
                            decimal tslx = decimal.Parse(tong_sl_xuat);
                            if (dongxk.sl_toida_trongLSXTo2 < tslx)
                            {
                                msg = string.Format(@"HHVT ""{0}"" lỗi: SL xuất: {0}, SL tối đa {1}", tongsl, dongxk.sl_toida_trongLSXTo2);
                            }
                            else if (dongxk.sl_toida_trongLSXTo < tongsl)
                            {
                                msg = string.Format(@"HHVT ""{0}"" lỗi: Tổng SL: {0}, SL tối đa {1}", tongsl, dongxk.sl_toida_trongLSXTo);
                            }
                            else
                            {
                                dongxk.tong_sl_xuat = tslx;
                                dongxk.sl_xuat = dongxk.tong_sl_xuat;
                                dongxk.sl_xuat2 = dongxk.sl_xuat;
                                db.SaveChanges();
                            }
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
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style=""color:red"">Lỗi: {0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void loadPBSL(HttpContext context)
    {
        var db = new EntityContext();
        string id_parent = context.Request.QueryString["id"];
        var dongXKNBs = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == id_parent).ToList();
        var lsxTos = new List<Dictionary<string, object>>();
        var items = new List<Dictionary<string, object>>();
        foreach (var item in dongXKNBs)
        {
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == item.md_sanpham_id).FirstOrDefault();
            if (sp != null)
            {
                var lstTo = lsxTos.Where(s => s["ma_sanpham"] + "" == sp.ma_sanpham).FirstOrDefault();
                if (lstTo == null)
                {
                    lsxTos.Add(new Dictionary<string, object> {
                        { "md_sanpham_id", sp.md_sanpham_id },
                        { "ma_sanpham", sp.ma_sanpham },
                        { "ten_sanpham", sp.mota_tiengviet },
                        { "sl_toida", item.sl_toida_trongLSXTo },
                        { "items", null }
                    });
                }


                var to = new Dictionary<string, object>();
                to["md_sanpham_id"] = sp.md_sanpham_id;
                to["ma_sanpham"] = sp.ma_sanpham;
                to["lsx_to"] = item.lsx_to;
                to["tong_sl_xuat"] = item.tong_sl_xuat;
                items.Add(to);
            }
        }

        foreach (var item in lsxTos)
        {
            item["items"] = items.Where(s => s["md_sanpham_id"] + "" == item["md_sanpham_id"] + "").ToList();
        }

        context.Response.Write(JsonConvert.SerializeObject(lsxTos));
    }

    public void CA_01_CapnhatSLXNB(HttpContext context)
    {
        var db = new EntityContext();
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string sel_val = context.Request.Form["sel_val"];
                decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
                string[] vnn = context.Request.Form["id"].Split(',');

                md_xuatkhonb xnb = null;
                foreach (var xb_cdh in db.md_xuatkhonb_cdh.Where(s => vnn.Contains(s.md_xuatkhonb_cdh_id)).ToList())
                {
                    if (xnb == null)
                        xnb = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == xb_cdh.md_xuatkhonb_id).FirstOrDefault();

                    if (xnb.trangthai == "HIEULUC")
                    {
                        msg = "<div style='margin: 2px 0 2px 0;'>Lỗi:Dòng " + xnb.sochungtu + " đã Hiệu lực.</div>";
                        break;
                    }
                    else
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == xb_cdh.md_sanpham_id).Take(1).FirstOrDefault();

                        decimal sltd = xb_cdh.tong_sl_xuat.Value - xb_cdh.sl_daxuat.Value;
                        if (sel_val == "0")
                        {
                            slvc_case = xb_cdh.sl_muonxuat.GetValueOrDefault(0);
                        }

                        var sltkTT = Helper.soLuongTonKhoThucTe(xnb.tukho, xb_cdh.md_sanpham_id, db);
                        if (sltkTT < slvc_case)
                        {
                            msg += string.Format(
                               @"<div style='margin: 2px 0 2px 0;'><b>{0}</b> ({1}) SL tồn kho thực tế: <b>{2}</b></div>",
                               sp.ma_sanpham,
                               xb_cdh.tenhang,
                               sltkTT.DropTrailingZeros());
                        }
                        else if (xnb.bosung == 4)
                        {
                            //var lsxTsx = Extension.getLSXToId2(xb_cdh.lsx_to, db);
                            //var lsxTSX_prevChk = Extension.getLSXToId_Prev(lsxTsx.tsx, db);
                            //var spCDT = db.md_lenhsanxuat_tosx_cdh.Where(
                            //    s => s.md_lenhsanxuat_tosx_id == lsxTSX_prevChk.md_lenhsanxuat_tosx_id
                            //    & s.md_sanpham_id == xb_cdh.md_sanpham_id
                            //    ).FirstOrDefault();

                            //if (spCDT.sl_dahoanthanh.GetValueOrDefault(0) < slvc_case)
                            //{
                            //    msg += string.Format(
                            //        @"<div style='margin: 2px 0 2px 0;'><b>{0}</b> ({1}) SL công đoạn trước: <b>{2}</b></div>",
                            //        sp.ma_sanpham,
                            //        xb_cdh.tenhang,
                            //        spCDT.sl_dahoanthanh.GetValueOrDefault(0).DropTrailingZeros());
                            //}
                        }

                        if (msg.Length <= 0)
                        {
                            if (xnb.bosung == 0 | xnb.bosung == 3)
                            {
                                xb_cdh.sl_xuat = slvc_case;
                                xb_cdh.sl_xuat2 = slvc_case;
                                xb_cdh.sl_thucxuat = xb_cdh.sl_xuat2;
                                xb_cdh.ghino = (xb_cdh.sl_thucxuat.GetValueOrDefault(0) - sltd + xb_cdh.truno).GetValueOrDefault(0).Set0WhenlessThan0();
                            }
                            else if (slvc_case <= sltd)
                            {
                                xb_cdh.sl_xuat = slvc_case;
                                xb_cdh.sl_xuat2 = slvc_case;
                                xb_cdh.sl_thucxuat = xb_cdh.sl_xuat2;
                                xb_cdh.ghino = 0;
                            }
                            else
                            {
                                msg += string.Format(
                                    @"<div style='margin: 2px 0 2px 0;'>Lỗi: Dòng <b>{0}</b> ({1}) SL tối đa là: <b>{1}</b></div>",
                                    sp.ma_sanpham,
                                    xb_cdh.tenhang,
                                    sltd.DropTrailingZeros()
                                    );
                            }
                        }
                    }
                }
                if (msg.Length <= 0)
                {

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg += ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "<div style='color:blue'>Cập nhật số lượng dự kiến xuất kho thành công</div>";
                transaction.Commit();
            }
            else
            {
                msg = string.Format("<div style='color:red'>Lỗi {0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {

    }

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            decimal sl_xuat = decimal.Parse(context.Request.Form["sl_thucxuat"]);
            decimal ghino = decimal.Parse(context.Request.Form["ghino"]);
            string id = context.Request.Form["id"];
            var object_ = db.md_xuatkhonb_cdh.Where(p => p.md_xuatkhonb_cdh_id == id).Take(1).FirstOrDefault();
            var xnb = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == object_.md_xuatkhonb_id).Take(1).FirstOrDefault();
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).FirstOrDefault();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (sl_xuat <= 0)
            {
                msg = "false#Số lượng xuất phải lớn hớn 0";
            }
            else if (sl_xuat > object_.sl_muonxuat)
            {
                msg = "false#Số lượng xuất tối đa là " + object_.sl_muonxuat.GetValueOrDefault(0).DropTrailingZeros();
            }
            else if (xnb.trangthai == "HIEULUC")
            {
                msg = @"false#Phiếu xuất kho đã ""Hiệu Lực""!";
            }
            else
            {
                var sltkTT = Helper.soLuongTonKhoThucTe(xnb.tukho, sp.md_sanpham_id, db);
                if (sltkTT < sl_xuat)
                    msg = @"false#Số lượng tồn kho thực tế là: " + sltkTT.DropTrailingZeros();
                else if (xnb.bosung == 4)
                {
                    //var lsxTsx = Extension.getLSXToId2(object_.lsx_to, db);
                    //var lsxTSX_prevChk = Extension.getLSXToId_Prev(lsxTsx.tsx, db);
                    //var spCDT = db.md_lenhsanxuat_tosx_cdh.Where(
                    //    s => s.md_lenhsanxuat_tosx_id == lsxTSX_prevChk.md_lenhsanxuat_tosx_id
                    //    & s.md_sanpham_id == object_.md_sanpham_id
                    //    ).FirstOrDefault();

                    //if (spCDT.sl_dahoanthanh.GetValueOrDefault(0) < sl_xuat)
                    //    msg = @"false#Số lượng nhập của công đoạn trước chỉ có: " + spCDT.sl_dahoanthanh.GetValueOrDefault(0).DropTrailingZeros();
                }
            }

            if (msg.Length <= 0)
            {
                object_.ghino = (sl_xuat - object_.tong_sl_xuat + object_.truno).GetValueOrDefault(0).Set0WhenlessThan0();
                object_.sl_thucxuat = sl_xuat;
                db.SaveChanges();
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.(--)" + object_.sl_xuat2;
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
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "md_xuatkhonb_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_xuatkhonb_cdh object_ = db.md_xuatkhonb_cdh.Where(p => p.md_xuatkhonb_cdh_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "<br>";
                }
                else
                {
                    md_xuatkhonb nb = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id).FirstOrDefault();
                    var xnb_cdhs = from a in db.md_vanchuyennoibo_cdvc
                                   join b in db.md_vanchuyennoibo on a.md_vanchuyennoibo_id equals b.md_vanchuyennoibo_id
                                   where b.chungtuthamchieu == nb.sochungtu & a.md_sanpham_id == object_.md_sanpham_id
                                   select new { a.md_vanchuyennoibo_cdvc_id };
                    if (nb.trangthai == "HIEULUC")
                    {
                        msg_del = "false#Lỗi: Số chứng từ : " + nb.sochungtu + " đã hiệu lực,";
                        msg += msg_del + "<br>";
                    }
                    else if (xnb_cdhs.Count() > 0)
                    {
                        msg_del = "Lỗi:\"" + nb.sochungtu + "\" có phiếu vận chuyển nội bộ đang sử dụng dòng hàng này.";
                        msg += msg_del + "<br>";
                    }
                }

                if (msg_del.Length <= 0)
                {
                    db.md_xuatkhonb_cdh.Remove(object_);
                }
            }

            if (msg.Length <= 0)
            {
                VNN_Function.loaddulieu_Auto(db, ma_module);
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