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
    public Public pub = new Public();
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
                pub.CA_01_TinhNhuCauVatTu(context, db, true, true, null, userTK);
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

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

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
                ncvt.c_nhucauvattu_id = id_new;
                ncvt.ten_nhucau = context.Request.Form["ten_nhucau"];
                ncvt.tungay = tungay;
                ncvt.denngay = denngay;
                ncvt.ngayyeucau = ngayyeucau;
                ncvt.c_yeucaumuavt_id = " ";
                ncvt.mota = context.Request.Form["mota"];
                ncvt = Helper.setDefaultValueWhenInsertOrUpdate(ncvt, userTK, false);
                db.c_nhucauvattu.Add(ncvt);

                msg = pub.CA_01_TinhNhuCauVatTu(context, db, false, true, ncvt, userTK);

                if (msg.Length <= 0)
                    db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

        if (msg.Length <= 0)
        {
            msg = $"true#Tạo nhu cầu mua vật tư thành công#{id_new}";
        }
        else
        {
            msg = "false#" + msg;
        }

        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        try
        {
            var tungayStr = context.Request.Form["tungay"];
            var tungay = VNN_Config.setDateTime(tungayStr);
            if (string.IsNullOrWhiteSpace(tungayStr))
                tungay = DateTime.Now.AddYears(-10);
            var denngayStr = context.Request.Form["denngay"];
            var denngay = VNN_Config.setDateTime(denngayStr);
            if (string.IsNullOrWhiteSpace(denngayStr))
                denngay = DateTime.Now.AddYears(10);
            var ngayyeucau = VNN_Config.setDateTime(context.Request.Form["ngayyeucau"]);

            var object_ = db.c_nhucauvattu.Where(p => p.c_nhucauvattu_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "Lỗi: Không tìm thấy đối tượng cần sửa.";
                goto EndEventHandler;
            }

            if (!string.IsNullOrWhiteSpace(object_.c_yeucaumuavt_id))
            {
                msg = "Lỗi: Đã tạo yêu cầu mua vật tư.";
                goto EndEventHandler;
            }

            if (tungay.IsDate() == false)
            {
                msg = string.Format(@"Trường ""Từ Ngày"" có giá trị sai");
                goto EndEventHandler;
            }

            if (denngay.IsDate() == false)
            {
                msg = string.Format(@"Trường ""Dến Ngày"" có giá trị sai");
                goto EndEventHandler;
            }

            if (ngayyeucau.IsDate() == false)
            {
                msg = string.Format(@"Trường ""Ngày yêu cầu"" có giá trị sai");
                goto EndEventHandler;
            }

            object_.ten_nhucau = context.Request.Form["ten_nhucau"];
            object_.tungay = tungay;
            object_.denngay = denngay;
            object_.ngayyeucau = ngayyeucau;
            object_.mota = context.Request.Form["mota"];
            object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);

            msg = pub.CA_01_TinhNhuCauVatTu(context, db, false, true, object_, userTK);

            if (msg.Length <= 0)
                db.SaveChanges();
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0)
        {
            msg = string.Format(@"true#Cập nhật thành công");
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            msg = string.Format(@"false#{0}", msg);
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

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
                    foreach (var dhpx in db.c_nhucauvattu_dhpx.Where(s => s.c_nhucauvattu_id == object_.c_nhucauvattu_id).ToList())
                    {
                        var khdh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhpx.c_kehoachdathang_id).FirstOrDefault();
                        if (khdh != null)
                            khdh.tinhNCVT = false;
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
