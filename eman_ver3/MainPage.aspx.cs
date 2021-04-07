using System;
using System.Linq;
using DataAcess;
public partial class MainPage : System.Web.UI.Page
{
    public User_TK tk = null;
    public EntityContext db = new EntityContext();
    public ADmin_JSON json = new ADmin_JSON();
    public ad_systemconfig ttc = null;
    public string[] kq_script;
    public string date_ip = "";
    public string get_mauhienthi_sochungtu = "";
    public string layoutSize = "[]";
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        //var userAll = Security.all_taikhoan(Context);
        //if (userAll.Count > 0)
        //{
        //    if(!userAll.ContainsKey("ma_user"))
        //        Response.Redirect(Security.UrlBase() + "Login.aspx");
        //}

        tk = VNN_Function.get_user(
            Security.id_taikhoan(Context),
            Security.id_vaitro(Context),
            Security.id_phongban(Context),
            db
        );



        kq_script = VNN_VariablePublic.Module_script(json);
        get_mauhienthi_sochungtu = VNN_VariablePublic.get_mauhienthi_sochungtu(db);
        ttc = json.ad_systemconfigJSON().FirstOrDefault();
        if (ttc.date_import != null)
        {
            date_ip = ttc.date_import.Value.ToString(VNN_Config.get_FormatDate());
        }

        var filepath = ExcuteSignalRStatic.mapPathSignalR("~/App_Data/CustomGrid/" + tk.ma_user + "/layoutSize.json");
        if (System.IO.File.Exists(filepath))
        {
            layoutSize = System.IO.File.ReadAllText(filepath);
        }
    }
}
