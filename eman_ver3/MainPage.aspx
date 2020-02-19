<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<html>
<head>
    <link rel="shortcut icon" href="images/logo/anco_logo.ico" />
    <title>eMan</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Css Grid -->
    <link href="css/layout-default.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/docsupport/prism.css">
    <link rel="stylesheet" href="css/chosen.css">
    <!-- Css VNN -->
    <link href="css/VNN_css/Default.css" rel="stylesheet" type="text/css" />
    <link href="css/VNN_css/Menu.css" rel="stylesheet" type="text/css" />
    <link href="css/VNN_css/Content.css" rel="stylesheet" type="text/css" />
    <!-- Css bootstrap -->
    <link href="css/bootstrap-awesome.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/FontAwesome/fontawesome_all.css">
    <!-- Script Grid -->
    <script src="js/Public_script/jquery-1.10.2.js" type="text/javascript"></script>
     <script src="js/Public_script/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="js/Public_script/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="js/Public_script/prism.js" type="text/javascript" charset="utf-8"></script>
    <!--Script VNN-->
    <script src="js/VNN_script/GridFunction_View.js" type="text/javascript"></script>
    <script src="js/VNN_script/GridFunction_Admin.js?ver=2" type="text/javascript"></script>
    <script async src="js/VNN_script/User_GridFormatter.js?ver=2" type="text/javascript"></script>
    <!-- layout -->
    <script src="js/Public_script/jquery.number.js" type="text/javascript"></script>
    <script src="js/Public_script/jquery.form.js" type="text/javascript"></script>
    <!-- Script Jqx Widgets -->
    <script src="js/jqxwidgets/jqxcore.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxbuttons.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxscrollbar.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxlistbox.js" type="text/javascript"></script>
    <!--/ layout -->
    <!--Script Module-->
    <%=kq_script[0]%>
