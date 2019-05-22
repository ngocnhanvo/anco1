//Start Nhap kho tu NCC
function format_nktncc(elem) {
    var id_elem = $(elem).attr('id');
    $(elem).keypress(function (e) {
        if (e.which == '13') {
            timkiem_nktncc(id_elem, 1);
        }
    });
    $(elem).parent().append('<span onclick="timkiem_nktncc(\'' + id_elem + '\')" ' +
        'class="span_format_lenhsx glyphicon glyphicon-search" style="position: absolute;margin: 1px 0 0 -21px;background-color: rgb(248, 249, 243);padding: 3.5px;cursor: pointer;border-left: 1px solid rgba(204, 204, 204, 0.63)" />');
}

function timkiem_nktncc(id_elem, type) {
    var load_sp = 0;
    var namegrid = "gridMD_00_DMHHVT_cp";
    $('body').append(`
        <div id="dlg_gridSmal_2" style="margin: 4px 0 0 0; background-color: rgba(165, 121, 255, 0.07);" title="Đơn mua hàng">
            <table id="${namegrid}"></table>
            <div id="pager${namegrid}"></div>
            <table id="${namegrid}_child"></table>
            <div id="${namegrid}_child"></div>
        </div>`);

    $('#dlg_gridSmal_2').dialog({
        modal: true,
        dialogClass: "dialog_index",
        width: 650,
        height: window.innerHeight - 10,
        open: function (event, ui) {
            let id_gridMD_00_DMHHVT_cp = null;
            jQuery('#' + namegrid).jqGrid({
                url: 'Controller/JqGrid/JQGridMD_00_DonMuaHangTatCaLoad.ashx?ma_module=MD_00_DonMuaHang&ma_menu=MN_01_DonMuaHang&id=null&id_sel=&module_select=1',
                editurl: '',
                height: window.innerHeight / 2 - 160,
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
                pager: '#pager' + namegrid,
                onSelectRow: function (ids) {
                    if (ids != '<a style=\'color:red\'>Not data (404)</a>') {
                        cell = $('#' + namegrid).getRowData(ids);
                        if ($('#' + id_elem).prop('disabled') != true) {
                            $('#' + id_elem).val(cell['sochungtu']);
                            $('#' + id_elem + '_id').val(cell['c_donmuahang_id']);
                        }
                        id_gridMD_00_DMHHVT_cp = ids;
                        $(`#${namegrid}_child`)[0].triggerToolbar();
                    }
                },
                colModel: [
                    { key: true, fixed: true, label: 'c_donmuahang_id', name: 'c_donmuahang_id', index: ' dmh.c_donmuahang_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, formoptions: { label: 'c_donmuahang_id' } },
                    { key: false, fixed: true, label: 'Trạng thái', name: 'md_trangthai_id', index: ' dmh.md_trangthai_id ', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, formatter: Frm_MD_00_KHDHJQGS_trangthai, unformat: disable_formatter, align: 'left', stype: 'select', searchoptions: { sopt: ['bw'], value: { '': '', 'SOANTHAO': 'Soạn thảo', 'HIEULUC': 'Hiệu lực' } }, edittype: 'select', editoptions: { value: { 'SOANTHAO': 'Soạn thảo', 'HIEULUC': 'Hiệu lực' } }, frozen: false, formoptions: { label: 'Trạng thái' } },
                    { key: false, fixed: true, label: 'Số Chứng Từ', name: 'sochungtu', index: ' dmh.sochungtu ', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 50 }, frozen: false, formoptions: { label: 'Số Chứng Từ' } },
                    { key: false, fixed: true, label: 'Phiếu nhập kho', name: 'phieunhapkho', index: 'dmh.phieunhapkho', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'center', stype: 'select', searchoptions: { sopt: ['eq'], value: { '': '', ' ': 'Chưa tạo phiếu', 'Đã tạo phiếu': 'Đã tạo phiếu', 'Đã nhập kho': 'Đã nhập kho' } }, frozen: false, formoptions: { label: 'Phiếu nhập kho' } },
                    { key: false, fixed: true, label: 'Đơn hàng tham chiếu', name: 'donhang_thamchieu', index: ' dmh.donhang_thamchieu ', width: 120, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 150 }, frozen: false, formoptions: { label: 'Đơn hàng tham chiếu' } },
                    { key: false, fixed: true, label: 'CT Kế Hoạch mua VT', name: 'sctkehoach', index: 'dmh.sctkehoach', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'CT Kế Hoạch mua VT' } },
                ],
                postData: {
                    where_ex: function () {
                        return " and (dmh.md_trangthai_id = 'HIEULUC' or dmh.md_trangthai_id = 'CHUAXONG')";
                    }
                },
                beforeRequest: function () {
                    //giữ focus
                    if ($('#' + id_elem).val() != '' & load_sp == 0) {
                        $('#' + namegrid).jqGrid('getGridParam', 'postData').filters = '{"groupOp":"AND","rules":[{"field":" dmh.sochungtu ","op":"eq","data":"' + $('#' + id_elem).val() + '"}]}';
                    }
                    input_focus = $('input:focus').attr('class');
                },
                ondblClickRow: function () {
                    $('#dlg_gridSmal_2').dialog('destroy').remove();
                },
                gridComplete: function () {
                    $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
                },
                loadComplete: function (data) {
                    var top_rowid = $('#' + namegrid + ' tr:nth-child(2)').attr('id');
                    var countrow = jQuery("#" + namegrid).jqGrid('getGridParam', 'records');
                    if (load_sp == 0) {
                        $('.gs_sochungtu.gs_' + namegrid).val($('#' + id_elem).val());
                        $('#' + namegrid).jqGrid('setSelection', $('#' + id_elem).val());
                        load_sp = 1;
                        if (top_rowid.indexOf('<a style=\'color:red\'>') <= -1 & type == 1 & countrow == 1) {
                            $('#dlg_gridSmal_2').dialog('destroy').remove();
                        }
                    }
                    Focus_Selection(namegrid);
                    //giữ focus end
                    $('.' + input_focus).focus();
                },
                caption: ' '
            });
            jQuery('#' + namegrid).jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });

            //luoi 2
            jQuery(`#${namegrid}_child`).jqGrid({
                url: 'Controller/JqGrid/JQGridMD_01_DongMuaHangTatCaLoad.ashx?ma_module=MD_01_DongMuaHangBS&ma_menu=MN_01_MuaHang&module_select=1&id_sel=1',
                height: window.innerHeight / 2 - 160,
                autowidth: true,
                datatype: 'json',
                shrinkToFit: true,
                rownumbers: true,
                viewrecords: true,
                search: true,
                scroll: false,
                rowNum: 50,
                multiselect: false,
                multiboxonly: false,
                rowList: [1000],
                pager: `pager${namegrid}_child`,
                onSelectRow: function (ids) {

                },
                colModel: [
                    { key: true, fixed: true, label: 'c_donmuahang_cdmh_id', name: 'c_donmuahang_cdmh_id', index: ' cdmh.c_donmuahang_cdmh_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'c_donmuahang_cdmh_id' } },
                    { key: false, fixed: true, label: 'c_donmuahang_id', name: 'c_donmuahang_id', index: ' cdmh.c_donmuahang_id ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'c_donmuahang_id' } },
                    { key: false, fixed: true, label: 'Mã hàng', name: 'md_sanpham_id', index: 'sp.ma_sanpham', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { dataInit: function (elem) { format_vattuBTPvaSP(elem); } }, frozen: false, formoptions: { label: 'Mã hàng' } },
                    { key: false, fixed: true, label: 'Đơn Vị Tính', name: 'md_donvitinhsanpham_id', index: 'cdmh.md_donvitinhsanpham_id', width: 100, editable: true, editrules: { edithidden: true }, hidden: false, align: 'center', stype: 'select', searchoptions: { sopt: ['bw'], value: { '': '', 'B0CADF6A7EAB4F049B430FF7EFDD5B45': 'bao', 'B39508EBF37A4FC6A3F72272CCDEC9D3': 'Bich', '1911AA5855294C16BE66E56D4B2452A1': 'binh', 'C658EC9C5D4D489E8D468B4786597C8B': 'Bình', 'C6902C484D7C42E5A0053AEDD4083B20': 'BO', 'EA4E867353894D6585E527B6AE746290': 'Bộ', '5D5A82D50B444A8495D32FB8D52716D1': 'Bon', '93662926846A45908A31D15C9CA546ED': 'cai', '3C6BD157D2C744DDB40FED430FA5AD12': 'Cái', 'FDDD80724440433E9101B449462D5A06': 'Cay', '7F078B119A9549A98CBC53D7090C1D63': 'Cây', 'C98AB69DDB8347EDBE83033C5121058F': 'Chai', '9A1496BF55E04C46845F14B79CDD15DF': 'Con', '3EC612D6A8BE419D9E5234D8AC760A3E': 'Cục', 'CFB742A9141F4431881369B65B60343D': 'Cuon', '4EF5272F159643C3B8E12B8B860AE9E8': 'Cuộn', '87AF5D27A7C64072AB84E73E60B6EE83': 'Dây', 'D2A7BD11E7434774AC6E78E433F1CCA5': 'Doi', 'CF92EE9615AA4319A47557BFD0A32E94': 'Đôi', '922268EF47734BD094ECFD2E816E3196': 'gam', '212F8315EBA84C2688BF3C96FA1A4518': 'Hop', '00E6D6D5AF254645AD1AFAB7FF9EC7E3': 'Kg', 'F7A99A0F2CF24FBCBB55B6DC73D482DD': 'khung', '68FFFE9AB5EF4531972B82E78C1F1457': 'Lít', 'B8BF8A890627472C97DF78E0C0593159': 'Lố', 'BCDE67CC992F4689BA09C6776CD7F5D8': 'Lọ', 'A9188839AD8C4200842CBBFD1B2ECC87': 'm', 'BFDD1E869A274F54A62FFF17FE37CCCE': 'm2', '82BB86D1D2204A689871308CF329588B': 'M3', '91E46CC2598C4111AD223F47F4A1A763': 'Met', 'CD418A38920A4E7C91B9AC447B99999E': 'Mét', '7d1c5224937b0f0b45bf7789fe41274b': 'pc', '4c08913293d66145064e50475e016456': 'set', '50549B67BF7341D4AB507C18F2B0A896': 'SOI', 'FC643CEC8DBF4B81824C45C51C7E3163': 'Sợi', 'BF88068E6CA349139590AEF401E1CAD4': 'TAM', '3635630D77384D2191672A1AB571EF4E': 'Tấm', 'B9DEABAAFA074A1BAB763C28EA551842': 'THANH', 'E7741B8A7C7B4AF5B9B814FA3AA53D24': 'Thanh', '7DC2501158CA41FA88095C466A4931E1': 'To', '3B4B27A706A5489B93076847F46E63DA': 'Tuýp', 'AC285AAC7392491792E50330075F81B9': 'Vien', '70450FE48161485DA9246881965867EB': 'Viên' } }, edittype: 'select', editoptions: { value: { '': '', 'B0CADF6A7EAB4F049B430FF7EFDD5B45': 'bao', 'B39508EBF37A4FC6A3F72272CCDEC9D3': 'Bich', '1911AA5855294C16BE66E56D4B2452A1': 'binh', 'C658EC9C5D4D489E8D468B4786597C8B': 'Bình', 'C6902C484D7C42E5A0053AEDD4083B20': 'BO', 'EA4E867353894D6585E527B6AE746290': 'Bộ', '5D5A82D50B444A8495D32FB8D52716D1': 'Bon', '93662926846A45908A31D15C9CA546ED': 'cai', '3C6BD157D2C744DDB40FED430FA5AD12': 'Cái', 'FDDD80724440433E9101B449462D5A06': 'Cay', '7F078B119A9549A98CBC53D7090C1D63': 'Cây', 'C98AB69DDB8347EDBE83033C5121058F': 'Chai', '9A1496BF55E04C46845F14B79CDD15DF': 'Con', '3EC612D6A8BE419D9E5234D8AC760A3E': 'Cục', 'CFB742A9141F4431881369B65B60343D': 'Cuon', '4EF5272F159643C3B8E12B8B860AE9E8': 'Cuộn', '87AF5D27A7C64072AB84E73E60B6EE83': 'Dây', 'D2A7BD11E7434774AC6E78E433F1CCA5': 'Doi', 'CF92EE9615AA4319A47557BFD0A32E94': 'Đôi', '922268EF47734BD094ECFD2E816E3196': 'gam', '212F8315EBA84C2688BF3C96FA1A4518': 'Hop', '00E6D6D5AF254645AD1AFAB7FF9EC7E3': 'Kg', 'F7A99A0F2CF24FBCBB55B6DC73D482DD': 'khung', '68FFFE9AB5EF4531972B82E78C1F1457': 'Lít', 'B8BF8A890627472C97DF78E0C0593159': 'Lố', 'BCDE67CC992F4689BA09C6776CD7F5D8': 'Lọ', 'A9188839AD8C4200842CBBFD1B2ECC87': 'm', 'BFDD1E869A274F54A62FFF17FE37CCCE': 'm2', '82BB86D1D2204A689871308CF329588B': 'M3', '91E46CC2598C4111AD223F47F4A1A763': 'Met', 'CD418A38920A4E7C91B9AC447B99999E': 'Mét', '7d1c5224937b0f0b45bf7789fe41274b': 'pc', '4c08913293d66145064e50475e016456': 'set', '50549B67BF7341D4AB507C18F2B0A896': 'SOI', 'FC643CEC8DBF4B81824C45C51C7E3163': 'Sợi', 'BF88068E6CA349139590AEF401E1CAD4': 'TAM', '3635630D77384D2191672A1AB571EF4E': 'Tấm', 'B9DEABAAFA074A1BAB763C28EA551842': 'THANH', 'E7741B8A7C7B4AF5B9B814FA3AA53D24': 'Thanh', '7DC2501158CA41FA88095C466A4931E1': 'To', '3B4B27A706A5489B93076847F46E63DA': 'Tuýp', 'AC285AAC7392491792E50330075F81B9': 'Vien', '70450FE48161485DA9246881965867EB': 'Viên' } }, frozen: false, formoptions: { label: 'Đơn Vị Tính' } },
                    { key: false, fixed: true, label: 'Số lượng đặt mua', name: 'sl_dadat', index: ' cdmh.sl_dadat ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'right', searchoptions: { sopt: ['en'], dataInit: function (elem) { search_number(elem); } }, editoptions: { defaultValue: '0', dataInit: function (elem) { format_number(elem, 0, 4); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: 'Số lượng đặt mua' } },
                    { key: false, fixed: true, label: 'sl_dadat2', name: 'sl_dadat2', index: 'cdmh.sl_dadat2', width: 100, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'sl_dadat2' } },
                    { key: false, fixed: true, label: 'saiso', name: 'saiso', index: 'cdmh.saiso', width: 100, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, frozen: false, formoptions: { label: 'saiso' } },
                    { key: false, fixed: true, label: 'Đơn giá mua', name: 'dongiamua', index: ' cdmh.dongiamua ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'right', searchoptions: { sopt: ['en'], dataInit: function (elem) { search_number(elem); } }, editoptions: { defaultValue: '0', dataInit: function (elem) { format_number(elem); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: 'Đơn giá mua' } },
                    { key: false, fixed: true, label: 'Giá chuẩn', name: 'giachuan', index: ' cdmh.giachuan ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'right', searchoptions: { sopt: ['en'], dataInit: function (elem) { search_number(elem); } }, editoptions: { defaultValue: '0', dataInit: function (elem) { format_number(elem, 0); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: 'Giá chuẩn' } },
                    { key: false, fixed: true, label: 'Có hạn sử dụng', name: 'co_ngayhethan', index: 'sp.co_ngayhethan', width: 100, editable: true, editrules: { edithidden: true }, hidden: true, formatter: 'checkbox', align: 'left', searchoptions: { sopt: ['bw'] }, edittype: 'checkbox', editoptions: { value: 'True:False', defaultValue: 'False' }, frozen: false, formoptions: { label: 'Có hạn sử dụng' } },
                    { key: false, fixed: true, label: 'Hạn sử dụng', name: 'ngay_hethan', index: 'cdmh.ngay_hethan', width: 100, editable: false, hidden: true, formatter: esc_date, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: 'Hạn sử dụng' } },
                    { key: false, fixed: true, label: 'Thuế', name: 'thue', index: 'thue_sp.ten_thue_sanpham', width: 80, editable: true, editrules: { edithidden: true }, hidden: false, align: 'center', searchoptions: { sopt: ['bw'] }, edittype: 'select', editoptions: { value: { '': '', 'D88CA4414A02404A9FABF19F97911712': 'VAT00', 'C801350449DD4C26B0551D3B49AB57C6': 'VAT05', 'FBA43F3375D3443CAA2F5370A4152A25': 'VAT10', '2FEA566266A64689B55200486414EAC9': 'VATZR' } }, frozen: false, formoptions: { label: 'Thuế' } },
                    { key: false, fixed: true, label: 'Thành tiền', name: 'thanhtien', index: ' cdmh.thanhtien ', width: 110, editable: true, editrules: { edithidden: true }, hidden: false, formatter: vnn_number, unformat: disable_formatter, align: 'right', searchoptions: { sopt: ['en'], dataInit: function (elem) { search_number(elem); } }, editoptions: { defaultValue: '0', dataInit: function (elem) { format_number(elem, 0); } }, frozen: false, formatoptions: { decimalSeparator: vnn_formatnumber()[0], thousandsSeparator: vnn_formatnumber()[1], decimalPlaces: 'auto', suffix: '' }, formoptions: { label: 'Thành tiền' } },
                    { key: false, fixed: true, label: 'sapxep', name: 'sapxep', index: ' cdmh.sapxep ', width: 120, editable: false, hidden: true, align: 'left', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 10 }, frozen: false, formoptions: { label: 'sapxep' } },
                    { key: false, fixed: true, label: 'Người tạo HT', name: 'nguoitao', index: ' cdmh.nguoitao ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Người tạo HT' } },
                    { key: false, fixed: true, label: 'Vai trò tạo HT', name: 'vaitrotao', index: ' cdmh.vaitrotao ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Vai trò tạo HT' } },
                    { key: false, fixed: true, label: 'Bộ phận tạo HT', name: 'bophantao', index: ' cdmh.bophantao ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Bộ phận tạo HT' } },
                    { key: false, fixed: true, label: 'Người cập nhật HT', name: 'nguoicapnhat', index: ' cdmh.nguoicapnhat ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Người cập nhật HT' } },
                    { key: false, fixed: true, label: 'Vai trò cập nhật HT', name: 'vaitrocapnhat', index: ' cdmh.vaitrocapnhat ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Vai trò cập nhật HT' } },
                    { key: false, fixed: true, label: 'Bộ phận cập nhật HT', name: 'bophancapnhat', index: ' cdmh.bophancapnhat ', width: 95, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 32 }, frozen: false, formoptions: { label: 'Bộ phận cập nhật HT' } },
                    { key: false, fixed: true, label: 'Người tạo', name: 'value_nguoitao', index: ' cdmh.value_nguoitao ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 150 }, frozen: false, formoptions: { label: 'Người tạo' } },
                    { key: false, fixed: true, label: 'Vai trò tạo', name: 'value_vaitrotao', index: ' cdmh.value_vaitrotao ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 150 }, frozen: false, formoptions: { label: 'Vai trò tạo' } },
                    { key: false, fixed: true, label: 'Bộ phận tạo', name: 'value_bophantao', index: ' cdmh.value_bophantao ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 150 }, frozen: false, formoptions: { label: 'Bộ phận tạo' } },
                    { key: false, fixed: true, label: 'Người cập nhật', name: 'value_nguoicapnhat', index: ' cdmh.value_nguoicapnhat ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 150 }, frozen: false, formoptions: { label: 'Người cập nhật' } },
                    { key: false, fixed: true, label: 'Vai trò cập nhật', name: 'value_vaitrocapnhat', index: ' cdmh.value_vaitrocapnhat ', width: 90, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 150 }, frozen: false, formoptions: { label: 'Vai trò cập nhật' } },
                    { key: false, fixed: true, label: 'Bộ phận cập nhật', name: 'value_bophancapnhat', index: ' cdmh.value_bophancapnhat ', width: 95, editable: false, hidden: true, align: 'center', searchoptions: { sopt: ['bw'] }, editoptions: { maxLength: 150 }, frozen: false, formoptions: { label: 'Bộ phận cập nhật' } },
                    { key: false, fixed: true, label: 'Ngày tạo', name: 'ngaytao', index: ' cdmh.ngaytao ', width: 90, editable: false, hidden: true, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: 'Ngày tạo' } },
                    { key: false, fixed: true, label: 'Ngày cập nhật', name: 'ngaycapnhat', index: ' cdmh.ngaycapnhat ', width: 90, editable: false, hidden: true, formatter: esc_date, align: 'center', searchoptions: { sopt: ['cn'], dataInit: function (elem) { search_datetime(elem); } }, editoptions: { dataInit: function (elem) { format_datetime(elem); } }, frozen: false, formatoptions: { srcformat: 'm/d/Y', newformat: format_srcdatetime() }, formoptions: { label: 'Ngày cập nhật' } },
                    { key: false, fixed: true, label: 'Mô tả', name: 'mota', index: ' cdmh.mota ', width: 150, editable: true, editrules: { edithidden: true }, hidden: false, align: 'left', searchoptions: { sopt: ['bw'] }, edittype: 'textarea', frozen: false, formoptions: { label: 'Mô tả' } },
                    { key: false, fixed: true, label: 'Hoạt động', name: 'hoatdong', index: ' cdmh.hoatdong ', width: 75, editable: false, hidden: true, formatter: 'checkbox', align: 'center', stype: 'select', searchoptions: { sopt: ['bw'], value: ':Tất cả;1:Có;0:Không' }, edittype: 'checkbox', editoptions: { value: 'True:False', defaultValue: 'False' }, frozen: false, formoptions: { label: 'Hoạt động' } },
                ],
                beforeRequest: function () {
                    $(`#${namegrid}_child`).jqGrid('getGridParam', 'postData').id = id_gridMD_00_DMHHVT_cp;
                },
                ondblClickRow: function () {

                },
                gridComplete: function () {
                    $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
                },
                loadComplete: function (data) {
                    //giữ focus end
                    $('.' + input_focus).focus();
                },
                caption: 'Dòng mua hàng'
            });
            jQuery(`#${namegrid}_child`).jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });
            $(`#gview_${namegrid}_child .ui-jqgrid-title`).css('float', 'left');
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
//End Nhap kho tu NCC