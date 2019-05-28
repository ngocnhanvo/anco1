using System;
using System.Linq;
using DataAcess;
using System.ComponentModel;
using System.Data;

/// <summary>
/// Summary description for Extension
/// </summary>
public static class Extension
{
    public static string Text<T>(this T t) where T : struct, IConvertible
    {
        return Enum.GetName(typeof(T), t);
    }

    public static string Description<T>(this T t) where T : struct, IConvertible
    {
        var type = t.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("Not Enum type");
        }
        var memberInfo = type.GetMember(t.ToString());
        if (memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }
        return t.ToString();
    }

    public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
    {
        var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
        var destProps = typeof(TU).GetProperties()
                .Where(x => x.CanWrite)
                .ToList();

        foreach (var sourceProp in sourceProps)
        {
            if (destProps.Any(x => x.Name == sourceProp.Name))
            {
                var p = destProps.First(x => x.Name == sourceProp.Name);
                if (p.CanWrite)
                { // check if the property can be set or no.
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }
            }
        }
    }

    public static double Round(this double value, int precision)
    {
        if (precision < -4 && precision > 15)
            throw new ArgumentOutOfRangeException("precision", "Must be and integer between -4 and 15");

        if (precision >= 0) return Math.Round(value, precision);
        else
        {
            precision = (int)Math.Pow(10, Math.Abs(precision));
            value = value + (5 * precision / 10);
            return Math.Round(value - (value % precision), 0);
        }
    }

    public static string DropTrailingZeros(this decimal value)
    {
        return value.ToString("#,#0.####");
    }

    public static decimal? Set0WhenlessThan0(this decimal value)
    {
        if(value < 0)
        {
            return 0;
        }
        else
        {
            return value;
        }
    }

    public static decimal NgoaiTeToiVND(this decimal value, string dongtienId, DateTime? ngaylap, EntityContext db)
    {
        string vndId = db.md_dongtien.Where(s => s.ma_iso == "VND").Select(s => s.md_dongtien_id).FirstOrDefault();
        var tygia = db.md_tygia.
            Where(s => 
                s.tu_dongtien_id == dongtienId & 
                s.sang_dongtien_id == vndId &
                s.hieuluc_tungay <= ngaylap &
                s.hieuluc_denngay >= ngaylap).FirstOrDefault();
        if (tygia != null)
            value = value * tygia.chia_cho.GetValueOrDefault(0);
        return value;
    }

    public static decimal TyGiaVND(string dongtienId, DateTime? ngaylap, EntityContext db)
    {
        decimal value = 1;
        string vndId = db.md_dongtien.Where(s => s.ma_iso == "VND").Select(s => s.md_dongtien_id).FirstOrDefault();
        var tygia = db.md_tygia.
            Where(s =>
                s.tu_dongtien_id == dongtienId &
                s.sang_dongtien_id == vndId &
                s.hieuluc_tungay <= ngaylap &
                s.hieuluc_denngay >= ngaylap).OrderByDescending(s=>s.hieuluc_tungay).FirstOrDefault();
        if (tygia != null)
            value = tygia.chia_cho.GetValueOrDefault(0);
        return value;
    }

    public static DateTime? ToDateTime(this object timestamp)
    {
        string a = timestamp + "";
        if (string.IsNullOrEmpty(a))
        {
            return null;
        }
        else
        {
            a = a.Replace("/Date(", "");
            a = a.Split(' ')[0];
            double b = double.Parse(a);
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddMilliseconds(b).ToLocalTime();
        }
    }

    public static md_lenhsanxuat_tosx getLSXToId_NKNB(string id_parent, EntityContext db)
    {
        var nknb = db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == id_parent).FirstOrDefault();
        var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == nknb.md_lenhsanxuat_id).FirstOrDefault();
        string[] arr = nknb.md_lenhsanxuat_tosx_id.Split(new[] { " --- " }, StringSplitOptions.None);
        string sctLSX = arr[0];
        string tentoLSX = arr[1];
        string toId = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == lsx.md_phanxuong_id &
        s.ten_to == tentoLSX).Select(s => s.md_to_id).FirstOrDefault();
        var lsxTSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_phanxuong_to_id == toId).FirstOrDefault();
        return lsxTSX;
    }

    public static md_lenhsanxuat_tosx getLSXToId_NKNB(md_nhapkhonb nknb, EntityContext db)
    {
        var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == nknb.md_lenhsanxuat_id).FirstOrDefault();
        string[] arr = nknb.md_lenhsanxuat_tosx_id.Split(new[] { " --- " }, StringSplitOptions.None);
        string sctLSX = arr[0];
        string tentoLSX = arr[1];
        string toId = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == lsx.md_phanxuong_id &
        s.ten_to == tentoLSX).Select(s => s.md_to_id).FirstOrDefault();
        var lsxTSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_phanxuong_to_id == toId).FirstOrDefault();
        return lsxTSX;
    }

    public static md_lenhsanxuat_tosx getLSXToId(string md_lenhsanxuat_tosx_id, EntityContext db)
    {
        string[] arr = md_lenhsanxuat_tosx_id.Split(new[] { " --- " }, StringSplitOptions.None);
        string sctLSX = arr[0];
        string tentoLSX = arr[1];
        var lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == sctLSX).FirstOrDefault();
        string toId = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == lsx.md_phanxuong_id &
        s.ten_to == tentoLSX).Select(s => s.md_to_id).FirstOrDefault();
        var lsxTSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_phanxuong_to_id == toId).FirstOrDefault();
        return lsxTSX;
    }

    public static md_lenhsanxuat_tosx getLSXToId_Prev(md_lenhsanxuat_tosx lsxTo, EntityContext db)
    {
        var prev = db.md_lenhsanxuat_tosx.Where(s => s.stt < lsxTo.stt & s.md_lenhsanxuat_id == lsxTo.md_lenhsanxuat_id)
            .OrderByDescending(s=>s.stt).FirstOrDefault();
        return prev;
    }
}