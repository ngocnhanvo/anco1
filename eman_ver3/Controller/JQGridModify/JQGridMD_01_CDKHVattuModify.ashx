<%@ WebHandler Language="C#" Class="JQGridMD_01_CDKHVattuModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_CDKHVattuModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_DuyetSoluongKHMVT":
                this.CA_01_DuyetSoluongKHMVT(context);
                break;
            case "CA_01_khmvt_DOINCC":
                this.CA_01_khmvt_DOINCC(context);
                break;
            case "CA_01_LamMoiHangTonKho":
                this.CA_01_LamMoiHangTonKho(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_LamMoiHangTonKho(HttpContext context)
    {
        var db = new EntityContext();
        string idparent = context.Request.Form["id"];
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var khmvt = db.c_kehoachmuavt.FirstOrDefault(s => s.c_kehoachmuavt_id == idparent);
                if (khmvt.md_trangthai_id != "SOANTHAO")
                {
                    msg = string.Format(@"Kế hoach này đã ""Hiệu Lực"".");
                }
                else
                {
                    db.c_kehoachmuavt_dklht.RemoveRange(db.c_kehoachmuavt_dklht.Where(s => s.c_kehoachmuavt_id == khmvt.c_kehoachmuavt_id));
                    foreach (var khmvt_cdh in db.c_kehoachmuavt_cdh.Where(s => s.c_kehoachmuavt_id == idparent).ToList())
                    {
                        var tonkho = (from a in db.md_kho_sanpham
                                      join b in db.md_kho on a.md_kho_id equals b.md_kho_id
                                      where b.vattu == true & a.md_sanpham_id == khmvt_cdh.md_sanpham_id
                                      select new { a.md_sanpham_id, a.md_kho_id, a.soluong }).ToList();
                        decimal sl_tonkho = 0,
                                   sl_tonkhotoithieu = khmvt_cdh.sl_tonkho_toithieu.GetValueOrDefault(0),
                                   sl_khmvtCan = khmvt_cdh.sl_can.GetValueOrDefault(0);

                        if (tonkho.Count > 0)
                        {
                            foreach (var tonkho_ in tonkho)
                            {
                                decimal sl_tonkho_ = tonkho_.soluong.GetValueOrDefault(0) -
                                                db.md_kho_giucho.Where(s =>
                                                    s.md_sanpham_id == tonkho_.md_sanpham_id &
                                                    s.md_kho_id == tonkho_.md_kho_id
                                                ).Select(s => s.soluong_giucho).Sum()
                                                .GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0);
                                sl_tonkho += sl_tonkho_;
                                var dklht = new c_kehoachmuavt_dklht();
                                dklht.c_kehoachmuavt_dklht_id = Helper.getNewId();
                                dklht.c_kehoachmuavt_id = khmvt.c_kehoachmuavt_id;
                                dklht.md_kho_id = tonkho_.md_kho_id;
                                dklht.md_sanpham_id = tonkho_.md_sanpham_id;
                                dklht.md_donvitinhsanpham_id = khmvt_cdh.md_donvitinhsanpham_id;
                                dklht.sl_tonkho = sl_tonkho_;
                                sl_tonkho_ = (sl_tonkho_ - sl_tonkhotoithieu).Set0WhenlessThan0().GetValueOrDefault(0);
                                //dklht.sl_layton = sl_tonkho_ > sl_khmvtCan ? sl_khmvtCan : sl_tonkho_;
                                dklht.sl_layton = 0;
                                var lt_tt = dklht.sl_layton;
                                //dklht.sl_layton = lt_tt > sl_tonkhotoithieu ? lt_tt - sl_tonkhotoithieu : 0;
                                sl_tonkhotoithieu = (sl_tonkhotoithieu - lt_tt.GetValueOrDefault(0)).Set0WhenlessThan0().GetValueOrDefault(0);
                                sl_khmvtCan = (sl_khmvtCan - dklht.sl_layton.GetValueOrDefault(0)).Set0WhenlessThan0().GetValueOrDefault(0);
                                db.c_kehoachmuavt_dklht.Add(dklht);
                            }
                        }

                        khmvt_cdh.sl_tonkho = sl_tonkho;
                        sl_tonkho = (sl_tonkho - khmvt_cdh.sl_tonkho_toithieu.GetValueOrDefault(0)).Set0WhenlessThan0().GetValueOrDefault(0);
                        khmvt_cdh.sl_layton = 0;
                        //khmvt_cdh.sl_layton = sl_tonkho > khmvt_cdh.sl_can ? khmvt_cdh.sl_can : sl_tonkho;
                        //khmvt_cdh.sl_layton = (khmvt_cdh.sl_layton - khmvt_cdh.sl_tonkho_toithieu).GetValueOrDefault(0).Set0WhenlessThan0();

                        var sldn = khmvt_cdh.sl_can - khmvt_cdh.sl_layton
                                    + (khmvt_cdh.sl_tonkho_toithieu - khmvt_cdh.sl_tonkho).GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0);
                        khmvt_cdh.sl_denghi = sldn;
                        khmvt_cdh.sl_duyet = null;
                    }
                    db.SaveChanges();
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
                msg = string.Format(@"<div style=""color:red"">Lỗi:{0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_khmvt_DOINCC(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string md_doitackinhdoanh_id = context.Request.Form["md_doitackinhdoanh_id"];
        string[] vnn = context.Request.Form["id"].Split(',');
        md_doitackinhdoanh_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_doitackinhdoanh_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
        foreach (c_kehoachmuavt_cdh khmvt_cdh in db.c_kehoachmuavt_cdh.Where(s => vnn.Contains(s.c_kehoachmuavt_cdh_id)))
        {
            khmvt_cdh.md_doitackinhdoanh_id = md_doitackinhdoanh_id;
        }
        db.SaveChanges();
        msg = "Cập nhật các dòng hàng thành công.";
        context.Response.Write(msg);
    }

    public void CA_01_DuyetSoluongKHMVT(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        foreach (var khmvt_cdh in db.c_kehoachmuavt_cdh.Where(s => vnn.Contains(s.c_kehoachmuavt_cdh_id)).ToList())
        {
            var khmvt = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == khmvt_cdh.c_kehoachmuavt_id).Take(1).FirstOrDefault();
            if (khmvt.c_donmuavattu_id != " ")
            {
                msg = "<div style='color:red'>lỗi: Kế hoạch \"" + khmvt.sochungtu + "\" đã tạo đơn mua vật tư, không thể chỉnh sửa.</div>";
                break;
            }
            else if (sel_val == "0")
            {
                khmvt_cdh.sl_duyet = khmvt_cdh.sl_denghi.Value + khmvt_cdh.sl_canthem.GetValueOrDefault(0);
                //var sllt = khmvt_cdh.sl_can + khmvt_cdh.sl_tonkho_toithieu - khmvt_cdh.sl_duyet;
                //khmvt_cdh.sl_layton = sllt > khmvt_cdh.sl_tonkho ? khmvt_cdh.sl_tonkho : sllt;
            }
            else
            {
                khmvt_cdh.sl_duyet = slvc_case;
                khmvt_cdh.sl_canthem = (khmvt_cdh.sl_duyet - khmvt_cdh.sl_denghi).GetValueOrDefault(0).Set0WhenlessThan0();
                //var sllt = khmvt_cdh.sl_can + khmvt_cdh.sl_tonkho_toithieu - khmvt_cdh.sl_duyet;
                //khmvt_cdh.sl_layton = sllt > khmvt_cdh.sl_layton ? khmvt_cdh.sl_layton : sllt;
            }

            //var dklhts = db.c_kehoachmuavt_dklht.Where(s =>
            //    s.md_sanpham_id == khmvt_cdh.md_sanpham_id &
            //    s.c_kehoachmuavt_id == khmvt_cdh.c_kehoachmuavt_id);

            //var slltTong = khmvt_cdh.sl_layton.GetValueOrDefault(0);
            //foreach (var dklht in dklhts.ToList())
            //{
            //    dklht.sl_layton = slltTong > dklht.sl_tonkho ? dklht.sl_tonkho : slltTong;
            //    slltTong = slltTong - dklht.sl_layton.GetValueOrDefault(0);
            //}
        }
        if (msg == "")
        {
            msg = "<div style='color:blue'>Duyệt số lượng cần mua thành công.</div>";
            db.SaveChanges();
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
                string ten_table = "c_kehoachmuavt_cdh";
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
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string mota_tiengviet = context.Request.Form["mota_tiengviet"];
        string md_doitackinhdoanh_id = context.Request.Form["md_doitackinhdoanh_id"];

        try
        {
            var sl_duyet = decimal.Parse(context.Request.Form["sl_duyet"]);
            var sl_layton = decimal.Parse(context.Request.Form["sl_layton"]);
            var sl_canthem = decimal.Parse(context.Request.Form["sl_canthem"]);
            var ngayPhaiCo = VNN_Config.setDateTime(context.Request.Form["ngayphaico"]);
            string id = context.Request.Form["id"];
            var object_ = db.c_kehoachmuavt_cdh.Where(p => p.c_kehoachmuavt_cdh_id == id).Take(1).FirstOrDefault();
			decimal? sldn = 0;
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (ngayPhaiCo == DateTime.MinValue | ngayPhaiCo == DateTime.MinValue.AddDays(1))
            {
                msg = @"false#""Ngày phải có"" có giá trị sai";
            }
            else
            {
				sldn = (object_.sl_can - sl_layton).GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0)  + (object_.sl_tonkho_toithieu - object_.sl_tonkho).GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0);
                var khmvt = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id).Take(1).FirstOrDefault();
                if (khmvt.c_donmuavattu_id != " ")
                    msg = string.Format(@"false#Lỗi: Kế hoạch ""{0}"" đã tạo đơn mua vật tư, không thể chỉnh sửa.</div>", khmvt.sochungtu);
				else if(khmvt.md_trangthai_id == "HIEULUC")
					msg = string.Format(@"false#Lỗi: Kế hoạch ""{0}"" đã Hiệu Lực.</div>", khmvt.sochungtu);
                else if (sl_layton > (object_.sl_tonkho - object_.sl_tonkho_toithieu).GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0))
                    msg = string.Format(@"false#""SL lấy tồn"" phải nhỏ hơn hoặc bằng ""số lượng tồn kho - tồn kho tối thiểu""");
                else if (sl_duyet != sldn + sl_canthem)
                    msg = string.Format(@"false#""Số lượng duyệt"" phải bằng ""SL đề nghị + SL cần thêm""");
				else if (sldn + sl_layton > object_.sl_can + object_.sl_tonkho_toithieu)
                    msg = string.Format(@"false#""Số lượng đề nghị + SL lấy tồn"" phải nhỏ hơn hoặc bằng ""SL cần + SL tồn kho tối thiểu""");
            }
			
            if (msg.Length <= 0)
            {
                object_.sl_duyet = sl_duyet;
                object_.sl_layton = sl_layton;
                object_.sl_canthem = sl_canthem;
                
                object_.sl_denghi = sldn;
                object_.md_doitackinhdoanh_id = md_doitackinhdoanh_id;
                object_.ngayphaico = ngayPhaiCo;
                object_.nguoicapnhat = us.ad_user_id;
                object_.value_nguoicapnhat = us.ma_user;
                object_.ngaycapnhat = DateTime.Now;

                var dklhts = db.c_kehoachmuavt_dklht.Where(s =>
                s.md_sanpham_id == object_.md_sanpham_id &
                s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id);
                var slltTong = object_.sl_layton.GetValueOrDefault(0);
                foreach (var dklht in dklhts.ToList())
                {
                    dklht.sl_layton = slltTong > dklht.sl_tonkho ? dklht.sl_tonkho : slltTong;
                    slltTong = slltTong - dklht.sl_layton.GetValueOrDefault(0);
                }
                db.SaveChanges();
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
            string ten_table = "c_kehoachmuavt_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.c_kehoachmuavt_cdh.Where(p => p.c_kehoachmuavt_cdh_id == id_del_).Select(s => s.c_kehoachmuavt_cdh_id).Take(1).FirstOrDefault();
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