</head>
<body class="main_body" id="main_body">
    <div id="mainpane">
        <!-- head_page -->
        <table class="nhan_header">
            <tr>
                <td style="width: 10%; min-width: 222px" align="center">
                    <div style="height:30px">
                        <img height="25px" width="70px" id="nhan_image" alt="" src="images/logo/emanAnco.png?ver1" />
                    </div>
                </td>
                <td style="width: 12px; min-width: 12px"></td>

                <td style="width: 138px; min-width: 138px">
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 12px;" onclick="click_back()" alt="" title="trở về trang trước" src="images/Menu/header_back2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0" onclick="click_refreshPage()" alt="" title="làm mới trang hiện tại" src="images/Menu/header_frefesh2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0;" onclick="click_doimau()" alt="" title="đổi màu" src="images/Menu/header_idea2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0;" alt="" title="giúp đỡ" src="images/Menu/header_ask2.png" />
                </td>
                <td align="right" class="cl_td_urlmenu" style="font-size: 10px !important"><span class="cl_span_urlmenu" style="display:none;">URL of clicking events</span></td>
                <td style="display:none; min-width: 110px; width: 110px" align="right">
                    <div id="logo_right" class="cl_div_chiadiv2" onclick="fix_loi_screen()">
                        <img height="30" width="60" style='margin: 0 0 0 20px;' alt="" title="hình ảnh" src="images/logo/logo_esc2.png" />
                    </div>
                </td>


            </tr>
        </table>
        <!-- #head_page -->

        <!-- main_page -->
        <div ui-view="noidungmain">
            <table class="nhan_content">
                <tr>
                    <td class="menu" valign="top">
                        <div class="menu_module_first" align="center">Đang tải menu ...</div>
                    </td>
                    <td style="width: 12px; min-width: 12px">
                        <div class="div_chiacach" style="margin: 10px 0px 0px -7px;">
                            <img class="cl_img_div_chiatach" width="20px" height="20px" alt="" src="images/Menu/phanquyen.png" />

                        </div>
                        <div onclick="view_log()" title="Xem nhật ký" class="div_chiacach" style="margin: -63px 0px 0px -7px;">
                            <img class="cl_img_div_chiatach" width="20px" height="20px" alt="" src="images/Menu/nhatky.png" />
                        </div>
                    </td>
                    <td class="noidung" valign="top">
                        <div class="menu_module_first" align="center">Đang tải module ...</div>
                    </td>
                </tr>
            </table>
        </div>
        <!-- #main_page -->

        <!-- footer -->
        <div class="footer">
            <div id="grid_small" style="display: none"></div>
            <p style="text-align: right; color: #033786">Version 1.0</p>
            <!-- chieu cao grid-->
            <input id="input_docaogrid" type="hidden" value="0" />
            <!-- ghi nhớ id menu đã nhấn-->
            <input id="input_idmenu" type="hidden" value="0" />
            <input id="input_urlmenu" type="hidden" value="0" />
            <!-- ghi nhớ tên menu đã nhấn-->
            <input id="input_tenmenu0" type="hidden" value="" />
            <input id="input_tenmenu1" type="hidden" value="" />
            <input id="input_tenmenu2" type="hidden" value="" />
            <!-- ghi nhớ id module đã nhấn-->
            <input id="input_idmodule0" type="hidden" value="0" />
            <input id="input_idmodule1" type="hidden" value="0" />
            <input id="input_idmodule2" type="hidden" value="0" />
            <!-- ghi nhớ tên module đã nhấn-->
            <input id="input_tenmodule1" type="hidden" value="" />
            <input id="input_tenmodule2" type="hidden" value="" />
            <!-- ghi nhớ đường dẫn để nhấn back -->
            <input id="input_trovetrangtruoc" type="hidden" value="" />
            <input id="input_ghinhomenu" type="hidden" value="" />
            <input id="input_ghinhomodule" type="hidden" value="" />
            <input id="input_nhanback" type="hidden" value="false" />
            <!-- bien chay timer -->
            <input id="bien_nguoinhan" style="display: none" type="hidden" value="" />
            <input id="bien_sessionmes" style="display: none" type="hidden" value="-1" />
            <input id="bien_sltinmoi" type="hidden" value="-1" />
            <input id="bien_ctrl" style="display: none" type="hidden" value="0" />
            <%=kq_script[1]%>
        </div>
        <!-- #footer -->
    </div>

    <script type="text/javascript">
        <%=kq_script[2]%>
        $('#mainpane').css('height', window.innerHeight - 15); 
		let height_menu_noidung = $('#mainpane').height() - $('.nhan_header').height();
		$('.menu').css('height', height_menu_noidung - 6);
        $('.noidung').css('height', height_menu_noidung);
        setTimeout(function () {
            loadMenu('Menu/Menu.htm');
        }, 10);

        $('body').click(function (e) {
            $('#div_chuotphai').remove();
        });
        load_doimau(null);
		<%
        string ma_module = "MD_00_NhatKy";
        string[] get_records = VNN_Config.get_records();
        string[] get_STTaID = VNN_Config.get_IDParent_STTLoad(ma_module);
        string[] colModel = VNN_Config.get_colModel(Context, ma_module);
		%>
		function view_log() {
            var tengrid_small = "MD_00_NhatKy";
            $('#mainpane').append('<div id="dlg_gridSmall" style="overflow: hidden;" title="Xem nhật ký"><div class="nhan_loading"></div>' +
            '<table id="grid' + tengrid_small + '" class="gridResize"></talbe>' +
            '<div  id="pagergrid' + tengrid_small + '"></div>' +
            '</div>');
			
			let ten_md_select = $('.module_spanselect').text();
			let ma_md_select = '';
			if(ten_md_select != null & ten_md_select != '') {
				ma_md_select = $('.module_spanselect').attr('id').replace('span_','');
				ten_md_select = ten_md_select + ' - [' + ma_md_select + ']';
			}
			var firstload_<%=ma_module%> = 0;
            $('#dlg_gridSmall').dialog({
                modal: true,
                width: 700,
                height: 500,
                open: function (event, ui) {
                    Logo_Center("glyphicon glyphicon-time", true);
                    jQuery('#grid' + tengrid_small).jqGrid({
                        url: 'Controller/JqGrid/JQGrid' + tengrid_small + 'Load.ashx?ma_module=' + tengrid_small + '&id=',
                        editurl: 'Controller/JQGridModify/JQGrid' + tengrid_small + 'Modify.ashx?ma_module=' + tengrid_small,
						datatype: 'json',
						height:318,
						autowidth: true,
						shrinkToFit: true,
						rownumbers: true,
						viewrecords: true,
						search: true,
						scroll:false,                    
						multiselect: false,
						multiboxonly: false,
						rowNum: <%=get_records[0] %>,
						rowList: <%=get_records[1] %>,
						pager: '#pagergrid'+tengrid_small,
                        onSelectRow: function (ids) {
                            id_<%=ma_module %> = ids;
                        },
                        colModel: [
                            <%=colModel[0] %>
                        ],
						ondblClickRow: function(e){
							<%=get_STTaID[4] %>;
						},
						beforeRequest: function() { 
							//giữ focus
							input_focus = $('input:focus').attr('id');
							$('#grid' + tengrid_small).jqGrid('getGridParam', 'postData').module_select = 1;
						},
                        gridComplete: function () {
                            $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
                        },
                        loadComplete: function (data) {
                            $('.nhan_loading').remove();
                            $('#grid' + tengrid_small).jqGrid('setSelection', id_<%=ma_module %>);
							if(firstload_<%=ma_module%> == 0){
								$('#gs_ad_module_id').val(ten_md_select);
								firstload_<%=ma_module%> = 1;
								$('#grid' + tengrid_small).jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" (md.ten_module+\' - [\'+md.ma_module+\']\')","op":"bw","data":"'+ ten_md_select +'"}]}';
								setTimeout(function(){ loadclick_('grid'+tengrid_small,null); }, 300);
							}
                        },
                        caption: ""
                    });
                    jQuery('#grid' + tengrid_small).jqGrid('navGrid', '#pagergrid' + tengrid_small, {
                         add:false,edit:false,del:false,search:false,view:true,refresh:true
                    }, {}, {}, {}, {}, {}, {}, {});
                    jQuery("#grid" + tengrid_small).jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });
                },
                close: function () {
                    $(this).dialog("destroy").remove();
                },
                buttons: [
                    {
                        id: 'btn-close',
                        text: 'Thoát',
                        click: function () {
                            $(this).dialog("destroy").remove();
                        }
                    }
                    ]
            });
        }
		
		
		//Load auto
		<%=VNN_Function.setFunction_AutoLoad(db) %>

		//Xem chi tiết tài khoản
		let ma_tk = '<%=tk.ma_user %>';
		let ma_role = '<%=tk.ma_role %>';
        let ten_role = '<%=tk.ten_role %>';
        let ma_phongban = '<%=tk.ma_phongban %>';
		let token = '<%=tk.ad_user_id + "-" + tk.ad_role_id %>';
		//thong tin chung
		let url_org_sys = '<%=Security.UrlBase() %>';
		let ten_canhbao = '<%=ttc.ten_canhbao %>';
		let logo_trangchu = url_org_sys + '<%=ttc.logo_trangchu %>';
        ngayhethong = '<%=ttc.format_ngay %>';
        now = get_now();
		let sohethong = '<%=ttc.format_so %>';
		let thoigiansanxuat_md = '<%=ttc.domain %>';
		let thoigianhoanthanh_md = '<%=ttc.email_hotro %>';
		let date_import = '<%=date_ip %>';
        var monthDF = (new Date()).getMonth() + 1;
        var yearDF = (new Date()).getFullYear();
		let dec = vnn_formatnumber()[0], thous = vnn_formatnumber()[1];
		//cookie tai khoan
		let cookie = '<%=tk.ad_user_id %>';
		$.jqm.params.closeoverlay = false;
		$.jgrid.no_legacy_api = true; 
		$.jgrid.useJSON = true; 
		// extension:
		$.fn.scrollEnd = function(callback, timeout) {          
		  $(this).scroll(function(){
			let $this = $(this);
			if ($this.data('scrollTimeout')) {
			  clearTimeout($this.data('scrollTimeout'));
			}
			$this.data('scrollTimeout', setTimeout(callback,timeout));
		  });
		};
		//
		function load_sct(ma_sct) {
			let kq = '';
			<%=VNN_VariablePublic.get_mauhienthi_sochungtu(db)%>
			return kq;
		}

        function changeTypeNumberDecToIntOrElse(elem, type, dec) {
            let valSav = elem.val();
            let id = elem.attr('id');
            elem.parent().html( elem.parent().html());
            elem = $('#'+id);
            elem.val(valSav);
            if(type == 1)
                format_number(elem, 1);
            else
                format_number(elem, 0, !dec ? 4 : dec);
        }

		history.pushState(null,null,""),window.addEventListener("popstate",function(){history.pushState(null,null,"")}),"Firefox"!=Browser&&$(window).bind("beforeunload",function(n){return null==reload_page?'BẠN MUỐN LÀM MỚI LẠI GIAO DIỆN?\n\n >> Nhấn "Reload This Page" để làm mới\n >> Nhấn "Don\'t Reload" để hủy thao tác.':void 0});
    </script>
</body>
</html>



