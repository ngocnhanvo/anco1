//Add function at here (don't remove this line, please)

//start CA_01_BoSungSLChiaTo
function CA_01_BoSungSLChiaTo(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow');
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var ma_module = tengrid.replace('grid', '');
        $('body').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
            '<div class="dlg_content">' +
            '<table>' +
            '<td>Số lượng bổ sung:</td>' +
            '<td width="8px"></td>' +
            '<td><input style="width:100px; padding: 2px 32px 2px 3px; outline:none" type="text" class="input_soluong_bs" value="0"/></td>' +
            '</table>' +
            '</div>' +
            '</div>');
        $('#dlg_gridSmall').dialog({
            modal: true,
            width: CLform_infor.dodai,
            height: CLform_infor.docao,
            open: function (event, ui) {
                format_number($('.input_soluong_bs'), 1);
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
                        $.post('Controller/JQGridModify/JQGridMD_02_TSXcacdonghangModify.ashx?oper=CA_01_BoSungSLChiaTo&ma_module=' + ma_module,
                            { id: masterId.toString(), id_parent: id_parent, sl_bosung: $('.input_soluong_bs').val() }, function (result) {
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
//end CA_01_BoSungSLChiaTo


//start CA_01_CapnhatSPtrongToSX
function CA_01_CapnhatSPtrongToSX(tengrid, id_parent, ma_case, Form_infor, Model_infor, load_stt) {
    var masterId = id_parent;
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
    if (masterId == null | masterId == '') {
        alert('Chưa chọn đối tượng cần thao tác.');
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
                $.get('Controller/JQGridModify/JQGridMD_02_TSXcacdonghangModify.ashx?oper=load_sanpham&id_parent=' + id_parent, function (result) {
                    $('.dlg_content').html(result);
                    format_number($('.input_soluong'), 1);
                    $('.checkall_slchiato').change(function () {
                        if ($(this).prop('checked') == true) {
                            $('.chk_tosx').each(function (index, val) {
                                if (!$(this).hasClass('nhan_disable')) {
                                    $(this).prop('checked', true);
                                }
                            });
                        }
                        else {
                            $('.chk_tosx').each(function (index, val) {
                                if (!$(this).hasClass('nhan_disable')) {
                                    $(this).prop('checked', false);
                                }
                            });
                        }
                    });

                    $('.btn_slchiato').click(function () {
                        $('.chk_tosx').each(function (index, val) {
                            if (!$(this).hasClass('nhan_disable') & $(this).prop('checked') == true) {
                                $(this).parent().next().next().next().children().val($(this).parent().next().next().html());
                            }
                        });
                    });

                    $('.btn_slchiato1').click(function () {
                        $('.chk_tosx').each(function (index, val) {
                            if (!$(this).hasClass('nhan_disable') & $(this).prop('checked') == true) {
                                $(this).parent().next().next().next().children().val($('.input_sl_chiato2').val());
                            }
                        });
                    });
                    Logo_Center(CLform_infor.logo, CLform_infor.canhgiua);
                });
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
                        var id_sel = '', value_slchiato = '';
                        $('.chk_tosx').each(function (index, val) {
                            if ($(this).prop('checked') == true) {
                                id_sel += $(this).val() + ',';
                                value_slchiato += $('.input_' + $(this).val()).val() + ',';
                            }
                        });
                        $.post('Controller/JQGridModify/JQGridMD_02_TSXcacdonghangModify.ashx?oper=CA_01_CapnhatSPtrongToSX&ma_module=' + ma_module,
                            {
                                id: masterId.toString(),
                                id_sel: id_sel,
                                value_slchiato: value_slchiato
                            },
                            function (result) {
                                if (result.indexOf('div') > -1) {
                                    $('.dlg_content').html(result);
                                    $("#" + tengrid0)[0].triggerToolbar();
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
//end CA_01_CapnhatSPtrongToSX

