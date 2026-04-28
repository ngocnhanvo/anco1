using DataAcess;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Fields;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
namespace vnnhan00000
{
    public class API_SyncData_Execute
    {
        public List<md_phieuthongtinsanpham_log_ancotrading> logs { get; set; }
        public string md_phieuthongtinsanpham_id { get; set; }
        public bool? chophepcapnhatDB { get; set; }
        public API_SyncData_Execute(List<md_phieuthongtinsanpham_log_ancotrading> logslc = null, string idlc = null, bool cplc = false)
        {
            logs = logslc;
            md_phieuthongtinsanpham_id = idlc;
            chophepcapnhatDB = cplc;
        }

        private class resultDetail
        {
            public bool? ok { get; set; }
            public dynamic result { get; set; }
            public string msg { get; set; }
        }

        public dynamic getDetailLog(string id, HttpContext context)
        {
            string msg = "";
            try
            {
                string formData = $"";
                formData += $"oper=logs_detail";
                formData += $"&logid={id}";
                string link = $"{Helper.urlSync_ANCO}/Controllers/API_Data.ashx";
                msg = VNN_VariablePublic.GetModule(link, formData, context);
                var json = JsonConvert.DeserializeObject<resultDetail>(msg);
                if (json.ok.GetValueOrDefault(false))
                {
                    return json.result[0];
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        public bool MapData(HttpContext context, EntityContext db)
        {
            var updated = false;
            if (logs == null)
                logs = db.md_phieuthongtinsanpham_log_ancotrading.Where(s => s.md_phieuthongtinsanpham_id == md_phieuthongtinsanpham_id).OrderBy(s => s.ngaytao).ToList();

            foreach (var log in logs)
            {
                var laTableSP = log.table == typeof(md_sanpham).Name;
                var laDongGoiSP = log.table == typeof(md_donggoisanpham_ancotrading).Name.Replace("_ancotrading", "");
                var laGiaSP = log.table == typeof(md_giasanpham).Name;
                string classTB = laTableSP ? log.table : $"{log.table}_ancotrading";
                // Tìm Type tương ứng với tên bảng
                var entityType = db.GetType().GetProperties()
                   .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                   .Select(p => p.PropertyType.GetGenericArguments()[0])
                   .FirstOrDefault(t => t.Name == classTB);
                if (entityType == null) continue;

                dynamic rs = null;
                // Nếu là xóa thì không cần gọi hàm lấy chi tiết (vì đằng nào cũng null)
                if (log.hanhdong != "del")
                {
                    rs = getDetailLog(log.ad_log_id, context);
                    // Chỉ continue nếu không phải lệnh xóa mà lại không lấy được dữ liệu
                    if (rs == null) continue;

                    string masp = rs.ma_sanpham;
                    string tendvt = rs.ten_dvt_tv;
                    if (laTableSP)
                    {
                        rs.md_sanpham_id = db.md_sanpham.Where(s => s.ma_sanpham == masp).Select(s => s.md_sanpham_id).FirstOrDefault();
                        rs.md_donvitinhsanpham_id = db.md_donvitinhsanpham.Where(s=>s.ten_dvt == tendvt).Select(s => s.md_donvitinhsanpham_id).FirstOrDefault();
                        rs.md_nhomnangluc_id2 = rs.md_nhomnangluc_id;
                        var jObj = rs as Newtonsoft.Json.Linq.JObject;
                        if (jObj != null)
                        {
                            // Xóa thuộc tính md_nhomnangluc_id
                            jObj.Remove("md_nhomnangluc_id");
                            jObj.Remove("vattu");
                            jObj.Remove("ban_thanhpham");
                            if (log.hanhdong == "add")
                            {
                                rs.sanpham = true;
                            }
                            else
                            {
                                jObj.Remove("sanpham");
                                jObj.Remove("mota");
                                jObj.Remove("ghichu");
                            }
                        }
                    }
                    else if(laDongGoiSP)
                    {
                        rs.md_sanpham_id = db.md_sanpham.Where(s => s.ma_sanpham == masp).Select(s => s.md_sanpham_id).FirstOrDefault();
                    }
                    else if (laGiaSP)
                    {
                        rs.md_sanpham_id = db.md_sanpham.Where(s => s.ma_sanpham == masp).Select(s => s.md_sanpham_id).FirstOrDefault();
                    }
                }


                // Chuyển đổi dữ liệu dynamic sang Object thực tế
                var entity = log.hanhdong == "del" ?
                        Activator.CreateInstance(entityType) :
                        JsonConvert.DeserializeObject(JsonConvert.SerializeObject(rs), entityType);
                string primaryKeyName = $"{classTB}_id";
                string sourceKeyName = $"{log.table}_id";
                var prop = entityType.GetProperty(primaryKeyName);


                if (log.hanhdong == "add")
                {
                    prop.SetValue(entity, Convert.ChangeType(Helper.getNewId(), prop.PropertyType));
                    db.Set(entityType).Add(entity);
                    updated = true;
                }
                else
                {
                    var sourceProp = entityType.GetProperty(sourceKeyName);
                    if (sourceProp == null)
                    {
                        continue;
                    }

                    if (log.hanhdong == "del")
                    {
                        sourceProp.SetValue(entity, Convert.ChangeType(log.id_lienket, sourceProp.PropertyType));
                    }
                    var sourceIdValue = sourceProp?.GetValue(entity);
                    string sql = $"SELECT {primaryKeyName} FROM {classTB} WHERE {sourceKeyName} = @p0";
                    // Sử dụng IEnumerable (không dùng dynamic) để C# nhận diện được LINQ
                    var result = db.Database.SqlQuery(prop.PropertyType, sql, sourceIdValue);
                    object actualId = null;
                    foreach (var item in result) // dynamic tự động duyệt được qua DbRawSqlQuery
                    {
                        actualId = item;
                        break; // Chỉ lấy dòng đầu tiên
                    }

                    if (actualId == null)
                    {
                        if (log.hanhdong == "edit")
                        {
                            prop.SetValue(entity, Convert.ChangeType(Helper.getNewId(), prop.PropertyType));
                            db.Set(entityType).Add(entity);
                        }
                        updated = true;
                    }
                    else
                    {
                        var destProp = entityType.GetProperty(primaryKeyName);
                        destProp.SetValue(entity, actualId);
                        switch (log.hanhdong)
                        {
                            case "edit":
                                // 1. Tận dụng destProp và actualId để tìm trong Local Cache
                                var localEntity = Enumerable.Cast<object>(db.Set(entityType).Local)
                                    .FirstOrDefault(x => destProp.GetValue(x).Equals(actualId));

                                if (localEntity != null)
                                {
                                    // "Đuổi" thực thể cũ ra nếu trùng ID
                                    db.Entry(localEntity).State = EntityState.Detached;
                                }
                                // 1. Attach entity vào context nếu nó chưa được track
                                db.Set(entityType).Attach(entity);
                                // 2. Ép kiểu rs về JObject để lấy danh sách các property đang có
                                var jObj = rs as Newtonsoft.Json.Linq.JObject;
                                if (jObj != null)
                                {
                                    foreach (var property in jObj.Properties())
                                    {
                                        string propertyName = property.Name;

                                        // Kiểm tra xem property này có tồn tại trong Entity không (tránh lỗi sai tên cột)
                                        var propInfo = entityType.GetProperty(propertyName);
                                        if (propInfo != null)
                                        {
                                            // Chỉ đánh dấu cột này là cần update
                                            db.Entry(entity).Property(propertyName).IsModified = true;
                                        }
                                    }
                                }
                                updated = true;
                                break;
                            case "del":
                                var entry = db.Entry(entity);
                                if (entry.State == EntityState.Detached)
                                {
                                    db.Set(entityType).Attach(entity);
                                }
                                db.Set(entityType).Remove(entity);
                                updated = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (updated)
            {
                //db.md_phieuthongtinsanpham_log_ancotrading.RemoveRange(logs);
                if (chophepcapnhatDB.GetValueOrDefault(false))
                    db.SaveChanges();
            }

            return updated;
        }
    }
}