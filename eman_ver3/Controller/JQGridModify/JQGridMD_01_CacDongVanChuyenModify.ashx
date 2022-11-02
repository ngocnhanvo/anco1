<%@ WebHandler Language="C#" Class="JQGridMD_01_CacDongVanChuyenModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_01_CacDongVanChuyenModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLcanchuyen":
                this.CA_01_CapnhatSLcanchuyen(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapnhatSLcanchuyen(HttpContext context)
    {
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        md_vanchuyennoibo vcnb = null;
        using (var transaction = db.Database.BeginTransaction())
        {
            var objSelfsVCNBDHSav = new List<Dictionary<string, string>>();
            foreach (var cdvc in db.md_vanchuyennoibo_cdvc.Where(s => vnn.Contains(s.md_vanchuyennoibo_cdvc_id)).ToList())
            {
                vcnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == cdvc.md_vanchuyennoibo_id).FirstOrDefault();
                if (vcnb.md_trangthai_id == "HIEULUC")
                {
                    msg = "<div style='color:red'>Lỗi:Dòng " + vcnb.sochungtu + " đã Hiệu lực.</div>";
                    break;
                }
                else
                {
                    objSelfsVCNBDHSav.Add(new Dictionary<string, string>() {
                        { "id", cdvc.md_vanchuyennoibo_cdvc_id },
                        { "sl", cdvc.soluong_dichchuyen.GetValueOrDefault(0).ToString() }
                    });

                    decimal sltd = cdvc.soluong_muonchuyen.Value - cdvc.soluong_dachuyen.Value;
                    if (sel_val == "0")
                    {
                        cdvc.soluong_dichchuyen = sltd;
                    }
                    else
                    {
                        if (slvc_case <= sltd)
                        {
                            cdvc.soluong_dichchuyen = slvc_case;
                        }
                        else
                        {
                            md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdvc.md_sanpham_id).Take(1).FirstOrDefault();
                            msg = "<div style='color:red'>lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có thể chuyển tối đa là: " + Math.Round(sltd, 0) + "</div>";
                            break;
                        }
                    }
                    cdvc.ngaycapnhat = DateTime.Now;
                    db.SaveChanges();
                }
            }

            if (vcnb.loaichuyen == "VANCNBCTKGH")
            {
                var objSelfs = new List<LSX_TSX>();
                var objSelfsVCNBDH = new List<md_vanchuyennoibo_cdvc>();

                var slcl = new List<Dictionary<string, object>>();
                foreach (var b in db.md_vanchuyennoibo_cdvc.Where(s =>
                    s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id
                    & (s.soluong_dichchuyen > 0 | vnn.Contains(s.md_vanchuyennoibo_cdvc_id))).ToList())
                {
                    var sp = db.md_sanpham.Where(s => s.md_sanpham_id == b.md_sanpham_id).FirstOrDefault();
                    var lsxTSX = Extension.getLSXToId2(b.lsx_to, db);
                    var tsx = lsxTSX.tsx;
                    var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                        s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                        & s.macuoi.Contains(sp.ma_sanpham));
                    if(vnn.Contains(b.md_vanchuyennoibo_cdvc_id))
                    {
                        objSelfs.Add(lsxTSX);
                        objSelfsVCNBDH.Add(b);
                    }

                    foreach (var cai in lsxSp.ToList())
                    {
                        var caiJSon = slcl.Where(s => s["md_sanpham_id"] + "" == cai.md_sanpham_id).FirstOrDefault();
                        if (caiJSon == null)
                        {
                            var spCai = db.md_sanpham.Where(s => s.md_sanpham_id == cai.md_sanpham_id).FirstOrDefault();
                            var khosp = db.md_kho_sanpham.Where(s => s.md_sanpham_id == spCai.md_sanpham_id & s.md_kho_id == vcnb.tukho).FirstOrDefault();
                            var slCai = cai.sl_dahoanthanh.GetValueOrDefault(0)- cai.sl_dagiao.GetValueOrDefault(0);
                            var slKho = khosp == null ? 0 : khosp.soluong.GetValueOrDefault(0);

                            slcl.Add(new Dictionary<string, object>() {
                                    { "md_sanpham_id", cai.md_sanpham_id },
                                    { "ma_sanpham", spCai.ma_sanpham },
                                    { "lsx_to", b.lsx_to },
                                    { "soluong", b.soluong_dichchuyen },
                                    { "sltd", slCai < slKho ? slCai : slKho }
                                });
                        }
                        else
                        {
                            caiJSon["soluong"] = b.soluong_dichchuyen + decimal.Parse(caiJSon["soluong"].ToString());
                        }
                    }
                }

                foreach (var itemSLTH in slcl.OrderBy(s => s["ma_sanpham"].ToString()))
                {
                    string spId = itemSLTH["md_sanpham_id"].ToString();

                    var sl = decimal.Parse(itemSLTH["soluong"].ToString());
                    var sltd = decimal.Parse(itemSLTH["sltd"].ToString());
                    if (sl > sltd)
                    {
                        msg += string.Format(@"<b>{0}</b> SL tối đa <b>{1}</b>, SL muốn chuyển <b>{2}</b>.<br>",
                            itemSLTH["ma_sanpham"], sltd.DropTrailingZeros(), sl.DropTrailingZeros());
                    }
                }
            }

            if (msg.Length <= 0)
            {
                msg = "<div style='color:blue'>Cập nhật số lượng cần chuyển thành công</div>";
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        decimal soluong_dichchuyen = decimal.Parse(context.Request.Form["soluong_dichchuyen"]);

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var object_ = db.md_vanchuyennoibo_cdvc.Where(p => p.md_vanchuyennoibo_cdvc_id == id).Take(1).FirstOrDefault();
                var vnnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == object_.md_vanchuyennoibo_id).Take(1).FirstOrDefault();
                decimal soluong_td_dc = (object_.soluong_toida.Value - object_.soluong_dachuyen.Value);
                if (object_ == null)
                {
                    msg = "Lỗi: Không tìm thấy đối tượng cần sửa.";
                }
                else if (vnnb.md_trangthai_id == "HIEULUC")
                {
                    msg = "Lỗi:Dòng " + vnnb.sochungtu + " đã Hiệu lực";
                }
                else if (soluong_dichchuyen < 0)
                {
                    msg = "Lỗi: Số lượng dịch chuyển không được âm.";
                }
                else if (soluong_td_dc < soluong_dichchuyen)
                {
                    msg = "Lỗi: Số lượng dịch chuyển tối đa là:" + soluong_td_dc;
                }


                if (msg.Length <= 0)
                {
                    object_.soluong_dichchuyen = soluong_dichchuyen;
                    db.SaveChanges();

                    if (vnnb.loaichuyen == "VANCNBCTKGH")
                    {
                        var slcl = new List<Dictionary<string, object>>();
                        foreach (var b in db.md_vanchuyennoibo_cdvc.Where(s =>
                            s.md_vanchuyennoibo_id == object_.md_vanchuyennoibo_id).ToList())
                        {
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == b.md_sanpham_id).FirstOrDefault();
                            var tsx = Extension.getLSXToId(b.lsx_to, db);
                            var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                                s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                                & s.macuoi.Contains(sp.ma_sanpham));


                            foreach (var cai in lsxSp.ToList())
                            {
                                var caiJSon = slcl.Where(s => s["md_sanpham_id"] + "" == cai.md_sanpham_id).FirstOrDefault();
                                if (caiJSon == null)
                                {
                                    var spCai = db.md_sanpham.Where(s => s.md_sanpham_id == cai.md_sanpham_id).FirstOrDefault();
                                    var khosp = db.md_kho_sanpham.Where(s => s.md_sanpham_id == spCai.md_sanpham_id & s.md_kho_id == vnnb.tukho).FirstOrDefault();
                                    var slCai = cai.sl_dahoanthanh.GetValueOrDefault(0) - cai.sl_dagiao.GetValueOrDefault(0);
                                    var slKho = khosp == null ? 0 : khosp.soluong.GetValueOrDefault(0);

                                    slcl.Add(new Dictionary<string, object>() {
                                    { "md_sanpham_id", cai.md_sanpham_id },
                                    { "ma_sanpham", spCai.ma_sanpham },
                                    { "lsx_to", b.lsx_to },
                                    { "soluong", b.soluong_dichchuyen },
                                    { "sltd", slCai < slKho ? slCai : slKho }
                                });
                                }
                                else
                                {
                                    caiJSon["soluong"] = b.soluong_dichchuyen + decimal.Parse(caiJSon["soluong"].ToString());
                                }
                            }
                        }

                        foreach (var itemSLTH in slcl.OrderBy(s => s["ma_sanpham"].ToString()))
                        {
                            string spId = itemSLTH["md_sanpham_id"].ToString();

                            var sl = decimal.Parse(itemSLTH["soluong"].ToString());
                            var sltd = decimal.Parse(itemSLTH["sltd"].ToString());
                            if (sl > sltd)
                            {
                                msg += string.Format(@"<b>{0}</b> SL tối đa <b>{1}</b>, SL muốn chuyển <b>{2}</b>.<br>",
                                    itemSLTH["ma_sanpham"], sltd.DropTrailingZeros(), sl.DropTrailingZeros());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Lỗi:" + ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "true#Cập nhật thành công.";
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
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