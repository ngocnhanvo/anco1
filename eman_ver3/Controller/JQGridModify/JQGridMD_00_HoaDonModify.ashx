<%@ WebHandler Language="C#" Class="JQGridMD_00_HoaDonModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_HoaDonModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
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
            case "CA_01_TaphopHD":
                this.CA_01_TaphopHD(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_TaphopHD(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "",id_new = Helper.getNewId();

        DateTime tungay = VNN_Config.setDateTime(context.Request.Form["tungay"]);
        DateTime denngay = VNN_Config.setDateTime(context.Request.Form["denngay"]);

        string date = DateTime.Now.ToString("dd-MM-yyyy");

        string ten_hd = context.Request.Form["ten_kh"];
        string ten_ncc = context.Request.Form["ten_ncc"];
        string check = context.Request.Form["check"];

        string tong_tatca = "";
        int dem = 0;
        try
        {
            var check_true = db.md_nhapkho_ncc.Where(s => s.ngaycapnhat >= tungay & s.ngaycapnhat <= denngay).OrderBy(s => s.md_doitackinhdoanh_id);

            string dtkd_id = "", dt_id = "", id = "";
            if(check != "true"){
                dtkd_id = db.md_doitackinhdoanh.Where(s => s.ten_dtkd == ten_ncc).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
                check_true = db.md_nhapkho_ncc.Where(s => s.ngaycapnhat >= tungay & s.ngaycapnhat <= denngay & s.md_doitackinhdoanh_id == dtkd_id).OrderBy(s => s.md_doitackinhdoanh_id);
            }

            foreach(md_nhapkho_ncc nk_ncc in check_true)
            {
                md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == nk_ncc.md_doitackinhdoanh_id).FirstOrDefault();
                c_donmuahang dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == nk_ncc.c_donmuahang_id).FirstOrDefault();
                if(dt_id != dtkd.md_doitackinhdoanh_id)
                {
                    //--
                    id = Helper.getNewId();
                    dt_id = dtkd.md_doitackinhdoanh_id;
                    //--
                    md_hoadon hd = new md_hoadon();
                    hd.md_hoadon_id = id;
                    //--
                    if(ten_hd.Trim().Length > 0)
                    {
                        hd.maso = ten_hd;
                    }
                    else
                    {
                        hd.maso = "HD/" + dtkd.ma_dtkd + "/" + date;
                    }
                    hd.sct_thamchieu = dmh.sochungtu + "\n";
                    hd.phieunhapkho = nk_ncc.sochungtu + "\n";

                    hd.md_trangthai_id = "SOANTHAO";
                    hd.sochungtu = "";

                    hd.ngaylap = DateTime.Now;
                    hd.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id;
                    hd.tel = dtkd.tel;
                    hd.diachi = dtkd.diachi;
                    hd.so_taikhoan = dtkd.so_taikhoan;
                    hd.masothue = dtkd.masothue;

                    hd.tong_tienhang = 0;
                    hd.vat = null;
                    hd.tong_vat = 0;
                    hd.tong_tatca = 0;
                    hd.chu_tong_tatca = "";

                    hd.nguoitao = us.ad_user_id;
                    hd.vaitrotao = us.ad_role_id;
                    hd.bophantao = us.md_phongban_id;
                    hd.value_nguoitao = us.ma_user;
                    hd.value_vaitrotao = us.ten_role;
                    hd.value_bophantao = us.ten_phongban;

                    hd.nguoicapnhat = us.ad_user_id;
                    hd.vaitrocapnhat = us.ad_role_id;
                    hd.bophancapnhat = us.md_phongban_id;
                    hd.value_nguoicapnhat = us.ma_user;
                    hd.value_vaitrocapnhat = us.ten_role;
                    hd.value_bophancapnhat = us.ten_phongban;

                    hd.ngaytao = DateTime.Now;
                    hd.ngaycapnhat = DateTime.Now;
                    hd.mota = "";
                    hd.hoatdong = true;
                    db.md_hoadon.Add(hd);
                    dem++;
                }
                else
                {
                    md_hoadon h_d = db.md_hoadon.Where(s => s.md_hoadon_id == id & s.md_doitackinhdoanh_id == dt_id).FirstOrDefault();
                    if(h_d.sct_thamchieu != dmh.sochungtu + "\n")
                    {
                        h_d.sct_thamchieu += dmh.sochungtu + "\n";
                    }

                    if(h_d.phieunhapkho != nk_ncc.sochungtu + "\n")
                    {
                        h_d.phieunhapkho += nk_ncc.sochungtu + "\n";
                    }

                    h_d.ngaycapnhat = DateTime.Now;
                }

                string donvitinh = "";
                foreach(md_nhapkho_ncc_dh dh in db.md_nhapkho_ncc_dh.Where(s => s.md_nhapkho_ncc_id == nk_ncc.md_nhapkho_ncc_id))
                {
                    if(dh != null)
                    {
                        var yhm = from a in db.md_nhapkho_ncc
                                  join b in db.c_donmuahang_cdmh on a.c_donmuahang_id equals b.c_donmuahang_id
                                  join c in db.c_donmuahang on b.c_donmuahang_id equals c.c_donmuahang_id
                                  where a.md_nhapkho_ncc_id == dh.md_nhapkho_ncc_id & b.md_sanpham_id == dh.md_sanpham_id
                                  select new { b.dongiamua, b.thue , c.md_dongtien_id };
                        foreach (var yhm_ in yhm)
                        {
                            md_hoadon_chitiet hd_ct = db.md_hoadon_chitiet.Where(s => s.md_sanpham_id == dh.md_sanpham_id & s.md_hoadon_id == id & s.dongiamua == yhm_.dongiamua).Take(1).FirstOrDefault();
                            md_hoadon_chitiet chitiet = hd_ct;

                            if(hd_ct == null)
                            {
                                chitiet = new md_hoadon_chitiet();
                                chitiet.md_hoadon_chitiet_id = Helper.getNewId();
                                chitiet.md_hoadon_id = id;
                                chitiet.md_sanpham_id = dh.md_sanpham_id;
                                chitiet.soluong = dh.sl_danhap;

                                try
                                {
                                    donvitinh = db.md_dongtien.Where(s => s.md_dongtien_id == yhm_.md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();;
                                    md_thue_sanpham thue = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == yhm_.thue).FirstOrDefault();
                                    chitiet.dongiamua = (decimal)yhm_.dongiamua.Value;
                                    chitiet.thanhtien = (decimal)yhm_.dongiamua.Value * dh.sl_danhap;
                                    chitiet.vat = (int)thue.giatri.Value;
                                    chitiet.tong_vat = (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                    chitiet.tong_tatca = (decimal)yhm_.dongiamua.Value * dh.sl_danhap + (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                chitiet.soluong += dh.sl_danhap;
                                try
                                {
                                    donvitinh = db.md_dongtien.Where(s => s.md_dongtien_id == yhm_.md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();;
                                    md_thue_sanpham thue = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == yhm_.thue).FirstOrDefault();
                                    chitiet.dongiamua = (decimal)yhm_.dongiamua.Value;
                                    chitiet.thanhtien += (decimal)yhm_.dongiamua.Value * dh.sl_danhap;
                                    chitiet.vat = (int)thue.giatri.Value;
                                    chitiet.tong_vat += (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                    chitiet.tong_tatca += (decimal)yhm_.dongiamua.Value * dh.sl_danhap + (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                }
                                catch
                                {
                                }
                            }


                            chitiet.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;

                            //
                            chitiet.nguoitao = us.ad_user_id;
                            chitiet.vaitrotao = us.ad_role_id;
                            chitiet.bophantao = us.md_phongban_id;
                            chitiet.value_nguoitao = us.ma_user;
                            chitiet.value_vaitrotao = us.ten_role;
                            chitiet.value_bophantao = us.ten_phongban;

                            chitiet.nguoicapnhat = us.ad_user_id;
                            chitiet.vaitrocapnhat = us.ad_role_id;
                            chitiet.bophancapnhat = us.md_phongban_id;
                            chitiet.value_nguoicapnhat = us.ma_user;
                            chitiet.value_vaitrocapnhat = us.ten_role;
                            chitiet.value_bophancapnhat = us.ten_phongban;

                            chitiet.ngaytao = DateTime.Now;
                            chitiet.ngaycapnhat = DateTime.Now;
                            chitiet.mota = "";
                            chitiet.hoatdong = true;
                            if(hd_ct == null)
                            {
                                db.md_hoadon_chitiet.Add(chitiet);
                            }
                            db.SaveChanges();
                        }
                    }
                }

                md_hoadon hd_ = db.md_hoadon.Where(s => s.md_hoadon_id == id).Take(1).FirstOrDefault();
                hd_.tong_tienhang = 0;
                hd_.tong_vat = 0;
                hd_.tong_tatca = 0;

                foreach(md_hoadon_chitiet dh_c in db.md_hoadon_chitiet.Where(s => id == s.md_hoadon_id))
                {
                    hd_.tong_tienhang += dh_c.thanhtien;
                    hd_.tong_vat += dh_c.tong_vat;
                    hd_.tong_tatca += dh_c.tong_tatca;
                }
                double p = Math.Round(Convert.ToDouble(hd_.tong_tatca),0);
                var cttc = VNN_ConvertMoney.convert(p, donvitinh).FirstOrDefault();
                if(donvitinh == null & donvitinh == "")
                {
                    donvitinh = "VND";
                }

                hd_.chu_tong_tatca = cttc.Key;
                db.SaveChanges();
            }
            msg = "<div style='color:blue'>Tạo hòa đơn thành công.</div>";
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
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ten_dtkd = context.Request.Form["md_doitackinhdoanh_id"];
        string phieunhapkho = context.Request.Form["phieunhapkho"];
        string[] pnk = phieunhapkho.Split('\n');
        try
        {
            string id = context.Request.Form["id"];
            string md_doitackinhdoanh_id = db.md_doitackinhdoanh.Where(s => s.ten_dtkd == ten_dtkd).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
            string pnk_ = "";
            for(int i = 0; i <= (pnk.Count() - 1); i++)
            {
                string pnkI = pnk[i];
                string md_nhapkho_ncc_id = db.md_nhapkho_ncc.Where(s => s.sochungtu == pnkI).Select(s => s.md_nhapkho_ncc_id).FirstOrDefault();
                pnk_ += md_nhapkho_ncc_id + ",";
            }
            string[] pnk_id = pnk_.Split(',');
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_hoadon";
                VNN_Function.SetFormValue("md_doitackinhdoanh_id",md_doitackinhdoanh_id);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;

                int m = 0;
                string donvitinh = "";
                foreach(var dh in db.md_nhapkho_ncc_dh.Where(s => pnk_id.Contains(s.md_nhapkho_ncc_id)).ToList())
                {
                    if(dh != null)
                    {
                        var yhm = from a in db.md_nhapkho_ncc
                                  join b in db.c_donmuahang_cdmh on a.c_donmuahang_id equals b.c_donmuahang_id
                                  join c in db.c_donmuahang on b.c_donmuahang_id equals c.c_donmuahang_id
                                  where a.md_nhapkho_ncc_id == dh.md_nhapkho_ncc_id & b.md_sanpham_id == dh.md_sanpham_id
                                  select new { b.dongiamua, b.thue , c.md_dongtien_id };
                        foreach (var yhm_ in yhm.ToList())
                        {
                            var hd_ct = db.md_hoadon_chitiet.Where(s => s.md_sanpham_id == dh.md_sanpham_id & s.md_hoadon_id == id_new & s.dongiamua == yhm_.dongiamua).Take(1).FirstOrDefault();
                            md_hoadon_chitiet chitiet = hd_ct;

                            if(hd_ct == null)
                            {
                                chitiet = new md_hoadon_chitiet();
                                chitiet.md_hoadon_chitiet_id = Helper.getNewId();
                                chitiet.md_hoadon_id = id_new;
                                chitiet.md_sanpham_id = dh.md_sanpham_id;
                                chitiet.soluong = dh.sl_danhap;


                                try
                                {
                                    donvitinh = db.md_dongtien.Where(s => s.md_dongtien_id == yhm_.md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();;
                                    var thue = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == yhm_.thue).FirstOrDefault();
                                    chitiet.dongiamua = (decimal)yhm_.dongiamua.Value;
                                    chitiet.thanhtien = (decimal)yhm_.dongiamua.Value * dh.sl_danhap;
                                    chitiet.vat = (int)thue.giatri.Value;
                                    chitiet.tong_vat = (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                    chitiet.tong_tatca = (decimal)yhm_.dongiamua.Value * dh.sl_danhap + (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                chitiet.soluong += dh.sl_danhap;

                                try
                                {
                                    donvitinh = db.md_dongtien.Where(s => s.md_dongtien_id == yhm_.md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();;
                                    var thue = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == yhm_.thue).FirstOrDefault();
                                    chitiet.dongiamua = (decimal)yhm_.dongiamua.Value;
                                    chitiet.thanhtien += (decimal)yhm_.dongiamua.Value * dh.sl_danhap;
                                    chitiet.vat = (int)thue.giatri.Value;
                                    chitiet.tong_vat += (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                    chitiet.tong_tatca += (decimal)yhm_.dongiamua.Value * dh.sl_danhap + (decimal)yhm_.dongiamua.Value * dh.sl_danhap * (int)thue.giatri.Value / 100;
                                }
                                catch
                                {
                                }
                            }

                            chitiet.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;

                            //
                            chitiet.nguoitao = us.ad_user_id;
                            chitiet.vaitrotao = us.ad_role_id;
                            chitiet.bophantao = us.md_phongban_id;
                            chitiet.value_nguoitao = us.ma_user;
                            chitiet.value_vaitrotao = us.ten_role;
                            chitiet.value_bophantao = us.ten_phongban;

                            chitiet.nguoicapnhat = us.ad_user_id;
                            chitiet.vaitrocapnhat = us.ad_role_id;
                            chitiet.bophancapnhat = us.md_phongban_id;
                            chitiet.value_nguoicapnhat = us.ma_user;
                            chitiet.value_vaitrocapnhat = us.ten_role;
                            chitiet.value_bophancapnhat = us.ten_phongban;

                            chitiet.ngaytao = DateTime.Now;
                            chitiet.ngaycapnhat = DateTime.Now;
                            chitiet.mota = "";
                            chitiet.hoatdong = true;
                            if(hd_ct == null)
                            {
                                db.md_hoadon_chitiet.Add(chitiet);
                            }
                            db.SaveChanges();
                        }
                    }
                }

                md_hoadon hd = db.md_hoadon.Where(s => s.md_hoadon_id == id_new).Take(1).FirstOrDefault();
                foreach(md_hoadon_chitiet dh_c in db.md_hoadon_chitiet.Where(s => id_new == s.md_hoadon_id).ToList())
                {
                    hd.tong_tienhang += dh_c.thanhtien;
                    hd.tong_vat += dh_c.tong_vat;
                    hd.tong_tatca += dh_c.tong_tatca;
                }
                var cttc = VNN_ConvertMoney.convert(Convert.ToDouble(hd.tong_tatca), donvitinh).FirstOrDefault();
                hd.chu_tong_tatca = cttc.Key;
                db.SaveChanges();
            }
        }
        catch(Exception ex)
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
            md_hoadon object_ = db.md_hoadon.Where(p => p.md_hoadon_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Mã hóa đơn đã 'Hiệu lực' không thể sửa";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_hoadon";
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", "VNN_notpost");
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
            }
        }
        catch(Exception ex)
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
            string ten_table = "md_hoadon";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_hoadon object_ = db.md_hoadon.Where(p => p.md_hoadon_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if(object_.md_trangthai_id == "HIEULUC")
                {
                    msg_del = "Lỗi:Hóa đơn \"" + object_.maso + "\" đã \"Hiệu lực\" không thể xóa" + i;
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    db.md_hoadon.Remove(object_);
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
