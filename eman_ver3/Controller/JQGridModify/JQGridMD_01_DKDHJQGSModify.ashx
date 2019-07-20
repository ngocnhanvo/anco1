<%@ WebHandler Language="C#" Class="JQGridMD_01_DKDHJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DKDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            default:
                break;
        }
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_doichieuhangton_dkdh";
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
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string[] id_del = context.Request.Form["id"].Split(',');
                for (int i = 0; i < id_del.Length; i++)
                {
                    var id_del_ = id_del[i];
                    var object_ = db.c_doichieuhangton_dkdh.Where(p => p.c_doichieuhangton_dkdh_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format("Lỗi dòng {1}: Không tìm thấy đối tượng cần xóa<br>", "", i + 1);
                    }
                    else
                    {
                        var dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
                        if (dcht == null)
                        {
                            msg += string.Format("Lỗi dòng {1}: Không tìm thấy phiếu đối chiếu hàng tồn<br>", "", i + 1);
                        }
                        else if (!string.IsNullOrEmpty(dcht.phieuhangton) & dcht.phieuhangton != " ")
                        {
                            msg += string.Format("Lỗi dòng {1}: {0} Đã lập phiếu lấy hàng tồn<br>", dcht.ten_donhang, i + 1);
                        }
                        else if (!string.IsNullOrEmpty(dcht.kehoach) & dcht.kehoach != " ")
                        {
                            msg += string.Format("Lỗi dòng {1}: {0} Đã lập kế hoạch đặt hàng<br>", dcht.ten_donhang, i + 1);
                        }
                        else
                        {
                            db.c_doichieuhangton_dkdh.Remove(object_);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = string.Format("Lỗi: {0}", ex.Message);
            }

            if (msg.Length <= 0)
            {
                transaction.Commit();
                msg = "true#Xóa thành công.";
            }
            else
            {
                transaction.Rollback();
                msg = "false#" + msg;
            }

            VNN_Function.loaddulieu_Auto(db, ma_module);
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
