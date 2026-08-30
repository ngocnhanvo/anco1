<%@ Assembly Name="System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" %>
<%@ WebHandler Language="C#" Class="getDataFromACTD" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class getDataFromACTD : HttpTaskAsyncHandler, System.Web.SessionState.IReadOnlySessionState
{
    // Replay interface handler async của ASP.NET
    public override async Task ProcessRequestAsync(HttpContext context)
    {
        string oper = context.Request.Form["oper"];
        switch (oper)
        {
            case "loadACTD":
                await this.loadACTD(context);
                break;
            case "loadAC1":
                await this.loadAC1(context);
                break;
            default:
                break;
        }
    }

    public async Task loadACTD(HttpContext context)
    {
        string id = context.Request.Form["id"];
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new Exception("Không tìm thấy id");
        }

        string link = $"{Helper.urlSync_ANCO}/Controllers/API_Data.ashx";
        string tbl_sanpham = typeof(md_sanpham).Name;
        
        List<string> msps;
        using (var db = new EntityContext())
        {
            var msps1 = db.md_phieuthongtinsanpham_log_ancotrading
                         .Where(s => s.md_phieuthongtinsanpham_id == id && s.table == tbl_sanpham)
                         .Select(s => s.ma_lienket);

            var msps2 = db.md_phieuthongtinsanpham_sanpham_ancotrading
                          .Where(s => s.md_phieuthongtinsanpham_id == id)
                          .Select(s => s.ma_sanpham);

            // Gộp query trực tiếp tại Database trước khi lấy về RAM
            msps = msps1.Concat(msps2).Distinct().OrderBy(s => s).ToList();
        }

        if (!msps.Any())
        {
            context.Response.ContentType = "application/json";
            context.Response.Write("{\"msg\":[], \"sps\":\"\"}");
            return;
        }

        // Chia chunk 10 mã
        int chunkSize = 10;
        var chunks = msps.Select((x, i) => new { Index = i, Value = x })
                         .GroupBy(x => x.Index / chunkSize)
                         .Select(g => g.Select(x => x.Value).ToList())
                         .ToList();

        var jsonChunks = new System.Collections.Concurrent.ConcurrentBag<string>();

        // Sử dụng HttpClient để thực hiện request bất đồng bộ
        using (var client = new HttpClient())
        {
            // BẮT ĐẦU GỌI SONG SONG (PARALLEL HTTP REQUESTS)
            var tasks = chunks.Select(async (chunk, index) =>
            {
                if (!context.Response.IsClientConnected) return;

                var postData = new Dictionary<string, string>
                {
                    { "oper", "xemthaydoi" },
                    { "msp", string.Join(",", chunk) },
                    { "ncc", Helper.DinhDanhHeThong }
                };

                using (var content = new FormUrlEncodedContent(postData))
                {
                    HttpResponseMessage response = await client.PostAsync(link, content);
                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"Lỗi kết nối ở đợt {index + 1}");

                    string msgSP = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(msgSP))
                        throw new Exception($"Không có phản hồi ở đợt {index + 1}");

                    string result = msgSP.Substring(1).Trim();

                    if (msgSP.StartsWith("0"))
                        throw new Exception($"Lỗi ở đợt {index + 1}: {result}");

                    if (result.StartsWith("[") && result.EndsWith("]"))
                    {
                        string innerJson = result.Substring(1, result.Length - 2).Trim();
                        if (!string.IsNullOrEmpty(innerJson))
                        {
                            jsonChunks.Add(innerJson);
                        }
                    }
                }
            });

            // Đợi tất cả request hoàn thành đồng thời
            await Task.WhenAll(tasks);
        }

        if (!context.Response.IsClientConnected) return;

        string finalJson = "[" + string.Join(",", jsonChunks) + "]";
        var rs = $@"{{""msg"":{finalJson}, ""sps"":""{string.Join(",", msps)}""}}";
        
        context.Response.ContentType = "application/json";
        context.Response.Write(rs);
    }

    public async Task loadAC1(HttpContext context)
    {
        string data = context.Request.Form["data"];
        if (string.IsNullOrEmpty(data)) return;

        var json = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
        string giamua = $"{Helper.DinhDanhHeThong}-GIAMUA";
        var lstStr = new List<Dictionary<string, string>>();

        using (var db = new EntityContext())
        {
            string tbl_sanpham = typeof(md_sanpham).Name;
            var msps = json["sps"].ToString().Split(',').Where(s => !string.IsNullOrEmpty(s)).ToList();

            try
            {
                // TỐI ƯU N+1 QUERY: Load toàn bộ danh sách dữ liệu liên quan vào Memory trước
                var spList = db.md_sanpham.Where(s => msps.Contains(s.ma_sanpham)).ToList();
                var spIds = spList.Select(s => s.md_sanpham_id).ToList();

                var allGia = (from a in db.md_banggia_ancotrading
                              join b in db.md_phienbangia_ancotrading on a.md_banggia_id equals b.md_banggia_id
                              join c in db.md_giasanpham_ancotrading on b.md_phienbangia_id equals c.md_phienbangia_id
                              where spIds.Contains(c.md_sanpham_id) &&
                                    a.ten_banggia == giamua &&
                                    b.ngay_hieuluc <= DateTime.Now
                              select new { c.md_sanpham_id, c.gia, b.ngay_hieuluc }).ToList();

                var allDongGoiSP = db.md_donggoisanpham_ancotrading
                                     .Where(s => spIds.Contains(s.md_sanpham_id) && s.macdinh == true)
                                     .ToList();

                var dgIds = allDongGoiSP.Select(s => s.md_donggoi_id).ToList();
                var allDongGoi = db.md_donggoi_ancotrading.Where(s => dgIds.Contains(s.md_donggoi_id)).ToList();

                var dvtIds = allDongGoi.Select(s => s.dvt_inner).Concat(allDongGoi.Select(s => s.dvt_outer)).Distinct().ToList();
                var allDVT = db.md_donvitinh.Where(s => dvtIds.Contains(s.md_donvitinh_id)).ToList();

                var kdIds = spList.Select(s => s.md_kieudang_id).Distinct().ToList();
                var allKieuDang = db.md_kieudang_ancotrading.Where(s => kdIds.Contains(s.md_kieudang_id)).ToList();

                var cnIds = spList.Select(s => s.md_chucnang_id).Distinct().ToList();
                var allChucNang = db.md_chucnang_ancotrading.Where(s => cnIds.Contains(s.md_chucnang_id)).ToList();

                var nnlIds = spList.Select(s => s.md_nhomnangluc_id2).Distinct().ToList();
                var allNhomNangLuc = db.md_nhomnangluc_ancotrading.Where(s => nnlIds.Contains(s.md_nhomnangluc_id)).ToList();

                var hscIds = spList.Select(s => s.md_hscode_id).Distinct().ToList();
                var allHsCode = db.md_hscode_ancotrading.Where(s => hscIds.Contains(s.md_hscode_id)).ToList();

                foreach (var msp in msps)
                {
                    if (!context.Response.IsClientConnected) return;

                    var sp = spList.FirstOrDefault(s => s.ma_sanpham == msp);
                    var item = new Dictionary<string, string>();
                    
                    // Khởi tạo tất cả key với giá trị rỗng
                    string[] keys = { "ma_sanpham", "kieudang1", "chucnang1", "tiengviet1", "tienganh1", "tl1", "dt1", "tt1", "nnl1", "hsc1", "ncn1", "htb1", "gia1", "kt1", "madg1", "slinner1", "ktdg1", "slouter1", "ktdg_1", "cont20_1", "cont40_1", "cont40hc_1", "tldg1", "cpdg1", "kieudang2", "chucnang2", "tiengviet2", "tienganh2", "tl2", "dt2", "tt2", "nnl2", "hsc2", "ncn2", "htb2", "gia2", "kt2", "madg2", "slinner2", "ktdg2", "slouter2", "ktdg_2", "cont20_2", "cont40_2", "cont40hc_2", "tldg2", "cpdg2" };
                    foreach (var k in keys) item[k] = "";

                    item["ma_sanpham"] = msp;

                    if (sp != null)
                    {
                        var giaObj = allGia.Where(g => g.md_sanpham_id == sp.md_sanpham_id)
                                           .OrderByDescending(g => g.ngay_hieuluc)
                                           .FirstOrDefault();
                        decimal giaSP = giaObj == null ? -1 : giaObj.gia.GetValueOrDefault(0);

                        var dgid = allDongGoiSP.Where(s => s.md_sanpham_id == sp.md_sanpham_id).Select(s => s.md_donggoi_id).FirstOrDefault();
                        var dg = allDongGoi.FirstOrDefault(s => s.md_donggoi_id == dgid) ?? new md_donggoi_ancotrading();

                        var dvt1 = allDVT.FirstOrDefault(s => s.md_donvitinh_id == dg.dvt_inner) ?? new md_donvitinh();
                        var dvt2 = allDVT.FirstOrDefault(s => s.md_donvitinh_id == dg.dvt_outer) ?? new md_donvitinh();

                        var kd = allKieuDang.FirstOrDefault(s => s.md_kieudang_id == sp.md_kieudang_id);
                        string ten_kd = kd == null ? "" : kd.ten_tv;

                        var cn = allChucNang.FirstOrDefault(s => s.md_chucnang_id == sp.md_chucnang_id);
                        string ten_cn = cn == null ? "" : cn.ten_tv;

                        var nnl = allNhomNangLuc.FirstOrDefault(s => s.md_nhomnangluc_id == sp.md_nhomnangluc_id2);
                        string ten_nnl = nnl == null ? "" : $"{nnl.hehang}({nnl.nhom})";

                        var hsc = allHsCode.FirstOrDefault(s => s.md_hscode_id == sp.md_hscode_id);
                        string ten_hsc = hsc == null ? "" : hsc.hscode;

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
                        item["ktdg1"] = $"{dg.l1.GetValueOrDefault(0).DropTrailingZeros()}";
                        item["slouter1"] = $"{dg.sl_outer.GetValueOrDefault(0).DropTrailingZeros()} {dvt2.ten_dvt}";
                        item["ktdg_1"] = $"{dg.l2_mix.GetValueOrDefault(0).DropTrailingZeros()}";
                        item["cont20_1"] = $"{dg.soluonggoi_ctn_20}";
                        item["cont40_1"] = $"{dg.soluonggoi_ctn}";
                        item["cont40hc_1"] = $"{dg.soluonggoi_ctn_40hc}";
                        item["tldg1"] = $"{dg.tldg}";
                        item["cpdg1"] = $"{dg.cpdg}";
                    }
                    lstStr.Add(item);
                }

                var dataACs = json["msg"] as Newtonsoft.Json.Linq.JArray;
                if (dataACs != null)
                {
                    foreach (var dataAC in dataACs)
                    {
                        if (!context.Response.IsClientConnected) return;

                        dynamic spAC = dataAC["sp"];
                        string msp = spAC.ma_sanpham;
                        dynamic dgAC = dataAC["dg"];
                        var item = lstStr.FirstOrDefault(s => s["ma_sanpham"].Equals(msp));
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
                            if (item["kt2"] == "xx") item["kt2"] = "";
                            item["madg2"] = dgAC.ma_donggoi;
                            item["slinner2"] = $"{dgAC.sl_inner} {dgAC.inner}";
                            item["ktdg2"] = $"{dgAC.l1}";
                            if (item["ktdg2"] == "xx") item["ktdg2"] = "";
                            item["slouter2"] = $"{dgAC.sl_outer} {dgAC.outer}";
                            item["ktdg_2"] = $"{dgAC.l2_mix}";
                            if (item["ktdg_2"] == "xx") item["ktdg_2"] = "";
                            item["cont20_2"] = $"{dgAC.soluonggoi_ctn_20}";
                            item["cont40_2"] = $"{dgAC.soluonggoi_ctn}";
                            item["cont40hc_2"] = $"{dgAC.soluonggoi_ctn_40hc}";
                            item["tldg2"] = $"{dgAC.tldg}";
                            item["cpdg2"] = $"{dgAC.cpdg}";
                        }
                    }
                }

                if (!context.Response.IsClientConnected) return;
                
                context.Response.ContentType = "application/json";
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