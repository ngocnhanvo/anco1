//Add function at here (don't remove this line, please)

//start CA_01_XoaPQuyen
function xoaquyen(tengrid, id_parent, ma_case, Form_infor, Model_infor) {
    var masterId = id_parent;
    var grid_small = 'MD_01_PhanQuyen';
    var ma_module = tengrid.replace('grid', '');
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
    if (masterId == null) {
        alert('Chưa chọn vai trò để xóa phân quyền.!');
    }
    else {
        var masterId2 = $('#grid' + grid_small).jqGrid('getGridParam', 'selrow');
        if (masterId2 == null) {
            alert('Hãy chọn một dòng mới có thể xóa quyền.!');
        }
        else {
            var rowData = $('#' + grid_small).getRowData(masterId2);
            var CLform_infor = new get_Forminfor(ma_case, Form_infor);
            $('.cl_table_noidung').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '"><span>Bạn muốn tước bỏ quyền này đối với vai trò đã chọn ???</span></div>');

            $('#dlg_gridSmall').dialog({
                modal: true,
                width: CLform_infor.dodai,
                height: CLform_infor.docao,
                open: function (event, ui) {
                    Logo_Center(CLform_infor.logo, CLform_infor.canhgiua);
                    $('#dlg_gridSmall').removeAttr('style');
                },
                close: function () {
                    $(this).dialog("destroy").remove();
                },
                buttons: [
            {
                id: "btn-ok",
                text: "Đồng ý",
                click: function () {
                    var t_mn = $('#grid' + grid_small).jqGrid("getCell", masterId2, 1);
                    var t_mod = $('#grid' + grid_small).jqGrid("getCell", masterId2, 2);
                    $('#dlg_gridSmall').prepend('<div class="nhan_loading"></div>');
                    $.post('Controller/JQGridModify/JQGrid'+ grid_small +'Modify.ashx?oper=delete', { ad_role_id: masterId, ten_menu: t_mn, ten_module: t_mod }, function (result) {
                        $('#dlg_gridSmall .nhan_loading').remove();
                        if (result.split('#')[0] == "true") {
                            $('#dlg_gridSmall').dialog("destroy").remove();
                        }
                    });
                }
            },

            {
                id: "btn-close",
                text: "Thoát",
                click: function () {
                    $(this).dialog("destroy").remove();
                }
            }
            ]
            });
        }
    }
}
//end CA_01_XoaPQuyen

