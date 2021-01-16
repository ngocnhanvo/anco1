using System;
using System.Linq;


public static class VNN_JQGridver2
{ 
	public static string get_layout(System.Web.HttpContext context ,string ma_module)
    {
        ADmin_JSON json = new ADmin_JSON();
        var modules = json.ad_moduleJSON();
        var role_mmcs = json.ad_role_mmcJSON();
        var user_mmcs = json.ad_user_mmcJSON();
        var mod = modules.Where(s=>s.ma_module == ma_module).FirstOrDefault();
		
		string li_mod0 = "", li_mod1 = "", li_mod2 = "";
		string div_mod0 = "", div_mod1 = "", div_mod2 = "";
		string[] arr_mod0_tk = new string[100];
		string[] arr_mod1_tk = new string[100];
		int dem_mod0 = 0, dem_mod1 = 0;
		foreach(var mod_0 in modules.Where(s=> s.ad_menu_id == mod.ad_menu_id & s.capmodule == 0 & s.hoatdong == true
		).OrderBy(s=>s.sapxep)) {
            if (Security.PhanQuyen_Module(context, role_mmcs, user_mmcs, mod_0.ad_module_id))
            {
				if(mod_0.thuake != ""){
					arr_mod0_tk[dem_mod0] = mod_0.thuake;
					li_mod0 += "<li sel_mod='"+ mod_0.thuake +"'><a onclick=\"load_detail(0,'"+ mod_0.ma_module +"',0, '" + mod_0.thuake + "', 0)\" href=\"#tabs_"+ mod_0.ma_module +"\">" + mod_0.ten_module +"</a></li>";
				}
				else {
					arr_mod0_tk[dem_mod0] = mod_0.ad_module_id;
					li_mod0 += "<li sel_mod='"+ mod_0.ad_module_id +"'><a onclick=\"load_detail(0,'"+ mod_0.ma_module +"',0, '" + mod_0.ad_module_id + "', 0)\" href=\"#tabs_"+ mod_0.ma_module +"\">" + mod_0.ten_module +"</a></li>";
				}
				div_mod0 += "<div id=\"tabs_" + mod_0.ma_module + "\">";
				div_mod0 += "<table id='grid" + mod_0.ma_module + "'></table>";
				div_mod0 += "<div id='pagergrid" + mod_0.ma_module + "'>";
				div_mod0 += "</div>";
				div_mod0 += "</div>";
				dem_mod0++;
			}
		}
		
		foreach(var mod_1 in modules.Where( s=> s.capmodule == 1 & arr_mod0_tk.Contains(s.ma_modulecha)
		& s.hoatdong == true).OrderBy(s=>s.sapxep)) {
			if (Security.PhanQuyen_Module(context, role_mmcs, user_mmcs, mod_1.ad_module_id))
            {
				if(mod_1.thuake != ""){
					arr_mod1_tk[dem_mod1] = mod_1.thuake;
					li_mod1 += "<li sel_mod='"+ mod_1.thuake +"' class='modcha_" + mod_1.ma_modulecha + "'><a onclick=\"load_detail(0,'"+ mod_1.ma_module +"',0,'" + mod_1.thuake + "',1)\" href=\"#tabs_"+ mod_1.ma_module +"\">" + mod_1.ten_module +"</a></li>";
				}
				else {
					arr_mod1_tk[dem_mod1] = mod_1.ad_module_id;
					li_mod1 += "<li sel_mod='"+ mod_1.ad_module_id +"' class='modcha_" + mod_1.ma_modulecha + "'><a onclick=\"load_detail(0,'"+ mod_1.ma_module +"',0,'" + mod_1.ad_module_id + "',1)\" href=\"#tabs_"+ mod_1.ma_module +"\">" + mod_1.ten_module +"</a></li>";
				}
				div_mod1 += "<div class='modcha_" + mod_1.ma_modulecha + "' id=\"tabs_" + mod_1.ma_module + "\"></div>";
				dem_mod1++;
			}
		}
		
		foreach(var mod_2 in modules.Where(s=> s.capmodule == 2 & arr_mod1_tk.Contains(s.ma_modulecha) 
		& s.hoatdong == true).OrderBy(s=>s.sapxep)) {
			if (Security.PhanQuyen_Module(context, role_mmcs, user_mmcs, mod_2.ad_module_id))
            {
				li_mod2 += "<li sel_mod='"+ mod_2.ad_module_id +"' class='modcha_"+ mod_2.ma_modulecha +"'><a mod_parent='"+ mod_2.ma_modulecha +"' onclick=\"load_detail(0,'"+ mod_2.ma_module +"',0, '" + mod_2.ad_module_id + "',2)\" href=\"#tabs_"+ mod_2.ma_module +"\">" + mod_2.ten_module +"</a></li>";
				div_mod2 += "<div class='modcha_"+ mod_2.ma_modulecha +"' id=\"tabs_"+ mod_2.ma_module +"\"></div>";
			}
		}
		
		string kq = "";
		//lay out 1
		kq += "<div class='ui-layout-north ui-widget-content' style='overflow:hidden' id='div_getdt_0'>";
		kq += "<ul class='ul_mod_0'>";
		kq += li_mod0;
		kq += "<li onclick=\"click_rutgon_div(0)\" style='float: right;margin: -2px 4px 0 0px;border: none; padding: 0px 4px 4px 4px;'><span class='btn_check_div0 glyphicon glyphicon-minus' style='font-size:14px; cursor:pointer' /></li>";
		kq += "</ul>"; 
		kq += div_mod0;
		kq += "</div>";
		//lay out 2
		kq += "<div class='ui-layout-center ui-widget-content' style='overflow:hidden' id='div_getdt_1'>";
		kq += "<ul class='ul_mod_1'>";
		kq += li_mod1;
		kq += "<li onclick=\"click_rutgon_div(1)\" style='float: right;margin: -2px 4px 0 0px;border: none; padding: 0px 4px 4px 4px;'><span class='btn_check_div1 glyphicon glyphicon-minus' style='font-size:14px; cursor:pointer' /></li>";
		kq += "</ul>"; 
		kq += div_mod1;
		kq += "</div>";
		//lay out 3
		kq += "<div class='ui-layout-south ui-widget-content' style='overflow:hidden' id='div_getdt_2'>";
		kq += "<ul class='ul_mod_2'>";
		kq += li_mod2;
		kq += "<li onclick=\"click_rutgon_div(2)\" style='float: right;margin: -2px 4px 0 0px;border: none; padding: 0px 4px 4px 4px;'><span class='btn_check_div2 glyphicon glyphicon-minus' style='font-size:14px; cursor:pointer' /></li>";
		kq += "</ul>"; 
		kq += div_mod2;
		kq += "</div>";
		return kq;
    }
	
