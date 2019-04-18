using System;
using System.Linq;
using System.IO;
using System.Web;
using System.Text;
using DataAcess;
/// <summary>
/// Summary description for CreateBasicFile
/// </summary>
public class Admin_CreateBasicFile
{
    public static string CreateFileLoad_Modify(HttpContext context, Module_TK mod, int capmodule)
    {
        string kq = "";
        //Tao id trong file GridVariables.js
		if(mod.loai_module == "JQG" | mod.loai_module == "JQGS")
			EditFileGridVariables(context, mod);

        string sql = "Select " + mod.select_sql + " from " + mod.from_sql + " where 1=1 " + mod.where_sql;
        if (mod.orderby_sql != null & mod.orderby_sql != "")
            sql += " order by " + mod.orderby_sql;
        if (VNN_Function.TestSQL(sql) == false & (mod.loai_module == "JQG" | mod.loai_module == "JQGS"))
        {
            kq = "\nKhông thể tạo Grid do cú pháp SQL chưa chính xác.\nVào module: \"" + mod.ma_module + "\" để edit lại câu lệnh sql.";
        }
        else
        {
            //Tạo file load Controller
            string filepath = Security.UrlBase() + "Controller/" + "JQGrid";
            string filename = "/JQGrid" + mod.ma_module + "Load.ashx";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(context.Server.MapPath(filepath));
            }
            filepath = context.Server.MapPath(filepath + filename);

            if (!File.Exists(filepath))
            {
                string id_parent = "''";
                if (mod.ma_modulecha != null & mod.ma_modulecha != "")
                {
                    EntityContext db = new EntityContext();
                    string mod_cha = db.ad_module.Where(s => s.ad_module_id == mod.ma_modulecha).Select(s => s.ma_module).Take(1).FirstOrDefault();
                    id_parent = "id_" + mod_cha;
                }
                StreamWriter w = new StreamWriter(filepath, false, Encoding.Unicode);
                //khai bao WebHandler
                w.WriteLine("<%@ WebHandler Language=\"C#\" Class=\"JQGrid" + mod.ma_module + "Load\" %>");
                //khai bao thu vien
                w.WriteLine("using System;");
                w.WriteLine("using System.Web;");
                w.WriteLine("using System.Linq;");
                w.WriteLine("using System.Collections.Generic;");
                w.WriteLine("using DataAcess;");
                //<!--1
                w.WriteLine("public class JQGrid" + mod.ma_module + "Load : IHttpHandler , System.Web.SessionState.IRequiresSessionState {");
                //<!--2
                w.WriteLine("   public void ProcessRequest(HttpContext context){");
                w.WriteLine("        if(Security.id_taikhoan(context) != \"\") {");
                w.WriteLine("            EntityContext db = new EntityContext();");
                if (mod.loai_module == "JQG" | mod.loai_module == "JQGS")
                {
                    w.WriteLine("            //// filter");
                    w.WriteLine("            String filter = Helper.getFilter(context);");
                    w.WriteLine("            string id = context.Request.QueryString[\"id\"];");
                    w.WriteLine("            string id_sel = context.Request.QueryString[\"id_sel\"];");
                    w.WriteLine("            if (id == \"null\") { id = null; }");
                    w.WriteLine("            string ma_menu = context.Request.QueryString[\"ma_menu\"];");
                    w.WriteLine("            string ma_module = context.Request.QueryString[\"ma_module\"];");
                    w.WriteLine("            string where_ex = context.Request.QueryString[\"where_ex\"];");
                    w.WriteLine("            string where_module_select = \" and 1 = \" +  context.Request.QueryString[\"module_select\"];");
                    w.WriteLine("            Module_TK mod_ = VNN_Config.get_ModuleKeThua(null, 0, ma_module, \"\", \"\", db);");
                    w.WriteLine("            string id_vaitro = Security.id_vaitro(context); ");
                    w.WriteLine("            string where_vaitro = db.ad_role_where.Where(s => s.ad_role_id == id_vaitro & s.ad_module_id == mod_.ad_module_id).Select(s => s.where_sql).FirstOrDefault();");
                    w.WriteLine("            string select_sql = VNN_Config.Select_sql(mod_.ma_module, db);");
                    w.WriteLine("            int page = Helper.getPage(context);");
                    w.WriteLine("            int limit = int.Parse(context.Request.QueryString[\"rows\"]);");
                    w.WriteLine("            String sidx = context.Request.QueryString[\"sidx\"];");
                    w.WriteLine("            String sord = context.Request.QueryString[\"sord\"];");
                    w.WriteLine("            String oper_action = context.Request.QueryString[\"oper_action\"];");
                    w.WriteLine("            if (oper_action == \"noSel\") { id_sel = \"notData(404)\"; }");
                    w.WriteLine("            string id_count = select_sql.Split(',')[0];");
                    w.WriteLine("            if (id_count.Contains(\" as \"))");
                    w.WriteLine("            {");
                    w.WriteLine("                int j_index = id_count.IndexOf(\" as \");");
                    w.WriteLine("                id_count = id_count.Substring(0, j_index);");
                    w.WriteLine("            }");
                    w.WriteLine("\n");
                    w.WriteLine("            int start, end;");
                    w.WriteLine("            start = limit * page - limit;");
                    w.WriteLine("            end = (page * limit) + 1;");
                    w.WriteLine("\n");
                    w.WriteLine("            string orderby = \"\";");
                    w.WriteLine("            if (sidx.Equals(\"\") || sidx == null)");
                    w.WriteLine("            {");
                    w.WriteLine("                if (mod_.orderby_sql != null & mod_.orderby_sql != \"\")");
                    w.WriteLine("                    orderby = string.Format(\"{0}\", mod_.orderby_sql);");
                    w.WriteLine("                else");
                    w.WriteLine("                    orderby = string.Format(\"{0}\", id_count + \" asc\");");
                    w.WriteLine("            }");
                    w.WriteLine("            else");
                    w.WriteLine("            {");
                    w.WriteLine("                orderby = sidx + \" \" + sord;");
                    w.WriteLine("            }");
                    w.WriteLine("\n");
					w.WriteLine("            string ROW_NUMBER = \"ROW_NUMBER() OVER (  ORDER BY \"+ orderby +\")\";");
					w.WriteLine("            string sql = string.Format(@\"sELeCt * fRoM (");
					w.WriteLine("            sELeCt \" + select_sql + ");
					w.WriteLine("            @\" (case when '{4}' = '{5}' and (\" + ROW_NUMBER +\" <= \" + start + \" or \" + ROW_NUMBER + \" >= \" + end + \")  then -1 else \" + ROW_NUMBER + \" end) as RowNum\" +");
					w.WriteLine("            @\" fRoM {1}"); 
					w.WriteLine("            WHeRe 1=1 {2} {3} {6} {7} {8} ) P WHeRe RowNum > \" + start + \" AND RowNum < \" + end + \" or (RowNum = -1) order by RowNum asc\",");
					w.WriteLine("            orderby, mod_.from_sql, mod_.where_sql, filter, id_count, id_sel, where_ex, where_vaitro, where_module_select);");
                    w.WriteLine("\n");
                    w.WriteLine("            sql = ADmin_ConvertStringToCode.Avariable(context, sql, id_count, id, mod_, db).Replace(\"'\", \"''\");");
                    w.WriteLine("\n");
                    w.WriteLine("            if (mod_.procedure_sql == \"\") { mod_.procedure_sql = \"admin_excutesql\"; }");
                    w.WriteLine("\n");
                    w.WriteLine("            string sqlcount = string.Format(\"exec [dbo].[{3}] N'{0}',N'{1}',{2}\", sql, mod_.ma_moduletk, 0, mod_.procedure_sql);");
                    w.WriteLine("            System.Data.DataTable dt_count = Mbg.Data.SqlClient.SqlHelper.GetData(sqlcount);");
                    w.WriteLine("            int count = int.Parse(dt_count.Rows[0][0].ToString());");
                    w.WriteLine("            string sql_select = string.Format(\"exec [dbo].[{3}] N'{0}',N'{1}',{2}\", sql, mod_.ma_moduletk, 1, mod_.procedure_sql);");
                    w.WriteLine("            System.Data.DataTable dt_select = Mbg.Data.SqlClient.SqlHelper.GetData(sql_select);");
                    w.WriteLine("            Mbg.Web.JqGrid.JqGResult rs = new Mbg.Web.JqGrid.JqGResult(dt_select, count, page, limit);");
                    w.WriteLine("            context.Response.Write(rs.WriteJson());");
                }
                w.WriteLine("        }");
                w.WriteLine("    }");
                //--2>

                //<!--2
                w.WriteLine("    public bool IsReusable {");
                w.WriteLine("        get { return false; }");
                w.WriteLine("    }");
                //--2>
                w.WriteLine("}");
                //--1>
                w.Flush();
                w.Close();
                CreateFileModify(context, mod);
                CreateFileInterface(context, mod, capmodule);
                CreateFunction_ModuleScript(context, mod);
                kq = "\n Tạo grid thành công.";
            }
        }
        return kq;
    }

    public static void CreateFileModify(HttpContext context, Module_TK mod)
    {
        //Tạo file modify Controller
        string filepath = Security.UrlBase() + "Controller/" + "JQGridModify";
        string filename = "/JQGrid" + mod.ma_module + "Modify.ashx";
        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(context.Server.MapPath(filepath));
        }
        filepath = context.Server.MapPath(filepath + filename);

        if (!File.Exists(filepath) & (mod.ma_moduletk == mod.ma_module))
        {
            StreamWriter w = new StreamWriter(filepath, false, Encoding.Unicode);
            //khai bao WebHandler
            w.WriteLine("<%@ WebHandler Language=\"C#\" Class=\"JQGrid" + mod.ma_module + "Modify\" %>");
            w.WriteLine("using System;");
            w.WriteLine("using System.Web;");
            w.WriteLine("using System.Linq;");
            w.WriteLine("using System.Data.Linq;");
            w.WriteLine("using DataAcess;");

            w.WriteLine("public class JQGrid" + mod.ma_module + "Modify : IHttpHandler, System.Web.SessionState.IRequiresSessionState");
            w.WriteLine("{");
            w.WriteLine("    public void ProcessRequest (HttpContext context) {");
            w.WriteLine("        string oper = \"vnn\";");
            w.WriteLine("        if (Security.id_taikhoan(context) != \"\")");
            w.WriteLine("           oper = context.Request.QueryString[\"oper\"] == null ? context.Request.Form[\"oper\"] : context.Request.QueryString[\"oper\"];");
            w.WriteLine("        switch (oper)");
            w.WriteLine("        {");
            if (mod.loai_module == "JQG" | mod.loai_module == "JQGS")
            {
                w.WriteLine("            case \"add\":");
                w.WriteLine("                this.add(context);");
                w.WriteLine("                break;");
                w.WriteLine("            case \"edit\":");
                w.WriteLine("                this.edit(context);");
                w.WriteLine("                break;");
                w.WriteLine("            case \"del\":");
                w.WriteLine("                this.del(context);");
                w.WriteLine("                break;");
                w.WriteLine("            default:");
                w.WriteLine("                break;");
            }
            else
            {
                w.WriteLine("            case \"CusFunction\":");
                w.WriteLine("                this.CusFunction(context);");
                w.WriteLine("                break;");
                w.WriteLine("            default:");
                w.WriteLine("                break;");
            }
            w.WriteLine("        }");
            w.WriteLine("    }\n");

            if (mod.loai_module == "JQG"| mod.loai_module == "JQGS")
            {
                //doi tuong
                int j = mod.from_sql.Split(' ')[0].Length;
                string md_object = mod.from_sql.Substring(0, j);
                string id_object = ADmin_UpdateLinq.get_KeyOfTable(md_object);
				string getMember_object = ADmin_UpdateLinq.getMember(md_object);
                //add
                
                w.WriteLine("    public void add(HttpContext context)");
                w.WriteLine("    {");
                w.WriteLine("        EntityContext db = new EntityContext();");
                w.WriteLine("        string msg = \"\",id_new = Helper.getNewId();");
                w.WriteLine("        string ma_module = context.Request.QueryString[\"ma_module\"];");
                w.WriteLine("        try");
                w.WriteLine("        {");
                w.WriteLine("            string id_parent = context.Request.Form[\"id_parent\"];");
                w.WriteLine("            if (msg.Length <= 0)");
                w.WriteLine("            {");
                w.WriteLine("                string action = \"add\";");
                w.WriteLine("                string[] column_ex = { };");
                w.WriteLine("                string ten_table = \"" + md_object + "\";");
                w.WriteLine("                VNN_Function.Set_DefaultvalueColumn(context, action);");
                w.WriteLine("                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);");
                w.WriteLine("                VNN_Function.loaddulieu_Auto(db, ma_module);");
                w.WriteLine("                msg = \"true#Thêm thành công.\" + \"#\" + id_new;");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("        catch(Exception ex)");
                w.WriteLine("        {");
                w.WriteLine("            msg = \"false#\" + ex.Message;");
                w.WriteLine("        }");
                w.WriteLine("        context.Response.Write(msg);");
                w.WriteLine("    }\n");
                //edit
                w.WriteLine("    public void edit(HttpContext context)");
                w.WriteLine("    {");
                w.WriteLine("        EntityContext db = new EntityContext();");
                w.WriteLine("        string msg = \"\";");
                w.WriteLine("        string ma_module = context.Request.QueryString[\"ma_module\"];");
                w.WriteLine("        try");
                w.WriteLine("        {");
                w.WriteLine("            string id_parent = context.Request.Form[\"id_parent\"];");
                w.WriteLine("            string id = context.Request.Form[\"id\"];");
                w.WriteLine("            "+ md_object +" object_ = db." + getMember_object + ".Where(p => p." + id_object + " == id ).Take(1).FirstOrDefault();");
                w.WriteLine("            if (object_ == null)");
                w.WriteLine("            {");
                w.WriteLine("                msg = \"false#Lỗi:Không tìm thấy đối tượng cần sửa \";");
                w.WriteLine("            }");
                w.WriteLine("            ");
                w.WriteLine("            if (msg.Length <= 0)");
                w.WriteLine("            {");
                w.WriteLine("                string action = \"edit\";");
                w.WriteLine("                string[] column_ex = { };");
                w.WriteLine("                string ten_table = \"" + md_object + "\";");
                w.WriteLine("                VNN_Function.Set_DefaultvalueColumn(context, action);");
                w.WriteLine("                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);");
                w.WriteLine("                VNN_Function.loaddulieu_Auto(db, ma_module);");
                w.WriteLine("                msg = \"true#Cập nhật thành công.\";");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("        catch(Exception ex)");
                w.WriteLine("        {");
                w.WriteLine("            msg = \"false#\" + ex.Message;");
                w.WriteLine("        }");
                w.WriteLine("        context.Response.Write(msg);");
                w.WriteLine("    }\n");
                //del
                w.WriteLine("    public void del(HttpContext context)");
                w.WriteLine("    {");
                w.WriteLine("        EntityContext db = new EntityContext();");
                w.WriteLine("        string msg = \"\", msg_del = \"\";");
                w.WriteLine("        string ma_module = context.Request.QueryString[\"ma_module\"];");
                w.WriteLine("        try");
                w.WriteLine("        {");
                w.WriteLine("            string ten_table = \"" + md_object + "\";");
                w.WriteLine("            int count = context.Request.Form[\"id\"].Split(',').Count();");
                w.WriteLine("            string[] id_del = new string[count];");
                w.WriteLine("            id_del = context.Request.Form[\"id\"].Split(',');");
                w.WriteLine("            for (int i = 0; i < count; i++)");
                w.WriteLine("            {");
                w.WriteLine("                msg_del = \"\";");
                w.WriteLine("                string id_del_ = id_del[i]; ");
                w.WriteLine("                " + md_object + " object_ = db."+ getMember_object +".Where(p => p."+ id_object + " == id_del_ ).Take(1).FirstOrDefault();");
                w.WriteLine("                if (object_ == null)");
                w.WriteLine("                {");
                w.WriteLine("                    msg_del = \"Lỗi:Không tìm thấy đối tượng cần xóa \" + i;");
                w.WriteLine("                    msg += msg_del + \"\\n\";");
                w.WriteLine("                }");

                w.WriteLine("                if (msg_del.Length <= 0)");
                w.WriteLine("                {");
                w.WriteLine("                     db."+ getMember_object +".Remove(object_);");
                w.WriteLine("                }");
                w.WriteLine("            }");
                
                w.WriteLine("            if (msg.Length <= 0)");
                w.WriteLine("            {");
				w.WriteLine("            	 VNN_Function.loaddulieu_Auto(db, ma_module);");
                w.WriteLine("                msg = \"true#Xóa thành công.\";");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                msg = \"false#\" + msg;");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("        catch (Exception ex)");
                w.WriteLine("        {");
                w.WriteLine("            if (ex.Message.ToUpper().Contains(\"REFERENCE\"))");
                w.WriteLine("            {");
                w.WriteLine("                msg = \"false#Lỗi: Đang được sử dụng, không thể xóa\";");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                msg = \"false#Lỗi: \" + ex.Message;");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("        context.Response.Write(msg);");
                w.WriteLine("    }\n");
            }
            else
            {
                //CusFunction
                w.WriteLine("    public void CusFunction(HttpContext context)");
                w.WriteLine("    {");
                w.WriteLine("        EntityContext db = new EntityContext();");
                w.WriteLine("        string msg = \"\",id_new = Helper.getNewId();");
                w.WriteLine("        string ma_module = context.Request.QueryString[\"ma_module\"];");
                w.WriteLine("        try");
                w.WriteLine("        {");

                w.WriteLine("        }");
                w.WriteLine("        catch(Exception ex)");
                w.WriteLine("        {");
                w.WriteLine("            msg = \"false#\" + ex.Message;");
                w.WriteLine("        }");
                w.WriteLine("        context.Response.Write(msg);");
                w.WriteLine("    }\n");
            }
            //IsReusable
            w.WriteLine("    public bool IsReusable");
            w.WriteLine("    {");
            w.WriteLine("        get");
            w.WriteLine("        {");
            w.WriteLine("            return false;");
            w.WriteLine("        }");
            w.WriteLine("    }");
            w.WriteLine("}");
            w.Flush();
            w.Close();
        }
    }

    public static void CreateFileInterface(HttpContext context, Module_TK mod, int capmodule)
    {
        EntityContext db = new EntityContext();
        //Tạo file load Controller

        string filepath = Security.UrlBase() + mod.url;
        int j = filepath.LastIndexOf('/');
        string directory = filepath.Substring(0, j);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(context.Server.MapPath(directory));
        }

        filepath = context.Server.MapPath(filepath);
        int so_select = capmodule - 1;
        string module_select = "";
        if (so_select < 0) { module_select = "1"; }
        else { module_select = "module_select[" + so_select + "]"; }
        
        if (!File.Exists(filepath))
        {
            StreamWriter w = new StreamWriter(filepath, false, Encoding.Unicode);
            if (mod.loai_module == "JQG")
            {
                string id_parent = "null";
                string ma_module_display = "ma_module";
                if (mod.ma_modulecha != null & mod.ma_modulecha != "")
                {
                    string mod_cha = db.ad_module.Where(s => s.ad_module_id == mod.ma_modulecha).Select(s => s.ma_module).Take(1).FirstOrDefault();
                    id_parent = "id_" + mod_cha;
                }
                w.WriteLine("<%@ Page Language=\"C#\" %>");
                w.WriteLine("<%");
                w.WriteLine("    string ma_module = \"" + mod.ma_module + "\";");
                if (mod.ma_moduletk != mod.ma_module)
                {
                    w.WriteLine("    string ma_moduletk = \"" + mod.ma_moduletk + "\";");
                    ma_module_display = "ma_moduletk";
                }
                w.WriteLine("    \n");
                w.WriteLine("    string[] get_records = VNN_Config.get_records();");
                w.WriteLine("    string[] get_STTaID = VNN_Config.get_IDParent_STTLoad(ma_module);");
                w.WriteLine("    string[] colModel = VNN_Config.get_colModel(Context, ma_module);");
                w.WriteLine("    string[][] modifyForm = VNN_Config.get_ModifyFormInfor(ma_module);");
                w.WriteLine("%>");
                w.WriteLine("\n");
                w.WriteLine("<table id='grid<%=ma_module %>'></table>");
                w.WriteLine("<div id='pagergrid<%=ma_module %>'></div>");
                w.WriteLine("\n");
                w.WriteLine("<script type=\"text/javascript\">");
                w.WriteLine("    //bien load grid");
                w.WriteLine("    var input_focus=null, load_grid = 0;");
                w.WriteLine("    var rownum = Number(<%=get_records[0] %>);");
                w.WriteLine("    //Cac bien can truyen vao truoc khi load chuc nang");
                w.WriteLine("    //--bien bat buoc");
                w.WriteLine("    var load_stt = <%=get_STTaID[0] %>;");
                w.WriteLine("    var id_parent = <%=get_STTaID[1] %>;");
                w.WriteLine("    var tengrid = 'grid<%=ma_module %>';");
                w.WriteLine("    var Form_infor = '<%=VNN_VariablePublic.Form_infor %>';");
                w.WriteLine("    var Model_infor = '<%=VNN_VariablePublic.Model_infor %>' ;");
                w.WriteLine("    //--#bien bat buoc");
                w.WriteLine("    //#Cac bien can truyen vao truoc khi load chuc nang");
                w.WriteLine("    //Load chức năng");
                w.WriteLine("    <%=VNN_Config.get_NavFunc(Context, ma_module) %>");
                w.WriteLine("    //#Load chức năng");
                w.WriteLine("</script>");
                w.WriteLine("\n");
                w.WriteLine("<script type=\"text/javascript\">");
                w.WriteLine("    jQuery('#'+tengrid).jqGrid({");
                w.WriteLine("        url: 'Controller/JqGrid/JQGrid<%=ma_module%>Load.ashx?ma_module=<%=ma_module%>&ma_menu='+$('#input_idmenu').val() + '&id='+id_parent,");
                w.WriteLine("        editurl: 'Controller/JQGridModify/JQGrid<%=" + ma_module_display + "%>Modify.ashx?ma_module=<%=ma_module%>&ma_menu='+$('#input_idmenu').val() + '&id='+id_parent,");
                w.WriteLine("        height: (window.innerHeight - $('#input_docaogrid').val()),");
                w.WriteLine("        datatype: 'json',");
                w.WriteLine("        autowidth: true,");
                w.WriteLine("        shrinkToFit: true,");
                w.WriteLine("        rownumbers: true,");
                w.WriteLine("        viewrecords: true,");
                w.WriteLine("        search: true,");
                w.WriteLine("        scroll:false,");
                w.WriteLine("        rowNum: rownum,");
                w.WriteLine("        multiselect: <%=get_STTaID[3] %>,");
                w.WriteLine("        multiboxonly: <%=get_STTaID[3] %>,");
                w.WriteLine("        rowList: <%=get_records[1] %>,");
                w.WriteLine("        pager: '#pager'+tengrid,");
                w.WriteLine("        onSelectRow: function (ids) {");
				w.WriteLine("			 //checkbox customize");
				w.WriteLine("			 checkbox_JQgrid(tengrid, 0);");
                w.WriteLine("            var value_header = '', cell = $('#'+ tengrid).getRowData(ids);");
                w.WriteLine("            if (id_parent != null) { ");
                w.WriteLine("                    value_header = <%=get_STTaID[1].Replace(\"id_\",\"header_\") %>;");
                w.WriteLine("                    header_<%=ma_module %> = value_header + header_sep + <%=get_STTaID[2] %>;");
                w.WriteLine("            }");
                w.WriteLine("            else {");
                w.WriteLine("                header_<%=ma_module %> = value_header + <%=get_STTaID[2] %>;");
                w.WriteLine("            }");
                w.WriteLine("            set_headerJQG(tengrid, header_<%=ma_module %>);");
				
				w.WriteLine("            // public id da chon");
                w.WriteLine("            if(ids != null & ids !='' & ids !='0'){");
				w.WriteLine("            	 id_<%=" + ma_module_display + " %> = ids;");
                w.WriteLine("                module_select[" + capmodule + "] = 1;");
                w.WriteLine("            }");
                w.WriteLine("        },");
                w.WriteLine("        colModel: [");
                w.WriteLine("            <%=colModel[0] %>");
                w.WriteLine("        ],");
                w.WriteLine("        beforeRequest: function() {");
                w.WriteLine("            //giữ focus");
                w.WriteLine("            input_focus = $('input:focus').attr('class');");
                w.WriteLine("            //giữ filter start");
                w.WriteLine("            if (id_oper[load_stt] == null)");
                w.WriteLine("                $('#' + tengrid).jqGrid('getGridParam', 'postData').id_sel = id_<%=" + ma_module_display + " %>;");
                w.WriteLine("            $('#' + tengrid).jqGrid('getGridParam', 'postData').module_select = " + module_select + ";");
                w.WriteLine("            if(load_grid == 0){");
                w.WriteLine("                $('#' + tengrid).jqGrid('getGridParam', 'postData').filters = filter_<%=ma_module %>;");
                w.WriteLine("                $('#' + tengrid).jqGrid('getGridParam', 'postData').page = page_<%=ma_module %>;");
                w.WriteLine("                $('#' + tengrid).jqGrid('getGridParam', 'postData').sord = sord_<%=ma_module %>;");
                w.WriteLine("                $('#' + tengrid).jqGrid('getGridParam', 'postData').sidx = sidx_<%=ma_module %>;");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                filter_<%=ma_module %> = $('#' + tengrid).jqGrid('getGridParam', 'postData').filters;");
                w.WriteLine("                page_<%=ma_module %> = $('#' + tengrid).jqGrid('getGridParam', 'postData').page;");
                w.WriteLine("                sord_<%=ma_module %> = $('#' + tengrid).jqGrid('getGridParam', 'postData').sord;");
                w.WriteLine("                sidx_<%=ma_module %> = $('#' + tengrid).jqGrid('getGridParam', 'postData').sidx;");
                w.WriteLine("            }");
                w.WriteLine("        },");
                w.WriteLine("        ondblClickRow: function(){");
                w.WriteLine("            <%=get_STTaID[4] %>;");
                w.WriteLine("        },");
                w.WriteLine("        gridComplete: function () {");
                w.WriteLine("            $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());");
                w.WriteLine("            taonut_header();");
                w.WriteLine("        },");
                w.WriteLine("        loadComplete: function (data) {");
                w.WriteLine("            //chia màu chẵn lẻ");
                w.WriteLine("            var top_rowid = $('#' + tengrid + ' tr:nth-child(2)').attr('id');");
                w.WriteLine("            phanmauchogrid(this);");
                if (mod.ma_moduletk != mod.ma_module)
                {
                    w.WriteLine("            if(id_<%=ma_moduletk %> != null & id_<%=ma_moduletk %> != '0')");
                    w.WriteLine("                $('#' + tengrid).jqGrid('setSelection', id_<%=ma_moduletk %>);");
                    w.WriteLine("            module_select[" + capmodule + "] = 1;");
                    w.WriteLine("            var b = $('#' + tengrid).jqGrid ('getGridParam', 'selrow');");
                    w.WriteLine("            if (b == null | b == '' | b == '0') {");
                    w.WriteLine("                if (id_<%=ma_moduletk %> == null | id_<%=ma_moduletk %> == '') {");
                    w.WriteLine("                    $('#' + tengrid).jqGrid('setSelection', top_rowid);");
                    w.WriteLine("                    if(top_rowid == null | top_rowid == '0')");
                    w.WriteLine("                    module_select[" + capmodule + "] = 2;");
                    w.WriteLine("                }");
                    w.WriteLine("                else {");
                    w.WriteLine("	                 module_select[" + capmodule + "] = 2;");
                    w.WriteLine("                }");
                    w.WriteLine("            }");
                    w.WriteLine("            else {");
                    w.WriteLine("            //click vào dòng vừa tạo mới");
                    w.WriteLine("                if(id_new == '0' | id_new == null)");
                    w.WriteLine("                { /*$('#'+tengrid).jqGrid('setSelection', id_<%=ma_moduletk %>);*/ }");
                    w.WriteLine("                else ");
                    w.WriteLine("                { resetSelection(tengrid); clickSelection(tengrid, id_new); id_new = '0';}");
                    w.WriteLine("                Focus_Selection(tengrid);");
                    w.WriteLine("            }");
                }
                else
                {
                    w.WriteLine("            if(id_<%=ma_module %> != null & id_<%=ma_module %> != '0')");
                    w.WriteLine("                $('#' + tengrid).jqGrid('setSelection', id_<%=ma_module %>);");
                    w.WriteLine("            module_select["+ capmodule +"] = 1;");
                    w.WriteLine("            var b = $('#' + tengrid).jqGrid ('getGridParam', 'selrow');");
                    w.WriteLine("            if (b == null | b == '' | b=='0') {");
                    w.WriteLine("                if(top_rowid != null & top_rowid != 0)");
                    w.WriteLine("                    $('#' + tengrid).jqGrid('setSelection', top_rowid);");
                    w.WriteLine("                else");
                    w.WriteLine("                    module_select["+ capmodule +"] = 2;");
                    w.WriteLine("            }");
                    w.WriteLine("            else {");
                    w.WriteLine("                if(id_new == '0' | id_new == null)");
                    w.WriteLine("                {	/*$('#'+tengrid).jqGrid('setSelection', id_<%=ma_module %>);*/ }");
                    w.WriteLine("                else");
                    w.WriteLine("                { resetSelection(tengrid); clickSelection(tengrid, id_new); id_new = '0';}");
                    w.WriteLine("                Focus_Selection(tengrid);");
                    w.WriteLine("            }");
                }
                w.WriteLine("            //làm mới bộ lọc");
                w.WriteLine("            clearSearchOptions(tengrid);");
                /*//demmo edit inline
                var ids = jQuery("#"+tengrid).jqGrid('getDataIDs');
                for(var i=0;i < ids.length;i++){
                    var cl = ids[i];
                    be = "<input style='height:22px;width:20px;' type='button' value='E' onclick=\"jQuery('#'+tengrid).editRow('"+cl+"');$('#'+tengrid).jqGrid('setSelection', '"+ cl +"');\"  />"; 
                    se = "<input style='height:22px;width:20px;' type='button' value='S' onclick=\"jQuery('#'+tengrid).saveRow('"+cl+"');\"  />"; 
                    ce = "<input style='height:22px;width:20px;' type='button' value='C' onclick=\"jQuery('#'+tengrid).restoreRow('"+cl+"');\" />"; 
                    jQuery("#"+tengrid).jqGrid('setRowData',ids[i],{thaotac:be+se+ce});
                }*/
                w.WriteLine("            //giữ filter end");
                w.WriteLine("            if (load_grid == 0)");
                w.WriteLine("            {");
                w.WriteLine("                fix_disableSelect(tengrid);");
                w.WriteLine("                set_ValueFilter(tengrid, filterVal_<%=ma_module %>, sord_<%=ma_module %>, sidx_<%=ma_module %>);");
                w.WriteLine("                load_grid = 1;");
                w.WriteLine("                if(top_rowid == '0') {");
                w.WriteLine("                    setTimeout(function(){click_refreshPage();},200);");
                w.WriteLine("                }");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                filterVal_<%=ma_module %> = get_ValueFilter(tengrid);");
                w.WriteLine("            }");
				w.WriteLine("			 //checkbox customize");
				w.WriteLine("			 checkbox_JQgrid(tengrid, 1);");
                w.WriteLine("            //giữ focus end");
                w.WriteLine("            $('.'+input_focus).focus();");
                w.WriteLine("        },");
                w.WriteLine("        caption: ' '");
                w.WriteLine("    });");
                w.WriteLine("\n");
                w.WriteLine("    jQuery('#'+tengrid).jqGrid('navGrid', '#pager'+tengrid,");
                w.WriteLine("    {");
                w.WriteLine("        <%=VNN_Config.get_navGrid(Context, " + ma_module_display + ") %>");
                w.WriteLine("    },{");
                w.WriteLine("    //edit");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[0][0] %>");
                w.WriteLine("            <%=modifyForm[0][1] %>");
                w.WriteLine("            <%=modifyForm[0][2] %>");
                w.WriteLine("            <%=modifyForm[0][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("            <%=colModel[1]%>");
                w.WriteLine("            <%=colModel[5] %>");
                w.WriteLine("            <%=colModel[6] %>");
                w.WriteLine("            Change_Value(Avariable(),'edit');");
                w.WriteLine("        },");
                w.WriteLine("        beforeSubmit: function (postdata, formid) {");
				w.WriteLine("            postdata.id_parent = id_parent;");
                w.WriteLine("            formid.prepend('<div class=\"nhan_loading\">&nbsp;</div>');");
                w.WriteLine("            return [true, ''];");
                w.WriteLine("        },");
                w.WriteLine("        afterSubmit: function (response, formid) {");
                w.WriteLine("            $('.nhan_loading').remove();");
                w.WriteLine("            if(thongbaokhimodify(response.responseText,this.id) == false)");
                w.WriteLine("            {");
                w.WriteLine("                return [false, response.responseText.split('#')[1]];");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                <%=colModel[5] %>");
                w.WriteLine("                <%=modifyForm[0][4] %>");
                w.WriteLine("                add_edit_del_complete('edit'); loadclick(tengrid,'edit',load_stt);");
                w.WriteLine("                return [false, ''];");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("    },{");
                w.WriteLine("    //add");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[1][0] %>");
                w.WriteLine("            <%=modifyForm[1][1] %>");
                w.WriteLine("            <%=modifyForm[1][2] %>");
                w.WriteLine("            <%=modifyForm[1][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("            <%=colModel[2]%>");
                w.WriteLine("            <%=colModel[3] %>");
                w.WriteLine("            <%=colModel[5] %>");
                w.WriteLine("            <%=colModel[7] %>");
                w.WriteLine("            Change_Value(Avariable(),'add');");
                w.WriteLine("            countRows(tengrid, 'sapxep');");
                w.WriteLine("        },");
                w.WriteLine("        beforeSubmit: function (postdata, formid) {");
				w.WriteLine("            postdata.id_parent = id_parent;");
                w.WriteLine("            formid.prepend('<div class=\"nhan_loading\">&nbsp;</div>');");
                w.WriteLine("            return [true, ''];");
                w.WriteLine("        },");
                w.WriteLine("        afterSubmit: function (response) {");
                w.WriteLine("            $('.nhan_loading').remove();");
                w.WriteLine("            if(thongbaokhimodify(response.responseText,this.id) == false)");
                w.WriteLine("            {");
                w.WriteLine("                return [false, response.responseText.split('#')[1]];");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                <%=colModel[4] %>");
                w.WriteLine("                <%=colModel[5] %>");
                w.WriteLine("                <%=modifyForm[1][4] %>");
                w.WriteLine("                id_new = response.responseText.split('#')[2]; countRows(tengrid, 'sapxep');");
                w.WriteLine("                add_edit_del_complete('add'); loadclick(tengrid,null,load_stt);");
                w.WriteLine("                return [false, ''];");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("    },{");
                w.WriteLine("    //del");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[2][0] %>");
                w.WriteLine("            <%=modifyForm[2][1] %>");
                w.WriteLine("            <%=modifyForm[2][2] %>");
                w.WriteLine("            <%=modifyForm[2][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("        },");
                w.WriteLine("        beforeSubmit: function (postdata, formid) {");
				w.WriteLine("            postdata.id_parent = id_parent;");
                w.WriteLine("            $('#DelTbl_'+tengrid).prepend('<div class=\"nhan_loading\">&nbsp;</div>');");
                w.WriteLine("            return [true, ''];");
                w.WriteLine("        },");
                w.WriteLine("        afterSubmit: function (response) {");
                w.WriteLine("            $('.nhan_loading').remove();");
                w.WriteLine("            if(thongbaokhimodify(response.responseText,this.id) == false)");
                w.WriteLine("            {");
                w.WriteLine("                return [false, response.responseText.split('#')[1]];");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                <%=modifyForm[2][4] %>");
                w.WriteLine("                add_edit_del_complete('del'); loadclick(tengrid, null,load_stt);");
                w.WriteLine("                return [false,''];");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("    }, {");
                w.WriteLine("    //search");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            formid.closest('div.ui-jqdialog').dialogCenter();");
                w.WriteLine("        }");
                w.WriteLine("    }, {");
                w.WriteLine("    //view");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[3][0] %>");
                w.WriteLine("            <%=modifyForm[3][1] %>");
                w.WriteLine("            <%=modifyForm[3][2] %>");
                w.WriteLine("            <%=modifyForm[3][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("        },");
                w.WriteLine("    },{");
                w.WriteLine("    //refesh");
                w.WriteLine("    });");
                w.WriteLine("    jQuery('#'+tengrid).jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });");
                w.WriteLine("    jQuery('#pager'+ tengrid +'_left table').css('display','none');");
				w.WriteLine("    jQuery('#'+tengrid).jqGrid('setFrozenColumns');");
                w.WriteLine("    \n");
                w.WriteLine("    //Start Ham ho tro them cho Grid (sẽ tự update nếu module chính update)");
                w.WriteLine("    function Avariable() {");
                w.WriteLine("        var column_array = [];");
                w.WriteLine("        return column_array;");
                w.WriteLine("    }");
                w.WriteLine("    //--");
                w.WriteLine("    function Change_Value(column_array, action)");
                w.WriteLine("    {");
                w.WriteLine("        for(var i in column_array) {");
                w.WriteLine("            $('#' + column_array[i]).change(function() {");
                w.WriteLine("                 action_grid(action, $(this).attr('id'));");
                w.WriteLine("            });");
                w.WriteLine("        }");
                w.WriteLine("        action_grid(action, null);");
                w.WriteLine("    }");
                w.WriteLine("    //--");
                w.WriteLine("    function action_grid(action, column){");
                w.WriteLine("        if(action == 'add') {");
                w.WriteLine("        \n");
                w.WriteLine("        }");
                w.WriteLine("        else if(action == 'edit') {");
                w.WriteLine("        \n");
                w.WriteLine("        }");
                w.WriteLine("    }");
                w.WriteLine("    //--");
                w.WriteLine("    function add_edit_del_complete(action){");
                w.WriteLine("        if(action == 'add') {");
                w.WriteLine("        }");
                w.WriteLine("        else if(action == 'edit') {");
                w.WriteLine("        }");
                w.WriteLine("        else if(action == 'del') {");
                w.WriteLine("        }");
                w.WriteLine("    }");
                w.WriteLine("    //#End Ham ho tro them cho Grid (sẽ tự update nếu module chính update)");
                w.WriteLine("</script>");
                //--1>
            }
			else if(mod.loai_module == "JQGS"){
				string id_parent = "null";
                string ma_module_display = "ma_module";
                if (mod.ma_modulecha != null & mod.ma_modulecha != "")
                {
                    string mod_cha = db.ad_module.Where(s => s.ad_module_id == mod.ma_modulecha).Select(s => s.ma_module).Take(1).FirstOrDefault();
                    id_parent = "id_" + mod_cha;
                }
                w.WriteLine("<%@ Page Language=\"C#\" %>");
                w.WriteLine("<%");
                w.WriteLine("    string ma_module = \"" + mod.ma_module + "\";");
                if (mod.ma_moduletk != mod.ma_module)
                {
                    w.WriteLine("    string ma_moduletk = \"" + mod.ma_moduletk + "\";");
                    ma_module_display = "ma_moduletk";
                }
                w.WriteLine("    \n");
                w.WriteLine("    string[] get_records = VNN_Config.get_records();");
                w.WriteLine("    string[] get_STTaID = VNN_Config.get_IDParent_STTLoad2(ma_module, " + capmodule + ");");
                w.WriteLine("    string[] colModel = VNN_Config.get_colModel(Context, ma_module);");
                w.WriteLine("    string[][] modifyForm = VNN_Config.get_ModifyFormInfor2(ma_module, " + capmodule + ");");
                w.WriteLine("%>");
				
                w.WriteLine("\n");
				if(capmodule == 0){
					w.WriteLine("<div class='sub_mainpage'>");
					w.WriteLine("	<%=VNN_JQGridver2.get_layout(Context ,ma_module) %>"); 
					w.WriteLine("</div>");
				}
				else {
					w.WriteLine("<table id='grid<%=ma_module %>'></table>");
					w.WriteLine("<div id='pagergrid<%=ma_module %>'></div>");
				}
                w.WriteLine("\n");
                w.WriteLine("<script type=\"text/javascript\">");
                w.WriteLine("    //bien load grid");
                w.WriteLine("    var input_focus" + capmodule + "=null, load_grid" + capmodule + " = 0;");
                w.WriteLine("    var rownum" + capmodule + " = Number(<%=get_records[0] %>);");
                w.WriteLine("    //Cac bien can truyen vao truoc khi load chuc nang");
                w.WriteLine("    //--bien bat buoc");
                w.WriteLine("    var load_stt" + capmodule + " = <%=get_STTaID[0] %>;");
                w.WriteLine("    var id_parent" + capmodule + " = <%=get_STTaID[1] %>;");
                w.WriteLine("    var tengrid" + capmodule + " = 'grid<%=ma_module %>';");
                w.WriteLine("    var Form_infor" + capmodule + " = '<%=VNN_VariablePublic.Form_infor %>';");
                w.WriteLine("    var Model_infor" + capmodule + " = '<%=VNN_VariablePublic.Model_infor %>' ;");
                w.WriteLine("    //--#bien bat buoc");
                w.WriteLine("    //#Cac bien can truyen vao truoc khi load chuc nang");
				w.WriteLine("    //Load chức năng");
				w.WriteLine("    <%=VNN_Config.get_NavFunc2(Context, ma_module, "+ capmodule +") %>");
				w.WriteLine("    //#Load chức năng");
                w.WriteLine("</script>");
                w.WriteLine("\n");
                w.WriteLine("<script type=\"text/javascript\">");
				w.WriteLine("<%=VNN_JQGridver2.get_layout_face() %>");
                w.WriteLine("    jQuery('#'+tengrid" + capmodule + ").jqGrid({");
                w.WriteLine("        url: 'Controller/JqGrid/JQGrid<%=ma_module%>Load.ashx?ma_module=<%=ma_module%>&ma_menu='+$('#input_idmenu').val(),");
                w.WriteLine("        editurl: 'Controller/JQGridModify/JQGrid<%=" + ma_module_display + "%>Modify.ashx?ma_module=<%=ma_module%>&ma_menu='+$('#input_idmenu').val(),");
                w.WriteLine("        height: $('#div_getdt_"+ capmodule +"').height() - $('#input_docaogrid').val(),");
                w.WriteLine("        datatype: 'json',");
                w.WriteLine("        autowidth: true,");
                w.WriteLine("        shrinkToFit: true,");
                w.WriteLine("        rownumbers: true,");
                w.WriteLine("        viewrecords: true,");
                w.WriteLine("        search: true,");
                w.WriteLine("        scroll:false,");
                w.WriteLine("        rowNum: rownum"+ capmodule +",");
                w.WriteLine("        multiselect: <%=get_STTaID[3] %>,");
                w.WriteLine("        multiboxonly: <%=get_STTaID[3] %>,");
                w.WriteLine("        rowList: <%=get_records[1] %>,");
                w.WriteLine("        pager: '#pager'+tengrid" + capmodule + ",");
                w.WriteLine("        onSelectRow: function (ids) {");
				w.WriteLine("			 //checkbox customize");
				w.WriteLine("			 checkbox_JQgrid(tengrid" + capmodule + ", 0);");
                w.WriteLine("            var value_header = '', cell = $('#'+ tengrid" + capmodule + ").getRowData(ids);");
                w.WriteLine("            if (id_parent"+ capmodule +" != null) { ");
                w.WriteLine("                    value_header = <%=get_STTaID[1].Replace(\"id_\",\"header_\") %>;");
                w.WriteLine("                    header_<%=ma_module %> = value_header + header_sep + <%=get_STTaID[2] %>;");
                w.WriteLine("            }");
                w.WriteLine("            else {");
                w.WriteLine("                header_<%=ma_module %> = value_header + <%=get_STTaID[2] %>;");
                w.WriteLine("            }");
                w.WriteLine("            set_headerJQG(tengrid" + capmodule + ", header_<%=ma_module %>);");
				
				w.WriteLine("            // public id da chon");
                w.WriteLine("            if(ids != null & ids !='' & ids !='0'){");
				w.WriteLine("            	 id_<%=" + ma_module_display + " %> = ids;");
                w.WriteLine("                module_select[" + capmodule + "] = 1;");
                w.WriteLine("            }");
				if(capmodule < 2){
					w.WriteLine("            load_detail(load_grid" + capmodule + ", "+ (capmodule + 1) +", "+ capmodule +");");
				}
                w.WriteLine("        },");
                w.WriteLine("        colModel: [");
                w.WriteLine("            <%=colModel[0] %>");
                w.WriteLine("        ],");
                w.WriteLine("        beforeRequest: function() {");
                w.WriteLine("            //giữ focus");
                w.WriteLine("            input_focus"+ capmodule +" = $('input:focus').attr('class');");
                w.WriteLine("            //giữ filter start");
                w.WriteLine("            if (id_oper[load_stt"+ capmodule +"] == null)");
                w.WriteLine("                $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').id_sel = id_<%=" + ma_module_display + " %>;");
                w.WriteLine("            $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').module_select = " + module_select + ";");
                w.WriteLine("            if(load_grid" + capmodule + " == 0){");
                w.WriteLine("                $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').filters = filter_<%=ma_module %>;");
                w.WriteLine("                $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').page = page_<%=ma_module %>;");
                w.WriteLine("                $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').sord = sord_<%=ma_module %>;");
                w.WriteLine("                $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').sidx = sidx_<%=ma_module %>;");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                filter_<%=ma_module %> = $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').filters;");
                w.WriteLine("                page_<%=ma_module %> = $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').page;");
                w.WriteLine("                sord_<%=ma_module %> = $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').sord;");
                w.WriteLine("                sidx_<%=ma_module %> = $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').sidx;");
                w.WriteLine("            }");
				 w.WriteLine("           $('#' + tengrid" + capmodule + ").jqGrid('getGridParam', 'postData').id = id_parent" + capmodule);
                w.WriteLine("        },");
                w.WriteLine("        ondblClickRow: function(){");
                w.WriteLine("            <%=get_STTaID[4] %>;");
                w.WriteLine("        },");
                w.WriteLine("        gridComplete: function () {");
                w.WriteLine("            $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());");
                if(capmodule == 0){
					w.WriteLine("            if(load_grid"+ capmodule +" == 0){taonut_header(tengrid"+ capmodule +"); $('#gview_' + tengrid"+ capmodule +" + ' .ui-jqgrid-bdiv').click(); };");
				}
				else {
					w.WriteLine("            if(load_grid"+ capmodule +" == 0){taonut_header"+ capmodule +"(tengrid"+ capmodule +")};");
				}
                w.WriteLine("        },");
                w.WriteLine("        loadComplete: function (data) {");
                w.WriteLine("            //chia màu chẵn lẻ");
                w.WriteLine("            var top_rowid = $('#' + tengrid" + capmodule + " + ' tr:nth-child(2)').attr('id');");
                w.WriteLine("            phanmauchogrid(this);");
                if (mod.ma_moduletk != mod.ma_module)
                {
                    w.WriteLine("            if(id_<%=ma_moduletk %> != null & id_<%=ma_moduletk %> != '0')");
                    w.WriteLine("                $('#' + tengrid" + capmodule + ").jqGrid('setSelection', id_<%=ma_moduletk %>);");
                    w.WriteLine("            module_select[" + capmodule + "] = 1;");
                    w.WriteLine("            var b = $('#' + tengrid" + capmodule + ").jqGrid ('getGridParam', 'selrow');");
                    w.WriteLine("            if (b == null | b == '' | b == '0') {");
                    w.WriteLine("                if (id_<%=ma_moduletk %> == null | id_<%=ma_moduletk %> == '') {");
                    w.WriteLine("                    $('#' + tengrid" + capmodule + ").jqGrid('setSelection', top_rowid);");
                    w.WriteLine("                    if(top_rowid == null | top_rowid == '0')");
                    w.WriteLine("                    module_select[" + capmodule + "] = 2;");
                    w.WriteLine("                }");
                    w.WriteLine("                else {");
					if(capmodule < 2){
						w.WriteLine("                    load_detail(load_grid"+ capmodule +", "+ (capmodule+1) +", "+ capmodule +");");
					}
                    w.WriteLine("	                 module_select[" + capmodule + "] = 2;");
                    w.WriteLine("                }");
                    w.WriteLine("            }");
                    w.WriteLine("            else {");
                    w.WriteLine("            //click vào dòng vừa tạo mới");
                    w.WriteLine("                if(id_new == '0' | id_new == null)");
                    w.WriteLine("                { /*$('#'+tengrid" + capmodule + ").jqGrid('setSelection', id_<%=ma_moduletk %>);*/ }");
                    w.WriteLine("                else ");
                    w.WriteLine("                { resetSelection(tengrid" + capmodule + "); $('#'+tengrid" + capmodule + ").jqGrid('setSelection', id_new); id_new = '0';}");
                    w.WriteLine("                Focus_Selection(tengrid" + capmodule + ");");
                    w.WriteLine("            }");
                }
                else
                {
                    w.WriteLine("            if(id_<%=ma_module %> != null & id_<%=ma_module %> != '0')");
                    w.WriteLine("                $('#' + tengrid" + capmodule + ").jqGrid('setSelection', id_<%=ma_module %>);");
                    w.WriteLine("            module_select["+ capmodule +"] = 1;");
                    w.WriteLine("            var b = $('#' + tengrid" + capmodule + ").jqGrid ('getGridParam', 'selrow');");
                    w.WriteLine("            if (b == null | b == '' | b=='0') {");
                    w.WriteLine("                if(top_rowid != null & top_rowid != 0) {");
                    w.WriteLine("                    $('#' + tengrid" + capmodule + ").jqGrid('setSelection', top_rowid);");
                    w.WriteLine("                } else {");
					if(capmodule < 2){
						w.WriteLine("                    load_detail(load_grid"+ capmodule +", "+ (capmodule+1) +", "+ capmodule +");");
					}
                    w.WriteLine("                    module_select["+ capmodule +"] = 2;");
					w.WriteLine("                }");
                    w.WriteLine("            }");
                    w.WriteLine("            else {");
                    w.WriteLine("                if(id_new == '0' | id_new == null)");
                    w.WriteLine("                {	/*$('#'+tengrid" + capmodule + ").jqGrid('setSelection', id_<%=ma_module %>);*/ }");
                    w.WriteLine("                else");
                    w.WriteLine("                {  resetSelection(tengrid" + capmodule + "); clickSelection(tengrid"+ capmodule +", id_new); id_new = '0';}");
                    w.WriteLine("                Focus_Selection(tengrid" + capmodule + ");");
                    w.WriteLine("            }");
                }
                w.WriteLine("            //làm mới bộ lọc");
                w.WriteLine("            clearSearchOptions(tengrid" + capmodule + ");");
                /*//demmo edit inline
                var ids = jQuery("#"+tengrid" + capmodule + ").jqGrid('getDataIDs');
                for(var i=0;i < ids.length;i++){
                    var cl = ids[i];
                    be = "<input style='height:22px;width:20px;' type='button' value='E' onclick=\"jQuery('#'+tengrid" + capmodule + ").editRow('"+cl+"');$('#'+tengrid" + capmodule + ").jqGrid('setSelection', '"+ cl +"');\"  />"; 
                    se = "<input style='height:22px;width:20px;' type='button' value='S' onclick=\"jQuery('#'+tengrid" + capmodule + ").saveRow('"+cl+"');\"  />"; 
                    ce = "<input style='height:22px;width:20px;' type='button' value='C' onclick=\"jQuery('#'+tengrid" + capmodule + ").restoreRow('"+cl+"');\" />"; 
                    jQuery("#"+tengrid" + capmodule + ").jqGrid('setRowData',ids[i],{thaotac:be+se+ce});
                }*/
                w.WriteLine("            //giữ filter end");
                w.WriteLine("            if (load_grid" + capmodule + " == 0)");
                w.WriteLine("            {");
                w.WriteLine("                fix_disableSelect(tengrid" + capmodule + ");");
                w.WriteLine("                set_ValueFilter(tengrid" + capmodule + ", filterVal_<%=ma_module %>, sord_<%=ma_module %>, sidx_<%=ma_module %>);");
                w.WriteLine("                load_grid" + capmodule + " = 1;");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                filterVal_<%=ma_module %> = get_ValueFilter(tengrid" + capmodule + ");");
                w.WriteLine("            }");
				w.WriteLine("			 //checkbox customize");
				w.WriteLine("			 checkbox_JQgrid(tengrid" + capmodule + ", 1);");
                w.WriteLine("            //giữ focus end");
                w.WriteLine("            $('.'+input_focus" + capmodule + ").focus();");
                w.WriteLine("        },");
                w.WriteLine("        caption: ''");
                w.WriteLine("    });");
                w.WriteLine("\n");
                w.WriteLine("    jQuery('#'+tengrid" + capmodule + ").jqGrid('navGrid', '#pager'+tengrid" + capmodule + ",");
                w.WriteLine("    {");
                w.WriteLine("        <%=VNN_Config.get_navGrid(Context, " + ma_module_display + ") %>");
                w.WriteLine("    },{");
                w.WriteLine("    //edit");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[0][0] %>");
                w.WriteLine("            <%=modifyForm[0][1] %>");
                w.WriteLine("            <%=modifyForm[0][2] %>");
                w.WriteLine("            <%=modifyForm[0][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("            <%=colModel[1]%>");
                w.WriteLine("            <%=colModel[5] %>");
                w.WriteLine("            <%=colModel[6] %>");
                w.WriteLine("            Change_Value" + capmodule + "(Avariable" + capmodule + "(),'edit');");
                w.WriteLine("        },");
                w.WriteLine("        beforeSubmit: function (postdata, formid) {");
				w.WriteLine("            postdata.id_parent = id_parent"+ capmodule +";");
                w.WriteLine("            formid.prepend('<div class=\"nhan_loading\">&nbsp;</div>');");
                w.WriteLine("            return [true, ''];");
                w.WriteLine("        },");
                w.WriteLine("        afterSubmit: function (response, formid) {");
                w.WriteLine("            $('.nhan_loading').remove();");
                w.WriteLine("            if(thongbaokhimodify(response.responseText,this.id) == false)");
                w.WriteLine("            {");
                w.WriteLine("                return [false, response.responseText.split('#')[1]];");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                <%=colModel[5] %>");
                w.WriteLine("                <%=modifyForm[0][4] %>");
                w.WriteLine("                add_edit_del_complete" + capmodule + "('edit'); loadclick(tengrid" + capmodule + ",'edit',load_stt" + capmodule + ");");
                w.WriteLine("                return [false, ''];");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("    },{");
                w.WriteLine("    //add");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[1][0] %>");
                w.WriteLine("            <%=modifyForm[1][1] %>");
                w.WriteLine("            <%=modifyForm[1][2] %>");
                w.WriteLine("            <%=modifyForm[1][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("            <%=colModel[2]%>");
                w.WriteLine("            <%=colModel[3] %>");
                w.WriteLine("            <%=colModel[5] %>");
                w.WriteLine("            <%=colModel[7] %>");
                w.WriteLine("            Change_Value" + capmodule + "(Avariable" + capmodule + "(),'add');");
                w.WriteLine("            countRows(tengrid" + capmodule + ", 'sapxep');");
                w.WriteLine("        },");
                w.WriteLine("        beforeSubmit: function (postdata, formid) {");
				w.WriteLine("            postdata.id_parent = id_parent"+ capmodule +";");
                w.WriteLine("            formid.prepend('<div class=\"nhan_loading\">&nbsp;</div>');");
                w.WriteLine("            return [true, ''];");
                w.WriteLine("        },");
                w.WriteLine("        afterSubmit: function (response) {");
                w.WriteLine("            $('.nhan_loading').remove();");
                w.WriteLine("            if(thongbaokhimodify(response.responseText,this.id) == false)");
                w.WriteLine("            {");
                w.WriteLine("                return [false, response.responseText.split('#')[1]];");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                <%=colModel[4] %>");
                w.WriteLine("                <%=colModel[5] %>");
                w.WriteLine("                <%=modifyForm[1][4] %>");
                w.WriteLine("                id_new = response.responseText.split('#')[2]; countRows(tengrid" + capmodule + ", 'sapxep');");
                w.WriteLine("                add_edit_del_complete" + capmodule + "('add'); loadclick(tengrid" + capmodule + ",null,load_stt" + capmodule + ");");
                w.WriteLine("                return [false, ''];");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("    },{");
                w.WriteLine("    //del");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[2][0] %>");
                w.WriteLine("            <%=modifyForm[2][1] %>");
                w.WriteLine("            <%=modifyForm[2][2] %>");
                w.WriteLine("            <%=modifyForm[2][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("        },");
                w.WriteLine("        beforeSubmit: function (postdata, formid) {");
				w.WriteLine("            postdata.id_parent = id_parent"+ capmodule +";");
                w.WriteLine("            $('#DelTbl_'+tengrid" + capmodule + ").prepend('<div class=\"nhan_loading\">&nbsp;</div>');");
                w.WriteLine("            return [true, ''];");
                w.WriteLine("        },");
                w.WriteLine("        afterSubmit: function (response) {");
                w.WriteLine("            $('.nhan_loading').remove();");
                w.WriteLine("            if(thongbaokhimodify(response.responseText,this.id) == false)");
                w.WriteLine("            {");
                w.WriteLine("                return [false, response.responseText.split('#')[1]];");
                w.WriteLine("            }");
                w.WriteLine("            else");
                w.WriteLine("            {");
                w.WriteLine("                <%=modifyForm[2][4] %>");
                w.WriteLine("                add_edit_del_complete" + capmodule + "('del'); loadclick(tengrid" + capmodule + ", null,load_stt" + capmodule + ");");
                w.WriteLine("                return [false,''];");
                w.WriteLine("            }");
                w.WriteLine("        }");
                w.WriteLine("    }, {");
                w.WriteLine("    //search");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            formid.closest('div.ui-jqdialog').dialogCenter();");
                w.WriteLine("        }");
                w.WriteLine("    }, {");
                w.WriteLine("    //view");
                w.WriteLine("        beforeShowForm: function (formid) {");
                w.WriteLine("            <%=modifyForm[3][0] %>");
                w.WriteLine("            <%=modifyForm[3][1] %>");
                w.WriteLine("            <%=modifyForm[3][2] %>");
                w.WriteLine("            <%=modifyForm[3][3] %>");
                w.WriteLine("        },");
                w.WriteLine("        afterShowForm: function (formid) {");
                w.WriteLine("        },");
                w.WriteLine("    },{");
                w.WriteLine("    //refesh");
                w.WriteLine("    });");
                w.WriteLine("    jQuery('#'+tengrid" + capmodule + ").jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });");
                w.WriteLine("    jQuery('#pager'+ tengrid" + capmodule + " +'_left table').css('display','none');");
				w.WriteLine("    jQuery('#'+tengrid" + capmodule + ").jqGrid('setFrozenColumns');");
                w.WriteLine("    \n");
                w.WriteLine("    //Start Ham ho tro them cho Grid (sẽ tự update nếu module chính update)");
                w.WriteLine("    function Avariable" + capmodule + "() {");
                w.WriteLine("        var column_array = [];");
                w.WriteLine("        return column_array;");
                w.WriteLine("    }");
                w.WriteLine("    //--");
                w.WriteLine("    function Change_Value" + capmodule + "(column_array, action)");
                w.WriteLine("    {");
                w.WriteLine("        for(var i in column_array) {");
                w.WriteLine("            $('#' + column_array[i]).change(function() {");
                w.WriteLine("                 action_grid" + capmodule + "(action, $(this).attr('id'));");
                w.WriteLine("            });");
                w.WriteLine("        }");
                w.WriteLine("        action_grid" + capmodule + "(action, null);");
                w.WriteLine("    }");
                w.WriteLine("    //--");
                w.WriteLine("    function action_grid" + capmodule + "(action, column){");
                w.WriteLine("        if(action == 'add') {");
                w.WriteLine("        \n");
                w.WriteLine("        }");
                w.WriteLine("        else if(action == 'edit') {");
                w.WriteLine("        \n");
                w.WriteLine("        }");
                w.WriteLine("    }");
                w.WriteLine("    //--");
                w.WriteLine("    function add_edit_del_complete" + capmodule + "(action){");
                w.WriteLine("        if(action == 'add') {");
                w.WriteLine("        }");
                w.WriteLine("        else if(action == 'edit') {");
                w.WriteLine("        }");
                w.WriteLine("        else if(action == 'del') {");
                w.WriteLine("        }");
                w.WriteLine("    }");
                w.WriteLine("    //#End Ham ho tro them cho Grid (sẽ tự update nếu module chính update)");
                w.WriteLine("</script>");
                //--1>
			}
			else
            {
                w.WriteLine("<%@ Page Language=\"C#\" %>");
                w.WriteLine("<%");
                w.WriteLine("    string ma_module = \"" + mod.ma_module + "\";");
                w.WriteLine("    string[] get_STTaID = VNN_Config.get_IDParent_STTLoad(ma_module);");
                w.WriteLine("    string[][] modifyForm = VNN_Config.get_ModifyFormInfor(ma_module);");
                w.WriteLine("    string[] colModel = VNN_Config.get_colModel(Context, ma_module);");
                w.WriteLine("%>");
                w.WriteLine("<div class='sub_mainpage'></div>");
                w.WriteLine("<script type=\"text/javascript\">");
                w.WriteLine("    //bien load grid");
                w.WriteLine("    var input_focus=null, load_grid = 0, load_stt = 0, tengrid2 = '';");
                w.WriteLine("    //Cac bien can truyen vao truoc khi load chuc nang");
                w.WriteLine("    //--bien bat buoc");
                w.WriteLine("    var id_parent = <%=get_STTaID[1] %>;");
                w.WriteLine("    var tengrid = 'grid<%=ma_module%>';");
                w.WriteLine("    var Form_infor = '<%=VNN_VariablePublic.Form_infor %>';");
                w.WriteLine("    var Model_infor = '<%=VNN_VariablePublic.Model_infor %>' ;");
                w.WriteLine("    //--#bien bat buoc");
                w.WriteLine("    //#Cac bien can truyen vao truoc khi load chuc nang");
                w.WriteLine("    //Load chức năng");
                w.WriteLine("    <%=VNN_Config.get_NavFunc(Context, ma_module) %>");
                w.WriteLine("    //#Load chức năng");
                w.WriteLine("    taonut_header();");
                w.WriteLine("</script>");
                w.WriteLine("\n");
                w.WriteLine("<script type=\"text/javascript\">");
                w.WriteLine("    $('.sub_mainpage').css('height', window.innerHeight - 112);");
                w.WriteLine("</script>");
            }
            w.Flush();
            w.Close();
        }
    }

    public static void CreateFunction_ModuleScript(HttpContext context, Module_TK mod)
    {
        //Tạo file modify Controller
        string filepath = Security.UrlBase() + "js/" + "Module_script";
        string filename = "/" + mod.ma_module + ".js";
        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(context.Server.MapPath(filepath));
        }
        filepath = context.Server.MapPath(filepath + filename);

        if (!File.Exists(filepath) & (mod.ma_moduletk == mod.ma_module))
        {
            StreamWriter w = new StreamWriter(filepath, false, Encoding.Unicode);
            w.WriteLine("//Add function at here (don't remove this line, please)");
            w.Flush();
            w.Close();
        }
    }

    public static void EditFileGridVariables(HttpContext context, Module_TK mod)
    {
        EntityContext db = new EntityContext();
        RemoveTextGridVariables(context, mod.ma_module);
        System.Threading.Thread.Sleep(300);
        string filepath = Security.UrlBase() + "js/VNN_script/GridVariables.js";
        string replace_strID = "//ID module Cấp " + mod.capmodule;
        string replace_strFilter = "//Filter module Cấp " + mod.capmodule;
        string replace_strPage = "//Page module Cấp " + mod.capmodule;
        string replace_strSidx = "//Sidx module Cấp " + mod.capmodule;
        string replace_strSord = "//Sord module Cấp " + mod.capmodule;
        string replace_strHeader = "//Header module Cấp " + mod.capmodule;
        filepath = context.Server.MapPath(filepath);
        string w = File.ReadAllText(filepath, Encoding.Unicode);
        string new_strID = replace_strID + "\n" + "var id_" + mod.ma_module + " = 0;";
        string new_strFilter = replace_strFilter + "\n" + "var filter_" + mod.ma_module + " = null, filterVal_" + mod.ma_module + " = null;";
        string new_strPage = replace_strPage + "\n" + "var page_" + mod.ma_module + " = null;";
        string new_strSidx = replace_strSidx + "\n" + "var sidx_" + mod.ma_module + " = null;";
        string new_strSord = replace_strSord + "\n" + "var sord_" + mod.ma_module + " = null;";
        string new_strHeader = replace_strHeader + "\n" + "var header_" + mod.ma_module + " = null;";
        if (mod.ma_moduletk == mod.ma_module)
        {
            if (!w.Contains(new_strID))
            {
                w = w.Replace(replace_strID, new_strID);
            }
        }
        if (!w.Contains(new_strFilter))
        {
            w = w.Replace(replace_strFilter, new_strFilter);
        }
        if (!w.Contains(new_strPage))
        {
            w = w.Replace(replace_strPage, new_strPage);
        }
        if (!w.Contains(new_strSidx))
        {
            w = w.Replace(replace_strSidx, new_strSidx);
        }
        if (!w.Contains(new_strSord))
        {
            w = w.Replace(replace_strSord, new_strSord);
        }
        if (!w.Contains(new_strHeader))
        {
            w = w.Replace(replace_strHeader, new_strHeader);
        }
        File.WriteAllText(filepath, w, Encoding.Unicode);
    }

    public static void DeleteFileLoad_Modify(HttpContext context, string ma_module, string url)
    {
        EntityContext db = new EntityContext();
        RemoveTextGridVariables(context, ma_module);
        string filepath = Security.UrlBase() + "Controller/JQGrid/JQGrid" + ma_module + "Load.ashx";
        filepath += ":";
        filepath += Security.UrlBase() + "View/Menu/Content/Module/" + ma_module + ".aspx";
        filepath += ":";
        filepath += Security.UrlBase() + "Controller/JQGridModify/JQGrid" + ma_module + "Modify.ashx";
        filepath += ":";
        filepath += Security.UrlBase() + "js/Module_script/" + ma_module + ".js";
        for (int i = 0; i < filepath.Split(':').Count(); i++)
        {
            string filepath_delete = context.Server.MapPath(filepath.Split(':')[i]);
            if (System.IO.File.Exists(filepath_delete))
            {
                try
                {
                    System.IO.File.Delete(filepath_delete);
                }
                catch (System.IO.IOException e)
                {
                    context.Response.Write(e.Message);
                }
            }
        }
    }

    public static void RemoveTextGridVariables(HttpContext context, string ma_module)
    {
        string filepath = Security.UrlBase() + "js/VNN_script/GridVariables.js";
        filepath = context.Server.MapPath(filepath);
        string w = File.ReadAllText(filepath, Encoding.Unicode);
        w = w.Replace("\nvar id_" + ma_module + " = 0;", "");
        w = w.Replace("\nvar filter_" + ma_module + " = null, filterVal_" + ma_module + " = null;", "");
        w = w.Replace("\nvar page_" + ma_module + " = null;", "");
        w = w.Replace("\nvar sidx_" + ma_module + " = null;", "");
        w = w.Replace("\nvar sord_" + ma_module + " = null;", "");
        w = w.Replace("\nvar header_" + ma_module + " = null;", "");
        File.WriteAllText(filepath, w, Encoding.Unicode);
    }

    //Dung de update ham ho tro cho tat ca module thua ke tu module chinh
    public static int Update_InterFace(HttpContext context, Module_TK mod_, EntityContext db)
    {
        int dem = 0;
        string str_start = "//Start Ham ho tro them cho Grid (sẽ tự update nếu module chính update)";
        string str_end = "//#End Ham ho tro them cho Grid (sẽ tự update nếu module chính update)";
        //--
        string filepath = context.Server.MapPath(Security.UrlBase() + mod_.url);
        string w = System.IO.File.ReadAllText(filepath, Encoding.Unicode);
        string str_new = str_start + VNN_Function.FindString(w, str_start, str_end) + str_end;
        //--
        foreach (ad_module mod in db.ad_module.Where(s => s.thuake == (mod_.ad_module_id)).ToList())
        {
            string filepath2 = context.Server.MapPath(Security.UrlBase() + mod.url);
            string w2 = System.IO.File.ReadAllText(filepath2, Encoding.Unicode);
            string str_replace = str_start + VNN_Function.FindString(w2, str_start, str_end) + str_end;
            w2 = w2.Replace(str_replace, str_new);
            System.IO.File.WriteAllText(filepath2, w2, Encoding.Unicode);
            System.Threading.Thread.Sleep(250);
            dem++;
        }
        return dem;
    }
}