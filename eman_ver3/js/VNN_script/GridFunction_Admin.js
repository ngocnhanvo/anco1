(function ($) {
    $.fn.hasScrollBar = function () {
        return this.get(0).scrollHeight > this.get(0).clientHeight;
    };

    $.fn.sizeChanged = function (handleFunction) {
        var element = this;
        var lastWidth = element.width();
        var lastHeight = element.height();

        setInterval(function () {
            if (lastWidth === element.width() && lastHeight === element.height())
                return;
            if (typeof (handleFunction) == 'function') {
                handleFunction({ width: lastWidth, height: lastHeight },
                           { width: element.width(), height: element.height() });
                lastWidth = element.width();
                lastHeight = element.height();
            }
        }, 0);
        return element;
    };

    $.extend($.expr[":"], {
        containsExact: $.expr.createPseudo ?
            $.expr.createPseudo(function (text) {
                return function (elem) {
                    return $.trim(elem.innerHTML.toLowerCase()) === text.toLowerCase();
                };
            }) :
            // support: jQuery <1.8
            function (elem, i, match) {
                return $.trim(elem.innerHTML.toLowerCase()) === match[3].toLowerCase();
            },

        containsExactCase: $.expr.createPseudo ?
            $.expr.createPseudo(function (text) {
                return function (elem) {
                    return $.trim(elem.innerHTML) === text;
                };
            }) :
            // support: jQuery <1.8
            function (elem, i, match) {
                return $.trim(elem.innerHTML) === match[3];
            },

        containsRegex: $.expr.createPseudo ?
            $.expr.createPseudo(function (text) {
                var reg = /^\/((?:\\\/|[^\/])+)\/([mig]{0,3})$/.exec(text);
                return function (elem) {
                    return reg ? RegExp(reg[1], reg[2]).test($.trim(elem.innerHTML)) : false;
                };
            }) :
            // support: jQuery <1.8
            function (elem, i, match) {
                var reg = /^\/((?:\\\/|[^\/])+)\/([mig]{0,3})$/.exec(match[3]);
                return reg ? RegExp(reg[1], reg[2]).test($.trim(elem.innerHTML)) : false;
            }

    });
} (jQuery));

jQuery.fn.dialogCenter = function () {
    this.css("position", "absolute");
    this.css("top", ($(window).height() - this.height()) / 2 + $(window).scrollTop() + "px");
    this.css("left", ($(window).width() - this.width()) / 2 + $(window).scrollLeft() + "px");
    return this;
};

String.prototype.insert = function (index, string) {
  if (index > 0)
    return this.substring(0, index) + string + this.substring(index, this.length);
  else
    return string + this;
};

function boolconvert (string) {
    switch (string.toLowerCase()) {
        case "true": case "yes": case "1": return true;
        case "false": case "no": case "0": case null: return false;
        default: return Boolean(string);
    }
}

function click_add(tengrid, type) {
	if(type == 0){
		$('#add_' + tengrid).click();
	}
	else {
		var vnn = 0;
		$('.cl_div_chuathanhcongcu > div > .img_btnmacdinh').each(function(){
			if($(this).attr('onclick').indexOf('click_add(') > -1){
				vnn = 1;
				return false;
			}
		});
		if(vnn > 0)
		{
			$('#add_' + tengrid).click();
			$('#sData').show();
		}
	}
}
function click_edit(tengrid, type) {
	if(type == 0){
		$('#edit_' + tengrid).click();
	}
	else {
		var vnn = 0;
		$('.cl_div_chuathanhcongcu > div > .img_btnmacdinh').each(function(){
			if($(this).attr('onclick').indexOf('click_edit(') > -1){
				vnn = 1;
				return false;
			}
		});
		if(vnn > 0) {
			$('#edit_' + tengrid).click();
			$('#sData').show();
		}
	}
}
function click_del(tengrid, id_parent, ma_case, load_stt) {
    $('#del_' + tengrid).click();
}
function click_refresh(tengrid) {
    loadclick_(tengrid, 'noSel');
}
function click_refresh_clearsearch(tengrid) {
    
	/*$('#gview_'+ tengrid+' .ui-jqgrid-hdiv > .ui-jqgrid-hbox table tr th div table tr > .ui-search-input input').val('');
	$('#gview_'+ tengrid+' .ui-jqgrid-hdiv > .ui-jqgrid-hbox table tr th div table tr > .ui-search-input select').val('');*/
    var a_ = $('.tbl_vnn_'+ tengrid +' > thead > .ui-search-toolbar > th > div > .ui-search-table tr > .ui-search-input input');
    $(a_).each(function (index, val) {
        $(this).val('');
    });
    var b_ = $('.ui-search-table tr > .ui-search-input select');
    $(b_).each(function (index, val) {
        $(this).val('');
    });
    try {
        $('#' + tengrid).jqGrid('getGridParam', 'postData').filters = null;
    }
    catch (r) { console.warn(r); }
    loadclick_(tengrid, 'noSel');
}
function click_view(tengrid) {
    $('#view_' + tengrid).click();
}
function viewform(tengrid_f){
	click_edit(tengrid_f,0);
	khoa_field(tengrid_f);
	$('#sData').hide();
}

function hideform(tengrid_f) {
	$.jgrid.hideModal('#viewmod' + tengrid_f, { gbox: '#gbox_' + tengrid_f });
}

function click_origination(tengrid_v) {
	if ($('#org_' + tengrid_v).val() == 0) {
		$('#'+tengrid_v).showCol('value_nguoitao');
		$('#'+tengrid_v).showCol('value_vaitrotao');
		$('#'+tengrid_v).showCol('value_bophantao');
		$('#'+tengrid_v).showCol('value_nguoicapnhat');
		$('#'+tengrid_v).showCol('value_vaitrocapnhat');
		$('#'+tengrid_v).showCol('value_bophancapnhat');
		$('#'+tengrid_v).showCol('ngaytao');
		$('#'+tengrid_v).showCol('ngaycapnhat');
		$('#'+tengrid_v).showCol('hoatdong');
		$('#org_' + tengrid_v).val(1);
	}
	else {
		$('#'+tengrid_v).hideCol('value_nguoitao');
		$('#'+tengrid_v).hideCol('value_vaitrotao');
		$('#'+tengrid_v).hideCol('value_bophantao');
		$('#'+tengrid_v).hideCol('value_nguoicapnhat');
		$('#'+tengrid_v).hideCol('value_vaitrocapnhat');
		$('#'+tengrid_v).hideCol('value_bophancapnhat');
		$('#'+tengrid_v).hideCol('ngaytao');
		$('#'+tengrid_v).hideCol('ngaycapnhat');
		$('#'+tengrid_v).hideCol('hoatdong');
		$('#org_' + tengrid_v).val(0);
	}
	$('#' + tengrid_v)[0].triggerToolbar();
}

function doubleclick(tengrid) {
    click_view(tengrid);
}

function doubleclicksua(tengrid) {
    $('#pager' + tengrid + '_left table tr td div > .ui-icon-pencil').click();
}

function doubleclickthem(tengrid) {
    $('#pager' + tengrid + '_left table tr td div > .ui-icon-plus').click();
}

function resetSelection(tengrid) {
	var k = $('#' + tengrid).jqGrid("getGridParam", 'selarrrow');
	var arr = k.slice();
	for(var i=0; i<arr.length; i++) {
		$('.jqg_'+ tengrid +'_' + arr[i]).click();
	}
}

function clickSelection(tengrid, id_new) {
	var k = $('#' + tengrid).jqGrid("getGridParam", 'selarrrow');
	if(k.length > 0) {
		var cls = '.jqg_' + tengrid + '_' + id_new;
		$(cls).click();
	}
	else {
		$('#'+tengrid).jqGrid('setSelection', id_new);
	}
}
function fix_disableSelect(tengrid) {
}
//khoa tat ca field trong grid
function khoa_field(tengrid) {

    var a = '#TblGrid_' + tengrid + ' tr td input'
    $(a).each(function (index, val) {
        khoa_column($(this).attr('id'));
    });

    var b = '#TblGrid_' + tengrid + ' tr td select'
    $(b).each(function (index, val) {
        khoa_column($(this).attr('id'));
    });

    var c = '#TblGrid_' + tengrid + ' tr td textarea'
    $(c).each(function (index, val) {
        khoa_column($(this).attr('id'));
    });
}

