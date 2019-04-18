//Get data from server to client
let ngayhethong = '', now = '';
function addZero(e) { return 10 > e && (e = "0" + e), e }
function vnn_formatdatetime(e) { var t = addZero(e.getDate()), n = addZero(e.getMonth() + 1), a = e.getFullYear(), i = addZero(e.getHours()), r = addZero(e.getMinutes()), o = addZero(e.getSeconds()), l = ngayhethong, c = ngayhethong.split(" "), s = "", d = ""; c[0].indexOf("yyyy") > -1 ? l = l.replace(/yyyy/g, a) : (a = a.toString().substring(2, 4), l = l.replace(/yy/g, a)); try { d = c[2], d.indexOf("tt") > -1 | d.indexOf("TT") > -1 && (s = addAMPM(i, d), 0 == i ? i = 12 : i > 12 && (i = addZero(i - 12))) } catch (h) { } return l = l.replace(/dd/g, t).replace(/MM/g, n).replace(/hh/g, i).replace(/mm/g, r).replace(/ss/g, o).replace(/tt/, s).replace(/TT/, s) }
function get_now() {
    let now = new Date();
    now = vnn_formatdatetime(now);
    return now;
}

let sessionbd = new Array(), id_action = new Array(), id_oper = new Array(), reset_column = new Array(), module_select = new Array();
let t = "", max_es = 3600000, min_es = 1000, espera2 = min_es, enable_timer = true, refresco2 = null, module_thuake = 0, loai_module_md = 'JQG', reload_page = null, xhr_menu, xhr_content, title_header = '', title_header_1 = '', title_header_2 = '', title_header_3 = '', loaddautien_page = 0, loadgrid_at = true, systemload = 0, id_new = "0", header_sep = ' <a style="color:rgb(225, 66, 110); font-weight:bold"> → </a> ';
 
var encodeHTML = function (a) {
    if (a) {
        a = a.replace(/</g, '0ψ0');
        a = a.replace(/>/g, '1Ψ1');
    }
    return a;
};

var decodeHTML = function (a) {
    if (a) {
        a = a.replace(/0ψ0/g, '<');
        a = a.replace(/1Ψ1/g, '>');
    }
    return a;
};

