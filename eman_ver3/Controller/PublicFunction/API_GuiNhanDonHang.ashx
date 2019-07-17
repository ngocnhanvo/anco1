<%@ WebHandler Language="C#" Class="API_GuiNhanDonHang" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAcess;
using Newtonsoft.Json;

public class API_GuiNhanDonHang : IHttpHandler
{
    private EntityContext db = new EntityContext();
    public void ProcessRequest(HttpContext context)
    {
        string oper = context.Request.QueryString["oper"];
        switch (oper)
        {
            case "NhanDonHang":
                this.NhanDonHang(context);
                break;
            case "getListDSDH":
                this.getListDSDH(context);
                break;
        }
    }

    public void getListDSDH(HttpContext context)
    {
        string msg = "";
        try
        {
            string strdata = context.Request.Form["data"];
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(strdata);
            var result = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data["result"] + "");
            var lst = new List<Dictionary<string, object>>();
            foreach (var a in result)
            {
                string c_dsdh_id = a["c_danhsachdathang_id"] + "";
                var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == c_dsdh_id).FirstOrDefault();
                if (dsdh != null)
                {
                    var item = new Dictionary<string, object>();
                    item["c_danhsachdathang_id"] = dsdh.c_danhsachdathang_id;
                    item["trangthai"] = dsdh.trangthai == "HIEULUC" ? "DAHIEULUC" : dsdh.trangthai;
                    lst.Add(item);
                }
            }
            msg = JsonConvert.SerializeObject(lst);
        }
        catch (Exception ex)
        {
            msg = "false##" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void NhanDonHang(HttpContext context)
    {
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            string strdata = context.Request.Form["data"];
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(strdata);
            var result = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data["result"] + "");


            try
            {
                foreach (var a in result)
                {
                    var item = JsonConvert.DeserializeObject<Dictionary<string, object>>(a["c_danhsachdathang"] + "");
                    var lstItem = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(a["c_dongdsdh"] + "");
                    var lstItem2 = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(a["c_phidathang"] + "");
                    string c_danhsachdathang_id = item["c_danhsachdathang_id"] + "";
                    var exist = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == c_danhsachdathang_id).FirstOrDefault();
                    if (exist == null)
                    {
                        var c_dsdh = new c_danhsachdathang();
                        c_dsdh.anco_check = true;
                        c_dsdh.check_nangluc = false;
                        c_dsdh.c_danhsachdathang_id = item["c_danhsachdathang_id"] + "";
                        c_dsdh.c_donhang_id = item["c_donhang_id"] + "";
                        c_dsdh.dg_nangluc = false;
                        c_dsdh.diachigiaohang = item["diachigiaohang"] + "";
                        c_dsdh.discount = Convert.ToDecimal(item["discount"]);
                        c_dsdh.grandtotal = Convert.ToDecimal(item["grandtotal"]);
                        c_dsdh.hangiaohang_po = item["hangiaohang_po"].ToDateTime();
                        c_dsdh.hoatdong = true;
                        c_dsdh.huongdanlamhang = item["huongdanlamhang"] + "";
                        c_dsdh.huongdanlamhangchung = item["huongdanlamhangchung"] + "";
                        c_dsdh.isgui_hdlh = Convert.ToBoolean(item["isgui_hdlh"]);
                        //c_dsdh.khachhang = item["khachhang"] + "";
                        c_dsdh.md_doitackinhdoanh_id = item["md_doitackinhdoanh_id"] + "";
                        c_dsdh.md_trangthai_id = item["md_trangthai_id"] + "";
                        c_dsdh.mota = item["mota"] + "";
                        c_dsdh.ngaycapnhat = item["ngaycapnhat"].ToDateTime();
                        c_dsdh.ngaylap = item["ngaylap"].ToDateTime();
                        c_dsdh.ngaytao = DateTime.Now;
                        c_dsdh.ngay_tigia = null;
                        c_dsdh.nguoicapnhat = item["nguoicapnhat"] + "";
                        c_dsdh.nguoitao = item["nguoitao"] + "";
                        c_dsdh.nguoi_dathang = item["nguoi_dathang"] + "";
                        c_dsdh.nguoi_phutrach = item["nguoi_phutrach"] + "";
                        c_dsdh.sochungtu = item["sochungtu"] + "";
                        c_dsdh.so_po = item["so_po"] + "";
                        c_dsdh.total = Convert.ToDecimal(item["total"]);
                        c_dsdh.trangthai = item["trangthai"] + "";
                        db.c_danhsachdathang.Add(c_dsdh);
                        db.SaveChanges();

                        foreach (var b in lstItem)
                        {
                            string ma_sanpham = b["md_sanpham_id"] + "";
                            var c_dongdsdh = new c_dongdsdh();
                            c_dongdsdh.w2 = Convert.ToDecimal(b["w2"]);
                            c_dongdsdh.w1 = Convert.ToDecimal(b["w1"]);
                            c_dongdsdh.vn = Convert.ToDecimal(b["vn"]);
                            c_dongdsdh.vl = Convert.ToDecimal(b["vl"]);
                            c_dongdsdh.vd = Convert.ToDecimal(b["vd"]);
                            c_dongdsdh.v2 = Convert.ToDecimal(b["v2"]);
                            c_dongdsdh.tem_dan = b["tem_dan"] + ""; ;
                            c_dongdsdh.sothutu = Convert.ToInt32(b["sothutu"]);
                            c_dongdsdh.sl_outer = Convert.ToDecimal(b["sl_outer"]);
                            c_dongdsdh.dvt_outer = b["dvt_outer"] + "";
                            c_dongdsdh.sl_inner = Convert.ToDecimal(b["sl_inner"]);
                            c_dongdsdh.dvt_inner = b["dvt_inner"] + "";
                            c_dongdsdh.sl_huy = Convert.ToDecimal(b["sl_huy"]);
                            c_dongdsdh.sl_dathang = Convert.ToDecimal(b["sl_dathang"]);
                            c_dongdsdh.sl_dagiao = Convert.ToDecimal(b["sl_dagiao"]);
                            c_dongdsdh.sl_cont = Convert.ToDecimal(b["sl_cont"]);
                            c_dongdsdh.sl_conlai = Convert.ToDecimal(b["sl_conlai"]);
                            c_dongdsdh.mota = b["mota"] + "";
                            c_dongdsdh.md_sanpham_id = ma_sanpham + "";
                            c_dongdsdh.md_donggoi_id = b["md_donggoi_id"] + "";
                            c_dongdsdh.md_doitackinhdoanh_id = b["md_doitackinhdoanh_id"] + "";
                            c_dongdsdh.ma_sanpham_khach = ma_sanpham + "";
                            c_dongdsdh.l2 = Convert.ToDecimal(b["l2"]);
                            c_dongdsdh.l1 = Convert.ToDecimal(b["l1"]);
                            c_dongdsdh.huongdan_dathang = b["huongdan_dathang"] + "";
                            c_dongdsdh.hoatdong = true;
                            c_dongdsdh.h2 = Convert.ToDecimal(b["h2"]);
                            c_dongdsdh.h1 = Convert.ToDecimal(b["h1"]);
                            c_dongdsdh.gianhap = Convert.ToDecimal(b["gianhap"]);
                            c_dongdsdh.ghichu_vachngan = b["ghichu_vachngan"] + "";
                            c_dongdsdh.c_dongdsdh_id = b["c_dongdsdh_id"] + "";
                            c_dongdsdh.c_dongdonhang_id = b["c_dongdonhang_id"] + "";
                            c_dongdsdh.c_danhsachdathang_id = b["c_danhsachdathang_id"] + "";
                            c_dongdsdh.anco_check = true;
                            db.c_dongdsdh.Add(c_dongdsdh);
                            db.SaveChanges();
                        }
                    }

                    foreach (var b in lstItem2)
                    {
                        var c_phidathang = new c_phidathang();
                        c_phidathang.c_phidathang_id = b["c_phidathang_id"] + "";
                        c_phidathang.c_danhsachdathang_id = b["c_danhsachdathang_id"] + "";
                        c_phidathang.hoatdong = true;
                        c_phidathang.isphicong = Convert.ToBoolean(b["isphicong"] + "");
                        c_phidathang.mota = b["mota"] + "";
                        c_phidathang.ngaytao = DateTime.Now;
                        c_phidathang.ngaycapnhat = DateTime.Now;
                        c_phidathang.sotien = Convert.ToDecimal(b["sotien"] + "");
                        c_phidathang.anco_check = true;
                        db.c_phidathang.Add(c_phidathang);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg += string.Format(@"<div style='color:red'>Có lỗi xảy ra: {0}</div>", ex.Message);
            }

            if (msg.Length <= 0)
                transaction.Commit();
            else
                transaction.Rollback();
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


