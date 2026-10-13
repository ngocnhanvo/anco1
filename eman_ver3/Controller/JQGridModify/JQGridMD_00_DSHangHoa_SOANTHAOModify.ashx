<%@ WebHandler Language="C#" Class="JQGridMD_00_DSHangHoa_SOANTHAOModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Collections.Generic;

public class JQGridMD_00_DSHangHoa_SOANTHAOModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA01ImportHHVG_MD00DSHangHoaSOANTHAO":
                this.CA01ImportHHVG_MD00DSHangHoaSOANTHAO(context);
                break;
            case "CA_01_ChuyenTrangThaiST":
                this.CA_01_ChuyenTrangThaiST(context);
                break;
            default:
                break;
        }
    }


    // Áp dụng bộ lọc và phân quyền giống JQGridMD_00_DSHangHoa_SOANTHAOLoad,
    // nhưng lấy ID tất cả các trang; không dùng selrow hoặc selarrrow.
    private List<string> GetFilteredProductIds(HttpContext context, string maModule)
    {
        var parentId = context.Request.Form["id"] ?? "";
        // ID ngữ cảnh của jqGrid là mã định danh, không phải câu SQL tự do.
        if (parentId != "" && parentId != "null" &&
            !System.Text.RegularExpressions.Regex.IsMatch(parentId, @"^[A-Za-z0-9_-]{1,64}$"))
            throw new Exception("Bộ lọc hoặc ID ngữ cảnh không hợp lệ.");
        var filterText = context.Request.Form["filters"];
        if (string.IsNullOrWhiteSpace(filterText))
            throw new Exception("Hãy lọc hàng hóa trên jqGrid trước khi chuyển trạng thái.");

        var json = Newtonsoft.Json.Linq.JObject.Parse(filterText);
        var rules = json["rules"] as Newtonsoft.Json.Linq.JArray;
        if (rules == null || rules.Count == 0 || rules.Count > 50)
            throw new Exception("Bộ lọc phải có ít nhất một điều kiện hợp lệ.");
        var groupOp = (string)json["groupOp"];
        if (groupOp != "AND" && groupOp != "OR")
            throw new Exception("Toán tử bộ lọc không hợp lệ.");
        var groups = json["groups"] as Newtonsoft.Json.Linq.JArray;
        if (groups != null && groups.Count > 0)
            throw new Exception("Chưa hỗ trợ bộ lọc nhóm lồng nhau khi chuyển hàng loạt.");
        // Không cho phép gửi SQL tùy ý từ trình duyệt tới thao tác cập nhật hàng loạt.
        if (!string.IsNullOrWhiteSpace(context.Request.Form["where_ex"]))
            throw new Exception("Bộ lọc SQL mở rộng chưa được hỗ trợ cho thao tác này.");

        var cols = new ADmin_JSON().ad_columnJSON()
            .Where(s => s.ma_module == maModule && s.hoatdong == true).ToList();
        var ops = new[] { "eq", "ne", "lt", "le", "gt", "ge", "bw", "bn", "in", "ni", "ew", "en", "cn", "abi" };
        foreach (var item in rules)
        {
            var field = (string)item["field"] ?? "";
            var op = (string)item["op"] ?? "";
            var data = (string)item["data"] ?? "";
            if (!cols.Any(c => string.Equals(c.index_cot, field, StringComparison.OrdinalIgnoreCase)
                || string.Equals(c.ma_column, field, StringComparison.OrdinalIgnoreCase)
                || string.Equals("P." + c.ma_column, field, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Bộ lọc có cột không thuộc module.");
            if (!ops.Contains(op) || string.IsNullOrWhiteSpace(data) ||
                data.Length > 500 || data.ToUpperInvariant().Contains("[ALL]"))
                throw new Exception("Hãy nhập điều kiện lọc cụ thể, hợp lệ.");
            // "en" chèn dữ liệu trực tiếp vào khoảng số trong Filter.ToScriptPL.
            if (op == "en" && !System.Text.RegularExpressions.Regex.IsMatch(data, @"^\d+(\.\d+)?-\d+(\.\d+)?$"))
                throw new Exception("Khoảng số lọc không hợp lệ.");
            ((Newtonsoft.Json.Linq.JObject)item)["data"] = data.Replace("'", "''");
        }
        var f = jqGridHelper.Filter.CreateFilter(json.ToString(Newtonsoft.Json.Formatting.None));
        var mod = VNN_Config.get_ModuleKeThua(null, 0, maModule, "", "", db);
        if (mod == null || string.IsNullOrEmpty(mod.from_sql))
            throw new Exception("Không tìm thấy cấu hình module.");
        var selectSql = VNN_Config.Select_sql(mod.ma_module, db);
        var firstCol = selectSql.Split(new[] { "as" }, StringSplitOptions.None)[0];
        var orderBy = string.IsNullOrWhiteSpace(mod.orderby_sql) ? firstCol + " asc" : mod.orderby_sql;
        var groupBy = string.IsNullOrWhiteSpace(mod.groupby_sql) ? "" : "group by " + mod.groupby_sql;
        var roleId = Security.id_vaitro(context);
        var roleWhere = db.ad_role_where.Where(s => s.ad_role_id == roleId &&
            s.ad_module_id == mod.ad_module_id).Select(s => s.where_sql).FirstOrDefault();
        var sql = $@"
            sELeCt P.*
            fRoM (
                sELeCt {selectSql}
                    ROW_NUMBER() OVER (ORDER BY {orderBy}) as RowNum
                fRoM {mod.from_sql}
                WHeRe 1=1
                    {mod.where_sql}
                    {roleWhere}
                    {Security.test_InjectionSQL(f.ToScript(), null, "")}
                {groupBy}
            ) P
            WHeRe 1=1 {f.ToScriptP()}
            order by RowNum";
        sql = ADmin_ConvertStringToCode.Avariable(context, sql, firstCol,
            context.Request.Form["id"], mod, db).Replace("'", "''");
        var proc = string.IsNullOrEmpty(mod.procedure_sql) ? "admin_excutesql" : mod.procedure_sql;
        var dt = Mbg.Data.SqlClient.SqlHelper.GetData(
            $@"exec [dbo].[{proc}] N'{sql}',N'{mod.ma_moduletk}',1");
        // Cột đầu tiên là ID dòng dùng bởi JqGResult/jqGrid.
        return dt.Rows.Cast<System.Data.DataRow>()
            .Select(r => r[0] == DBNull.Value ? "" : r[0].ToString())
            .Where(id => !string.IsNullOrWhiteSpace(id))
            .Distinct(StringComparer.OrdinalIgnoreCase).ToList();
    }

    private List<string> GetDraftIds(List<string> ids)
    {
        var drafts = new List<string>();
        for (int i = 0; i < ids.Count; i += 350)
        {
            var batch = ids.Skip(i).Take(350).ToList();
            drafts.AddRange(db.md_sanpham
                .Where(p => batch.Contains(p.md_sanpham_id) && p.trangthai == Helper.SOANTHAO)
                .Select(p => p.md_sanpham_id).ToList());
        }
        return drafts;
    }

    private static string GetSnapshot(List<string> ids, List<string> drafts)
    {
        var data = string.Join("|", ids.OrderBy(x => x, StringComparer.OrdinalIgnoreCase))
            + "\n" + string.Join("|", drafts.OrderBy(x => x, StringComparer.OrdinalIgnoreCase));
        using (var sha = System.Security.Cryptography.SHA256.Create())
            return System.Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data)));
    }

    public void CA_01_ChuyenTrangThaiST(HttpContext context)
    {
        const string maModule = "MD_00_DSHangHoa_SOANTHAO";
        const string maCase = "CA_01_ChuyenTrangThaiST";
        context.Response.ContentType = "application/json; charset=utf-8";
        try
        {
            if (context.Request.HttpMethod != "POST"
                || string.IsNullOrEmpty(Security.id_taikhoan(context))
                || context.Request.QueryString["ma_module"] != maModule
                || !Security.PhanQuyen_ChucNang(context, maModule, maCase))
                throw new Exception("Bạn không có quyền thực hiện chức năng này.");

            var mode = context.Request.Form["mode"];
            if (mode != "preview" && mode != "execute")
                throw new Exception("Thao tác không hợp lệ.");

            var allIds = GetFilteredProductIds(context, maModule);
            var drafts = GetDraftIds(allIds);
            var snapshot = GetSnapshot(allIds, drafts);
            if (mode == "preview")
            {
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(new {
                    ok = true, total = allIds.Count, eligible = drafts.Count,
                    skipped = allIds.Count - drafts.Count, snapshot = snapshot
                }));
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["snapshot"])
                || context.Request.Form["snapshot"] != snapshot)
                throw new Exception("Danh sách lọc hoặc trạng thái hàng hóa đã thay đổi. Hãy mở lại chức năng để xác nhận.");
            if (drafts.Count == 0)
                throw new Exception("Không có hàng hóa Soạn thảo nào cần chuyển.");

            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < drafts.Count; i += 350)
                    {
                        var batch = drafts.Skip(i).Take(350).ToList();
                        var products = db.md_sanpham.Where(p =>
                            batch.Contains(p.md_sanpham_id) && p.trangthai == Helper.SOANTHAO).ToList();
                        if (products.Count != batch.Count)
                            throw new Exception("Trạng thái vừa thay đổi. Đã hủy toàn bộ đợt chuyển.");

                        foreach (var product in products)
                        {
                            product.trangthai = "DHD";
                            product.hoatdong = true;
                            Helper.setDefaultValueWhenInsertOrUpdate(product, userTK, true);
                        }
                        db.SaveChanges();
                        foreach (var product in products)
                            db.Entry(product).State = System.Data.Entity.EntityState.Detached;
                    }
                    VNN_Function.Write_log(context, maModule, null, maCase,
                        "Chuyển " + drafts.Count + " HHVT từ SOANTHAO sang DHD theo bộ lọc jqGrid.",
                        db, true, userTK);
                    db.SaveChanges();
                    tx.Commit();
                }
                catch { tx.Rollback(); throw; }
            }
            try { VNN_Function.loaddulieu_Auto(db, maModule); } catch { }
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(new {
                ok = true, changed = drafts.Count, total = allIds.Count
            }));
        }
        catch (Exception ex)
        {
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(new {
                ok = false, message = ex.Message
            }));
        }
    }

    public void CA01ImportHHVG_MD00DSHangHoaSOANTHAO(HttpContext context)
    {
        var msg = new List<string>();
        var jsonStr = context.Request.Form["json"];
        var id = context.Request.Form["id_parent"];
        var ma_module = context.Request.QueryString["ma_module"];
        try
        {
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonStr);
            var hasErr = false;
            foreach (var item in json)
            {
                string maHHVT = item.ElementAt(0).Value.removeAllSpaceOrTrimText(true);
                string dinhkhoan = item.ElementAt(1).Value.removeAllSpaceOrTrimText(true);
                string nhomHHVT = item.ElementAt(2).Value.removeAllSpaceOrTrimText(true);
                string cbmMD = item.ElementAt(3).Value.removeAllSpaceOrTrimText(true);
                string nccMD = item.ElementAt(4).Value.removeAllSpaceOrTrimText(true);
                string khoMD = item.ElementAt(5).Value.removeAllSpaceOrTrimText(true);
                string khoton = item.ElementAt(6).Value.removeAllSpaceOrTrimText(true);
                string xuongSX = item.ElementAt(7).Value.removeAllSpaceOrTrimText(true);
                string thue = item.ElementAt(8).Value.removeAllSpaceOrTrimText(true);
                string noigiaohang = item.ElementAt(9).Value.removeAllSpaceOrTrimText(true);
                string ghichu = item.ElementAt(10).Value.removeAllSpaceOrTrimText(true);
                string trangthai = item.ElementAt(11).Value.removeAllSpaceOrTrimText(true);

                string msgDT = "", auto = "auto";
                var dinhkhoan_isNumeric = int.TryParse(dinhkhoan, out _);
                if (!dinhkhoan_isNumeric & !string.IsNullOrWhiteSpace(dinhkhoan) & dinhkhoan != auto)
                {
                    msgDT = $@"<div style='color:red' error>Định khoản phải là số</div>";
                    goto endloop;
                }

                var nhom = db.md_chungloai.Where(s => s.code_cl == nhomHHVT | s.tv_ngan == nhomHHVT).FirstOrDefault();
                if (nhom == null & nhomHHVT != auto)
                {
                    msgDT = $@"<div style='color:red' error>Không tìm thấy <b>Nhóm HHVT</b></div>";
                    goto endloop;
                }

                var ncc = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == nccMD | s.ten_dtkd == nccMD).FirstOrDefault();
                if (ncc == null & !string.IsNullOrWhiteSpace(nccMD) & nccMD != auto)
                {
                    msgDT = $@"<div style='color:red' error>Không tìm thấy <b>NCC</b></div>";
                    goto endloop;
                }

                var khoSX = db.md_kho.Where(s => s.ma_kho == khoMD | s.ten_kho == khoMD).FirstOrDefault();
                if (khoSX == null & khoMD != auto)
                {
                    msgDT = $@"<div style='color:red' error>Không tìm thấy <b>Kho SX</b></div>";
                    goto endloop;
                }

                var khoTon = db.md_kho.Where(s => s.ma_kho == khoton | s.ten_kho == khoton).FirstOrDefault();
                if (khoTon == null & khoton != auto)
                {
                    msgDT = $@"<div style='color:red' error>Không tìm thấy <b>Kho tồn</b></div>";
                    goto endloop;
                }

                var phanxuong = db.ad_department.Where(s => s.ma_phongban == xuongSX | s.ten_phongban == xuongSX).FirstOrDefault();
                if (phanxuong == null & !string.IsNullOrWhiteSpace(xuongSX) & xuongSX != auto)
                {
                    msgDT = $@"<div style='color:red' error>Không tìm thấy <b>Xưởng SX</b></div>";
                    goto endloop;
                }

                var thueVT = db.md_thue_sanpham.Where(s => s.ten_thue_sanpham == thue).FirstOrDefault();
                if (thueVT == null & thue != auto)
                {
                    msgDT = $@"<div style='color:red' error>Không tìm thấy <b>Thuế</b></div>";
                    goto endloop;
                }

                var vtServer = db.md_sanpham.Where(s => s.ma_sanpham == maHHVT & s.trangthai == Helper.SOANTHAO).FirstOrDefault();
                var vt = db.md_sanpham.Local.Where(s => s.ma_sanpham == maHHVT & s.trangthai == Helper.SOANTHAO).FirstOrDefault();
                if (vt == null)
                {
                    msgDT = $@"<div style='color:red' error>Không tồn tại hoặc không ở trạng thái <b>Soạn Thảo</b></div>";
                    goto endloop;
                }
                if (dinhkhoan != auto)
                    vt.dinhkhoan = dinhkhoan.ToNullableInt();
                if (nhomHHVT != auto)
                    vt.md_nhomnangluc_id = nhom.md_chungloai_id;
                if (cbmMD != auto)
                    vt.v2 = cbmMD.ToNullableDecimal();
                if (nccMD != auto)
                    vt.nhacungung = ncc == null ? "" : ncc.md_doitackinhdoanh_id;
                if (khoMD != auto)
                    vt.khomacdinh = khoSX.md_kho_id;
                if (khoton != auto)
                    vt.khoton = khoTon.md_kho_id;
                if (xuongSX != auto)
                    vt.phongbanId = phanxuong == null ? "" : phanxuong.md_phongban_id;
                if (thue != auto)
                    vt.md_thue_sanpham_id = thueVT.md_thue_sanpham_id;
                if (noigiaohang != auto)
                    vt.noigiaohang = noigiaohang;
                if (ghichu != auto)
                    vt.ghichu = ghichu;
                if (trangthai != auto)
                    vt.trangthai = trangthai;

                vt = Helper.setDefaultValueWhenInsertOrUpdate(vt, userTK, true);
                msgDT = $@"<div style='color:blue'>Đạt</div>";

            endloop:;

                if (!string.IsNullOrWhiteSpace(msgDT))
                {
                    if (msgDT.LastIndexOf("error") > -1)
                        hasErr = true;
                    msg.Add(msgDT);
                }
            }

            if (!hasErr)
            {
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg.Add($@"<div error style='color:red'>{ex.ToString()}</div>");
        }

        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(msg));
    }

    public string layQuyTrinhCuaXuong(EntityContext db, string xuongId)
    {
        var qtId = db.md_phanxuong_to.Where(s => s.phongbanId2 == xuongId).Select(s => s.md_phanxuong_id).FirstOrDefault();
        return qtId;
    }

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string id_parent = context.Request.Form["id_parent"];
        string maDTKD = context.Request.Form["nhacungung"].removeAllSpaceOrTrimText(true);
        string ma_sanpham = context.Request.Form["ma_sanpham"].removeAllSpaceOrTrimText(true);
        string dinhkhoan = context.Request.Form["dinhkhoan"].removeAllSpaceOrTrimText(true);

        try
        {
            string dtkdId = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == maDTKD).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();

            if (db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Count() > 0)
            {
                msg = string.Format(@"HHVT có mã {0} đã tồn tại.", ma_sanpham);
            }

            if (msg.Length <= 0)
            {
                var object_ = new md_sanpham();
                object_.md_sanpham_id = id_new;
                object_.sanpham = true;
                object_.ban_thanhpham = false;
                object_.vattu = false;
                object_.hoatdong = true;
                VNN_Function.SetFormValue(object_.nameof(s => s.nhacungung), dtkdId);
                VNN_Function.SetFormValue(object_.nameof(s => s.dinhkhoan), dinhkhoan);
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                db.md_sanpham.Add(object_);
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
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            msg = string.Format(@"false#{0}", msg);
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id_parent = context.Request.Form["id_parent"];
        string id = context.Request.Form["id"];
        string maDTKD = context.Request.Form["nhacungung"].removeAllSpaceOrTrimText(true);
        string ma_sanpham = context.Request.Form["ma_sanpham"].removeAllSpaceOrTrimText(true);
        string dinhkhoan = context.Request.Form["dinhkhoan"].removeAllSpaceOrTrimText(true);
        string trangthai = context.Request.Form["trangthai"].removeAllSpaceOrTrimText(true);

        try
        {
            string dtkdId = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == maDTKD).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();

            var object_ = db.md_sanpham.Where(p => p.md_sanpham_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                goto EndEventHandler;
            }

            var exist = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham & s.md_sanpham_id != id).FirstOrDefault();
            if (exist != null)
            {
                msg = $@"HHVT ""{ma_sanpham}"" đã tồn tại.";
                goto EndEventHandler;
            }

            if (msg.Length <= 0)
            {
                if (ma_sanpham != object_.ma_sanpham)
                {
                    //Cac dong hang SX
                    var cdhs1Server = db.md_lenhsanxuat_tosx_cdh.Where(s => s.sp1 == object_.ma_sanpham).ToList();
                    var cdhs1 = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.sp1 == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhs1)
                    {
                        cdh.sp1 = ma_sanpham;
                    }
                    var cdhs2Server = db.md_lenhsanxuat_tosx_cdh.Where(s => s.macuoi == object_.ma_sanpham).ToList();
                    var cdhs2 = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.macuoi == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhs2)
                    {
                        cdh.macuoi = ma_sanpham;
                    }
                    var cdhs3Server = db.md_lenhsanxuat_tosx_cdh.Where(s => s.mathaydoi == object_.ma_sanpham).ToList();
                    var cdhs3 = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.mathaydoi == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhs3)
                    {
                        cdh.mathaydoi = ma_sanpham;
                    }
                    var cdhs4Server = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                        s.mabo == object_.ma_sanpham |
                        s.mabo.StartsWith(object_.ma_sanpham + ",") |
                        s.mabo.EndsWith("," + object_.ma_sanpham) |
                        s.mabo.Contains("," + object_.ma_sanpham + ",")
                        ).ToList();

                    var cdhs4 = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
                       s.mabo == object_.ma_sanpham |
                       s.mabo.StartsWith(object_.ma_sanpham + ",") |
                       s.mabo.EndsWith("," + object_.ma_sanpham) |
                       s.mabo.Contains("," + object_.ma_sanpham + ",")
                       ).ToList();
                    foreach (var cdh in cdhs4)
                    {
                        var mabos = cdh.mabo.Split(',');
                        var mabosMoi = new System.Collections.Generic.List<string>();
                        foreach (var mabo in mabos)
                        {
                            if (mabo == object_.ma_sanpham)
                            {
                                mabosMoi.Add(ma_sanpham);
                            }
                            else
                            {
                                mabosMoi.Add(mabo);
                            }
                        }
                        cdh.mabo = string.Join(",", mabosMoi);
                    }
                    //Cac dong vat tu SX
                    var cdhVTs1Server = db.md_lenhsanxuat_tosx_vattu.Where(s => s.sp1 == object_.ma_sanpham).ToList();
                    var cdhVTs1 = db.md_lenhsanxuat_tosx_vattu.Local.Where(s => s.sp1 == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhVTs1)
                    {
                        cdh.sp1 = ma_sanpham;
                    }
                    var cdhVTs2Server = db.md_lenhsanxuat_tosx_vattu.Where(s => s.sp2 == object_.ma_sanpham).ToList();
                    var cdhVTs2 = db.md_lenhsanxuat_tosx_vattu.Local.Where(s => s.sp2 == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhVTs2)
                    {
                        cdh.sp2 = ma_sanpham;
                    }
                    var cdhVTs3Server = db.md_lenhsanxuat_tosx_vattu.Where(s => s.sp3 == object_.ma_sanpham).ToList();
                    var cdhVTs3 = db.md_lenhsanxuat_tosx_vattu.Local.Where(s => s.sp3 == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhVTs3)
                    {
                        cdh.sp3 = ma_sanpham;
                    }
                    //Cac dong vat tu trong BOM
                    var cdhVTBKs1Server = db.md_lenhsanxuat_tosx_vattuBackup.Where(s => s.sp1 == object_.ma_sanpham).ToList();
                    var cdhVTBKs1 = db.md_lenhsanxuat_tosx_vattuBackup.Local.Where(s => s.sp1 == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhVTBKs1)
                    {
                        cdh.sp1 = ma_sanpham;
                    }
                    var cdhVTBKs2Server = db.md_lenhsanxuat_tosx_vattuBackup.Where(s => s.sp2 == object_.ma_sanpham).ToList();
                    var cdhVTBKs2 = db.md_lenhsanxuat_tosx_vattuBackup.Local.Where(s => s.sp2 == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhVTBKs2)
                    {
                        cdh.sp2 = ma_sanpham;
                    }
                    var cdhVTBKs3Server = db.md_lenhsanxuat_tosx_vattuBackup.Where(s => s.sp3 == object_.ma_sanpham).ToList();
                    var cdhVTBKs3 = db.md_lenhsanxuat_tosx_vattuBackup.Local.Where(s => s.sp3 == object_.ma_sanpham).ToList();
                    foreach (var cdh in cdhVTBKs3)
                    {
                        cdh.sp3 = ma_sanpham;
                    }
                }
                var hoatdong = trangthai == "NHD" ? "false" : "true";
                VNN_Function.SetFormValue(object_.nameof(s => s.nhacungung), dtkdId);
                VNN_Function.SetFormValue(object_.nameof(s => s.dinhkhoan), dinhkhoan);
                VNN_Function.SetFormValue(object_.nameof(s => s.hoatdong), hoatdong);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                //object_.md_phanxuong_id = layQuyTrinhCuaXuong(db, object_.phongbanId);
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0)
        {
            msg = $@"true#Cập nhật thành công";
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            if (msg.StartsWith("<br>"))
                msg = msg.Substring(4);
            msg = $@"false#{msg}";
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id_del = context.Request.Form["id"];
        try
        {
            var object_ = db.md_sanpham.Where(p => p.md_sanpham_id == id_del).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "Lỗi:Không tìm thấy đối tượng cần xóa";
                goto EndEventHandler;
            }

            var pbg001s = db.md_giasanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg002s = db.md_sanpham_bom_vattu.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg003s = db.md_donvitinhsanpham_cddv.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();

            var pbg004s = db.c_dongdsdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg005s = db.c_donmuahang_cdmh.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg006s = db.c_nhucauvattu_ycmvt.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg007s = db.c_yeucaumuavt_cdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg008s = db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_sanpham_id == object_.md_sanpham_id
            | s.sp1 == object_.ma_sanpham
            | s.sp2 == object_.ma_sanpham
            | s.sp3 == object_.ma_sanpham).Take(1).Count();

            var pbg009s = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id
            | s.sp1 == object_.ma_sanpham
            | s.macuoi == object_.ma_sanpham
            | s.mathaydoi == object_.ma_sanpham).Take(1).Count();

            var pbg010s = db.md_nhapkhonb_cdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg011s = db.md_xuatban_cdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg012s = db.md_nhapkhoton_cdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg013s = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg014s = db.md_vanchuyennoibo_cdvc.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();
            var pbg015s = db.md_hanngach_chitiet.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Take(1).Count();

            if (pbg001s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Bảng giá""";
            if (pbg002s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""BOM""";
            if (pbg003s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""chuyển đổi đơn vị tính""";
            if (pbg004s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Đơn hàng""";
            if (pbg005s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Đơn mua hàng""";
            if (pbg006s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Nhu cầu vật tư""";
            if (pbg007s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Yêu cầu mua vật tư""";
            if (pbg008s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Bật tư của KHDH""";
            if (pbg009s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Rã bộ của KHDH""";
            if (pbg010s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Nhập nội bộ""";
            if (pbg011s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Xuất thanh lý""";
            if (pbg012s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Nhập thêm tồn""";
            if (pbg013s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Xuất kho nội bộ""";
            if (pbg014s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Chuyển nội bộ""";
            if (pbg015s > 0)
                msg += $@"<br>- HHVT đã được sử dụng trong ""Giảm hạn ngạch""";

            if (msg.Length <= 0)
            {
                VNN_Function.Write_log(context, ma_module, null, oper, "MSP:" + object_.ma_sanpham + ", TSP:" + object_.mota_tiengviet, db);
                db.md_sanpham.Remove(object_);
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0)
        {
            msg = $@"true#Xóa HHVT thành công";
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            if (msg.StartsWith("<br>"))
                msg = msg.Substring(4);
            msg = $@"false#{msg}";
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
