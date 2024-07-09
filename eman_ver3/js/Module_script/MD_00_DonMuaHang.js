//Add function at here (don't remove this line, please)

//start CA_01_TraVeSoanThaoDMH
function CA_01_TraVeSoanThaoDMH(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    let masterId = $(`#${tengrid}`).jqGrid('getGridParam', 'selrow');

    $(`#${tengrid}`).jqGrid('getGridParam', 'selarrrow').toString();

    let CLform_infor = new get_Forminfor(ma_case, Form_infor);
    let ma_module = tengrid.replace('grid', '');
    $('body').append(`
        <div id="dlg_gridSmall" title="${CLform_infor.tieude}">
		    <div class="dlg_content">Thực hiện chức năng này?</div>
	    </div>
    `);

    let $dlgGrid = $('#dlg_gridSmall');
    let $dlgGridContent = $dlgGrid.find('.dlg_content');
    let dlgW = Number(CLform_infor.dodai);
    $dlgGrid.dialog({
        modal: true,
        width: window.innerWidth >= dlgW + 50 ? dlgW : dlgW - 50,
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
                    $dlgGridContent.prepend('<div class="nhan_loading"></div>');
                    $.post(`Controller/JQGridModify/JQGrid${ma_module}Modify.ashx?oper=${ma_case}&ma_module=${ma_module}`,
                        { id: masterId }, function (result) {
                            $dlgGridContent.html(result);
                            if (result.lastIndexOf('error') <= -1) {
                                $(`#${tengrid}`)[0].triggerToolbar();
                                Close_Form($dlgGrid, CLform_infor.dongform);
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
//end CA_01_TraVeSoanThaoDMH

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
    let masterId = $(`#${tengrid}`).jqGrid('getGridParam', 'selrow');
    let cell = $(`#${tengrid}`).getRowData(masterId);
    if (masterId == null) {
        alert('Chưa chọn đối tượng cần thao tác.');
        return;
    }

    if (cell.md_trangthai_id != 'HIEULUC') {
        alert(`Đơn mua hàng không ở trạng thái "Hiệu lực".`);
        return;
    }

    let CLform_infor = new get_Forminfor(ma_case, Form_infor);
    let ma_module = tengrid.replace('grid', '');
    $('body').append(`
        <div id="dlg_gridSmall" title="${CLform_infor.tieude}">
            <div class="dlg_content">Bạn muốn kết thúc đơn mua hàng này?</div>
        </div>`
    );

    let $dlg_gridSmall = $('#dlg_gridSmall');
    $dlg_gridSmall.dialog({
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
                    $.post(`Controller/JQGridModify/JQGrid${ma_module}Modify.ashx?oper=${ma_case}&ma_module=${ma_module}`,
                        { id: masterId.toString() }, function (result) {
                            $('.dlg_content').html(result);
                            $('.nhan_loading').remove();

                            if (result.indexOf('error') <= -1) {
                                $(`#${tengrid}`)[0].triggerToolbar();
                                Close_Form($dlg_gridSmall, CLform_infor.dongform);
                            }
                            else {
                                $('#btn-ok').button('option', 'disabled', false);
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
                        let url = url_org_sys + "View/Print/MD_00_NhapkhotuNCC/Xacnhannhapkho.aspx?oper=CA_01_InPhieuNhapkho" +
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
    let masterId = $(`#${tengrid}`).jqGrid('getGridParam', 'selrow');
    let cell = $(`#${tengrid}`).getRowData(masterId);
    if (masterId == null) {
        alert('Chưa chọn đối tượng cần thao tác.');
        return;
    }

    if (cell.md_trangthai_id != 'DANHAN') {
        alert(`Đơn mua hàng không ở trạng thái "Đã xác nhận".`);
        return;
    }

    let CLform_infor = new get_Forminfor(ma_case, Form_infor);
    let ma_module = tengrid.replace('grid', '');
    $('body').append(`
        <div id="dlg_gridSmall" title="${CLform_infor.tieude}">
            <div class="dlg_content">Bạn muốn hiệu lực đơn mua hàng này?</div>
        </div>`
    );

    let $dlg_gridSmall = $('#dlg_gridSmall');
    $dlg_gridSmall.dialog({
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
                    $.post(`Controller/JQGridModify/JQGrid${ma_module}Modify.ashx?oper=${ma_case}&ma_module=${ma_module}`,
                        { id: masterId.toString() }, function (result) {
                            $('.dlg_content').html(result);
                            $('.nhan_loading').remove();

                            if (result.indexOf('error') <= -1) {
                                $(`#${tengrid}`)[0].triggerToolbar();
                                Close_Form($dlg_gridSmall, CLform_infor.dongform);
                            }
                            else {
                                $('#btn-ok').button('option', 'disabled', false);
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
//end CA_01_TPNKMG2


//start CA_01_donMuaHangHoaVatTu
function CA_01_donMuaHangHoaVatTu(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    let masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow');
    let cell = $('#' + tengrid).getRowData(masterId);
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
        return;
    }

    let CLform_infor = new get_Forminfor(ma_case, Form_infor);
    let ma_module = tengrid.replace('grid', '');
    let lblStyle = `cursor:pointer;user-select:none;`;
    $('body').append(`
        <div id="dlg_gridSmall" title="${CLform_infor.tieude}">
            <div class="dlg_content">
			    <table>
				    <tr>
					    <td><input id="rdoDMHHVT1" type="radio" name="rdoDMHHVT" style="outline:none" value="1" /></td>
					    <td><label style="${lblStyle}" for="rdoDMHHVT1">In đơn mua hàng hóa vật tư (có giá trị)</label></td>
				    </tr>

                    <tr>
					    <td><input id="rdoDMHHVT2" type="radio" name="rdoDMHHVT" style="outline:none" value="2" /></td>
					    <td><label style="${lblStyle}" for="rdoDMHHVT2">In đơn mua hàng hóa vật tư (không có giá trị)</label></td>
				    </tr>

                    <tr style="height: 30px;">
                        <td colspan=2>
                            <p class ="pTitlePublic">Chọn cách in</p>
                            ${getHTMLSelectKieuIn(0)}
                        </td>
                    </tr>
			    </table>
		    <div>
        </div>`
    );

    $('#dlg_gridSmall').dialog({
        modal: true,
        width: CLform_infor.dodai,
        height: CLform_infor.docao,
        open: function (event, ui) {
            $('#rdoDMHHVT1').click();
            $("#kieuInBaoCao").val(3);

            if (inDMHcoGiaTri) {
                $('#rdoDMHHVT1').click();
            }
            else {
                $('#rdoDMHHVT1').parent().parent().remove();
                $('#rdoDMHHVT2').click();
            }
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
                    let sel_val = $(`input:radio[name="rdoDMHHVT"]:checked`).val();
                    let inPDF = $("#kieuInBaoCao").val();
                    if (sel_val == 1) {
                        url = `${url_org_sys}View/Print/${ma_module}/DMHCoGiaTri.aspx?ma_module=${ma_module}` +
                            "&id=" + masterId +
                            "&inPDF=" + inPDF;
                    }
                    else if (sel_val == 2) {
                        url = `${url_org_sys}View/Print/${ma_module}/DMHKhongGiaTri.aspx?ma_module=${ma_module}` +
                            "&id=" + masterId +
                            "&inPDF=" + inPDF;
                    }

                    openPrintDialog(url, "eMan Anco1", []);
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
//end CA_01_donMuaHangHoaVatTu


//start CA_01_TPNKMG
function CA_01_TPNKMG(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    let masterId = $(`#${tengrid}`).jqGrid('getGridParam', 'selrow');
    let cell = $(`#${tengrid}`).getRowData(masterId);
    if (masterId == null) {
        alert('Chưa chọn đối tượng cần thao tác.');
        return;
    }

    if (cell.md_trangthai_id != 'SOANTHAO') {
        alert(`Đơn mua hàng không ở trạng thái "Soạn Thảo".`);
        return;
    }

    let CLform_infor = new get_Forminfor(ma_case, Form_infor);
    let ma_module = tengrid.replace('grid', '');
    $('body').append(`
        <div id="dlg_gridSmall" title="${CLform_infor.tieude}">
            <div class="dlg_content">Bạn muốn xác nhận đơn mua hàng này?</div>
        </div>`
    );

    let $dlg_gridSmall = $('#dlg_gridSmall');
    $dlg_gridSmall.dialog({
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
                    $.post(`Controller/JQGridModify/JQGrid${ma_module}Modify.ashx?oper=${ma_case}&ma_module=${ma_module}`,
                        { id: masterId.toString() }, function (result) {
                            $('.dlg_content').html(result);
                            $('.nhan_loading').remove();

                            if (result.indexOf('error') <= -1) {
                                $(`#${tengrid}`)[0].triggerToolbar();
                                Close_Form($dlg_gridSmall, CLform_infor.dongform);
                            }
                            else {
                                $('#btn-ok').button('option', 'disabled', false);
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
//end CA_01_TPNKMG

function getCellValue(rowId, cellId) {
    var cell = $('#' + rowId + '_' + cellId);
    var val = cell.val();
    return val;
}