//mo khoa tat ca field trong grid
function mokhoa_field(tengrid) {

    var a = '#TblGrid_' + tengrid + ' tr td input'
    $(a).each(function (index, val) {
        mokhoa_column($(this).attr('id'));
    });

    var b = '#TblGrid_' + tengrid + ' tr td select'
    $(b).each(function (index, val) {
        mokhoa_column($(this).attr('id'));
    });

    var c = '#TblGrid_' + tengrid + ' tr td textarea'
    $(c).each(function (index, val) {
        mokhoa_column($(this).attr('id'));
    });
}

function khoa_column(column) {
    try {
        $('#' + column).prop("disabled", true).addClass("nhan_disable").prop("disabled", true);
    }
    catch (r) {
    }
}

function mokhoa_column(column) {
    try {
        $('#' + column).prop("disabled", false).removeClass("nhan_disable").prop("disabled", false);
    }
    catch (r) {
    }
}

//select item mac dinh trong grid
function macdinh_selected(tengrid) {
    $('#TblGrid_' + tengrid + ' tr td select').selectedIndex = "0";
}

function get_Forminfor(ma_case, Form_infor) {
    Form_infor = Form_infor.split(")##(");
    for (var i = 0; i < Form_infor.length; i++) {
        if (Form_infor[i].indexOf("09378753400MACAS_VNN_" + ma_case) > -1) {
            Form_infor = Form_infor[i];
        }
    }
	
    Form_infor = Form_infor.split('(##)');

    this.logo = Form_infor[1];
    if (Form_infor[2] == "") { this.dodai = 500; } else { this.dodai = Form_infor[2]; }
    if (Form_infor[3] == "") { docao = 'auto'; } else { this.docao = Form_infor[3]; }
    this.canhgiua = Form_infor[4];
    this.dongform = Form_infor[5];
    this.tieude = Form_infor[6] + ' - [ '+ get_now() +' ] ';
}

function get_MLname(ma_column, Model_infor) {
    Model_infor = Model_infor.split(")##(");
    for (var i = 0; i < Model_infor.length; i++) {
        if (Model_infor[i].indexOf("09378753400MACOL_VNN_" + ma_column) > -1) {
            Model_infor = Model_infor[i];
        }
    }
    return Model_infor.split('(##)')[1];
}

function Logo_Center(logo, center, id_dialog) {
	if(id_dialog == null | id_dialog == ''){
        if (logo.indexOf("/") > -1) {
            $('.ui-dialog > .ui-dialog-titlebar').find('.img_title_jqgrid').remove();
			$('.ui-dialog > .ui-dialog-titlebar').prepend('<img class="img_title_jqgrid" alt="" src="' + logo + '" />');
		}
        else {
            $('.ui-dialog > .ui-dialog-titlebar').find('.img_title_jqgrid').remove();
			$('.ui-dialog > .ui-dialog-titlebar').prepend('<span class="img_title_jqgrid ' + logo + '" />');
		}
		if (center == "False") {
			$('.ui-dialog').css('top', 0);
			$('.ui-dialog').css('left', 0);
		}
	}
	else {
		var ui_dialog = $('#' + id_dialog).prev();
        if (logo.indexOf("/") > -1) {
            $(ui_dialog).find('.img_title_jqgrid').remove();
            $(ui_dialog).prepend('<img class="img_title_jqgrid" alt="" src="' + logo + '" />');
        }
        else {
            $(ui_dialog).find('.img_title_jqgrid').remove();
            $(ui_dialog).prepend('<span class="img_title_jqgrid ' + logo + '" />');
        }
			
		if (center == "False") {
			$(ui_dialog).css('top', 0);
			$(ui_dialog).css('left', 0);
		}
    }
    $('#btn-ok').find('.span_button.ui-icon.ui-icon-disk').remove();
    $('#btn-ok').prepend('<span class=\"span_button ui-icon ui-icon-disk\"></span>');
    $('#btn-close').find('.span_button.ui-icon.ui-icon-close').remove();
    $('#btn-close').prepend('<span class=\"span_button ui-icon ui-icon-close\"></span>');
    $('#btn-ok_').find('.span_button.ui-icon.ui-icon-disk').remove();
    $('#btn-ok_').prepend('<span class=\"span_button ui-icon ui-icon-disk\"></span>');
    $('#btn-close_').find('.span_button.ui-icon.ui-icon-close').remove();
	$('#btn-close_').prepend('<span class=\"span_button ui-icon ui-icon-close\"></span>');
}


function Close_Form(object, close) {
    if(close == 'True')
        $(object).dialog("destroy").remove();
}

function set_ValueFilter(tengrid, ValueFilter, sord, sidx) {
    try {
        ValueFilter = ValueFilter.split(')##(');
    } catch (r) {
        ValueFilter = '';
    }

    for (var i = 0; i < ValueFilter.length; i++) {
        var id = ValueFilter[i].split('(##)')[0];
        var value = ValueFilter[i].split('(##)')[1];
        try { 
			$('.' + id).each(function(index, val){
				if($(this).hasClass('gs_'+ tengrid)){
					$(this).val(value);
				}
			});
		} catch (r) { }
    }

    if (sord != null & sidx != null) {
        var s = '#jqgh_' + tengrid + '_' + sidx + ' .s-ico';
        $(s).removeAttr('style');
        $('#' + tengrid + '_' + sidx).attr('aria-selected', 'true');
        $(s + ' > .ui-grid-ico-sort').addClass('ui-state-disabled');
        $(s + ' > .ui-icon-' + sord).removeClass('ui-state-disabled');
    }
}

function get_ValueFilter(tengrid) {
    var val_final = '';
    var s = '#gbox_' + tengrid + ' tr th div table tr td input';
    $(s).each(function (index, val) {
        val_final += $(this).attr('id') + '(##)' + val.value + ')##(';
    });

    s = '#gbox_' + tengrid + ' tr th div table tr td select';
    $(s).each(function (index, val) {
        val_final += $(this).attr('id') + '(##)' + val.value + ')##(';
    });
    return val_final;
}

function remove_module_1_2() {
    $('.div_modulelv1').remove();
    $('.div_modulelv2').remove();
}

function load_gridSmall(ma_module, ma_row, url, selectedrows_1, selectedrows_2) {
    $('#grid_small').append('<table id="grid' + ma_module + '"></table>');
    if (selectedrows_1[0] == null) {
        jQuery('#grid' + ma_module).jqGrid({
            url: url,
            editurl: '',
            datatype: 'json',
            multiselect: true,
            multiboxonly: true,
            rowNum: 1000,
            loadComplete: function (data) {
                selectedrows_1 = $('#grid' + ma_module).jqGrid("getRowData");
                for (var i_2 = 0; i_2 < selectedrows_2.length; i_2++) {
                    for (var i_1 = 0; i_1 < selectedrows_1.length; i_1++) {
                        if (selectedrows_1[i_1][ma_row] == selectedrows_2[i_2][ma_row]) {
                            $('#jqg_gridDSPB_VT_' + selectedrows_1[i_1][ma_row]).click();
                        }
                    }
                }
                $('#grid_small').empty();
            },
            colModel: [
                { fixed: true, label: 'Id Small', name: ma_row, width: 0, key: true, hidden: true }
            ],
            caption: ""
        });
    }
    else {
        for (var i_2 = 0; i_2 < selectedrows_2.length; i_2++) {
            for (var i_1 = 0; i_1 < selectedrows_1.length; i_1++) {
                if (selectedrows_1[i_1][ma_row] == selectedrows_2[i_2][ma_row]) {
                    $('#jqg_gridDSPB_VT_' + selectedrows_1[i_1][ma_row]).click();
                }
            }
        }
    }
}

