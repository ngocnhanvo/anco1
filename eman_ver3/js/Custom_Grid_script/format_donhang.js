//Start Đơn hàng
function format_donhang(elem) {
    var id_elem = $(elem).attr('id');
    $(elem).keypress(function (e) {
        if (e.which == '13') {
            timkiem_donhang(id_elem, 1);
        }
    });
    $(elem).parent().append('<span onclick="timkiem_donhang(\'' + id_elem + '\')" ' +
        'class="span_format_donhang glyphicon glyphicon-search" style="position: absolute;margin: 1px 0 0 -21px;background-color: rgb(248, 249, 243);padding: 3.5px;cursor: pointer;border-left: 1px solid rgba(204, 204, 204, 0.63)" />');
}

function timkiem_donhang(id_elem, type) {
    var load_sp = 0;
    var namegrid = "gridMD_00_TatCaDonHang_cp";
    $('body').append('<div id="dlg_gridSmal_2" style="margin: 4px 0 0 0; background-color: rgba(165, 121, 255, 0.07);" title="Danh mục đơn hàng">' +
        '<table id="gridMD_00_TatCaDonHang_cp"></table>' +
        '<div id="pagergridMD_00_TatCaDonHang_cp"></div>' +
        '</div>');

    $('#dlg_gridSmal_2').dialog({
        modal: true,
        dialogClass: "dialog_index",
        width: 650,
        height: window.innerHeight - 10,
        open: function (event, ui) {
            jQuery('#gridMD_00_TatCaDonHang_cp').jqGrid({
                url: 'Controller/JqGrid/JQGridMD_00_TatCaDonHangLoad.ashx?ma_module=MD_00_TatCaDonHang&ma_menu=MN_01_DSDHJQGS&id=null&id_sel=&module_select=1',
                editurl: '',
                height: window.innerHeight - 220,
                datatype: 'json',
                autowidth: true,
                shrinkToFit: true,
                rownumbers: true,
                viewrecords: true,
                search: true,
                scroll: false,
                rowNum: 100,
                multiselect: false,
                multiboxonly: false,
                rowList: [10, 50, 100, 1000],
                pager: '#pagergridMD_00_TatCaDonHang_cp',
                onSelectRow: function (ids) {
                    checkbox_JQgrid('gridMD_00_TatCaDonHang_cp', 0);
                    if (ids.indexOf('<a style=\'color:red\'') <= -1) {
                        cell = $('#gridMD_00_TatCaDonHang_cp').getRowData(ids);
                        if ($('#' + id_elem).prop('disabled') != true) {
                            $('#' + id_elem).val(cell['sochungtu']);
                            $('#donhang_thamchieu').val(cell['so_po']);
                            $('#hangiaohang_po').val(cell['hangiaohang_po']);
                            $('#ngaybatdausx').val(cell['ngaytao']);
                        }
                    }
                },
                colModel: [
                    { key: true, fixed: true, label: 'c_danhsachdathang_id', name: 'c_danhsachdathang_id', index: ' dsdh.c_danhsachdathang_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: true, formoptions: { label: 'c_danhsachdathang_id' } },
                    { key: false, fixed: true, label: 'Trạng thái', name: 'trangthai', index: 'dsdh.trangthai', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, formatter: Frm_MD_01_DSDatHang_trangthaigui, unformat: disable_formatter, align: 'left', stype: 'select', searchoptions: { sopt: ['bw'], value: { '': '', 'DAGUI': 'Chưa Nhận', 'DANHAN': 'Đã Nhận', 'SOANTHAO': 'Soạn thảo', 'HIEULUC': 'Hiệu lực' } }, edittype: 'select', editoptions: { value: { 'SOANTHAO': 'Soạn thảo', 'HIEULUC': 'Hiệu lực' } }, frozen: false },
                    { key: false, fixed: true, label: 'Số Chứng Từ', name: 'sochungtu', index: ' dsdh.sochungtu ', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Số Chứng Từ' } },
                    { key: false, fixed: true, label: 'Số Đơn Hàng', name: 'so_po', index: ' dsdh.so_po ', width: 170, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Số Đơn Hàng' } },
                    { key: false, fixed: true, label: 'Ngày Bắt Đầu SX', name: 'ngaybatdau', index: 'dsdh.ngaybatdau', width: 130, editable: true, editrules: { edithidden: true }, hidden: true, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() } },
                    { key: false, fixed: true, label: 'Thời Hạn SX', name: 'thoigiansx', index: 'dsdh.thoigiansx', width: 113, editable: true, editrules: { edithidden: true }, hidden: true, formatter: 'number', unformat: disable_formatter, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { dataInit: function (elem) { format_number(elem, 1); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 0, suffix: '' } },
                    { key: false, fixed: true, label: 'Hạn Giao Hàng', name: 'hangiaohang_po', index: ' dsdh.hangiaohang_po ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() } },
                    { key: false, fixed: true, label: 'Ngày nhận', name: 'ngaytao', index: ' dsdh.ngaytao ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() } },
                    { key: false, fixed: true, label: 'Khách hàng', name: 'md_doitackinhdoanh_id', index: 'dtkd.ma_dtkd', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Nhà Cung Ứng' } },
                    { key: false, fixed: true, label: 'Nơi Giao Hàng', name: 'diachigiaohang', index: ' dsdh.diachigiaohang ', width: 120, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, edittype: 'textarea', frozen: false, formoptions: { label: 'Nơi Giao Hàng' } },
                ],
                postData: {
                    where_ex: function () {
                        let whereSQL = '';
                        if (tengrid0 != 'gridMD_00_GiamHanNgach')
                            whereSQL = " and dsdh.trangthai = 'HIEULUC'";

                        if (tengrid0 == 'gridMD_00_XuatBan_PDN')
                            whereSQL += ` 
                            and (
                                select top 1 1
                                from c_dongdsdh
                                where 
                                    c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                                    and (sl_dathang - isnull(sl_giamhanngach,0) - isnull(sl_dagiao, 0) - isnull(sl_thuhoi, 0)) > 0
                            ) > 0
                            `;

                        if (tengrid0 == 'gridMD_00_KeHoachDatHangTongHop')
                            whereSQL += ` 
                            and (
                                select top 1 1
                                from c_kehoachdathang
                                where 
                                    sodonhang = dsdh.sochungtu
                                    and isnull(nhomKH, '') = ''
                                    and trangthai = 'SOANTHAO'
                            ) > 0
                            `;

                        if (tengrid0 == 'gridMD_00_LenhDongGoi')
                        {
                            whereSQL += " and (";
                            whereSQL += " select count(1)";
                            whereSQL += " from c_dongdsdh";
                            whereSQL += " where c_danhsachdathang_id = dsdh.c_danhsachdathang_id";
                            whereSQL += " and (sl_dathang - isnull(sl_giamhanngach,0) - isnull(sl_donggoi, 0)) > 0";
                            whereSQL += " ) > 0";
                        }

                        if (tengrid0 == 'gridMD_00_BaoCaoSanXuat') {
                            whereSQL += " and (";
                            whereSQL += " select count(1)";
                            whereSQL += " from md_dondathangphanxuong";
                            whereSQL += " where donhang_thamchieu = dsdh.so_po";
                            whereSQL += "   and md_trangthai_id = 'HIEULUC'";
                            whereSQL += "   and md_phanxuong_id = '" + $('#selPhanXuong').val() + "'";
                            whereSQL += " ) > 0";
                        }
                        return whereSQL;
                    }
                },
                beforeRequest: function () {
                    //giữ focus
                    if ($('#' + id_elem).val() != '' & load_sp == 0) {
                        if (id_elem == 'donhang_thamchieu')
                            $('#gridMD_00_TatCaDonHang_cp').jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" dsdh.so_po ","op":"eq","data":"' + $('#' + id_elem).val() + '"}]}';
                        else
                            $('#gridMD_00_TatCaDonHang_cp').jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" dsdh.sochungtu ","op":"eq","data":"' + $('#' + id_elem).val() + '"}]}';
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
                    var top_rowid = $('#gridMD_00_TatCaDonHang_cp tr:nth-child(2)').attr('id');
                    var countrow = jQuery("#gridMD_00_TatCaDonHang_cp").jqGrid('getGridParam', 'records');
                    if (load_sp == 0) {
                        if (id_elem == 'donhang_thamchieu')
                            $('.gs_so_po.gs_gridMD_00_TatCaDonHang_cp').val($('#' + id_elem).val());
                        else
                            $('.gs_sochungtu.gs_gridMD_00_TatCaDonHang_cp').val($('#' + id_elem).val());

                        $('#gridMD_00_TatCaDonHang_cp').jqGrid('setSelection', $('#' + id_elem).val());
                        load_sp = 1;
                        if (top_rowid.indexOf('<a style=\'color:red\'>') <= -1 & type == 1 & countrow == 1) {
                            $('#dlg_gridSmal_2').dialog('destroy').remove();
                        }
                    }
                    checkbox_JQgrid('gridMD_00_TatCaDonHang_cp', 1);
                    Focus_Selection('gridMD_00_TatCaDonHang_cp');
                    //giữ focus end
                    $('.' + input_focus).focus();
                },
                caption: ' '
            });
            jQuery('#gridMD_00_TatCaDonHang_cp').jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });
            Logo_Center("glyphicon glyphicon-search", true, 'dlg_gridSmal_2');
        },
        close: function () {
            $(this).dialog('destroy').remove();
        },
        buttons: [
            {
                id: 'btn-ok_',
                text: 'OK',
                click: function () {
                    if (tengrid0 == 'gridMD_00_Xuatnoibo') {
                        if ($('#' + id_elem).prop('disabled') != true) {
                            var ids_sel = $('#' + namegrid).jqGrid('getGridParam', 'selarrrow'), sct_pnk = '', sct_dhtc = '', val_dhtc = '';
                            for (var i = 0; i < ids_sel.length; i++) {
                                var cel_s = $('#' + namegrid).getRowData(ids_sel[i]);
                                sct_pnk += cel_s['sochungtu'] + '\n';
                                val_dhtc += cel_s['so_po'] + '\n';
                            }
                            if (sct_pnk != '') {
                                sct_pnk = sct_pnk.substring(0, sct_pnk.length - 1);
                                val_dhtc = val_dhtc.substring(0, val_dhtc.length - 1);
                            }

                            $('#sctdathang').val(sct_pnk);
                            $('#donhang_thamchieu').val(val_dhtc);
                        }
                    }
                    $(this).dialog('destroy').remove();
                }
            },
            {
                id: 'btn-close_',
                text: 'Cancel',
                click: function () {
                    $(this).dialog("destroy").remove();
                }
            }
        ]
    });
}
//End Đơn hàng