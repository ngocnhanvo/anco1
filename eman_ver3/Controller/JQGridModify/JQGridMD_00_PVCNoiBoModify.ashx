<%@ WebHandler Language="C#" Class="JQGridMD_00_PVCNoiBoModify" %>
using System;
using System.Web;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_PVCNoiBoModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XuLyVanChuyen":
                this.CA_01_XuLyVanChuyen(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XuLyVanChuyen(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));

        string msg = "", msg_fail = "";
        string ma_module = context.Request.QueryString["ma_module"];

        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');

        if (vnn.Count() < -1)
        {
            msg = "<div style='color:red'>Lỗi:Chỉ được chọn 1 phiếu vận chuyển.</div>";
        }
        else
        {
            foreach (var vcnb in db.md_vanchuyennoibo.Where(s => vnn.Contains(s.md_vanchuyennoibo_id)).ToList())
            {
                if (vcnb.md_trangthai_id == "HIEULUC")
                {
                    msg = "<div style='color:red'>Lỗi: dòng \"" + vcnb.sochungtu + "\" đã hiệu lực.</div>";
                    break;
                }

                var vcnb_cdvcs = db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id);
                int tong_sl_dachuyenhet = vcnb_cdvcs.Where(s => s.dachuyenhet == true).Count();
                foreach (var vcnb_cdvc in vcnb_cdvcs.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id).OrderBy(s => s.denkho).ToList())
                {
                    /*if (vcnb_cdvc.denkho != vcnb.denkho)
					if(1 == 1)                    
					{
						md_kho kho = db.md_kho.Where(s=>s.md_kho_id == vcnb_cdvc.denkho).Take(1).FirstOrDefault();
                        string ten_sp = db.md_sanpham.Where(s => s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).Select(s => s.ma_sanpham).FirstOrDefault();
                        msg += "<div style='color:red'>Lỗi: dòng \"" + ten_sp + "\" phải chuyển đến \""+ kho.ten_kho +"\".</div>";
						break;
                    }*/
                    //start Xuat kho
                    string[] arr_tukho = vcnb.tukho.Split(',');
                    decimal sl_kho_thucte = 0, sl_dichchuyen_thucte = vcnb_cdvc.soluong_dichchuyen.Value;
                    //xuất kho
                    foreach (md_kho_sanpham kho_sp in db.md_kho_sanpham.Where(s => arr_tukho.Contains(s.md_kho_id) & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id))
                    {
                        decimal sl_kho_sp = (decimal)kho_sp.soluong.Value;
                        sl_kho_thucte += sl_kho_sp;
                        decimal sl_xuatkho = sl_dichchuyen_thucte;
                        if (sl_kho_sp <= sl_dichchuyen_thucte)
                        {
                            sl_dichchuyen_thucte = sl_dichchuyen_thucte - sl_kho_sp;
                            sl_xuatkho = sl_kho_sp;
                        }

                        if (sl_xuatkho > 0)
                        {
                            //Lisch su xuat kho
                            md_kho_giaodich kho_gd = new md_kho_giaodich
                            {
                                md_kho_giaodich_id = Helper.getNewId(),
                                md_kho_id = kho_sp.md_kho_id,
                                md_sanpham_id = kho_sp.md_sanpham_id,
                                soluong_dichchuyen = sl_xuatkho,
                                ngaychuyen = vcnb.ngaychuyen.Value,
                                kieuchuyen = "Xuất kho",
                                dongnhapxuat = " ",
                                dongkiemkho = " ",
                                dongvanchuyen = vcnb.sochungtu,
                                dongsanxuat = " ",
                                md_donvitinhsanpham_id = vcnb_cdvc.md_donvitinhsanpham_id,
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
                            db.md_kho_giaodich.Add(kho_gd);
                        }
                        //Cap nhat lai kho_gd
                        kho_sp.soluong = kho_sp.soluong.Value - sl_xuatkho;
                        //Neu so luong da dap ung du thi ko xet tiep
                        if (sl_kho_thucte >= vcnb_cdvc.soluong_dichchuyen.Value)
                            break;
                    }
                    //end Xuat kho
                    if (sl_kho_thucte < vcnb_cdvc.soluong_dichchuyen.Value)
                    {
                        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).Take(1).FirstOrDefault();
                        msg = "<div style='color:red'>Lỗi: dòng \"" + sp.ma_sanpham + "\" số lượng trong kho chỉ còn : " + VNN_VariablePublic.autoRound(sl_kho_thucte, 4) + ".</div>";
                        break;
                    }
                    else {
                        //Nhap Kho
                        md_kho_sanpham kho_sp_nhapkho = db.md_kho_sanpham.Where(s => s.md_kho_id == vcnb.denkho & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).Take(1).FirstOrDefault();
                        if (kho_sp_nhapkho == null)
                        {
                            kho_sp_nhapkho = new md_kho_sanpham
                            {
                                md_kho_sanpham_id = Helper.getNewId(),
                                md_kho_id = vcnb.denkho,
                                md_sanpham_id = vcnb_cdvc.md_sanpham_id,
                                soluong = vcnb_cdvc.soluong_dichchuyen.Value,
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
                            db.md_kho_sanpham.Add(kho_sp_nhapkho);
                        }
                        else
                        {
                            kho_sp_nhapkho.soluong += vcnb_cdvc.soluong_dichchuyen.Value;
                        }
                        //Lich su kho
                        md_kho_giaodich kho_gd_nhapkho = new md_kho_giaodich
                        {
                            md_kho_giaodich_id = Helper.getNewId(),
                            md_kho_id = vcnb.denkho,
                            md_sanpham_id = vcnb_cdvc.md_sanpham_id,
                            soluong_dichchuyen = vcnb_cdvc.soluong_dichchuyen.Value,
                            ngaychuyen = vcnb.ngaychuyen.Value,
                            kieuchuyen = "Nhập kho",
                            dongnhapxuat = " ",
                            dongkiemkho = " ",
                            dongvanchuyen = vcnb.sochungtu,
                            dongsanxuat = " ",
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
                        db.md_kho_giaodich.Add(kho_gd_nhapkho);
                        //end Nhap kho

                        //Start Cap nhat don van chuyen
                        vcnb_cdvc.soluong_dachuyen = vcnb_cdvc.soluong_dichchuyen;
                        vcnb_cdvc.soluong_dichchuyen = 0;
                        vcnb.md_trangthai_id = "HIEULUC";
                        //End Cap nhat don van chuyen
                    }
                }
                if (msg != "")
                {
                    break;
                }
                //-----
                foreach (var cdvc in db.md_vanchuyennoibo_cdvc.
                                        Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id).ToList())
                {
                    //Cap nhat du kien lay hang ton
                    foreach (var dklht in
                            db.c_doichieuhangton_dklht.
                                Where(s => s.c_doichieuhangton_id == vcnb.c_doichieuhangton_id &
                                s.md_sanpham_id == cdvc.md_sanpham_id).ToList())
                    {
                        dklht.sl_dalay = dklht.sl_dalay + cdvc.soluong_dachuyen;
                    }
                    //Cap nhat lai cac dong van chuyen
                    foreach (var check_xk in
                            db.md_vanchuyennoibo.Where(s =>
                                s.md_vanchuyennoibo_id != vcnb.md_vanchuyennoibo_id &
                                s.c_doichieuhangton_id == vcnb.c_doichieuhangton_id &
                                s.tukho == vcnb.tukho &
                                s.md_trangthai_id == "SOANTHAO").ToList())
                    {
                        foreach (var ck_dh in
                                db.md_vanchuyennoibo_cdvc.Where(s =>
                                    s.md_vanchuyennoibo_id == check_xk.md_vanchuyennoibo_id &
                                    s.md_sanpham_id == cdvc.md_sanpham_id).ToList())
                        {
                            ck_dh.soluong_toida = ck_dh.soluong_toida - cdvc.soluong_dachuyen;
                        }
                    }
                }
            }
        }
        if (msg == "")
        {
            db.SaveChanges();
            msg = "<div style='color:blue'>Vận chuyển hàng hóa thành công.</div>";
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);

        string loaichuyen = context.Request.Form["loaichuyen"];
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];
        string loaichuyen_id = "";
        string sctdathang = context.Request.Form["sctdathang"];
        int a = 0, count = 0;
        string chungtuthamchieu = context.Request["chungtuthamchieu"];
        try
        {
            var ko = db.md_kho.Where(s => s.md_kho_id == tukho).FirstOrDefault();
            var check_cdh1 = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == loaichuyen_id);
            var check_cdh2 = db.md_xuatban_cdh.Where(s => s.md_xuatban_id == loaichuyen_id);
            if (loaichuyen == "XUATNB")
            {
                var xnb = db.md_xuatkhonb.Where(s => s.sochungtu == chungtuthamchieu & s.tukho == denkho).FirstOrDefault();
                loaichuyen_id = xnb.md_xuatkhonb_id;
                sctdathang = xnb.sctdathang;
                if (check_cdh1.Count() <= 0)
                {
                    msg = "false#Lỗi: Dòng " + chungtuthamchieu + " chưa có các dòng hàng.";
                }
                foreach (md_xuatkhonb_cdh cdh in check_cdh1.ToList())
                {
                    count = db.md_kho_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.md_kho_id == tukho).Count();
                    if(count > 0)
                        break;
                }
                if (count <= 0)
                {
                    msg = "false#Lỗi : Các mã sản phẩm cửa " + chungtuthamchieu + " không có trong kho " + ko.ten_kho;
                }
                a = 1;
            }
            else if (loaichuyen == "XUATB")
            {
                md_xuatban xnb = db.md_xuatban.Where(s => s.sochungtu == chungtuthamchieu & s.tukho == denkho).FirstOrDefault();
                loaichuyen_id = xnb.md_xuatban_id;
                sctdathang = xnb.sctdathang;
                if (check_cdh2.Count() <= 0)
                {
                    msg = "false#Lỗi: Dòng " + chungtuthamchieu + " chưa có các dòng hàng.";
                }
                foreach (md_xuatban_cdh cdh in check_cdh2.ToList())
                {
                    count = db.md_kho_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.md_kho_id == tukho).Count();
                    if(count > 0)
                        break;
                }
                if (count <= 0)
                {
                    msg = "false#Lỗi : Các mã sản phẩm cửa " + chungtuthamchieu + " không có trong kho " + ko.ten_kho;
                }
                a = 2;
            }

            if (tukho == denkho)
            {
                msg = "false#Lỗi: Kho chuyển không được giống với kho đến";
            }

            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                if(loaichuyen == "VANCNB")
                {
                    /*c_doichieuhangton dcht = db.c_doichieuhangton.Where(s => s.so_donhang == sctdathang).FirstOrDefault();
					if (dcht.phieuhangton != null & dcht.phieuhangton != "" & dcht.phieuhangton != " ")
					{
						dcht.phieuhangton += "," + sochungtu;
					}
					else
					{dcht.phieuhangton = sochungtu;}
					VNN_Function.SetFormValue("c_doichieuhangton_id",dcht.c_doichieuhangton_id);*/
                }
                string action = "add";
                string[] column_ex = { "loaichuyen_id", "sctdathang" , "c_doichieuhangton_id"};
                string ten_table = "md_vanchuyennoibo";
                VNN_Function.SetFormValue("sctdathang", sctdathang);
                VNN_Function.SetFormValue("sochungtu", sochungtu);
                VNN_Function.SetFormValue("loaichuyen_id", loaichuyen_id);
                VNN_Function.SetFormValue("denkho", denkho);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);

                if(loaichuyen != "VANCNB")
                {
                    if (a == 1)
                    {
                        foreach (var xnb in check_cdh1.ToList())
                        {
                            int count_ = db.md_kho_sanpham.Where(s => s.md_sanpham_id == xnb.md_sanpham_id & s.md_kho_id == tukho).Count();
                            if(count_ > 0)
                                add_dongvanchuyen(db, xnb.md_sanpham_id, xnb.tong_sl_xuat.Value, us, id_new);
                        }
                    }
                    else if (a == 2)
                    {
                        foreach (var xb in check_cdh2.ToList())
                        {
                            int count_ = db.md_kho_sanpham.Where(s => s.md_sanpham_id == xb.md_sanpham_id & s.md_kho_id == tukho).Count();
                            if(count_ > 0)
                                add_dongvanchuyen(db, xb.md_sanpham_id, xb.tong_sl_xuat.Value, us, id_new);
                        }
                    }
                }
                else {
                    var dsdh = db.c_danhsachdathang.Where(s => s.sochungtu == sctdathang).Take(1).FirstOrDefault();
                    if (dsdh != null)
                    {
                        foreach (c_dongdsdh ddh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id))
                        {
                            if (ddh.sl_conlai.Value > 0)
                            {
                                add_dongvanchuyen(db, ddh.md_sanpham_id, ddh.sl_conlai.Value, us, id_new);
                            }
                        }
                    }
                }
            }

            if (msg.Length <= 0)
            {
                msg = "true#Thêm thành công." + "#" + id_new;
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void add_dongvanchuyen(EntityContext db, string md_sanpham_id, decimal tong_sl_xuat, User_TK us, string md_vanchuyennoibo_id) {
        md_vanchuyennoibo_cdvc cdvc = new md_vanchuyennoibo_cdvc();
        cdvc.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
        cdvc.md_vanchuyennoibo_id = md_vanchuyennoibo_id;
        cdvc.md_sanpham_id = md_sanpham_id;
        cdvc.soluong_toida = tong_sl_xuat;
        cdvc.soluong_dachuyen = 0;
        cdvc.soluong_dichchuyen = 0;
        cdvc.dachuyenhet = false;
        cdvc.nguoitao = us.ad_user_id;
        cdvc.vaitrotao = us.ad_role_id;
        cdvc.bophantao = us.md_phongban_id;
        cdvc.value_nguoitao = us.ma_user;
        cdvc.value_vaitrotao = us.ten_role;
        cdvc.value_bophantao = us.ten_phongban;

        cdvc.nguoicapnhat = us.ad_user_id;
        cdvc.vaitrocapnhat = us.ad_role_id;
        cdvc.bophancapnhat = us.md_phongban_id;
        cdvc.value_nguoicapnhat = us.ma_user;
        cdvc.value_vaitrocapnhat = us.ten_role;
        cdvc.value_bophancapnhat = us.ten_phongban;

        cdvc.ngaytao = DateTime.Now;
        cdvc.ngaycapnhat = DateTime.Now;
        cdvc.mota = "";
        cdvc.hoatdong = true;
        db.md_vanchuyennoibo_cdvc.Add(cdvc);
    }

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];

        try
        {
            string id = context.Request.Form["id"];
            md_vanchuyennoibo object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id).Take(1).FirstOrDefault();
            denkho = db.md_kho.Where(s => s.md_kho_id == denkho).Select(s => s.md_kho_id).FirstOrDefault();
            tukho = db.md_kho.Where(s => s.md_kho_id == tukho).Select(s => s.md_kho_id).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Dòng " + object_.sochungtu + " đã Hiệu lực";
            }
            else if (tukho == denkho)
            {
                msg = "false#Lỗi: Kho chuyển không được giống với kho đến";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_vanchuyennoibo";
                VNN_Function.SetFormValue("tukho", tukho);
                VNN_Function.SetFormValue("denkho", denkho);
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
            string ten_table = "md_vanchuyennoibo";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_vanchuyennoibo object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id_del_).Take(1).FirstOrDefault();
                c_doichieuhangton dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi: Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id != "SOANTHAO")
                {
                    msg_del = "Lỗi: Dòng \"" + object_.sochungtu + "\" đang xử lý hoặc đã hiệu lực, không thể xóa.";
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0) {
                    if(dcht != null) {
                        dcht.phieuhangton = dcht.phieuhangton.Replace(object_.sochungtu + ",", "");
                        dcht.phieuhangton = dcht.phieuhangton.Replace(object_.sochungtu, "");
                        if(dcht.phieuhangton == "") {
                            dcht.phieuhangton = " ";
                        }
                    }
                    db.md_vanchuyennoibo.Remove(object_);
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