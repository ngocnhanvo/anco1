//Add function at here (don't remove this line, please)

//start CA_01_InPhieuVatTu
function CA_01_InPhieuVatTu(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }

	var CLform_infor = new get_Forminfor(ma_case, Form_infor);
	var ma_module = tengrid.replace('grid','');
	$('body').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
		'<div class="dlg_content">'+
			'<div class="err_MD_00_KHMHHVT"></div>'+			
			'<table id="gridMD_00_KHMHHVT_cp"></table>' +
			'<div id="pagergridMD_00_KHMHHVT_cp"></div>' +
		'</div>' +
	'</div>');
	var input_focus = '';
	$('#dlg_gridSmall').dialog({
		modal: true,
		width: CLform_infor.dodai,
		height: CLform_infor.docao,
		open: function (event, ui) {
			jQuery('#gridMD_00_KHMHHVT_cp').jqGrid({
				url: 'Controller/JqGrid/JQGridMD_01_TongVatTuLoad.ashx?ma_module=MD_01_TongVatTu&ma_menu=MN_01_TongVatTu&module_select=1&id_sel=1',
				editurl: '',
				height: 300,
				width: 680,
				datatype: 'json',
				shrinkToFit: true,
				rownumbers: true,
				viewrecords: true,
				search: true,
				scroll:false,
				rowNum: 50,
				multiselect: false,
				multiboxonly: false,
				rowList: [1000],
				pager: '#pagergridMD_00_KHMHHVT_cp',
				onSelectRow: function (ids) {
				},
				colModel: [
					{key:true,fixed:true,label:'md_dondathangphanxuong_vattu_id',name:'md_dondathangphanxuong_vattu_id',index:' ddhpx_vt.md_dondathangphanxuong_vattu_id ',width:120,editable:false,hidden:true,align:'left',searchoptions:{sopt:['bw']},editoptions:{maxLength:32},formoptions:{label:'md_dondathangphanxuong_vattu_id'}},
					{key:false,fixed:true,label:'md_dondathangphanxuong_id',name:'md_dondathangphanxuong_id',index:' ddhpx_vt.md_dondathangphanxuong_id ',width:120,editable:false,hidden:true,align:'left',searchoptions:{sopt:['bw']},editoptions:{maxLength:32},frozen:false,formoptions:{label:'md_dondathangphanxuong_id'}},
					{key:false,fixed:true,label:'Mã Sản Phẩm',name:'md_sanpham_id',index:'sp.ma_sanpham',width:120,editable:false, editrules:{ edithidden: true }, hidden:false,align:'left',searchoptions:{sopt:['bw']},editoptions:{maxLength:32},frozen:false,formoptions:{label:'Mã Sản Phẩm'}},
					{key:false,fixed:true,label:'Vật tư',name:'mota_tiengviet',index:' ddhpx_vt.mota_tiengviet ',width:120,editable:false, editrules:{ edithidden: true }, hidden:false,align:'left',searchoptions:{sopt:['bw']},editoptions:{maxLength:255},frozen:false,formoptions:{label:'Vật tư'}},
					{key:false,fixed:true,label:'Tổng SL',name:'soluong',index:' ddhpx_vt.soluong ',width:100,editable:false, editrules:{ edithidden: true }, hidden:false,formatter:vnn_number,unformat: disable_formatter, align:'right',searchoptions:{sopt:['en'], dataInit: function (elem) { search_number(elem); }},editoptions:{dataInit: function (elem) { format_number(elem, 0, 4); }},frozen:false,formatoptions:{decimalSeparator:vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix:''},formoptions:{label:'Tổng SL'}},
					{key:false,fixed:true,label:'SL đã xuất',name:'sl_hanngach',index:'ddhpx_vt.sl_hanngach',width:100,editable:false, editrules:{ edithidden: true }, hidden:false,formatter:vnn_number,unformat: disable_formatter, align:'right',searchoptions:{sopt:['bw'], dataInit: function (elem) { search_number(elem); }},editoptions:{dataInit: function (elem) { format_number(elem, 0, 4); }},frozen:false,formatoptions:{decimalSeparator:vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix:''},formoptions:{label:'SL đã xuất'}},
					{key:false,fixed:true,label:'SL còn lại',name:'sl_conlai',width:100,editable:true, editrules:{ edithidden: true }, hidden:false,formatter:vnn_number,unformat: disable_formatter, align:'right',searchoptions:{sopt:['bw']},editoptions:{dataInit: function (elem) { format_number(elem, 0, 4); }},frozen:false,formatoptions:{decimalSeparator:vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix:''},formoptions:{label:'SL còn lại'}},
					{key:false,fixed:true,label:'Đơn vị đo',name:'md_donvitinhsanpham_id',index:'dvt.ten_dvt',width:90,editable:false, editrules:{ edithidden: true }, hidden:false,align:'center',searchoptions:{sopt:['bw']},editoptions:{maxLength:32},frozen:false,formoptions:{label:'Đơn vị đo'}},
				],
				beforeRequest: function() {
					$('#gridMD_00_KHMHHVT_cp').jqGrid('getGridParam', 'postData').id = masterId; 
					input_focus = $('input:focus').attr('class');
				},
				ondblClickRow: function(){
					$('#dlg_gridSmal_2').dialog('destroy').remove();
				},
				gridComplete: function () {
					//$(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
				},
				loadComplete: function (data) {
					var ids = jQuery("#gridMD_00_KHMHHVT_cp").jqGrid('getDataIDs');
					for(var i=0;i < ids.length;i++){
						jQuery('#gridMD_00_KHMHHVT_cp').editRow(ids[i]);
					}
					//giữ focus end
					$('.'+input_focus).focus();
				},
				caption: ' '
			});
                Logo_Center(CLform_infor.logo, CLform_infor.canhgiua);
            },
            close: function () {
                $(this).dialog('destroy').remove();
            },
            buttons: [
            {
                id: 'btn-ok',
                text: 'In',
                click: function () {					
					var ids_sel = jQuery("#gridMD_00_KHMHHVT_cp").jqGrid('getDataIDs');
					var arr_sl = '', arr_masp='', arr_dvt='';
					for(var i=0;i < ids_sel.length;i++){
						arr_sl += getCellValue(ids_sel[i], 'sl_conlai') + ',';
						//--
						cell = jQuery("#gridMD_00_KHMHHVT_cp").getRowData(ids_sel[i]);
						arr_masp += cell['md_sanpham_id'] + ',';
						arr_dvt += cell['md_donvitinhsanpham_id'] + ',';
					}									
                	
					var url = url_org_sys + 'View/Print/MD_00_Lenhsanxuat/vatTuTheoLSX.aspx?oper=CA_01_InPhieuYeuCau&ma_module=' + 
					ma_module + '&md=' + masterId.toString();
					var strWindowFeatures = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes";
					var left = (window.innerWidth - 1024) / 2 - 10;
					var mapForm = document.createElement("form");
						
                    mapForm.target = "_blank";
                    mapForm.method = "POST"; // or "post" if appropriate
                    mapForm.action = url;

                    var mapInput = document.createElement("input");
                    mapInput.type = "hidden";
                    mapInput.name = "ma_sanpham";
                    mapInput.value = arr_masp;
                    mapForm.appendChild(mapInput);

                    mapInput = document.createElement("input");
                    mapInput.type = "hidden";
                    mapInput.name = "sl_conlai";
                    mapInput.value = arr_sl;
                    mapForm.appendChild(mapInput);
					
					mapInput = document.createElement("input");
                    mapInput.type = "hidden";
                    mapInput.name = "dvt";
                    mapInput.value = arr_dvt;
                    mapForm.appendChild(mapInput);
					
                    document.body.appendChild(mapForm);
                    mapForm.submit();
                    mapForm.remove();
                }
            },
            {
                id: 'btn-close',
                text: 'Thoát',
                click: function () {
                    $(this).dialog('destroy').remove();
                }
            }
            ]
        });
    }
