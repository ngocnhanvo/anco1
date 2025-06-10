//Start Đơn hàng
var format_donhang = {
    create: function (elem) {
        let id_elem = $(elem).attr('id');
        $(elem).parent().append(`
            <span
                class="format_donhang glyphicon glyphicon-search" 
                style="position: absolute;margin: 1px 0 0 -21px;background-color: rgb(248, 249, 243);padding: 3.5px;cursor: pointer;border-left: 1px solid rgba(204, 204, 204, 0.63)" 
            />
        `);

        $(elem).attr('autocomplete', 'off');

        $(elem).keypress(function (e) {
            if (e.which == '13') {
                format_donhang.search(id_elem, 1);
            }
        });

        $(elem).next().click(function () {
            format_donhang.search(id_elem, 0);
        });
    },
    search: function (id_elem, type) {
        let $elem = $(`#${id_elem}`);
        if ($elem.prop('disabled')) {
            return;
        }

        let load_sp = 0;
        let namegrid = "gridMD_00_TatCaDonHang_cp";
        $('body').append(`
            <div 
                id="dlg_gridSmal_2" 
                style="margin: 4px 0 0 0; background-color: rgba(165, 121, 255, 0.07);" 
                title="Danh mục đơn hàng"
            >
                <table id="gridMD_00_TatCaDonHang_cp"></table>
                <div id="pagergridMD_00_TatCaDonHang_cp"></div>
            </div>
        `);

        let gridSel = $('.module_spanselect').attr('id').substring(5);
        let $dlgGridSmal2 = $('#dlg_gridSmal_2');
        let gridMasterId = 'gridMD_00_TatCaDonHang_cp';
        let $gridMaster = $(`#${gridMasterId}`);
        let laSoPO = id_elem == 'donhang_thamchieu';
        let giaoHang = $('#loaichuyen').val() == 'VANCNBCTKGH';
        let valEle = $elem.val();
        $dlgGridSmal2.dialog({
            modal: true,
            dialogClass: "dialog_index",
            width: 650,
            height: window.innerHeight - 10,
            open: function (event, ui) {
                $gridMaster.jqGrid({
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
                    pager: `#pager${gridMasterId}`,
                    onSelectRow: function (ids) {
                        checkbox_JQgrid($gridMaster.attr('id'), 0);
                        if (ids.indexOf('<a style=\'color:red\'') <= -1 & ids != '0') {
                            cell = $gridMaster.getRowData(ids);
                            $elem.val(cell.sochungtu);
                            $('#donhang_thamchieu').val(cell.so_po);
                            $('#md_doitackinhdoanh_id').val(cell.md_doitackinhdoanh_id);
                            $('#diachi').val(cell.diachigiaohang);
                            if (giaoHang) {
                                let sxt = cell.sanxuatton ? cell.sanxuatton : false;
                                $('#tukho')[0].loadDonHang(sxt);
                                $('#denkho')[0].loadDonHang(sxt);
                            }

							if($('#tukho')[0]) {
								if ($('#tukho')[0].loadDonHangXB) {
                                    let dht = cell.donhangtron ? cell.donhangtron : false;
                                    $('#tukho')[0].loadDonHangXB(dht, cell.loai);
								}
							}
                        }
                    },
                    colModel: [
                        { key: true, fixed: true, label: 'c_danhsachdathang_id', name: 'c_danhsachdathang_id', index: ' dsdh.c_danhsachdathang_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: true, formoptions: { label: 'c_danhsachdathang_id' } },
                        { key: false, fixed: true, label: 'Trạng thái', name: 'trangthai', index: 'dsdh.trangthai', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, formatter: Frm_MD_01_DSDatHang_trangthaigui, unformat: disable_formatter, align: 'left', stype: 'select', searchoptions: { sopt: ['bw'], value: { '': '', 'DAGUI': 'Chưa Nhận', 'DANHAN': 'Đã Nhận', 'SOANTHAO': 'Soạn thảo', 'HIEULUC': 'Hiệu lực' } }, frozen: false },
                        { key: false, fixed: true, label: 'Số Chứng Từ', name: 'sochungtu', index: ' dsdh.sochungtu ', width: 100, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Số Chứng Từ' } },
                        { key: false, fixed: true, label: 'Số Đơn Hàng', name: 'so_po', index: ' dsdh.so_po ', width: 170, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Số Đơn Hàng' } },
                        { key: false, fixed: true, label: 'Thời Hạn SX', name: 'thoigiansx', index: 'dsdh.thoigiansx', width: 113, editable: true, editrules: { edithidden: true }, hidden: true, formatter: 'number', unformat: disable_formatter, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { dataInit: function (elem) { format_number(elem, 1); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 0, suffix: '' } },
                        { key: false, fixed: true, label: 'Hạn Giao Hàng', name: 'hangiaohang_po', index: ' dsdh.hangiaohang_po ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() } },
                        { key: false, fixed: true, label: 'Ngày nhận', name: 'ngaytao', index: ' dsdh.ngaytao ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() } },
                        { key: false, fixed: true, label: 'Khách hàng', name: 'md_doitackinhdoanh_id', index: 'dtkd.ma_dtkd', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Nhà Cung Ứng' } },
                        { key: false, fixed: true, label: 'Địa chỉ', name: 'diachigiaohang', index: 'dsdh.diachigiaohang', width: 120, editable: true, editrules: { edithidden: true }, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Nhà Cung Ứng' } },
                        { key: false, fixed: true, label: 'sanxuatton', name: 'sanxuatton', index: 'dsdh.sanxuatton', width: 120, hidden: true },
                        { key: false, fixed: true, label: 'donhangtron', name: 'donhangtron', index: 'dsdh.sanxuatton', width: 120, hidden: true },
                        { key: false, fixed: true, label: 'loai', name: 'loai', index: 'dsdh.loai', width: 120, hidden: true }
                    ],
                    postData: {
                        where_ex: function () {
                            let whereSQL = ``;
                            let whereAll = `and dsdh.trangthai = 'HIEULUC' and isnull(dsdh.donhangtron, 0) = 0`;
                            if (giaoHang) {
                                whereSQL = ` 
                                    ${whereAll}
                                    and dsdh.trangthai = 'HIEULUC'
                                    and (
                                        select top 1 1
                                        from c_dongdsdh
                                        where 
                                            c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                                            and (sl_dathang - isnull(sl_giamhanngach,0) - isnull(sl_nhaphang, 0) - isnull(sl_thuhoi, 0)) > 0
                                    ) > 0
                                `;
                            }
                            else if (tengrid0 == 'gridMD_00_PVCDG') {
                                whereSQL = ` 
                                    ${whereAll}
                                    and (
                                        select top 1 1
                                        from c_dongdsdh
                                        where 
                                            c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                                            and isnull(sl_nhaphang, 0) > 0
                                            and (isnull(sl_donggoiTP, 0) <= isnull(sl_nhaphang, 0))
                                    ) > 0
                                `;
                            }
                            else if (tengrid0 == 'gridMD_00_XuatBan_PDN') {
                                whereSQL = ` 
                                    ${whereAll}
                                    and (
                                        select top 1 1
                                        from c_dongdsdh
                                        where 
                                            c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                                            and isnull(sl_donggoiTP, 0) > 0
                                            and (isnull(sl_donggoiTP, 0) - isnull(sl_dagiao, 0) - isnull(sl_thuhoi, 0)) > 0
                                    ) > 0
                                `;
                            }
                            else if (tengrid0 == 'gridMD_00_PVCTonThanhPham') {
                                let loaichuyenId = $('#loaichuyen_id').val();
                                if (loaichuyenId == 'T00' | loaichuyenId == 'T01') {
                                    whereSQL = ` 
                                        ${whereAll}
                                        and (
                                            select top 1 1
                                            from md_lenhsanxuat lsx
                                            inner join md_lenhsanxuat_tosx_cdh cdh on cdh.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
                                            where 
                                                lsx.donhang_thamchieu = dsdh.so_po
                                                and isnull(cdh.sl_giamhanngach, 0) > 0
                                                and isnull(cdh.sl_danhapkho, 0) + isnull(cdh.sl_datncc, 0) + isnull(cdh.sl_nhapkho, 0) - isnull(cdh.sl_nkton, 0) >= cdh.sl_dat - isnull(cdh.sl_giamhanngach, 0)
                                                and isnull(cdh.sl_danhapkho, 0) + isnull(cdh.sl_datncc, 0) + isnull(cdh.sl_nhapkho, 0) - isnull(cdh.sl_nkton, 0) > 0
                                        ) > 0
                                    `;
                                }
                                else if (loaichuyenId == 'T02') {
                                    whereSQL = ` 
                                        ${whereAll}
                                        and (
                                            select top 1 1
                                            from c_dongdsdh
                                            where 
                                                c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                                                and isnull(sl_giamhanngach, 0) > 0
                                                and isnull(sl_nhaphang, 0) > 0
                                                and (isnull(sl_nhaphang, 0) - isnull(sl_donggoiTP, 0) - isnull(sl_dagiao, 0) - isnull(sl_thuhoi, 0)) > 0
                                        ) > 0
                                    `;
                                }
                                else if (loaichuyenId == 'T03') {
                                    whereSQL = ` 
                                        ${whereAll}
                                        and (
                                            select top 1 1
                                            from c_dongdsdh
                                            where 
                                                c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                                                and isnull(sl_donggoiTP, 0) > 0
                                                and (isnull(sl_donggoiTP, 0) - isnull(sl_dagiao, 0) - isnull(sl_thuhoi, 0)) > 0
                                        ) > 0
                                    `;
                                }
                            }
                            else if (tengrid0 == 'gridMD_00_GiamHanNgach') {
                                whereSQL = ` 
                                    ${whereAll}
                                    and (
                                        select top 1 1
                                        from c_dongdsdh
                                        where 
                                            c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                                            and isnull(sl_dathang, 0) - isnull(sl_giamhanngach, 0) - isnull(sl_dagiao, 0) > 0
                                    ) > 0
                                `;
                            }
                            
                            return whereSQL;
                        }
                    },
                    beforeRequest: function () {
                        //giữ focus
                        if (valEle != '' & load_sp == 0) {
                            if (laSoPO)
                                $gridMaster.jqGrid('getGridParam', 'postData').filters = `{"groupOp":"AND","rules":[{"field":" dsdh.so_po ","op":"eq","data":"${valEle}"}]}`;
                            else
                                $gridMaster.jqGrid('getGridParam', 'postData').filters = `{"groupOp":"AND","rules":[{"field":" dsdh.sochungtu ","op":"eq","data":"${valEle}"}]}`;
                        }
                        input_focus = $('input:focus').attr('class');
                    },
                    ondblClickRow: function () {
                        $dlgGridSmal2.dialog('destroy').remove();
                    },
                    gridComplete: function () {
                        $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width() - 5);
                    },
                    loadComplete: function (data) {
                        var top_rowid = $(`#${gridMasterId} tr:nth-child(2)`).attr('id');
                        var countrow = $gridMaster.jqGrid('getGridParam', 'records');
                        if (load_sp == 0) {
                            if (laSoPO)
                                $(`.gs_so_po.gs_${gridMasterId}`).val(valEle);
                            else
                                $(`.gs_sochungtu.gs_${gridMasterId}`).val(valEle);

                            $gridMaster.jqGrid('setSelection', top_rowid);
                            load_sp = 1;
                            if (top_rowid.indexOf('err') <= -1 & type == 1 & countrow == 1) {
                                $dlgGridSmal2.dialog('destroy').remove();
                            }
                        }
                        checkbox_JQgrid(gridMasterId, 1);
                        Focus_Selection(gridMasterId);
                        //giữ focus end
                        $('.' + input_focus).focus();
                    },
                    caption: ' '
                });
                $gridMaster.jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });
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
};
//End Đơn hàng