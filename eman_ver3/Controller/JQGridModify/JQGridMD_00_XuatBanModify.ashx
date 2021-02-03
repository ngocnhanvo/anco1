<%@ WebHandler Language="C#" Class="JQGridMD_00_XuatBanModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_XuatBanModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;

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
            case "add":
                this.add(context);
                break;
            case "edit":
                this.edit(context);
                break;
            case "del":
                this.del(context);
                break;
            case "CA_01_XuatBan":
                this.CA_01_XuatBan(context);
                break;
            case "CA_01_CopytuDonHang":
                this.CA_01_CopytuDonHang(context);
                break;
            case "CA_01_XacNhanXuatKho":
                this.CA_01_XacNhanXuatKho(context);
                break;
            default:
                break;
        }
    }
    public void CA_01_XacNhanXuatKho(HttpContext context)
    {
        string md_xuatban_id = context.Request.QueryString["id"];
        string msg = "";
        var xb = db.md_xuatban.Where(s => s.md_xuatban_id == md_xuatban_id).Take(1).FirstOrDefault();
        if (xb != null)
        {
            if (xb.phieuXNNK == null | xb.phieuXNNK == "")
            {
                xb.phieuXNNK = xb.sochungtu.Replace("PXKXB", "XNXK");
                db.SaveChanges();
                msg = "true";
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_CopytuDonHang(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void CA_01_XuatBan(HttpContext context)
    {
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        int count_slxuat = 0;
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                //Xu Ly nhap kho
                foreach (var px in db.md_xuatban.Where(s => vnn.Contains(s.md_xuatban_id)).ToList())
                {
                    if (px.trangthai == "HIEULUC")
                    {
                        msg = "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" đã hiệu lực.</div>";
                        break;
                    }

                    string soluong_xuat = "0";
                    var count = db.md_xuatban_cdh.Where(s => s.md_xuatban_id == px.md_xuatban_id & s.sl_xuat > 0).ToList();
                    foreach (var dh in count)
                    {
                        //--
                        var khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == px.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();

                        if (string.IsNullOrEmpty(px.tukho) | string.IsNullOrEmpty(px.md_doitackinhdoanh_id))
                        {
                            msg += "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" chưa có kho hoặc phân xưởng đến.</div>";
                        }
                        else if (khosp == null)
                        {
                            msg += "<div style='color:red'>Lỗi: \"" + sp.ma_sanpham + "\" không có trong kho.</div>";
                        }
                        else if (khosp.soluong < dh.sl_xuat)
                        {
                            msg += "<div style='color:red'>Lỗi: Số lượng \"" + sp.ma_sanpham + "\" trong kho chỉ còn: \"" + khosp.soluong.Value.DropTrailingZeros() + "\" .</div>";
                        }
                        else if (dh.sl_xuat < 0)
                        {
                            msg += "<div style='color:red'>Lỗi: Số lượng xuất của \"" + sp.ma_sanpham + "\" phải lớn hơn 0 .</div>";
                        }

                        if (msg.Length <= 0 & dh.sl_xuat.GetValueOrDefault(0) > 0)
                        {
                            count_slxuat++;
                            soluong_xuat = "" + dh.sl_xuat.GetValueOrDefault(0).DropTrailingZeros();
                            //--cap nhat so luong xuat
                            edit_xuat(db, dh, userTK);
                            //--cap nhat vao kho
                            string khospId = xuat_kho(db, dh, px, userTK);
                            add_kho_hsd(db, dh, px, userTK, khospId);
                            //--tao lich su nhap kho
                            add_kho_ls(db, dh, px, userTK);
                            msg_success += "<div style='color:blue'>Dòng \"" + px.sochungtu + " của \"" + sp.ma_sanpham + "\" đã xuất kho thành công, số lượng xuất là: \"" + soluong_xuat + "\"</div>";
                        }
                    }

                    if (msg.Length <= 0 & count_slxuat <= 0)
                    {
                        msg = "<div style='color:red'>Lỗi: Dòng \"" + px.sochungtu + "\" phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.</div>";
                    }

                    if (msg.Length <= 0)
                    {
                        px.trangthai = "HIEULUC";
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = msg_success + msg;
                transaction.Commit();
            }
            else
                transaction.Rollback();
        }
        context.Response.Write(msg);
    }
    //--cap nhat so luong xuat
    public string edit_xuat(EntityContext db, md_xuatban_cdh dh, User_TK us)
    {
        string id_new = dh.md_xuatban_id;
        var xk = db.md_xuatban.Where(s => s.md_xuatban_id == dh.md_xuatban_id).FirstOrDefault();
        var ddsdh = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == xk.c_danhsachdathang_id & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        if (ddsdh != null)
            ddsdh.sl_hanngach += (decimal)dh.sl_xuat;

        decimal sl_daxuat = dh.sl_daxuat.Value + dh.sl_xuat.Value;
        if (dh.tong_sl_xuat.Value <= sl_daxuat)
        {
            sl_daxuat = dh.tong_sl_xuat.Value;
            dh.check_kho = true;
        }

        dh.sl_daxuat = dh.sl_xuat + dh.sl_daxuat;
        xk.ngaycapnhat = DateTime.Now;
        foreach (var xb in db.md_xuatban.Where(s => s.md_xuatban_id != xk.md_xuatban_id & s.c_danhsachdathang_id == xk.c_danhsachdathang_id & s.trangthai == "SOANTHAO").ToList())
        {
            foreach (var xb_dh in db.md_xuatban_cdh.Where(s => s.md_xuatban_id == xb.md_xuatban_id & s.md_sanpham_id == dh.md_sanpham_id).ToList())
            {
                xb_dh.tong_sl_xuat = xb_dh.tong_sl_xuat - sl_daxuat;
                xb_dh.sl_xuat = 0;
            }
        }
        return id_new;
    }

    //xuat kho
    public string xuat_kho(EntityContext db, md_xuatban_cdh dh, md_xuatban px, User_TK us)
    {
        string id_new = dh.md_xuatban_id;
        var check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == px.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;

        id_new = sp.md_kho_sanpham_id;
        sp.soluong = sp.soluong - dh.sl_xuat;
        sp.ngaycapnhat = DateTime.Now;
        var dsdh = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == px.c_danhsachdathang_id & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        dsdh.sl_dagiao += dh.sl_xuat;
        dsdh.sl_conlai -= dh.sl_xuat;
        return id_new;
    }
    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_xuatban_cdh dh, md_xuatban px, User_TK us)
    {
        string id_new = Helper.getNewId();
        var giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = px.tukho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_xuat;
        giao.ngaychuyen = px.ngaychuyen;
        giao.kieuchuyen = "Xuất kho";
        giao.dongnhapxuat = px.sochungtu;
        giao.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;
        giao.mota = px.donhang_thamchieu;

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
        return id_new;
    }
    public string add_kho_hsd(EntityContext db, md_xuatban_cdh dh, md_xuatban px, User_TK us, string khospId)
    {
        string msg = "";
        var spid = db.md_kho_sanpham.
                Where(s => s.md_sanpham_id == dh.md_sanpham_id &
                s.md_kho_id == px.tukho).Select(s => s.md_kho_sanpham_id).FirstOrDefault();
        decimal tsl = dh.sl_xuat.GetValueOrDefault(0);
        foreach (var item in db.md_kho_sanpham_hansudung.
            Where(s => s.md_kho_sanpham_id == spid & s.soluong > 0).OrderBy(s => s.ngay_hethan).ToList())
        {
            decimal soTru = item.soluong.GetValueOrDefault(0) - tsl;
            if (soTru >= 0)
            {
                item.soluong = soTru;
                break;
            }
            else
                item.soluong = 0;
            tsl = Math.Abs(soTru);
        }

        return msg;
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
        string diachi = context.Request.Form["diachi"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var dtk = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).FirstOrDefault();
                string id = context.Request.Form["id"];
                var object_ = db.md_xuatban.Where(p => p.md_xuatban_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg = string.Format(@"Lỗi:Phiếu xuất kho đã ""Hiệu Lực"".");
                }
                else if (dtk == null)
                {
                    msg = "Lỗi:Mã đối tác \"" + md_dtk_id + "\" không tồn tại.";
                }

                if (msg.Length <= 0)
                {
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_doitackinhdoanh_id), dtk.md_doitackinhdoanh_id);
                    VNN_Function.SetFormValue(object_.nameof(s => s.diachi), dtk.diachi);
                    VNN_Function.SetFormValue(object_.nameof(s => s.sochungtu), "VNN_notpost");
                    VNN_Function.SetFormValue(object_.nameof(s => s.trangthai), "VNN_notpost");
                    entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
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

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_xuatban.Where(p => p.md_xuatban_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần trả.", id_del_);
                    }
                    else if (object_.trangthai == "HIEULUC")
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Đã được ""Hiệu Lực"".", object_.sochungtu);
                    }
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "PXB:" + object_.sochungtu, db);
                        object_.trangthai = "SOANTHAO";
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                msg = @"true#Trả phiếu xuất bán đã chọn về ""Soạn Thảo"" thành công.";
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