<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>
<html>
<head>
    <link rel="shortcut icon" href="images/logo/anco_logo.ico" />
    <title>eMan</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Css Grid -->
    <link href="css/layout-default.css?ver=<%=version %>" rel="stylesheet" type="text/css" />
    <link href="css/style.css?ver=<%=version %>" rel="stylesheet" type="text/css" />
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
    <script src="js/Public_script/jquery.signalR-2.4.1.min.js" type="text/javascript"></script>
    <script src="signalr/hubs" type="text/javascript"></script>
    <script src="js/VNN_script/ExecSignalR.js?ver=<%=version %>" type="text/javascript"></script>
    <script src="js/Public_script/jquery.jqGrid.min.js?ver=<%=version %>" type="text/javascript"></script>
    <script src="js/Public_script/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="js/Public_script/prism.js" type="text/javascript" charset="utf-8"></script>
    <!--Script VNN-->
    <script src="js/VNN_script/GridFunction_View.js?ver=<%=version %>" type="text/javascript"></script>
    <script src="js/VNN_script/GridFunction_Admin.js?ver=<%=version %>" type="text/javascript"></script>
    <script async src="js/VNN_script/User_GridFormatter.js?ver=<%=version %>" type="text/javascript"></script>
    <!-- layout -->
    <script src="js/Public_script/jquery.number.js" type="text/javascript"></script>
    <script src="js/Public_script/jquery.form.js" type="text/javascript"></script>
    <script src="js/Public_script/jquery.dragScroll.js" type="text/javascript"></script>
    <script src="js/VNN_script/CheckBrowser.js" type="text/javascript"></script>
    <!-- Script Jqx Widgets -->
    <script src="js/jqxwidgets/jqxcore.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxbuttons.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxscrollbar.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxlistbox.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxdragdrop.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxtree.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxcheckbox.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxdata.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxmenu.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxcombobox.js" type="text/javascript"></script>

    <script src="js/ComboGrid/plugin/jquery.ui.combogrid-1.6.3.js" type="text/javascript"></script>
    <link href="js/ComboGrid/css/jquery.ui.combogrid.css" rel="stylesheet" />

    <script src="js/Public_script/moment.js"></script> 
    <script src="extension/mess/tableToExcel.js"></script>
    <script lang="javascript" src="js/Public_script/xlsx.full.min.js"></script>
    <!--/ layout -->
    
    <!--Script Module-->
    <%=kq_script[0]%>

    <script type="text/javascript">
        var jqgridXHR = [];
        var click_reloadJavascript = function () {
            let countModuleTotal = 0, countModuleLoaded = 0;
            let divScript = $('#divScript');

            let loadScriptUrl = function (link, text) {
                countModuleTotal++;
                $.getScript(link, function (data, textStatus, jqxhr) {
                    divScriptLoaded(text);
                }).fail(function () {
                    if (arguments[0].readyState == 0) {
                        //script failed to load
                        divScriptLoaded(text);
                    } else {
                        //script loaded but failed to parse
                        divScriptLoaded(text);
                    }
                });
            };

            let divScriptLoaded = function (text) {
                countModuleLoaded++;
                divScript.html(`Tổng: ${countModuleTotal}, đã tải: ${countModuleLoaded}`);

                if (countModuleTotal == countModuleLoaded) {
                    let sto1 = setTimeout(function () {
                        divScript.html('Đã cập nhật javascript thành công.');
                        let sto2 = setTimeout(function () {
                            divScript.hide();
                            clearTimeout(sto2);
                        }, 200);
                        clearTimeout(sto1);
                    }, 200);
                }
            };

            //if (confirm('Bạn có chắn chắn muốn tải lại thư viện javascript???')) {
                divScript.show();
                <%=kq_script[3]%>;
            //}
        };

    </script>

    <style type="text/css">
        @media (min-width: 721px) {
            .menuMobile {
                display: none;
            }
        }

         @media (max-width: 720px) {
            td.tdDisplayMenuConfig, td.menuSpaceModule, td.tdDisplayButton {
                display: none;
            }

            td.menu {
                min-width: 220px;
                position: absolute;
                z-index: 4;
                box-shadow: 1px 1px 4px #000;
            }

            .menuMobile {
                color: #FFF;
                font-size: 14px !important;
                padding: 8px;
            }

            .ui-dialog, .ui-jqdialog, .ui-jqdialog-content .FormGrid {
                max-width: 100%;
            }

            .ui-pager-control > table.ui-pg-table > tbody > tr > td:first-child, 
            .ui-pager-control > table.ui-pg-table > tbody > tr > td:last-child {
                display: none;
            }
        }
    </style>