function xemthongtinchitiet() {
    var n = "",
        i = "MD_00_TaiKhoan";
    $("#mainpane").append('<div id="dlg_gridSmall" align="center" title="Thông tin chi tiết của tài khoản"><table id="xemchitiet"><tr><td><label>Họ tên</label><br /><input readonly id="xct_hoten" type="text" value="Đang tải..." /></td><td><label>Email</label><br /><input readonly id="xct_email" type="text" value="Đang tải..." /></td><td><label>Điện thoại</label><br /><input readonly id="xct_dienthoai" type="text" value="Đang tải..." /></td></td></tr><tr><td><label>Mã tài khoản</label><br /><input readonly id="xct_mauser" type="text" value="Đang tải..." /></td><td><label>Vai trò</label><br /><div id="xct_vaitro">Đang tải...</div></td><td><label>Bộ phận</label><br /><input readonly id="xct_phongban" type="text" value="Đang tải..." /></td></tr><tr><td><label>Mật khẩu cũ:</label><br /><input id="txtMKcu" type="password" name="txtMKcu" /></td><td><label>Mật khẩu mới:</label><br /><input type="password" id="txtMKmoi" name="txtMKmoi" /></td><td><label>Xác nhận mật khẩu:</label><br /><input type="password" id="txtXNMK" name="txtXNMK" /></td></tr><tr><td colspan="3"><label>Thông tin khác</label><br /><textarea id="xct_mota" style="height:100px" readonly role="textbox" multiline="true" class="FormElement ui-widget-content ui-corner-all"></textarea></td></tr><tr><td style="text-align:right" colspan="3"><input style="width:15px;position:absolute;margin:0 0 0 -21px" id="vaitro_macdinh" type="checkbox" /><label>Đặt làm mặc định</label></td></table></div>'), $("#dlg_gridSmall").dialog({
        modal: !0,
        width: 550,
        open: function () {
            Logo_Center("glyphicon glyphicon-user", ""), $.getJSON("Controller/JQGridModify/JQGrid" + i + "Modify.ashx?oper=getthongtin", function (i) {
                $("#xct_vaitro").empty();
                $.each(i, function (i, e) {
                    $("#xct_hoten").val(e.hoten), $("#xct_email").val(e.email), $("#xct_dienthoai").val(e.phone), $("#xct_mauser").val(e.ma_user), $("#xct_vaitro").prepend(e.vaitro), $("#xct_phongban").val(e.ten_phongban), n = e.md_phongban_id
                })
            }), $("#xct_vaitro").change(function () {
                $("#xct_phongban").val("Đang tải..."), $.get("Controller/JQGridModify/JQGrid" + i + "Modify.ashx?oper=get_phongban&id=" + $("#xct_vaitro select").val(), function (n) {
                    $("#xct_phongban").val(n)
                })
            })
        },
        close: function () {
            $(this).dialog("destroy").remove()
        },
        buttons: [{
            id: "btn-ok",
            text: "Đồng ý",
            click: function () {
                $("#dlg_gridSmall").prepend('<div class="nhan_loading"></div>'), $("#dlg_gridSmall .ui-state-error").remove(), $("#dlg_gridSmall .nhan-thanhcong").remove(), $.post("Controller/JQGridModify/JQGrid" + i + "Modify.ashx", {
                    matkhau: "",
                    hoten: $("#xct_hoten").val(),
                    diachi: $("#xct_diachi").val(),
                    phone: $("#xct_dienthoai").val(),
                    md_phongban_id: n,
                    mota: $("#xct_mota").val(),
                    fax: $("#xct_fax").val(),
                    vaitro_macdinh: document.getElementById("vaitro_macdinh").checked,
                    ad_role_id: $("#xct_vaitro select").val(),
                    oldpassword: $('#txtMKcu').val(),
                    newpassword: $('#txtMKmoi').val(),
                    confirm: $('#txtXNMK').val(),
                    oper: "save"
                }, function (n) {
                    n = n.split("(##)"), $("#dlg_gridSmall .nhan_loading").remove(), $("#dlg_gridSmall").prepend(n[2]), "True" == n[0] && (reload_page = !0, window.location.href = n[1])
                })
            }
        }, {
            id: "btn-close",
            text: "Thoát",
            click: function () {
                $(this).dialog("destroy").remove()
            }
        }]
    })
}

function nhan_trotoisearch() {
    $(".textbox_nhan").focus()
}

function nhan_trotoitextarea() {
    $(".noidunggui_chatbox").focus()
}

function chonnguoinhan(n) {
    checkedItems = n, $("#nhan_checkall_uncheckall").click();
    for (var i = 0; i < n.split("; ").length - 1; i++) $("#list_menu2").jqxListBox("checkItem", n.split("; ")[i]);
    $("#bien_nguoinhan").val(checkedItems), $(".nhan_divnguoinhan").empty(), $(".nhan_divnguoinhan").append(checkedItems), $(".nguoinhan_chatbox").find("a").remove(), $(".nguoinhan_chatbox").append('<a onclick="nhan_trotoisearch()" style="color:#999;color: #999;position: absolute;margin: -21 0 0 31;z-index: 10;cursor: text;">Tìm kiếm</a>'), $.get("Controller/JQGridModify/JqGridMD_00_TaiKhoanModify.ashx?oper=loadtaikhoan&timkiem=", function (n) {
        res = n.split("#"), countcase_2 = res.length, $("#list_menu2").jqxListBox({
            selectedIndex: -1,
            checkboxes: !0,
            source: res,
            width: 200,
            height: 275
        });
        var i = checkedItems;
        nhan2 = 0;
        for (var e = 0; e < i.split(";").length - 1; e++) {
            for (var t = 0; t < countcase_2 - 1; t++)
                if (i.split(";")[e].replace(/ /g, "") == n.split("#")[t]) {
                    var a = new RegExp(i.split(";")[e].replace(/ /g, "") + "; ", "g");
                    checkedItems = checkedItems.replace(a, ""), $("#bien_nguoinhan").val(checkedItems)
                } $("#list_menu2").jqxListBox("uncheckItem", i.split(";")[e].replace(/ /g, "")), $("#list_menu2").jqxListBox("checkItem", i.split(";")[e].replace(/ /g, ""))
        }
    }), $(".textbox_nhan").val(""), $("#bien_sessionmes").val("-1")
}

