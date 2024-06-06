<%@ WebHandler Language="C#" Class="JQGridMD_00_DTKDModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;

public class JQGridMD_00_DTKDModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest (HttpContext context) {
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
            case "CA_01_UpdateDTKD":
                this.CA_01_UpdateDTKD(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_UpdateDTKD(HttpContext context)
    {
        var msg = new List<string>();
        var jsonStr = context.Request.Form["json"];
        var id = context.Request.Form["id_parent"];
        var ma_module = context.Request.QueryString["ma_module"];
        try
        {
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonStr);
            var hasErr = false;
            foreach(var item in json)
            {
                string maDTKD = item.ElementAt(0).Value.removeAllSpaceOrTrimText(true);
                string tenDTKD = item.ElementAt(1).Value.removeAllSpaceOrTrimText(true);
                string daiDien = item.ElementAt(2).Value.removeAllSpaceOrTrimText(true);
                string chucVu = item.ElementAt(3).Value.removeAllSpaceOrTrimText(true);
                string dienThoai = item.ElementAt(4).Value.removeAllSpaceOrTrimText(true);
                string fax = item.ElementAt(5).Value.removeAllSpaceOrTrimText(true);
                string email = item.ElementAt(6).Value.removeAllSpaceOrTrimText(true);
                string website = item.ElementAt(7).Value.removeAllSpaceOrTrimText(true);
                string diaChi = item.ElementAt(8).Value.removeAllSpaceOrTrimText(true);
                string loaiDTKD = item.ElementAt(9).Value.removeAllSpaceOrTrimText(true);
                string quocGia = item.ElementAt(10).Value.removeAllSpaceOrTrimText(true);
                string khuVuc = item.ElementAt(11).Value.removeAllSpaceOrTrimText(true);
                string soTaiKhoan = item.ElementAt(12).Value.removeAllSpaceOrTrimText(true);
                string nganHang = item.ElementAt(13).Value.removeAllSpaceOrTrimText(true);
                string maSoThue = item.ElementAt(14).Value.removeAllSpaceOrTrimText(true);

                string msgDT = "";

                var loaiDTKD_DB = db.md_loaidtkd.Where(s => s.ma_loaidtkd == loaiDTKD | s.ten_loaidtkd == loaiDTKD).FirstOrDefault();
                if (loaiDTKD_DB == null)
                {
                    msgDT = $@"<div style='color:red' error>Không tìm thấy <b>Loại ĐTKD</b></div>";
                }
                else
                {
                    var quocGia_DB = db.md_quocgia.Where(s => s.ma_quocgia == quocGia | s.ten_quocgia == quocGia).FirstOrDefault();
                    if (quocGia_DB == null & !string.IsNullOrWhiteSpace(quocGia))
                    {
                        msgDT = $@"<div style='color:red' error>Không tìm thấy <b>quốc gia</b></div>";
                    }
                    else
                    {
                        var khuVuc_DB = db.md_khuvuc.Where(s => s.ma_khuvuc == khuVuc | s.ten_khuvuc == khuVuc).FirstOrDefault();
                        if (khuVuc_DB == null & !string.IsNullOrWhiteSpace(khuVuc))
                        {
                            msgDT = $@"<div style='color:red' error>Không tìm thấy <b>khu vực</b></div>";
                        }
                        else
                        {
                            var dtkdServer = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == maDTKD).FirstOrDefault();

                            var dtkd = db.md_doitackinhdoanh.Local.Where(s => s.ma_dtkd == maDTKD).FirstOrDefault();

                            var addVT = dtkd == null;
                            if (addVT)
                            {
                                dtkd = new md_doitackinhdoanh();
                                dtkd.md_doitackinhdoanh_id = Helper.getNewId();
                                dtkd.ma_dtkd = maDTKD;
                                dtkd.ten_dtkd = tenDTKD;
                                dtkd.daidien = daiDien;
                                dtkd.chucvu = chucVu;
                                dtkd.tel = dienThoai;
                                dtkd.fax = fax;
                                dtkd.email = email;
                                dtkd.url = website;
                                dtkd.diachi = diaChi;
                                dtkd.md_loaidtkd_id = loaiDTKD_DB.md_loaidtkd_id;
                                dtkd.md_quocgia_id = quocGia_DB == null ? "" : quocGia_DB.md_quocgia_id;
                                dtkd.md_khuvuc_id = khuVuc_DB == null ? "" : khuVuc_DB.md_khuvuc_id;
                                dtkd.so_taikhoan = soTaiKhoan;
                                dtkd.nganhang = nganHang;
                                dtkd.masothue = maSoThue;
                                dtkd = Helper.setDefaultValueWhenInsertOrUpdate(dtkd, userTK, false);
                                db.md_doitackinhdoanh.Add(dtkd);
                                msgDT = $@"<div style='color:blue'>Đạt (add)</div>";
                            }
                            else
                            {
                                dtkd.ten_dtkd = tenDTKD;
                                dtkd.daidien = daiDien;
                                dtkd.chucvu = chucVu;
                                dtkd.tel = dienThoai;
                                dtkd.fax = fax;
                                dtkd.email = email;
                                dtkd.url = website;
                                dtkd.diachi = diaChi;
                                dtkd.md_loaidtkd_id = loaiDTKD_DB.md_loaidtkd_id;
                                dtkd.md_quocgia_id = quocGia_DB == null ? "" : quocGia_DB.md_quocgia_id;
                                dtkd.md_khuvuc_id = khuVuc_DB == null ? "" : khuVuc_DB.md_khuvuc_id;
                                dtkd.so_taikhoan = soTaiKhoan;
                                dtkd.nganhang = nganHang;
                                dtkd.masothue = maSoThue;
                                dtkd = Helper.setDefaultValueWhenInsertOrUpdate(dtkd, userTK, true);
                                msgDT = $@"<div style='color:blue'>Đạt (edit)</div>";
                            }
                        }
                    }
                }


                if (!string.IsNullOrWhiteSpace(msgDT))
                {
                    if (msgDT.LastIndexOf("error") > -1)
                        hasErr = true;
                    msg.Add(msgDT);
                }
            }

            if(!hasErr)
            {
                db.SaveChanges();
            }
        }
        catch(Exception ex)
        {
            msg.Add($@"<div error style='color:red'>{ex.ToString()}</div>");
        }

        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
    }

    public void add(HttpContext context)
    {
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var object_ = new md_doitackinhdoanh();
                object_.md_doitackinhdoanh_id = id_new;
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                object_.hoatdong = true;
                db.md_doitackinhdoanh.Add(object_);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Thêm mới thành công#{0}", id_new);
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

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var object_ = db.md_doitackinhdoanh.Where(p => p.md_doitackinhdoanh_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
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
                string id_del = context.Request.Form["id"];

                var object_ = db.md_doitackinhdoanh.Where(p => p.md_doitackinhdoanh_id == id_del).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần xóa";
                }
                else
                {
                    var pbg001s = db.c_danhsachdathang.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg002s = db.c_donmuahang.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg003s = db.md_xuatban.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg004s = db.md_nhapkho_ncc.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();

                    if(pbg001s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong đơn hàng";
                    else if(pbg002s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong đơn mua hàng hóa vật tư";
                    else if(pbg003s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong xuất bán";
                    else if(pbg004s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong nhập kho từ NCC";
                }

                if (msg.Length <= 0)
                {
                    VNN_Function.Write_log(context, ma_module, null, oper, "MĐT:" + object_.ma_dtkd + ", TĐT:" + object_.ten_dtkd, db);
                    db.md_doitackinhdoanh.Remove(object_);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                transaction.Commit();
                msg = string.Format("true#{0}", "Xóa đối tác kinh doanh thành công");
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format("false#{0}", msg);
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