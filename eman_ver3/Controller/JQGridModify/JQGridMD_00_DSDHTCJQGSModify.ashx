e<%@ WebHandler Language="C#" Class="JQGridMD_00_DSDHTCJQGSModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using System.Collections.Generic;
using Newtonsoft.Json;
public class JQGridMD_00_DSDHTCJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public partial class VNN
    {
        public string dauma { get; set; }
        public decimal? tongCBM { get; set; }
        public decimal? cbmDatDuoc { get; set; }
        public int tuan { get; set; }
        public int nam { get; set; }
        public DateTime ngaydukien { get; set; }
        public DateTime ngayketthuc { get; set; }
    }

    List<VNN> vNNs = new List<VNN>();
    EntityContext db = new EntityContext();
    Public pub = new Public();
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
            case "CA01UpdateDSX_MD00DSDHTCJQGS":
                this.CA01UpdateDSX_MD00DSDHTCJQGS(context);
                break;
            case "CA01DCHT_MD00DSDHTCJQGS": // Hieu Luc
                this.CA01DCHT_MD00DSDHTCJQGS(context);
                break;
            case "CA_01_CopyDonHang":
                this.CA_01_CopyDonHang(context);
                break;
            case "CA_01_HuyBoDonHangTN":
                this.CA_01_HuyBoDonHangTN(context);
                break;
            case "CA_01_TinhNangLuc":
                this.CA_01_TinhNangLuc(context, 0, db);
                break;
            default:
                break;
        }
    }

    public string CA_01_TinhNangLuc(HttpContext context, int type, EntityContext db)
    {
        string poId = context.Request.Form["id"];
        var donhang = db.c_danhsachdathang.Where(dh => dh.c_danhsachdathang_id == poId).FirstOrDefault();
        DataTable dt = pub.TinhNangLuc(donhang, db);
        string result = "";
        string ngaylap = donhang.ngaylap.Value.ToString("dd/MM/yyyy");
        //DataTable dt = Mbg.Data.SqlClient.SqlHelper.GetData("select * from dbo.f_tinhNangLucCungUng('" + poId + "')");
        DateTime maxDate = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null);
        int max_tgnhan_dh = -1, max_tgantoan_dh = -1;
        int colCount = dt.Columns.Count;
        int rowCount = dt.Select("tong_cbmcandat >= 0").Count();
        int check = dt.Select("result_nhandh = 0 or result = 0").Count();
        string folder = Security.UrlBase() + "images/icon/";
        if (rowCount > 0)
        {
            result += "<div style=\"height:450px; overflow:auto\"><table class=\"view-capacity\">";
            result += String.Format("<tr style=\"background:green; color:white\"><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>"
                    , "Nhóm Năng Lực", "Tổng CBM Cần Đặt", "CBM Đặt Được", "Thời Gian Dự Kiến", "Tuần Thứ", "Thời Gian Yêu Cầu", "Đánh Giá Năng Lực Cung Ứng");

            vNNs.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = new VNN();
                item.dauma = row[0].ToString();
                item.tongCBM = decimal.Parse(row[2].ToString());
                item.cbmDatDuoc = decimal.Parse(row[3].ToString());
                item.ngaydukien = (DateTime)row[4];
                item.ngayketthuc = (DateTime)row[6];
                item.tuan = (int)row[5];
                item.nam = ((DateTime)row[6]).Year;
                vNNs.Add(item);

                result += "<tr>";
                result += String.Format("<td>{0}</td>", row[0]);
                result += String.Format("<td>{0}</td>", decimal.Parse(row[2].ToString()).DropTrailingZeros());
                result += String.Format("<td>{0}</td>", decimal.Parse(row[3].ToString()).DropTrailingZeros());
                result += String.Format("<td>{0}</td>", ((DateTime)row[4]).ToString("dd/MM/yyyy"));
                result += String.Format("<td>{0}</td>", row[5]);
                result += String.Format("<td>{0}</td>", ((DateTime)row[6]).ToString("dd/MM/yyyy"));
                result += String.Format("<td><img src=\"{0}\"/></td>", row[10].ToString() == "True" ? folder + "tick-icon.png" : folder + "del.png");
                result += "</tr>";

                if (row[10].ToString() == "1")
                {
                    var ngaydukien = DateTime.Parse(row[4].ToString());
                    var tgnhan_dh = (int)row["tgnhan_dh"];
                    var tgantoan_dh = (int)row["tgantoan_dh"];
                    if (maxDate < ngaydukien)
                        maxDate = ngaydukien;

                    if (max_tgantoan_dh < tgantoan_dh)
                        max_tgantoan_dh = tgantoan_dh;

                    if (max_tgnhan_dh < tgnhan_dh)
                        max_tgnhan_dh = tgnhan_dh;
                }
            }
            result += "</table></div>";

            if (check > 0)
            {
                DateTime? ngaydk = null;
                foreach (var row in dt.AsEnumerable().GroupBy(s=>s["thoigianyeucau"])
                        .Select(s=> new {
                            tgyc = (DateTime)s.Key,
                            tgdk = s.Max(t=>(DateTime)t["thoigiandukien"]),
                            tgnhandh = s.Max(t=>(int)t["tgnhan_dh"]),
                            tgantoan_dh = s.Max(t=>(int)t["tgantoan_dh"])
                        }))
                {
                    var ngay_dh = donhang.ngaylap;
                    if (row.tgdk < row.tgyc & row.tgnhandh > row.tgantoan_dh)
                        ngaydk = row.tgyc;
                    else if (row.tgdk < row.tgyc & row.tgnhandh < row.tgantoan_dh)
                        ngaydk = ngay_dh.Value.AddDays(row.tgnhandh);
                    else if (row.tgdk > row.tgyc & row.tgnhandh > row.tgantoan_dh)
                        ngaydk = row.tgdk;
                    else
                        ngaydk = row.tgdk;

                }
                //         //tinh thoi gian du kien 
                //         string sql_dk = @"select case when (tgdk < tgyc and tgnhandh > tgantoan_dh) then tgyc
                //		when (tgdk < tgyc and tgnhandh < tgantoan_dh) then ngay_dh + tgnhandh
                //		when (tgdk > tgyc and tgnhandh > tgantoan_dh) then tgdk
                //		else tgdk
                //		end
                //from(
                //		select MAX(thoigiandukien) tgdk, thoigianyeucau tgyc, max(tgnhan_dh) tgnhandh, max(tgantoan_dh) tgantoan_dh, convert(datetime,'" + ngaylap + "',103) as ngay_dh" +
                //                                 " from f_tinhNangLucCungUng('" + poId + "')" +
                //                                 " group by thoigianyeucau) as tmp";
                //         DateTime ngaydk = (DateTime)Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(sql_dk);
                result = "<div style=\"padding:15px; border:1px solid red; background:#ffadad;\"><h3>Năng lực nhà cung ứng không đáp ứng được đơn hàng này.!<br/>Ngày dự kiến: " + ngaydk.Value.ToString("dd/MM/yyyy") + "</h3></div>" + result;
            }
            else
            {

                //string sql_tongcandat = string.Format(@"SELECT sum(ddh.v2 * ddh.sl_conlai) as tcbm from c_dongdsdh ddh where ddh.c_danhsachdathang_id ='{0}'", poId);
                //string sql_slCandat = @"select isnull(SUM(cbm_candat), 0) from f_tinhNangLucCungUng('" + poId + "')";
                //string tong = Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(sql_tongcandat).ToString();
                decimal slTongCanDat = 0;
                if (donhang.anco_check.GetValueOrDefault(false) == false)
                {
                    slTongCanDat = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == donhang.c_danhsachdathang_id).Sum(s => s.v2 * s.sl_dathang).GetValueOrDefault(0);
                }
                else
                {
                    slTongCanDat = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == donhang.c_danhsachdathang_id).Sum(s => s.sl_dathang).GetValueOrDefault(0);
                }
                decimal slCanDat = dt.AsEnumerable().Sum(s => (decimal)s["cbm_candat"]);

                if (slCanDat < slTongCanDat)
                {
                    result = "<div style=\"padding:15px; border:1px solid red; background:#ffadad;\"><h3>Năng lực nhà cung ứng không đáp ứng được đơn hàng này.!</h3>Năng lực Cung Ứng: " + slCanDat.DropTrailingZeros() + ", CBM Đơn Hàng: " + slTongCanDat.DropTrailingZeros() + "</div>" + result;
                }
                else
                {
                    if (check == 0 && slCanDat >= slTongCanDat)
                    {
                        result = "<div style=\"padding:15px; border:1px sold green; background:#b9fdbf;\"><h3>Năng lực nhà cung ứng đáp ứng được đơn hàng này.!</h3>Năng lực Cung Ứng: " + slCanDat.DropTrailingZeros() + ", CBM Đơn Hàng: " + slTongCanDat.DropTrailingZeros() + "</div>" + result;
                    }
                    else
                    {
                        //string sql_chk_lai_tongcandat = @"select isnull(sum(tmp.tong_cbmcandat), 0) from (select distinct dauma, tong_cbmcandat from f_tinhNangLucCungUng('" + poId + "')) as tmp";
                        //decimal sl_chk_lai_TongCanDat = decimal.Parse(Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(sql_chk_lai_tongcandat).ToString());

                        decimal sl_chk_lai_TongCanDat = dt.AsEnumerable().Select(s => new
                        {
                            dauma = s["dauma"],
                            tong_cbmcandat = (decimal)s["tong_cbmcandat"]
                        }).Distinct().Sum(s => s.tong_cbmcandat);

                        if (slCanDat >= sl_chk_lai_TongCanDat)
                        {
                            result = "<div style=\"padding:15px; border:1px solid green; background:#b9fdbf;\"><h3>Năng lực nhà cung ứng đáp ứng được đơn hàng này.!</h3>" + (slCanDat >= slTongCanDat) + "</div>" + result;
                        }
                        else
                        {
                            result = "<div style=\"padding:15px; border:1px solid red; background:#ffadad;\"><h3>Không đủ dữ liệu để tính năng lực.! </h3></div>" + result;
                        }
                    }
                }
            }

            if (donhang != null)
            {
                donhang.check_nangluc = true;
                db.SaveChanges();
            }
        }
        else
        {
            result += string.Format(@"
                <div style=""padding:15px; border:1px solid red; background:#b9fdbf;"">
                    <b>Tuần {0} Năm {1}</b> chưa có đủ thông tin về năng lực sản xuất.!
                </div>", dt.Rows[0]["tuanthu"], dt.Rows[0]["nam"]);
        }

        if (type == 0)
        {
            db.Dispose();
            context.Response.Write(result);
        }
        return result;
    }

    public void CA_01_HuyBoDonHangTN(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string check_1 = context.Request.Form["check"];
        string[] vnn = id.Split(',');
        try
        {
            foreach (var dsdh in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)).ToList())
            {
                if (dsdh.trangthai != "DANHAN" & dsdh.trangthai != "SOANTHAO")
                {
                    if (check_1 == "1")
                    {
                        dsdh.trangthai = "HUYBO";
                        msg_success = "<div style='color:blue'> Hủy bỏ đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "2")
                    {
                        dsdh.trangthai = "KETTHUC";
                        msg_success = "<div style='color:blue'> Kết thúc đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "3" & dsdh.anco_check == false)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Khởi động lại đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "3" & dsdh.anco_check == true)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Khởi động lại đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "4" & dsdh.anco_check == false)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Kích hoạt đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "4" & dsdh.anco_check == true)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Kích hoạt đơn hàng thành công.</div>";
                    }
                }
                else
                {
                    msg = "<div style='color:red'>Đơn hàng chưa hiệu lực.</div>";
                }
            }
            if (msg.Length <= 0)
            {
                db.SaveChanges();
                msg = msg_success;
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
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

    public void CA_01_CopyDonHang(HttpContext context)
    {
        string msg = "";
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);
        c_danhsachdathang dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id).FirstOrDefault();
        if (dsdh == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm thấy đơn hàng đã chọn.</div>" + "###" + "";
        }
        else
        {
            string id_new = Helper.getNewId();
            var dsdh_new = Clone(dsdh);
            dsdh_new.c_danhsachdathang_id = id_new;
            dsdh_new.sochungtu = sochungtu;
            dsdh_new.so_po = sochungtu;
            dsdh_new.trangthai = "SOANTHAO";
            dsdh_new.md_trangthai_id = "HIEULUC";
            db.c_danhsachdathang.Add(dsdh_new);

            foreach (var dongdsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id))
            {
                var dongdsdh_new = Clone(dongdsdh);
                dongdsdh_new.c_dongdsdh_id = Helper.getNewId();
                dongdsdh_new.c_danhsachdathang_id = id_new;
                dongdsdh_new.sl_giamhanngach = 0;
                dongdsdh_new.sl_conlai = dongdsdh_new.sl_dathang - dongdsdh_new.sl_giamhanngach;
                db.c_dongdsdh.Add(dongdsdh_new);
            }

            foreach (var pdh in db.c_phidathang.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id))
            {
                var pdh_new = Clone(pdh);
                pdh_new.c_phidathang_id = Helper.getNewId();
                pdh_new.c_danhsachdathang_id = id_new;
                db.c_phidathang.Add(pdh_new);
            }
            db.SaveChanges();
            msg = "<div style='color:blue'>Tạo mới đơn hàng \"" + sochungtu + "\" thành công.</div>" + "###" + id_new;
        }
        context.Response.Write(msg);
    }

    public void CA01DCHT_MD00DSDHTCJQGS(HttpContext context)
    {
        User_TK us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        var dsdhId = new List<string>();
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                foreach (var dsdh in db.c_danhsachdathang.
                        Where(s => vnn.Contains(s.c_danhsachdathang_id)).
                        OrderByDescending(s => s.ngaylap).ToList())
                {
                    if (dsdh.trangthai == "HIEULUC")
                    {
                        msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hiệu lực.</div>";
                    }
                    else if (dsdh.trangthai == "HUYBO")
                    {
                        msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hủy.</div>";
                    }
                    else if (dsdh.trangthai == "KETTHUC")
                    {
                        msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã kết thúc.</div>";
                    }
                    else if (dsdh.md_trangthai_id != "HIEULUC")
                    {
                        msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã được đối chiếu hàng tồn.</div>";
                    }
                    else
                    {
                        VNN_Function.SetFormValue("id", dsdh.c_danhsachdathang_id);
                        string msgTNL = CA_01_TinhNangLuc(context, 1, db);
                        if (!msgTNL.ToLower().Contains("năng lực nhà cung ứng đáp ứng được đơn hàng này"))
                        {
                            msg += "<div style='color:red'>Lỗi:không đủ năng lực để nhận Đơn hàng " + dsdh.sochungtu + " .</div>";
                            msg += msgTNL;
                        }
                        else
                        {
                            var range = db.c_danhsachdathang_nangluc.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id);
                            db.c_danhsachdathang_nangluc.RemoveRange(range);
                            db.SaveChanges();
                            foreach (var item in vNNs)
                            {
                                var nangluc = new c_danhsachdathang_nangluc
                                {
                                    c_danhsachdathang_nangluc_id = Helper.getNewId(),
                                    c_danhsachdathang_id = dsdh.c_danhsachdathang_id,
                                    dauma = item.dauma,
                                    CBMdatduoc = item.cbmDatDuoc.GetValueOrDefault(0),
                                    tongCBM = item.tongCBM.GetValueOrDefault(0),
                                    thoigiandukien = item.ngaydukien,
                                    thoigianyeucau = item.ngayketthuc,
                                    tuanthu = item.tuan,
                                    danhgia = true,
                                    hoatdong = true,
                                    ngaycapnhat = DateTime.Now,
                                    ngaytao = DateTime.Now,
                                    nguoicapnhat = us.ad_user_id,
                                    nguoitao = us.ad_user_id,
                                    mota = ""
                                };
                                db.c_danhsachdathang_nangluc.Add(nangluc);
                                db.SaveChanges();

                                var dongNL = db.md_nangluc.
                                        Where(s => s.nam == item.nam & s.tuan == item.tuan & s.hehang == item.dauma).FirstOrDefault();
                                if (dongNL != null)
                                {
                                    dongNL.soluongdadat = dongNL.soluongdadat + item.cbmDatDuoc.GetValueOrDefault(0);
                                    dongNL.soluongconlai = dongNL.nangsuat - dongNL.soluongdadat.GetValueOrDefault(0);
                                    db.SaveChanges();
                                }
                            }

                            string id_dc = Helper.getNewId();
                            var dc = new c_doichieuhangton
                            {
                                c_doichieuhangton_id = id_dc,
                                c_danhsachdathang_id = dsdh.c_danhsachdathang_id,
                                so_donhang = dsdh.sochungtu,
                                ten_donhang = "KHDH-" + dsdh.sochungtu,
                                donhang_thamchieu = dsdh.so_po,
                                kehoach = " ",
                                doichieuht = false,
                                phieuhangton = " ",
                                ngaykehoach = DateTime.Now,
                                ngayhoanthanh = dsdh.ngayhoanthanh,

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
                            db.c_doichieuhangton.Add(dc);
                            db.SaveChanges();
                            //tao cac dong don hang
                            foreach (var ddsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).ToList())
                            {
                                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == ddsdh.md_sanpham_id).FirstOrDefault();
                                if (sp == null)
                                {
                                    msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " chưa có dữ liệu của hàng hóa.</div>";
                                }

                                var cddh = new c_doichieuhangton_cddh
                                {
                                    c_doichieuhangton_cddh_id = Helper.getNewId(),
                                    c_doichieuhangton_id = id_dc,
                                    md_sanpham_id = ddsdh.md_sanpham_id,
                                    md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
                                    mota_tiengviet = sp.mota_tiengviet,
                                    mota_tienganh = sp.mota_tienganh,
                                    sl_dathang = ddsdh.sl_dathang,
                                    sl_giamhanngach = ddsdh.sl_giamhanngach,
                                    mota = dsdh.mota,

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
                                db.c_doichieuhangton_cddh.Add(cddh);
                            }
                            db.SaveChanges();
                            if (dsdh.anco_check == true)
                            {
                                dsdhId.Add(dsdh.c_danhsachdathang_id);
                            }
                            //dsdh.md_trangthai_id = "DATAO";
                            dsdh.trangthai = "HIEULUC";
                            dsdh.dg_nangluc = true;
                            db.SaveChanges();
                            msg_success += "<div style='color:blue'>Đơn hàng " + dsdh.sochungtu + " được hiệu lực thành công.</div>";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            if (msg.Length <= 0 & dsdhId.Count > 0)
            {
                var item = new Dictionary<string, object>();
                item["result"] = id;
                item["trangthai"] = "DAHIEULUC";
                //msg = VNN_VariablePublic.GetModule(
                //    VNN_VariablePublic.API_AncoTrading + "?oper=CapNhatTrangThaiDonHang",
                //    item
                //);
            }

            if (msg.Length <= 0)
            {
                msg = msg_success;
                transaction.Commit();
            }
            else
                transaction.Rollback();
        }

        context.Response.Write(msg);
    }

    public void CA01UpdateDSX_MD00DSDHTCJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string[] vnn = context.Request.Form["id"].Split(',');
        string thoigiansx = context.Request.Form["thoigiansx"];
        string thoigianht = context.Request.Form["thoigianht"];
        foreach (var dsdh in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)).ToList())
        {
            if (dsdh.trangthai == "HIEULUC")
            {
                msg += "<div style='color:red'>Lỗi: Dòng " + dsdh.sochungtu + " đã hiệu lực.</div>";
            }
            else if (dsdh.trangthai == "HUYBO")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hủy.</div>";
            }
            else if (dsdh.trangthai == "KETTHUC")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã kết thúc.</div>";
            }
            else if (dsdh.trangthai != "DANHAN")
            {
                msg += "<div style='color:red'>Lỗi: Dòng " + dsdh.sochungtu + " chưa được xác nhận.</div>";
            }
            else
            {
                dsdh.thoigiansx = int.Parse(thoigiansx);
                dsdh.ngaybatdau = dsdh.hangiaohang_po - TimeSpan.Parse(thoigiansx) - TimeSpan.Parse(thoigianht);
                dsdh.ngayhoanthanh = dsdh.hangiaohang_po - TimeSpan.Parse(thoigianht);
                db.SaveChanges();
                msg += "<div style='color:blue'>Dòng " + dsdh.sochungtu + " đã cập nhật thời gian sản xuất thành công.</div>";
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string so_po = context.Request.Form["so_po"].Trim();
        string sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);

        try
        {
            int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
            int thoigianht = int.Parse(context.Request.Form["thoigianht"]);
            DateTime ngaylap = VNN_Config.setDateTime(context.Request.Form["ngaylap"]);
            DateTime hangiaohang_po = VNN_Config.setDateTime(context.Request.Form["hangiaohang_po"]);
            string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
            string id = context.Request.QueryString["id"];
            DateTime ngaybatdau = hangiaohang_po.AddDays(0 - thoigiansx).AddDays(0 - thoigianht);
            DateTime ngayhoanthanh = hangiaohang_po.AddDays(0 - thoigianht);
            if (ngaylap == null)
            {
                msg = "false#Lỗi:Chưa có ngày lập đơn hàng.";
            }
            else if (hangiaohang_po == null)
            {
                msg = "false#Lỗi:Chưa có hạng giao hàng.";
            }
            else if (string.IsNullOrEmpty(so_po.Trim()))
            {
                msg = string.Format(@"false#Lỗi:Số đơn hàng không thể để trống.");
            }
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_trangthai_id", "sochungtu", "ngaybatdau", "ngayhoanthanh", "anco_check" };
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtk_id);
                VNN_Function.SetFormValue("ngaybatdau", ngaybatdau.ToString(VNN_Config.get_FormatDate()));
                VNN_Function.SetFormValue("ngayhoanthanh", ngayhoanthanh.ToString(VNN_Config.get_FormatDate()));
                VNN_Function.SetFormValue("md_trangthai_id", "HIEULUC");
                VNN_Function.SetFormValue("anco_check", "false");
                VNN_Function.SetFormValue("sochungtu", sochungtu);
                VNN_Function.SetFormValue("thoigiansx", thoigiansx.ToString());
                string ten_table = "c_danhsachdathang";
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
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string so_po = context.Request.Form["so_po"];
        //string sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);
        //int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
        string trangthai = context.Request.Form["trangthai"];
        try
        {

            string id = context.Request.Form["id"];
            c_danhsachdathang object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id == id).FirstOrDefault();
            int count = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Count();
            string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa.";
            }
            else if (trangthai == "HIEULUC")
            {
                msg = "false#Lỗi:Không thể hiệu lực tại đây.";
            }
            else if (object_.trangthai == "HIEULUC")
            {
                msg = "false#Lỗi:Đơn hàng đã hiệu lực không thể sửa.";
            }
            else if (object_.trangthai == "HUYBO")
            {
                msg += "false#Lỗi:Đơn hàng " + object_.sochungtu + " đã hủy.";
            }
            else if (object_.trangthai == "KETTHUC")
            {
                msg += "false#Lỗi:Đơn hàng " + object_.sochungtu + " đã kết thúc.";
            }
            else if (count <= 0 & trangthai == "HIEULUC")
            {
                msg = "false#Lỗi:Đơn hàng chưa có dòng đơn hàng không thể hiệu lực.";
            }
            else if (string.IsNullOrEmpty(so_po.Trim()))
            {
                msg = string.Format(@"false#Lỗi:Số đơn hàng không thể để trống.");
            }
            int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
            int thoigianht = int.Parse(context.Request.Form["thoigianht"]);
            DateTime ngaylap = VNN_Config.setDateTime(context.Request.Form["ngaylap"]);
            DateTime hangiaohang_po = VNN_Config.setDateTime(context.Request.Form["hangiaohang_po"]);
            DateTime ngaybatdau = hangiaohang_po.AddDays(0 - thoigiansx).AddDays(0 - thoigianht);
            DateTime ngayhoanthanh = hangiaohang_po.AddDays(0 - thoigianht);
            /*int thoigiansx = 0;
            TimeSpan t = hangiaohang_po - ngaybatdau;
            int NrOfDays = (int)Math.Round((decimal)t.TotalDays, 0);
            thoigiansx = NrOfDays;*/


            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { "md_trangthai_id", "sochungtu", "thoigiansx", "ngaybatdau", "ngayhoanthanh", "anco_check" };
                VNN_Function.SetFormValue("ngaybatdau", ngaybatdau.ToString(VNN_Config.get_FormatDate()));
                VNN_Function.SetFormValue("ngayhoanthanh", ngayhoanthanh.ToString(VNN_Config.get_FormatDate()));
                VNN_Function.SetFormValue("md_trangthai_id", "HIEULUC");
                VNN_Function.SetFormValue("anco_check", "false");
                VNN_Function.SetFormValue("thoigiansx", thoigiansx.ToString());
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", "VNN_notpost");
                VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                VNN_Function.SetFormValue("so_po", so_po);
                string ten_table = "c_danhsachdathang";
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
            string ten_table = "c_danhsachdathang";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                c_danhsachdathang object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi dòng " + i + ": Không tìm thấy đối tượng cần xóa.";
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "HUYBO")
                {
                    msg_del = "<div style='color:red'>Lỗi:Đơn hàng " + object_.sochungtu + " đã hủy.</div>";
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "KETTHUC")
                {
                    msg_del = "<div style='color:red'>Lỗi:Đơn hàng " + object_.sochungtu + " đã kết thúc.</div>";
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "<div style='color:red'>Lỗi:Đơn hàng " + object_.sochungtu + " đã hiệu lực.</div>";
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id != "HIEULUC")
                {
                    msg_del = "Lỗi dòng: " + i + ":Đã hiệu lực không thể xóa.";
                    msg += msg_del + "\n";
                }
                else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Count() > 0)
                {
                    msg_del = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã tạo phiếu giảm hạn ngạch.", object_.sochungtu);
                    msg += msg_del + "<br>";
                }


                if (msg_del.Length <= 0)
                {
                    db.c_danhsachdathang.Remove(object_);
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