	public static string get_layout_face(){
		string kq = "";
		kq += "if(Browser == 'FirefoxCanCel'){$('.sub_mainpage').css('height', window.innerHeight - 100);$('#input_docaogrid').val('107');}else {$('.sub_mainpage').css('height', window.innerHeight - 98);$('#input_docaogrid').val('102');}\n";
		kq += "$('.ui-layout-north').tabs();\n";
		kq += "$('.ui-layout-center').tabs();\n";
		kq += "$('.ui-layout-south').tabs();\n";
		kq += "var layout_vnn = $('#div_getdt_1').parent().layout({\n";
		kq += "	north: {\n";
		kq += "		size: '35%',\n";
		kq += "		minSize: '0%',\n";
		kq += "		maxSize: '100%',\n";
		kq += "		spacing_open: 1,\n";
		kq += "		spacing_closed: 1,\n";
		kq += "		onresize_end: function() {\n";
		kq += "			var o = $('#div_getdt_0').height();\n";
		kq += "			$('#' + tengrid0).setGridHeight(o - $('#input_docaogrid').val());\n";
		kq += "			//$('#' + tengrid0)[0].triggerToolbar();\n";
		kq += "			//var var_table_frozen = $('#' + tengrid0 + '_frozen').parent();\n";
		kq += "			//$(var_table_frozen).css('height', $(var_table_frozen).height() - 1);\n";
		kq += "		}\n";
		kq += "	},\n";
		kq += "	center: {\n";
		kq += "		onresize_end: function() {\n";
		kq += "			var o = $('#div_getdt_1').height();\n";
		kq += "			$('#' + tengrid1).setGridHeight(o - $('#input_docaogrid').val());\n";
		kq += "			//$('#' + tengrid1)[0].triggerToolbar();\n";
		kq += "			//var var_table_frozen = $('#' + tengrid1 + '_frozen').parent();\n";
		kq += "			//$(var_table_frozen).css('height', $(var_table_frozen).height() - 1);\n";
		kq += "		}\n";
		kq += "	},\n";
		kq += "	south: {\n";
		kq += "		size: '33%',\n";
		kq += "		minSize: '0%',\n";
		kq += "		maxSize: '100%',\n";
		kq += "		spacing_open: 1,\n";
		kq += "		spacing_closed: 1,\n";
		kq += "		onresize_end: function() {\n";
		kq += "			var o = $('#div_getdt_2').height();\n";
		kq += "			$('#' + tengrid2).setGridHeight(o - $('#input_docaogrid').val());\n";
		kq += "			//$('#' + tengrid2)[0].triggerToolbar();\n";
		kq += "			//var var_table_frozen = $('#' + tengrid2 + '_frozen').parent();\n";
		kq += "			//$(var_table_frozen).css('height', $(var_table_frozen).height() - 1);\n";
		kq += "		}\n";
		kq += "	}\n";
		kq += "});\n";
		return kq;
	}
}
