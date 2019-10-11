<%@ WebHandler Language="C#" Class="JQGridMD_00_DCHTJQGSModify" %> using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.SqlClient;

public class JQGridMD_00_DCHTJQGSModify : IHttpHandler,
System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "") oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
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
            case "CA_01_DCHTJQGS":
                this.CA_01_DCHTJQGS(context);
                break;
            case "CA_01_UpdateTHDH":
                this.CA_01_UpdateTHDH(context);
                break;
            case "CA_01_LKHDHJQGS":
                this.CA_01_LKHDHJQGS(context);
                break;
            case "CA_01_HLPLHTJQGS":
                this.CA_01_HLPLHTJQGS(context);
                break;
            default:
                break;
        }
    }

    private void CA_01_HLPLHTJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context),
        Security.id_phongban(context));
        string msg = "";
        var ids = new List<string>();
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');


        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var khohangton = from a in db.md_kho
                                 join b in db.md_kho_sanpham on a.md_kho_id equals b.md_kho_id
                                 join c in db.md_sanpham on b.md_sanpham_id equals c.md_sanpham_id
                                 where a.hangton == true
                                 select new
                                 {
                                     a.md_kho_id,
                                     a.ten_kho,
                                     c.ma_sanpham,
                                     b.md_sanpham_id,
                                     c.md_donvitinhsanpham_id,
                                     c.mota_tiengviet,
                                     c.mota_tienganh,
                                     b.soluong,
                                     c.mota,
                                     c.sanpham
                                 };

                if (vnn.Count() > 1)
                {
                    msg = "<div style='color:red'>Lỗi:Chỉ được chọn 1 phiếu đối chiếu hàng tồn.</div>";
                }
                else
                {
                    foreach (var dcht in db.c_doichieuhangton.Where(s => vnn.Contains(s.c_doichieuhangton_id)).ToList())
                    {
                        var c_doichieuhangton_dklht = db.c_doichieuhangton_dklht.Where(s => s.c_doichieuhangton_id == id);
                        if (dcht.doichieuht != true)
                        {
                            msg += "<div style='color:red'>Lỗi: Dòng " + dcht.ten_donhang + " Chưa được đối chiếu hàng tồn.</div>";
                        }
                        else if (!string.IsNullOrEmpty(dcht.kehoach) & dcht.kehoach != " ")
                        {
                            msg += string.Format(@"<div style='color:red'>Lỗi: Dòng ""{0}"" đã tạo kế hoạch đặt hàng.</div>", dcht.ten_donhang);
                        }
                        else if (!string.IsNullOrEmpty(dcht.phieuhangton) & dcht.phieuhangton != " ")
                        {
                            msg += "";
                        }
                        else
                        {
                            var phtArr = dcht.phieuhangton.Split(new[] { "<br>" }, StringSplitOptions.None);
                            foreach (var dcht_tk in db.c_doichieuhangton_tk.Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id).ToList())
                            {
                                var tht = khohangton.Where(s =>
                                        s.md_sanpham_id == dcht_tk.md_sanpham_id
                                    )
                                    .ToList()
                                    .Select(s =>
                                    s.soluong -
                                    db.md_kho_giucho.Where(t =>
                                                    t.md_sanpham_id == s.md_sanpham_id &
                                                    t.md_kho_id == s.md_kho_id
                                                    )
                                                    .Select(t => t.soluong_giucho)
                                                    .Sum().GetValueOrDefault(0)
                                    ).Sum();

                                if (dcht_tk.sl_conlai != tht.GetValueOrDefault(0))
                                {
                                    msg += string.Format(@"
                                        <div style='color:red'>
                                            Lỗi: dòng ""{0}"" đã có sự thay đổi số lượng tồn kho.
                                            <br/>
                                            <input type=""button"" value=""Đối chiếu lại hàng tồn"" 
                                            onclick=""$('#dlg_gridSmall').remove();CA_01_DCHTJQGS(tengrid0, id_parent0, 'CA_01_DCHTJQGS', Form_infor0, Model_infor0, load_stt0);""/ >
                                        </div>", dcht.ten_donhang);
                                    break;
                                }
                            }

                            var lstKho = new List<Dictionary<string, object>>();
                            foreach (var dklht in c_doichieuhangton_dklht.OrderBy(s => s.md_kho_id).ToList())
                            {
                                var khoArr = dklht.md_kho_id.Split(',');
                                decimal? slLay = dklht.sl_lay - dklht.sl_dalay;
                                foreach (string khoId in khoArr)
                                {
                                    var ksp = db.md_kho_sanpham.Where(s => s.md_kho_id == khoId & s.md_sanpham_id == dklht.md_sanpham_id).FirstOrDefault();
                                    if (slLay > 0)
                                    {
                                        decimal? slLayCP = ksp.soluong > slLay ? slLay : ksp.soluong;
                                        slLay = (slLay - slLayCP).GetValueOrDefault(0).Set0WhenlessThan0();

                                        if (slLayCP > 0)
                                        {
                                            var item = new Dictionary<string, object>();
                                            item["kho"] = khoId;
                                            item["sp"] = dklht.md_sanpham_id;
                                            item["dvt"] = dklht.md_donvitinhsanpham_id;
                                            item["sl_lay"] = slLayCP;
                                            lstKho.Add(item);
                                        }
                                    }
                                }
                            }

                            string md_kho_id = "", sochungtu = "", id_new = "";
                            foreach (var dklht in lstKho.OrderBy(s => s["kho"].ToString()))
                            {
                                decimal? slLayCP = decimal.Parse(dklht["sl_lay"].ToString());
                                string khoId = dklht["kho"].ToString();
                                string md_sanpham_id = dklht["sp"].ToString();
                                string md_donvitinhsanpham_id = dklht["dvt"].ToString();
                                if (slLayCP > 0)
                                {
                                    string[] kq = new string[2];
                                    if (md_kho_id != khoId)
                                    {
                                        md_kho_id = khoId;
                                        kq = tao_phieu(db, dcht, md_kho_id, md_sanpham_id, us);
                                        id_new = kq[0];
                                        sochungtu = kq[1];
                                        ids.Add(id_new);
                                    }

                                    var cdvc = new md_vanchuyennoibo_cdvc
                                    {
                                        md_vanchuyennoibo_cdvc_id = Helper.getNewId(),
                                        md_vanchuyennoibo_id = id_new,
                                        md_sanpham_id = md_sanpham_id,
                                        md_donvitinhsanpham_id = md_donvitinhsanpham_id,
                                        soluong_toida = slLayCP,
                                        soluong_dachuyen = 0,
                                        soluong_muonchuyen = slLayCP,
                                        soluong_dichchuyen = slLayCP,
                                        dachuyenhet = false,
                                        sapxep = "",
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
                                        hoatdong = true
                                    };
                                    db.md_vanchuyennoibo_cdvc.Add(cdvc);

                                    var giucho = new md_kho_giucho();
                                    giucho.md_kho_giucho_id = Helper.getNewId();
                                    giucho.md_kho_id = khoId;
                                    giucho.md_sanpham_id = md_sanpham_id;
                                    giucho.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
                                    giucho.soluong_giucho = slLayCP;
                                    giucho.sctlienquan = sochungtu;
                                    giucho.ngaygiu = DateTime.Now;
                                    giucho.nguoitao = us.ad_user_id;
                                    giucho.nguoicapnhat = us.ad_user_id;
                                    giucho.ngaytao = DateTime.Now;
                                    giucho.ngaycapnhat = DateTime.Now;
                                    giucho.bophantao = us.md_phongban_id;
                                    giucho.bophancapnhat = us.md_phongban_id;
                                    giucho.vaitrotao = us.ad_role_id;
                                    giucho.vaitrocapnhat = us.ad_role_id;
                                    giucho.hoatdong = true;
                                    giucho.mota = "";
                                    giucho.lydo = "";
                                    db.md_kho_giucho.Add(giucho);
                                }
                                db.SaveChanges();
                            }
                        }
                    }
                    HttpUtility.HtmlEncode(msg);
                }
            }
            catch (Exception ex)
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: {0}</div>", ex.Message);
            }

            if (msg.Length <= 0)
            {
                transaction.Commit();
                string formData = "";
                formData += string.Format(@"oper=CA_01_XuLyVanChuyen");
                formData += string.Format(@"&id={0}", string.Join(",", ids));
                VNN_VariablePublic.GetModule("/Controller/JQGridModify/JQGridMD_00_PVCNoiBoModify.ashx", formData);
            }
            else
            {
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public string[] tao_phieu(EntityContext db, c_doichieuhangton dcht, string tukho, string md_sanpham_id, User_TK us)
    {
        string[] kq = new string[2];
        kq[0] = Helper.getNewId();
        string md_kho_id = db.md_sanpham.Where(s => s.md_sanpham_id == md_sanpham_id).Select(s => s.khomacdinh).Take(1).FirstOrDefault();
        if(string.IsNullOrEmpty(md_kho_id))
        {
            md_kho_id = db.md_kho.Where(s => s.ten_kho == "KHO THÀNH PHẨM AN CO 2").Select(s=>s.md_kho_id).FirstOrDefault();
        }
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);
        //Tạo phiếu lấy hàng tồn
        //md_vanchuyennoibo check = db.md_vanchuyennoibo.Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id & s.tukho == tukho & s.denkho == md_kho_id).FirstOrDefault();
        md_vanchuyennoibo vc = new md_vanchuyennoibo();
        //if (check == null)

        //vc = new md_vanchuyennoibo();  
        kq[1] = sochungtu;
        vc.md_vanchuyennoibo_id = kq[0];
        vc.sochungtu = sochungtu;
        vc.c_doichieuhangton_id = dcht.c_doichieuhangton_id;
        vc.md_trangthai_id = "DANHAN";
        vc.sctdathang = dcht.so_donhang;
        vc.loaichuyen = "VANCNB";
        vc.ngaychuyen = DateTime.Now;
        vc.tukho = tukho;
        vc.ketoan = true;
        vc.denkho = md_kho_id;
        vc.nguoitao = us.ad_user_id;
        vc.vaitrotao = us.ad_role_id;
        vc.bophantao = us.md_phongban_id;
        vc.value_nguoitao = us.ma_user;
        vc.value_vaitrotao = us.ten_role;
        vc.value_bophantao = us.ten_phongban;
        vc.nguoicapnhat = us.ad_user_id;
        vc.vaitrocapnhat = us.ad_role_id;
        vc.bophancapnhat = us.md_phongban_id;
        vc.value_nguoicapnhat = us.ma_user;
        vc.value_vaitrocapnhat = us.ten_role;
        vc.value_bophancapnhat = us.ten_phongban;

        vc.ngaytao = DateTime.Now;
        vc.ngaycapnhat = DateTime.Now;
        db.md_vanchuyennoibo.Add(vc);

        vc.hoatdong = true;

        if (dcht.phieuhangton != null & dcht.phieuhangton != "" & dcht.phieuhangton != " ")
        {
            dcht.phieuhangton += "<br>" + sochungtu;
        }
        else
            dcht.phieuhangton = sochungtu;
        return kq;
    }

    public string noidung(EntityContext db, c_doichieuhangton dcht, string tukho, string md_sanpham_id, string md_donvitinhsanpham_id,
        decimal sl_lay, decimal sl_dalay, decimal sl_trongkho, string ma_kho, User_TK us, string id)
    {
        string md_kho_id = db.md_sanpham.Where(s => s.md_sanpham_id == md_sanpham_id).Select(s => s.khomacdinh).Take(1).FirstOrDefault();
        decimal sl_toida = sl_lay - sl_dalay;
        if (sl_toida > sl_trongkho)
        {
            sl_toida = sl_trongkho;
        }
        var cdvc = new md_vanchuyennoibo_cdvc
        {
            md_vanchuyennoibo_cdvc_id = Helper.getNewId(),
            md_vanchuyennoibo_id = id,
            md_sanpham_id = md_sanpham_id,
            md_donvitinhsanpham_id = md_donvitinhsanpham_id,
            soluong_toida = sl_toida,
            soluong_dachuyen = 0,
            soluong_dichchuyen = sl_toida,
            ma_tukho = ma_kho,
            dachuyenhet = false,
            sapxep = "",
            //tukho = dklht.md_kho_id,
            denkho = md_kho_id,
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
            hoatdong = true
        };
        db.md_vanchuyennoibo_cdvc.Add(cdvc);
        return id;
    }

    private void CA_01_LKHDHJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context),
        Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                if (msg.Length <= 0)
                {
                    foreach (var dcht in db.c_doichieuhangton.Where(s => vnn.Contains(s.c_doichieuhangton_id)).ToList())
                    {
                        if (dcht.kehoach != null & dcht.kehoach != "" & dcht.kehoach != " ")
                        {
                            msg += "<div style='color:red'>Lỗi: dòng " + dcht.ten_donhang + " đã được lập kế hoạch.</div>";
                        }
                        else if (dcht.doichieuht != true)
                        {
                            msg += "<div style='color:red'>Lỗi: dòng " + dcht.ten_donhang + " Chưa được đối chiếu hàng tồn.</div>";
                        }
                        else
                        {
                            var ds = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == dcht.c_danhsachdathang_id).FirstOrDefault();
                            //Tạo kế hoạch đặt hàng
                            dcht.kehoach = dcht.ten_donhang;
                            ds.md_trangthai_id = "CHUAXULY";
                            string id_khdh = Helper.getNewId();
                            var kh = new c_kehoachdathang();
                            kh.c_kehoachdathang_id = id_khdh;
                            kh.xulykehoach = false;
                            kh.c_doichieuhangton_id = dcht.c_doichieuhangton_id;
                            kh.mota = dcht.mota;
                            kh.ngaybatdausx = ds.ngaybatdau;
                            kh.sodonhang = dcht.so_donhang;
                            kh.ten_kh = dcht.ten_donhang;
                            kh.ngaykehoach = dcht.ngaykehoach;
                            kh.donhang_thamchieu = dcht.donhang_thamchieu;
                            kh.trangthai = "SOANTHAO";
                            kh.nguoitao = us.ad_user_id;
                            kh.vaitrotao = us.ad_role_id;
                            kh.bophantao = us.md_phongban_id;
                            kh.value_nguoitao = us.ma_user;
                            kh.value_vaitrotao = us.ten_role;
                            kh.value_bophantao = us.ten_phongban;
                            kh.nguoicapnhat = us.ad_user_id;
                            kh.vaitrocapnhat = us.ad_role_id;
                            kh.bophancapnhat = us.md_phongban_id;
                            kh.value_nguoicapnhat = us.ma_user;
                            kh.value_vaitrocapnhat = us.ten_role;
                            kh.value_bophancapnhat = us.ten_phongban;
                            kh.ngaytao = DateTime.Now;
                            kh.ngaycapnhat = DateTime.Now;
                            kh.hoatdong = true;
                            db.c_kehoachdathang.Add(kh);
                            //Tạo dòng hàng trong kế hoạch đặt hàng
                            foreach (var dkdh in db.c_doichieuhangton_dkdh.Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id).ToList())
                            {
                                if (dkdh.sl_dat > 0)
                                {
                                    decimal sl_phanphoi = 0;
                                    string nhacungung = "";
                                    var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dkdh.md_sanpham_id).Take(1).FirstOrDefault();
                                    if (sp.muangoai.GetValueOrDefault(false) != true)
                                    {
                                        sl_phanphoi = dkdh.sl_dat.Value;
                                    }

                                    if (sp.nhacungung == null || sp.nhacungung == "" || sp.nhacungung == " ")
                                    {
                                        var dtkd_ht = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == "MUA NGOAI").FirstOrDefault();
                                        if (dtkd_ht != null)
                                        {
                                            nhacungung = dtkd_ht.md_doitackinhdoanh_id;
                                        }
                                    }
                                    else
                                    {
                                        nhacungung = sp.nhacungung;
                                    }

                                    var cdhcd = new c_kehoachdathang_cdhcd
                                    {
                                        c_kehoachdathang_cdhcd_id = Helper.getNewId(),
                                        c_kehoachdathang_id = id_khdh,
                                        md_sanpham_id = dkdh.md_sanpham_id,
                                        md_donvitinhsanpham_id = dkdh.md_donvitinhsanpham_id,
                                        macuoi = dkdh.macuoi,
                                        sl_giamhanngach = dkdh.sl_giamhanngach,
                                        sl_candat = dkdh.sl_dat,
                                        sl_phanphoi = sl_phanphoi,
                                        md_doitackinhdoanh_id = nhacungung,
                                        md_phanxuong_id = sp.md_phanxuong_id,
                                        noigiaohang = sp.noigiaohang,

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
                                        hoatdong = true
                                    };
                                    db.c_kehoachdathang_cdhcd.Add(cdhcd);
                                }
                            }
                            msg_success += "<div style='color:blue'>Dòng " + dcht.ten_donhang + " đã lập kế hoạch thành công.</div>";
                            db.SaveChanges();
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg += string.Format(@"<div style='color:red'>Lỗi: {0}.</div>", ex.Message);
            }

            if (msg.Length <= 0)
            {
                transaction.Commit();
                msg = msg_success;
            }
            else
            {
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);

    }

    public void CA_01_UpdateTHDH(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context),
        Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        bool commit = true;
        try
        {
            foreach (var dcht in db.c_doichieuhangton.
                    Where(s => vnn.Contains(s.c_doichieuhangton_id)).ToList())
            {
                if (dcht.doichieuht == false)
                {
                    msg = "<div style='color:red'>Dòng: \"" + dcht.ten_donhang + "\" chưa thực hiện đối chiếu hàng tồn.</div>";
                }

                if (msg.Length <= 0)
                {
                    db.c_doichieuhangton_thdh.RemoveRange(db.c_doichieuhangton_thdh.Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id));
                    db.SaveChanges();
                    foreach (var dkdh in db.c_doichieuhangton_dkdh.
                            Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id).ToList())
                    {
                        add_thdh(db, dkdh, us);
                    }
                    db.SaveChanges();

                    var cdcht_thdhs = db.c_doichieuhangton_thdh.
                            Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id);
                    //--sl_layhangton
                    foreach (var dklht in db.c_doichieuhangton_dklht.
                            Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id).ToList())
                    {
                        var dcht_thdh = cdcht_thdhs.Where(s => s.md_sanpham_id == dklht.md_sanpham_id).FirstOrDefault();
                        if (dcht_thdh != null)
                            dcht_thdh.sl_layhangton = dklht.sl_dalay.GetValueOrDefault(0);
                    }
                    db.SaveChanges();
                    //--sl_sanxuat
                    foreach (var dhcpx in db.c_kehoachdathang_dhcpx.
                            Where(s => s.sctdathang == dcht.so_donhang).ToList())
                    {
                        foreach (var dhcpx_cdh in db.c_kehoachdathang_dhcpx_cdh.
                                Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).ToList())
                        {
                            var dcht_thdh = cdcht_thdhs.FirstOrDefault(s => s.md_sanpham_id == dhcpx_cdh.md_sanpham_id);
                            if (dcht_thdh != null)
                                dcht_thdh.sl_sanxuat += dhcpx_cdh.soluong.GetValueOrDefault(0);
                        }
                    }
                    db.SaveChanges();
                    //--sl_dasanxuat
                    foreach (var ddhpx in db.md_dondathangphanxuong.Where(s => s.sctdathang == dcht.so_donhang & s.donhang_thamchieu == dcht.donhang_thamchieu).ToList())
                    {
                        foreach (var lsx in db.md_lenhsanxuat.Where(s => s.md_dondathangphanxuong_id == ddhpx.md_dondathangphanxuong_id).ToList())
                        {
                            foreach (var lsx_to in db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).ToList())
                            {
                                foreach (var lsx_to_dh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == lsx_to.md_lenhsanxuat_tosx_id).ToList())
                                {
                                    var dcht_thdh = cdcht_thdhs.FirstOrDefault(s => s.md_sanpham_id == lsx_to_dh.md_sanpham_id);
                                    if (dcht_thdh != null)
                                        dcht_thdh.sl_dasanxuat += lsx_to_dh.sl_danhapkho.GetValueOrDefault(0);
                                }
                            }
                        }
                    }
                    db.SaveChanges();
                    //--sl_datmua
                    foreach (var dhncc in db.c_kehoachdathang_dhncc.
                            Where(s => s.sctdathang == dcht.so_donhang).ToList())
                    {
                        foreach (var dhncc_cdh in db.c_kehoachdathang_dhncc_cdh.
                                Where(s => s.c_kehoachdathang_dhncc_id == dhncc.c_kehoachdathang_dhncc_id).ToList())
                        {
                            var dcht_thdh = cdcht_thdhs.
                                    FirstOrDefault(s => s.md_sanpham_id == dhncc_cdh.md_sanpham_id);
                            if (dcht_thdh != null)
                                dcht_thdh.sl_datmua += dhncc_cdh.soluong.GetValueOrDefault(0);
                        }
                    }
                    db.SaveChanges();
                    //--sl_damua
                    foreach (var dmh in db.c_donmuahang.
                            Where(s => s.sctdathang == dcht.so_donhang & s.md_trangthai_id != "SOANTHAO" & (s.bosung == false | s.bosung == null)).ToList())
                    {
                        foreach (var dmh_cdmh in db.c_donmuahang_cdmh.
                                Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).ToList())
                        {
                            var dcht_thdh = cdcht_thdhs.FirstOrDefault(s => s.md_sanpham_id == dmh_cdmh.md_sanpham_id);
                            if (dcht_thdh != null)
                                dcht_thdh.sl_damua += dmh_cdmh.sl_dadat.GetValueOrDefault(0);
                        }
                    }
                    db.SaveChanges();

                    foreach (var dcht_thdh in db.c_doichieuhangton_thdh.
                            Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id).ToList())
                    {
                        if (dcht_thdh.sl_donhang > 0)
                            dcht_thdh.sl_thieu = dcht_thdh.sl_donhang - dcht_thdh.sl_dasanxuat - dcht_thdh.sl_layhangton - dcht_thdh.sl_damua;
                        else
                            dcht_thdh.sl_thieu = 0;
                    }
                    db.SaveChanges();
                }
            }
            if (msg.Length <= 0)
            {
                msg = "<div style='color:blue'>Cập nhật tình hình đơn hàng thành công.</div>";
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public string add_thdh(EntityContext db, c_doichieuhangton_dkdh dkdh, User_TK us)
    {
        string id_new = Helper.getNewId();
        var thdh = new c_doichieuhangton_thdh();
        thdh.c_doichieuhangton_thdh_id = id_new;
        thdh.sl_layhangton = 0;
        thdh.sl_datmua = 0;
        thdh.sl_damua = 0;
        thdh.sl_dasanxuat = 0;
        thdh.sl_sanxuat = 0;
        thdh.sl_thieu = 0;
        thdh.c_doichieuhangton_id = dkdh.c_doichieuhangton_id;
        thdh.md_sanpham_id = dkdh.md_sanpham_id;
        thdh.sl_donhang = dkdh.sl_dathang;
        thdh.md_donvitinhsanpham_id = dkdh.md_donvitinhsanpham_id;
        thdh.nguoitao = us.ad_user_id;
        thdh.vaitrotao = us.ad_role_id;
        thdh.bophantao = us.md_phongban_id;
        thdh.value_nguoitao = us.ma_user;
        thdh.value_vaitrotao = us.ten_role;
        thdh.value_bophantao = us.ten_phongban;
        thdh.nguoicapnhat = us.ad_user_id;
        thdh.vaitrocapnhat = us.ad_role_id;
        thdh.bophancapnhat = us.md_phongban_id;
        thdh.value_nguoicapnhat = us.ma_user;
        thdh.value_vaitrocapnhat = us.ten_role;
        thdh.value_bophancapnhat = us.ten_phongban;
        thdh.hoatdong = true;
        thdh.ngaytao = DateTime.Now;
        thdh.ngaycapnhat = DateTime.Now;
        db.c_doichieuhangton_thdh.Add(thdh);
        return id_new;
    }

    public void CA_01_DCHTJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        try
        {
            foreach (var dcht1 in db.c_doichieuhangton.Where(s => vnn.Contains(s.c_doichieuhangton_id)).ToList())
            {
                if (dcht1.kehoach != " ")
                {
                    msg += "<div style='color:red'>Lỗi: dòng " + dcht1.ten_donhang + " đã được lập kế hoạch.</div>";
                }
                else
                {
                    var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == dcht1.c_danhsachdathang_id).FirstOrDefault();
                    dsdh.md_trangthai_id = "DOICHIEUHANGTON";

                    del_doichieuhangton(db, vnn);
                    //San pham trong kho ton
                    var khohangton = from a in db.md_kho
                                     join b in db.md_kho_sanpham on a.md_kho_id equals b.md_kho_id
                                     join c in db.md_sanpham on b.md_sanpham_id equals c.md_sanpham_id
                                     where a.hangton == true
                                     select new
                                     {
                                         a.md_kho_id,
                                         a.ten_kho,
                                         c.ma_sanpham,
                                         b.md_sanpham_id,
                                         c.md_donvitinhsanpham_id,
                                         c.mota_tiengviet,
                                         c.mota_tienganh,
                                         b.soluong,
                                         c.mota,
                                         c.sanpham
                                     };

                    //Doi chieu hang ton
                    foreach (var cddh in db.c_doichieuhangton_cddh.Where(s => s.c_doichieuhangton_id == dcht1.c_doichieuhangton_id).ToList())
                    {
                        string spBomId = db.c_dongdsdh.Where(s =>
                            s.md_sanpham_id == cddh.md_sanpham_id &
                            s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id)
                            .Select(s => s.md_sanpham_bom_id).FirstOrDefault();

                        //start tinh ton kho
                        var khohangtonCp = khohangton.Where(s => s.md_sanpham_id == cddh.md_sanpham_id).ToList();
                        decimal sl_ThanhPham = 0, sl_ThanhPham2 = 0;
                        foreach (var dong_khohangtonCp in khohangtonCp)
                        {
                            var slgc = db.md_kho_giucho.Where(s =>
                                            s.md_sanpham_id == dong_khohangtonCp.md_sanpham_id &
                                            s.md_kho_id == dong_khohangtonCp.md_kho_id &
                                            s.md_donvitinhsanpham_id == dong_khohangtonCp.md_donvitinhsanpham_id
                                            ).Select(s => s.soluong_giucho).Sum()
                                            .GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0);
                            sl_ThanhPham += dong_khohangtonCp.soluong.GetValueOrDefault(0) - slgc;
                            sl_ThanhPham2 += dong_khohangtonCp.soluong.GetValueOrDefault(0);

                        }


                        foreach (var sanpham in khohangtonCp)
                        {
                            bool issanpham = convert_bool(sanpham.sanpham);
                            //--Them moi dong ton kho
                            add_dongtonkho(db, cddh.c_doichieuhangton_id, sanpham.md_sanpham_id,
                            sanpham.md_donvitinhsanpham_id, sanpham.mota_tiengviet, sanpham.mota_tienganh,
                            sl_ThanhPham, sanpham.mota, issanpham, sanpham.md_sanpham_id, cddh.sl_dathang.Value,
                            1, sanpham.md_kho_id, sanpham.ten_kho, us,
                            cddh.sl_giamhanngach.GetValueOrDefault(0), sl_ThanhPham2);


                            //string bc = sanpham.ma_sanpham.Substring(9, 2);
                            //string start = sanpham.ma_sanpham.Substring(0, 9) + "S";
                            //string end = sanpham.ma_sanpham.Substring(11, 3);
                            //string boS = db.md_sanpham.Where(s =>
                            //    s.ma_sanpham.StartsWith(start)
                            //    & s.ma_sanpham.EndsWith(end))
                            //    .Select(s => s.ma_sanpham).FirstOrDefault();
                            //boS = !string.IsNullOrEmpty(boS) ? boS.Substring(9, 2) : "";
                            //var boSele = db.md_bo.Where(s => s.ma_bo == bc & s.ma_bo_cha == boS).FirstOrDefault();

                            //foreach (var bodt in db.md_bo_chitiet.Where(s => s.md_bo_id == boSele.md_bo_id).ToList())
                            //{
                            //    string ma_spdetail = sanpham.ma_sanpham.Replace(bc, bodt.md_bo_detail);
                            //    var sp = db.md_sanpham.FirstOrDefault(s => s.ma_sanpham == ma_spdetail);
                            //    if (sp != null)
                            //    {
                            //        var sl = khohangton.Where(s => s.md_sanpham_id == sp.md_sanpham_id).Select(s => s.soluong).Sum();
                            //        add_dongtonkho(db, cddh.c_doichieuhangton_id, sp.md_sanpham_id,
                            //        sp.md_donvitinhsanpham_id, sp.mota_tiengviet, sp.mota_tienganh,
                            //        sl.GetValueOrDefault(0), sanpham.mota, sp.sanpham.GetValueOrDefault(false),
                            //        sp.md_sanpham_id,
                            //        0,
                            //        1,
                            //        sanpham.md_kho_id,
                            //        sanpham.ten_kho,
                            //        us,
                            //        cddh.sl_giamhanngach.GetValueOrDefault(0),
                            //        sl.GetValueOrDefault(0));
                            //    }
                            //}
                        }

                        //Neu hang hoa ko co trog kho hoac it hon so luong dat hang thi tach BOM
                        decimal slkho_tru_dathang = sl_ThanhPham - cddh.sl_dathang.Value;
                        find_BOM(db, cddh, us, cddh.md_sanpham_id, spBomId);
                        //end tinh ton kho

                        //start tinh du kien dat hang
                        add_dongdukiendathang(db, cddh.c_doichieuhangton_id, cddh.md_sanpham_id,
                            cddh.md_sanpham_id, cddh.sl_dathang.Value,
                            cddh.sl_dathang.Value, cddh.sl_giamhanngach.GetValueOrDefault(0), 1, us);
                        //end tinh du kien dat hang

                        //start tinh ton kho kieu dang
                        string ma_sanpham = db.md_sanpham.Where(s => s.md_sanpham_id == cddh.md_sanpham_id).Select(s => s.ma_sanpham.Substring(0, 8)).Take(1).FirstOrDefault();
                        string trangthai_tkkd = "Không";
                        int sl_tkkd = khohangton.Where(s => s.ma_sanpham.Contains(ma_sanpham)).Count();
                        if (sl_tkkd > 0)
                        {
                            trangthai_tkkd = "Có";
                        }
                        add_tonkhokieudang(db, cddh.c_doichieuhangton_id, ma_sanpham, trangthai_tkkd, us);
                        //end tinh ton kho kieu dang
                    }

                    //start tinh du kien lay hang ton
                    foreach (var dcht_tk in db.c_doichieuhangton_tk.Where(s =>
                        s.c_doichieuhangton_id == dcht1.c_doichieuhangton_id).ToList())
                    {
                        decimal sllay = dcht_tk.sl_conlai.Value - dcht_tk.sl_dathang.Value;

                        if (sllay < 0)
                            sllay = dcht_tk.sl_conlai.Value;
                        else
                            sllay = dcht_tk.sl_dathang.Value;

                        //--Them moi dong du lien lay  hang ton
                        var dklht = new c_doichieuhangton_dklht
                        {
                            c_doichieuhangton_dklht_id = Helper.getNewId(),
                            c_doichieuhangton_id = dcht_tk.c_doichieuhangton_id,
                            md_sanpham_id = dcht_tk.md_sanpham_id,
                            md_donvitinhsanpham_id = dcht_tk.md_donvitinhsanpham_id,
                            sl_conlai = dcht_tk.sl_conlai,
                            mota_tiengviet = dcht_tk.mota_tiengviet,
                            mota_tienganh = dcht_tk.mota_tienganh,
                            mota = dcht_tk.mota,
                            macuoi = dcht_tk.macuoi,
                            macuoi_id = dcht_tk.macuoi_id,
                            makho = dcht_tk.makho,
                            md_kho_id = dcht_tk.md_kho_id,
                            issanpham = dcht_tk.sanpham,
                            sl_dalay = 0,
                            sl_lay = sllay - dcht_tk.sl_giamhanngach.GetValueOrDefault(0),

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
                            hoatdong = true
                        };
                        db.c_doichieuhangton_dklht.Add(dklht);
                        //--Cap nhat du kien dat hang
                        foreach (var dkdh in db.c_doichieuhangton_dkdh.Where(s => s.c_doichieuhangton_id == dcht_tk.c_doichieuhangton_id & s.md_sanpham_id == dcht_tk.md_sanpham_id).ToList())
                        {
                            dkdh.sl_conlai = (sllay - dkdh.sl_giamhanngach.GetValueOrDefault(0)).Set0WhenlessThan0();
                        }
                    }
                    db.SaveChanges();

                    //end tinh du kien lay hang ton	

                    //--Cap nhat du kien dat hang
                    var c_doichieuhangton_dkdh = db.c_doichieuhangton_dkdh.
                            Where(s => s.c_doichieuhangton_id == dcht1.c_doichieuhangton_id);
                    foreach (var dkdh in c_doichieuhangton_dkdh.ToList())
                    {
                        if (dkdh.sl_dathang.Value > 0)
                        {
                            dkdh.sl_dathang = dkdh.sl_dathang_cp.Value;
                        }

                        decimal sl_dat = (dkdh.sl_dathang_cp.Value - dkdh.sl_conlai.Value - dkdh.sl_giamhanngach.GetValueOrDefault(0)).Set0WhenlessThan0().Value;
                        decimal sl_dathang_cp = dkdh.sl_dathang_cp.Value;
                        string[] arr_macuoi = dkdh.macuoi_id.Replace(dkdh.md_sanpham_id, "").Split(',');
                        //foreach (c_doichieuhangton_dkdh dkdh_ in c_doichieuhangton_dkdh.Where(s => arr_macuoi.Contains(s.md_sanpham_id)).ToList())
                        //{
                        //sl_dat = sl_dat - dkdh_.sl_conlai.Value;
                        //sl_dathang_cp = sl_dathang_cp - dkdh_.sl_conlai.Value;
                        //}
                        dkdh.sl_dathang_cp = sl_dathang_cp;
                        dkdh.sl_dat = sl_dat;
                    }

                    foreach (var dcht in db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == dcht1.c_doichieuhangton_id).ToList())
                    {
                        dcht.doichieuht = true;
                    }
                    db.SaveChanges();

                    foreach (var tkCai in db.c_doichieuhangton_tk.Where(s =>
                     s.c_doichieuhangton_id == dcht1.c_doichieuhangton_id).ToList())
                    {
                        var sanpham = db.md_sanpham.Where(s => s.md_sanpham_id == tkCai.md_sanpham_id).FirstOrDefault();
                        if (sanpham != null)
                        {
                            string bc = sanpham.ma_sanpham.Substring(9, 2);
                            string start = sanpham.ma_sanpham.Substring(0, 9) + "S";
                            string end = sanpham.ma_sanpham.Substring(11, 3);
                            string boS = db.md_sanpham.Where(s =>
                                s.ma_sanpham.StartsWith(start)
                                & s.ma_sanpham.EndsWith(end))
                                .Select(s => s.ma_sanpham).FirstOrDefault();
                            boS = !string.IsNullOrEmpty(boS) ? boS.Substring(9, 2) : "";
                            string boSeleId = db.md_bo.Where(s => s.ma_bo == bc & s.ma_bo_cha == boS).Select(s=>s.md_bo_id).FirstOrDefault();

                            foreach (var bodt in db.md_bo_chitiet.Where(s => s.md_bo_id == boSeleId).ToList())
                            {
                                string ma_spdetail = sanpham.ma_sanpham.Replace(bc, bodt.md_bo_detail);
                                var sp = db.md_sanpham.FirstOrDefault(s => s.ma_sanpham == ma_spdetail);
                                if (sp != null)
                                {
                                    var sl = khohangton.Where(s => s.md_sanpham_id == sp.md_sanpham_id).Select(s => s.soluong).Sum();
                                    add_dongtonkho(db, dcht1.c_doichieuhangton_id, sp.md_sanpham_id,
                                    sp.md_donvitinhsanpham_id, sp.mota_tiengviet, sp.mota_tienganh,
                                    sl.GetValueOrDefault(0), sanpham.mota, sp.sanpham.GetValueOrDefault(false),
                                    sanpham.md_sanpham_id,
                                    0,
                                    1,
                                    "",
                                    "",
                                    us,
                                    0,
                                    sl.GetValueOrDefault(0));
                                }
                            }
                        }
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
    //--
    public bool convert_bool(object a)
    {
        bool issanpham = true;
        if (a == null)
        {
            issanpham = false;
        }
        else
        {
            issanpham = (bool)a;
        }
        return issanpham;
    }
    //Tim cac dong bom lam ra san pham
    public string find_BOM(EntityContext db, c_doichieuhangton_cddh cddh, User_TK us, string md_sanpham_id, string spBomId)
    {
        //San pham trong bom 
        var dong_bom = (from b in db.md_sanpham_bom_vattu
                        join d in db.md_sanpham on b.md_sanpham_id equals d.md_sanpham_id
                        where b.md_sanpham_bom_id == spBomId
                        & d.vattu != true
                        select new
                        {
                            id_sanpham = d.md_sanpham_id,
                            b.md_sanpham_id,
                            b.soluong,
                            d.md_donvitinhsanpham_id,
                            d.mota_tiengviet,
                            d.mota_tienganh,
                            d.mota,
                            d.ma_sanpham,
                            d.sanpham
                        }).ToList();

        var khohangton = from a in db.md_kho
                         join b in db.md_kho_sanpham on a.md_kho_id equals b.md_kho_id
                         join c in db.md_sanpham on b.md_sanpham_id equals c.md_sanpham_id
                         where a.hangton == true
                         select
                             new
                             {
                                 a.md_kho_id,
                                 a.ten_kho,
                                 b.md_sanpham_id,
                                 c.md_donvitinhsanpham_id,
                                 c.mota_tiengviet,
                                 c.mota_tienganh,
                                 b.soluong,
                                 c.mota,
                                 c.sanpham
                             };


        foreach (var dongbomcon in dong_bom)
        {
            //San pham trong kho ton
            var khohangtonBTP = khohangton.Where(s => s.md_sanpham_id == dongbomcon.md_sanpham_id);
            int count_dongkho = khohangtonBTP.Count();
            string md_kho_id = "", ma_kho = "";
            decimal sl_BanThanhPham = 0;
            if (count_dongkho > 1)
            {
                foreach (var dong_khohangtonBTP in khohangtonBTP)
                {
                    sl_BanThanhPham += (decimal)dong_khohangtonBTP.soluong;
                    if (md_kho_id == "")
                    {
                        md_kho_id = dong_khohangtonBTP.md_kho_id;
                        ma_kho = dong_khohangtonBTP.ten_kho;
                    }
                    else
                    {
                        md_kho_id = md_kho_id + "," + dong_khohangtonBTP.md_kho_id;
                        ma_kho = ma_kho + "<br>" + dong_khohangtonBTP.ten_kho;
                    }
                }
            }
            else if (count_dongkho == 1)
            {
                var dongkhohangtonBTP = khohangtonBTP.FirstOrDefault();
                sl_BanThanhPham = (decimal)dongkhohangtonBTP.soluong;
                md_kho_id = dongkhohangtonBTP.md_kho_id;
                ma_kho = dongkhohangtonBTP.ten_kho;
            }
            //--Them moi dong Ton Kho
            bool issanpham = convert_bool(dongbomcon.sanpham);
            if (sl_BanThanhPham > 0)
            {
                add_dongtonkho(db, cddh.c_doichieuhangton_id, dongbomcon.md_sanpham_id,
                dongbomcon.md_donvitinhsanpham_id, dongbomcon.mota_tiengviet,
                dongbomcon.mota_tienganh, sl_BanThanhPham, dongbomcon.mota,
                issanpham, dongbomcon.id_sanpham, cddh.sl_dathang.Value, dongbomcon.soluong.Value,
                md_kho_id, ma_kho, us, cddh.sl_giamhanngach.GetValueOrDefault(0), sl_BanThanhPham);
            }
            //--Them moi dong Du kien dat hang
            add_dongdukiendathang(db, cddh.c_doichieuhangton_id, dongbomcon.md_sanpham_id, dongbomcon.id_sanpham, 0,
                cddh.sl_dathang.Value, cddh.sl_giamhanngach.GetValueOrDefault(0), dongbomcon.soluong.Value, us);
            find_BOM(db, cddh, us, dongbomcon.md_sanpham_id, spBomId);
        }
        return "vnn";
    }
    //Xoa cac du lieu lien quan den doi chieu hang ton de doi chieu lai 
    public void del_doichieuhangton(EntityContext db, string[] c_doichieuhangton_id)
    {

        for (int i = 0; i < c_doichieuhangton_id.Length; i++)
        {
            string doichieuhangton_id = c_doichieuhangton_id[i];
            db.c_doichieuhangton_tk.RemoveRange(db.c_doichieuhangton_tk.Where(s => s.c_doichieuhangton_id == doichieuhangton_id).ToList());

            db.c_doichieuhangton_dklht.RemoveRange(db.c_doichieuhangton_dklht.Where(s => s.c_doichieuhangton_id == doichieuhangton_id).ToList());

            db.c_doichieuhangton_dkdh.RemoveRange(db.c_doichieuhangton_dkdh.Where(s => s.c_doichieuhangton_id == doichieuhangton_id).ToList());
        }
        db.SaveChanges();

    }
    //Them dong trong du kien dat hang
    public string add_dongdukiendathang(EntityContext db, string c_doichieuhangton_id, string md_sanpham_id,
        string macuoi, decimal sl_dathang, decimal sl_dathang_cp, decimal sl_giamhanngach, double soluong, User_TK us)
    {
        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == md_sanpham_id).Take(1).FirstOrDefault();
        string ma_sanpham = db.md_sanpham.Where(s => s.md_sanpham_id == macuoi).Select(s => s.ma_sanpham).Take(1).FirstOrDefault();
        string id_new = Helper.getNewId();
        c_doichieuhangton_dkdh check_ma = db.c_doichieuhangton_dkdh.Where(s => s.md_sanpham_id == md_sanpham_id & s.c_doichieuhangton_id == c_doichieuhangton_id).FirstOrDefault();
        c_doichieuhangton_dkdh dkdh = check_ma;
        if (dkdh == null)
        {
            dkdh = new c_doichieuhangton_dkdh();
            dkdh.c_doichieuhangton_dkdh_id = id_new;
            dkdh.macuoi = ma_sanpham;
            dkdh.macuoi_id = macuoi;
            dkdh.sl_dathang_cp = sl_dathang_cp * (decimal)soluong;
        }
        else
        {
            id_new = dkdh.c_doichieuhangton_dkdh_id;
            if (!dkdh.macuoi.Contains(ma_sanpham))
            {
                dkdh.macuoi = dkdh.macuoi + "<br>" + ma_sanpham;
                dkdh.macuoi_id = dkdh.macuoi_id + "," + macuoi;
            }
            dkdh.sl_dathang_cp = dkdh.sl_dathang_cp + (sl_dathang_cp * (decimal)soluong);
        }

        dkdh.c_doichieuhangton_id = c_doichieuhangton_id;
        dkdh.md_sanpham_id = md_sanpham_id;
        dkdh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
        dkdh.sl_dat = sl_dathang_cp.Set0WhenlessThan0();
        dkdh.sl_giamhanngach = sl_giamhanngach;
        dkdh.sl_conlai = 0;
        dkdh.sl_dathang = sl_dathang;
        dkdh.issanpham = sp.sanpham;
        dkdh.mota = sp.mota;
        dkdh.nguoitao = us.ad_user_id;
        dkdh.vaitrotao = us.ad_role_id;
        dkdh.bophantao = us.md_phongban_id;
        dkdh.value_nguoitao = us.ma_user;
        dkdh.value_vaitrotao = us.ten_role;
        dkdh.value_bophantao = us.ten_phongban;
        dkdh.nguoicapnhat = us.ad_user_id;
        dkdh.vaitrocapnhat = us.ad_role_id;
        dkdh.bophancapnhat = us.md_phongban_id;
        dkdh.value_nguoicapnhat = us.ma_user;
        dkdh.value_vaitrocapnhat = us.ten_role;
        dkdh.value_bophancapnhat = us.ten_phongban;
        dkdh.hoatdong = true;

        if (check_ma == null)
        {
            dkdh.ngaytao = DateTime.Now;
            dkdh.ngaycapnhat = DateTime.Now;
            db.c_doichieuhangton_dkdh.Add(dkdh);
        }
        else
        {
            dkdh.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();

        return id_new;
    }
    //Them ton kho kieu dang
    public string add_tonkhokieudang(EntityContext db, string c_doichieuhangton_id, string ma_sanpham, string trangthai_tkkd, User_TK us)
    {

        string id_new = Helper.getNewId();
        c_doichieuhangton_tkkd check_ma = db.c_doichieuhangton_tkkd.Where(s => s.md_sanpham_id == ma_sanpham & s.c_doichieuhangton_id == c_doichieuhangton_id).FirstOrDefault();
        c_doichieuhangton_tkkd tkkd = check_ma;
        if (tkkd == null)
        {
            tkkd = new c_doichieuhangton_tkkd();
            tkkd.c_doichieuhangton_tkkd_id = id_new;
        }
        else
        {
            id_new = tkkd.c_doichieuhangton_tkkd_id;
        }
        tkkd.c_doichieuhangton_id = c_doichieuhangton_id;
        tkkd.md_sanpham_id = ma_sanpham;
        tkkd.trangthai = trangthai_tkkd;
        tkkd.kieudang = ma_sanpham;
        tkkd.mota = "";
        tkkd.nguoitao = us.ad_user_id;
        tkkd.vaitrotao = us.ad_role_id;
        tkkd.bophantao = us.md_phongban_id;
        tkkd.value_nguoitao = us.ma_user;
        tkkd.value_vaitrotao = us.ten_role;
        tkkd.value_bophantao = us.ten_phongban;
        tkkd.nguoicapnhat = us.ad_user_id;
        tkkd.vaitrocapnhat = us.ad_role_id;
        tkkd.bophancapnhat = us.md_phongban_id;
        tkkd.value_nguoicapnhat = us.ma_user;
        tkkd.value_vaitrocapnhat = us.ten_role;
        tkkd.value_bophancapnhat = us.ten_phongban;
        tkkd.hoatdong = true;

        if (check_ma == null)
        {
            tkkd.ngaytao = DateTime.Now;
            tkkd.ngaycapnhat = DateTime.Now;
            db.c_doichieuhangton_tkkd.Add(tkkd);
        }
        else
        {
            tkkd.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();

        return id_new;
    }
    //Them dong trong ton kho
    public string add_dongtonkho(EntityContext db, string c_doichieuhangton_id, string md_sanpham_id,
        string md_donvitinhsanpham_id, string mota_tiengviet, string mota_tienganh, decimal soluong, string mota,
        bool sanpham, string macuoi, decimal sl_dathang, double soluong_bom, string md_kho_id, string makho, User_TK us,
        decimal sl_giamhanngach, decimal sl_trongkho)
    {

        string ma_sanpham = db.md_sanpham.Where(s => s.md_sanpham_id == macuoi).Select(s => s.ma_sanpham).Take(1).FirstOrDefault();
        string id_new = Helper.getNewId();
        c_doichieuhangton_tk check_ma = db.c_doichieuhangton_tk.Where(s => s.md_sanpham_id == md_sanpham_id & s.c_doichieuhangton_id == c_doichieuhangton_id).FirstOrDefault();
        c_doichieuhangton_tk tkho = check_ma;
        if (tkho == null)
        {
            tkho = new c_doichieuhangton_tk();
            tkho.c_doichieuhangton_tk_id = id_new;
            tkho.macuoi = ma_sanpham;
            tkho.macuoi_id = macuoi;
            tkho.sl_dathang = (sl_dathang * (decimal)soluong_bom);
            tkho.sl_giamhanngach = sl_giamhanngach;
            tkho.makho = makho;
            tkho.md_kho_id = md_kho_id;
        }
        else
        {
            tkho.sl_dathang += sl_dathang;
            id_new = tkho.c_doichieuhangton_tk_id;
            if (!tkho.macuoi_id.Contains(macuoi))
            {
                tkho.macuoi = tkho.macuoi + "<br>" + ma_sanpham;
                tkho.macuoi_id = tkho.macuoi_id + "," + macuoi;
            }

            if (!tkho.md_kho_id.Contains(md_kho_id))
            {
                tkho.makho = tkho.makho + "<br>" + makho;
                tkho.md_kho_id = tkho.md_kho_id + "," + md_kho_id;
            }
        }
        tkho.c_doichieuhangton_id = c_doichieuhangton_id;
        tkho.md_sanpham_id = md_sanpham_id;
        tkho.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
        tkho.mota_tiengviet = mota_tiengviet;
        tkho.mota_tienganh = mota_tienganh;
        tkho.sl_conlai = soluong;
        tkho.sl_trongkho = sl_trongkho;
        tkho.sl_giucho = tkho.sl_trongkho - tkho.sl_conlai;
        tkho.sanpham = sanpham;
        tkho.mota = mota;
        tkho.nguoitao = us.ad_user_id;
        tkho.vaitrotao = us.ad_role_id;
        tkho.bophantao = us.md_phongban_id;
        tkho.value_nguoitao = us.ma_user;
        tkho.value_vaitrotao = us.ten_role;
        tkho.value_bophantao = us.ten_phongban;
        tkho.nguoicapnhat = us.ad_user_id;
        tkho.vaitrocapnhat = us.ad_role_id;
        tkho.bophancapnhat = us.md_phongban_id;
        tkho.value_nguoicapnhat = us.ma_user;
        tkho.value_vaitrocapnhat = us.ten_role;
        tkho.value_bophancapnhat = us.ten_phongban;
        tkho.hoatdong = true;

        if (check_ma == null)
        {
            tkho.ngaytao = DateTime.Now;
            tkho.ngaycapnhat = DateTime.Now;
            db.c_doichieuhangton_tk.Add(tkho);
        }
        else
        {
            tkho.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();

        return id_new;
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id_parent = context.Request.Form["id_parent"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_doichieuhangton";
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
            string id_parent = context.Request.Form["id_parent"];
            string object_ = db.c_doichieuhangton.Where(p => p.c_doichieuhangton_id.Equals(context.Request.Form["id"])).Select(s => s.c_doichieuhangton_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_doichieuhangton";
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
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                int count = context.Request.Form["id"].Split(',').Count();
                string[] id_del = new string[count];
                id_del = context.Request.Form["id"].Split(',');
                for (int i = 0; i < count; i++)
                {
                    msg_del = ""; var id_del_ = id_del[i];
                    var object_ = db.c_doichieuhangton.Where(p => p.c_doichieuhangton_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg_del = "Lỗi dòng " + i + ": Không tìm thấy đối tượng cần xóa.";
                        msg += msg_del + "\n";
                    }
                    else if (object_.kehoach != null & object_.kehoach != "" & object_.kehoach != " ")
                    {
                        msg_del = "Lỗi dòng: " + i + ": Đã lập kế hoạch đặt hàng, không thể xóa.";
                        msg += msg_del + "\n";
                    }
                    else if (object_.phieuhangton != null & object_.phieuhangton != "" & object_.phieuhangton != " ")
                    {
                        msg_del = "Lỗi dòng: " + i + ": Đã lập phiếu lấy hàng tồn, không thể xóa.";
                        msg += msg_del + "\n";
                    }

                    if (msg_del.Length <= 0)
                    {
                        var dsdh = db.c_danhsachdathang.
                                Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Take(1).FirstOrDefault();
                        dsdh.md_trangthai_id = "HIEULUC";
                        db.c_doichieuhangton.Remove(object_);
                        db.SaveChanges();
                        dsdh.trangthai = "SOANTHAO";

                        foreach (var nangluc in db.c_danhsachdathang_nangluc.
                                Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).ToList())
                        {
                            var dongNL = db.md_nangluc.
                                    Where(s => s.nam == nangluc.thoigianyeucau.Value.Year & s.tuan == nangluc.tuanthu & s.hehang == nangluc.dauma).FirstOrDefault();
                            if (dongNL != null)
                            {
                                dongNL.soluongdadat -= (decimal)nangluc.CBMdatduoc.GetValueOrDefault(0);
                                dongNL.soluongconlai = dongNL.nangsuat - dongNL.soluongdadat;
                            }
                            db.c_danhsachdathang_nangluc.Remove(nangluc);
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "false#Lỗi: " + ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#");
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"false#{0}", msg);
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