//start CA_01_PhanQuyen
function phanquyen(tengrid, id_parent, ma_case, Form_infor, Model_infor) {

    var masterId = id_parent;
    var grid_small = 'MD_01_PhanQuyen';
    var ma_module = tengrid.replace('grid', '');
    if (id_parent == null) { masterId = $('#' + tengrid).jqGrid('getGridParam', 'selrow'); }
    if (masterId == null) {
        alert('Chưa chọn vai trò để phân quyền.!');
    }
    else {
        var CLform_infor = new get_Forminfor(ma_case, Form_infor);
        var s = Model_infor;
        var ad_menu_id = "";
        var ad_module_id = "";
        var width_list = 200;
        var height_list = 230;
        var scroll_list = 5;
        $('.cl_table_noidung').append('<div id="dlg_gridSmall" title="' + CLform_infor.tieude + '">' +
                    '<table>' +

                    '<tr style="display:none">' +
                    '<td><div id="selectitem_list_menu"></div></td>' +
                    '<td><div id="selectitem_list_module"></div></td>' +
                    '<td><div id="selectitem_list_case"></div></td>' +
                    '<td><div id="selectitem_list_viewcase"></div></td>' +
                    '</tr>' +

                    '<tr><th>Tên menu</th><th>Tên module</th><th>Tên chức năng</th><th>Dữ liệu được xem</th></tr>' +
                    '<tr><td>' +
                        '<div id="list_menu"></div>' +
                    '</td>' +

                    '<td>' +
                        '<div id="list_module"></div>' +
                    '</td>' +
                    '<td>' +
                         '<div id="list_case"></div>' +
                    '</td>' +
                    '<td>' +
                         '<div id="list_viewcase"></div>' +
                    '</td>' +
                    '</tr></table>' +
                    '</div>');

        $('#dlg_gridSmall').dialog({
            modal: true,
            width: CLform_infor.dodai,
            height: CLform_infor.docao,
            open: function (event, ui) {
                Logo_Center(CLform_infor.logo, CLform_infor.canhgiua);
                $(document).ready(function () {
                    $.get("Controller/JQGridModify/JQGridMD_00_MNZModify.ashx?oper=loadlist", function (result) {
                        var res = result.split("ξ");
                        $("#list_menu").jqxListBox({ selectedIndex: -1, source: res, width: width_list, height: height_list, scrollBarSize: scroll_list });
                        $("#list_module").jqxListBox({ selectedIndex: -1, source: null, width: width_list, height: height_list, scrollBarSize: scroll_list });
                        $("#list_case").jqxListBox({ selectedIndex: -1, source: null, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });
                        $("#list_viewcase").jqxListBox({ selectedIndex: -1, source: null, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });
                    });


                    $('#list_menu').on('select', function (event) {
                        var args = event.args;
                        var item = $('#list_menu').jqxListBox('getItem', args.index);
                        if (item != null) {
                            $("#list_case").jqxListBox({ selectedIndex: -1, source: null, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });
                            $("#list_viewcase").jqxListBox({ selectedIndex: -1, source: null, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });

                            //get id cua menu da chon
                            chenthe('#selectitem_list_menu', item.value);
                            ad_menu_id = $('#selectitem_list_menu a:first').text();
                            //#get id cua menu da chon
                            $.get("Controller/JQGridModify/JQGridMD_01_MDZModify.ashx?oper=loadlist&ad_menu_id=" + ad_menu_id, function (result) {
                                var res = result.split("ξ");
                                $("#list_module").jqxListBox({ selectedIndex: -1, source: res, width: width_list, height: height_list, scrollBarSize: scroll_list });
                            });
                        }
                    });

                    var countcase = 0, countcase_2 = 0;

                    $('#list_module').on('select', function (event) {
                        var args = event.args;
                        var item = $('#list_module').jqxListBox('getItem', args.index);
                        $("#list_case").jqxListBox({ selectedIndex: -1, source: null, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });
                        $("#list_viewcase").jqxListBox({ selectedIndex: -1, source: null, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });
                        if (item != null) {

                            //get id cua menu da chon
                            chenthe('#selectitem_list_module', item.value);
                            ad_module_id = $('#selectitem_list_module a:first').text();
                            //#get id cua menu da chon
                            $.get("Controller/JQGridModify/JQGridMD_02_CASModify.ashx?oper=loadlist&ad_module_id=" + ad_module_id + "&id=" + masterId, function (result) {
                                var res1 = result.split("-")[0];
                                var res2 = result.split("-")[1];

                                countcase = res1.split("ξ").length;
                                countcase2 = res2.split("/").length;
                                res1 = res1.split("ξ");
                                res2 = res2.split("/");

                                $("#list_case").jqxListBox({ selectedIndex: -1, source: res1, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });

                                for (var i = 0; i < countcase2; i++) {
                                    if (res2[i] != "") {
                                        $('#list_case').jqxListBox('checkIndex', Number(res2[i]));
                                    }
                                }

                                $.get("Controller/JQGridModify/JQGridMD_02_CASModify.ashx?oper=loadlist2&ad_module_id=" + ad_module_id + "&id=" + masterId, function (result) {
                                    var res1 = result.split("-")[0];
                                    var res2 = result.split("-")[1];

                                    countcase_2 = res1.split("ξ").length;
                                    countcase2 = res2.split("/").length;
                                    res1 = res1.split("ξ");
                                    res2 = res2.split("/");

                                    $("#list_viewcase").jqxListBox({ selectedIndex: -1, source: res1, checkboxes: true, width: width_list, height: height_list, scrollBarSize: scroll_list });

                                    for (var i = 0; i < countcase2; i++) {
                                        if (res2[i] != "") {
                                            $('#list_viewcase').jqxListBox('checkIndex', Number(res2[i]));
                                        }
                                    }
                                });
                            });
                        }
                    });

                    var nhan = 0;
                    $('#list_case').on('checkChange', function (event) {
                        var args = event.args;

                        if (args.checked) {
                            if (args.label == "Tất cả") {
                                for (var dem = 1; dem < countcase; dem++) {
                                    $('#list_case').jqxListBox('checkIndex', dem);
                                }
                                nhan = 0;
                            }
                            else {

                            }

                        }
                        else {

                            if (args.label == "Tất cả") {

                                if (nhan <= 0) {
                                    for (var dem = 1; dem < countcase; dem++) {
                                        $('#list_case').jqxListBox('uncheckIndex', dem);
                                    }
                                }
                            }
                            else {
                                nhan++;
                                if (nhan > 0)
                                { $('#list_case').jqxListBox('uncheckIndex', 0); }
                            }

                        }
                    });

                    var nhan2 = 0;
                    $('#list_viewcase').on('checkChange', function (event) {
                        var args = event.args;

                        if (args.checked) {
                            if (args.label == "Tất cả") {
                                for (var dem = 1; dem < countcase_2; dem++) {
                                    $('#list_viewcase').jqxListBox('checkIndex', dem);
                                }
                                nhan2 = 0;
                            }
                            else {

                            }

                        }
                        else {

                            if (args.label == "Tất cả") {

                                if (nhan2 <= 0) {
                                    for (var dem = 1; dem < countcase_2; dem++) {
                                        $('#list_viewcase').jqxListBox('uncheckIndex', dem);
                                    }
                                }
                            }
                            else {
                                nhan2++;
                                if (nhan2 > 0)
                                { $('#list_viewcase').jqxListBox('uncheckIndex', 0); }
                            }

                        }
                    });

                });
            },
            close: function () {
                $(this).dialog("destroy").remove();
            },
            buttons: [
            {
                id: "btn-ok",
                text: "Đồng ý",
                click: function () {
                    $('#dlg_gridSmall').prepend('<div class="nhan_loading"></div>');
                    $('#dlg_gridSmall .ui-state-error').remove();
                    $('#dlg_gridSmall .nhan-thanhcong').remove();

                    var items = $('#list_case').jqxListBox('getCheckedItems');
                    var ad_case_id = "";
                    for (var it in items) {
                        //get id cua case da chon
                        chenthe('#selectitem_list_menu', items[it].value);
                        ad_case_id += $('#selectitem_list_menu a:first').text() + "#";
                        //#get id cua case da chon
                    }

                    items = $('#list_viewcase').jqxListBox('getCheckedItems');
                    var ad_case_id2 = "";
                    for (var it in items) {
                        //get id cua viewcase da chon
                        chenthe('#selectitem_list_menu', items[it].value);
                        ad_case_id2 += $('#selectitem_list_menu a:first').text() + "#";
                        //#get id cua viewcase da chon
                    }
                    $.post('Controller/JQGridModify/JQGrid'+ grid_small +'Modify.ashx?oper=phanquyen', { ad_menu_id: ad_menu_id, ad_module_id: ad_module_id, ad_case_id: ad_case_id, ad_case_id2: ad_case_id2, id: masterId }, function (result) {
                        $('#dlg_gridSmall .nhan_loading').remove();
                        $('#dlg_gridSmall').prepend(result);
                    });
                }
            },

            {
                id: "btn-close",
                text: "Thoát",
                click: function () {
                    $(this).dialog("destroy").remove();
                }
            }
            ]
        });
    }
}
//end CA_01_PhanQuyen