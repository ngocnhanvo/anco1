<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>
<%var version = 6; %>
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
    <link href="css/VNN_css/Default.css?ver=<%=version %>" rel="stylesheet" type="text/css" />
    <link href="css/VNN_css/Menu.css?ver=<%=version %>" rel="stylesheet" type="text/css" />
    <link href="css/VNN_css/Content.css?ver=<%=version %>" rel="stylesheet" type="text/css" />
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
    <!-- Script Jqx Widgets -->
    <script src="js/jqxwidgets/jqxcore.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxbuttons.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxscrollbar.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxlistbox.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxdragdrop.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxtree.js" type="text/javascript"></script>
    <script async src="js/jqxwidgets/jqxcheckbox.js" type="text/javascript"></script>
    <!--/ layout -->
    <!--Script Module-->
    <%=kq_script[0]%>
</head>
<body class="main_body" id="main_body">
    <div class="overlay-dark"></div>
    <img alt="" class="img-overlay" />
    <div class="ckeditorPublic hidden">
        <iframe style="width:100%;height:100%" loaded="false"></iframe>
    </div>
    <div id="mainpane">
        <!-- head_page -->
        <table class="nhan_header">
            <tr>
                <td style="width: 10%; min-width: 222px" align="center">
                    <div style="height:30px">
                        <img id="nhan_image" alt="" src="images/logo/emanAnco.png" 
							style="
								height: 24px;
                                padding: 0px;
                                margin-top: 1.3px;
							"
						/>
                    </div>
                </td>
                <td style="width: 12px; min-width: 12px"></td>

                <td style="width: 138px; min-width: 138px">
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 12px;" onclick="click_back()" alt="" title="trở về trang trước" src="images/Menu/header_back2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0" onclick="click_refreshPage(true)" alt="" title="làm mới trang hiện tại" src="images/Menu/header_frefesh2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0;" onclick="click_doimau()" alt="" title="đổi màu" src="images/Menu/header_idea2.png" />
                    <img class="cl_img_btnmenu" style="margin: 0 10px -3px 0;" onclick="loadContent('MN_01_HT1','','Hướng dẫn sử dụng','Trợ Giúp')" alt="" title="giúp đỡ" src="images/Menu/header_ask2.png" />
                </td>
                <td class="cl_td_urlmenu">
                    <div>
                        <span class="cl_span_urlmenu" style="display:none;">URL of clicking events</span>
                    </div>
                </td>
                <td style="width: 1px">
                    <div id="logo_right" onclick="fix_loi_screen()">
                        <img height="0" width="0" style='margin: 0 0 0 0px;' alt="" title="hình ảnh" src="images/logo/logo_esc2.png" />
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
        var heightHeader = $('.nhan_header').height();
        var heightFooter = $('.footer').height();
        var height_menu_noidung = heightBody - (heightHeader + heightFooter) * ratePercentTransform;
        $('.menu').height(height_menu_noidung);

        setTimeout(function () {
            loadMenu('Menu/Menu.htm');
        }, 10);

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
						ondblClickRow: function(e){
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
        let mauBackgroundDF = '<%=tk.mauBackground %>';
        load_doimau_client(mauBackgroundDF);
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
		
		function load_sct(ma_sct) {
			let kq = '';
			<%=get_mauhienthi_sochungtu%>
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
                    <option value="0">In trên trình duyệt</option>
                    <option value="1">In thông qua PDF</option>
                    <option value="2">In thông qua Excel</option>
                    <option value="3">In thông qua PDF (Mẫu Excel)</option>
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
    
		window.onresize = function() {
		    click_refreshPage2();
		}; 

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
		});
    </script>
</body>
</html>



