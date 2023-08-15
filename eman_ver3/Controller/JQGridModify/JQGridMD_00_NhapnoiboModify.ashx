<%@ WebHandler Language="C#" Class="JQGridMD_00_NhapnoiboModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NhapnoiboModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public class maHHVT_SLThieu_LaBTP
    {
        public string maHH { get; set; }
        public string maVT { get; set; }
        public string donhang { get; set; }
        public string background { get; set; }
        public decimal SLCan { get; set; }
        public decimal SLCo { get; set; }
        public decimal SLThieu { get; set; }
        public bool LaBTP { get; set; }
    }

    public class NNNB
    {
        public string md_nhapkhonb_cdh_id { get; set; }
        public string ma_sanpham { get; set; }
        public string tenhang { get; set; }
        public string bomId { get; set; }
        public string cdhTsxLsxId { get; set; }
        public string md_sanpham_id { get; set; }
        public decimal? sl_nhap1 { get; set; }
        public decimal? sl_nhap2 { get; set; }
    }
    EntityContext db;
    EntityFunction entityFunc;
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
        {
            db = new EntityContext();
            entityFunc = new EntityFunction();
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
            userTK = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context), db);
        }

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
            case "CA_01_XacNhanPNKNB":
                this.CA_01_XacNhanPNKNB(context);
                break;
            case "CA_01_NhapKho":
                this.CA_01_NhapKho(context);
                break;
            default:
                break;
        }

        db.Dispose();
    }

    public void CA_01_XacNhanPNKNB(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void CA_01_NhapKho(HttpContext context)
    {
        string msg = "", msg_success = "", fmtErr = "<div style='color:red'>{0}</div>";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');

        try
        {
            var ngayKCS = VNN_Config.setDateTime(context.Request.Form["ngayKCS"]);
            if(!ngayKCS.IsDate())
            {
                msg = string.Format(fmtErr, string.Format(@"Lỗi: Ngày KCS có giá trị sai."));
                goto EndEventHandler;
            }

            string sochungtu = VNN_VariablePublic.sochungtu(db, "PNKNB", 1);
            //Xu Ly nhap kho
            var nk = db.md_nhapkhonb.Where(s => vnn.Contains(s.md_nhapkhonb_id)).FirstOrDefault();
            if (nk == null)
            {
                msg = string.Format(fmtErr, string.Format(@"Lỗi: Không tìm thấy phiếu nhập kho này."));
                goto EndEventHandler;
            }
            else if (nk.trangthai == Helper.HIEULUC)
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" đã hiệu lực.</div>", nk.sochungtu);
                goto EndEventHandler;
            }
            else if (nk.trangthai != Helper.DANHAN)
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" cần ở trạng thái ""Đã Xác Nhận"".</div>", nk.sochungtu);
                goto EndEventHandler;
            }
            else if (string.IsNullOrEmpty(nk.denkho))
            {
                msg = string.Format(fmtErr,string.Format(@"Dòng ""{0}"" chưa có kho hoặc phân xưởng đến.", nk.sochungtu));
                goto EndEventHandler;
            }

            var md_nhapkhonb_cdhs = (from a in db.md_nhapkhonb_cdh
                                     join d in db.md_sanpham on a.md_sanpham_id equals d.md_sanpham_id
                                     where a.md_nhapkhonb_id == nk.md_nhapkhonb_id & (a.sl_nhap ?? 0) > 0
                                     orderby a.tenhang, d.ma_sanpham
                                     select new NNNB
                                     {
                                         md_nhapkhonb_cdh_id = a.md_nhapkhonb_cdh_id,
                                         ma_sanpham = d.ma_sanpham,
                                         md_sanpham_id = d.md_sanpham_id,
                                         sl_nhap1 = a.sl_muonnhap,
                                         sl_nhap2 = a.sl_nhap,
                                         bomId = a.bomId,
                                         cdhTsxLsxId = a.cdhTsxLsxId,
                                         tenhang = a.tenhang
                                     })
                                    .ToList();

            if (md_nhapkhonb_cdhs.Sum(s => s.sl_nhap2.GetValueOrDefault(0)) <= 0)
            {
                msg = string.Format(fmtErr, string.Format(@"Lỗi: phải có ít nhất 1 dòng có số lượng KCS lớn hơn 0."));
                goto EndEventHandler;
            }

            var msgErrs = new List<maHHVT_SLThieu_LaBTP>();
            var vts = new List<md_lenhsanxuat_tosx_vattu>();
            foreach (var dh1 in md_nhapkhonb_cdhs.ToList())
            {
                var tsxId = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_cdh_id == dh1.cdhTsxLsxId).Select(s => s.md_lenhsanxuat_tosx_id).FirstOrDefault();

                var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == tsxId).FirstOrDefault();

                var bomSPs = db.md_lenhsanxuat_tosx_vattuBackup
                .Join(db.md_sanpham, a => a.vt, b => b.md_sanpham_id, (a, b) => new { a, b })
                .Where(s => s.a.md_lenhsanxuat_tosx_id == tsxId & s.a.sp == dh1.md_sanpham_id & (s.a.soluong ?? 0) > 0)
                .OrderBy(s => s.b.ma_sanpham)
                .ToList();

                foreach (var vtB in bomSPs)
                {
                    var slth1 = (decimal)vtB.a.soluong.GetValueOrDefault(0) * dh1.sl_nhap1.GetValueOrDefault(0);
                    var slth2 = (decimal)vtB.a.soluong.GetValueOrDefault(0) * dh1.sl_nhap2.GetValueOrDefault(0);

                    var vtServer = db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_lenhsanxuat_tosx_id == tsxId & s.md_sanpham_id == vtB.a.vt).FirstOrDefault();
                    var vt = db.md_lenhsanxuat_tosx_vattu.Local.Where(s => s.md_lenhsanxuat_tosx_id == tsxId & s.md_sanpham_id == vtB.a.vt).FirstOrDefault();

                    if (vt == null)
                    {
                        msg += string.Format(@"
                                    <div style='color:red;padding:4px;'>
                                        Lỗi: <span style='color: blue'>{0}</span> ({2}) cần vật tư <span style='color: blue'>{1}</span>.
                                    </div>", dh1.ma_sanpham, vtB.b.ma_sanpham, dh1.tenhang);
                    }
                    else
                    {
                        vt.sl_backup2 = vt.sl_backup2.GetValueOrDefault(0) + slth2;
                        vts.Add(vt);
                    }
                }

                var dh = db.md_nhapkhonb_cdh.FirstOrDefault(s => s.md_nhapkhonb_cdh_id == dh1.md_nhapkhonb_cdh_id);

                if (msg.Length <= 0 & dh.sl_nhap > 0 & msgErrs.Count <= 0)
                {
                    decimal sl_nhap = dh.sl_nhap.Value;
                    //--cap nhat so luong xuat
                    edit_nhap(db, dh, userTK);
                    //--cap nhat vao kho
                    string khospId = nhap_kho(db, dh, nk, 1, userTK);
                    //--tao lich su nhap kho
                    add_kho_ls(db, dh, nk, 1, userTK, tsx);
                    //--cap nhat lenh san xuat
                    if (sl_nhap > 0)
                    {
                        foreach (var lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.
                                Where(s =>
                                s.md_sanpham_id == dh1.md_sanpham_id &
                                s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList())
                        {
                            lsx_to_cdh.sl_dahoanthanh = lsx_to_cdh.sl_dahoanthanh.GetValueOrDefault(0) + sl_nhap;
                        }

                        var ck_dhSTs = db.md_nhapkhonb_cdh.Where(s =>
                            s.md_nhapkhonb_id != nk.md_nhapkhonb_id
                            & s.md_sanpham_id == dh.md_sanpham_id
                            & s.lsx_to == dh.lsx_to
                            & db.md_nhapkhonb.Where(t => t.md_nhapkhonb_id == s.md_nhapkhonb_id & t.trangthai == Helper.SOANTHAO).Count() > 0).ToList();
                        foreach (var ck_dh in ck_dhSTs)
                        {
                            var tsldSav = ck_dh.tong_sl_dat.GetValueOrDefault(0);
                            ck_dh.tong_sl_dat = (ck_dh.tong_sl_dat - dh.sl_danhap).GetValueOrDefault(0).Set0WhenlessThan0();
                            if(tsldSav != ck_dh.tong_sl_dat.GetValueOrDefault(0))
                                ck_dh.sl_nhap = 0;
                        }

                        //var ck_dhXNs = db.md_nhapkhonb_cdh.Where(s =>
                        //    s.md_nhapkhonb_id != nk.md_nhapkhonb_id
                        //    & s.md_sanpham_id == dh.md_sanpham_id
                        //    & s.lsx_to == dh.lsx_to
                        //    & db.md_nhapkhonb.Where(t => t.md_nhapkhonb_id == s.md_nhapkhonb_id & t.trangthai == Helper.DANHAN).Count() > 0).ToList();
                        //foreach (var ck_dh in ck_dhXNs)
                        //{
                        //    ck_dh.tong_sl_dat = ck_dh.sl_muonnhap;
                        //}

                        msg_success += string.Format(@"
                                <div style='color:blue'>
                                    Dòng ""{0}"" của ""{1}"" đã nhập kho thành công, số lượng nhập là: ""{2}""
                                </div>", nk.sochungtu, dh1.ma_sanpham, sl_nhap.DropTrailingZeros());
                    }
                }
            }

            //Kiem tra de chuyen thanh Hieu Luc
            if (msg.Length <= 0)
            {
                foreach(var vt in vts)
                {
                    vt.sl_backup = vt.sl_backup2;
                }
                msg = msg_success + msg;
                nk.trangthai = Helper.HIEULUC;
                nk.ngaychuyen = ngayKCS;
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = string.Format(@"<div style='color:red'>{0}</div>", ex.Message);
        }

    EndEventHandler:;
        context.Response.Write(msg);
    }
    //--cap nhat so luong xuat
    public string edit_nhap(EntityContext db, md_nhapkhonb_cdh dh, User_TK us)
    {
        string id_new = dh.md_nhapkhonb_id;
        decimal sl_danhap = dh.sl_danhap.Value + dh.sl_nhap.Value;
        if (dh.tong_sl_dat <= dh.sl_danhap + dh.sl_nhap)
        {
            sl_danhap = dh.tong_sl_dat.Value;
            dh.check_kho = true;
        }

        dh.sl_danhap = sl_danhap;
        dh.ngaycapnhat = DateTime.Now;
        return id_new;
    }

    //nhap kho
    public string nhap_kho(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        var spServer = db.md_kho_sanpham.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        var sp = db.md_kho_sanpham.Local.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        var add = sp == null;
        if (add)
        {
            sp = new md_kho_sanpham();
            sp.md_kho_sanpham_id = id_new;
            sp.soluong = (dh.sl_nhap * nhanvoi);
        }
        else
        {
            id_new = sp.md_kho_sanpham_id;
            sp.soluong += (dh.sl_nhap * nhanvoi);
        }
        sp.md_kho_id = nk.denkho;
        sp.md_sanpham_id = dh.md_sanpham_id;

        sp.nguoitao = us.ad_user_id;
        sp.vaitrotao = us.ad_role_id;
        sp.bophantao = us.md_phongban_id;
        sp.value_nguoitao = us.ma_user;
        sp.value_vaitrotao = us.ten_role;
        sp.value_bophantao = us.ten_phongban;
        sp.nguoicapnhat = us.ad_user_id;
        sp.vaitrocapnhat = us.ad_role_id;
        sp.bophancapnhat = us.md_phongban_id;
        sp.value_nguoicapnhat = us.ma_user;
        sp.value_vaitrocapnhat = us.ten_role;
        sp.value_bophancapnhat = us.ten_phongban;
        sp.hoatdong = true;

        //Kiem tra
        if (add)
        {
            sp.ngaytao = DateTime.Now;
            sp.ngaycapnhat = DateTime.Now;
            db.md_kho_sanpham.Add(sp);
        }
        else
        {
            sp.ngaycapnhat = DateTime.Now;
        }
        return id_new;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us, md_lenhsanxuat_tosx tsx)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = nk.denkho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_nhap * nhanvoi;
        giao.ngaychuyen = nk.ngaychuyen;
        giao.kieuchuyen = "Nhập kho";
        giao.dongnhapxuat = nk.sochungtu;
        giao.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;
        giao.mota = dh.tenhang;
        giao.md_to_id = nk.md_to_id;
        giao.sanxuat = 1;
        giao.lsx = dh.lsx_to.Substring(0, 13);
        giao.tosxId = tsx.md_lenhsanxuat_tosx_id;
        giao.nguoitao = us.ad_user_id;
        giao.vaitrotao = us.ad_role_id;
        giao.bophantao = us.md_phongban_id;
        giao.value_nguoitao = us.ma_user;
        giao.value_vaitrotao = us.ten_role;
        giao.value_bophantao = us.ten_phongban;
        giao.nguoicapnhat = us.ad_user_id;
        giao.vaitrocapnhat = us.ad_role_id;
        giao.bophancapnhat = us.md_phongban_id;
        giao.value_nguoicapnhat = us.ma_user;
        giao.value_vaitrocapnhat = us.ten_role;
        giao.value_bophancapnhat = us.ten_phongban;
        giao.hoatdong = true;
        giao.ngaytao = DateTime.Now;
        giao.ngaycapnhat = DateTime.Now;
        db.md_kho_giaodich.Add(giao);
        return "";
    }

    public void add(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string md_lenhsanxuat_id = context.Request.Form["md_lenhsanxuat_id"];
        string id = context.Request.Form["id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                var object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = @"Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg = @"Lỗi:Phiếu nhập kho đã ""Hiệu Lực""";
                }
                else if (ngaychuyen.IsDate() == false)
                {
                    msg = "Lỗi: Ngày nhập kho không đúng định dạng";
                }

                if (msg.Length <= 0)
                {
                    object_.ngaychuyen = ngaychuyen;
                    object_.mota = context.Request.Form["mota"];
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "true#Cập nhật thành công.";
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else if (object_.trangthai == "HIEULUC")
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Đã được ""Hiệu Lực"".", object_.sochungtu);
                    }
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "PNKNB:" + object_.sochungtu, db);
                        object_.trangthai = "SOANTHAO";
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
                msg = @"true#Trả phiếu nhập kho đã chọn về ""Soạn Thảo"" thành công.";
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg.Substring(4));
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