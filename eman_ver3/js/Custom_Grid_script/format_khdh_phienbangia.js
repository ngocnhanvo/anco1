//Start Đơn hàng
var format_khdh_phienbangia = {
    create: function (elem) {
        let id_elem = $(elem).attr('id');
        $(elem).parent().append(`
            <span
                class="format_khdh_phienbangia glyphicon glyphicon-search" 
                style="position: absolute;margin: 1px 0 0 -19px;background-color: rgb(248, 249, 243);padding: 3px;cursor: pointer;border-left: 1px solid rgba(204, 204, 204, 0.63)" 
            />
        `);

        $(elem).attr('autocomplete', 'off');

        $(elem).keypress(function (e) {
            if (e.which == '13') {
                format_khdh_phienbangia.search(id_elem, 1);
            }
        });

        $(elem).next().click(function () {
            format_khdh_phienbangia.search(id_elem, 0);
        });
    },
    search: function (id_elem, type) {
        let $elem = $(`#${id_elem}`);
        if ($elem.prop('disabled')) {
            return;
        }

        let spid = id_elem.replace('_phienbangia', '');
        let dtkd = $(`#${spid}_nccmacdinh`).val();
        let rowMasterSel = $('#gridMD_01_KHDNCC').getRowData(spid);
        
        let load_sp = 0;
        let namegrid = "gridKHDH_PhienBanGiaMua";
        $('body').append(`
            <div 
                id="dlg_gridSmal_2" 
                style="margin: 4px 0 0 0; background-color: rgba(165, 121, 255, 0.07);" 
                title="Phiên bản giá của mã ${rowMasterSel.ma_sanpham}"
            >
                <table id="${namegrid}"></table>
                <div id="pager${namegrid}"></div>
            </div>
        `);

        let gridSel = $('.module_spanselect').attr('id').substring(5);
        let $dlgGridSmal2 = $('#dlg_gridSmal_2');
        let $gridMaster = $(`#${namegrid}`);;
        let valEle = $elem.val();
        $dlgGridSmal2.dialog({
            modal: true,
            dialogClass: "dialog_index",
            width: 650,
            height: window.innerHeight - 10,
            open: function (event, ui) {
                $gridMaster.jqGrid({
                    url: 'Controller/JqGridCustom/KHDH_PhienBanGiaMuaLoad.ashx',
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
                    pager: `#pager${namegrid}`,
                    onSelectRow: function (ids) {
                        checkbox_JQgrid($gridMaster.attr('id'), 0);
                        if (ids.indexOf('<a style=\'color:red\'') <= -1 & ids != '0') {
                            cell = $gridMaster.getRowData(ids);
                            $elem.val(cell.ten_phienbangia);
                        }
                    },
                    colModel: [
                        { key: true, fixed: true, label: `md_phienbangia_id`, name: 'md_phienbangia_id', index: ' pbg.md_phienbangia_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, formoptions: { label: `md_phienbangia_id` } },
                        { key: false, fixed: true, label: `Trạng thái`, name: 'trangthai', index: 'pbg.trangthai', width: 100, editable: false, hidden: true, formatter: Frm_MD_00_KHDHJQGS_trangthai, unformat: disable_formatter, align: 'left', stype: 'select', searchoptions: { sopt: ['bw'], value: json_MD_00_Nhapnoibo_trangthai }, edittype: 'select', editoptions: { value: json_MD_00_Nhapnoibo_trangthai }, frozen: false, formoptions: { label: `Trạng thái` } },
                        { key: false, fixed: true, label: `Bảng giá`, name: 'md_banggia_id', index: ' pbg.md_banggia_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: `Bảng giá` } },
                        { key: false, fixed: true, label: `Tên phiên bản giá`, name: 'ten_phienbangia', index: ' pbg.ten_phienbangia ', width: 170, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: `Tên phiên bản giá` } },
                        { key: false, fixed: true, label: `Ngày hiệu lực`, name: 'ngay_hieuluc', index: ' pbg.ngay_hieuluc ', width: 105, editable: true, editrules: { edithidden: true }, hidden: false, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: `Ngày hiệu lực` } },
                        { key: false, fixed: true, label: `Trạng thái`, name: 'md_trangthai_id', index: ' pbg.md_trangthai_id ', width: 100, editable: false, hidden: true, formatter: Frm_MD_01_PBangGia_trangthai, unformat: disable_formatter, align: 'left', stype: 'select', searchoptions: { sopt: ['bw'], value: { '': '', 'SOANTHAO': 'Soạn thảo', 'HIEULUC': 'Hiệu lực' } }, edittype: 'select', editoptions: { value: { 'SOANTHAO': 'Soạn thảo', 'HIEULUC': 'Hiệu lực' } }, frozen: false, formoptions: { label: `Trạng thái` } },
                        { key: false, fixed: true, label: `Giá mua`, name: 'gia', index: ' gsp.gia ', width: 90, editable: true, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'right', searchoptions: { sopt: ['en'], dataInit: function (elem) { search_number(elem); } }, editoptions: { dataInit: function (elem) { format_numeric($(elem), 2); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: `Giá HHVT` } },
                        { key: false, fixed: true, label: `Ngày tạo`, name: 'ngaytao', index: ' pbg.ngaytao ', width: 90, editable: false, hidden: true, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: `Ngày tạo` } },
                        { key: false, fixed: true, label: `Người tạo HT`, name: 'nguoitao', index: ' pbg.nguoitao ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, formoptions: { label: `Người tạo HT` } },
                        { key: false, fixed: true, label: `Ngày cập nhật`, name: 'ngaycapnhat', index: ' pbg.ngaycapnhat ', width: 90, editable: false, hidden: true, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: `Ngày cập nhật` } },
                        { key: false, fixed: true, label: `Người cập nhật HT`, name: 'nguoicapnhat', index: ' pbg.nguoicapnhat ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, formoptions: { label: `Người cập nhật HT` } },
                        { key: false, fixed: true, label: `Mô tả`, name: 'mota', index: ' pbg.mota ', width: 140, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 2000 }, formoptions: { label: `Mô tả` } },
                        { key: false, fixed: true, label: `Hoạt động`, name: 'hoatdong', index: ' pbg.hoatdong ', width: 60, editable: true, editrules: { edithidden: true }, hidden: false, formatter: 'checkbox', align: 'center', stype: 'select', searchoptions: { sopt: ['bw'], value: ':Tất cả;1:Có;0:Không' }, edittype: 'checkbox', editoptions: { value: 'True:False', defaultValue: 'True' }, frozen: false, formoptions: { label: `Hoạt động` } },
                    ],
                    postData: {
                        dtkd: function () {
                            return dtkd;
                        },
                        spid: function () {
                            return spid;
                        }
                    },
                    beforeRequest: function () {
                        //giữ focus
                        if (valEle != '' & load_sp == 0) {
                            $gridMaster.jqGrid('getGridParam', 'postData').filters = `{"groupOp":"AND","rules":[{"field":" pbg.ten_phienbangia ","op":"eq","data":"${valEle}"}]}`;
                        }
                        input_focus = $('input:focus');
                    },
                    ondblClickRow: function () {
                        $dlgGridSmal2.dialog('destroy').remove();
                    },
                    gridComplete: function () {
                        $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width() - 5);
                    },
                    loadError: function (xhr, status, error) {
                        if (xhr.status === 500) {
                            let htmlElements = $.parseHTML(xhr.responseText);
                            let titleText = $(htmlElements).filter('title').text();
                            alert(`Lỗi: ${titleText}`);
                            $dlgGridSmal2.dialog('destroy').remove();
                        } else if (xhr.status === 503) {
                            alert("Hệ thống quá tải (503): Vui lòng thử lại sau ít phút!");
                        } else {
                            alert("Lỗi không xác định: " + xhr.status);
                        }
                    },
                    loadComplete: function (data) {
                        var top_rowid = $(`#${namegrid} tr:nth-child(2)`).attr('id');
                        var countrow = $gridMaster.jqGrid('getGridParam', 'records');
                        if (load_sp == 0) {
                            $(`.gs_ten_phienbangia.gs_${namegrid}`).val(valEle);
                            $gridMaster.jqGrid('setSelection', top_rowid);
                            load_sp = 1;
                            if (top_rowid.indexOf('err') <= -1 & type == 1 & countrow == 1) {
                                $dlgGridSmal2.dialog('destroy').remove();
                            }
                        }
                        checkbox_JQgrid(namegrid, 1);
                        Focus_Selection(namegrid);
                        //giữ focus end
                        input_focus.focus();
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