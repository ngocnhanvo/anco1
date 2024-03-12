<%@ WebHandler Language="C#" Class="JQGridMD_00_NCVTTKModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NCVTTKModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TinhNhuCauVatTu":
                this.CA_01_TinhNhuCauVatTu(context, db, true);
                break;
            case "CA_01_TaoYCMuaVT":
                this.CA_01_TaoYCMuaVT(context);
                break;
            default:
                break;
        }
    }
    public void CA_01_TaoYCMuaVT(HttpContext context)
    {
        string msg = "", msg_success = "";
        string[] vnn = context.Request.Form["id"].Split(',');
        int i = 1;

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                foreach (var ncvt in db.c_nhucauvattu.Where(s => vnn.Contains(s.c_nhucauvattu_id)).ToList())
                {
                    if (ncvt.c_yeucaumuavt_id != " ")
                    {
                        msg += "<div style='color:red'>Lỗi: Dòng \"" + ncvt.ten_nhucau + "\" đã có yêu cầu mua.</div>";
                    }
                    else if (ncvt.datinh_nhucau == false)
                    {
                        msg += "<div style='color:red'>Lỗi: Dòng \"" + ncvt.ten_nhucau + "\" chưa tính nhu cầu mua vật tư.</div>";
                    }
                    else
                    {
                        var khdhs = db.c_nhucauvattu_dhpx.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).ToList();
                        foreach(var khdh in khdhs)
                        {
                            var khdhLK = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).FirstOrDefault();
                            if(khdhLK != null)
                            {
                                khdhLK.xulyNCVT = true;
                            }
                        }

                        string sochungtu = VNN_VariablePublic.sochungtu(db, "YCM", i);
                        i++;
                        ncvt.c_yeucaumuavt_id = sochungtu;
                        var ycmvt = new c_yeucaumuavt()
                        {
                            c_yeucaumuavt_id = Helper.getNewId(),
                            c_nhucauvattu_id = ncvt.c_nhucauvattu_id,
                            c_kehoachmuavt_id = " ",
                            md_trangthai_id = "SOANTHAO",
                            sochungtu = sochungtu,
                            ncvt_name = ncvt.ten_nhucau,
                            nguoiyeucau = "",
                            ngaycan = ncvt.ngayyeucau,
                            nguoitao = userTK.ad_user_id,
                            vaitrotao = userTK.ad_role_id,
                            bophantao = userTK.md_phongban_id,
                            value_nguoitao = userTK.ma_user,
                            value_vaitrotao = userTK.ten_role,
                            value_bophantao = userTK.ten_phongban,
                            nguoicapnhat = userTK.ad_user_id,
                            vaitrocapnhat = userTK.ad_role_id,
                            bophancapnhat = userTK.md_phongban_id,
                            value_nguoicapnhat = userTK.ma_user,
                            value_vaitrocapnhat = userTK.ten_role,
                            value_bophancapnhat = userTK.ten_phongban,
                            ngaytao = DateTime.Now,
                            ngaycapnhat = DateTime.Now,
                            mota = "",
                            hoatdong = true
                        };
                        db.c_yeucaumuavt.Add(ycmvt);

                        foreach (var ncvt_ycmvt in db.c_nhucauvattu_ycmvt.
                                Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).ToList())
                        {
                            var ycmvt_cdh = new c_yeucaumuavt_cdh()
                            {
                                c_yeucaumuavt_cdh_id = Helper.getNewId(),
                                c_yeucaumuavt_id = ycmvt.c_yeucaumuavt_id,
                                md_sanpham_id = ncvt_ycmvt.md_sanpham_id,
                                md_donvitinhsanpham_id = ncvt_ycmvt.md_donvitinhsanpham_id,
                                soluong_yeucau = ncvt_ycmvt.soluong.Value,
                                nguoitao = userTK.ad_user_id,
                                vaitrotao = userTK.ad_role_id,
                                bophantao = userTK.md_phongban_id,
                                value_nguoitao = userTK.ma_user,
                                value_vaitrotao = userTK.ten_role,
                                value_bophantao = userTK.ten_phongban,
                                nguoicapnhat = userTK.ad_user_id,
                                vaitrocapnhat = userTK.ad_role_id,
                                bophancapnhat = userTK.md_phongban_id,
                                value_nguoicapnhat = userTK.ma_user,
                                value_vaitrocapnhat = userTK.ten_role,
                                value_bophancapnhat = userTK.ten_phongban,
                                ngaytao = DateTime.Now,
                                ngaycapnhat = DateTime.Now,
                                mota = "",
                                hoatdong = true
                            };
                            db.c_yeucaumuavt_cdh.Add(ycmvt_cdh);
                        }
                        db.SaveChanges();
                        msg_success += "<div style='color:blue'>Đã tạo yêu cầu mua \"" + sochungtu + "\"</div>";
                    }
                }
            }
            catch(Exception ex)
            {
                msg += "<div style='color:red'>Lỗi: "+ ex.Message +".</div>";
            }

            if(msg.Length <= 0)
            {
                msg = msg_success;
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_TinhNhuCauVatTu(HttpContext context, EntityContext db, bool SingleFunc, bool? reset = false)
    {
        string msg = "", msg_success = "";
        string[] vnn = context.Request.Form["id"].Split(',');

        try
        {
            System.Linq.Expressions.Expression<Func<c_nhucauvattu, bool>> condition = s => vnn.Contains(s.c_nhucauvattu_id);

            var ncvts = db.c_nhucauvattu.Where(condition).ToList();
            var ncvtsLocal = db.c_nhucauvattu.Local.AsQueryable().Where(condition).ToList();

            foreach (var ncvt in ncvtsLocal)
            {
                if (ncvt.c_yeucaumuavt_id != " ")
                {
                    msg = "<div style='color:red'>Lỗi: dòng \"" + ncvt.ten_nhucau + "\" đã lập yêu cầu mua vật tư.</div>";
                    break;
                }
                else
                {
                    if (reset.GetValueOrDefault(false))
                    {
                        var khdhs = from a in db.c_kehoachdathang
                                    where
                                     a.ngaybatdausx >= ncvt.tungay & a.ngaybatdausx <= ncvt.denngay
                                     & (a.trangthai == Helper.DATNCC | a.trangthai == Helper.DATSX)
                                     & (a.tinhNCVT ?? false) == false
                                    select a;

                        db.c_nhucauvattu_dhpx.RemoveRange(db.c_nhucauvattu_dhpx.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id));

                        foreach (var khdh in khdhs.ToList())
                        {
                            var ncvt_dhpx = new c_nhucauvattu_dhpx()
                            {
                                c_nhucauvattu_dhpx_id = Helper.getNewId(),
                                c_nhucauvattu_id = ncvt.c_nhucauvattu_id,
                                c_kehoachdathang_id = khdh.c_kehoachdathang_id,
                                nguoitao = userTK.ad_user_id,
                                vaitrotao = userTK.ad_role_id,
                                bophantao = userTK.md_phongban_id,
                                value_nguoitao = userTK.ma_user,
                                value_vaitrotao = userTK.ten_role,
                                value_bophantao = userTK.ten_phongban,

                                nguoicapnhat = userTK.ad_user_id,
                                vaitrocapnhat = userTK.ad_role_id,
                                bophancapnhat = userTK.md_phongban_id,
                                value_nguoicapnhat = userTK.ma_user,
                                value_vaitrocapnhat = userTK.ten_role,
                                value_bophancapnhat = userTK.ten_phongban,

                                ngaytao = DateTime.Now,
                                ngaycapnhat = DateTime.Now,
                                mota = "",
                                hoatdong = true
                            };
                            db.c_nhucauvattu_dhpx.Add(ncvt_dhpx);
                            khdh.tinhNCVT = true;
                        }
                    }
                    ncvt.datinh_nhucau = true;
                    msg_success += "<div style='color:blue'>Tính nhu cầu vật tư \"" + ncvt.ten_nhucau + "\" thành công</div>";
                }
            }
            if (msg.Length <= 0)
            {
                var ncvtDDHPXs = db.c_nhucauvattu_ddhpx.Where(s => vnn.Contains(s.c_nhucauvattu_id));
                db.c_nhucauvattu_ddhpx.RemoveRange(ncvtDDHPXs);
                var ncvtYCMVTs = db.c_nhucauvattu_ycmvt.Where(s => vnn.Contains(s.c_nhucauvattu_id));
                db.c_nhucauvattu_ycmvt.RemoveRange(ncvtYCMVTs);
                var khdhsServer = db.c_nhucauvattu_dhpx.Where(s => vnn.Contains(s.c_nhucauvattu_id)).ToList();
                var khdhs = db.c_nhucauvattu_dhpx.Local.Where(s => vnn.Contains(s.c_nhucauvattu_id)).ToList();
                foreach (var khdh in khdhs)
                {

                    var dhcpxs = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).ToList();
                    foreach (var dhcpx in dhcpxs)
                    {
                        var dhcpxCDHs = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).ToList();
                        foreach (var cdh in dhcpxCDHs)
                        {
                            var cdhNCVTServer = db.c_nhucauvattu_ddhpx.
                                Where(s => s.md_sanpham_id == cdh.md_sanpham_id &
                                s.c_nhucauvattu_id == khdh.c_nhucauvattu_id).Take(1).FirstOrDefault();
                            var cdhNCVT = db.c_nhucauvattu_ddhpx.Local.
                                Where(s => s.md_sanpham_id == cdh.md_sanpham_id &
                                s.c_nhucauvattu_id == khdh.c_nhucauvattu_id).Take(1).FirstOrDefault();
                            var addNCVT = cdhNCVT == null;
                            if (addNCVT)
                            {
                                cdhNCVT = new c_nhucauvattu_ddhpx();
                                cdhNCVT.c_nhucauvattu_ddhpx_id = Helper.getNewId();
                                cdhNCVT.soluong = cdh.soluong;
                                cdhNCVT.c_nhucauvattu_id = khdh.c_nhucauvattu_id;
                                cdhNCVT.md_sanpham_id = cdh.md_sanpham_id;
                                cdhNCVT.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                                cdhNCVT = Helper.setDefaultValueWhenInsertOrUpdate(cdhNCVT, userTK, false);
                                db.c_nhucauvattu_ddhpx.Add(cdhNCVT);
                            }
                            else
                            {
                                cdhNCVT.soluong = cdhNCVT.soluong.GetValueOrDefault(0) + cdh.soluong.Value;
                            }
                        }
                    }

                    var vts = from a in db.md_lenhsanxuat_tosx_vattu
                              join b in db.md_lenhsanxuat_tosx on a.md_lenhsanxuat_tosx_id equals b.md_lenhsanxuat_tosx_id
                              join c in db.md_lenhsanxuat on b.md_lenhsanxuat_id equals c.md_lenhsanxuat_id
                              join d in db.md_dondathangphanxuong on c.md_dondathangphanxuong_id equals d.md_dondathangphanxuong_id
                              join e in db.c_kehoachdathang on d.donhang_thamchieu equals e.donhang_thamchieu
                              join sp in db.md_sanpham on a.md_sanpham_id equals sp.md_sanpham_id
                              where
                                e.c_kehoachdathang_id == khdh.c_kehoachdathang_id
                                & b.stt != 0
                                & (sp.ban_thanhpham ?? false) == false
                              select a;

                    foreach (var vt in vts.ToList())
                    {
                        var sltd = vt.soluong.GetValueOrDefault(0) - vt.sl_giamhanngach.GetValueOrDefault(0);
                        if (sltd > 0)
                        {
                            var ncvt_ycmvtServer = db.c_nhucauvattu_ycmvt.Where(s => s.md_sanpham_id == vt.md_sanpham_id & s.c_nhucauvattu_id == khdh.c_nhucauvattu_id).Take(1).FirstOrDefault();
                            var ncvt_ycmvt = db.c_nhucauvattu_ycmvt.Local.Where(s => s.md_sanpham_id == vt.md_sanpham_id & s.c_nhucauvattu_id == khdh.c_nhucauvattu_id).Take(1).FirstOrDefault();
                            var addVT = ncvt_ycmvt == null;
                            if (addVT)
                            {
                                ncvt_ycmvt = new c_nhucauvattu_ycmvt();
                                ncvt_ycmvt.c_nhucauvattu_ycmvt_id = Helper.getNewId();
                                ncvt_ycmvt.c_nhucauvattu_id = khdh.c_nhucauvattu_id;
                                ncvt_ycmvt.md_sanpham_id = vt.md_sanpham_id;
                                ncvt_ycmvt.md_donvitinhsanpham_id = vt.md_donvitinhsanpham_id;
                                ncvt_ycmvt.soluong = sltd;
                                ncvt_ycmvt = Helper.setDefaultValueWhenInsertOrUpdate(ncvt_ycmvt, userTK, false);
                                db.c_nhucauvattu_ycmvt.Add(ncvt_ycmvt);
                            }
                            else
                            {
                                ncvt_ycmvt.soluong = ncvt_ycmvt.soluong.GetValueOrDefault(0) + sltd;
                            }
                        }
                    }
                }
            }

            if (SingleFunc == true)
            {
                if (msg.Length <= 0)
                    db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = string.Format(@"Lỗi: {0}", ex.Message);
        }

        if (SingleFunc == true)
        {
            if (msg.Length <= 0)
            {
                //transaction.Commit();
                msg = msg_success;
            }
            else
                //transaction.Rollback();

                //transaction.Dispose();
                context.Response.Write(msg);
        }
    }

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        //using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var tungayStr = context.Request.Form["tungay"];
                var tungay = VNN_Config.setDateTime(tungayStr);
                if (string.IsNullOrWhiteSpace(tungayStr))
                    tungay = DateTime.Now.AddYears(-10);
                var denngayStr = context.Request.Form["denngay"];
                var denngay = VNN_Config.setDateTime(denngayStr);
                if (string.IsNullOrWhiteSpace(denngayStr))
                    denngay = DateTime.Now.AddYears(10);

                var ngayyeucau = VNN_Config.setDateTime(context.Request.Form["ngayyeucau"]);

                if (tungay.IsDate() == false)
                    msg = string.Format(@"Trường ""Từ Ngày"" có giá trị sai");
                else if (denngay.IsDate() == false)
                    msg = string.Format(@"Trường ""Dến Ngày"" có giá trị sai");
                else if (ngayyeucau.IsDate() == false)
                    msg = string.Format(@"Trường ""Ngày yêu cầu"" có giá trị sai");

                if (msg.Length <= 0)
                {
                    var ncvt = new c_nhucauvattu();
                    ncvt.c_nhucauvattu_id = Helper.getNewId();
                    ncvt.ten_nhucau = context.Request.Form["ten_nhucau"];
                    ncvt.tungay = tungay;
                    ncvt.denngay = denngay;
                    ncvt.ngayyeucau = ngayyeucau;
                    ncvt.c_yeucaumuavt_id = " ";
                    ncvt.mota = context.Request.Form["mota"];
                    db.c_nhucauvattu.Add(ncvt);


                    VNN_Function.SetFormValue("id", ncvt.c_nhucauvattu_id);
                    CA_01_TinhNhuCauVatTu(context, db, false, true);

                    var countNCMVTServer = db.c_nhucauvattu_ycmvt.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).Count();
                    var countNCMVT = db.c_nhucauvattu_ycmvt.Local.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).Count();
                    if (countNCMVT <= 0)
                    {
                        msg = "Không có vật tư nào cần mua trong thời gian này.";
                    }
                    else
                    {
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
                msg = "true#Tạo nhu cầu mua vật tư thành công";
            }
            else
            {
                msg = "false#" + msg;
            }
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var object_ = db.c_nhucauvattu.Where(p => p.c_nhucauvattu_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa.";
                }
                else
                {
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

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.c_nhucauvattu.Where(p => p.c_nhucauvattu_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else if (!string.IsNullOrWhiteSpace(object_.c_yeucaumuavt_id))
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Đã tạo yêu cầu mua vật tư.", object_.ten_nhucau);
                    }
                    else
                    {
                        foreach(var dhpx in db.c_nhucauvattu_dhpx.Where(s=>s.c_nhucauvattu_id == object_.c_nhucauvattu_id).ToList())
                        {
                            var khdhpx = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == dhpx.md_dondathangphanxuong_id).FirstOrDefault();
                            if (khdhpx != null)
                                khdhpx.tinh_ncvt = false;
                        }
                        VNN_Function.Write_log(context, ma_module, null, oper, "TNCMVT:" + object_.ten_nhucau, db);
                        db.c_nhucauvattu.Remove(object_);
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
                msg = string.Format(@"true#Xóa nhu cầu vật tư đã chọn thành công");
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
