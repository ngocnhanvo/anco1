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
            case "CA01DSAncotradingMD00DSDHJQGS_MD00DSDHTCJQGS":
                this.CA01DSAncotradingMD00DSDHJQGS_MD00DSDHTCJQGS(context);
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
                this.CA_01_TinhNangLuc(context, 0);
                break;
            default:
                break;
        }
    }

    public string CA_01_TinhNangLuc(HttpContext context, int type)
    {
        EntityContext db = new EntityContext();
        string poId = context.Request.Form["id"];
        var donhang = db.c_danhsachdathang.Where(dh => dh.c_danhsachdathang_id == poId).FirstOrDefault();
        string result = "";
        string ngaylap = donhang.ngaylap.Value.ToString("dd/MM/yyyy");
        string selCapacity = "select count(*) as count from dbo.f_tinhNangLucCungUng('" + poId + "') where result_nhandh=0 or result=0";
        int check = (int)Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(selCapacity);
        bool dg_nangluc = false;
        DataTable dt = Mbg.Data.SqlClient.SqlHelper.GetData("select * from dbo.f_tinhNangLucCungUng('" + poId + "')");
        DateTime maxDate = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null);
        int colCount = dt.Columns.Count;
        int rowCount = dt.Select("tong_cbmcandat >= 0").Count();
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
                    DateTime ngaydukien = DateTime.Parse(row[4].ToString());
                    if (maxDate < ngaydukien)
                    {
                        maxDate = ngaydukien;
                    }
                }
            }
            result += "</table></div>";

            if (check > 0)
            {
                //tinh thoi gian du kien 
                string sql_dk = @"select case when (tgdk < tgyc and tgnhandh > tgantoan_dh) then tgyc
									when (tgdk < tgyc and tgnhandh < tgantoan_dh) then ngay_dh + tgnhandh
									when (tgdk > tgyc and tgnhandh > tgantoan_dh) then tgdk
									else tgdk
									end
							from(
									select MAX(thoigiandukien) tgdk, thoigianyeucau tgyc, max(tgnhan_dh) tgnhandh, max(tgantoan_dh) tgantoan_dh, convert(datetime,'" + ngaylap + "',103) as ngay_dh" +
                                        " from f_tinhNangLucCungUng('" + poId + "')" +
                                        " group by thoigianyeucau) as tmp";
                DateTime ngaydk = (DateTime)Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(sql_dk);
                result = "<div style=\"padding:15px; border:1px solid red; background:#ffadad;\"><h3>Năng lực nhà cung ứng không đáp ứng được đơn hàng này.!<br/>Ngày dự kiến: " + ngaydk.ToString("dd/MM/yyyy") + "</h3></div>" + result;
            }
            else
            {
                string sql_tongcandat = string.Format(@"SELECT sum(ddh.v2 * ddh.sl_conlai) as tcbm from c_dongdsdh ddh where ddh.c_danhsachdathang_id ='{0}'", poId);
                string sql_slCandat = @"select isnull(SUM(cbm_candat), 0) from f_tinhNangLucCungUng('" + poId + "')";
                string tong = Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(sql_tongcandat).ToString();
                decimal slTongCanDat = decimal.Parse(tong);
                decimal slCanDat = decimal.Parse(Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(sql_slCandat).ToString());

                if (slCanDat < slTongCanDat)
                {
                    result = "<div style=\"padding:15px; border:1px solid red; background:#ffadad;\"><h3>Năng lực nhà cung ứng không đáp ứng được đơn hàng này.!</h3>Năng lực Cung Ứng: " + slCanDat.DropTrailingZeros() + ", CBM Đơn Hàng: " + slTongCanDat.DropTrailingZeros() + "</div>" + result;
                }
                else
                {
                    if (check == 0 && slCanDat >= slTongCanDat)
                    {
                        result = "<div style=\"padding:15px; border:1px sold green; background:#b9fdbf;\"><h3>Năng lực nhà cung ứng đáp ứng được đơn hàng này.!</h3>Năng lực Cung Ứng: " + slCanDat.DropTrailingZeros() + ", CBM Đơn Hàng: " + slTongCanDat.DropTrailingZeros() + "</div>" + result;
                        dg_nangluc = true;
                    }
                    else
                    {
                        string sql_chk_lai_tongcandat = @"select isnull(sum(tmp.tong_cbmcandat), 0) from (select distinct dauma, tong_cbmcandat from f_tinhNangLucCungUng('" + poId + "')) as tmp";
                        decimal sl_chk_lai_TongCanDat = decimal.Parse(Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(sql_chk_lai_tongcandat).ToString());

                        if (slCanDat >= sl_chk_lai_TongCanDat)
                        {
                            result = "<div style=\"padding:15px; border:1px solid green; background:#b9fdbf;\"><h3>Năng lực nhà cung ứng đáp ứng được đơn hàng này.!</h3>" + (slCanDat >= slTongCanDat) + "</div>" + result;
                            dg_nangluc = true;
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
                donhang.dg_nangluc = dg_nangluc;
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

        db.Dispose();
        if (type == 0)
            context.Response.Write(result);
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
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        foreach (var dsdh in db.c_danhsachdathang.
                Where(s => vnn.Contains(s.c_danhsachdathang_id)).
                OrderByDescending(s => s.ngaylap).ToList())
        {
            if (dsdh.check_nangluc != true)
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " chưa kiểm tra năng lực.</div>";
            }
            else if (dsdh.trangthai == "HIEULUC")
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
                string msgTNL = CA_01_TinhNangLuc(context, 1);
                if (!msgTNL.ToLower().Contains("năng lực nhà cung ứng đáp ứng được đơn hàng này"))
                {
                    msg += "<div style='color:red'>Lỗi:không đủ năng lực để nhận Đơn hàng " + dsdh.sochungtu + " .</div>";
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
                            danhgia = true
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

                    //tao cac dong don hang
                    foreach (var ddsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id))
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
                    if (dsdh.anco_check == true)
                    {
                        string str = VNN_VariablePublic.connectString_Anco(db);
                        SqlConnection cnn = new SqlConnection(str);

                        //disable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                        SqlCommand cmd = new SqlCommand(@"
					ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateGoiHDLH
					ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateSLDaDatTrenPO
					", cnn);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        //update c_danhsachdathang
                        cmd = new SqlCommand(@"
					update c_danhsachdathang set trangthai = 'DAHIEULUC' where c_danhsachdathang_id = '" + dsdh.c_danhsachdathang_id + "'"
                        , cnn);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        //enable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                        cmd = new SqlCommand(@"
					ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateGoiHDLH
					ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateSLDaDatTrenPO
					", cnn);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    //dsdh.md_trangthai_id = "DATAO";
                    dsdh.trangthai = "HIEULUC";
                    msg_success += "<div style='color:blue'>Đơn hàng " + dsdh.sochungtu + " được hiệu lực thành công.</div>";
                }
                db.SaveChanges();
            }
        }
        if (msg.Length <= 0)
        {
            msg = msg_success;
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

    public void CA01DSAncotradingMD00DSDHJQGS_MD00DSDHTCJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string id = context.Request.Form["id"];
        string thoigiansx = context.Request.Form["thoigiansx"];
        string thoigianht = context.Request.Form["thoigianht"];
        string[] vnn = id.Split(',');
        foreach (c_danhsachdathang dsdh1 in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id) & (s.trangthai != "DANHAN")).OrderByDescending(s => s.ngaylap))
        {
            //lay du lieu dong danh sach dat hang
            string str = VNN_VariablePublic.connectString_Anco(db);
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(@"select 
			dddsh.c_dongdsdh_id,
			dddsh.c_danhsachdathang_id,
			dddsh.c_dongdonhang_id,
			(select ma_sanpham from md_sanpham where dddsh.md_sanpham_id = md_sanpham_id) as md_sanpham_id,
			dddsh.mota_tiengviet,
			dddsh.mota_tienganh,
			dddsh.ma_sanpham_khach,
			dddsh.md_doitackinhdoanh_id,
			dddsh.huongdan_dathang,
			dddsh.han_giaohang,
			dddsh.tem_dan,
			dddsh.sl_dathang,
			dddsh.sl_dagiao,
			dddsh.sl_conlai,
			dddsh.gianhap,
			dddsh.sothutu,
			dddsh.ngaytao,
			dddsh.nguoitao,
			dddsh.ngaycapnhat,
			dddsh.nguoicapnhat,
			dddsh.mota,
			dddsh.hoatdong,
			dddsh.md_donggoi_id,
			dddsh.sl_inner,
			dddsh.l1,
			dddsh.w1,
			dddsh.h1,
			dddsh.sl_outer,
			dddsh.l2,
			dddsh.w2,
			dddsh.h2,
			dddsh.v2,
			dddsh.sl_cont,
			dddsh.vd,
			dddsh.vn,
			dddsh.vl,
			dddsh.ghichu_vachngan,
			dddsh.sl_huy,
			dvt_i.ten_dvt as dvt_inner,
			dvt_o.ten_dvt as dvt_outer
			from c_dongdsdh dddsh 
			left join c_dongdonhang ddh on dddsh.c_dongdonhang_id = ddh.c_dongdonhang_id
			left join md_donggoi dg on dddsh.md_donggoi_id = dg.md_donggoi_id
			left join md_donvitinh dvt_i on dg.dvt_inner = dvt_i.md_donvitinh_id
			left join md_donvitinh dvt_o on dg.dvt_outer = dvt_o.md_donvitinh_id
			where dddsh.c_danhsachdathang_id = '" + dsdh1.c_danhsachdathang_id + "'", cnn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            int count_col = 0;
            string sql_column = "(";
            string sql_values = "(";
            foreach (System.Data.DataColumn col in dt.Columns)
            {
                count_col++;
                sql_column += col.ColumnName + ",";
            }

            if (sql_column != "(") { sql_column += "anco_check, sl_hanngach" + ")"; }

            foreach (System.Data.DataRow row in dt.Rows)
            {
                string c_dongdsdh_id = row[0].ToString();
                c_dongdsdh dsdh = db.c_dongdsdh.Where(s => s.c_dongdsdh_id == c_dongdsdh_id).FirstOrDefault();
                if (dsdh == null)
                {
                    string sql_insert = "insert into c_dongdsdh" + sql_column + " values(";
                    for (int i = 0; i < count_col; i++)
                    {
                        string cell_value = row[i].ToString();
                        if (cell_value == null | cell_value == "")
                        {
                            sql_insert += "NULL,";
                        }
                        else
                        {
                            if (i == 3)
                            {
                                sql_insert += "(" + "select md_sanpham_id from md_sanpham where ma_sanpham = N'" + cell_value.Replace("'", "''") + "'),";
                            }
                            else
                            {
                                sql_insert += "N'" + cell_value.Replace("'", "''") + "',";
                            }
                        }
                    }
                    sql_insert += "1,0)";
                    Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery(sql_insert);
                }
            }

            //lay du lieu tu Cac khoan phi
            string str1 = VNN_VariablePublic.connectString_Anco(db);
            SqlConnection cnn1 = new SqlConnection(str1);
            SqlCommand cmd1 = new SqlCommand(@"select * from c_phidathang where c_danhsachdathang_id = '" + dsdh1.c_danhsachdathang_id + "'", cnn1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);

            int count_col1 = 0;
            string sql_column1 = "(";
            string sql_values1 = "(";
            foreach (System.Data.DataColumn col in dt1.Columns)
            {
                count_col1++;
                sql_column1 += col.ColumnName + ",";
            }

            if (sql_column1 != "(") { sql_column1 += "anco_check" + ")"; }

            foreach (System.Data.DataRow row in dt1.Rows)
            {
                string c_phidathang_id = row[0].ToString();
                c_phidathang dsdh2 = db.c_phidathang.Where(s => s.c_phidathang_id == c_phidathang_id).FirstOrDefault();
                if (dsdh2 == null)
                {
                    string sql_insert = "insert into c_phidathang" + sql_column1 + " values(";
                    for (int i = 0; i < count_col1; i++)
                    {
                        string cell_value = row[i].ToString();
                        if (cell_value == null | cell_value == "")
                        {
                            sql_insert += "NULL,";
                        }
                        else
                        {
                            sql_insert += "N'" + cell_value.Replace("'", "''") + "',";
                        }
                    }
                    sql_insert += "1)";
                    Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery(sql_insert);
                }
            }

            //disable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
            cmd = new SqlCommand(@"
            ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateGoiHDLH
            ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateSLDaDatTrenPO
            ", cnn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //update c_danhsachdathang
            cmd = new SqlCommand(@"
            update c_danhsachdathang set trangthai = 'DANHAN' where c_danhsachdathang_id = '" + dsdh1.c_danhsachdathang_id + "'"
            , cnn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //enable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
            cmd = new SqlCommand(@"
            ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateGoiHDLH
            ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateSLDaDatTrenPO
            ", cnn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            dsdh1.trangthai = "DANHAN";
            dsdh1.thoigiansx = int.Parse(thoigiansx);
            dsdh1.ngaybatdau = dsdh1.hangiaohang_po - TimeSpan.Parse(thoigiansx) - TimeSpan.Parse(thoigianht);
            dsdh1.ngayhoanthanh = dsdh1.hangiaohang_po - TimeSpan.Parse(thoigianht);
            db.SaveChanges();
            msg += "\"" + dsdh1.sochungtu + "\" đã nhận\n";
        }
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