function chatbox_vu() {
    try {
        $("#dlg_chatbox").remove()
    } catch (n) { }
    var i = "Hộp Thoại",
        e = "Danh sách người nhận",
        t = "Nội dung cần gửi";
    $("#bien_nguoinhan").val(""), $("body").append('<div id="dlg_chatbox" title="Yêu cầu công việc- [' + get_now() + ']"><table id="chatbox_vu" align="center"><tr id="duyvu_tr1"><td><label style="font-size:12px;color: #033786;">' + i + '</label><br><div class="noidung_chatbox" readonly><div class="nhan_divnguoinhan">Chưa chọn người để trao đổi công việc</div><div class="nhan_noidung"><div></div></td><td><label style="padding: 0 0 0 6;font-size:12px;color: #033786;">' + e + '</label><div title="làm mới dữ liệu" style="float:right;font-size:14px;color: #033786;"><span id="nhan_checkall_uncheckall" class="ui-icon ui-icon-circle-close"></span></div><br><div class="nguoinhan_chatbox" id="list_menu2"></div><input class="textbox_nhan" type="text"/></tr><tr class="khoangtrang_tr"><td></td></tr></table><table align="center"><tr id="duyvu_tr3"><td class="duyvu_tr3_td"><label style="font-size:12px;color: #033786;">' + t + '</label><br><textarea class="noidunggui_chatbox" autofocus="autofocus"></textarea></td><td><image class="send_hotro_vu" name="send_hotro" src="images/icon/enter.png"></td></tr></table></div>');
    $("#mainpane").width();
    $("#dlg_chatbox").dialog({
        modal: !1,
        width: 680,
        height: 500,
        open: function () {
            $(".ui-dialog-titlebar").append('<button id="nhan_uidialog_mini" type="button" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close" role="button" aria-disabled="false" title="mini"><span class="ui-button-icon-primary ui-icon ui-icon-minusthick"></span><span class="ui-button-text">minimize</span></button>'), $("#nhan_uidialog_mini").mouseover(function () {
                $("#nhan_uidialog_mini").addClass("ui-state-hover")
            }), $("#nhan_uidialog_mini").mouseout(function () {
                $("#nhan_uidialog_mini").removeClass("ui-state-hover")
            }), $.get("Controller/JQGridModify/JqGridMD_00_TaiKhoanModify.ashx?oper=loadtaikhoan&timkiem=", function (n) {
                var i = 0,
                    e = n.split("#"),
                    t = e,
                    a = "Chưa chọn người để trao đổi công việc";
                i = e.length, $("#list_menu2").jqxListBox({
                    selectedIndex: -1,
                    checkboxes: !0,
                    source: e,
                    width: 200,
                    height: 275
                });
                var o = 0;
                $("#list_menu2").on("checkChange", function (n) {
                    var e = n.args;
                    if (e.checked) {
                        if ("Tất cả" == e.label & "" != e.label & null != e.label) {
                            for (var t = 1; i > t; t++) $("#list_menu2").jqxListBox("checkIndex", t);
                            o = 0
                        } else if ("" != e.label & null != e.label) {
                            a = a.replace("Trao đổi với: mọi người", ""), a = a.replace("Chưa chọn người để trao đổi công việc", "");
                            var l = new RegExp(e.label + "; ", "g");
                            a = a.replace(l, ""), a += e.label + "; ", $(".nhan_divnguoinhan").empty(), $(".nhan_divnguoinhan").append(a), $("#bien_nguoinhan").val(a)
                        }
                        $(".nhan_noidung").append('<div style="color:red; padding: 6 6 0 4">Đang tải</div>')
                    } else {
                        if ("Tất cả" == e.label & "" != e.label & null != e.label) {
                            if (0 >= o)
                                for (var t = 1; i > t; t++) $("#list_menu2").jqxListBox("uncheckIndex", t)
                        } else if ("" != e.label & null != e.label) {
                            o++ , o > 0 && $("#list_menu2").jqxListBox("uncheckIndex", 0), a = a.replace("Trao đổi với: mọi người", ""), a = a.replace("Chưa chọn người để trao đổi công việc", "");
                            var l = new RegExp(e.label + "; ", "g");
                            a = a.replace(l, ""), "" == a ? ($(".nhan_divnguoinhan").empty(), a = "Chưa chọn người để trao đổi công việc", $(".nhan_divnguoinhan").append(a), $("#bien_nguoinhan").val(a)) : ($(".nhan_divnguoinhan").empty(), $(".nhan_divnguoinhan").append(a), $("#bien_nguoinhan").val(a))
                        }
                        $(".nhan_noidung").empty(), $(".nhan_noidung").append('<div style="color:red; padding: 6 6 0 4">Đang tải</div>')
                    }
                    $("#bien_sessionmes").val("-1")
                }), $(".nguoinhan_chatbox").find("a").remove(), $(".nguoinhan_chatbox").append('<a onclick="nhan_trotoisearch()" style="color:#999;color: #999;position: absolute;margin: -21 0 0 31;z-index: 10;cursor: text;">Tìm kiếm</a>'), $(".textbox_nhan").on("keyup", function () {
                    $(".textbox_nhan").val().length <= 0 ? ($(".nguoinhan_chatbox").find("a").remove(), $(".nguoinhan_chatbox").append('<a onclick="nhan_trotoisearch()" style="color:#999;color: #999;position: absolute;margin: -21 0 0 31;z-index: 10;cursor: text;">Tìm kiếm</a>'), $.get("Controller/JQGridModify/JqGridMD_00_TaiKhoanModify.ashx?oper=loadtaikhoan&timkiem=", function (n) {
                        e = n.split("#"), i = e.length, $("#list_menu2").jqxListBox({
                            selectedIndex: -1,
                            checkboxes: !0,
                            source: e,
                            width: 200,
                            height: 275
                        });
                        var t = a;
                        o = 0;
                        for (var l = 0; l < t.split(";").length - 1; l++) {
                            for (var c = 0; i - 1 > c; c++)
                                if (t.split(";")[l].replace(/ /g, "") == n.split("#")[c]) {
                                    var d = new RegExp(t.split(";")[l].replace(/ /g, "") + "; ", "g");
                                    a = a.replace(d, ""), $("#bien_nguoinhan").val(a)
                                } $("#list_menu2").jqxListBox("uncheckItem", t.split(";")[l].replace(/ /g, "")), $("#list_menu2").jqxListBox("checkItem", t.split(";")[l].replace(/ /g, ""))
                        }
                    })) : ($(".nguoinhan_chatbox").find("a").remove(), $.get("Controller/JQGridModify/JqGridMD_00_TaiKhoanModify.ashx?oper=loadtaikhoan&timkiem=" + $(".textbox_nhan").val(), function (n) {
                        e = n.split("#"), i = e.length, $("#list_menu2").jqxListBox({
                            selectedIndex: -1,
                            checkboxes: !0,
                            source: e,
                            width: 200,
                            height: 275
                        });
                        var t = a;
                        o = 0;
                        for (var l = 0; l < t.split(";").length - 1; l++) {
                            for (var c = 0; i - 1 > c; c++)
                                if (t.split(";")[l].replace(/ /g, "") == n.split("#")[c]) {
                                    var d = new RegExp(t.split(";")[l].replace(/ /g, "") + "; ", "g");
                                    a = a.replace(d, ""), $("#bien_nguoinhan").val(a)
                                } $("#list_menu2").jqxListBox("uncheckItem", t.split(";")[l].replace(/ /g, "")), $("#list_menu2").jqxListBox("checkItem", t.split(";")[l].replace(/ /g, ""))
                        }
                    }))
                }), $(".duyvu_tr3_td").find("a").remove(), $(".duyvu_tr3_td").append('<a onclick="nhan_trotoitextarea()" style="color:#999;font-size:14;position: absolute;margin: 7 0 0 -521;z-index: 10;cursor: text;">Nhập nội dung muốn gửi...</a>'), $(".noidunggui_chatbox").on("keydown", function (n) {
                    if ("" == $(".noidunggui_chatbox").val() ? ($(".duyvu_tr3_td").find("a").remove(), $(".duyvu_tr3_td").append('<a onclick="nhan_trotoitextarea()" style="color:#999;font-size:14;position: absolute;margin: 7 0 0 -521;z-index: 10;cursor: text;">Nhập nội dung muốn gửi...</a>')) : $(".duyvu_tr3_td").find("a").remove(), "13" == n.keyCode & 0 == l) {
                        var i = $(".noidunggui_chatbox").val();
                        $(".noidunggui_chatbox").attr("disabled", !0);
                        var e = new RegExp("; ", "g"),
                            t = a.replace(e, ", ");
                        $(".noidunggui_chatbox").val('Đang gửi nội dung đến "' + t.slice(0, -2) + '"...'), $.post("Controller/PublicFunction/SendMessage.ashx", {
                            nguoinhan: a,
                            noidung: i.replace(/\n/g, "<br>")
                        }, function (n) {
                            "false" == n.split("#")[0] && ($(".noidunggui_chatbox").removeAttr("disabled"), $(".noidunggui_chatbox").val(i), alert(n.split("#")[1]), $(".noidunggui_chatbox").focus())
                        })
                    }
                }).on("keyup", function () {
                    "" == $(".noidunggui_chatbox").val() && ($(".duyvu_tr3_td").find("a").remove(), $(".duyvu_tr3_td").append('<a onclick="nhan_trotoitextarea()" style="color:#999;font-size:14;position: absolute;margin: 7 0 0 -521;z-index: 10;cursor: text;">Nhập nội dung muốn gửi...</a>'))
                });
                var l = !1;
                $(".noidunggui_chatbox").keydown(function (n) {
                    "17" == n.keyCode && (l = !0)
                }).keyup(function (n) {
                    "17" == n.keyCode && (l = !1)
                }).keydown(function (n) {
                    l && "13" == n.keyCode && ($(".noidunggui_chatbox").val($(".noidunggui_chatbox").val() + "\n"), l = !1)
                }), $(".send_hotro_vu").on("click", function () {
                    $("body").append('<div id="nhan-che"></div>'), $.post("Controller/PublicFunction/SendMessage.ashx", {
                        nguoinhan: a,
                        noidung: $(".noidunggui_chatbox").val().replace(/\n/g, "<br>")
                    }, function (n) {
                        $("#nhan-che").remove(), "false" == n.split("#")[0] ? alert(n.split("#")[1]) : ($(".noidunggui_chatbox").val(""), $(".duyvu_tr3_td").append('<a onclick="nhan_trotoitextarea()" style="color:#999;font-size:14;position: absolute;margin: 7 0 0 -521;z-index: 10;cursor: text;">Nhập nội dung muốn gửi...</a>'))
                    })
                }), $("#nhan_uidialog_mini").click(function () {
                    if ($("#nhan_uidialog_mini span").hasClass("ui-icon-minusthick")) $("#bien_nguoinhan").val(""), $(".ui-dialog").css("width", "150px"), $(".ui-dialog").css("height", "27px"), $(".ui-dialog").css("left", window.innerWidth - 160), $(".ui-dialog").css("top", window.innerHeight - 30), $("#nhan_uidialog_mini span").removeClass("ui-icon-minusthick"), $("#nhan_uidialog_mini span").addClass("ui-icon-plusthick");
                    else {
                        $("#bien_nguoinhan").val(a), $("#bien_sessionmes").val("-1");
                        var n = $("#listBoxContentlist_menu2 div").find("div").length / 4;
                        $("#list_menu2").jqxListBox("checkIndex", n - 1), $("#list_menu2").jqxListBox("uncheckIndex", n - 1), $(".ui-dialog").css("width", "680px"), $(".ui-dialog").css("height", "500px"), $(".ui-dialog").css("left", (window.innerWidth - 680) / 2), $(".ui-dialog").css("top", (window.innerHeight - 500) / 2), $("#nhan_uidialog_mini span").addClass("ui-icon-minusthick"), $("#nhan_uidialog_mini span").removeClass("ui-icon-plusthick"), $(".noidunggui_chatbox").focus()
                    }
                }), $(".noidunggui_chatbox").focus(), $("#bien_sltinmoi").val() > 0 && ($(".textbox_nhan").val("%"), "" == $(".textbox_nhan").val() ? ($(".nguoinhan_chatbox").find("a").remove(), $(".nguoinhan_chatbox").append('<a onclick="nhan_trotoisearch()" style="color:#999;color: #999;position: absolute;margin: -21 0 0 31;z-index: 10;cursor: text;">Tìm kiếm</a>'), $.get("Controller/JQGridModify/JqGridMD_00_TaiKhoanModify.ashx?oper=loadtaikhoan&timkiem=", function (n) {
                    e = n.split("#"), i = e.length, $("#list_menu2").jqxListBox({
                        selectedIndex: -1,
                        checkboxes: !0,
                        source: e,
                        width: 200,
                        height: 275
                    });
                    var t = a;
                    o = 0;
                    for (var l = 0; l < t.split(";").length - 1; l++) {
                        for (var c = 0; i - 1 > c; c++)
                            if (t.split(";")[l].replace(/ /g, "") == n.split("#")[c]) {
                                var d = new RegExp(t.split(";")[l].replace(/ /g, "") + "; ", "g");
                                a = a.replace(d, ""), $("#bien_nguoinhan").val(a)
                            } $("#list_menu2").jqxListBox("uncheckItem", t.split(";")[l].replace(/ /g, "")), $("#list_menu2").jqxListBox("checkItem", t.split(";")[l].replace(/ /g, ""))
                    }
                })) : ($(".nguoinhan_chatbox").find("a").remove(), $.get("Controller/JQGridModify/JqGridMD_00_TaiKhoanModify.ashx?oper=loadtaikhoan&timkiem=" + $(".textbox_nhan").val(), function (n) {
                    e = n.split("#"), i = e.length, $("#list_menu2").jqxListBox({
                        selectedIndex: -1,
                        checkboxes: !0,
                        source: e,
                        width: 200,
                        height: 275
                    });
                    var t = a;
                    o = 0;
                    for (var l = 0; l < t.split(";").length - 1; l++) {
                        for (var c = 0; i - 1 > c; c++)
                            if (t.split(";")[l].replace(/ /g, "") == n.split("#")[c]) {
                                var d = new RegExp(t.split(";")[l].replace(/ /g, "") + "; ", "g");
                                a = a.replace(d, ""), $("#bien_nguoinhan").val(a)
                            } $("#list_menu2").jqxListBox("uncheckItem", t.split(";")[l].replace(/ /g, "")), $("#list_menu2").jqxListBox("checkItem", t.split(";")[l].replace(/ /g, ""))
                    }
                    $("#list_menu2").jqxListBox("checkIndex", 1)
                }))), $("#nhan_checkall_uncheckall").click(function () {
                    a = "";
                    for (var n = 1; n < t.length - 1; n++) $("#list_menu2").jqxListBox("uncheckIndex", n);
                    $("#bien_nguoinhan").val(a), $(".nhan_divnguoinhan").empty(), $(".nhan_divnguoinhan").append("Chưa chọn người để trao đổi công việc")
                })
            })
        },
        close: function () {
            $(this).dialog("destroy").remove(), $("#bien_nguoinhan").val("")
        }
    })
}

