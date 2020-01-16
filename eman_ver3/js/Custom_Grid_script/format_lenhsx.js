//Start Lệnh sản xuất
function format_lenhsx(elem) {
    var id_elem = $(elem).attr('id');
    $(elem).parent().append('<span onclick="timkiem_lenhsx(\'' + id_elem + '\')" ' +
        'class="span_format_lenhsx glyphicon glyphicon-search" style="position: absolute;margin: 1px 0 0 -21px;background-color: rgb(248, 249, 243);padding: 3.5px;cursor: pointer;border-left: 1px solid rgba(204, 204, 204, 0.63)" />');
    $(elem).attr('readonly', true);
    $(elem).css('cursor', 'default');
    $(elem).keypress(function (e) {
        if (e.which == '13') {
            $(elem).next().click();
        }
    });
}

function timkiem_lenhsx(id_elem, type) {
    if ($(`#${id_elem}`).prop('disabled') == true)
        return;
    var load_sp = 0;
    var namegrid = "gridMD_00_Lenhsanxuat_cp";
    $('body').append('<div id="dlg_gridSmal_2" style="margin: 4px 0 0 0; background-color: rgba(165, 121, 255, 0.07);" title="Danh mục Lệnh sản xuất">' +
        '<table id="gridMD_00_Lenhsanxuat_cp"></table>' +
        '<div id="pagergridMD_00_Lenhsanxuat_cp"></div>' +
        '</div>');
    var multi = false;
    if (tengrid0 == 'gridMD_00_Xuatnoibo_PDN' | tengrid0 == 'gridMD_00_Nhapnoibo_PDN' | tengrid0 == 'gridMD_00_PVCNoiBo_PDN')
    {
        multi = true;
    }
    
    $('#dlg_gridSmal_2').dialog({
        modal: true,
        dialogClass: "dialog_index",
        width: 650,
        height: window.innerHeight - 10,
        open: function (event, ui) {
            jQuery('#gridMD_00_Lenhsanxuat_cp').jqGrid({
                url: 'Controller/JqGrid/JQGridMD_00_LenhsanxuatLoad.ashx?ma_module=MD_00_Lenhsanxuat&ma_menu=MN_01_Lenhsanxuat&id=null&id_sel=&module_select=1',
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
                multiselect: multi,
                multiboxonly: false,
                rowList: [10, 50, 100, 1000],
                pager: '#pagergridMD_00_Lenhsanxuat_cp',
                onSelectRow: function (ids) {
                    if (multi)
                        checkbox_JQgrid(namegrid, 0);
                    if (ids != '<a style=\'color:red\'>Not data (404)</a>') {
                        cell = $('#gridMD_00_Lenhsanxuat_cp').getRowData(ids);
                        if ($('#' + id_elem).prop('disabled') != true) {
                            if (multi != true) {
                                $('#' + id_elem).val(cell['sochungtu']);
                                $('#sctdathang').val(cell['sctdathang']);
                                $('#donhang_thamchieu').val(cell['donhang_thamchieu']);
                                $('#xuatden').val(cell['md_phanxuong_id2']);
                                $('#nhaptu').val(cell['md_phanxuong_id2']);
                            }
                        }
                    }
                },
                colModel: [
                    { key: true, fixed: true, label: 'md_lenhsanxuat_id', name: 'md_lenhsanxuat_id', index: '  lsx.md_lenhsanxuat_id ', width: 100, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'md_lenhsanxuat_id' } },
                    { key: false, fixed: true, label: 'Trạng thái', name: 'md_trangthai_id', index: ' lsx.md_trangthai_id ', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, formatter: Frm_MD_00_Lenhsanxuat_trangthai, unformat: disable_formatter, align: 'left', stype: 'select', searchoptions: { sopt: ['eq'], value: { '': '', 'CHUAHOANTHANH': 'Chưa hoàn thành', 'HOANTHANH': 'Hoàn thành' } }, edittype: 'select', editoptions: { value: { 'CHUAHOANTHANH': 'Chưa hoàn thành', 'HOANTHANH': 'Hoàn thành' } }, frozen: false, formoptions: { label: 'Trạng thái' } },
                    { key: false, fixed: true, label: 'Số Chứng Từ', name: 'sochungtu', index: '  lsx.sochungtu ', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Số Chứng Từ' } },
                    { key: false, fixed: true, label: 'ĐĐH phân xưởng', name: 'md_dondathangphanxuong_id', index: '  lsx.md_dondathangphanxuong_id ', width: 100, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'ĐĐH phân xưởng' } },
                    { key: false, fixed: true, label: 'CT tham chiếu', name: 'sctdathang', index: 'ddhpx.sctdathang', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'CT tham chiếu' } },
                    { key: false, fixed: true, label: 'Đơn hàng tham chiếu', name: 'donhang_thamchieu', index: 'ddhpx.donhang_thamchieu', width: 100, editable: false, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'Đơn hàng tham chiếu' } },
                    { key: false, fixed: true, label: 'Phân xưởng', name: 'md_phanxuong_id', index: '  lsx.md_phanxuong_id ', width: 170, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Phân xưởng' } },
                    { key: false, fixed: true, label: 'ID Phân xưởng', name: 'md_phanxuong_id2', index: 'lsx.md_phanxuong_id ', width: 170, editable: false, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'ID Phân xưởng' } },
                    { key: false, fixed: true, label: 'Ngày Lập', name: 'ngaylap', index: ' lsx.ngaylap', width: 130, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: 'Ngày Lập' } },
                    { key: false, fixed: true, label: 'Ngày kết thúc', name: 'ngayketthuc', index: '  lsx.ngayketthuc ', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: 'Ngày kết thúc' } },
                    { key: false, fixed: true, label: 'Ngày hoàn thành', name: 'ngayhoanthanh', index: '  lsx.ngayhoanthanh ', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: 'Ngày hoàn thành' } },
                ],
                postData: {
                    where_ex: function () {
                        if (tengrid0 == 'gridMD_00_Xuatnoibo') {
                            let khdhpx = $('#kh_ddhpx').val();
                            let dkc = " and  dsdh.trangthai != 'KETTHUC' and dsdh.trangthai != 'HUYBO' and lsx.phieuXK != 'DAXUATHET' and lsx.md_trangthai_id = 'DAXL'";
                            if ($('#bosung').val() == '3')
                                dkc = `${dkc} and lsx.md_dondathangphanxuong_id in (select md_dondathangphanxuong_id from md_dondathangphanxuong where N'${khdhpx}' like N'%' + c_kehoachdathang_dhcpx_id + '%')`;
                            
                            return dkc;
                        }
                        else if (tengrid0 == 'gridMD_00_Nhapnoibo')
                            return " and  dsdh.trangthai != 'KETTHUC' and dsdh.trangthai != 'HUYBO' and lsx.md_trangthai_id = 'DAXL'";
                        else if (tengrid0 == 'gridMD_00_PVCNoiBo')
                            return " and  dsdh.trangthai != 'KETTHUC' and dsdh.trangthai != 'HUYBO' and lsx.md_trangthai_id = 'DAXL'";
                        else
                            return `
                                and  dsdh.trangthai != 'KETTHUC'
                                and dsdh.trangthai != 'HUYBO'
                                and lsx.md_trangthai_id = 'DAXL'
                            `;
                    }
                },
                beforeRequest: function () {
                    //giữ focus
                    if ($('#' + id_elem).val() != '' & load_sp == 0) {
                        var val_lsxid = $('#' + id_elem).val();
                        if (id_elem == 'md_lenhsanxuat_id')
                            $('#gridMD_00_Lenhsanxuat_cp').jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" lsx.sochungtu ","op":"eq","data":"' + val_lsxid + '"}]}';
                        else if (multi == false)
                            $('#gridMD_00_Lenhsanxuat_cp').jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" lsx.sochungtu ","op":"eq","data":"' + val_lsxid + '"}]}';

                    }
                    input_focus = $('input:focus').attr('class');
                },
                ondblClickRow: function () {
                    if (multi != true) {
                        $('#dlg_gridSmal_2').dialog('destroy').remove();
                    }
                },
                gridComplete: function () {
                    $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
                },
                loadComplete: function (data) {
                    var top_rowid = $('#gridMD_00_Lenhsanxuat_cp tr:nth-child(2)').attr('id');
                    var countrow = jQuery("#gridMD_00_Lenhsanxuat_cp").jqGrid('getGridParam', 'records');
                    if (load_sp == 0) {
                        var val_lsxid = $('#' + id_elem).val();
                        if (id_elem == 'md_lenhsanxuat_id')
                            $('.gs_sochungtu.gs_gridMD_00_Lenhsanxuat_cp').val(val_lsxid);
                        else if (multi == false)
                            $('.gs_sochungtu.gs_gridMD_00_Lenhsanxuat_cp').val(val_lsxid);


                        //$('#gridMD_00_Lenhsanxuat_cp').jqGrid('setSelection', val_lsxid);
                        var grid = jQuery("#gridMD_00_Lenhsanxuat_cp");
                        var grid_ids = grid.jqGrid('getDataIDs');
                        for (var i = 0; i < grid_ids.length; i++) {
                            var rowid = grid_ids[i];
                            var aRow = grid.jqGrid('getRowData', rowid);
                            var book_id = aRow['sochungtu'];
                            if (val_lsxid.indexOf(book_id) > -1) {
                                var chk_ipu_lsx = 'jqg_gridMD_00_Lenhsanxuat_cp_' + rowid;
                                grid.jqGrid('setSelection', rowid);
                            }
                        }
                        load_sp = 1;
                        if (top_rowid.indexOf('<a style=\'color:red\'>') <= -1 & type == 1 & countrow == 1) {
                            $('#dlg_gridSmal_2').dialog('destroy').remove();
                        }
                    }
                    Focus_Selection('gridMD_00_Lenhsanxuat_cp');
                    checkbox_JQgrid('gridMD_00_Lenhsanxuat_cp', 1);
                    //giữ focus end
                    $('.' + input_focus).focus();
                },
                caption: ' '
            });
            jQuery('#gridMD_00_Lenhsanxuat_cp').jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });
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
                    if (multi == true)
                    {
                        var ids_sel = $('#' + namegrid).jqGrid('getGridParam', 'selarrrow'), sct_pnk = '', sct_dhtc = '', val_dhtc = '';
                        for (var i = 0; i < ids_sel.length; i++) {
                            var cel_s = $('#' + namegrid).getRowData(ids_sel[i]);
                            sct_pnk += cel_s['sochungtu'] + '\n';
                            sct_dhtc += cel_s['sctdathang'] + '\n';
                            val_dhtc += cel_s['donhang_thamchieu'] + '\n';
                        }
                        if (sct_pnk != '') {
                            sct_pnk = sct_pnk.substring(0, sct_pnk.length - 1);
                            sct_dhtc = sct_dhtc.substring(0, sct_dhtc.length - 1);
                            val_dhtc = val_dhtc.substring(0, val_dhtc.length - 1);
                        }

                        $('#chungtu_lenhsx').val(sct_pnk);
                        $('#sctdathang').val(sct_dhtc);
                        $('#donhang_thamchieu').val(val_dhtc);
                        khoa_column('sctdathang');
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
//End Lệnh sản xuất