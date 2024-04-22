//Add function at here (don't remove this line, please)

//start CA_01_THemmoiDMHHVT
function CA_01_THemmoiDMHHVT(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selarrrow'); }

    var CLform_infor = new get_Forminfor(ma_case, Form_infor);
    var ma_module = tengrid.replace('grid', '');
    $('body').append(`
    <div id="dlg_gridSmall" title="${CLform_infor.tieude}">
		<div class="dlg_content">
			<div class="err_MD_00_KHMHHVT"></div>
			<div style="padding: 1px 0 8px 0;">
                <table>
                    <tr>
                        <td style="text-align: right;">Chọn KHMVT: </td>
                        <td>
                            <select style="width:350px" data-placeholder="Chọn 1 KHMVT.." class="sel_loadkhmvt"><option value="1">Đang tải...</option></select>
                        </td>
                    </tr>
                    <tr>
                        <td  style="text-align: right;">
                            <input type="button" value="Chọn" id="btnSLMbangSLCM" />
                        </td>
                        <td>
                            <label for="btnSLMbangSLCM">Số lượng mua = Số lượng cần mua</label>
                        </td>
                    </tr>
                </table>
            </div>
			<table id="gridMD_00_KHMHHVT_cp"></table>
			<div id="pagergridMD_00_KHMHHVT_cp"></div>
		</div>
	</div>`);
    var input_focus = '';
    $('#dlg_gridSmall').dialog({
        modal: true,
        width: 800,
        height: 550,
        open: function (event, ui) {
            $('#btnSLMbangSLCM').off('click');
            $('#btnSLMbangSLCM').click(function () {
                var ids = $("#gridMD_00_KHMHHVT_cp").jqGrid('getDataIDs');
                for (let i = 0; i < ids.length; i++) {
                    let rowId = ids[i];
                    let rowData = $('#gridMD_00_KHMHHVT_cp').jqGrid('getRowData', rowId);
                    $(`#${rowId}_sl_semua`).val(rowData["sl_canmua"]);
                }
            });
            $.get('Controller/JqGridModify/JQGridMD_00_KHMVTModify.ashx?oper=load_khmvt', function (result) {
                let json = JSON.parse(result);
                let donvitinh = json['donvitinh'].replace('value:', '');
                donvitinh = donvitinh.replace(/\\'/g, "'").replace(/'/g, '"');
                donvitinh = JSON.parse(donvitinh);
                $('.sel_loadkhmvt').html(json['khmvt']);

                $('.sel_loadkhmvt').change(function () {
                    $('#gridMD_00_KHMHHVT_cp').trigger("reloadGrid");
                });
                var config = {
                    '.sel_loadkhmvt': { search_contains: true, allow_single_deselect: true }
                }
                for (var selector in config) {
                    $(selector).chosen(config[selector]);
                }

                jQuery('#gridMD_00_KHMHHVT_cp').jqGrid({
                    url: 'Controller/JqGrid/JQGridMD_01_CDKHVattuLoad.ashx?ma_module=MD_01_CDKHVattu&ma_menu=MN_01_KHMVT&module_select=1&id_sel=1',
                    editurl: '',
                    height: 315,
                    width: 772,
                    datatype: 'json',
                    shrinkToFit: true,
                    rownumbers: true,
                    viewrecords: true,
                    search: true,
                    scroll: false,
                    rowNum: 1000,
                    multiselect: false,
                    multiboxonly: false,
                    rowList: [1000],
                    pager: '#pagergridMD_00_KHMHHVT_cp',
                    onSelectRow: function (ids) {
                    },
                    colModel: [
                        { key: true, fixed: true, label: 'c_kehoachmuavt_cdh_id', name: 'c_kehoachmuavt_cdh_id', index: ' khmvt_cdh.c_kehoachmuavt_cdh_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, formoptions: { label: 'c_kehoachmuavt_cdh_id' } },
                        { key: false, fixed: true, label: 'c_kehoachmuavt_id', name: 'c_kehoachmuavt_id', index: ' khmvt_cdh.c_kehoachmuavt_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'c_kehoachmuavt_id' } },
                        { key: false, fixed: true, label: 'Mã HHVT', name: 'md_sanpham_id', index: ' sp.ma_sanpham', width: 100, editable: false, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Mã HHVT' } },
                        { key: false, fixed: true, label: 'Id HHVT', name: 'sanpham_id', index: ' sp.md_sanpham_id', width: 100, editable: false, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Id HHVT' } },
                        { key: false, fixed: true, label: 'Mô tả tiếng việt', name: 'mota_tiengviet', index: 'sp.mota_tiengviet', width: 120, editable: false, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'Mô tả tiếng việt' } },
                        { key: false, fixed: true, label: 'SL cần mua', name: 'sl_canmua', index: '', width: 95, editable: false, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'right', searchoptions: { sopt: ['en'], dataInit: function (elem) { search_number(elem); } }, editoptions: { dataInit: function (elem) { format_number(elem, 0, 4); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: 'SL cần' } },
                        { key: false, fixed: true, label: 'Đơn vị tính', name: 'md_donvitinhsanpham_id2', index: 'dvt_sp.ten_dvt', width: 80, editable: false, editrules: { edithidden: true }, hidden: false, align: 'center', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'Đơn vị tính' } },
                        { key: false, fixed: true, label: 'SL mua', name: 'sl_semua', index: '', width: 95, editable: true, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'right', searchoptions: { sopt: ['bw'], dataInit: function (elem) { search_number(elem); } }, editoptions: { dataInit: function (elem) { format_numeric($(elem), 5); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: 'SL mua' } },
                        { key: false, fixed: true, label: 'Đơn vị tính', name: 'md_donvitinhsanpham_id', index: 'dvt_sp.ten_dvt', width: 80, editable: true, editrules: { edithidden: true }, hidden: false, align: 'center', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'Đơn vị tính' }, edittype: 'select', editoptions: { value: donvitinh, disabled: true } },
                        { key: false, fixed: true, label: 'Nhà cung ứng', name: 'md_doitackinhdoanh_id', index: 'dtkd.ma_dtkd', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { dataInit: function (elem) { format_dtkdHHVT(elem); $(elem).css('padding', '3px 20px 3px 0px'); } }, frozen: false, formoptions: { label: 'Nhà cung ứng' } },
                    ],
                    beforeRequest: function () {
                        $('#gridMD_00_KHMHHVT_cp').jqGrid('getGridParam', 'postData').id = $('.sel_loadkhmvt').val();
                        $('#gridMD_00_KHMHHVT_cp').jqGrid('getGridParam', 'postData').where_ex = " and (khmvt_cdh.sl_duyet2 - khmvt_cdh.sl_conlai) > 0 ";
                        //$('#gridMD_00_KHMHHVT_cp').jqGrid('getGridParam', 'postData').where_ex = " and ('@ad_user_id' in (select ad_user_id from md_chungloai_ql where md_chungloai_id = sp.md_chungloai_id) or sp.md_chungloai_id is null) ";
                        input_focus = $('input:focus').attr('class');
                    },
                    ondblClickRow: function () {
                        $('#dlg_gridSmal_2').dialog('destroy').remove();
                    },
                    gridComplete: function () {
                        //$(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
                    },
                    loadComplete: function (data) {
                        var ids = $("#gridMD_00_KHMHHVT_cp").jqGrid('getDataIDs');
                        for (var i = 0; i < ids.length; i++) {
                            $('#gridMD_00_KHMHHVT_cp').editRow(ids[i]);
                            $('#' + ids[i] + '_sl_semua').css({ 'text-align': 'right' });
                            $('#' + ids[i] + '_sl_semua').attr('autocomplete', 'off');
                        }
                        //giữ focus end
                        $('.' + input_focus).focus();
                    },
                    caption: ' '
                });
            });
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
                    if ($('.sel_loadkhmvt').val() != '1') {
                        var ids_sel = jQuery("#gridMD_00_KHMHHVT_cp").jqGrid('getDataIDs');
                        var arr_sl = '', arr_ncc = '', arr_id = '', arr_dvt = '';
                        for (var i = 0; i < ids_sel.length; i++) {
                            arr_sl += $('#' + ids_sel[i] + '_sl_semua')[0].val2() + ',';
                            //--
                            arr_ncc += getCellValue(ids_sel[i], 'md_doitackinhdoanh_id') + ',';
                            //--
                            arr_dvt += getCellValue(ids_sel[i], 'md_donvitinhsanpham_id') + ',';
                            //--
                            arr_id += ids_sel[i] + ',';
                        }
                        $('#btn-ok').button('option', 'disabled', true);
                        $('.err_MD_00_KHMHHVT').html('<div class="nhan_loading"></div>');
                        $.post('Controller/JQGridModify/JQGridMD_00_KHMVTModify.ashx?oper=CA_01_Taodomuavattu&ma_module=' + ma_module,
                            {
                                id: $('.sel_loadkhmvt').val(),
                                arr_sl: arr_sl,
                                arr_dvt: arr_dvt,
                                arr_ncc: arr_ncc,
                                arr_id: arr_id
                            }, function (result) {
                                $('#btn-ok').button('option', 'disabled', false);
                                $('.err_MD_00_KHMHHVT').html(result);
                                if (result.lastIndexOf('Lỗi') <= -1) {
                                    loadclick(tengrid, 'edit', load_stt);
                                    Close_Form($('#dlg_gridSmall'), CLform_infor.dongform);
                                }
                            });
                    }
                    else {
                        alert('Phải chọn 1 kế hoạch mua vật tư.');
                    }
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
//end CA_01_THemmoiDMHHVT


//start CA_01_KetThucDonMuHang
function CA_01_KetThucDonMuHang(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
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
                        $.post('Controller/JQGridModify/JQGridMD_00_DonMuaHangModify.ashx?oper=CA_01_KetThucDonMuHang&ma_module=' + ma_module,
                            { id: masterId.toString() }, function (result) {
                                $('#btn-ok').button('option', 'disabled', false);
                                $('.dlg_content').html(result);
                                loadclick(tengrid, 'edit', load_stt);
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
//end CA_01_KetThucDonMuHang


//start CA_01_InPXNNKNCC
function CA_01_InPXNNKNCC(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid', '');
        $('body').append(`<div id="dlg_gridSmall" title="${CLform_infor.tieude}">
            <div class="dlg_content">
				<table>
					<tr>
						<td><input type="radio" checked name="rdo_SLVC" class="rdo_SLVC" style="outline:none" value="KHO VẬT TƯ"/></td>
						<td> In phiếu xác nhận nhập kho VT</td>
					</tr>

					<tr>
						<td><input type="radio" name="rdo_SLVC" class="rdo_SLVC"  style="outline:none" value="KHO TỒN THÀNH PHẨM"/></td>
						<td> In phiếu xác nhận nhập kho TP</td>
					</tr>

                    <tr>
                        <td colspan="2">
                            <p class ="pTitlePublic">Chọn cách hiển thị số thập phân</p>
                            ${getHTMLSelectSoThapPhan()}
                        </td>
                    </tr>

                    <tr style="height: 30px;">
                        <td colspan=2>
                            <p class ="pTitlePublic">Chọn cách in</p>
                            ${getHTMLSelectKieuIn(0)}
                        </td>
                    </tr>
				</table>
			<div>
        </div>`);
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
                        let inPDF = $("#inPDF").prop('checked') ? "1" : "";
                        let sothapphan = $('#sothapphan').val();
                        let url = url_org_sys + "View/Print/MD_00_NhapkhotuNCC/Xacnhannhapkho.aspx?oper=CA_01_InPhieuNhapkho"+
                            "&ma_module=" + ma_module +
                            "&md_nhapkho_ncc_id=" + masterId.toString() +
                            "&inPDF=" + inPDF +
                            "&stp=" + sothapphan;
                        let strWindowFeatures = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes";
                        let left = (window.innerWidth - 1024) / 2 - 10;
                        window.open(url, "eMan", "top=100, left=" + left + ", width=1024, height=500");
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
//end CA_01_InPXNNKNCC


//start CA_01_TPNKMG2
function CA_01_TPNKMG2(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid', '');
        $('body').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
            '<div class="dlg_content">Tạo phiếu nhập kho từ đơn mua hàng này.?</div>' +
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
                        $.post('Controller/JQGridModify/JQGridMD_00_DonMuaHangModify.ashx?oper=CA_01_TPNKMG2&ma_module=' + ma_module,
                            { id: masterId.toString() }, function (result) {
                                $('#btn-ok').button('option', 'disabled', false);
                                $('.dlg_content').html(result);
                                loadclick(tengrid, 'edit', load_stt);
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
//end CA_01_TPNKMG2


//start CA_01_donMuaHangHoaVatTu
function CA_01_donMuaHangHoaVatTu(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    id_parent = null;
    var masterId = id_parent, cell = null;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
    cell = $('#' + tengrid).getRowData(masterId);
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    //else if (masterId.length > 1) {
    //    alert('Chỉ có thể in 1 đơn mua.');
    //}
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid', '');
        $('body').append(`<div id="dlg_gridSmall" title="${CLform_infor.tieude}">
            <div class="dlg_content">
				<table>
					<tr>
						<td><input type="radio" checked name="rdo_SLVC" class="rdo_SLVC" style="outline:none" value="KHO VẬT TƯ"/></td>
						<td> In đơn mua hàng</td>
					</tr>

					<tr>
						<td><input type="radio" name="rdo_SLVC" class="rdo_SLVC"  style="outline:none" value="KHO TỒN THÀNH PHẨM"/></td>
						<td> In đơn mua vật tư</td>
					</tr>

                    <tr>
                        <td colspan="2">
                            <p class ="pTitlePublic">Hiển thị số thập phân</p>
                            ${getHTMLSelectSoThapPhan()}
                        </td>
                    </tr>

                    <tr style="height: 30px;">
                        <td colspan=2>
                            <p class ="pTitlePublic">Chọn cách in</p>
                            ${getHTMLSelectKieuIn(0)}
                        </td>
                    </tr>
				</table>
			<div>
        </div>`);
        $('#dlg_gridSmall').dialog({
            modal: true,
            width: CLform_infor.dodai,
            height: CLform_infor.docao,
            open: function (event, ui) {
                $('.rdo_SLVC').click();
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
                        let sothapphan = $('#sothapphan').val();
                        let sel_val = $("input:radio[name=rdo_SLVC]:checked").val();
                        let CLform_infor = new get_Forminfor(ma_case, Form_infor);
                        let ma_module = tengrid.replace('grid', '');
                        let inPDF = $("#kieuInBaoCao").val();
                        if (sel_val == 1) {
                            let url = url_org_sys + "View/Print/MD_00_DonMuaHang/?oper=CA_01_donMuaHangHoaVatTu"+
                                "&ma_module=" + ma_module +
                                "&id=" + masterId +
                                "&inPDF=" + inPDF +
                                "&stp=" + sothapphan;
                            let strWindowFeatures = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes";
                            let left = (window.innerWidth - 1024) / 2 - 10;
                            window.open(url, "eMan", "top=100, left=" + left + ", width=1024, height=500");
                        }
                        else {
                            let url = url_org_sys + "View/Print/MD_00_DonMuaHang/?oper=CA_01_donMuaHangHoaVatTu"+
                                "&ma_module=" + ma_module +
                                "&id=" + masterId +
                                "&inPDF=" + inPDF +
                                "&stp=" + sothapphan;
                            let strWindowFeatures = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes";
                            let left = (window.innerWidth - 1024) / 2 - 10;
                            window.open(url, "eMan", "top=100, left=" + left + ", width=1024, height=500");
                        }
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
//end CA_01_donMuaHangHoaVatTu


//start CA_01_TPNKMG
function CA_01_TPNKMG(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent, cell = null;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
    cell = $('#' + tengrid).getRowData(masterId);
    if (masterId == null) {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    else if (cell['md_trangthai_id'] != 'HIEULUC') {
        alert('Chỉ có thể thao tác với đơn mua hàng có trạng thái \"Hiệu lực\".');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid', '');
        $('body').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
            '<div class="dlg_content"><div class="nhan_loading">&nbsp;</div></div>' +
            '</div>');
        $('#dlg_gridSmall').dialog({
            modal: true,
            width: CLform_infor.dodai,
            height: CLform_infor.docao,
            open: function (event, ui) {
                $.get('Controller/JQGridModify/JQGridMD_00_DonMuaHangModify.ashx?oper=load_donghang&id=' + masterId, function (result) {
                    $('.dlg_content').html(result);
                    format_number($('.input_soluong'), 0, 4);
                    var dem_chk = 0, sl_toida = $('.chk_tosx').length - $('.chk_tosx.nhan_disable').length;
                    $('.chk_tosx').change(function () {
                        var input = '.input_' + $(this).val();
                        if ($(this).prop('checked') == true) {
                            $(input).removeAttr('disabled').removeClass('nhan_disable');
                            dem_chk++;
                            if (dem_chk >= sl_toida) {
                                $('.chk_tosx_all').prop('checked', true);
                            }
                        }
                        else {
                            dem_chk--;
                            $('.chk_tosx_all').prop('checked', false);
                            $(input).addClass('nhan_disable').attr('disabled', 'disabled');
                        }
                    });

                    $('.chk_tosx_all').change(function () {
                        if ($(this).prop('checked') == true) {
                            $('.chk_tosx').each(function () {
                                if (!$(this).hasClass('nhan_disable')) {
                                    $(this).prop('checked', true);
                                    $('.input_' + $(this).val()).removeAttr('disabled').removeClass('nhan_disable');;
                                }
                            });
                            dem_chk = sl_toida;
                        }
                        else {
                            $('.chk_tosx').prop('checked', false);
                            $('.input_soluong').addClass('nhan_disable').attr('disabled', 'disabled');
                            dem_chk = 0;
                        }
                    });
                });
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
                        var id_sel = '', value_sl = '';
                        $('.chk_tosx').each(function (index, val) {
                            if ($(this).prop('checked') == true) {
                                id_sel += $(this).val() + ',';
                                value_sl += $('.input_' + $(this).val()).val() + ',';
                            }
                        });
                        $.post('Controller/JQGridModify/JQGridMD_00_DonMuaHangModify.ashx?oper=CA_01_TPNKMG&ma_module=' + ma_module,
                            { id: masterId.toString(), id_sel: id_sel, value_sl: value_sl }, function (result) {
                                if (result.indexOf('div') > -1) {
                                    $('.dlg_content').html(result);
                                    loadclick(tengrid, 'edit', load_stt);
                                    Close_Form($('#dlg_gridSmall'), CLform_infor.dongform);
                                }
                                else {
                                    $('#btn-ok').button('option', 'disabled', false);
                                    $('.nhan_loading').remove();
                                    alert(result);
                                }
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
//end CA_01_TPNKMG

function getCellValue(rowId, cellId) {
    var cell = $('#' + rowId + '_' + cellId);
    var val = cell.val();
    return val;
}