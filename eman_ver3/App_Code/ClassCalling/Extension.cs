using System;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Globalization;

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
        return value.ToString("0.####");
    }

    public static decimal ToDecimal(this string value)
    {
        return Convert.ToDecimal(value, CultureInfo.InvariantCulture);
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
                s.hieuluc_tungay >= ngaylap &
                s.hieuluc_denngay <= ngaylap).FirstOrDefault();
        if (tygia != null)
            value = value * tygia.chia_cho.GetValueOrDefault(0);
        return value;
    }
}