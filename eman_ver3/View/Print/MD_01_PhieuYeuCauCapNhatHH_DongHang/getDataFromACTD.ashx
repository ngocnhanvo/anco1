<%@ WebHandler Language="C#" Class="getDataFromACTD" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;
using System.Collections.Generic;

public class getDataFromACTD : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = context.Request.Form["oper"];
        switch (oper)
        {
            case "loadACTD":
                this.loadACTD(context);
                break;
            case "loadAC1":
                this.loadAC1(context);
                break;
            default:
                break;
        }
    }

    public void loadACTD(HttpContext context)
    {
        string id = context.Request.Form["id"];
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new Exception("Không tìm thấy id");
        }

        string link = $"{Helper.urlSync_ANCO}/Controllers/API_Data.ashx";
        string tbl_sanpham = typeof(md_sanpham).Name;
        using (var db = new EntityContext())
        {
            var msps = db.md_phieuthongtinsanpham_log_ancotrading
                         .Where(s => s.md_phieuthongtinsanpham_id == id && s.table == tbl_sanpham)
                         .Select(s => s.ma_lienket).ToList();

            var msp2s = db.md_phieuthongtinsanpham_sanpham_ancotrading
                          .Where(s => s.md_phieuthongtinsanpham_id == id)
                          .Select(s => s.ma_sanpham).ToList();

            msps.AddRange(msp2s);
            msps = msps.Distinct().OrderBy(s => s).ToList();

            int chunkSize = 100;
            var jsonChunks = new System.Collections.Generic.List<string>();

            for (int i = 0; i < msps.Count; i += chunkSize)
            {
                // === KIỂM TRA NẾU CLIENT ĐÃ NGẮT KẾT NỐI (TẮT TAB) ===
                if (!context.Response.IsClientConnected)
                {
                    // Thoát hoàn toàn khỏi hàm, Server dừng xử lý đợt này tiếp theo
                    return;
                }

                var chunk = msps.Skip(i).Take(chunkSize).ToList();

                string formData = $"oper=xemthaydoi&msp={string.Join(",", chunk)}&ncc={Helper.DinhDanhHeThong}";
                string msgSP = VNN_VariablePublic.GetModule(link, formData);

                if (string.IsNullOrEmpty(msgSP))
                    throw new Exception($"Lỗi kết nối ở đợt {i / chunkSize + 1}");

                string result = msgSP.Substring(1).Trim();

                if (msgSP.StartsWith("0"))
                    throw new Exception($"Lỗi ở đợt {i / chunkSize + 1}: {result}");

                if (result.StartsWith("[") && result.EndsWith("]"))
                {
                    string innerJson = result.Substring(1, result.Length - 2).Trim();
                    if (!string.IsNullOrEmpty(innerJson))
                    {
                        jsonChunks.Add(innerJson);
                    }
                }
            }

            // Kiểm tra một lần nữa trước khi build chuỗi JSON lớn trả về
            if (!context.Response.IsClientConnected) return;

            string finalJson = "[" + string.Join(",", jsonChunks) + "]";
            var rs = $@"{{""msg"":{finalJson}, ""sps"":""{string.Join(",", msps)}""}}";
            context.Response.Write(rs);
        }
    }

    public void loadAC1(HttpContext context)
    {
        string data = context.Request.Form["data"];
        var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
        string giamua = $"{Helper.DinhDanhHeThong}-GIAMUA";
        var lstStr = new List<Dictionary<string, string>>();
        using (var db = new EntityContext())
        {
            string tbl_sanpham = typeof(md_sanpham).Name;
            var msps = json["sps"].ToString().Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList();
            try
            {
                //var sps = db.md_sanpham.Where(s => msps.Contains(s.ma_sanpham)).ToList();
                foreach (var msp in msps)
                {
                    // === KIỂM TRA NẾU CLIENT ĐÃ HUỶ TIẾN TRÌNH ===
                    if (!context.Response.IsClientConnected)
                    {
                        return; // Dừng ngay lập tức vòng lặp và kết thúc xử lý tại server
                    }

                    var sp = db.md_sanpham.Where(s => s.ma_sanpham == msp).FirstOrDefault();
                    var item = new Dictionary<string, string>();
                    item["ma_sanpham"] = msp;
                    item["kieudang1"] = "";
                    item["chucnang1"] = "";
                    item["tiengviet1"] = "";
                    item["tienganh1"] = "";
                    item["tl1"] = "";
                    item["dt1"] = "";
                    item["tt1"] = "";
                    item["nnl1"] = "";
                    item["hsc1"] = "";
                    item["ncn1"] = "";
                    item["htb1"] = "";
                    item["gia1"] = "";
                    item["kt1"] = "";
                    item["madg1"] = "";
                    item["slinner1"] = "";
                    item["ktdg1"] = "";
                    item["slouter1"] = "";
                    item["ktdg_1"] = "";
                    item["cont20_1"] = "";
                    item["cont40_1"] = "";
                    item["cont40hc_1"] = "";
                    item["tldg1"] = "";
                    item["cpdg1"] = "";
                    item["kieudang2"] = "";
                    item["chucnang2"] = "";
                    item["tiengviet2"] = "";
                    item["tienganh2"] = "";
                    item["tl2"] = "";
                    item["dt2"] = "";
                    item["tt2"] = "";
                    item["nnl2"] = "";
                    item["hsc2"] = "";
                    item["ncn2"] = "";
                    item["htb2"] = "";
                    item["gia2"] = "";
                    item["kt2"] = "";
                    item["madg2"] = "";
                    item["slinner2"] = "";
                    item["ktdg2"] = "";
                    item["slouter2"] = "";
                    item["ktdg_2"] = "";
                    item["cont20_2"] = "";
                    item["cont40_2"] = "";
                    item["cont40hc_2"] = "";
                    item["tldg2"] = "";
                    item["cpdg2"] = "";
                    if (sp != null)
                    {
                        var gia = (from a in db.md_banggia_ancotrading
                                   join b in db.md_phienbangia_ancotrading on a.md_banggia_id equals b.md_banggia_id
                                   join c in db.md_giasanpham_ancotrading on b.md_phienbangia_id equals c.md_phienbangia_id
                                   where
                                     c.md_sanpham_id == sp.md_sanpham_id &&
                                     a.ten_banggia == giamua &&
                                     b.ngay_hieuluc <= DateTime.Now
                                   orderby b.ngay_hieuluc descending
                                   select c).FirstOrDefault();
                        var giaSP = gia == null ? -1 : gia.gia.GetValueOrDefault(0);
                        var dgid = db.md_donggoisanpham_ancotrading.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.macdinh == true).Select(s => s.md_donggoi_id).FirstOrDefault();
                        var dg = db.md_donggoi_ancotrading.Where(s => s.md_donggoi_id == dgid).FirstOrDefault();
                        if (dg == null)
                            dg = new md_donggoi_ancotrading();
                        var dvt1 = db.md_donvitinh.Where(s => s.md_donvitinh_id == dg.dvt_inner).FirstOrDefault();
                        if (dvt1 == null)
                        {
                            dvt1 = new md_donvitinh();
                        }
                        var dvt2 = db.md_donvitinh.Where(s => s.md_donvitinh_id == dg.dvt_outer).FirstOrDefault();
                        if (dvt2 == null)
                        {
                            dvt2 = new md_donvitinh();
                        }
                        var kd = db.md_kieudang_ancotrading.Where(s => s.md_kieudang_id == sp.md_kieudang_id).FirstOrDefault();
                        string ma_kd = kd == null ? "" : kd.ma_kieudang;
                        string ten_kd = kd == null ? "" : kd.ten_tv;
                        var cn = db.md_chucnang_ancotrading.Where(s => s.md_chucnang_id == sp.md_chucnang_id).FirstOrDefault();
                        string ma_cn = cn == null ? "" : cn.ma_chucnang;
                        string ten_cn = cn == null ? "" : cn.ten_tv;
                        var nnl = db.md_nhomnangluc_ancotrading.Where(s => s.md_nhomnangluc_id == sp.md_nhomnangluc_id2).FirstOrDefault();
                        string ten_nnl = nnl == null ? "" : $"{nnl.hehang}({nnl.nhom})";
                        var hsc = db.md_hscode_ancotrading.Where(s => s.md_hscode_id == sp.md_hscode_id).FirstOrDefault();
                        string ten_hsc = hsc == null ? "" : hsc.hscode;

                        item["ma_sanpham"] = sp.ma_sanpham;
                        item["kieudang1"] = ten_kd;
                        item["chucnang1"] = ten_cn;
                        item["tiengviet1"] = sp.mota_tiengviet;
                        item["tienganh1"] = sp.mota_tienganh;
                        item["tl1"] = $"{sp.trongluong}";
                        item["dt1"] = $"{sp.dientich}";
                        item["tt1"] = $"{sp.thetich}";
                        item["nnl1"] = ten_nnl;
                        item["hsc1"] = ten_hsc;
                        item["ncn1"] = sp.chucnangsp;
                        item["htb1"] = sp.hinhthucban;
                        item["gia1"] = giaSP.DropTrailingZeros();
                        item["kt1"] = $"{sp.l_cm.GetValueOrDefault(0).DropTrailingZeros()}x{sp.w_cm.GetValueOrDefault(0).DropTrailingZeros()}x{sp.h_cm.GetValueOrDefault(0).DropTrailingZeros()}";
                        item["madg1"] = dg.ma_donggoi;
                        item["slinner1"] = $"{dg.sl_inner.GetValueOrDefault(0).DropTrailingZeros()} {dvt1.ten_dvt}";
                        item["ktdg1"] = $"{dg.l1.GetValueOrDefault(0).DropTrailingZeros()}x{dg.w1.GetValueOrDefault(0).DropTrailingZeros()}x{dg.h1.GetValueOrDefault(0).DropTrailingZeros()}";
                        item["slouter1"] = $"{dg.sl_outer.GetValueOrDefault(0).DropTrailingZeros()} {dvt2.ten_dvt}";
                        item["ktdg_1"] = $"{dg.l2_mix.GetValueOrDefault(0).DropTrailingZeros()}x{dg.w2_mix.GetValueOrDefault(0).DropTrailingZeros()}x{dg.h2_mix.GetValueOrDefault(0).DropTrailingZeros()}";
                        item["cont20_1"] = $"{dg.soluonggoi_ctn_20}";
                        item["cont40_1"] = $"{dg.soluonggoi_ctn}";
                        item["cont40hc_1"] = $"{dg.soluonggoi_ctn_40hc}";
                        item["tldg1"] = $"{dg.tldg}";
                        item["cpdg1"] = $"{dg.cpdg}";
                    }
                    lstStr.Add(item);
                }
                //
                var dataACs = json["msg"] as Newtonsoft.Json.Linq.JArray;
                foreach (var dataAC in dataACs)
                {
                    if (!context.Response.IsClientConnected) return;

                    dynamic spAC = dataAC["sp"];
                    string msp = spAC.ma_sanpham;
                    dynamic dgAC = dataAC["dg"];
                    var item = lstStr.Where(s => s["ma_sanpham"].Equals(msp)).FirstOrDefault();
                    if (item != null)
                    {
                        item["kieudang2"] = spAC.ten_kd;
                        item["chucnang2"] = spAC.ten_cn;
                        item["tiengviet2"] = spAC.mota_tiengviet;
                        item["tienganh2"] = spAC.mota_tienganh;
                        item["tl2"] = $"{spAC.trongluong}";
                        item["dt2"] = $"{spAC.dientich}";
                        item["tt2"] = $"{spAC.thetich}";
                        item["nnl2"] = spAC.ten_nnl;
                        item["hsc2"] = spAC.ten_hsc;
                        item["ncn2"] = spAC.chucnangsp;
                        item["htb2"] = spAC.hinhthucban;
                        item["gia2"] = $"{spAC.giaSP}";
                        item["kt2"] = $"{spAC.l_cm}x{spAC.w_cm}x{spAC.h_cm}";
                        if (item["kt2"] == "xx")
                            item["kt2"] = "";
                        item["madg2"] = dgAC.ma_donggoi;
                        item["slinner2"] = $"{dgAC.sl_inner} {dgAC.inner}";
                        item["ktdg2"] = $"{dgAC.l1}x{dgAC.w1}x{dgAC.h1}";
                        if (item["ktdg2"] == "xx")
                            item["ktdg2"] = "";
                        item["slouter2"] = $"{dgAC.sl_outer} {dgAC.outer}";
                        item["ktdg_2"] = $"{dgAC.l2_mix}x{dgAC.w2_mix}x{dgAC.h2_mix}";
                        if (item["ktdg_2"] == "xx")
                            item["ktdg_2"] = "";
                        item["cont20_2"] = $"{dgAC.soluonggoi_ctn_20}";
                        item["cont40_2"] = $"{dgAC.soluonggoi_ctn}";
                        item["cont40hc_2"] = $"{dgAC.soluonggoi_ctn_40hc}";
                        item["tldg2"] = $"{dgAC.tldg}";
                        item["cpdg2"] = $"{dgAC.cpdg}";
                    }
                }

                if (!context.Response.IsClientConnected) return;
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(lstStr));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
