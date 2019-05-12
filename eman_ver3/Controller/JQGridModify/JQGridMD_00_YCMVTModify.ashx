<%@ WebHandler Language="C#" Class="JQGridMD_00_YCMVTModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
using System.Collections.Generic;

public class JQGridMD_00_YCMVTModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TaoKeHoachmuaVT":
                this.CA_01_TaoKeHoachmuaVT(context);
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

    public void CA_01_TaoKeHoachmuaVT(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        string sochungtu = "goc";
        string ten_kehoach = context.Request.Form["ten_kh"];
        DateTime? tungay = null;
        DateTime? denngay = null;

        foreach (c_yeucaumuavt ycmvt in db.c_yeucaumuavt.Where(s => vnn.Contains(s.c_yeucaumuavt_id)).ToList())
        {
            if (ycmvt.ngaycan <= tungay | tungay == null)
                tungay = ycmvt.ngaycan;

            if (ycmvt.ngaycan >= denngay | denngay == null)
                denngay = ycmvt.ngaycan;

            if (ycmvt.md_trangthai_id != "HIEULUC")
            {
                msg = "<div style='color:red'>Lỗi: Dòng \"" + ycmvt.sochungtu + "\" Chưa hiệu lực.</div>";
                break;
            }
            else if (db.c_yeucaumuavt_cdh.Where(s => s.sapxep == null & s.c_yeucaumuavt_id == ycmvt.c_yeucaumuavt_id).Count() <= 0)
            {
                msg = "<div style='color:red'>Lỗi: Dòng \"" + ycmvt.sochungtu + "\" không thể tạo thêm kế hoạch mua vật tư.</div>";
                break;
            }
            else if (!string.IsNullOrEmpty(ycmvt.c_kehoachmuavt_id) & ycmvt.c_kehoachmuavt_id != " ")
            {
                msg = "<div style='color:red'>Lỗi: Dòng \"" + ycmvt.sochungtu + "\" đã tạo kế hoạch mua vật tư.</div>";
                break;
            }
            else
            {
                ycmvt.c_kehoachmuavt_id = sochungtu;
            }
        }

        string id_new = Helper.getNewId();
        if (msg.Length <= 0)
        {
            c_kehoachmuavt khmvt = new c_kehoachmuavt
            {
                c_kehoachmuavt_id = id_new,
                c_donmuavattu_id = " ",
                md_trangthai_id = "SOANTHAO",
                sochungtu = sochungtu,
                ten_kehoach = ten_kehoach,
                tungay = tungay,
                denngay = denngay,
                ngaykehoach = DateTime.Now,
                nguoitao = us.ad_user_id,
                vaitrotao = us.ad_role_id,
                bophantao = us.md_phongban_id,
                value_nguoitao = us.ma_user,
                value_vaitrotao = us.ten_role,
                value_bophantao = us.ten_phongban,
                nguoicapnhat = us.ad_user_id,
                vaitrocapnhat = us.ad_role_id,
                bophancapnhat = us.md_phongban_id,
                value_nguoicapnhat = us.ma_user,
                value_vaitrocapnhat = us.ten_role,
                value_bophancapnhat = us.ten_phongban,
                ngaytao = DateTime.Now,
                ngaycapnhat = DateTime.Now,
                mota = "",
                hoatdong = true
            };
            db.c_kehoachmuavt.Add(khmvt);
            db.SaveChanges();

            foreach (var ycmvt_cdh in db.c_yeucaumuavt_cdh.Where(s => vnn.Contains(s.c_yeucaumuavt_id) & s.sapxep == null).ToList())
            {
                c_kehoachmuavt_cdh khmvt_cdh_chk = db.c_kehoachmuavt_cdh.Where(s => s.md_sanpham_id == ycmvt_cdh.md_sanpham_id &
                s.c_kehoachmuavt_id == khmvt.c_kehoachmuavt_id).Take(1).FirstOrDefault();
                c_kehoachmuavt_cdh khmvt_cdh = khmvt_cdh_chk;
                if (khmvt_cdh_chk == null)
                {
                    khmvt_cdh = new c_kehoachmuavt_cdh();
                    khmvt_cdh.c_kehoachmuavt_cdh_id = Helper.getNewId();
                    khmvt_cdh.c_kehoachmuavt_id = khmvt.c_kehoachmuavt_id;
                    khmvt_cdh.md_sanpham_id = ycmvt_cdh.md_sanpham_id;
                    khmvt_cdh.md_donvitinhsanpham_id = ycmvt_cdh.md_donvitinhsanpham_id;
                    string nhacungung = db.md_sanpham.Where(s => s.md_sanpham_id == ycmvt_cdh.md_sanpham_id).Select(s => s.nhacungung).FirstOrDefault();
                    if (nhacungung == null)
                    {
                        nhacungung = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == "TONGHOP").Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
                    }
                    khmvt_cdh.md_doitackinhdoanh_id = nhacungung;
                    khmvt_cdh.ngayphaico = tungay;
                    khmvt_cdh.sl_can = ycmvt_cdh.soluong_yeucau;
                    khmvt_cdh.sl_duyet = 0;
                    var tonkho = from a in db.md_kho_sanpham
                                 join b in db.md_kho on a.md_kho_id equals b.md_kho_id
                                 where b.ma_kho == "KHO1" & a.md_sanpham_id == ycmvt_cdh.md_sanpham_id
                                 select new { a.soluong };
                    decimal sl_tonkho = 0, sl_tonkho_toithieu = 0;

                    foreach (var tonkho_ in tonkho.ToList()) { try { sl_tonkho += (decimal)tonkho_.soluong.Value; } catch { } }

                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == ycmvt_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                    if (sp.sl_tonkho_toithieu != null) { sl_tonkho_toithieu = sp.sl_tonkho_toithieu.Value; }
                    khmvt_cdh.sl_tonkho = sl_tonkho;
                    khmvt_cdh.sl_tonkho_toithieu = sl_tonkho_toithieu;

                    khmvt_cdh.sl_denghi = sl_tonkho_toithieu - sl_tonkho + khmvt_cdh.sl_can;

                    if (khmvt_cdh.sl_denghi < 0) { khmvt_cdh.sl_denghi = 0; }
                    // khmvt_cdh.sl_denghi = khmvt_cdh.sl_can;
                    //- sl_tonkho + sl_tonkho_toithieu
                }
                else
                {
                    khmvt_cdh.sl_can += ycmvt_cdh.soluong_yeucau;
                    khmvt_cdh.sl_denghi += ycmvt_cdh.soluong_yeucau;
                }

                khmvt_cdh.sapxep = ycmvt_cdh.c_yeucaumuavt_cdh_id;
                khmvt_cdh.sl_conlai = 0;
                khmvt_cdh.nguoitao = us.ad_user_id;
                khmvt_cdh.vaitrotao = us.ad_role_id;
                khmvt_cdh.bophantao = us.md_phongban_id;
                khmvt_cdh.value_nguoitao = us.ma_user;
                khmvt_cdh.value_vaitrotao = us.ten_role;
                khmvt_cdh.value_bophantao = us.ten_phongban;
                khmvt_cdh.nguoicapnhat = us.ad_user_id;
                khmvt_cdh.vaitrocapnhat = us.ad_role_id;
                khmvt_cdh.bophancapnhat = us.md_phongban_id;
                khmvt_cdh.value_nguoicapnhat = us.ma_user;
                khmvt_cdh.value_vaitrocapnhat = us.ten_role;
                khmvt_cdh.value_bophancapnhat = us.ten_phongban;
                khmvt_cdh.ngaytao = DateTime.Now;
                khmvt_cdh.ngaycapnhat = DateTime.Now;
                khmvt_cdh.mota = "";
                khmvt_cdh.hoatdong = true;
                if (khmvt_cdh_chk == null)
                {
                    db.c_kehoachmuavt_cdh.Add(khmvt_cdh);
                }
                db.SaveChanges();
            }

            //Tach KHMVT
            string id_nguoidung = "";
            var dem_nguoidung = from a in db.c_kehoachmuavt_cdh
                                join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                                join c in db.md_chungloai_ql on b.md_nhomnangluc_id equals c.md_chungloai_id
                                where a.c_kehoachmuavt_id == id_new & (c.ad_user_id != null & c.ad_user_id != "" & c.ad_user_id != " ")
                                select new { c.ad_user_id };

            var dem_ = dem_nguoidung.Distinct();
            List<string> id_nd = new List<string>();
            if (dem_.Count() > 0)
            {
                foreach (var dem in dem_.ToList())
                {
                    id_nd.Add(dem.ad_user_id);
                }
            }

            //string[] id_nd = id_nguoidung.Split(',');
            //tao id_new2
            string id_new2 = "";
            string sct_chung = "";

            c_kehoachmuavt khdh = null;

            if (id_nd.Count > 0)
            {
                for (int i = 0; i < id_nd.Count; i++)
                {
                    id_new2 = Helper.getNewId();

                    string id_nd_ = id_nd[i];
                    ad_user user = db.ad_user.Where(s => s.ad_user_id == id_nd_).FirstOrDefault();
                    khdh = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == id_new).FirstOrDefault();
                    if (khdh != null)
                    {
                        c_kehoachmuavt dsdh_new = Clone(khdh);
                        dsdh_new.c_kehoachmuavt_id = id_new2;

                        var san_pham = from a in db.c_kehoachmuavt_cdh
                                       join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                                       where a.c_kehoachmuavt_id == id_new
                                       select new { a.c_kehoachmuavt_cdh_id, b.md_chungloai_id };
                        if (user != null)
                        {
                            int m = 0;
                            dsdh_new.ten_kehoach = ten_kehoach + " / " + user.ma_user;

                            var san_pham2 = from a in san_pham
                                            where (db.md_chungloai_ql.Where(s => s.md_chungloai_id == a.md_chungloai_id & s.ad_user_id == user.ad_user_id).Count() > 0)
                                            select new { a.c_kehoachmuavt_cdh_id };

                            foreach (var cdh_ in san_pham2.ToList())
                            {
                                c_kehoachmuavt_cdh cdh = db.c_kehoachmuavt_cdh.FirstOrDefault(s => s.c_kehoachmuavt_cdh_id == cdh_.c_kehoachmuavt_cdh_id);
                                if (cdh != null)
                                {
                                    c_yeucaumuavt_cdh ycmvt_cdh2 = db.c_yeucaumuavt_cdh.FirstOrDefault(s => s.c_yeucaumuavt_cdh_id == cdh.sapxep);
                                    if (ycmvt_cdh2 != null)
                                        ycmvt_cdh2.sapxep = id_new2;
                                    cdh.c_kehoachmuavt_id = id_new2;
                                    m = 1;
                                }
                            }
                            if (m > 0)
                            {
                                string sct = VNN_VariablePublic.sochungtu(db, "DTMVT", 1);
                                dsdh_new.sochungtu = sct;
                                sct_chung += sct + ",";
                                db.c_kehoachmuavt.Add(dsdh_new);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            int m = 0;
                            var san_pham2 = from a in san_pham
                                            where (db.md_chungloai_ql.Where(s => s.md_chungloai_id == a.md_chungloai_id).Count() <= 0)
                                            select new { a.c_kehoachmuavt_cdh_id };

                            dsdh_new.ten_kehoach = ten_kehoach + " / " + "Chung";

                            foreach (var cdh_ in san_pham2.ToList())
                            {
                                c_kehoachmuavt_cdh cdh = db.c_kehoachmuavt_cdh.FirstOrDefault(s => s.c_kehoachmuavt_cdh_id == cdh_.c_kehoachmuavt_cdh_id);
                                if (cdh != null)
                                {
                                    c_yeucaumuavt_cdh ycmvt_cdh2 = db.c_yeucaumuavt_cdh.FirstOrDefault(s => s.c_yeucaumuavt_cdh_id == cdh.sapxep);
                                    if (ycmvt_cdh2 != null)
                                        ycmvt_cdh2.sapxep = id_new2;
                                    cdh.c_kehoachmuavt_id = id_new2;
                                    m = 1;
                                }
                            }
                            if (m > 0)
                            {
                                string sct = VNN_VariablePublic.sochungtu(db, "DTMVT", 1);
                                dsdh_new.sochungtu = sct;
                                sct_chung += sct + ",";
                                db.c_kehoachmuavt.Add(dsdh_new);
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            else
            {
                c_kehoachmuavt nht = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == id_new).FirstOrDefault();
                string sct = VNN_VariablePublic.sochungtu(db, "DTMVT", 1);
                nht.sochungtu = sct;
                sct_chung = sct;
                db.SaveChanges();
            }

            foreach (var ycmvt in db.c_yeucaumuavt.Where(s => vnn.Contains(s.c_yeucaumuavt_id)).ToList())
            {
                if(string.IsNullOrEmpty(sct_chung))
                    sct_chung = "";
                foreach (var id_khmvt in db.c_yeucaumuavt_cdh.Where(s => s.c_yeucaumuavt_id == ycmvt.c_yeucaumuavt_id).Select(s => new { s.sapxep }).Distinct().ToList())
                {
                    c_kehoachmuavt khmvt_sct = db.c_kehoachmuavt.FirstOrDefault(s => s.c_kehoachmuavt_id == id_khmvt.sapxep);
                    if (khmvt_sct != null)
                    {
                        sct_chung += khmvt_sct.sochungtu + ",";
                    }
                }

                if (sct_chung.LastIndexOf(",") > -1)
                    ycmvt.c_kehoachmuavt_id = sct_chung.Remove(sct_chung.Length - 1);
                else if (!string.IsNullOrEmpty(sct_chung))
                    ycmvt.c_kehoachmuavt_id = sct_chung;
                else
                    ycmvt.c_kehoachmuavt_id = " ";
            }

            var remove_kh = db.c_kehoachmuavt.Where(s => s.sochungtu == "goc").FirstOrDefault();
            if (remove_kh != null)
            {
                db.c_kehoachmuavt.Remove(remove_kh);
            }
            db.SaveChanges();

            msg = "<div style='color:blue'>Đã tạo kế hoạch mua vật tư \"" + sct_chung + "\" thành công.</div>";
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
            string sochungtu = VNN_VariablePublic.sochungtu(db, "YCM", 1);
            string masp = context.Request.Form["ma_sanpham"];

            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_yeucaumuavt";
                VNN_Function.SetFormValue("sochungtu", sochungtu);
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
            string object_ = db.c_yeucaumuavt.Where(p => p.c_yeucaumuavt_id == id).Select(s => s.c_yeucaumuavt_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_yeucaumuavt";
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
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "c_yeucaumuavt";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                c_yeucaumuavt object_ = db.c_yeucaumuavt.Where(p => p.c_yeucaumuavt_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.c_kehoachmuavt_id != " " & object_.c_kehoachmuavt_id != null )
                {
                    msg_del = "Lỗi: Dòng \"" + object_.sochungtu + "\" đã tạo kế hoạch mua vật tư.";
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                    msg_del = "Lỗi: Dòng \"" + object_.sochungtu + "\" đã Hiệu Lực, không thể xóa";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    c_nhucauvattu ncvt = db.c_nhucauvattu.Where(s => s.c_nhucauvattu_id == object_.c_nhucauvattu_id).Take(1).FirstOrDefault();
                    if (ncvt != null)
                        ncvt.c_yeucaumuavt_id = " ";

                    foreach (md_dondathangphanxuong dhpx in db.md_dondathangphanxuong.Where(s => s.yeucaumuavattu == object_.sochungtu).ToList())
                    {
                        dhpx.yeucaumuavattu = " ";
                    }
                    db.c_yeucaumuavt.Remove(object_);
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
