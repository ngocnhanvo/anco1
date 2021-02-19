<%@ WebHandler Language="C#" Class="JQGridMD_01_DKDHJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DKDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            default:
                break;
        }
    }

    public void add(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        decimal sl_dat = decimal.Parse(context.Request.Form["sl_dat"]);
        decimal sl_conlai = decimal.Parse(context.Request.Form["sl_conlai"]);
        decimal sl_conlai2 = decimal.Parse(context.Request.Form["sl_conlai2"]);

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                //string id = context.Request.Form["id_parent"];
                c_doichieuhangton_dkdh object_ =
                    db.c_doichieuhangton_dkdh.Where(p => p.c_doichieuhangton_dkdh_id == id)
                        .Take(1)
                        .FirstOrDefault();
                c_doichieuhangton dc = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (dc.kehoach != " " & dc.kehoach != null)
                {
                    msg = "Lỗi: \"" + dc.ten_donhang + "\" đã lập kế hoạch";
                }
                else if (sl_conlai > sl_conlai2)
                {
                    msg = "Lỗi: Không thể vượt quá số lượng tồn kho hiện có : \"" + sl_conlai2 + "\"";
                }
                if (msg.Length <= 0)
                {
                    var dklht = db.c_doichieuhangton_dklht.FirstOrDefault(
                    s => s.c_doichieuhangton_id == dc.c_doichieuhangton_id & s.md_sanpham_id == object_.md_sanpham_id);

                    if (dklht != null)
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).FirstOrDefault();

                        if (sp.ma_sanpham == object_.macuoi)
                        {
                            dklht.sl_lay = sl_conlai;
                            object_.sl_conlai = sl_conlai;
                            object_.sl_dat = object_.sl_dathang_cp - object_.sl_giamhanngach.GetValueOrDefault(0) - sl_conlai;
                            db.SaveChanges();
                            dequyDCTHT_CDH(db, sp.ma_sanpham, sp.md_sanpham_id, object_);
                        }
                        else
                        {
                            var spmId = db.md_sanpham.Where(s => s.ma_sanpham == object_.macuoi).Select(s => s.md_sanpham_id).FirstOrDefault();
                            var dklhtMain = db.c_doichieuhangton_dkdh.FirstOrDefault(
                            s => s.c_doichieuhangton_id == dc.c_doichieuhangton_id & s.md_sanpham_id == spmId);
                            if (dklhtMain != null)
                            {
                                dklht.sl_lay = sl_conlai;
                                object_.sl_conlai = sl_conlai;
                                object_.sl_dat = dklhtMain.sl_dat - sl_conlai;
                                db.SaveChanges();
                                dequyDCTHT_CDH(db, sp.ma_sanpham, sp.md_sanpham_id, object_);
                            }
                            else {
                                string[] mspCuoi = object_.macuoi_id.Split(',');
                                if(mspCuoi.Length > 0)
                                {
                                    var sldat = db.c_doichieuhangton_dkdh.Where(s =>
                                        mspCuoi.Contains(s.md_sanpham_id)
                                        & s.c_doichieuhangton_id == object_.c_doichieuhangton_id).Sum(s => s.sl_dat);

                                    dklht.sl_lay = sl_conlai;
                                    object_.sl_conlai = sl_conlai;
                                    object_.sl_dat = sldat - sl_conlai;
                                    db.SaveChanges();
                                    dequyDCTHT_CDH(db, sp.ma_sanpham, sp.md_sanpham_id, object_);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                transaction.Commit();
                msg = string.Format("true#Cập nhật số lượng lấy tồn thành công.");
            }
            else
            {
                transaction.Rollback();
                msg = string.Format("false#Lỗi:{0}.", msg);
            }
        }
        context.Response.Write(msg);
    }

    public void dequyDCTHT_CDH(EntityContext db, string masp, string spId, c_doichieuhangton_dkdh object_)
    {
        foreach (var object2_ in db.c_doichieuhangton_dkdh.Where(s => s.macuoi.Contains(masp) & s.md_sanpham_id != spId
        & s.c_doichieuhangton_id == object_.c_doichieuhangton_id).ToList())
        {
            string[] mspCuoi = object2_.macuoi_id.Split(',');
            if (mspCuoi.Length <= 1)
            {
                object2_.sl_conlai = object_.sl_dat < object2_.sl_conlai ? object_.sl_dat : object2_.sl_conlai;
                object2_.sl_dat = object_.sl_dat - object2_.sl_conlai;
                db.SaveChanges();
            }
            else
            {
                var sldat = db.c_doichieuhangton_dkdh.Where(s =>
                    mspCuoi.Contains(s.md_sanpham_id)
                    & s.c_doichieuhangton_id == object2_.c_doichieuhangton_id).Sum(s => s.sl_dat);

                object2_.sl_conlai =sldat < object2_.sl_conlai ? sldat : object2_.sl_conlai;
                object2_.sl_dat = sldat - object2_.sl_conlai;
                db.SaveChanges();
            }
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == object2_.md_sanpham_id).FirstOrDefault();
            dequyDCTHT_CDH(db, sp.ma_sanpham, sp.md_sanpham_id, object2_);
        }
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
                    var object_ = db.c_doichieuhangton_dkdh.Where(p => p.c_doichieuhangton_dkdh_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else
                    {
                        var dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
                        if (dcht == null)
                        {
                            msg += string.Format(@"<br>Không tìm thấy phiếu đối chiếu hàng tồn.");
                        }
                        else if (!string.IsNullOrWhiteSpace(dcht.kehoach))
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Đã lập kế hoạch đặt hàng.", dcht.ten_donhang);
                        }
                        else if (!string.IsNullOrWhiteSpace(dcht.phieuhangton))
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Đã lập phiếu lấy hàng tồn.", dcht.ten_donhang);
                        }
                        else
                        {
                            VNN_Function.Write_log(context, ma_module, null, oper, "TĐCHT:" + dcht.ten_donhang + ", " + object_.md_sanpham_id, db);
                            db.c_doichieuhangton_dkdh.Remove(object_);
                            db.SaveChanges();
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
                msg = string.Format(@"true#Xóa dự kiến đặt hàng đã chọn thành công");
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
