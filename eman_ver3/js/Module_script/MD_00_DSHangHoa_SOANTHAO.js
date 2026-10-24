//Add function at here (don't remove this line, please)

//start CA01ImportHHVG_MD00DSHangHoaSOANTHAO
function CA01ImportHHVG_MD00DSHangHoaSOANTHAO(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    let masterId = $(`#${tengrid}`).jqGrid('getGridParam', 'selrow');

    let CLform_infor = new get_Forminfor(ma_case, Form_infor);
    let ma_module = tengrid.replace('grid', '');
    $('body').append(`
            <div id="dlg_gridSmall" title="${CLform_infor.tieude}">
                <div class="dlg_content">
                    <input id="fileExcel" type="file" value="Chọn tập tin excel" accept=".xls,.xlsx" />
                    <a style="float:right;color:blue;cursor:pointer;" target="_blank" a-link="file_importTemp/BS012 - Cập nhật hàng hóa soạn thảo.xls">Tải về mẫu nhập liệu</a>
                    <div class="divResult"></div>
                </div>
            </div>
        `);
    let $div = $('#dlg_gridSmall'), $divRS = $div.find('.divResult');
    let $btnSelFile = $('#fileExcel');
    let $btnSavFile = $btnSelFile.next();
    let taptin = null;
    let jsonFromFile = [];
    $div.dialog({
        modal: true,
        width: window.innerWidth >= 650 ? 600 : window.innerWidth - 50,
        height: window.innerHeight / 2,
        open: function (event, ui) {

            $btnSavFile.click(function () {
                modify_code($(this).attr('a-link'));
            });

            $btnSelFile.click(function () {
                $btnSelFile.val('');
            });
            $btnSelFile.change(function () {
                try {
                    let trTHall = ``, trTDall = ``;
                    taptin = this.files[0];
                    excelToJSON.parseExcel(taptin, function () {
                        let json = excelToJSON.json[0];
                        jsonFromFile = json;
                        let columns = [];
                        for (let i in json) {
                            let row = json[i];

                            if (columns.length <= 0)
                                columns = Object.keys(row);

                            let trTH = ``, trTD = ``,
                                thS = 'border-width:thin; border-style:solid; padding:3px;',
                                tdS = 'border-width:thin; border-style:solid; padding:3px;';
                            for (let ic in columns) {
                                let cn = columns[ic];
                                if (i == 0)
                                    trTH += `<th style="${thS}">${cn}</th>`;

                                trTD += `<td style="${tdS}">${typeof (row[cn]) == 'undefined' ? "" : row[cn]}</td>`;
                            }

                            if (i == 0)
                                trTHall = `<tr>${trTH}<th style="${thS}; width:15%;">Kết quả</th></tr>`;
                            trTDall += `<tr>${trTD}<td style="${tdS}" idkq='${i}'></td></tr>`;
                        }
                        $divRS.html(`<table style="width:100%;">${trTHall}${trTDall}</table>`);
                        $('#btn-ok').button('option', 'disabled', false);
                    });
                }
                catch (r) {
                    taptin = null;
                    jsonFromFile = [];
                    $divRS.html('');
                }
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
                    if (jsonFromFile.length <= 0) {
                        alert('Hãy chọn 1 tập tin');
                        return;
                    }

                    let data_js = new FormData();
                    data_js.append("id_parent", id_parent);
                    data_js.append("taptin", taptin);
                    data_js.append("json", JSON.stringify(jsonFromFile));
                    $divRS.prepend('<div class="nhan_loading"></div>');
                    $('#btn-ok').button('option', 'disabled', true);
                    $btnSelFile.prop('disabled', true);
                    $.ajax({
                        url: `Controller/JQGridModify/JQGrid${ma_module}Modify.ashx?oper=${ma_case}&ma_module=${ma_module}`,
                        type: 'POST',
                        data: data_js,
                        processData: false,
                        contentType: false,
                        success: function (data) {
                            $divRS.find('.nhan_loading').remove();
                            data = JSON.parse(data);
                            let hasErr = false;
                            for (let i in data) {
                                let $tdKQ = $divRS.find(`td[idkq="${i}"]`);
                                $tdKQ.html(data[i]);
                                if ($tdKQ.children('div[error]').length > 0)
                                    hasErr = true;
                            }

                            //$('#btn-ok').button('option', 'disabled', false);
                            $btnSelFile.prop('disabled', false);

                            $divRS.children('.divRS_rs').remove();
                            if (!hasErr) {
                                $divRS.append(`<div class='divRS_rs' style='color:blue;'>Nhập liệu thành công</div>`);
                                loadclick(tengrid, 'edit', load_stt);
                                Close_Form($div, CLform_infor.dongform);
                            }
                            else {
                                $divRS.append(`<div class='divRS_rs' style='color:red;'>Nhập liệu thất bại</div>`);
                            }
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
//end CA01ImportHHVG_MD00DSHangHoaSOANTHAO

//start CA01ExportHHVG_MD00DSHangHoaSOANTHAO
// Export TẤT CẢ hàng đang hiển thị theo quyền và bộ lọc jqGrid, không đòi selrow.
// File .xls được server tạo trực tiếp và tải qua POST; không lưu workbook vào Session.
function CA01ExportHHVG_MD00DSHangHoaSOANTHAO(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var $grid = $('#' + tengrid);
    var postData = $.extend({}, $grid.jqGrid('getGridParam', 'postData'));
    var filters = typeof postData.filters === 'string'
        ? postData.filters : JSON.stringify(postData.filters || {});
    var request = {
        filters: filters,
        id: postData.id || (id_parent || ''),
        where_ex: postData.where_ex || '',
        sidx: $grid.jqGrid('getGridParam', 'sortname') || '',
        sord: $grid.jqGrid('getGridParam', 'sortorder') || ''
    };
    var ma_module = 'MD_00_DSHangHoa_SOANTHAO';
    var url = 'Controller/JQGridModify/JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx?oper='
        + encodeURIComponent(ma_case) + '&ma_module=' + encodeURIComponent(ma_module);
    var formInfo = new get_Forminfor(ma_case, Form_infor);
    var $dialog = $('<div id="dlg_ExportHHVG_SOANTHAO"><div class="dlg_content">Đang kiểm tra số lượng hàng hóa...</div></div>');
    var snapshot = null, count = 0, busy = false;

    function showError(message) {
        $dialog.find('.dlg_content').text(message || 'Không thể xuất Excel.');
        $dialog.parent().find('.ui-dialog-buttonpane #btn-export-hhvg')
            .button('option', 'disabled', true);
    }
    $('body').append($dialog);
    $dialog.dialog({
        title: formInfo.tieude,
        modal: true,
        resizable: false,
        width: Math.min(550, $(window).width() - 40),
        open: function () {
            Logo_Center(formInfo.logo, formInfo.canhgiua, null, 'btn-export-hhvg', 'btn-close-export-hhvg');
            var $button = $dialog.parent().find('.ui-dialog-buttonpane #btn-export-hhvg');
            $button.button('option', 'disabled', true);
            $.ajax({
                url: url,
                type: 'POST',
                dataType: 'json',
                data: $.extend({}, request, { mode: 'preview' })
            }).done(function (result) {
                if (!result || !result.ok) {
                    showError(result && result.message);
                    return;
                }
                count = result.count || 0;
                snapshot = result.snapshot;
                var $content = $dialog.find('.dlg_content').empty();
                $('<p>').text('Số hàng hóa SOANTHAO theo bộ lọc, bao gồm tất cả các trang: ' + count + '.').appendTo($content);
                $('<p>').text('Tệp Excel 97-2003 (.xls), 37 cột đúng mẫu, không có 4 cột ẩn.').appendTo($content);
                if (!filters || filters === '{}' || filters === '{"groupOp":"AND","rules":[]}') {
                    $('<p>').text('Chưa áp dụng bộ lọc: sẽ xuất toàn bộ dữ liệu được phép xem.').appendTo($content);
                }
                if (count === 0) {
                    $('<p>').text('Không có dữ liệu để xuất.').appendTo($content);
                }
                $button.button('option', 'disabled', count === 0);
            }).fail(function (xhr) {
                showError('Không kiểm tra được dữ liệu xuất Excel. ' + (xhr.responseJSON && xhr.responseJSON.message || ''));
            });
        },
        close: function () {
            $(this).dialog('destroy').remove();
        },
        buttons: [
            {
                id: 'btn-export-hhvg',
                text: 'Xuất Excel',
                click: function () {
                    if (busy || !snapshot || count === 0) return;
                    busy = true;
                    var $button = $dialog.parent().find('.ui-dialog-buttonpane #btn-export-hhvg');
                    $button.button('option', 'disabled', true);
                    $dialog.find('.dlg_content').append('<div class="nhan_loading"></div>');
                    var xhr = new XMLHttpRequest();
                    xhr.open('POST', url, true);
                    xhr.responseType = 'blob';
                    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
                    xhr.onload = function () {
                        $dialog.find('.nhan_loading').remove();
                        if (xhr.status === 200 && (xhr.getResponseHeader('Content-Type') || '').indexOf('application/vnd.ms-excel') >= 0) {
                            var name = 'Danh sach hang hoa.xls';
                            var disposition = xhr.getResponseHeader('Content-Disposition') || '';
                            var match = disposition.match(/filename="?([^";]+)"?/i);
                            if (match && match[1]) name = match[1];
                            var blobUrl = URL.createObjectURL(xhr.response);
                            var link = document.createElement('a');
                            link.href = blobUrl;
                            link.download = name;
                            document.body.appendChild(link);
                            link.click();
                            document.body.removeChild(link);
                            window.setTimeout(function () { URL.revokeObjectURL(blobUrl); }, 1000);
                            $dialog.dialog('close');
                            return;
                        }
                        if (xhr.response && window.FileReader) {
                            var reader = new FileReader();
                            reader.onload = function () { showError(reader.result || 'Không tải được file Excel.'); };
                            reader.readAsText(xhr.response);
                        } else {
                            showError('Máy chủ trả lỗi khi xuất Excel.');
                        }
                        busy = false;
                    };
                    xhr.onerror = function () {
                        $dialog.find('.nhan_loading').remove();
                        showError('Lỗi mạng trong khi tải Excel. Hãy thử lại.');
                        busy = false;
                    };
                    xhr.send($.param($.extend({}, request, { mode: 'download', snapshot: snapshot })));
                }
            },
            {
                id: 'btn-close-export-hhvg',
                text: 'Thoát',
                click: function () {
                    if (!busy) $(this).dialog('close');
                }
            }
        ]
    });
}
//end CA01ExportHHVG_MD00DSHangHoaSOANTHAO

//start CA_01_ChuyenTrangThaiST
// Chuyển TẤT CẢ hàng hóa trong kết quả lọc jqGrid (mọi trang), không chỉ selrow/selarrrow.
function CA_01_ChuyenTrangThaiST(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var $grid = $('#' + tengrid);
    var postData = $.extend({}, $grid.jqGrid('getGridParam', 'postData'));
    var filters = typeof postData.filters === 'string' ? postData.filters : JSON.stringify(postData.filters || {});
    var request = {
        filters: filters,
        id: postData.id || (id_parent || ''),
        where_ex: postData.where_ex || '',
        mode: 'preview'
    };
    var ma_module = 'MD_00_DSHangHoa_SOANTHAO';
    var url = 'Controller/JQGridModify/JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx?oper='
        + encodeURIComponent(ma_case) + '&ma_module=' + encodeURIComponent(ma_module);
    var CLform_infor = new get_Forminfor(ma_case, Form_infor);
    var $dlg = $('<div id="dlg_ChuyenTrangThaiST" title="' + CLform_infor.tieude + '"><div class="dlg_content">Đang kiểm tra kết quả lọc...</div></div>');
    var preview = null;
    var busy = false;

    function showError(message) {
        $dlg.find('.dlg_content').text(message || 'Không thể thực hiện thao tác.');
        $dlg.parent().find('.ui-dialog-buttonpane #btn-chuyen-dhd').button('option', 'disabled', true);
    }

    $('body').append($dlg);
    $dlg.dialog({
        modal: true,
        width: 540,
        resizable: false,
        open: function () {
            Logo_Center(CLform_infor.logo, CLform_infor.canhgiua, null, 'btn-chuyen-dhd', 'btn-thoat-dhd');
            var $confirm = $dlg.parent().find('.ui-dialog-buttonpane #btn-chuyen-dhd');
            $confirm.button('option', 'disabled', true);
            $.ajax({
                url: url, type: 'POST', dataType: 'json', data: request
            }).done(function (result) {
                if (!result.ok) {
                    showError(result.message);
                    return;
                }
                preview = result;
                var $content = $dlg.find('.dlg_content').empty();
                $('<p>').text('Toàn bộ kết quả lọc (bao gồm các trang jqGrid khác): ' + result.total + ' hàng hóa.').appendTo($content);
                $('<p>').text('Đang Soạn thảo, đủ điều kiện chuyển sang DHD: ' + result.eligible + '.').appendTo($content);
                $('<p>').text('Không ở trạng thái Soạn thảo (sẽ giữ nguyên): ' + result.skipped + '.').appendTo($content);
                $('<p style="color:#a94442;font-weight:bold">').text('Xác nhận chuyển ' + result.eligible + ' hàng hóa sang hiệu lực (DHD)?').appendTo($content);
                $confirm.button('option', 'disabled', result.eligible === 0);
            }).fail(function () {
                showError('Không thể kiểm tra bộ lọc trên máy chủ. Vui lòng thử lại.');
            });
        },
        close: function () { $(this).dialog('destroy').remove(); },
        buttons: [
            {
                id: 'btn-chuyen-dhd', text: 'Chuyển sang hiệu lực',
                click: function () {
                    if (busy || !preview || !preview.ok || preview.eligible === 0) return;
                    busy = true;
                    $dlg.parent().find('.ui-dialog-buttonpane #btn-chuyen-dhd').button('option', 'disabled', true);
                    $dlg.find('.dlg_content').prepend('<div class="nhan_loading"></div>');
                    $.ajax({
                        url: url, type: 'POST', dataType: 'json',
                        data: $.extend({}, request, { mode: 'execute', snapshot: preview.snapshot })
                    }).done(function (result) {
                        $dlg.find('.nhan_loading').remove();
                        if (result.ok) {
                            alert('Đã chuyển ' + result.changed + ' hàng hóa sang hiệu lực (DHD).');
                            $dlg.dialog('close');
                            loadclick(tengrid, null, load_stt);
                        } else {
                            showError(result.message || 'Chuyển trạng thái thất bại.');
                        }
                    }).fail(function () {
                        showError('Lỗi kết nối trong khi chuyển trạng thái. Hãy tải lại danh sách để kiểm tra trước khi thử lại.');
                    }).always(function () {
                        busy = false;
                    });
                }
            },
            {
                id: 'btn-thoat-dhd', text: 'Thoát', click: function () {
                    if (!busy) $(this).dialog('close');
                }
            }
        ]
    });
}
//end CA_01_ChuyenTrangThaiST
