using System;
using System.Linq;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary;
using DataAcess;

public class VNN_VariablePublic
{
    public static string[] session_bd = new string[300];
    public static string Model_infor = "";
    public static string Form_infor = "";
    public static string auto_update_ad_selectoption = "";
    public static bool linqtosql_exec = false;
    public static int error_detail = 0;
    public static string error_content = "";
    public static bool view_origination = false;
	public static string format_so = "";
	public static Worksheet ws = null;
    
	public static string[] Module_script()
    {
        string[] kq = new string[3];
        ADmin_JSON json = new ADmin_JSON();
        List<ad_module> modules = json.ad_moduleJSON();
        foreach (ad_module mod in modules.Where(s => s.hoatdong == true & (s.thuake == null | s.thuake == "")))
        {
            kq[0] += "<script async src=\"" + Security.UrlBase() + "js/Module_script/"+ mod.ma_module +".js\" type=\"text/javascript\"></script>";
			kq[1] += "<input type='hidden' id=\"org_grid"+ mod.ma_module +"\"/>";
            kq[2] += string.Format(@"let id_{0} = 0;", mod.ma_module);
            kq[2] += string.Format(@"let filter_{0} = null, filterVal_{0} = null;", mod.ma_module);
            kq[2] += string.Format(@"let page_{0} = null;", mod.ma_module);
            kq[2] += string.Format(@"let sidx_{0} = null;", mod.ma_module);
            kq[2] += string.Format(@"let sord_{0} = null;", mod.ma_module);
            kq[2] += string.Format(@"let header_{0} = null;", mod.ma_module);
        }
        return kq;
    }

    public static string Serialize(object o)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(o);
    }
	
	public static string connectString_Anco(EntityContext db)
    {
        ad_systemconfig ttc = db.ad_systemconfig.FirstOrDefault();
        return ttc.connectstring_anco;
    }
	
	public static string connectString_Anco1(EntityContext db)
    {
        ad_systemconfig ttc = db.ad_systemconfig.FirstOrDefault();
        string  ip_server = "118.69.76.143";
        string table_name = "ancotrading2018";
        string user_name = "sa";
        string password = "abc,123@123";
        string connectstring_anco = "Data Source="+ ip_server +";Initial Catalog="+table_name+";Persist Security Info=True;User ID="+user_name+";Password="+password+"";
        return connectstring_anco;
    }
	
	public static string sochungtu(EntityContext db, string ma_sochungtu, int congthem){
		md_sochungtu sct = db.md_sochungtu.Where(s => s.ma_sochungtu == ma_sochungtu & s.md_trangthai_id == "HIEULUC").Take(1).FirstOrDefault();
        // get Year from md_modongky
        md_modongky mdk = db.md_modongky.Where(s => s.hoatdong == true).Take(1).OrderByDescending(s => s.nam & s.ky).FirstOrDefault();
        string nam = "";
        if (mdk != null)
            nam = mdk.nam.ToString().Substring(2, 2);
        else
            nam = DateTime.Now.Year.ToString().Substring(2, 2);

        string gttd = sct.giatri_thaydoi;
		int count_gttd = gttd.Length;
		congthem = congthem * sct.buocnhay.Value;
		string gtcd = VNN_Config.load_number((int.Parse(gttd) + congthem).ToString(), count_gttd);
		string km = sct.khuonmau.Replace(gttd, gtcd);
		sct.giatri_thaydoi = gtcd;
		sct.khuonmau = km;
        km = km + "/" + nam;
        return km;
	}
	
	public static string sochungtu_(EntityContext db, string ma_sochungtu, int trura){
		md_sochungtu sct = db.md_sochungtu.Where(s => s.ma_sochungtu == ma_sochungtu & s.md_trangthai_id == "HIEULUC").Take(1).FirstOrDefault();
		string gttd = sct.giatri_thaydoi;
		int count_gttd = gttd.Length;
		trura = trura * sct.buocnhay.Value;
		string gtcd = VNN_Config.load_number((int.Parse(gttd) - trura).ToString(), count_gttd);
		string km = sct.khuonmau.Replace(gttd, gtcd);
		sct.giatri_thaydoi = gtcd;
		sct.khuonmau = km;
		return km;
	}
	
	public static string get_mauhienthi_sochungtu(){
		EntityContext db = new EntityContext();
		string msg = "if(1 == 2) { }";
		foreach(md_sochungtu sct in db.md_sochungtu.Where(s=>s.md_trangthai_id == "HIEULUC")) {
			msg += "\nelse if(ma_sct == '"+ sct.ma_sochungtu +"'){";
			msg += "	kq = '" + sct.mau_hienthi + "';";
			msg += "\n}";
		}
		return msg;
	}
	
	public static string autoRound(decimal number, int round){
		string s = Math.Round(number, round).ToString();
		decimal atr = 0;
		if(s.Contains(".")){
			for(int i=s.Length - 1; i >= 0; i--) {
				if(s[i] == '0'){
					s = s.Remove(i);
				}
				else if(s[i] == '.'){
					s= s.Remove(i);
					break;
				}
				else {
					break;
				}
			}
			atr = decimal.Parse(s);
		}
		else {
			atr = number;
		}
		int daucham = s.LastIndexOf(".");
		string s_ = s;
		if(daucham > 0)
			s.Substring(0,daucham);
		for(int i = s_.Length - 3; i > 0; i-=3) {
			s = s.Insert(i, ",");
		}
		return s;
	}

    public static string DecodeHTML(string text)
    {
        try { text = text.Replace("0ψ0", "<").Replace("1Ψ1", ">"); }
        catch { }
        return text;
    }

    public static string EncodeHTML(string text)
    {
        try { text = text.Replace("<", "0ψ0").Replace(">", "1Ψ1"); }
        catch { }
        return text;
    }
}

public class Module_TK
{
    public string ad_module_id;
    public string ma_module;
    public string ma_moduletk;
    public string ten_module;
    public string select_sql;
    public string from_sql;
    public string where_sql;
    public string orderby_sql;
    public string procedure_sql;
    public int capmodule;
    public string ma_modulecha;
    public string url;
    public bool row_count;
    public string loai_module;
}

public class User_TK
{
    public string ad_user_id;
    public string ad_role_id;
    public string md_phongban_id;
    public string ma_user;
	public string ma_role;
    public string ten_role;
    public string ten_phongban;
}

