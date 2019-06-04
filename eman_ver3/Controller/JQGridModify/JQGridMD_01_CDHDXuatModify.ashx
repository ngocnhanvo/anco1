<%@ WebHandler Language="C#" Class="JQGridMD_01_CDHDXuatModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
using Newtonsoft.Json;
public class JQGridMD_01_CDHDXuatModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLXNB":
                this.CA_01_CapnhatSLXNB(context);
                break;
            case "loadPBSL":
                this.loadPBSL(context);
                break;
            case "CA_01_PhanBoSoLuongTheoTo":
                this.CA_01_PhanBoSoLuongTheoTo(context);
                break;
            case "CA_01_GhepVatTuXuat":
                this.CA_01_GhepVatTuXuat(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_GhepVatTuXuat(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string id = context.Request.Form["id"];
        string idpr = context.Request.Form["idpr"];
        string[] vnn = id.Split(',');
        string type = context.Request.Form["type"];
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var xknb = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == idpr).FirstOrDefault();
                if (xknb == null)
                {
                    msg = "Không tìm thấy phiếu xuất kho";
                }
                else if (xknb.trangthai == "HIEULUC")
                {
                    msg = @"Phiếu xuất kho đã ""Hiệu Lực""";
                }
                else
                {
                    var tbl = db.md_xuatkhonb_cdh.Where(s => vnn.Contains(s.md_xuatkhonb_cdh_id)).ToList();
                    if (type == "1")
                    {
                        tbl = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == idpr).ToList();
                    }

                    var groupTBL = tbl.GroupBy(s => new { s.md_sanpham_id, s.md_donvitinhsanpham_id, s.md_donvitinhsanpham_id2 }).Select(s => new md_xuatkhonb_cdh
                    {
                        md_xuatkhonb_cdh_id = Helper.getNewId(),
                        md_sanpham_id = s.Key.md_sanpham_id,
                        md_donvitinhsanpham_id = s.Key.md_donvitinhsanpham_id2,
                        md_donvitinhsanpham_id2 = s.Key.md_donvitinhsanpham_id2,
                        lsx_to = string.Join(",", s.Select(t => t.lsx_to).OrderByDescending(t => t).ToList()),
                        sl_daxuat = s.Select(t => t.sl_daxuat).Sum(),
                        sl_xuat2 = 0,
                        sl_xuat = 0,
                        tong_sl_xuat = s.Select(t => t.tong_sl_xuat).Sum(),
                        sl_muonxuat = s.Select(t => t.sl_muonxuat).Sum(),
                        sl_thucxuat = 0,
                        md_xuatkhonb_id = idpr,
                        ghino = s.Select(t => t.ghino).Sum(),
                        saiso = s.Select(t => t.saiso).Sum(),
                        bophancapnhat = us.md_phongban_id,
                        bophantao = us.md_phongban_id,
                        nguoicapnhat = us.ad_user_id,
                        nguoitao = us.ad_user_id,
                        vaitrocapnhat = us.ad_role_id,
                        vaitrotao = us.ad_role_id,
                        value_bophancapnhat = us.ten_phongban,
                        value_bophantao = us.ten_phongban,
                        value_nguoicapnhat = us.ma_user,
                        value_nguoitao = us.ma_user,
                        value_vaitrocapnhat = us.ten_role,
                        value_vaitrotao = us.ten_role,
                        ngaycapnhat = DateTime.Now,
                        ngaytao = DateTime.Now,
                        hoatdong = true,
                        mota = ""
                    });

                    db.md_xuatkhonb_cdh.RemoveRange(tbl);
                    foreach (var item in groupTBL.ToList())
                    {
                        db.md_xuatkhonb_cdh.Add(item);
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
                msg = string.Format(@"<div style=""color:blue"">Ghép vật tư thành công</div>");
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style=""color:red"">Lỗi:{0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_PhanBoSoLuongTheoTo(HttpContext context)
    {
        var db = new EntityContext();
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var jsonPost = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(context.Request.Form["jsonPost"]);
                string id = context.Request.Form["id"];
                foreach (var a in jsonPost)
                {
                    var b = a["items"].ToString();
                    var items = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(b);
                    foreach (var item in items)
                    {
                        string spid = item["md_sanpham_id"] + "", lsx_to = item["lsx_to"] + "", tong_sl_xuat = item["tong_sl_xuat"] + "";
                        var dongxk = db.md_xuatkhonb_cdh.Where(s =>
                            s.md_xuatkhonb_id == id
                            & s.md_sanpham_id == spid
                            & s.lsx_to == lsx_to).FirstOrDefault();

                        var tongsl = items.Where(s => s["md_sanpham_id"] + "" == spid).Select(s => decimal.Parse(s["tong_sl_xuat"] + "")).Sum();

                        if (dongxk == null)
                        {
                            msg = string.Format(@"HHVT ""{0}"" không tìm thấy", item["ma_sanpham"]);
                        }
                        else
                        {
                            decimal tslx = decimal.Parse(tong_sl_xuat);
                            if (dongxk.sl_toida_trongLSXTo2 < tslx)
                            {
                                msg = string.Format(@"HHVT ""{0}"" lỗi: SL xuất: {0}, SL tối đa {1}", tongsl, dongxk.sl_toida_trongLSXTo2);
                            }
                            else if (dongxk.sl_toida_trongLSXTo < tongsl)
                            {
                                msg = string.Format(@"HHVT ""{0}"" lỗi: Tổng SL: {0}, SL tối đa {1}", tongsl, dongxk.sl_toida_trongLSXTo);
                            }
                            else
                            {
                                dongxk.tong_sl_xuat = tslx;
                                dongxk.sl_xuat = dongxk.tong_sl_xuat;
                                dongxk.sl_xuat2 = dongxk.sl_xuat;
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style=""color:red"">Lỗi: {0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void loadPBSL(HttpContext context)
    {
        var db = new EntityContext();
        string id_parent = context.Request.QueryString["id"];
        var dongXKNBs = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == id_parent).ToList();
        var lsxTos = new List<Dictionary<string, object>>();
        var items = new List<Dictionary<string, object>>();
        foreach (var item in dongXKNBs)
        {
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == item.md_sanpham_id).FirstOrDefault();
            if (sp != null)
            {
                var lstTo = lsxTos.Where(s => s["ma_sanpham"] + "" == sp.ma_sanpham).FirstOrDefault();
                if (lstTo == null)
                {
                    lsxTos.Add(new Dictionary<string, object> {
                        { "md_sanpham_id", sp.md_sanpham_id },
                        { "ma_sanpham", sp.ma_sanpham },
                        { "ten_sanpham", sp.mota_tiengviet },
                        { "sl_toida", item.sl_toida_trongLSXTo },
                        { "items", null }
                    });
                }


                var to = new Dictionary<string, object>();
                to["md_sanpham_id"] = sp.md_sanpham_id;
                to["ma_sanpham"] = sp.ma_sanpham;
                to["lsx_to"] = item.lsx_to;
                to["tong_sl_xuat"] = item.tong_sl_xuat;
                items.Add(to);
            }
        }

        foreach (var item in lsxTos)
        {
            item["items"] = items.Where(s => s["md_sanpham_id"] + "" == item["md_sanpham_id"] + "").ToList();
        }

        context.Response.Write(JsonConvert.SerializeObject(lsxTos));
    }

    public void CA_01_CapnhatSLXNB(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        foreach (var xb_cdh in db.md_xuatkhonb_cdh.Where(s => vnn.Contains(s.md_xuatkhonb_cdh_id)).ToList())
        {
            var vcnb = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == xb_cdh.md_xuatkhonb_id).FirstOrDefault();
            if (vcnb.trangthai == "HIEULUC")
            {
                msg = "<div style='color:red'>Lỗi:Dòng " + vcnb.sochungtu + " đã Hiệu lực.</div>";
                break;
            }
            else
            {
                decimal sltd = xb_cdh.tong_sl_xuat.Value - xb_cdh.sl_daxuat.Value;
                if (sel_val == "0")
                {
                    xb_cdh.sl_xuat = sltd;
                    xb_cdh.sl_xuat2 = sltd;
                    xb_cdh.ghino = 0;
                    xb_cdh.sl_thucxuat = xb_cdh.sl_xuat2;
                }
                else
                {
                    if (slvc_case <= sltd)
                    {
                        xb_cdh.sl_xuat = slvc_case;
                        xb_cdh.sl_xuat2 = slvc_case;
                        xb_cdh.ghino = 0;
                        xb_cdh.sl_thucxuat = xb_cdh.sl_xuat2;
                    }
                    else
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == xb_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                        msg = "<div style='color:red'>Lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có thể chuyển tối đa là: " + sltd.DropTrailingZeros() + "</div>";
                        break;
                    }
                }
            }
        }
        if (msg.Length <= 0)
        {
            msg = "<div style='color:blue'>Cập nhật số lượng dự kiến xuất kho thành công</div>";
            db.SaveChanges();
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        string md_donvitinhsanpham_id = context.Request.Form["md_donvitinhsanpham_id"];

        decimal nhanvoi = 1, saiso = 0;
        try
        {
            string ghichu_donvi2 = "";
            string id = context.Request.Form["id_parent"];
            decimal sl_xuat = decimal.Parse(context.Request.Form["sl_xuat"]);
            var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
            var nb = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == id).FirstOrDefault();

            var nht = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == id & s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
            var kho_sp = db.md_kho_sanpham.Where(s => s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
            if (nb.trangthai == "HIEULUC")
            {
                msg = "false#Lỗi: Số chứng từ : " + nb.sochungtu + " đã hiệu lực,";
            }
            else if (sp == null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không tồn tại.";
            }
            else if (nht != null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" đã tồn tại.";
            }
            else if (kho_sp == null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không có trong kho.";
            }
            else if (kho_sp.soluong < sl_xuat)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" số lượng trong kho không đủ.";
            }
            else if (sl_xuat < 0)
            {
                msg = "false#Lỗi: Số lượng xuất phải lớn hơn 0";
            }
            else if (sp.md_donvitinhsanpham_id != md_donvitinhsanpham_id)
            {
                var dvtsp_cddv = db.md_donvitinhsanpham_cddv.Where(s => s.md_donvitinhsanpham_id == md_donvitinhsanpham_id
                & s.md_dvtsp_id == sp.md_donvitinhsanpham_id & s.md_sanpham_id == sp.ma_sanpham).Take(1).FirstOrDefault();
                if (dvtsp_cddv != null)
                {
                    string ten_dvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                    string ten_dvt2 = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                    nhanvoi = dvtsp_cddv.nhanvoi.Value;
                    saiso = dvtsp_cddv.chiacho.Value * sl_xuat;
                    if (saiso > dvtsp_cddv.saiso_toida.Value | saiso < 0)
                        saiso = dvtsp_cddv.saiso_toida.Value;
                    ghichu_donvi2 += "Xuất " + sl_xuat + " " + ten_dvt;
                    ghichu_donvi2 += "\n => 1 " + ten_dvt + " = " + nhanvoi.DropTrailingZeros() + " " + ten_dvt2;
                    ghichu_donvi2 += " (Sai số cho phép: " + dvtsp_cddv.chiacho.Value.DropTrailingZeros() + " " + ten_dvt2 + ")";
                    ghichu_donvi2 += "\n => " + sl_xuat + " " + ten_dvt + " = " + (sl_xuat * nhanvoi).DropTrailingZeros() + " " + ten_dvt2;
                    ghichu_donvi2 += " (Sai số cho phép: " + saiso.DropTrailingZeros() + " " + ten_dvt2 + ")";
                }
                else
                {
                    msg = "false#Đơn vị tính đã chọn không thể quy đổi.";
                }
            }

            sl_xuat = sl_xuat * nhanvoi;
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_xuatkhonb_id", "md_donvitinhsanpham_id2", "sl_xuat2", "saiso" };
                string ten_table = "md_xuatkhonb_cdh";
                VNN_Function.SetFormValue("md_xuatkhonb_id", id);
                VNN_Function.SetFormValue("ghichu_donvi2", ghichu_donvi2);
                VNN_Function.SetFormValue("tong_sl_xuat", sl_xuat.ToString());
                VNN_Function.SetFormValue("sl_xuat", sl_xuat.ToString());
                VNN_Function.SetFormValue("sl_xuat2", (sl_xuat * nhanvoi).ToString());
                VNN_Function.SetFormValue("saiso", saiso.ToString());
                VNN_Function.SetFormValue("md_donvitinhsanpham_id", sp.md_donvitinhsanpham_id);
                VNN_Function.SetFormValue("md_donvitinhsanpham_id2", sp.md_donvitinhsanpham_id);
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
                VNN_Function.SetFormValue("tenhang", sp.mota_tiengviet);
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
        decimal tong_sl_xuat = decimal.Parse(context.Request.Form["tong_sl_xuat"]);
        decimal sl_xuat = decimal.Parse(context.Request.Form["sl_xuat"]);
        decimal ghino = decimal.Parse(context.Request.Form["ghino"]);
        decimal truno = decimal.Parse(context.Request.Form["truno"]);
        string md_donvitinhsanpham_id = context.Request.Form["md_donvitinhsanpham_id"];
        decimal nhanvoi = 1, saiso = 0;
        try
        {
            string id = context.Request.Form["id"];
            var object_ = db.md_xuatkhonb_cdh.Where(p => p.md_xuatkhonb_cdh_id == id).Take(1).FirstOrDefault();
            var xnb = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == object_.md_xuatkhonb_id).Take(1).FirstOrDefault();
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).FirstOrDefault();
            string ghichu_donvi2 = "";
            string ten_dvt = db.md_donvitinhsanpham.
                    Where(s => s.md_donvitinhsanpham_id == md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
            string ten_dvt2 = db.md_donvitinhsanpham.
                    Where(s => s.md_donvitinhsanpham_id == object_.md_donvitinhsanpham_id2).Select(s => s.ten_dvt).FirstOrDefault();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (xnb.bosung != 1)
            {
                if (tong_sl_xuat != object_.tong_sl_xuat)
                    msg = "false#Chỉ có thể sửa phiếu Bổ sung";
            }

            if (sl_xuat <= 0)
            {
                msg = "false#Số lượng xuất phải lớn hớn 0";
            }

            else if (object_.md_donvitinhsanpham_id2 != md_donvitinhsanpham_id)
            {
                var dvtsp_cddv = db.md_donvitinhsanpham_cddv.
                        Where(s =>
                            s.md_donvitinhsanpham_id == md_donvitinhsanpham_id
                            & s.md_dvtsp_id == sp.md_donvitinhsanpham_id
                            & s.md_sanpham_id == sp.ma_sanpham
                        ).Take(1).FirstOrDefault();

                if (dvtsp_cddv != null)
                {
                    nhanvoi = dvtsp_cddv.nhanvoi.Value;
                    saiso = dvtsp_cddv.chiacho.Value * sl_xuat;
                    if (saiso > dvtsp_cddv.saiso_toida.Value | saiso < 0)
                        saiso = dvtsp_cddv.saiso_toida.Value;
                    ghichu_donvi2 += "=> 1 " + ten_dvt + " = " + nhanvoi.DropTrailingZeros() + " " + ten_dvt2;
                    ghichu_donvi2 += " (Sai số cho phép: " + dvtsp_cddv.chiacho.Value.DropTrailingZeros() + " " + ten_dvt2 + ")";
                    if (sl_xuat > 1)
                    {
                        ghichu_donvi2 += "\n=> " + sl_xuat + " " + ten_dvt + " = " + (sl_xuat * nhanvoi).DropTrailingZeros() + " " + ten_dvt2;
                        ghichu_donvi2 += " (Sai số cho phép: " + saiso.DropTrailingZeros() + " " + ten_dvt2 + ")";
                    }
                }
                else
                {
                    msg = "false#Đơn vị tính đã chọn không thể quy đổi.";
                }
            }

            if ((sl_xuat * nhanvoi - saiso) > object_.tong_sl_xuat)
            {
                msg = string.Format(@"false#Chỉ có thể xuất số lượng tối đa là: ""{0} {1}""",
                    object_.tong_sl_xuat.Value.DropTrailingZeros(), ten_dvt2);
                msg += string.Format(@"<br> + Số lượng đang muốn xuất: ""{0} {1}""",
                    (sl_xuat * nhanvoi).DropTrailingZeros(), ten_dvt2);
                msg += string.Format(@"<br> + Độ sai lệch cho phép: ""{0} {1}""",
                    saiso.DropTrailingZeros(), ten_dvt2);
            }

            foreach (var ncc in db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id).ToList())
            {
                if (ncc.trangthai == "HIEULUC")
                {
                    msg = "false#Đơn hàng đã hiệu lực !";
                }
            }

            decimal sl_xuat2 = sl_xuat * nhanvoi;
            if (msg.Length <= 0)
            {
                object_.ghichu_donvi2 = ghichu_donvi2;
                object_.ghino = ghino;
                object_.sl_xuat = sl_xuat;
                object_.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
                object_.saiso = saiso;
                object_.sl_xuat2 = sl_xuat2;
                object_.truno = truno;
                object_.sl_thucxuat = object_.sl_xuat2 + object_.ghino;
                db.SaveChanges();
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.(--)" + object_.sl_xuat2;
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
            string ten_table = "md_xuatkhonb_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_xuatkhonb_cdh object_ = db.md_xuatkhonb_cdh.Where(p => p.md_xuatkhonb_cdh_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "<br>";
                }
                else
                {
                    md_xuatkhonb nb = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id).FirstOrDefault();
                    var xnb_cdhs = from a in db.md_vanchuyennoibo_cdvc
                                   join b in db.md_vanchuyennoibo on a.md_vanchuyennoibo_id equals b.md_vanchuyennoibo_id
                                   where b.chungtuthamchieu == nb.sochungtu & a.md_sanpham_id == object_.md_sanpham_id
                                   select new { a.md_vanchuyennoibo_cdvc_id };
                    if (nb.trangthai == "HIEULUC")
                    {
                        msg_del = "false#Lỗi: Số chứng từ : " + nb.sochungtu + " đã hiệu lực,";
                        msg += msg_del + "<br>";
                    }
                    else if (xnb_cdhs.Count() > 0)
                    {
                        msg_del = "Lỗi:\"" + nb.sochungtu + "\" có phiếu vận chuyển nội bộ đang sử dụng dòng hàng này.";
                        msg += msg_del + "<br>";
                    }
                }

                if (msg_del.Length <= 0)
                {
                    db.md_xuatkhonb_cdh.Remove(object_);
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