//end CA_01_InPhieuVatTu


//start CA_01_TaoPhieuXuatVattuTong
function CA_01_TaoPhieuXuatVattuTong(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selarrrow'); }
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid','');
        $('body').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
            '<div class="dlg_content">Thực hiện chức năng này?</div>' +
        '</div>');
        $('#dlg_gridSmall').dialog({
            modal: true,
            width: CLform_infor.dodai,
            height: CLform_infor.docao,
            open: function (event, ui) {
                Logo_Center(CLform_infor.logo, CLform_infor.canhgiua);
            },
            close: function () {
                $(this).dialog('destroy').remove();
            },
            buttons: [
            {
                id: 'btn-ok',
                text: 'Đồng ý',
                click: function () {
                	  $('#btn-ok').button('option', 'disabled', true);
                	  $('.dlg_content').prepend('<div class="nhan_loading"></div>');
                    $.post('Controller/JQGridModify/JQGridMD_00_LenhsanxuatModify.ashx?oper=CA_01_TaoPhieuXuatVattuTong&ma_module=' + ma_module,
                    { id:masterId.toString() }, function (result) {
                        $('#btn-ok').button('option', 'disabled', false);
                        $('.dlg_content').html(result);
                        loadclick(tengrid, 'edit', load_stt);
						$("#"+tengrid2)[0].triggerToolbar();
                        Close_Form($('#dlg_gridSmall'), CLform_infor.dongform);
                    });
                }
            },
            {
                id: 'btn-close',
                text: 'Thoát',
                click: function () {
                    $(this).dialog('destroy').remove();
                }
            }
            ]
        });
    }
}
//end CA_01_TaoPhieuXuatVattuTong