</head>
<body class="main_body" id="main_body">
    <div style="display:none" id="divRoteMobile">Hãy xoay điện thoại theo hướng dọc</div>
    <div style="display:none" id="divScript">Đang tải..</div>
    <div style="display:none" id="divVirtual"></div>
    <div class="overlay-dark"></div>
    <img alt="" class="img-overlay" />
    <div class="ckeditorPublic hidden">
        <iframe style="width:100%;height:100%" loaded="false"></iframe>
    </div>
    <div id="mainpane">
        <!-- head_page -->
        <table class="nhan_header">
            <tr>
                <td class="tdDisplayMenuConfig" align="center">
                    <div class="displayMenuConfig">
                        <span title="Ẩn/hiện menu (ALT+Q)" class="glyphicon glyphicon-cog"></span>
                    </div>
                    <div style="height:30px">
                        <img id="nhan_image" alt="" src="images/logo/emanAnco.png?ver1" 
							style="
								height: 20px;
								padding: 7px;
								margin-top: -3px;
							"
						/>
                    </div>
                </td>

                <td style="width: 12px; min-width: 12px">
                    <div onclick="showMenuMobile();" class="menuMobile">
                        <i class="fa fa-bars"></i>
                    </div>
                </td>

                <td class="tdDisplayButton" style="width: 180px; min-width: 180px">
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 12px;" onclick="click_back()" alt="" title="trở về trang trước" src="images/Menu/header_back2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0" onclick="click_refreshPage(true)" alt="" title="làm mới trang hiện tại" src="images/Menu/header_frefesh2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0;" onclick="click_doimau()" alt="" title="đổi màu" src="images/Menu/header_idea2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0;" onclick="loadContent('MN_01_HT1','','Hướng dẫn sử dụng','Trợ Giúp')" alt="" title="giúp đỡ" src="images/Menu/header_ask2.png" />
                    <%if (tk.ma_user == "admin")
                    {%>
                        <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0;" onclick="click_reloadJavascript()" alt="" title="Tải lại thư viện của module (CTRL+SHIFT+S)" src="images/Menu/javascript.png" />
                    <%}%>
                </td>
                <td class="cl_td_urlmenu">
                    <div>
                        <span class="cl_span_urlmenu" style="display:none;">URL of clicking events</span>
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
                    <td class="menuSpaceModule">
                        <div onclick="configModelGridForUser()" class="div_chiacach" style="margin: 10px 0px 0px -7px;">
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
        var transformAll = 1;
        var layoutSize = <%=layoutSize%>;
        var ratePercentTransform = 1/transformAll;
        var ratePercentTransform100 = ratePercentTransform * 100;
        let bodyAll = document.getElementsByTagName('body')[0];
        //bodyAll.style.transform = "scale(" + transformAll + ")";
        //bodyAll.style.width = ratePercentTransform100 + "%";
        //bodyAll.style.height = ratePercentTransform100 + "%";
        //bodyAll.style.transformOrigin = "left top";
        //bodyAll.style.zoom = transformAll*100 + "%";

        <%=kq_script[2]%>
        //$('#mainpane').css('height', window.innerHeight - 15); 
        var heightBody = getSizeBrowser().height;
        var idWindow = uuidv4();
        var heightHeader = $('.nhan_header').height();
        var heightFooter = $('.footer').height();
        var height_menu_noidung = heightBody - (heightHeader + heightFooter) * ratePercentTransform;
        var searchParams = new URLSearchParams(window.location.search);
        var isLinkTransfer = searchParams.has('menu');
        var googleMapLoaded = false;
        var input_focus_public;
        var formVisible_addEdit, formVisible_Del, formVisible_addEdit_id, formVisible_Del_id;

        var hideTabInGrid = function (arrMaModule, selected) {
             arrMaModule.forEach(function(str) {
                 let item = $(`li[aria-controls="tabs_${str}"][role="tab"]`);
                 item.hide();
            });

            if (selected) {
                $(`li[aria-controls="tabs_${selected}"][role="tab"] > a`).click();
            }
            return arrMaModule;
        };

        if(isLinkTransfer) 
        {
            $('td.menu').css('display', 'none');
            $('td.menu').next().css('display', 'none');
            $('.nhan_header').css('visibility', 'hidden');
        }
        else {
            $.getScript( "https://polyfill.io/v3/polyfill.min.js?features=default", function( data, textStatus, jqxhr ) {
                $.getScript( "https://maps.googleapis.com/maps/api/js?key=<%=ttc.url_lichtuan%>&libraries=places", function( data, textStatus, jqxhr ) {
                    googleMapLoaded = true;
                });
            });
        }

        $('.menu').height(height_menu_noidung);

        let sto3 = setTimeout(function () {
            loadMenu('Menu/Menu.htm');
            clearTimeout(sto3);
        }, 10);

        let inter270323 = setInterval(function () {
            if (reload_page) {
                clearInterval(inter270323);
            }
            else {
                checkNewReport();
            }
        }, 60000);

        $('body').click(function (e) {
            $('#div_chuotphai').remove();
        });

		<%
        string ma_module = "MD_00_NhatKy";
        string[] get_records = VNN_Config.get_records();
        string[] get_STTaID = VNN_Config.get_IDParent_STTLoad(ma_module);
        string[] colModel = VNN_Config.get_colModel(Context, ma_module);
		%>
		function view_log() {
            let tengrid_small = "MD_00_NhatKy";
			
            let ma_md_select = $('.module_spanselect').attr('regiongrid');
		    try {
		        if(ma_md_select == null | ma_md_select == '') {
		            ma_md_select = $('.module_spanselect').attr('id').replace('span_','');
		        }

		        if(ma_md_select) {
		            ma_md_select = '[' + ma_md_select.replace("grid", "") + ']';
		        }
		        else {
		            return;
		        }
		    }
		    catch(r) {
		        return;
		    }

		    $('#mainpane').append('<div id="dlg_gridSmall" style="overflow: hidden;" title="Xem nhật ký"><div class="nhan_loading"></div>' +
            '<table id="grid' + tengrid_small + '" class="gridResize"></talbe>' +
            '<div  id="pagergrid' + tengrid_small + '"></div>' +
            '</div>');
            
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
						ondblClickRow: function(e) {
						    $('#view_gridMD_00_NhatKy').click();
						},
						beforeRequest: function() { 
							//giữ focus
							input_focus = $('input:focus').attr('id');
							$('#grid' + tengrid_small).jqGrid('getGridParam', 'postData').module_select = 1;

                            if(firstload_<%=ma_module%> == 0) {
							    $('#grid' + tengrid_small).jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" (md.ten_module+\' - [\'+md.ma_module+\']\')","op":"bw","data":"'+ ma_md_select +'"}]}';
							}
						},
                        gridComplete: function () {
                            $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
                        },
                        loadComplete: function (data) {
                            $('.nhan_loading').remove();
                            $('#grid' + tengrid_small).jqGrid('setSelection', id_<%=ma_module %>);
                            if(firstload_<%=ma_module%> == 0) {
                                firstload_<%=ma_module%> = 1;
                                $('#gs_ad_module_id').val(ma_md_select);
                            }
                        },
                        caption: ""
                    });
                    jQuery('#grid' + tengrid_small).jqGrid('navGrid', '#pagergrid' + tengrid_small, {
                         add:false,edit:false,del:false,search:false,view:true,refresh:true
                    }, {}, {}, {}, {}, {  beforeShowForm: function (formid) { formid.closest('div.ui-jqdialog').dialogCenter(); } }, {}, {});
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

        var clickToShowOrHideElement = function(a) {
            let type = $(a).parent().parent().attr('id').lastIndexOf('listHide') > -1 ? 0 : 1;
            let itemHides = $("#listHide").jqxListBox('getItems');
            let itemShows = $("#listShow").jqxListBox('getItems');
            let text = $(a).next().text();
            console.log(text);
            if(type == 0) {
                let index = itemHides.findIndex(function(a){ return a.label == text });
                let item = $("#listHide").jqxListBox('getItem', index);
                
                $("#listHide").jqxListBox('removeAt', index); 
                $("#listShow").jqxListBox('insertAt', item, itemShows.length);
            }
            else {
                let index = itemShows.findIndex(function(a){ return a.label == text });
                let item = $("#listShow").jqxListBox('getItem', index);

                $("#listShow").jqxListBox('removeAt', index); 
                $("#listHide").jqxListBox('insertAt', item, itemHides.length);

            }
        };

        function configModelGridForUser() {
            let ma_md_select = $('.module_spanselect').attr('regiongrid');
            try {
                if(ma_md_select == null | ma_md_select == '') {
                    ma_md_select = 'grid' + $('.module_spanselect').attr('id').replace('span_','');
                }

                if(!ma_md_select)
                    return;
            }
            catch(r) {
                return;
            }

            let gridSet = $("#"+ma_md_select);
            let models = gridSet.jqGrid('getGridParam', 'colModel').filter(function(a) { return a.khoaTuyChinh != true & ['rn','cb'].lastIndexOf(a.name) <= -1});
            let listShow = models.filter(function(a){ return a.hidden == false });
            let listHide = models.filter(function(a){ return a.hidden == true });

            let options = '';
            for(let i = 1; i <= 99; i++) {
                options += `<option value="${i}">${i}</option>`;
            } 

            $('#mainpane').append(`
                <div id="dlg_gridSmall" style="overflow: hidden;" title="Cấu hình lưới dữ liệu">
                    <table>
                        <tr>
                            <td colspan=3>
                                <input type="radio" style="position: relative;top: 1.5px;left: -1px;" id="thayDoiKichThuocLuoiDuLieu" name="tuyChonCauHinhLuoi"/>
                                <label for="thayDoiKichThuocLuoiDuLieu"><b>Thay đổi kích thước lưới dữ liệu</b></label>
                            </td>
                        </tr>
                        <tr class="thayDoiKichThuocLuoiDuLieu">
                            <td colspan=3>
                                <label style='padding-left:15px;'>- Trường hợp có 2 lưới:</label>
                                <select id="th2luoi1">${options}</select>
                                <select id="th2luoi2">${options}</select>
                                <select id="th2luoi3" disabled>${options}</select>
                            </td>
                        </tr>
                        <tr class="thayDoiKichThuocLuoiDuLieu">
                            <td colspan=3>
                                <label style='padding-left:15px;'>- Trường hợp có 3 lưới:</label>
                                <select id="th3luoi1">${options}</select>
                                <select id="th3luoi2">${options}</select>
                                <select id="th3luoi3" disabled>${options}</select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan=3>
                                <input type="radio" style="position: relative;top: 1.5px;left: -1px;" id="macDinhChieuDaiTungCot" name="tuyChonCauHinhLuoi"/>
                                <label for="macDinhChieuDaiTungCot"><b>Mặc định chiều dài của từng cột giống với cột trên lưới dữ liệu</b></label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan=3>
                                <input type="radio" style="position: relative;top: 1.5px;left: -1px;" id="sapXepCotHoacAnHienCot" name="tuyChonCauHinhLuoi"/>
                                <label for="sapXepCotHoacAnHienCot"><b>Sắp xếp cột hoặc ẩn hiển cột</b></label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan=3><div style="height:5px"></div></td>
                        </tr>
                        <tr>
                            <td><label><b>Cột hiển thị</b></label></td>
                            <td style="width:10px"></td>
                            <td><label><b>Cột bị ẩn</b></label></td>
                        </tr>
                        <tr>
                            <td><div id="listShow"></div></td>
                            <td></td>
                            <td><div id="listHide"></div></td>
                        </tr>

                        <tr>
                            <td><div id="listShow"></div></td>
                            <td></td>
                            <td style="text-align: right">
                                <input type="checkbox" style="position: relative;top: 1.5px;left: -1px;" id="khoiPhucCaiDatMacDinh"/>
                                <label style="user-select: none;" for="khoiPhucCaiDatMacDinh">Khôi phục cài đặt mặc định</label>
                            </td>
                        </tr>
                    </table>
                </div>`
            );

            $('#dlg_gridSmall').dialog({
                modal: true,
                width: 540,
                height: 485,
                open: function (event, ui) {
                    let getLayoutSize = layoutSize.filter(function(a){ return a.module == getModuleCodeFromSpanSelect() })[0];
                    let listSizeTH1 = $('#div_getdt_1').attr('sizeTH1').split(',');
                    let listSizeTH2 = $('#div_getdt_1').attr('sizeTH2').split(',');
                    if(getLayoutSize != null) {
                        listSizeTH1 = getLayoutSize.size1;
                        listSizeTH2 = getLayoutSize.size2;
                    }

                    let th2luoi1 = $('#th2luoi1');
                    let th2luoi2 = $('#th2luoi2');
                    let th2luoi3 = $('#th2luoi3');

                    th2luoi1.val(listSizeTH1[0]);
                    th2luoi2.val(listSizeTH1[1]);
                    th2luoi3.val(listSizeTH1[2]);

                    th2luoi1.change(function() {
                        th2luoi2.val(100 - Number($(this).val()) - 1);
                    });

                    th2luoi2.change(function() {
                        th2luoi1.val(100 - Number($(this).val()) - 1);
                    });

                    let th3luoi1 = $('#th3luoi1');
                    let th3luoi2 = $('#th3luoi2');
                    let th3luoi3 = $('#th3luoi3');

                    th3luoi1.val(listSizeTH2[0]);
                    th3luoi2.val(listSizeTH2[1]);
                    th3luoi3.val(listSizeTH2[2]);

                    th3luoi1.change(function() {
                        let slcl = 100 - Number(th3luoi1.val()) - Number(th3luoi3.val());
                        th3luoi2.val(slcl);
                    });

                    th3luoi2.change(function() {
                        let slcl = 100 - Number(th3luoi1.val()) - Number(th3luoi2.val());
                        th3luoi3.val(slcl);
                    });

                    $("#listShow").jqxListBox({ allowDrop: true, allowDrag: true, source: listShow, width: 250, height: 280, 
                        renderer: function (index, label, value) {
                            return "<span style='cursor:pointer' onclick='clickToShowOrHideElement(this)' class='clickToShowOrHideElement glyphicon glyphicon-minus'></span><label style='margin-left:5px'>" + label + "</label>";
                        } 
                    });
                    $("#listHide").jqxListBox({ allowDrop: true, allowDrag: true, source: listHide, width: 250, height: 280, 
                        renderer: function (index, label, value) {
                            return "<span style='cursor:pointer' onclick='clickToShowOrHideElement(this)' class='clickToShowOrHideElement glyphicon glyphicon-plus'></span><label style='margin-left:5px'>" + label + "</label>";
                        } 
                    });

                    let updateItemsForList = function(items) {
                        for(let i=0; i<items.length; i++) {
                            if(i > 0) {
                                let prev = items[i - 1].originalItem.name;
                                items[i - 1].originalItem.namePrev = prev;
                            }
                            items[i].value = items[i].originalItem;
                        }

                        return items;
                    }

                    let itemShows = $("#listShow").jqxListBox('getItems');
                    itemShows = updateItemsForList(itemShows);

                    let itemHides = $("#listHide").jqxListBox('getItems');
                    itemHides = updateItemsForList(itemHides);

                    $('#sapXepCotHoacAnHienCot').prop('checked', true);

                    let moKhoaOrKhoaList = function(type){
                        $('#listShow').jqxListBox({ disabled: type });
                        $('#listHide').jqxListBox({ disabled: type }); 
                    }

                    $('input[name="tuyChonCauHinhLuoi"]').change(function(){
                        let checked = $(this).prop('checked');
                        if(checked) {
                            let id =  $(this).attr('id');
                            $('tr.thayDoiKichThuocLuoiDuLieu').hide();
                            if(id =='sapXepCotHoacAnHienCot')
                                moKhoaOrKhoaList(false);
                            else {
                                moKhoaOrKhoaList(true);
                                if(id == 'thayDoiKichThuocLuoiDuLieu') {
                                    $('tr.thayDoiKichThuocLuoiDuLieu').show();
                                }
                            }
                        }
                    });

                    $('#khoiPhucCaiDatMacDinh').change(function(){
                        let checked = $(this).prop('checked');
                        if(checked) {
                            moKhoaOrKhoaList(true);
                            $('input[name="tuyChonCauHinhLuoi"]').prop('disabled', true);
                        }
                        else {
                            $('input[name="tuyChonCauHinhLuoi"]').prop('disabled', false);
                            $('input[name="tuyChonCauHinhLuoi"]').change();
                        }
                    });

                    $('input[name="tuyChonCauHinhLuoi"]:checked').change();
                    Logo_Center("glyphicon glyphicon-cog", true);
                },
                close: function () {
                    $(this).dialog("destroy").remove();
                },
                buttons: [
                    {
                        id: 'btn-ok',
                        text: 'Đồng ý',
                        click: function () {
                            let khoiPhucCaiDatMacDinh = $('#khoiPhucCaiDatMacDinh').prop('checked');
                            let thayDoiKichThuocLuoiDuLieu = $('#thayDoiKichThuocLuoiDuLieu').prop('checked');
                            let macDinhChieuDaiTungCot = $('#macDinhChieuDaiTungCot').prop('checked');
                            let sapXepCotHoacAnHienCot = $('#sapXepCotHoacAnHienCot').prop('checked');
                            let type =
                                thayDoiKichThuocLuoiDuLieu ? 4 : (
                                    khoiPhucCaiDatMacDinh ? 3 : (
                                        sapXepCotHoacAnHienCot ? 2 : (
                                            macDinhChieuDaiTungCot ? 1 : 0
                                        )
                                    )
                                );

                            let oper = 'configColumns';

                            let itemModels = [];

                            if(type == 1) {
                                let gridGS = gridSet[0].grid.headers;
                                let gridGSCP = gridSet[0].grid.headersCp;
                                for(let i in models) {
                                    let model = models[i];
                                    let indexGridGS = gridGS.findIndex(function(a) { return a.el.id == ma_md_select + '_' + model.name });
                                    let oldWidth = gridGSCP[indexGridGS].width;

                                    if(oldWidth != model.width) {
                                        itemModels.push({
                                            name: model.name,
                                            label: model.label,
                                            hidden: model.hidden,
                                            width: model.width
                                        });
                                    }
                                }
                            }
                            else if(type == 2) {
                                let items = $("#listShow").jqxListBox('getItems');
                                for(let i in items) {
                                    let item = items[i];
                                    itemModels.push({
                                        name: item.value.name,
                                        label: item.value.label,
                                        hidden: false
                                    });
                                }

                                items = $("#listHide").jqxListBox('getItems');
                                for(let i in items) {
                                    let item = items[i];
                                    itemModels.push({
                                        name: item.value.name,
                                        label: item.value.label,
                                        hidden: true
                                    });
                                }
                            }
                            else if(type == 4) {
                                oper = 'configSizeLayout';
                                itemModels = {
                                    size1: [],
                                    size2: [],
                                    module: getModuleCodeFromSpanSelect()
                                };
                                itemModels.size1.push($('#th2luoi1').val());
                                itemModels.size1.push($('#th2luoi2').val());
                                itemModels.size1.push($('#th2luoi3').val());

                                itemModels.size2.push($('#th3luoi1').val());
                                itemModels.size2.push($('#th3luoi2').val());
                                itemModels.size2.push($('#th3luoi3').val());
                            }

                            $('.nhan-loi').remove();
                            $('#dlg_gridSmall').prepend(`<div class="nhan_loading0"></div>`);
                            let thisSav = this;
                            $.post(`Controller/PublicFunction/ChangePrintMethod.ashx?oper=${oper}`, 
                            { 
                                itemModels: JSON.stringify(itemModels), 
                                grid: ma_md_select, 
                                type: type 
                            }, function(rs) {
                                $('.nhan_loading0').remove();
                                let ok = true;
                                if(type == 4) {
                                    layoutSize = JSON.parse(rs);       
                                }
                                else if(rs.length > 0) {
                                    ok = false;
                                    $('#dlg_gridSmall').prepend(`<div class="nhan-loi">${rs}</div>`);
                                }
                                
                                if(ok) {
                                    $(thisSav).dialog("destroy").remove();
                                    $('.module_spanselect').click();
                                }
                            });
                        }
                    },
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
        let chuyenCachInBTSangPDF = <%=tk.chuyenCachInBTSangPDF.GetValueOrDefault(false).ToString().ToLower() %>;
        let tuDongNhanDienCachIn = <%=tk.tuDongNhanDienCachIn.GetValueOrDefault(false).ToString().ToLower() %>;
        let btnDongMenuTuDong = <%=tk.btnDongMenuTuDong.GetValueOrDefault(false).ToString().ToLower() %>;
        let btnDongMenuConTuDong = <%=tk.btnDongMenuConTuDong.GetValueOrDefault(false).ToString().ToLower() %>;
        let mauBackgroundDF = '<%=tk.mauBackground %>';
        load_doimau_client(mauBackgroundDF);
        let ma_tk = '<%=tk.ma_user %>';
        let ma_nhanvien = '<%=tk.ma_nhanvien %>';
        let hoten_nv = '<%=string.IsNullOrWhiteSpace(tk.ma_nhanvien) ? "" : tk.hoten %>';
        let hoten_tk = '<%=tk.hoten %>';
		let ma_role = '<%=tk.ma_role %>';
        let ten_role = '<%=tk.ten_role %>';
        let ma_phongban = '<%=tk.ma_phongban %>';
        let ten_phongban = '<%=tk.ten_phongban %>';
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
        let divDisplayMenuConfig = $('div.displayMenuConfig'); 
		$.jqm.params.closeoverlay = false;
		$.jgrid.no_legacy_api = true; 
		$.jgrid.useJSON = true; 
		
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

        function getHTMLSelectSoThapPhan(selected, id) 
        {
            selected = selected == null ? 5 : selected;

            let html = `
                <select id="sothapphan" class="FormElement">
                    <option value="0">Không lấy số thập phân</option>
                    <option value="1">Lấy 1 số thập phân</option>
                    <option value="2">Lấy 2 số thập phân</option>
                    <option value="3">Lấy 3 số thập phân</option>
                    <option value="4">Lấy 4 số thập phân</option>
                    <option value="5">Lấy số thập phân tự động</option>
                </select>
            `;

            html = html.replace('<option value="'+ selected +'">', '<option selected value="'+ selected +'">');

            if(id != null)
                $(id).html(html).children().unwrap();

            return html;
        }

        function getHTMLSelectKieuIn(selected, id) 
        {
            selected = selected == null ? 0 : selected;

            let html = `
                <select id="kieuInBaoCao" class="FormElement">
                    <option value="0">In thông qua Browser</option>
                    <option value="1">In thông qua PDF (Mẫu Browser)</option>
                    <option value="2">In thông qua Excel</option>
                    <option value="3">In thông qua PDF (Mẫu Excel)</option>
                    <option value="4">In thông qua Word</option>
                    <option value="5">In thông qua PDF (Mẫu Word)</option>
                </select>
            `;

            if(chuyenCachInBTSangPDF)
                selected = selected == 0 ? 1 : selected;

            html = html.replace('<option value="'+ selected +'">', '<option selected value="'+ selected +'">');

            if(id != null)
                $(id).html(html).children().unwrap();

            return html;
        }

		history.pushState(null,null,""),window.addEventListener("popstate",function(){history.pushState(null,null,"")}),"Firefox"!=Browser&&$(window).bind("beforeunload",function(n){return null==reload_page?'BẠN MUỐN LÀM MỚI LẠI GIAO DIỆN?\n\n >> Nhấn "Reload This Page" để làm mới\n >> Nhấn "Don\'t Reload" để hủy thao tác.':void 0});

        var showMenuMobile = function () {
            if ($('.menu').css('display') == 'none') {
                $('.menu').css('display', '');
            }
            else {
                $('.menu').css('display', 'none');
            }
        }

		window.onresize = function() {
		    click_refreshPage2();
		}; 

		let displayAddEditDelForm = function(editmod, id, type) { 
		    if(!editmod & !id) {
		        return;
		    }

		    let mod = type == 'del' ? 'delmod' : 'editmod';
		    editmod = $(`#${mod}${id}`);

		    let editF = $(`#editmod${id}`), delF = $(`#delmod${id}`);
		    let alert = $(`#alertmod_${id}`);

		    let displayEdit = editF.attr('aria-hidden') == null ? true : (editF.attr('aria-hidden') == "true" ? true : false);
		    let displayDel = delF.attr('aria-hidden') == null ? true : (delF.attr('aria-hidden') == "true" ? true : false);
		    let display = displayEdit & displayDel;

		    let showAlter = alert.attr('aria-hidden') == null ? false : (alert.attr('aria-hidden') == "true" ? false : true);

		    formVisible_Del_id = formVisible_addEdit_id = id;

		    if(display & !showAlter) {
		        type == 'add' ? click_add(id) : (type == 'edit' ? click_edit(id) : click_del(id));
		    }
		    else
		    {
		        if(!displayDel)
		            $('#eData').click();
		        
		        if(!displayEdit)
		            $('#cData').click();

		        if(showAlter) {
		            alert.find('.ui-jqdialog-titlebar-close.ui-corner-all').click();
		        }
		    }
		};

		document.onkeydown = function (e) {
		    e = e || window.event;

		    if (!e.ctrlKey & !e.altKey) return;

		    let code = e.which || e.keyCode;
            if (e.ctrlKey) {
                if (e.shiftKey  && code == 83) {
                    // CTRL+SHIFT+S
                    click_reloadJavascript();
                    return;
                }

		        switch (code) {
		            case 81:
		                e.preventDefault();
		                e.stopPropagation();
		                if ($(e.target).closest('.ui-jqdialog').length > 0) {
		                    $('#cData').click();
		                }

		                if ($(e.target).closest('.ui-dialog.ui-widget.ui-widget-content').length > 0) {
		                    $('#btn-close_').click();
		                }
		                break;
		            case 83:
		                e.preventDefault();
		                e.stopPropagation();
		                if ($(e.target).closest('.ui-jqdialog').length > 0) {
		                    $('#sData').click();
		                }

		                if ($(e.target).closest('.ui-dialog.ui-widget.ui-widget-content').length > 0) {
		                    $('#btn-ok_').click();
		                }
		                break;
		        }
		    }
		    else if(e.altKey) {
                let chk = $(e.target).closest('.ui-tabs-panel.ui-widget-content.ui-corner-bottom');

		        switch (code) {
		            case 65:
		                e.preventDefault();
		                e.stopPropagation();
		                
		                if (chk.length > 0) {
		                    let id = chk.attr('id').replace('tabs_','grid');
		                    displayAddEditDelForm(null, id, 'add');
		                }
		                else {
		                    displayAddEditDelForm(null, formVisible_addEdit_id, 'add');
		                }
                        break;
                    case 81:
		                e.preventDefault();
		                e.stopPropagation();

                        divDisplayMenuConfig.click();
		                break;
		            case 83:
		                e.preventDefault();
		                e.stopPropagation();

		                if (chk.length > 0) {
		                    let id = chk.attr('id').replace('tabs_','grid');
		                    displayAddEditDelForm(null, id, 'edit');
		                }
		                else {
		                    displayAddEditDelForm(null, formVisible_addEdit_id, 'edit');
		                }
		                break;
		            case 68:
		                e.preventDefault();
		                e.stopPropagation();
		                if (chk.length > 0) {
		                    let id = chk.attr('id').replace('tabs_','grid');
		                    displayAddEditDelForm(null, id, 'del');
		                }
		                else {
		                    displayAddEditDelForm(null, formVisible_Del_id, 'del');
		                }
		                break;
		        }
		        return false;
		    }
		};

        divDisplayMenuConfig.click(function () {
            let dlnMN = 'displayNoneMenu';
            let bodyClass = $('#main_body').hasClass(dlnMN);
            if (!bodyClass) {
                divDisplayMenuConfig.addClass('favnn-spin');
                divDisplayMenuConfig.removeClass('favnn-spin-1');

                $('#main_body').addClass(dlnMN);
                $('td.menu').fadeOut(200);
                $('td.menuSpaceModule').fadeOut(200, "linear", function () {
                    $('.div_noidung_menu').css('width', $('.div_module_background').width() - 8);

                    if(typeof tengrid != 'undefined')
                        $(`#${tengrid}`).jqGrid('setGridWidth', $(`#${tengrid}`).parent().parent().parent().parent().parent().width());

                    if(typeof tengrid0 != 'undefined')
                        $(`#${tengrid0}`).jqGrid('setGridWidth', $(`#${tengrid0}`).parent().parent().parent().parent().parent().width());

                    if(typeof tengrid1 != 'undefined')
                        $(`#${tengrid1}`).jqGrid('setGridWidth', $(`#${tengrid1}`).parent().parent().parent().parent().parent().width());

                    if(typeof tengrid2 != 'undefined')
                        $(`#${tengrid2}`).jqGrid('setGridWidth', $(`#${tengrid2}`).parent().parent().parent().parent().parent().width());
                });
            }
            else {
                divDisplayMenuConfig.removeClass('favnn-spin');
                divDisplayMenuConfig.addClass('favnn-spin-1');

                $('#main_body').removeClass(dlnMN);
                $('td.menu').fadeIn(200);
                $('td.menuSpaceModule').fadeIn(200, "linear", function () {
                    $('.div_noidung_menu').css('width', $('.div_module_background').width() - 8);
                    if(typeof tengrid0 != 'undefined')
                        $(`#${tengrid0}`).jqGrid('setGridWidth', $(`#${tengrid0}`).parent().parent().parent().parent().parent().width());

                    if(typeof tengrid1 != 'undefined')
                        $(`#${tengrid1}`).jqGrid('setGridWidth', $(`#${tengrid1}`).parent().parent().parent().parent().parent().width());

                    if(typeof tengrid2 != 'undefined')
                        $(`#${tengrid2}`).jqGrid('setGridWidth', $(`#${tengrid2}`).parent().parent().parent().parent().parent().width());
                });
            }
            
        });

		window.addEventListener('message', function(e) {
		    const data = e.data;

		    if(data.closeIframe) {
		        let divCKeditor = $('.ckeditorPublic');
		        let iframeCKeditor = divCKeditor.children('iframe');
		        iframeCKeditor.removeAttr('src');
		        divCKeditor.addClass('hidden');
		    }

		    if(data.saveVal) {
		        $(data.elem).val(encodeHTML(data.saveVal));
		        $(data.elem).next().next().val(data.files);
            }

            if (data.moveToMenu) {
                let a = 'filter_' + data.ma_module + ' = \'{"groupOp":"AND","rules":[{"field":" ' + data.index + ' ","op":"bw","data":"' + data.sochungtu + '"}]}\'';
                eval(a);
                let b = 'filterVal_' + data.ma_module + ' = "gs_sochungtu(##)' + data.sochungtu + '";';
                eval(b);
                $('#td_' + data.ma_menu).click();
		    }
        });

        function detectMobileOrientation() {
            switch (screen.orientation.angle) {
                case 90:
                    showRoteMobile(screen.orientation.angle);
                    break;
                case 270:
                    showRoteMobile(screen.orientation.angle);
                    break;
                default:
                    showRoteMobile(screen.orientation.angle, true);
                    break;
            }
        }

        var prevMenuMobile = $('.menuMobile').is(":visible");

        var showHideMenuMobile = function () {
            if ($('.menuMobile').is(":visible")) {
                $('.menu').css('display', 'none');
            }
            else {
				if(!isLinkTransfer)
					$('.menu').css('display', '');
            }
        };

        const userAgent = navigator.userAgent.toLowerCase();
        const isTablet = /(ipad|tablet|(android(?!.*mobile))|(windows(?!.*phone)(.*touch))|kindle|playbook|silk|(puffin(?!.*(IP|AP|WP))))/.test(userAgent);
        const isMobile = /iphone|ipod|android/i.test(userAgent);
        var showRoteMobile = function (angle, hide) {
            if (hide) {
                if (isTablet) {
                    $('#divRoteMobile').html('Vui lòng xoay thiết bị theo hướng ngang');
                    $('#divRoteMobile').show();
                }
                else {
                    $('#divRoteMobile').hide();
                    click_refreshPage2();
                }
            }
            else {
                if (isMobile) {
                    $('#divRoteMobile').html('Vui lòng xoay thiết bị theo hướng dọc');
                    $('#divRoteMobile').show();
                }
                else {
                     $('#divRoteMobile').hide();
                    click_refreshPage2();
                }
            }
        };

        showHideMenuMobile();

        window.addEventListener("orientationchange", detectMobileOrientation);

        detectMobileOrientation();
    </script>
</body>
</html>