function thaydoinoidungxoa(n, i) {
    $("#DelTbl_" + n + " table tr > .delmsg").empty(), $("#DelTbl_" + n + " table tr > .delmsg").append(i)
}
//function download
function modify_code(url){reload_page="no";window.location.href=url;setTimeout(function(){reload_page=null},1000)}

var winconfigGV = null;
function click_configGV_link(tengrid) {
    var ma_module = tengrid.replace('grid', '');
    var sord = $('#' + tengrid).jqGrid('getGridParam', 'postData').sord;
    var sidx = $('#' + tengrid).jqGrid('getGridParam', 'postData').sidx;
    var filters = $('#' + tengrid).jqGrid('getGridParam', 'postData').filters;
    var id_parent = $('#' + tengrid).jqGrid('getGridParam', 'postData').id;
    if (filters) {
        filters = filters.replace(/'/g, "\\'");
    }
    else {
        filters = "";
    }
    if (!sord) {
        sord = "";
    }
    if (!sidx) {
        sidx = "";
    }
    var link_export = 'View/Print/MD_01_Export/XuatDSTK.aspx?ma_module=' + ma_module + '&sord=' + sord + '&sidx=' + sidx + '&filters=' + filters + '&_search=true&id=' + id_parent;

    try { winconfigGV.close(); } catch (r) { console.error(r); }
    winconfigGV = window.open(link_export, 'Chiết Xuất Dữ Liệu', 'width = 500px, height = 500px');
}

function click_configGV(tengrid) {
    var ma_menu = 'mainbody', ma_module = tengrid.replace('grid', '');
    var id_parent = $('#' + tengrid).jqGrid('getGridParam', 'postData').id;
    var dialog = 'dlg_gridSmall' + ma_menu;
    $('body').append(`<div class="${dialog}" align="center" title="Chi tiết dữ liệu đang xem">
	<table class="EditTable" style="width:100%">
		<tr style="height: 40px;">
			<td>
				Tất cả dữ liệu: <b class="ctdldx_dlhc">Đang tải...</b>  
			</td>
		</tr>
		
		<tr style="height: 40px;">
			<td>
				Dữ liệu đang hiển thị: <b class="ctdldx_dldht">Đang tải...</b>
			</td>
		</tr>
		
		<tr style="height: 40px;">
			<td>
				<a onclick="click_configGV_link('${tengrid}')" class="btn-escedoc">Xuất dữ liệu</a>
			</td>
		</tr>
	</table>
	</div>`);
    dialog = '.' + dialog;
    $(dialog).dialog({
        modal: !0,
        width: 300,
        open: function () {
            $.get('Controller/PublicFunction/ConfigSystem.ashx', { ma_module: ma_module, oper: 'count_module2', id: id_parent }, function (result) {
                $(dialog).find('.ctdldx_dlhc').html(result + ' dòng.');
                var dht = 0;
                $('#' + tengrid).find('tr.ui-widget-content.jqgrow.ui-row-ltr').each(function () {
                    if ($(this).attr('class').indexOf('esc_vnn_') > -1 &
                        $(this).attr('class').indexOf('esc_vnn_vnnnodel_esc') <= -1) {
                        dht++;
                    }
                });
                if (result <= 0)
                    dht = 0;
                $(dialog).find('.ctdldx_dldht').html(dht + ' dòng.');
            });
            Logo_Center("glyphicon glyphicon-cog", true);
        },
        close: function () {
            $(this).dialog("destroy").remove();
        },
        buttons: [{
            id: "btn-close",
            text: "Thoát",
            click: function () {
                $(this).dialog("destroy").remove();
            }
        }]
    })
}

var findnamegrid_basecodegrid = function (a, b) {
    var a_cp = a.replace('grid', '').substring(0, 5);
    var name = "";
    if (a_cp == 'MD_00') {
        name = $('.nav1_li_a_select').text();
    }
    else if (a_cp == 'MD_01') {
        name = $('#jqxTabs' + b + ' .jqx-tabs-title-selected-top.jqx-fill-state-pressed').attr('ten_mod');

    }
    else if (a_cp == 'MD_02') {
        name = $('#jqxTabs' + b + '_capdo1 .jqx-tabs-title-selected-top.jqx-fill-state-pressed').attr('ten_mod');
    }
    return name;
}
var search_jqgrid = function (grid) {
    var ma_menu = $('.nav1_li_a_select').attr('ma_menu');
    var dialog = 'dlg_gridSmall' + grid;

    $('.content-menu-' + ma_menu).append('<div class="' + dialog +
        `" align="center" title="Tìm kiếm ` + findnamegrid_basecodegrid(grid, ma_menu) + `">
	<table class="EditTable" style="width:100%">
	</table>
	</div>`);
    dialog = '.' + dialog;
    $(dialog).dialog({
        modal: !0,
        width: 450,
        height: 550,
        open: function () {
            var tbl = dialog + ' .EditTable';
            var i = 2;
            $('.content-menu-' + ma_menu).append($(this).parent().prev());
            $('.content-menu-' + ma_menu).append($(this).parent());
            var th_header = '.tbl_vnn_' + grid + ' .ui-jqgrid-labels > .ui-state-default.ui-th-column.ui-th-ltr';
            var input_str = '.tbl_vnn_' + grid + ' .ui-search-table .ui-search-input > input';
            var select_str = '.tbl_vnn_' + grid + ' .ui-search-table .ui-search-input > select';
            $(input_str + ',' + select_str).each(function () {
                var th_sr = $(this).parent().parent().parent().parent().parent().parent().attr('style');
                var ok = false;
                if (th_sr == null) {
                    ok = true;
                }
                else if (th_sr.indexOf('display') <= -1) {
                    ok = true;
                }
                if (ok == true) {
                    var kq = '';
                    kq += '<tr class="FormData">';
                    kq += '<td style="padding-bottom: 10px;" class="DataTD">';
                    kq += '<div style="color: #6d41ec;">' + $(th_header + ':nth-child(' + i + ')').text() + '</div>';
                    var id_el = $(this).attr('id') + grid;
                    if ($(this).prop("tagName") == 'INPUT') {
                        kq += '<input id="' + id_el + '" class="FormElement ui-widget-content ui-corner-all" />';
                    }
                    else {
                        kq += '<select id="' + id_el + '" class="FormElement ui-widget-content ui-corner-all">';
                        kq += $(this).html();
                        kq += '</select>';
                    }
                    kq += '</tr>';
                    kq += '</td>';
                    $(tbl).append(kq);
                    var elem_new = $('#' + id_el);
                    elem_new.val($(this).val());
                    if ($(this).hasClass('date')) {
                        search_datetime(elem_new, 1);
                    }
                    else if ($(this).hasClass('number')) {
                        search_number(elem_new, 1, 1);
                    }
                    else if ($(this).prop("tagName") == 'SELECT') {
                        elem_new.chosen(vnn_sel_config['default']);
                    }
                }
                i++;
            });

            Logo_Center("glyphicon glyphicon-search", "", dialog);
        },
        close: function () {
            $(this).dialog("destroy").remove();
        },
        buttons: [{
            id: "btn-ok" + grid,
            text: "Đồng ý",
            click: function () {
                var tbl = dialog + ' .EditTable';
                var input_str = '.tbl_vnn_' + grid + ' .ui-search-table .ui-search-input > input';
                var select_str = '.tbl_vnn_' + grid + ' .ui-search-table .ui-search-input > select';
                $(input_str + ',' + select_str).each(function () {
                    var val_new = $('#' + $(this).attr('id') + grid).val();
                    $(this).val(val_new);
                    chosen_update($(this));
                });
                $('#' + grid)[0].triggerToolbar();
                $(this).dialog("destroy").remove();
            }
        }, {
            id: "btn-close" + grid,
            text: "Thoát",
            click: function () {
                $(this).dialog("destroy").remove();
            }
        }]
    })
}


var set_height_tabs = function (elem, grid) {
    if (ismobile == true) {
        try {
            var height = height_menu_auto(1) - 13;
            elem.jqxTabs({ height: height });
            grid.setGridHeight(height - 92);
            grid.setGridWidth($('.page-content').children().first().width());
            $('.tbl_vnn_' + grid.attr('id') + ' .ui-search-toolbar .ui-search-table .ui-search-input select').each(function () {
                $(this).next().css('width', $(this).parent().width());
            });
        }
        catch (r) {
            console.log(r);
        }
    }
};