//start CA_01_TinhTongVattu
function CA_01_TinhTongVattu(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    let masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selarrrow'); }
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid','');
        $('body').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
            '<div class="dlg_content">Thực hiện chức năng này?</div>' +
        '</div>');
        $('#dlg_gridSmall').dialog({
            modal: true,
            width: CLform_infor.dodai,
            height: CLform_infor.docao,
            open: function (event, ui) {
                Logo_Center(CLform_infor.logo, CLform_infor.canhgiua);
            },
            close: function () {
                $(this).dialog('destroy').remove();
            },
            buttons: [
            {
                id: 'btn-ok',
                text: 'Đồng ý',
                click: function () {
                	  $('#btn-ok').button('option', 'disabled', true);
                	  $('.dlg_content').prepend('<div class="nhan_loading"></div>');
                    $.post('Controller/JQGridModify/JQGridMD_00_LenhsanxuatModify.ashx?oper=CA_01_TinhTongVattu&ma_module=' + ma_module,
                    { id:masterId.toString() }, function (result) {
                        $('#btn-ok').button('option', 'disabled', false);
                        $('.dlg_content').html(result);
                        loadclick(tengrid, 'edit', load_stt);
						$("#"+tengrid2)[0].triggerToolbar();
                        Close_Form($('#dlg_gridSmall'), CLform_infor.dongform);
                    });
                }
            },
            {
                id: 'btn-close',
                text: 'Thoát',
                click: function () {
                    $(this).dialog('destroy').remove();
                }
            }
            ]
        });
    }
}
//end CA_01_TinhTongVattu


//start CA_01_Taophieuxuatkho
function CA_01_Taophieuxuatkho(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    let masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selarrrow'); }
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid', '');
        $('body').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
            '<div class="dlg_content">Thực hiện chức năng này?</div>' +
        '</div>');
        $('#dlg_gridSmall').dialog({
            modal: true,
            width: CLform_infor.dodai,
            height: CLform_infor.docao,
            open: function (event, ui) {
                Logo_Center(CLform_infor.logo, CLform_infor.canhgiua);
            },
            close: function () {
                $(this).dialog('destroy').remove();
            },
            buttons: [
            {
                id: 'btn-ok',
                text: 'Đồng ý',
                click: function () {
                    $('#btn-ok').button('option', 'disabled', true);
                    $('.dlg_content').prepend('<div class="nhan_loading"></div>');
                    $.post('Controller/JQGridModify/JQGridMD_00_LenhsanxuatModify.ashx?oper=CA_01_Taophieuxuatkho&ma_module=' + ma_module,
                    { id: masterId.toString() }, function (result) {
                        $('#btn-ok').button('option', 'disabled', false);
                        $('.dlg_content').html(result);
                        loadclick(tengrid, 'edit', load_stt);
                        $("#" + tengrid2)[0].triggerToolbar();
                        Close_Form($('#dlg_gridSmall'), CLform_infor.dongform);
                    });
                }
            },
            {
                id: 'btn-close',
                text: 'Thoát',
                click: function () {
                    $(this).dialog('destroy').remove();
                }
            }
            ]
        });
    }
}
//end CA_01_Taophieuxuatkho

