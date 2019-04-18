<%@ WebHandler Language="C#" Class="JQGridMD_00_KHMVTModify" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;
using System.Collections.Generic;
using Newtonsoft.Json;

public class JQGridMD_00_KHMVTModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "load_banggia":
                this.load_banggia(context);
                break;
            case "CA_01_Taodomuavattu":
                this.CA_01_Taodomuavattu(context);
                break;
            case "CA_01_CopyKehoach":
                this.CA_01_CopyKehoach(context);
                break;
            case "load_khmvt":
                this.load_khmvt(context);
                break;
            case "CA_01_TongHopLHMVT":
                this.CA_01_TongHopLHMVT(context);
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

    public void CA_01_TongHopLHMVT(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string[] id = context.Request.Form["id"].Split(',');
        var khmvts = db.c_kehoachmuavt.Where(s => id.Contains(s.c_kehoachmuavt_id)).OrderByDescending(s => s.sochungtu);
        c_kehoachmuavt khmvt_sel = khmvts.FirstOrDefault();

        if (khmvts.Where(s => s.md_trangthai_id == "SOANTHAO").Count() == khmvts.Count())
        {
            foreach (var khmvt in khmvts.Where(s => s.c_kehoachmuavt_id != khmvt_sel.c_kehoachmuavt_id).ToList())
            {
                foreach (var khmvt_cdh in db.c_kehoachmuavt_cdh.Where(s => s.c_kehoachmuavt_id == khmvt.c_kehoachmuavt_id).ToList())
                {
                    var khmvt_cdh_sel = db.c_kehoachmuavt_cdh.FirstOrDefault(
                    s => s.c_kehoachmuavt_id == khmvt_sel.c_kehoachmuavt_id & s.md_sanpham_id == khmvt_cdh.md_sanpham_id);
                    if (khmvt_cdh_sel != null)
                    {
                        khmvt_cdh_sel.sl_can += khmvt_cdh.sl_can;
                        khmvt_cdh_sel.sl_denghi = khmvt_cdh_sel.sl_can;
                    }
                    else
                    {
                        var khmvt_cdh_new = Clone(khmvt_cdh);
                        khmvt_cdh_new.c_kehoachmuavt_cdh_id = Helper.getNewId();
                        khmvt_cdh_new.c_kehoachmuavt_id = khmvt_sel.c_kehoachmuavt_id;
                        khmvt_cdh_new.sl_denghi = khmvt_cdh.sl_can;
                        db.c_kehoachmuavt_cdh.Add(khmvt_cdh_new);
                    }
                }

                string sct_new = khmvt_sel.sochungtu, sct_old = khmvt.sochungtu;
                foreach (c_yeucaumuavt ycmvt in db.c_yeucaumuavt.Where(s => s.c_kehoachmuavt_id.Contains(sct_old)).ToList())
                {
                    if (!ycmvt.c_kehoachmuavt_id.Contains(sct_new))
                    {
                        ycmvt.c_kehoachmuavt_id = ycmvt.c_kehoachmuavt_id.Replace(sct_old, sct_new);
                    }
                    else
                    {
                        ycmvt.c_kehoachmuavt_id = ycmvt.c_kehoachmuavt_id.Replace("," + sct_old, "").Replace(sct_old + ",", "").Replace(sct_old, "");
                    }

                    foreach (c_yeucaumuavt_cdh ycmvt_cdh in db.c_yeucaumuavt_cdh.Where(s => s.sapxep == khmvt.c_kehoachmuavt_id & s.c_yeucaumuavt_id == ycmvt.c_yeucaumuavt_id).ToList())
                    {
                        ycmvt_cdh.sapxep = khmvt_sel.c_kehoachmuavt_id;
                    }
                }
                khmvt_sel.mota += khmvt.sochungtu + ",";
                db.c_kehoachmuavt.Remove(khmvt);
                db.SaveChanges();
            }
            msg += "<div style='color:blue'>Thành công: Đã tập hợp tất cả kế hoạch đã chọn thành \"" + khmvt_sel.sochungtu + "\"</div>";
        }
        else
        {
            msg += "<div style='color:red'>Lỗi: Tất cả kết hoạch được chọn đều phải có trạng thái \"Soạn Thảo\"</div>";
        }
        context.Response.Write(msg);
    }



    public void load_khmvt(HttpContext context)
    {
        var item = new Dictionary<string, object>();
        var db = new EntityContext();
        string str = "<option value=''></option>";
        foreach (c_kehoachmuavt khmvt in db.c_kehoachmuavt.Where(s => s.hoatdong == true & s.md_trangthai_id == "HIEULUC" & s.sochungtu.Contains("DTMVT")).ToList())
        {
            str += "<option value='" + khmvt.c_kehoachmuavt_id + "'>" + khmvt.ten_kehoach + "</option>";
        }

        string value = db.ad_selectoption.Where(s => s.ma_selectoption == "<%=SL_eAncop_donvitinhsanpham%>").Select(s => s.value_selectoption).FirstOrDefault();
        item["khmvt"] = str;
        item["donvitinh"] = value;
        context.Response.Write(JsonConvert.SerializeObject(item));
    }

    public void CA_01_CopyKehoach(HttpContext context)
    {
        string msg = "";
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        string[] nht = id.Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "DTMVT", 1);
        c_kehoachmuavt dsdh = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == id).FirstOrDefault();
        if (nht.Count() > 1)
        {
            msg = "<div style='color:red'>Lỗi: Chỉ được chọn một kế hoạch.</div>" + "###" + "";
        }
        else if (dsdh == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm kế hoạch đã chọn.</div>" + "###" + "";
        }
        else
        {
            string id_new = Helper.getNewId();
            c_kehoachmuavt dsdh_new = Clone(dsdh);
            dsdh_new.c_kehoachmuavt_id = id_new;
            dsdh_new.sochungtu = sochungtu;
            dsdh_new.c_donmuavattu_id = " ";
            db.c_kehoachmuavt.Add(dsdh_new);

            foreach (c_kehoachmuavt_cdh dongdsdh in db.c_kehoachmuavt_cdh.Where(s => s.c_kehoachmuavt_id == dsdh.c_kehoachmuavt_id))
            {
                if (dongdsdh.sl_duyet == 0)
                {
                    c_kehoachmuavt_cdh dongdsdh_new = Clone(dongdsdh);
                    dongdsdh_new.c_kehoachmuavt_cdh_id = Helper.getNewId();
                    dongdsdh_new.c_kehoachmuavt_id = id_new;
                    db.c_kehoachmuavt_cdh.Add(dongdsdh_new);
                }
            }

            db.SaveChanges();
            msg = "<div style='color:blue'>Tạo mới kế hoạch \"" + sochungtu + "\" thành công.</div>" + "###" + id_new;
        }
        context.Response.Write(msg);
    }

    public void load_banggia(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        msg += "<option value=''></option>";
        foreach (md_banggia bg in db.md_banggia.Where(s => s.banggiaban != true).OrderBy(s => s.ten_banggia))
        {
            msg += "<option value='" + bg.md_banggia_id + "'>" + bg.ten_banggia + "</option>";
        }
        context.Response.Write(msg);
    }

    public void CA_01_Taodomuavattu(HttpContext context)
    {
        string msg = "", msg_success = "";
        EntityContext db = new EntityContext();
        string[] vnn = context.Request.Form["id"].Split(',');
        string[] arr_id = context.Request.Form["arr_id"].Split(',');
        string[] arr_ncc = context.Request.Form["arr_ncc"].Split(',');
        string[] arr_sl = context.Request.Form["arr_sl"].Split(',');
        string[] arr_dvt = context.Request.Form["arr_dvt"].Split(',');
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context),
            Security.id_vaitro(context), Security.id_phongban(context));
        string c_donmuahang_id = "";

        var lst = new List<khmvt_hh>();
        for (int i = 0; i < arr_id.Length; i++)
        {
            string arr_id_ = arr_id[i];
            string arr_dvt_ = arr_dvt[i];
            var khmvt_cdh = db.c_kehoachmuavt_cdh.Where(s => s.c_kehoachmuavt_cdh_id == arr_id_).FirstOrDefault();
            if (khmvt_cdh != null)
            {
                decimal sl_semua = -1;
                decimal sl_thaythe = sl_semua, saiso = 0;
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == khmvt_cdh.md_sanpham_id).FirstOrDefault();
                var dvt = db.md_donvitinhsanpham_cddv.
                    Where(s => s.md_sanpham_id == sp.ma_sanpham & s.md_donvitinhsanpham_id == arr_dvt_).FirstOrDefault();
                try { sl_semua = decimal.Parse(arr_sl[i]); } catch { }
                if (dvt != null)
                {
                    sl_thaythe = dvt.nhanvoi.GetValueOrDefault(0) * sl_semua;
                    saiso = dvt.chiacho.GetValueOrDefault(0) * sl_semua;
                    if (saiso > dvt.saiso_toida.GetValueOrDefault(9999999))
                        saiso = dvt.saiso_toida.GetValueOrDefault(9999999);
                }
                else if (arr_dvt_ == sp.md_donvitinhsanpham_id)
                {
                    sl_thaythe = sl_semua;
                    saiso = 0;
                }
                else
                {
                    string tendvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == arr_dvt_).Select(s => s.ten_dvt).FirstOrDefault();
                    msg += string.Format(@"
                        <div style='color:red'>
                            Lỗi: Mã sản phẩm ""{0}"" không có đơn vị tính ""{1}""
                        </div>",
                        sp.ma_sanpham,
                        tendvt);
                }

                if (sl_semua > -1 & (sl_thaythe - saiso) <= (khmvt_cdh.sl_duyet.Value - khmvt_cdh.sl_conlai.Value))
                {
                    string arr_ncc_ = arr_ncc[i];
                    var dtkd = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == arr_ncc_).FirstOrDefault();
                    if (dtkd != null)
                    {
                        if (dtkd.md_banggia_id != null & dtkd.md_banggia_id != "")
                        {
                            khmvt_hh khm = new khmvt_hh
                            {
                                md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id,
                                md_donvitinhsanpham_id = arr_dvt_,
                                md_sanpham_id = sp.md_sanpham_id,
                                sl_duyet = khmvt_cdh.sl_duyet.Value,
                                sl_conlai = khmvt_cdh.sl_conlai.Value,
                                sl_semua = sl_semua,
                                sl_semua2 = sl_thaythe,
                                saiso = saiso,
                                md_thue_sanpham_id = sp.md_thue_sanpham_id,
                                daidien = dtkd.daidien,
                                ma_sanpham = sp.ma_sanpham,
                                ma_dtkd = dtkd.ma_dtkd,
                                md_banggia_id = dtkd.md_banggia_id
                            };
                            lst.Add(khm);
                        }
                        else if (sl_semua > 0)
                        {
                            msg += "<div style='color:red'>Lỗi:NCC \"" + arr_ncc[i] + "\" không có bảng giá</div>";
                        }
                    }
                    else if (sl_semua > 0)
                    {
                        msg += "<div style='color:red'>Lỗi:NCC \"" + arr_ncc[i] + "\" không tồn tại</div>";
                    }
                }
                else
                {
                    string ten_dvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                    string msgDT = "";
                    msgDT += @"chỉ có thể nhập số lượng tối đa là: ""{0}""";
                    msgDT += @"<br> + Số lượng đang muốn nhập: ""{1}"" ({2})";
                    msgDT += @"<br> + Độ sai lệch cho phép: ""{3}""";
                    msgDT = string.Format(msgDT, khmvt_cdh.sl_duyet.Value.DropTrailingZeros(),
                        sl_thaythe.DropTrailingZeros(), ten_dvt, saiso.DropTrailingZeros());
                    msg += string.Format(@"
                        <div style='color:red'>
                            Lỗi:Mặt hàng ""{0}"" {1}
                        </div>", sp.ma_sanpham, msgDT);
                }
            }
        }

        if (msg.Length <= 0)
        {
            foreach (var khmvt in db.c_kehoachmuavt.Where(s => vnn.Contains(s.c_kehoachmuavt_id)).ToList())
            {
                //Hieu luc tung don
                int countx = 0;
                int m = db.c_donmuahang.Where(s => s.c_kehoachmuavt_id == khmvt.c_kehoachmuavt_id & s.md_trangthai_id == "SOANTHAO" & s.sctkehoach == khmvt.sochungtu).Count();
                countx += m;
                string nhacungung = "123";
                int dem_khmvt_cdh = 0;
                /*if(khmvt.c_donmuavattu_id != " ") {
					msg += "<div style='color:red'>Lỗi:Kế hoạch \""+ khmvt.sochungtu +"\" đã tạo đơn mua vật tư</div>";
				}*/
                /*if(countx > 0)
				{
					msg = "<div style='color:red'>Đơn mua hàng trước chưa Hiệu Lực, không thể tạo phiếu mới.</div>";
					break;
				}*/
                if (1 == 1)
                {
                    var c_kehoachmuavt_cdhs = lst.Where(s => s.sl_semua > 0).OrderBy(s => s.md_doitackinhdoanh_id).ToList();

                    string id_new = Helper.getNewId(), ma_iso_tiente = "";
                    foreach (var khmvt_cdh in c_kehoachmuavt_cdhs)
                    {

                        var check_gia = (from a in db.md_banggia
                                         join b in db.md_phienbangia on a.md_banggia_id equals b.md_banggia_id
                                         join c in db.md_giasanpham on b.md_phienbangia_id equals c.md_phienbangia_id
                                         where
                                         c.md_sanpham_id == khmvt_cdh.md_sanpham_id
                                         & c.md_donvitinhsanpham_id == khmvt_cdh.md_donvitinhsanpham_id
                                         & a.md_banggia_id == khmvt_cdh.md_banggia_id
                                         & b.hoatdong == true
                                         select new
                                         {
                                             a.md_banggia_id,
                                             c.gia,
                                             a.md_dongtien_id,
                                             c.md_phienbangia_id,
                                             b.ngay_hieuluc
                                         }
                                        ).OrderByDescending(s => s.ngay_hieuluc).FirstOrDefault();

                        if (khmvt_cdh.sl_duyet == khmvt_cdh.sl_conlai)
                        {
                            //msg += "<div style='color:red'>Lỗi:Mã \""+ khmvt_cdh.ma_sanpham +"\" đã mua đủ số lượng.</div>";
                        }
                        else if (check_gia == null)
                        {
                            msg += "<div style='color:red'>Lỗi:NCC \"" + khmvt_cdh.ma_dtkd + "\" không có giá của HH/VT \"" + khmvt_cdh.ma_sanpham + "\"</div>";
                        }
                        else
                        {
                            c_donmuahang dmh = db.c_donmuahang.FirstOrDefault(s => s.c_donmuahang_id == id_new);
                            if (nhacungung != khmvt_cdh.md_doitackinhdoanh_id & dmh == null)
                            {
                                nhacungung = khmvt_cdh.md_doitackinhdoanh_id;
                                string sochungtu = VNN_VariablePublic.sochungtu(db, "DMH", 1);
                                msg_success += "<div style='color:blue'>Tạo đơn mua vật tư \"" + sochungtu + "\" thành công.</div>";
                                dem_khmvt_cdh = 1;
                                id_new = Helper.getNewId();
                                c_donmuahang_id += id_new + ",";
                                ma_iso_tiente = db.md_dongtien.Where(s => s.md_dongtien_id == check_gia.md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();
                                dmh = new c_donmuahang();
                                dmh.c_donmuahang_id = id_new;
                                dmh.phieunhapkho = " ";
                                dmh.c_kehoachmuavt_id = khmvt.c_kehoachmuavt_id;
                                dmh.md_trangthai_id = "SOANTHAO";
                                dmh.sochungtu = sochungtu;
                                dmh.sctkehoach = khmvt.sochungtu;
                                dmh.donhang_thamchieu = "";
                                dmh.huongdan_lamhang = "";
                                dmh.ngaydonhang = DateTime.Now;
                                dmh.ngaygiaohang = DateTime.Now.AddDays(4);
                                dmh.diadiem_giaohang = "";
                                dmh.md_doitackinhdoanh_id = khmvt_cdh.md_doitackinhdoanh_id;
                                dmh.nguoilienhe = khmvt_cdh.daidien;
                                dmh.md_banggia_id = khmvt_cdh.md_banggia_id;
                                //
                                dmh.md_phienbangia_id = check_gia.md_phienbangia_id;
                                dmh.md_dongtien_id = check_gia.md_dongtien_id;
                                dmh.tong_tienhang = 0;
                                dmh.tong_tatca = 0;
                                dmh.chu_tong_tienhang = "Không " + ma_iso_tiente;
                                dmh.chu_tong_tatca = "Không " + ma_iso_tiente;
                                dmh.nguoitao = us.ad_user_id;
                                dmh.vaitrotao = us.ad_role_id;
                                dmh.bophantao = us.md_phongban_id;
                                dmh.value_nguoitao = us.ma_user;
                                dmh.value_vaitrotao = us.ten_role;
                                dmh.value_bophantao = us.ten_phongban;

                                dmh.nguoicapnhat = us.ad_user_id;
                                dmh.vaitrocapnhat = us.ad_role_id;
                                dmh.bophancapnhat = us.md_phongban_id;
                                dmh.value_nguoicapnhat = us.ma_user;
                                dmh.value_vaitrocapnhat = us.ten_role;
                                dmh.value_bophancapnhat = us.ten_phongban;

                                dmh.ngaytao = DateTime.Now;
                                dmh.ngaycapnhat = DateTime.Now;
                                dmh.mota = "";
                                dmh.hoatdong = true;

                                db.c_donmuahang.Add(dmh);
                                if (khmvt.c_donmuavattu_id == " ")
                                    khmvt.c_donmuavattu_id = sochungtu;
                                else
                                    khmvt.c_donmuavattu_id += "," + sochungtu;
                            }

                            decimal dongiamua = check_gia.gia.Value;

                            var thue_sp = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == khmvt_cdh.md_thue_sanpham_id).FirstOrDefault();
                            string md_thue_sanpham_id = "";
                            decimal gt_thue = 0;
                            if (thue_sp != null)
                            {
                                md_thue_sanpham_id = thue_sp.md_thue_sanpham_id;
                                gt_thue = thue_sp.giatri.Value;
                            }

                            var dmvt_cdmh = new c_donmuahang_cdmh();
                            dmvt_cdmh.c_donmuahang_cdmh_id = Helper.getNewId();
                            dmvt_cdmh.c_donmuahang_id = id_new;
                            dmvt_cdmh.md_sanpham_id = khmvt_cdh.md_sanpham_id;
                            dmvt_cdmh.md_donvitinhsanpham_id = khmvt_cdh.md_donvitinhsanpham_id;
                            dmvt_cdmh.sl_dadat = khmvt_cdh.sl_semua;
                            dmvt_cdmh.sl_dadat2 = khmvt_cdh.sl_semua2;
                            dmvt_cdmh.sl_hanngach = 0;
                            dmvt_cdmh.saiso = khmvt_cdh.saiso;
                            dmvt_cdmh.dongiamua = dongiamua;
                            dmvt_cdmh.giachuan = dongiamua;

                            dmvt_cdmh.thue = md_thue_sanpham_id;
                            if (ma_iso_tiente == "VND")
                                dmvt_cdmh.thanhtien = Math.Round(dongiamua * (khmvt_cdh.sl_semua), 0);
                            else
                                dmvt_cdmh.thanhtien = dongiamua * (khmvt_cdh.sl_semua);
                            dmvt_cdmh.nguoitao = us.ad_user_id;
                            dmvt_cdmh.vaitrotao = us.ad_role_id;
                            dmvt_cdmh.bophantao = us.md_phongban_id;
                            dmvt_cdmh.value_nguoitao = us.ma_user;
                            dmvt_cdmh.value_vaitrotao = us.ten_role;
                            dmvt_cdmh.value_bophantao = us.ten_phongban;
                            dmvt_cdmh.md_donvitinhsanpham_id = khmvt_cdh.md_donvitinhsanpham_id;

                            dmvt_cdmh.nguoicapnhat = us.ad_user_id;
                            dmvt_cdmh.vaitrocapnhat = us.ad_role_id;
                            dmvt_cdmh.bophancapnhat = us.md_phongban_id;
                            dmvt_cdmh.value_nguoicapnhat = us.ma_user;
                            dmvt_cdmh.value_vaitrocapnhat = us.ten_role;
                            dmvt_cdmh.value_bophancapnhat = us.ten_phongban;

                            dmvt_cdmh.ngaytao = DateTime.Now;
                            dmvt_cdmh.ngaycapnhat = DateTime.Now;
                            dmvt_cdmh.mota = "";
                            dmvt_cdmh.hoatdong = true;
                            db.c_donmuahang_cdmh.Add(dmvt_cdmh);

                            string id_news = Helper.getNewId();
                            c_donmuahang_thue thue = new c_donmuahang_thue();
                            //--
                            thue.tong_tien_thue = dmvt_cdmh.thanhtien * gt_thue / 100;
                            thue.tong_tien_chiu_thue = dmvt_cdmh.thanhtien + thue.tong_tien_thue;
                            //--
                            thue.c_donmuahang_thue_id = id_news;
                            thue.c_donmuahang_id = dmvt_cdmh.c_donmuahang_id;
                            thue.md_thue_sanpham_id = md_thue_sanpham_id;
                            thue.doanhnghiep = "";
                            thue.tochuc = "";

                            thue.nguoitao = us.ad_user_id;
                            thue.vaitrotao = us.ad_role_id;
                            thue.bophantao = us.md_phongban_id;
                            thue.value_nguoitao = us.ma_user;
                            thue.value_vaitrotao = us.ten_role;
                            thue.value_bophantao = us.ten_phongban;

                            thue.nguoicapnhat = us.ad_user_id;
                            thue.vaitrocapnhat = us.ad_role_id;
                            thue.bophancapnhat = us.md_phongban_id;
                            thue.value_nguoicapnhat = us.ma_user;
                            thue.value_vaitrocapnhat = us.ten_role;
                            thue.value_bophancapnhat = us.ten_phongban;

                            thue.ngaytao = DateTime.Now;
                            thue.ngaycapnhat = DateTime.Now;
                            thue.mota = "";
                            thue.hoatdong = true;

                            if (dmvt_cdmh.thue != "")
                            {
                                db.c_donmuahang_thue.Add(thue);
                            }
                        }
                    }
                }

                if (dem_khmvt_cdh == 0 & msg == "")
                    msg += "<div style='color:red'>Lỗi: Dòng \"" + khmvt.sochungtu + "\" phải có ít nhất 1 mã hàng có số lượng duyệt lớn hơn 0<br>" +
                    " → Có thể kế hoạch đã được mua hết.</div>";
            }
        }

        if (msg == "")
        {
            db.SaveChanges();
            msg = msg_success;
            vnn = c_donmuahang_id.Split(',');
            //Start cap nhat Thue trong don mua hang
            foreach (c_donmuahang dmh in db.c_donmuahang.Where(s => vnn.Contains(s.c_donmuahang_id)).ToList())
            {
                var c_donmuahang_thues = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id);
                List<string> id_notdel = new List<string>();
                foreach (var thue_donhang_list in c_donmuahang_thues.Select(s => new { s.md_thue_sanpham_id, s.c_donmuahang_id }).Distinct().ToList())
                {
                    var c_donmuahang_thueschild = c_donmuahang_thues.Where(s => s.md_thue_sanpham_id == thue_donhang_list.md_thue_sanpham_id);
                    c_donmuahang_thue dmh_thue = c_donmuahang_thueschild.Take(1).FirstOrDefault();

                    dmh_thue.tong_tien_thue = c_donmuahang_thueschild.Select(s => s.tong_tien_thue).Sum();
                    dmh_thue.tong_tien_chiu_thue = c_donmuahang_thueschild.Select(s => s.tong_tien_chiu_thue).Sum();
                    id_notdel.Add(dmh_thue.c_donmuahang_thue_id);
                }


                foreach (c_donmuahang_thue dong_thue in c_donmuahang_thues.Where(s => !id_notdel.Contains(s.c_donmuahang_thue_id)).ToList())
                {
                    db.c_donmuahang_thue.Remove(dong_thue);
                }
            }
            db.SaveChanges();
            //End cap nhat Thue trong don mua hang

            //Start cap nhat don mua hang
            foreach (c_donmuahang dmh in db.c_donmuahang.Where(s => vnn.Contains(s.c_donmuahang_id)).ToList())
            {
                string ma_iso_tiente = db.md_dongtien.Where(s => s.md_dongtien_id == dmh.md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();
                decimal tong_tienhang = decimal.Parse("0.00");
                try
                {
                    tong_tienhang = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.thanhtien.Value).Sum();
                }
                catch { }
                decimal tong_tienthue = decimal.Parse("0.00");
                try { tong_tienthue = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.tong_tien_thue.Value).Sum(); } catch { }
                decimal tong_tatca = tong_tienhang + tong_tienthue;
                if (ma_iso_tiente == "VND")
                {
                    tong_tienhang = Math.Round(tong_tienhang, 0);
                    tong_tatca = Math.Round(tong_tatca, 0);
                }

                var tth = VNN_ConvertMoney.convert((double)tong_tienhang, ma_iso_tiente).FirstOrDefault();
                var ttc = VNN_ConvertMoney.convert((double)tong_tatca, ma_iso_tiente).FirstOrDefault();
                dmh.tong_tienhang = (decimal)tth.Value;
                dmh.tong_tatca = (decimal)ttc.Value;
                dmh.chu_tong_tienhang = tth.Key;
                dmh.chu_tong_tatca = ttc.Key;
            }
            db.SaveChanges();
            //End cap nhat don mua hang
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
                string ten_table = "c_kehoachmuavt";
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
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        try
        {
            string id = context.Request.Form["id"];
            var object_ = db.c_kehoachmuavt.Where(p => p.c_kehoachmuavt_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = @"false#Lỗi:Không tìm thấy đối tượng cần sửa.";
            }
            else if (md_trangthai_id == "SOANTHAO" & object_.md_trangthai_id == "HIEULUC")
            {
                msg = @"false#Lỗi:Không thể sửa trạng thái ""Hiệu lực"" thành ""Soạn Thảo"".";
            }
            else if (md_trangthai_id == "KETTHUC" & object_.md_trangthai_id == "SOANTHAO")
            {
                msg = @"false#Lỗi:Không thể sửa trạng thái ""Soạn Thảo"" thành ""Kết Thúc"".";
            }
            else if (md_trangthai_id == "HIEULUC")
            {
                int count = db.c_kehoachmuavt_cdh.
                        Where(s => s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id & s.sl_duyet > 0).Count();
                if (count <= 0)
                    msg = @"false#Lỗi:Phải có ít nhất 1 dòng hàng được duyệt.";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_kehoachmuavt";
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
            string ten_table = "c_kehoachmuavt";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                c_kehoachmuavt object_ = db.c_kehoachmuavt.Where(p => p.c_kehoachmuavt_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.c_donmuavattu_id != " ")
                {
                    msg_del = "Lỗi: Dòng \"" + object_.sochungtu + "\" đã tạo đơn mua vật tư.";
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id != "SOANTHAO")
                {
                    msg_del = "Lỗi: Dòng \"" + object_.sochungtu + "\" đã Hiệu Lực hoặc đã kết thúc, không thể xóa.";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string sct = object_.sochungtu;
                    foreach (c_yeucaumuavt ycmvt in db.c_yeucaumuavt.Where(s => s.c_kehoachmuavt_id.Contains(sct)))
                    {
                        if (ycmvt != null)
                        {
                            ycmvt.c_kehoachmuavt_id = ycmvt.c_kehoachmuavt_id.Replace("," + sct, "").Replace(sct + ",", "").Replace(sct, "");
                            if (ycmvt.c_kehoachmuavt_id == "") { ycmvt.c_kehoachmuavt_id = " "; }

                            foreach (c_yeucaumuavt_cdh ycmvt_cdh in db.c_yeucaumuavt_cdh.Where(s => s.c_yeucaumuavt_id == ycmvt.c_yeucaumuavt_id
                             & s.sapxep == object_.c_kehoachmuavt_id))
                            {
                                ycmvt_cdh.sapxep = null;
                            }
                        }
                    }
                    db.c_kehoachmuavt.Remove(object_);
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

public class khmvt_hh
{
    public string md_doitackinhdoanh_id;
    public string md_sanpham_id;
    public decimal sl_duyet;
    public decimal sl_conlai;
    public decimal sl_semua;
    public decimal sl_semua2;
    public decimal saiso;
    public string md_thue_sanpham_id;
    public string daidien;
    public string ma_sanpham;
    public string ma_dtkd;
    public string md_banggia_id;
    public string md_donvitinhsanpham_id;
}
