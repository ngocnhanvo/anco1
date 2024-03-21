//Start San pham
function format_sanpham(elem) {
    if (!$(elem)[0].keyPressF) {
        $(elem)[0].keyPressF = 1;
        $(elem).keypress(function (e) {
            if (e.which == '13') {
                timkiem_sanpham($(this).next(), 1);
            }
        });
    }
    
    $(elem).parent().append(`<span onclick="timkiem_sanpham(this)"
        class="span_format_sanpham glyphicon glyphicon-search" 
        style="position: absolute;margin: 1px 0 0 -21px;background-color: rgb(248, 249, 243);padding: 3.5px;cursor: pointer;border-left: 1px solid rgba(204, 204, 204, 0.63)" />`);

    setTimeout(function () { $('#tr_sanpham_id').hide(); }, 10);
}

function timkiem_sanpham(id_elem, type) {
    var load_sp = 0;
    $('body').append(`
        <div id="dlg_gridSmal_2" style="margin: 4px 0 0 0; background-color: rgba(165, 121, 255, 0.07);" title="Danh mục hàng hóa/vật tư">
            <table id="gridMD_00_DSHangHoaVG_cp"></table>
            <div id="pagergridMD_00_DSHangHoaVG_cp"></div>
        </div>`
    );

    let where_ex = 'and sp.hoatdong = 1', vattu = false, btp = false, tp = false;
    if ($('.module_spanselect').attr('id') == 'span_MD_00_DSDHTCJQGS') {
        vattu = true;
        tp = true;
        let datagrid0 = $('#gridMD_00_DSDHTCJQGS').getRowData(id_parent1);
        let sxton = datagrid0.sanxuatton == 'True';
        let dhtron = datagrid0.donhangtron == 'True';
        if (dhtron) {
            where_ex += ` and sp.ban_thanhpham = 1 and kmd.ma_kho = 'KHO100'`;
        }
        else if (sxton) {
            where_ex += ` and sp.ban_thanhpham = 1 and kmd.ma_kho = 'KHO110'`;
        }
    }

    id_elem = $(id_elem).prev();
    $('#dlg_gridSmal_2').dialog({
        modal: true,
        dialogClass: "dialog_index",
        width: 530,
        height: window.innerHeight - 10,
        open: function (event, ui) {
            jQuery('#gridMD_00_DSHangHoaVG_cp').jqGrid({
                url: 'Controller/JqGrid/JQGridMD_00_DSHangHoaVGLoad.ashx?ma_module=MD_00_DSHangHoaVG&ma_menu=MN_01_DSHangHoaVG&id=null&id_sel=&module_select=1',
                editurl: '',
                height: window.innerHeight - 220,
                datatype: 'json',
                autowidth: true,
                shrinkToFit: true,
                rownumbers: true,
                viewrecords: true,
                search: true,
                scroll: false,
                rowNum: 50,
                multiselect: false,
                multiboxonly: false,
                rowList: [10, 50, 100, 1000],
                pager: '#pagergridMD_00_DSHangHoaVG_cp',
                onSelectRow: function (ids) {
                    if (ids != '<a style=\'color:red\'>Not data (404)</a>') {

                        cell = $('#gridMD_00_DSHangHoaVG_cp').getRowData(ids);
                        if (id_elem.prop('disabled') != true) {
                            id_elem.val(cell['ma_sanpham']);
                            $(`#sanpham_id`).val(cell['md_sanpham_id']);
                        }
                        $('#mota_tiengviet').val(cell['mota_tiengviet']);
                        $('#tenhang').val(cell['mota_tiengviet']);
                        $('#mota_tienganh').val(cell['mota_tienganh']);
                        $('#v2').val(cell['v2']);
                        $('#md_doitackinhdoanh_id').val(cell['nhacungung']);
                        $('#md_donvitinhsanpham_id option').each(function (index, val) {
                            if (cell['md_donvitinhsanpham_id'] == $(this).text()) {
                                $(this).attr('selected', true);
                                $('#md_donvitinhsanpham_id').val($(this).val());
                            }
                            else {
                                $(this).removeAttr('selected');
                            }
                        });

                        $('#md_dvtsp_id option').each(function (index, val) {
                            if (cell['md_donvitinhsanpham_id'] == $(this).text()) {

                                $(this).attr('selected', true);
                            }
                            else {
                                $(this).removeAttr('selected');
                            }
                        });

                        $('#donvitinh option').each(function (index, val) {
                            if (cell['md_donvitinhsanpham_id'] == $(this).text()) {

                                $(this).attr('selected', true);
                            }
                            else {
                                $(this).removeAttr('selected');
                            }
                        });
                    }
                },
                colModel: [
                    { key: true, fixed: true, label: 'Sản Phẩm Id', name: 'md_sanpham_id', index: ' sp.md_sanpham_id ', width: 120, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 255 }, frozen: true, formoptions: { label: 'Sản Phẩm Id' } },
                    { key: false, fixed: true, label: 'Mã Sản Phẩm', name: 'ma_sanpham', index: ' sp.ma_sanpham ', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 255 }, frozen: true, formoptions: { label: 'Mã Sản Phẩm' } },
                    { key: false, fixed: true, label: 'md_kieudang_id', name: 'md_kieudang_id', index: ' sp.md_kieudang_id ', width: 120, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'md_kieudang_id' } },
                    { key: false, fixed: true, label: 'md_chucnang_id', name: 'md_chucnang_id', index: ' sp.md_chucnang_id ', width: 120, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'md_chucnang_id' } },
                    { key: false, fixed: true, label: 'ma_sanphamcu', name: 'ma_sanphamcu', index: ' sp.ma_sanphamcu ', width: 120, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'ma_sanphamcu' } },
                    { key: false, fixed: true, label: 'Mô Tả Tiếng Việt', name: 'mota_tiengviet', index: ' sp.mota_tiengviet ', width: 160, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, edittype: 'textarea', frozen: false, formoptions: { label: 'Mô Tả Tiếng Việt' } },
                    { key: false, fixed: true, label: 'Mô Tả Tiếng Anh', name: 'mota_tienganh', index: ' sp.mota_tienganh ', width: 160, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, edittype: 'textarea', frozen: false, formoptions: { label: 'Mô Tả Tiếng Anh' } },
                    { key: false, fixed: true, label: 'Đơn Vị Tính', name: 'md_donvitinhsanpham_id', index: 'dvt_sp.ten_dvt', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Đơn Vị Tính' } },
                    { key: false, fixed: true, label: 'Kho mặc định', name: 'khomacdinh', index: 'kmd.ten_kho', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'ma_sanphamcu' } },
                    { key: false, fixed: true, label: 'Kho tồn', name: 'khoton', index: 'kton.ten_kho', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'ma_sanphamcu' } },
                    { key: false, fixed: true, label: 'Vật tư', name: 'vattu', index: ' sp.vattu ', width: 65, editable: true, editrules: { edithidden: true }, hidden: vattu, formatter: 'checkbox', align: 'center', stype: 'select', searchoptions: { sopt: ['bw'], value: ':Tất cả;1:Có;0:Không' }, edittype: 'checkbox', editoptions: { value: 'True:False', defaultValue: 'False' }, frozen: false, formoptions: { label: 'Vật tư' } },
                    { key: false, fixed: true, label: 'Bán TP', name: 'ban_thanhpham', index: ' sp.ban_thanhpham ', width: 65, editable: true, editrules: { edithidden: true }, hidden: btp, formatter: 'checkbox', align: 'center', stype: 'select', searchoptions: { sopt: ['bw'], value: ':Tất cả;1:Có;0:Không' }, edittype: 'checkbox', editoptions: { value: 'True:False', defaultValue: 'False' }, frozen: false, formoptions: { label: 'Bán TP' } },
                    { key: false, fixed: true, label: 'Sản phẩm', name: 'sanpham', index: ' sp.sanpham ', width: 65, editable: true, editrules: { edithidden: true }, hidden: tp, formatter: 'checkbox', align: 'center', stype: 'select', searchoptions: { sopt: ['bw'], value: ':Tất cả;1:Có;0:Không' }, edittype: 'checkbox', editoptions: { value: 'True:False', defaultValue: 'False' }, frozen: false, formoptions: { label: 'Sản phẩm' } },
                    { key: false, fixed: true, label: 'CBM', name: 'v2', index: 'sp.v2', width: 75, editable: true, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'center', searchoptions: { sopt: ['bw'], dataInit: function (elem) { search_number(elem); } }, editoptions: { defaultValue: '0', dataInit: function (elem) { format_number(elem, 0, 3); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: 'CBM' } },
                    { key: false, fixed: true, label: 'Có Ngày Hết Hạn', name: 'co_ngayhethan', index: 'sp.co_ngayhethan', width: 100, editable: true, editrules: { edithidden: true }, hidden: true, formatter: 'checkbox', align: 'center', stype: 'select', searchoptions: { sopt: ['bw'], value: ':Tất cả;1:Có;0:Không' }, edittype: 'checkbox', editoptions: { value: 'True:False', defaultValue: 'False' }, frozen: false, formoptions: { label: 'Có Ngày Hết Hạn' } }
                ],
                beforeRequest: function () {
                    //giữ focus
                    $('#gridMD_00_DSHangHoaVG_cp').jqGrid('getGridParam', 'postData').where_ex = where_ex;
                    if (id_elem.val() != '' & load_sp == 0) {
                        $('#gridMD_00_DSHangHoaVG_cp').jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" sp.ma_sanpham ","op":"bw","data":"' + id_elem.val() + '"}]}';
                    }
                    input_focus = $('input:focus').attr('class');
                },
                ondblClickRow: function () {
                    $('#dlg_gridSmal_2').dialog('destroy').remove();
                },
                gridComplete: function () {
                    $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width() - 5);
                },
                loadComplete: function (data) {
                    var top_rowid = $('#gridMD_00_DSHangHoaVG_cp tr:nth-child(2)').attr('id') + '';
                    var countrow = jQuery("#gridMD_00_DSHangHoaVG_cp").jqGrid('getGridParam', 'records');
                    if (load_sp == 0) {
                        $('.gs_ma_sanpham.gs_gridMD_00_DSHangHoaVG_cp').val(id_elem.val());
                        $('#gridMD_00_DSHangHoaVG_cp').jqGrid('setSelection', top_rowid);
                        load_sp = 1;
                        if (top_rowid != '0' & type == 1 & countrow == 1) {
                            $('#dlg_gridSmal_2').dialog('destroy').remove();
                        }
                    }
                    Focus_Selection('gridMD_00_DSHangHoaVG_cp');
                    //giữ focus end 
                    $('.' + input_focus).focus();
                },
                caption: ' '
            });
            jQuery('#gridMD_00_DSHangHoaVG_cp').jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });
            Logo_Center("glyphicon glyphicon-search", true, 'dlg_gridSmal_2');
        },
        close: function () {
            $(this).dialog('destroy').remove();
        },
        buttons: [
            {
                id: 'btn-ok',
                text: 'OK',
                click: function () {
                    $(this).dialog('destroy').remove();
                }
            },
            {
                id: 'btn-close',
                text: 'Cancel',
                click: function () {
                    $(this).dialog("destroy").remove();
                }
            }
        ]
    });
}
//End San pham