function addremove_gridSmall(ma_row) {
    //them user
    var $grid_add = $("#gridDSPB_VT"), selectedrows_add = $grid_add.jqGrid("getGridParam", "selarrrow");
    var chuoi_add = "";
    if (selectedrows_add.length) {
        for (var i_add = 0; i_add < selectedrows_add.length; i_add++) {
            var chen = $grid_add.jqGrid("getCell", selectedrows_add[i_add], 1);
            chuoi_add += chen + "#";
        }
    }

    //bo user
    var $grid_remove = $("#gridDSPB_VT"), selectedrows_remove = $grid_remove.jqGrid("getRowData");
    var chuoi_remove = "";
    if (selectedrows_remove.length) {
        for (var i_remove = 0; i_remove < selectedrows_remove.length; i_remove++) {
            var dem = 0;
            for (var i_add = 0; i_add < selectedrows_add.length; i_add++) {
                if (selectedrows_add[i_add] == selectedrows_remove[i_remove][ma_row])
                    dem++;
            }
            if (dem == 0)
                chuoi_remove += selectedrows_remove[i_remove][ma_row] + "#";
        }
    }

    //loading
    $('#dlg_gridSmall').prepend('<div class="nhan_loading"></div>');
    $('#dlg_gridSmall .ui-state-error').remove();
    $('#dlg_gridSmall .nhan-thanhcong').remove();

    var chuoi_kq = chuoi_add + '(##)' + chuoi_remove;
    return chuoi_kq;
}

function set_headerJQG(tengrid, headerValue) {
    headerValue = " &diams;&diams;  " + headerValue + "  &diams;&diams;";
    $('#gview_' + tengrid + ' > .ui-jqgrid-titlebar > .ui-jqgrid-title').empty();
    $('#gview_' + tengrid + ' > .ui-jqgrid-titlebar > .ui-jqgrid-title').append(headerValue);
}

function set_SizeForm(tengrid ,width, height, center) {
    $('#editmod' + tengrid).css('width', width);
    $('#FrmGrid_' + tengrid).css('width', width);
    $('#editmod' + tengrid).css('height', height);
    $('#FrmGrid_' + tengrid).css('height', height - 66);
    if (center) {
        $('#FrmGrid_' + tengrid).closest('div.ui-jqdialog').dialogCenter();
    }
}

function set_SizeForm_(tengrid, width, height, center) {
    $('#' + tengrid).parent().css('width', width);
    $('#' + tengrid).parent().css('height', height);
    $('#' + tengrid).css('height', height - 83);
    if (center) {
        $('#' + tengrid).parent().dialogCenter();
    }
}

