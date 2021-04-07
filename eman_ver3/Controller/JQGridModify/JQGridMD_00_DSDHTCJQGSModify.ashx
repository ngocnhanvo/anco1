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
    Public pub = new Public();

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
        int rowCount = dt.Select("tong_cbmcandat > 0").Count();
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

            decimal slTongCanDat = 0;
            if (donhang.anco_check.GetValueOrDefault(false) == false)
            {
                slTongCanDat = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == donhang.c_danhsachdathang_id).Sum(s => s.v2 * s.sl_dathang).GetValueOrDefault(0);
            }
            else
            {
                slTongCanDat = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == donhang.c_danhsachdathang_id).Sum(s => s.v2).GetValueOrDefault(0);
            }
            decimal slCanDat = dt.AsEnumerable().Sum(s => (decimal)s["cbm_candat"]);

            if (check > 0)
            {
                DateTime? ngaydk = null, ngayyc = null;
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
                    ngayyc = row.tgyc;
                }

                string spanNDKYC = "color:green", spanSLCDTCD = "color:green";
                if(ngaydk > ngayyc)
                    spanNDKYC = "color:red";
                if(slTongCanDat > slCanDat)
                    spanSLCDTCD = "color:red";
                result = string.Format(@"
				<div style=""padding:15px; border:1px solid red; background:#ffadad;"">
					<h3 style=""margin:0px;"">
						Năng lực nhà cung ứng không đáp ứng được đơn hàng này.!
						<div style=""padding: 10px 0px 5px 0px;font-size: 90% !important;"">Ngày dự kiến: <span style=""{5}"">{0}</span>, Ngày yêu cầu: <span style=""{5}"">{1}</span></div>
						<div style=""padding: 5px 0px 5px 0px;font-size: 90% !important;"">Năng lực Cung Ứng: <span style=""{6}"">{2}</span>, CBM Đơn Hàng: <span style=""{6}"">{3}</span></div>
					</h3>
				</div>{4}",
                ngaydk.Value.ToString("dd/MM/yyyy"),
                ngayyc.Value.ToString("dd/MM/yyyy"),
                slCanDat.DropTrailingZeros(),
                slTongCanDat.DropTrailingZeros(),
                result,
                spanNDKYC,
                spanSLCDTCD
                );
            }
            else
            {
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

    public void CA_01_CopyDonHang(HttpContext context)
    {
        string msg = "";
        string id = context.Request.Form["id"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);
        var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id).FirstOrDefault();
        if (dsdh == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm thấy đơn hàng đã chọn.</div>" + "###" + "";
        }
        else
        {
            string id_new = Helper.getNewId();
            var dsdh_new = dsdh.Clone();
            dsdh_new.c_danhsachdathang_id = id_new;
            dsdh_new.sochungtu = sochungtu;
            dsdh_new.so_po = sochungtu;
            dsdh_new.trangthai = "SOANTHAO";
            dsdh_new.md_trangthai_id = "HIEULUC";
            db.c_danhsachdathang.Add(dsdh_new);

            foreach (var dongdsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).ToList())
            {
                var dongdsdh_new = dongdsdh.Clone();
                dongdsdh_new.c_dongdsdh_id = Helper.getNewId();
                dongdsdh_new.c_danhsachdathang_id = id_new;
                dongdsdh_new.sl_giamhanngach = 0;
                dongdsdh_new.sl_conlai = dongdsdh_new.sl_dathang - dongdsdh_new.sl_giamhanngach;
                db.c_dongdsdh.Add(dongdsdh_new);
            }

            foreach (var pdh in db.c_phidathang.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).ToList())
            {
                var pdh_new = pdh.Clone();
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
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        var dsdhId = new List<string>();
		var dcHTIds = new List<string>();
		
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
				else if (dsdh.trangthai == "DAGUI")
				{
					msg += string.Format(@"<div style='color:red'>Lỗi:Đơn hàng ""{0}"" chưa nhận hàng.</div>", dsdh.sochungtu);
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
					if (msgTNL.ToLower().Contains("Hủy bắt lỗi khi năng lực không đủ."))
					{
						msg += "<div style='color:red'>Lỗi:không đủ năng lực để nhận Đơn hàng " + dsdh.sochungtu + " .</div>";
						msg += msgTNL;
					}
					else
					{
						var range = db.c_danhsachdathang_nangluc.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id);
						db.c_danhsachdathang_nangluc.RemoveRange(range);
						
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
								nguoicapnhat = userTK.ad_user_id,
								nguoitao = userTK.ad_user_id,
								mota = ""
							};
							db.c_danhsachdathang_nangluc.Add(nangluc);

							var dongNL = db.md_nangluc.
									Where(s => s.nam == item.nam & s.tuan == item.tuan & s.hehang == item.dauma).FirstOrDefault();
							if (dongNL != null)
							{
								dongNL.soluongdadat = dongNL.soluongdadat + item.cbmDatDuoc.GetValueOrDefault(0);
								dongNL.soluongconlai = dongNL.nangsuat - dongNL.soluongdadat.GetValueOrDefault(0);
							}
						}
						
						var dchtId = Helper.getNewId();
						var kh = new c_kehoachdathang();
						kh.c_kehoachdathang_id = Helper.getNewId();
						kh.xulykehoach = false;
						kh.c_doichieuhangton_id = dchtId;
						kh.mota = "";
						kh.ngaybatdausx = dsdh.ngaybatdau;
						kh.sodonhang = dsdh.sochungtu;
						kh.ten_kh = "KHDH-" + dsdh.sochungtu;
						kh.ngaykehoach = DateTime.Now;
						kh.donhang_thamchieu = dsdh.so_po;
						kh.trangthai = "SOANTHAO";
						kh.nguoitao = userTK.ad_user_id;
						kh.vaitrotao = userTK.ad_role_id;
						kh.bophantao = userTK.md_phongban_id;
						kh.value_nguoitao = userTK.ma_user;
						kh.value_vaitrotao = userTK.ten_role;
						kh.value_bophantao = userTK.ten_phongban;
						kh.nguoicapnhat = userTK.ad_user_id;
						kh.vaitrocapnhat = userTK.ad_role_id;
						kh.bophancapnhat = userTK.md_phongban_id;
						kh.value_nguoicapnhat = userTK.ma_user;
						kh.value_vaitrocapnhat = userTK.ten_role;
						kh.value_bophancapnhat = userTK.ten_phongban;
						kh.ngaytao = DateTime.Now;
						kh.ngaycapnhat = DateTime.Now;
						kh.hoatdong = true;
						db.c_kehoachdathang.Add(kh);
						
						var dc = new c_doichieuhangton
						{
							c_doichieuhangton_id = dchtId,
							c_danhsachdathang_id = dsdh.c_danhsachdathang_id,
							so_donhang = kh.sodonhang,
							ten_donhang = kh.ten_kh,
							donhang_thamchieu = dsdh.so_po,
							kehoach = kh.ten_kh,
							doichieuht = true,
							phieuhangton = " ",
							ngaykehoach = DateTime.Now,
							ngayhoanthanh = dsdh.ngayhoanthanh,

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
							hoatdong = true
						};
						db.c_doichieuhangton.Add(dc);
						
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
								c_doichieuhangton_id = dc.c_doichieuhangton_id,
								md_sanpham_id = ddsdh.md_sanpham_id,
								md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
								mota_tiengviet = sp.mota_tiengviet,
								mota_tienganh = sp.mota_tienganh,
								sl_dathang = ddsdh.sl_dathang,
								sl_giamhanngach = ddsdh.sl_giamhanngach,
								mota = dsdh.mota,

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
								hoatdong = true
							};
							db.c_doichieuhangton_cddh.Add(cddh);
							
							var cdhcd = new c_kehoachdathang_cdhcd
							{
								c_kehoachdathang_cdhcd_id = Helper.getNewId(),
								c_kehoachdathang_id = kh.c_kehoachdathang_id,
								md_sanpham_id = ddsdh.md_sanpham_id,
								md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
								macuoi = sp.ma_sanpham,
								sl_giamhanngach = 0,
								sl_candat = ddsdh.sl_dathang - ddsdh.sl_giamhanngach.GetValueOrDefault(0),
								sl_phanphoi = ddsdh.sl_dathang - ddsdh.sl_giamhanngach.GetValueOrDefault(0),
								md_doitackinhdoanh_id = sp.nhacungung,
								md_phanxuong_id = sp.md_phanxuong_id,
								noigiaohang = sp.noigiaohang,

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
								hoatdong = true
							};
							db.c_kehoachdathang_cdhcd.Add(cdhcd);
						}
						
						//db.SaveChanges();
						if (dsdh.anco_check == true)
						{
							dsdhId.Add(dsdh.c_danhsachdathang_id);
						}
						//dsdh.md_trangthai_id = "DATAO";
						dsdh.trangthai = "HIEULUC";
						dsdh.dg_nangluc = true;
						msg_success += "<div style='color:blue'>Đơn hàng " + dsdh.sochungtu + " được hiệu lực thành công.</div>";
					}
				}
			}
		}
		catch(Exception ex)
		{
			msg = ex.Message;
		}
		
		if (msg.Length <= 0)
		{
			msg = msg_success;
			db.SaveChanges();
		}

        context.Response.Write(msg);
    }

    public void CA01UpdateDSX_MD00DSDHTCJQGS(HttpContext context)
    {
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
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["khachhang"];
        string so_po = context.Request.Form["so_po"].Trim();

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);
                int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
                int thoigianht = int.Parse(context.Request.Form["thoigianht"]);
                DateTime ngaylap = VNN_Config.setDateTime(context.Request.Form["ngaylap"]);
                DateTime hangiaohang_po = VNN_Config.setDateTime(context.Request.Form["hangiaohang_po"]);
                string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
                string id = context.Request.QueryString["id"];
                DateTime ngaybatdau = hangiaohang_po.AddDays(0 - thoigiansx);
                DateTime ngayhoanthanh = hangiaohang_po.AddDays(-10);
                if (ngaylap == null)
                {
                    msg = "Lỗi:Chưa có ngày lập đơn hàng.";
                }
                else if (hangiaohang_po == null)
                {
                    msg = "Lỗi:Chưa có hạng giao hàng.";
                }
                else if (string.IsNullOrEmpty(so_po.Trim()))
                {
                    msg = string.Format(@"Lỗi:Số đơn hàng không thể để trống.");
                }
                else
                {
                    var countPO = db.c_danhsachdathang.Where(s => s.so_po == so_po).Count();
                    if (countPO > 0)
                        msg = string.Format(@"Lỗi:Số đơn hàng đã tồn tại.");
                }
                if (msg.Length <= 0)
                {
                    var object_ = new c_danhsachdathang();
                    object_.c_danhsachdathang_id = id_new;
                    object_.md_trangthai_id = "HIEULUC";
                    object_.ngaybatdau = ngaybatdau;
                    object_.ngayhoanthanh = ngayhoanthanh;
                    object_.anco_check = false;
                    VNN_Function.SetFormValue(object_.nameof(s=>s.md_doitackinhdoanh_id), dtk_id);
                    VNN_Function.SetFormValue(object_.nameof(s=>s.ngayhoanthanh), ngayhoanthanh.ToString(VNN_Config.get_FormatDate()));
                    VNN_Function.SetFormValue(object_.nameof(s=>s.sochungtu), sochungtu);
                    VNN_Function.SetFormValue(object_.nameof(s=>s.thoigiansx), thoigiansx.ToString());
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    db.c_danhsachdathang.Add(object_);
                    db.SaveChanges();
                }
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
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string so_po = context.Request.Form["so_po"].Trim();
        string trangthai = context.Request.Form["trangthai"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
                string id = context.Request.Form["id"];
                var object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id == id).FirstOrDefault();
                int count = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Count();
                string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa.";
                }
                else if (object_.trangthai == "HUYBO")
                {
                    msg += "Lỗi:Đơn hàng " + object_.sochungtu + " đã hủy.";
                }
                else if (string.IsNullOrEmpty(so_po))
                {
                    msg = string.Format(@"Lỗi:Số đơn hàng không thể để trống.");
                }
                else
                {
                    var countPO = db.c_danhsachdathang.Where(s => s.so_po == so_po & s.c_danhsachdathang_id != object_.c_danhsachdathang_id).Count();
                    if (countPO > 0)
                        msg = string.Format(@"Lỗi:Số đơn hàng đã tồn tại.");
                }
                int thoigianht = int.Parse(context.Request.Form["thoigianht"]);
                DateTime ngaylap = VNN_Config.setDateTime(context.Request.Form["ngaylap"]);
                DateTime hangiaohang_po = VNN_Config.setDateTime(context.Request.Form["hangiaohang_po"]);
                DateTime ngaybatdau = hangiaohang_po.AddDays(0 - thoigiansx);
                DateTime ngayhoanthanh = hangiaohang_po.AddDays(-10);

                if (msg.Length <= 0)
                {
                    if (object_.trangthai == "HIEULUC")
                    {
                        object_.khachhang = context.Request.Form["khachhang"];
                        object_.thoigiansx = thoigiansx;
                        object_.diachigiaohang = context.Request.Form["diachigiaohang"];
                        db.SaveChanges();
                    }
                    else
                    {
                        object_.ngaybatdau = ngaybatdau;
                        object_.ngayhoanthanh = ngayhoanthanh;
                        VNN_Function.SetFormValue(object_.nameof(s => s.trangthai), "VNN_notpost");
                        VNN_Function.SetFormValue(object_.nameof(s => s.thoigiansx), thoigiansx.ToString());
                        VNN_Function.SetFormValue(object_.nameof(s => s.md_doitackinhdoanh_id), "VNN_notpost");
                        VNN_Function.SetFormValue(object_.nameof(s => s.sochungtu), "VNN_notpost");
                        VNN_Function.SetFormValue(object_.nameof(s => s.so_po), so_po);
                        object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                        object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
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
                var ids = context.Request.Form["id"].Split(',').Where(s=>!string.IsNullOrWhiteSpace(s)).ToList();

                foreach (var id_del_ in ids)
                {
                    var object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else if (new string[] { "HIEULUC", "HUYBO", "KETTHUC" }.Contains(object_.trangthai))
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Không thể xóa khi đang trong trạng thái ""Hiệu Lực"", ""Hủy"" hoặc ""Kết Thúc"".", object_.sochungtu, object_.so_po);
                    }
                    else if (!new string[] { "HIEULUC", "SOANTHAO" }.Contains(object_.md_trangthai_id))
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Không thể xóa khi đang triển khai.", object_.sochungtu, object_.so_po);
                    }
                    else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Count() > 0)
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Đã tạo phiếu giảm hạn ngạch.", object_.sochungtu, object_.so_po);
                    }
                    else if (object_.dg_nangluc.GetValueOrDefault(false))
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Đã từng hiệu lực không thể xóa.", object_.sochungtu, object_.so_po);
                    }
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "MĐH:" + object_.sochungtu + ", TĐH:" + object_.so_po, db);
                        db.c_danhsachdathang.Remove(object_);
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
                msg = string.Format(@"true#Xóa các đơn hàng đã chọn thành công");
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