function change_title_dialog() {
    $('.ui-dialog-titlebar').addClass('ui-dialog-titlebar_');
    $('.ui-dialog-titlebar_').removeClass('ui-dialog-titlebar');
}
//GridFormatter.js
function formatBytes(e, t) { if (0 == e) return "0 Byte"; var n = 1024, a = t + 1 || 3, i = ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"], r = Math.floor(Math.log(e) / Math.log(n)); return (e / Math.pow(n, r)).toPrecision(a) + " " + i[r] }

function vnn_number(e, t) {
    if (e == null | e == "null")
        return '<span title=""></span>';
    else {
        //let object = t;
        //if()
        var n = t.colModel.formatoptions.decimalSeparator,
            a = t.colModel.formatoptions.thousandsSeparator,
            i = t.colModel.formatoptions.decimalPlaces;
        null == e && (e = "");
        var r = e.toString(), o = "";
        "-" == r[0] && (r = r.substring(1), o = "-"),
            "auto" != i && (i = Number(i),
                r = parseFloat(r).toFixed(i)),
            vl = r.replace(".", n);
        var l = r.indexOf(".");
        Math.round(l / 3, 0); 0 > l && (l = r.length);
        for (var c = l - 3; c > 0; c -= 3)
            vl = vl.insert(c, a);
        return vl = o + vl, '<span title="' + vl + '">' + vl + "</span>";
    }
}
function get_id() { return now = new Date, now } function disable_formatter(e, t, n) { var a = $(n).html(), i = $(a).prop("tagName"); return $(i, n).attr("title") } function minetype(e) { var t = "images/mime/" + e + ".png", n = UrlExists(t); return 1 == n ? '<img style="width:16px; height:16px" src="' + t + '" />' : '<img style="width:16px; height:16px" src="images/mime/notimage.png" />' } function UrlExists(e) { var t = new XMLHttpRequest; return t.open("HEAD", e, !1), t.send(), 404 != t.status } function unminetype(e, t, n) { return $("img", n).attr("src") } function trangthaicongvan(e) { switch (e) { case "MTN": return "Mới tiếp nhận"; case "DXL": return "Đang xử lý"; case "LTR": return "Lưu trữ"; case "QH": return "Quá hạn"; case "TDUNG": return "Tạm dừng"; case "KTHUC": return "Kết thúc"; default: return '<span title="' + e + '">' + e + "</span>" } } function hinhthuccongvan(e) { switch (e) { case "CVDEN": return "Công văn đến"; case "CVDI": return "Công văn đi"; case "CVNOIBO": return "Công văn nội bộ"; default: return '<span title="' + e + '">' + e + "</span>" } } function ketthucvt(e) { return '<a  style="color:blue" href="#" onclick=ketthucvt2("' + e + '")>Kết Thúc</a>' } function download_type(e) { var t = ""; return 0 == e ? t = '<image src="images/icon/download.png" height="18px"/>' : 1 == e && (t = '<span class="glyphicon glyphicon-cloud-download" style="font-size:13px" />'), t } function download(e) { return "-" != e ? '<a href="#" onclick="modify_code(\'Controller/PublicFunction/Download.ashx?id=' + e + "')\">" + download_type(1) + "</a>" : "-" } function viewfile_type(e) { var t = ""; return 0 == e ? t = '<image src="images/icon/xemcv.png" height="18px"/>' : 1 == e && (t = '<span class="glyphicon glyphicon-eye-open" style="font-size:13px" />'), t } function viewfile_action(e) { window.open("Controller/Convert/Default.aspx?tenfile=" + e) } function viewfile(e) { return "-" != e ? "<a onclick=\"viewfile_action('" + e + '\')" href="#">' + viewfile_type(1) + "</a>" : "-" } function nhan_formatdate(e) { try { var t = (e.split(" ")[0], e.split(" ")[1], e.split(" ")[2], nhan_chuoi1.split("/")[0]); t.length < 2 && (t = 0 + t); var n = nhan_chuoi1.split("/")[1]; n.length < 2 && (n = 0 + n); var a = nhan_chuoi1.split("/")[2]; a.length < 2 && (a = 0 + a); var i = nhan_chuoi2.split(":")[0]; return i.length < 2 && (i = 0 + i), n + "/" + t + "/" + a + " " + i + ":" + nhan_chuoi2.split(":")[1] + ":" + nhan_chuoi2.split(":")[2] + " " + nhan_chuoi3 } catch (r) { return "" } } function xacnhan(e) { switch (e) { case "True": return '<div align="center"><image src="images/icon/cvmoitiepnhan.png"/></div>'; case "False": return '<span style="color:red" title="' + e + '"></span>'; default: return '<span style="color:red" title="' + e + '">' + e + "</span>" } } function dulieu_quantrong() { return '<strong style="color:red"> (<b style="font-size:14px">*</b>)</strong>' }

function esc_date(cellvalue, options, rowObject) {
    if (cellvalue != null) {
        cellvalue = cellvalue.replace('T', ' ');
        var date_cel = new Date(cellvalue);
        if (isNaN(date_cel) == true) {
            cellvalue = cellvalue.replace(/-/g, '/');
            date_cel = new Date(cellvalue);
        }
        cellvalue = vnn_formatdatetime(date_cel);
    }
    else
        cellvalue = '';
    return cellvalue;
}

function esc_date_nottime(cellvalue, options, rowObject) {
    if (cellvalue != null) {
        cellvalue = cellvalue.replace('T', ' ');
        var date_cel = new Date(cellvalue);
        if (isNaN(date_cel) == true) {
            cellvalue = cellvalue.replace(/-/g, '/');
            date_cel = new Date(cellvalue);
        }
        cellvalue = vnn_formatdatetime(date_cel);
        cellvalue = cellvalue.split(' ')[0];
    }
    return cellvalue;
}

function format_srcdatetime() {
    var e = ngayhethong.split(" "), t = "", n = "", a = "";
    t = e[0].indexOf("yyyy") > -1 ? e[0].replace(/dd/g, "d").replace(/MM/g, "m").replace(/yyyy/g, "Y") : e[0].replace(/dd/g, "d").replace(/MM/g, "m").replace(/yy/g, "y");
    try { n = e[1].replace(/hh/g, "H").replace(/mm/g, "i").replace(/ss/g, "s") } catch (i) { }
    try { a = e[2].replace(/tt/g, "a").replace(/TT/g, "A"), a.indexOf("a") > -1 | a.indexOf("A") > -1 && (n = n.replace(/H/g, "h"), n += " " + a) } catch (i) { } return t + " " + n
} function addZero(e) { return 10 > e && (e = "0" + e), e }
function addAMPM(e, t) { var n = "AM", a = "PM"; return "tt" == t && (n = "am", a = "pm"), 0 == e ? n : 12 == e ? a : e > 12 ? a : n } function vnn_formatdatetime(e) { var t = addZero(e.getDate()), n = addZero(e.getMonth() + 1), a = e.getFullYear(), i = addZero(e.getHours()), r = addZero(e.getMinutes()), o = addZero(e.getSeconds()), l = ngayhethong, c = ngayhethong.split(" "), s = "", d = ""; c[0].indexOf("yyyy") > -1 ? l = l.replace(/yyyy/g, a) : (a = a.toString().substring(2, 4), l = l.replace(/yy/g, a)); try { d = c[2], d.indexOf("tt") > -1 | d.indexOf("TT") > -1 && (s = addAMPM(i, d), 0 == i ? i = 12 : i > 12 && (i = addZero(i - 12))) } catch (h) { } return l = l.replace(/dd/g, t).replace(/MM/g, n).replace(/hh/g, i).replace(/mm/g, r).replace(/ss/g, o).replace(/tt/, s).replace(/TT/, s) } function format_ValueNull(e) { return null == e | "" == e && (e = "Thông báo"), e }

function div_load(e,t,n){var a=window.innerWidth,i=window.innerHeight,r=n.clientX,o=n.clientY,l=r-20,c=o-20;
                         "list"!=t?$("#"+e).hasScrollBar()&&$("#"+e).css("width",$("#"+e).width()+20):c+=15,r<a-$("#"+e).width()?
                             $("#"+e).css("left",l):$("#"+e).css("left",l-$("#"+e).width()+20),o<i-$("#"+e).height()?
                             $("#"+e).css("top",c):$("#"+e).css("top",c-$("#"+e).height()+20);
                         $("#"+e).bind("contextmenu",function(t){
                            return false;
                         });
}

function chenthe(e,t){$(e).empty(),$(e).prepend(t)}

//function format_datetime(e){var t=ngayhethong.split(" "),n=t[0].replace(/M/g,"m").replace(/yy/g,"y"),a="",i="",r=!0;try{a=t[1].replace(/h/g,"H")}catch(o){}try{i=t[2],i.indexOf("t")>-1|i.indexOf("T")>-1&&(r=!1,a=a.replace(/H/g,"h"),a+=" "+i)}catch(o){}a.length<=0?$(e).datepicker({dateFormat:n,changeMonth:!0,changeYear:!0}):$(e).datetimepicker({changeMonth:!0,changeYear:!0,showSecond:!1,dateFormat:n,timeFormat:a,use24hours:r}),$(e).addClass("format_vnn formatdate")}
function format_datetime(e, type){
	var t=ngayhethong.split(" "),n=t[0].replace(/M/g,"m").replace(/yy/g,"y"),a="",i="",r=!0;try{a=t[1].replace(/h/g,"H")}catch(o){}
	try{i=t[2],i.indexOf("t")>-1|i.indexOf("T")>-1&&(r=!1,a=a.replace(/H/g,"h"),a+=" "+i)}catch(o){}
	if(a.length<=0 | type == 0) {
		$(e).datepicker({dateFormat:n,changeMonth:!0,changeYear:!0})
	}
	else {
		$(e).datetimepicker({changeMonth:!0,changeYear:!0,showSecond:!1,dateFormat:n,timeFormat:a,use24hours:r})
	}
	$(e).addClass("format_vnn formatdate")
}	

function Check_SpecialCharacter(e) { return /[~`!#$%\^&*+=\-\[\]\\';,./{}|\\":<>\?]/g.test(e) } function format_listbox(e) { var t = null; $(e).click(function (e) { t = e }), $(e).keyup(function () { var n = 200, a = 230, i = 5, r = "list_" + $(e).attr("id"), o = '<div style="display:none"id="selectitem_' + r + '"></div><div id="' + r + '"class="div_fixed"></div>'; $("#" + r).remove(), $(".cl_table_noidung").prepend(o), "<%=" == $(e).val() ? ($.get("Controller/JQGridModify/JQGridMD_00_SelectOptionModify.ashx?oper=loadlist", function (o) { var l = o.split("#"); $("#" + r).jqxListBox({ selectedIndex: -1, source: l, checkboxes: !1, width: n, height: a, scrollBarSize: i }), div_load(r, "list", t), $("#" + r).on("select", function (t) { var n = t.args, a = $("#" + r).jqxListBox("getItem", n.index); null != a && (chenthe("#selectitem_" + r, a.value), $(e).val($("#selectitem_" + r + "a:first").text())) }) }), $("body").dblclick(function () { $("#" + r).remove() })) : $("#" + r).remove() }), $(e).addClass("format_vnn formatlistbox") } function format_password(e) { $(e).attr("type", "password"), $(e).addClass("format_vnn formatpassword") }
function format_number(e, t, n) {
    var a = "", i = "", r = 0, o = sohethong;
    if (1 == t && (o = Check_SpecialCharacter(o[1]) ? o.substring(0, 5) : o.substring(0, 4)), Check_SpecialCharacter(o)) {
        if (Check_SpecialCharacter(o[1])) {
            a = o[1];
            for (var l = o.replace(o[1], ""), c = 0; c < l.length; c++)
                Check_SpecialCharacter(l[c]) ? (i = l[c], r = 1) : r >= 1 && r++;
            if (i == "")
                $(e).number(!0, 0, "", a);
            else {
                if (r > -1) {
                    r -= 1;
                    if (n)
                        r = n;
                    $(e).number(!0, r, i, a);
                }
                else {
                    $(e).number(true);
                }
            }
            //"" == i ? $(e).number(!0, 0, "", a) : (r -= 1, null != n && (r = n), $(e).number(!0, r, i, a))
        } else {
            for (var c = 0; c < o.length; c++)
                Check_SpecialCharacter(o[c]) ? (i = o[c], r = 1) : r >= 1 && r++; r -= 1, null != n && (r = n),
                    $(e).numeric({ decimal: i, decimalPlaces: r })
        }
    }
    else {
        $(e).numeric({ decimal: !1 });
    }
    $(e).addClass("format_vnn formatnumber");
}

function vnn_formatnumber() { var e = "", t = "", n = 0, a = sohethong; Check_SpecialCharacter(a[1]) ? (e = a[1], a.length > 5 && (t = a[5], n = a.length - 6)) : a.length > 4 && Check_SpecialCharacter(a[5]) && (t = a[4], n = a.length - 5); var i = new Array(t, e, n); return i }
function format_image(e) { var t = null; $(e).click(function (e) { t = e }), $(e).click(function () { $("body").append('<div id="dlg_gridSmal_2"title="Tìm hình ảnh"><table><tr><td><input id="rdiClass"type="radio"name="rdiStatus"value="img_Class" /><label for="rdiClass">Hìn ảnh trong Class</label>   <input id="rdiHinhAnh" type="radio" name="rdiStatus" value="img_Content" /><label for="rdiHinhAnh">Hìn ảnh trong Content</label>   <input id="rdiAweSome" type="radio" name="rdiStatus" value="img_Content" /><label for="rdiAweSome">Hìn ảnh trong Content</label></td></tr><tr><td id="td_content"><div class="nhan_loading"></div></td></tr></table></div>'), $("#dlg_gridSmal_2").dialog({ modal: !0, dialogClass: "dialog_index", width: window.innerWidth / 3, height: window.innerHeight - 3, open: function () { $("input:radio[name=rdiStatus]").click(function () { $.get("Controller/PublicFunction/LoadImage.ashx?oper=load_img&check=" + $(this).val() + "&elem=" + $(e).attr("id"), function (t) { $("#td_content").empty(), $("#td_content").prepend(t); var n = $(".nhan_divclass"); $(n).each(function () { if ($(e).val().indexOf("/") < 0) try { $(this).find("span").attr("class").replace("nhan_spanclass ", "") == $(e).val() && $(this).find("span").css("background", "#FCFC6F") } catch (t) { } else try { $(this).find("img").attr("src").indexOf($(e).val()) > -1 && $(this).find("img").css("background", "#FCFC6F") } catch (t) { } $(this).click(function () { n.find("span").removeAttr("style"), n.find("img").removeAttr("style"), $(this).find("span").css("background", "#FCFC6F"), $(this).find("img").css("background", "#FCFC6F") }), $(this).dblclick(function () { $("#dlg_gridSmal_2").dialog("destroy").remove() }) }) }) }), $(e).val().indexOf("/") < 0 ? $("#rdiClass").click() : "fa" == $(e).val().substring(0, 2) ? $("#rdiHinhAnh").click() : $("#rdiAweSome").click() }, close: function () { $(this).dialog("destroy").remove() } }) }), $(e).addClass("format_vnn formatimage") } function get_image(e, t) { $("#" + e).val(t) }
//GridFunction_Load.js
function loadPage(t){
    $('.noidung > .cl_table_noidung').remove();
    $(".noidung").html('<table class="cl_table_noidung" valign="top" style="height: ' + (height_menu_noidung - 10) + ';"><tr><td valign="top" style="padding:20px"><div class="nhan_loading0">&nbsp;</div></td></tr></table>');
    try { xhr_menu.abort(); xhr_content.abort(); } catch (n) { console.log(n); }
    //xhr_menu = $(".noidung").load(, function () { enable_timer = !0 })

    xhr_menu = $.ajax({
        type: "GET",
        url: "View/" + t,
        success: function (msg) {
            $(".noidung").html(msg);
        }
    });
}

function loading_grid(t) {
    $("#load_" + t).css("display", "block")
}
function loadMenu(t) {
    systemload > 0 && window.stop(), enable_timer = !1, $(".menu").load("View/" + t, function () { enable_timer = !0 })
}
function dem_Records() {
    systemload = 0; var t = $(".menu_td_menuchinh tr td table tr td div table tr td a"); $(t).removeAttr("style"), $(t).css("color", "red"); var n = ""; $(t).each(function (i) { n += $(this).attr("name"), i < $(t).length - 1 && (n += ",") }), null != n & "" != n && $.post("Controller/PublicFunction/CountDocument.ashx?oper=countCV", { ma_menu: n }, function (n) { n = n.split("(##)"), $(t).each(function (t) { loadgiatri_demCV($(this).attr("id"), n[t]) }), $(".menu_td_menuchinh tr td table tr td div table tr td a").css("color", "black"), "&nbsp;(0)" != $("#a_MN_01_CVChuaXem").html() && $("#a_MN_01_CVChuaXem").css("color", "rgb(25, 98, 247)"), "&nbsp;(0)" != $("#a_MN_01_CVDangTamDung").html() && $("#a_MN_01_CVDangTamDung").css("color", "rgb(25, 98, 247)"), "&nbsp;(0)" != $("#a_MN_01_CongViecChuaXem").html() && $("#a_MN_01_CongViecChuaXem").css("color", "rgb(25, 98, 247)") })
} function loadgiatri_demCV(t, n) {
    $("#" + t).empty(), $("#" + t).prepend("&nbsp;" + n)
} function loadclick(t, n, i) {
    if (null == id_action[i]) { try { $(".ui-state-error").css("display", "none") } catch (a) { } var e = $("#" + t).jqGrid("getGridParam", "postData").filters, o = $("#" + t).jqGrid("getGridParam", "postData").page, r = $("#" + t).jqGrid("getGridParam", "postData").sord, d = $("#" + t).jqGrid("getGridParam", "postData").sidx; id_oper[i] = n, id_action[i] = i, $("#" + t).jqGrid("setGridParam", { postData: { filters: e, sord: r, sidx: d }, search: !0 }), $("#" + t).trigger("reloadGrid", [{ page: o }]) }
} function loadclick_(t, n) {
    let postDT = $("#" + t).jqGrid("getGridParam", "postData");
    let i = postDT ? postDT.filters : null,
        a = postDT ? postDT.page : null,
        e = postDT ? postDT.sord : null,
        o = postDT ? postDT.sidx : null;

    $("#" + t).jqGrid("setGridParam", { postData: { filters: i, sord: e, sidx: o, oper_action: n }, search: !0 }),
        $("#" + t).trigger("reloadGrid", [{ page: a }]);

    if (postDT) {
        postDT.oper_action = null;
        postDT.id_sel = null;
    }
}
function loadmes(t) {
    try { $(".noidunggui_chatbox").removeAttr("disabled"), $(".noidunggui_chatbox").val(""), $(".duyvu_tr3_td").append('<a onclick="nhan_trotoitextarea()" style="color:#999;font-size:14;position: absolute;margin: 7 0 0 -521;z-index: 10;cursor: text;">Nhập nội dung muốn gửi...</a>'), $(".noidunggui_chatbox").focus(), $(".nhan_noidung").empty(), $(".nhan_noidung").append(t), $(".nhan_noidung").scrollTop(99999999 * $(".nhan_noidung").height()) } catch (n) { }
} function thongbaokhimodify(t, n) {
    var i, a, e = ""; i = $("#TblGrid_" + $.jgrid.jqID(n) + ">tbody>tr.tinfo"), a = i.children("td.topinfo"), a.html(e), i.show(), $(".nhan_loading").remove(); var o = t.split("#")[0]; return "false" == o ? ($(".ui-state-error").removeAttr("style"), !1) : (i.hide(), $(".ui-state-error").empty(), e = '<div class="ui-state-highlight ui-corner-all"><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span><span>' + t.split("#")[1] + "</span></div>", i = $("#TblGrid_" + $.jgrid.jqID(n) + ">tbody>tr.tinfo"), a = i.children("td.topinfo"), a.html(e), i.show(), setTimeout(function () { a.children("div").fadeOut("slow", function () { i.hide() }) }, 5e3), !0)
} function click_loadtrangchu() {
    $(".menu_td_menuchinh tr td table tr td").removeClass("menu_btndanhan"),
        $("#input_trovetrangtruoc").val($("#input_trovetrangtruoc").val() + "/img_btntrangchu"),
        $("#input_tenmenu1").val("Trang chủ"), $("#input_idmenu").val("MNTC"),
        $("#input_urlmenu").val(" modules/Menu/Content/Module/Trangchu_noidungtrangchu.aspx"),
    loadPage("Menu/Content/Module/Trangchu_trangchu.aspx")
}

function click_refreshPage() {
    var t = window.innerHeight - 15;
    if ($("#mainpane").css("height", t), $(".menu").css("height", t - $(".nhan_header").height() - 6),
        $(".noidung").css("height", t - $(".nhan_header").height() - 6),
        $(".cl_table_menu").css("height", window.innerHeight - $(".nhan_header").height() - 26),
        $(".cl_table_noidung").css("height", window.innerHeight - $(".nhan_header").height() - 26),
        $(".menu_div_dongkhung").css("height", t - $(".nhan_header").height() - 38),
        $("div.div_noidung_menu").css("width", window.innerWidth - $(".menu").width() - 28),
        $(".sub_mainpage").hasClass("ui-layout-container"))
        $("div.sub_mainpage").css("height", window.innerHeight - 102),
            $(".module_spanselect").click();
    else {
        var n = $(".ui-search-table tr > .ui-search-input input");
        $(n).each(function () { $(this).val("") }); var i = $(".ui-search-table tr > .ui-search-input select"); $(i).each(function () { $(this).val("") }), $(".ui-pg-div > .ui-icon-refresh").click(), $("div.ui-jqgrid-pager").css("width", window.innerWidth - $(".menu").width() - 28); var a = "div.ui-jqgrid-bdiv", e = "div.ui-jqgrid-hdiv"; $(a).each(function () { $(this).hasClass("frozen-bdiv") || $(this).css("width", window.innerWidth - $(".menu").width() - 28) }), $(e).each(function () { $(this).hasClass("frozen-div") || $(this).css("width", window.innerWidth - $(".menu").width() - 28) }), $("div.ui-jqgrid-view").css("width", window.innerWidth - $(".menu").width() - 28), $("div.ui-jqgrid").css("width", window.innerWidth - $(".menu").width() - 28), "Firefox" == Browser ? ($("div.ui-jqgrid-bdiv").css("height", window.innerHeight - $("#input_docaogrid").val()), $("div.ui-jqgrid-view").css("height", window.innerHeight - $("#input_docaogrid").val() + 75), $("div.sub_mainpage").css("height", window.innerHeight - $("#input_docaogrid").val() + 112)) : ($("div.ui-jqgrid-bdiv").css("height", window.innerHeight - $("#input_docaogrid").val()), $("div.ui-jqgrid-view").css("height", window.innerHeight - $("#input_docaogrid").val() + 76), $("div.sub_mainpage").css("height", window.innerHeight - $("#input_docaogrid").val() + 112))
    }
}
function click_back() { $(function () { $("#input_nhanback").val("true"), $("#input_ghinhomodule").val(""); var t = $("#input_trovetrangtruoc").val().split("/").length - 1, n = $("#input_trovetrangtruoc").val().split("/")[t - 1], i = $("#input_trovetrangtruoc").val().split("/")[t], a = $("#input_trovetrangtruoc").val().length, e = ""; if (n.indexOf("&") < 0 & i.indexOf("&") < 0) { var o = $("#input_trovetrangtruoc").val().split("/")[t].length; a > 16 && $("#input_trovetrangtruoc").val(Remove($("#input_trovetrangtruoc").val(), a - o - 1, a)), e = $("#input_trovetrangtruoc").val(), $("#" + n).click() } else if (i.indexOf("&") > -1) { var r = i.split("&").length - 1, o = i.split("&")[r].length; $("#input_trovetrangtruoc").val(Remove($("#input_trovetrangtruoc").val(), a - o - 1, a)), e = $("#input_trovetrangtruoc").val(); for (var d = r - 1; d >= 1; d--){ var c = i.split("&")[d]; $("#input_ghinhomodule").val($("#input_ghinhomodule").val() + "#" + c) } $("#" + i.split("&")[0]).click() } else { var r = n.split("&").length - 1, o = n.split("&")[r].length; $("#input_trovetrangtruoc").val(Remove($("#input_trovetrangtruoc").val(), a - o - 1, a)), e = $("#input_trovetrangtruoc").val(); for (var d = r; d >= 1; d--){ var c = n.split("&")[d]; $("#input_ghinhomodule").val($("#input_ghinhomodule").val() + "#" + c) } $("#" + n.split("&")[0]).click() } $("#input_trovetrangtruoc").val(e) }) } function click_doimau() { $("body").append('<div id="dlg_dsvt_daketthuc" title="Đổi màu phần mềm theo ý khách hàng"><table id="xemchitietcv" align="left"><tr><td><input class="nhan_radio" type="radio" id="mau_01" name="rdiMau" value="rgba(9, 80, 153, 0.909804)"/></td><td style="background-color:rgba(9, 80, 153, 0.909804); width:50px"></td><td><p>Màu mặc định</p></td></tr><tr class="khoangtrang_tr"><td></td></tr><tr><td><input class="nhan_radio" type="radio" id="mau_02" name="rdiMau" value="rgba(153, 9, 31, 0.8)"/></td><td style="background-color:red; width:50px"></td><td><p>Màu đỏ</p></td></tr><tr class="khoangtrang_tr"><td></td></tr><tr><td><input class="nhan_radio" type="radio" id="mau_03" name="rdiMau" value="rgb(111, 111, 111)"/></td><td style="background-color:grey; width:50px"></td><td><p>Màu xám</p></td></tr><tr class="khoangtrang_tr"><td></td></tr><tr><td><input class="nhan_radio" type="radio" id="mau_04" name="rdiMau" value="rgb(72, 137, 61)"/></td><td style="background-color:rgb(72, 137, 61); width:50px"></td><td><p>Màu xanh lá cây</p></td></tr><tr class="khoangtrang_tr"><td></td></tr><tr><td><input class="nhan_radio" type="radio" id="mau_05" name="rdiMau" value="rgb(90, 24, 142)"/></td><td style="background-color:rgb(90, 24, 142); width:50px"></td><td><p>Màu tím</p></td></tr></table></div>'), $("#dlg_dsvt_daketthuc").dialog({ modal: !1, width: 260, height: 250, open: function () { $.get("Controller/PublicFunction/ConfigSystem.ashx?oper=loadColor", function (t) { $("#" + t).attr("checked", !0) }), $(".nhan_radio").change(function () { $("#mainpane").css("background-color", $(this).val()), load_doimau_client($(this).attr("id")) }) }, close: function () { load_doimau(this) }, buttons: [{ id: "btn-ok", text: "Lưu", click: function () { var t = $("input[name=rdiMau]:checked"); $("#dlg_dsvt_daketthuc").prepend('<div class="nhan_loading"></div>'), $.post("Controller/PublicFunction/ConfigSystem.ashx?oper=changeColor&mausac=" + t.attr("id"), function () { $(".nhan-loading").remove() }), load_doimau(this) } }, { id: "btn-close", text: "Thoát", click: function () { load_doimau(this) } }] }) } function load_doimau_client(t) { "mau_01" == t ? ($(".div_chiacach").css("background-color", "rgba(247, 247, 247, 0.95)"), $(".nhan_header").css("background", 'url("images/toolbar0.png")'), $(".label_bg_body").css("background-image", "url(images/Menu/menu_labelBody.png)"), $(".label_bg_right").css("background-image", "url(images/Menu/menu_labelRight.png)"), $(".label_bg_left").css("background-image", "url(images/Menu/menu_labelLeft.png)"), $("#mainpane").css("background-color", "rgba(9, 80, 153, 0.909804)")) : "mau_02" == t ? ($(".div_chiacach").css("background-color", "rgb(175, 70, 66)"), $(".nhan_header").css("background", 'url("images/toolbar_mau_02.png")'), $(".label_bg_body").css("background-image", "none"), $(".label_bg_right").css("background-image", "none"), $(".label_bg_left").css("background-image", "none"), $("#mainpane").css("background-color", "rgba(153, 9, 31, 0.8)")) : "mau_03" == t ? ($(".div_chiacach").css("background-color", "rgb(121, 116, 117)"), $(".nhan_header").css("background", 'url("images/toolbar_mau_03.png")'), $(".label_bg_body").css("background-image", "none"), $(".label_bg_right").css("background-image", "none"), $(".label_bg_left").css("background-image", "none"), $("#mainpane").css("background-color", "rgb(111, 111, 111)")) : "mau_04" == t ? ($(".div_chiacach").css("background-color", "rgb(72, 137, 61)"), $(".nhan_header").css("background", 'url("images/toolbar_mau_04.png")'), $(".label_bg_body").css("background-image", "none"), $(".label_bg_right").css("background-image", "none"), $(".label_bg_left").css("background-image", "none"), $("#mainpane").css("background-color", "rgb(72, 137, 61)")) : "mau_05" == t && ($(".div_chiacach").css("background-color", "rgb(90, 24, 142)"), $(".nhan_header").css("background", 'url("images/toolbar_mau_05.png")'), $(".label_bg_body").css("background-image", "url(images/Menu/menu_labelBody.png)"), $(".label_bg_right").css("background-image", "url(images/Menu/menu_labelRight.png)"), $(".label_bg_left").css("background-image", "url(images/Menu/menu_labelLeft.png)"), $("#mainpane").css("background-color", "rgb(90, 24, 142)")) } function load_doimau(t) { $.get("Controller/PublicFunction/ConfigSystem.ashx?oper=loadColor", function (n) { load_doimau_client(n), null != t && $(t).dialog("destroy").remove() }) }
function load_menurightclick(tg, n, f) {
	let i=$("#gview_"+ tg +" .ui-jqgrid-bdiv");
	i=null==i.attr("class") ? tengrid2:"#gview_"+ tg +" .ui-jqgrid-bdiv";
	for(let a=i.split(","),e=0;e<a.length;e++) {
		$(a[e]).bind("contextmenu",function(t){
			if(2==t.button) {
				$(this).click();
				$("#div_chuotphai").remove();
				$(".cl_table_noidung").prepend(n);
				div_load("div_chuotphai",n,t);
				if(f) {
					f();
				}
				return false;
			}
			else {
				return false;
			}
		})
	}
}

function load_menuleftclick(t,n){
	let i=$("#gview_"+t+" .ui-jqgrid-bdiv");
	i=null==i.attr("class")?tengrid2:"#gview_"+t+" .ui-jqgrid-bdiv";
	for(let a=i.split(","),e=0;e<a.length;e++)
		$(a[e]).click(function(){$(".cl_div_chuathanhcongcu").html(n)})
}
	
	
function fix_loi_screen(){$("#logo_right").css("background-color","ccc"),$.get("Controller/JQGridModify/JQGridMD_00_MNZModify.ashx?oper=fixloi_nhieunguoixuly",function(){$("#logo_right").removeAttr("style")})}
//--
function checkbox_JQgrid_(t, n) {
	$("." + t).change(function() {
        action_checkbox_JQgrid(t, n)
    });
	
	$("." + t).dblclick(function() {
        return !1
    });
	
	$("." + t).parent().prev().click(function(){
		return !1
	});
}

function checkbox_JQgrid(t, n) {
    var i = $("#" + t).jqGrid("getDataIDs");
	if(n == 1) {
		for (var a in i) {
			checkbox_JQgrid_("jqg_" + t + "_" + i[a], t);
			action_checkbox_JQgrid("jqg_" + t + "_" + i[a], t);
		}
		$(".cb_" + t).click(function() {
			for (var b in i) {
				action_checkbox_JQgrid("jqg_" + t + "_" + i[b], t);
			}
		});
	}
	else {
		$('#' + t + ' > tbody > .jqgrow > td').removeClass('sel_checkbox_jqg');
		$('#' + t + '_frozen > tbody > .jqgrow > td').removeClass('sel_checkbox_jqg');
		i = $('#' + t).jqGrid('getGridParam', 'selarrrow');
		for(var a in i) {
			action_checkbox_JQgrid("jqg_" + t + "_" + i[a], t, 1);
		}
	}
}

function action_checkbox_JQgrid(t, n, a) {
	var parent_t = $("." + t).parent();
    $(parent_t).removeClass('sel_checkbox_jqg');
	if($("." + t).prop("checked") == true | a == 1) {
		$(parent_t).addClass('sel_checkbox_jqg');
	}
}
//--
function NumberESC(e){
	var dec = vnn_formatnumber()[0];
	e = e.toString().replace('.',dec);
	return e;
}
//--
function logout(){$("#mainpane").append('<div id="dlg_gridSmall" title="Thoát chương trình"><a>Bạn có chắc chắn muốn thoát khỏi chương trình?</a></div>'),$("#dlg_gridSmall").dialog({modal:!0,height:110,open:function(){Logo_Center("glyphicon glyphicon-log-out",!0)},close:function(){$(this).dialog("destroy").remove()},buttons:[{id:"btn-ok",text:"Đồng ý",click:function(){reload_page=!0,enable_timer=!1,window.location.href="Controller/PublicFunction/LogOut.ashx"}},{id:"btn-close",text:"Thoát",click:function(){$(this).dialog("destroy").remove()}}]})}
//GridShow.js
function phanmauchogrid(a){return a%2==0?" myAltRowClass":" "}function colspanedit(a,e){var i=$("#"+a),t=(i.children("td.CaptionTD"),i.children("td.DataTD"));t.attr("colspan",e),t.children("textarea").css("width","99%")}function clearSearchOptions(a){$("#refresh_"+a).click(function(){$("#gview_"+a+" .ui-jqgrid-hdiv > .ui-jqgrid-hbox table tr th div table tr > .ui-search-input input").val("")})}function multiSelectHandler(a,e){var i=$(e.target).closest("table.ui-jqgrid-btable"),t=i[0],s=e.target,n=$(s).hasClass("cbox");if("INPUT"==s.tagName&&!n||"A"==s.tagName)return!0;var c=i.getGridParam("selarrrow"),r=$.inArray(a,c)>=0;if(e.ctrlKey||n&&(r||!e.shiftKey))i.setSelection(a,!0);else{if(e.shiftKey){var l=i.getInd(a),d=l,o=l;for($.each(c,function(){var a=i.getInd(this);d>a&&(d=a),a>o&&(o=a)});o>=d;){var u=t.rows[d++],h=u.id;h!=a&&$.inArray(h,c)<0&&i.setSelection(u.id,!1)}}else r||i.resetSelection();if(r){var g=i.getGridParam("onSelectRow");$.isFunction(g)&&g(a,!0)}else i.setSelection(a,!0)}}function setbackgroundforgrid(a,e,i){var t,s,n,c=(getColumnIndexByName($(a),"closed"),a.rows.length);for(t=0;c>t;t++)s=a.rows[t],n=s.className.replace(/ VNN_css_rows/g,""),s.cells.item(e).innerHTML!=i?s.className=n+" VNN_css_rows":s.className=n.replace(/ VNN_css_rows/g,"")}function Remove(a,e,i){return a.substr(0,e)+a.substr(e+i)}function countRows(a,e){var i=jQuery("#"+a).jqGrid("getGridParam","records");if(null==e|""==e)return i;var t=$("#"+a+" tr:nth-child(2)").attr("id");null!=t&"0"!=t&"-"!=t?$("#"+e).val(i):$("#"+e).val(0)}function Focus_Selection(a){var e=$("#"+a).jqGrid("getGridParam","selrow");scrollToRow($("#"+a),e)}function getGridRowHeight(a,e){var i=null;try{var t=jQuery(a).find("tbody").find("tr");$(t).each(function(a){return e>a?void(i+=$(this).outerHeight()):!1})}catch(s){}return i}function scrollToRow(a,e){var i=jQuery(a).getInd(e),t=getGridRowHeight(a,i)||23;jQuery(a).closest(".ui-jqgrid-bdiv").scrollTop(t-20)}function SetWidth_BtnHeader(a){var e=a-3,i=e,t=$(".cl_div_chuathanhcongcu div"),s=$(".cl_div_chuathanhcongcu div > img.img_btnmacdinh");$(s).length>a&&($(s).each(function(a){a>e&&$(this).addClass("case_hidden")}),$(t).prepend('<img src="images/Content/content_quatrai2.png" id="case_quatrai" class="img_btnmacdinh2" title="Qua trái" />'),$(t).append('<img src="images/Content/content_quaphai2.png" id="case_quaphai" class="img_btnmacdinh2" title="Qua phải" />'),$("#case_quatrai").click(function(){$("#case_quatrai").hasClass("case_disable")||(i>e&&(i-=e),$(s).each(function(a){i>=a?$(this).removeClass("case_hidden"):$(this).addClass("case_hidden")}),$("#case_quaphai").removeClass("case_disable"),$(".cl_div_chuathanhcongcu div > img.img_btnmacdinh:first").hasClass("case_hidden")||$("#case_quatrai").addClass("case_disable"))}),$("#case_quaphai").click(function(){$("#case_quaphai").hasClass("case_disable")||($(s).each(function(a){a>i?$(this).removeClass("case_hidden"):$(this).addClass("case_hidden")}),i<$(s).length&&(i+=e),$("#case_quatrai").removeClass("case_disable"),$(".cl_div_chuathanhcongcu div > img.img_btnmacdinh:last").hasClass("case_hidden")||$("#case_quaphai").addClass("case_disable"))}),$("#case_quatrai").click())}var getColumnIndexByName=function(a,e){for(var i=a.jqGrid("getGridParam","colModel"),t=0,s=i.length;s>t;t++)if(i[t].name===e)return t;return-1};
//JQGridver2.js
function check_click_rutgon(t,a){var i="unclick_div"+a,e="click_div"+a;$(t).hasClass(e)?($(t).removeClass(e),$(t).removeClass("glyphicon-plus"),$(t).addClass(i),$(t).hasClass("glyphicon-minus")||$(t).addClass("glyphicon-minus")):($(t).removeClass(i),$(t).removeClass("glyphicon-minus"),$(t).addClass(e),$(t).hasClass("glyphicon-plus")||$(t).addClass("glyphicon-plus"))}function check_click_rutgon2(t,a){var i="unclick_div"+a,e="click_div"+a;$(t).removeClass(e),$(t).hasClass(i)||$(t).addClass(i),$(t).removeClass("glyphicon-plus"),$(t).hasClass("glyphicon-minus")||$(t).addClass("glyphicon-minus")}function check_click_rutgon3(t){for(var a=0;3>a;a++){var i="unclick_div"+a,e="click_div"+a;$(t+a).hasClass(e)&&($(t+a).removeClass(e),$(t+a).addClass(i),$(t+a).removeClass("glyphicon-plus"),$(t+a).hasClass("glyphicon-minus")||$(t+a).addClass("glyphicon-minus"))}}function click_rutgon_div(t){var a=$("#div_getdt_2").outerHeight();$("#div_getdt_1").outerHeight(),$("#div_getdt_0").outerHeight();0==t?$(".btn_check_div0").hasClass("click_div0")?5>=a?layout_vnn.sizePane("north","50%"):(layout_vnn.sizePane("north","33%"),layout_vnn.sizePane("south","33%")):(layout_vnn.sizePane("north","4%"),a>5&&layout_vnn.sizePane("south","49%"),setTimeout(function(){check_click_rutgon2($(".btn_check_div1"),1),check_click_rutgon2($(".btn_check_div2"),2)},100)):1==t?$(".btn_check_div1").hasClass("click_div1")?5>=a?layout_vnn.sizePane("north","49%"):layout_vnn.sizePane("north","33%"):5>=a?layout_vnn.sizePane("north","95%"):27>=a?layout_vnn.sizePane("north","92%"):layout_vnn.sizePane("north","63%"):2==t&&($(".btn_check_div2").hasClass("click_div2")?(layout_vnn.sizePane("north","33%"),layout_vnn.sizePane("south","33%")):(layout_vnn.sizePane("south","4%"),layout_vnn.sizePane("north","49%"),setTimeout(function(){check_click_rutgon2($(".btn_check_div0"),0),check_click_rutgon2($(".btn_check_div1"),1)},100))),check_click_rutgon($(".btn_check_div"+t),t)}function load_detail(t,a,i,e,n){var s=".ui-layout-center > .ui-tabs-nav > .ui-state-active",l=".ui-layout-south > .ui-tabs-nav > .ui-state-active",r="";if(1==a?$(s).each(function(){return null==$(this).attr("style")?(r=$(this).attr("aria-controls").replace("tabs_",""),!1):$(this).attr("style").indexOf("display: none;")<=-1?(r=$(this).attr("aria-controls").replace("tabs_",""),!1):void 0}):2==a?$(l).each(function(){return null==$(this).attr("style")?(r=$(this).attr("aria-controls").replace("tabs_",""),!1):$(this).attr("style").indexOf("display: none;")<=-1?(r=$(this).attr("aria-controls").replace("tabs_",""),!1):void 0}):(r=a,display_hidden(n,e,r)),0==t){if(1==a){var o=".ui-layout-north > .ui-tabs-nav > .ui-state-active";display_hidden(0,$(o).attr("sel_mod"),r)}else if(2==a){var o=".ui-layout-center > .ui-tabs-nav > .ui-state-active";display_hidden(1,$(o).attr("sel_mod"),r)}if(""!=r){1==n&&$("div.modcha_"+e).html(""),$("#tabs_"+r).html('<div class="nhan_loading0"></div>');try{xhr_menu.abort()}catch(c){}enable_timer=!1,xhr_menu=$.get("View/Menu/Content/Module/"+r+".aspx",function(t){$("#tabs_"+r).html(t),2!=n&&check_click_rutgon3(".btn_check_div"),enable_timer=!0})}}else try{if(0==i){var u=$("#"+tengrid0).jqGrid("getGridParam","selrow");if(id_parent1!=u|1==load_grid0){switch(id_parent1=u,load_grid0){case"3":$("#"+tengrid1).trigger("reloadGrid");break;default:$("#"+tengrid1)[0].triggerToolbar()}load_grid0=2}}else if(1==i){var u=$("#"+tengrid1).jqGrid("getGridParam","selrow");id_parent2!=u|1==load_grid1&&(id_parent2=u,load_grid1=2,$("#"+tengrid2)[0].triggerToolbar())}}catch(c){}}function display_hidden(t,a){var i=".ui-layout-center > .ui-tabs-nav > ",e=".ui-layout-south > .ui-tabs-nav > ",n=".ui-layout-center > ",s=".ui-layout-south > ";if(0==t){var l=i+".ui-state-default",r=i+".modcha_"+a,o=n+".ui-tabs-panel",c=n+".modcha_"+a;$(l).hide(),$(o).hide(),$(r).show(),$(c).show(),$(r).each(function(){if($(this).hasClass("ui-state-active")){var t=$("#"+$(this).attr("aria-controls"));return $(t).insertAfter(".ul_mod_1"),!1}}),null==$(r).first().attr("class")&&(layout_vnn.sizePane("south","1%"),layout_vnn.sizePane("north","99%"))}else if(1==t){var u=e+".ui-state-default",h=e+".modcha_"+a,d=s+".ui-tabs-panel",_=s+".modcha_"+a;$(u).hide(),$(d).hide(),$(h).show(),$(_).show();var v=0,y=null,g=null;$(h).each(function(t){return $(this).hasClass("ui-state-active")?(g=$("#"+$(this).attr("aria-controls")),$(g).insertAfter(".ul_mod_2"),!1):void(0==t?(y=$(this),g=$("#"+$(this).attr("aria-controls")),v++):v++)}),v>=$(h).length&&null!=y&null!=g&&($(y).addClass("ui-state-active"),$(g).insertAfter(".ul_mod_2")),null==$(h).first().attr("class")?(layout_vnn.sizePane("north","49%"),layout_vnn.sizePane("south","1%")):(layout_vnn.sizePane("north","35%"),layout_vnn.sizePane("south","33%"))}}
//CheckBrowser.js
function check_zoom(){return DPR=window.devicePixelRatio,DPR<=1?zoomLevel="0":DPR<=1.1?zoomLevel="1":DPR<=1.3&&(zoomLevel="1"),zoomLevel}var Browser=navigator.userAgent;Browser=Browser.indexOf("MSIE")>=0?"MSIE":Browser.indexOf("Firefox")>=0?"Firefox":Browser.indexOf("Chrome")>=0?"Chrome":Browser.indexOf("Safari")>=0?"Safari":Browser.indexOf("Opera")>=0?"Opera":"UNKNOWN";