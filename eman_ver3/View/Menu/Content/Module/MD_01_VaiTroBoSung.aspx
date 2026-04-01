<%@ Page Language="C#" %>
<%
    string ma_module = "MD_01_VaiTroBoSung";

    string[] get_records = VNN_Config.get_records();
    string[] get_STTaID = VNN_Config.get_IDParent_STTLoad(ma_module);
    string[] colModel = VNN_Config.get_colModel(Context, ma_module);
    string[][] modifyForm = VNN_Config.get_ModifyFormInfor(ma_module);
%>


<table id='grid<%=ma_module %>'></table>
<div id='pagergrid<%=ma_module %>'></div>

<script type="text/javascript">
    //bien load grid
    var input_focus=null, load_grid = 0;
    var rownum = Number(<%=get_records[0] %>);
    //Cac bien can truyen vao truoc khi load chuc nang
    //--bien bat buoc
    var load_stt = <%=get_STTaID[0] %>;
    var id_parent = <%=get_STTaID[1] %>;
    var tengrid = 'grid<%=ma_module %>';
    var Form_infor = '<%=VNN_VariablePublic.Form_infor %>';
    var Model_infor = '<%=VNN_VariablePublic.Model_infor %>' ;
    //--#bien bat buoc
    //#Cac bien can truyen vao truoc khi load chuc nang
    //Load chức năng
    <%=VNN_Config.get_NavFunc(Context, ma_module) %>
    //#Load chức năng
</script>

<script type="text/javascript">
    jQuery('#'+tengrid).jqGrid({
        url: 'Controller/JqGrid/JQGrid<%=ma_module%>Load.ashx?ma_module=<%=ma_module%>&ma_menu='+$('#input_idmenu').val() + '&id='+id_parent,
        editurl: 'Controller/JQGridModify/JQGrid<%=ma_module%>Modify.ashx?ma_module=<%=ma_module %>&ma_menu='+$('#input_idmenu').val() + '&id='+id_parent,
        height: (window.innerHeight - $('#input_docaogrid').val()),
        datatype: 'json',
        autowidth: true,
        shrinkToFit: true,
        rownumbers: true,
        viewrecords: true,
        search: true,
        scroll:false,                    
		multiselect: <%=get_STTaID[3] %>,
        multiboxonly: <%=get_STTaID[3] %>,
        rowNum: rownum,
        rowList: <%=get_records[1] %>,
        pager: '#pager'+tengrid,
        onSelectRow: function (ids) {
            // public id da chon
			id_<%=ma_module %> = ids;
            if(ids != null & ids !='' & ids !='0'){
				//checkbox customize
				checkbox_JQgrid(tengrid, 0);
                var value_header = '', cell = $("#"+ tengrid).getRowData(ids);
                if (id_parent != null) { 
                    value_header = <%=get_STTaID[1].Replace("id_","header_") %>;  
                    header_<%=ma_module %> = value_header + header_sep + <%=get_STTaID[2] %>;
                }
                else {
                    header_<%=ma_module %> = value_header + <%=get_STTaID[2] %>;
                }
                set_headerJQG(tengrid, header_<%=ma_module %>);
            }
        },
        ondblClickRow: function(e){
            <%=get_STTaID[4] %>;
        },
        colModel: [
            <%=colModel[0] %>
        ],
        beforeRequest: function() {
            //giữ focus
            input_focus = $('input:focus').attr('class');
            //giữ filter start
            if(id_oper[load_stt] == null)
                $('#' + tengrid).jqGrid('getGridParam', 'postData').id_sel = id_<%=ma_module %>;
				
            $('#' + tengrid).jqGrid('getGridParam', 'postData').module_select = module_select[0];
			
            set_Filter(load_grid, tengrid, '<%=ma_module %>');
        },
        gridComplete: function () {
            $(this).jqGrid('setGridWidth', $(this).parent().parent().parent().parent().parent().width());
            taonut_header();
        },
        loadComplete: function (data) {
            //chia màu chẵn lẻ
            phanmauchogrid(this);
            if(id_<%=ma_module %> != null & id_<%=ma_module %> != '0')
				$('#' + tengrid).jqGrid('setSelection', id_<%=ma_module %>);
			module_select[1] = 1;
            var b = $('#' + tengrid).jqGrid ('getGridParam', 'selrow');
			var top_rowid = $('#' + tengrid + ' tr:nth-child(2)').attr('id');
            if (b == null | b == '') {
                if(top_rowid != null & top_rowid != 0)
                    $('#' + tengrid).jqGrid('setSelection', top_rowid);
				else
					module_select[1] = 2;
            }
            else {
				//click vào dòng vừa tạo mới
				if(id_new == '0' | id_new == null)
				{	/*$('#'+tengrid).jqGrid('setSelection', id_<%=ma_module %>);*/ }
				else
				{  $('#'+tengrid).jqGrid('setSelection', id_new); id_new = '0';}
				Focus_Selection(tengrid);
            }
            //làm mới bộ lọc
            clearSearchOptions(tengrid);
            //giữ filter end
            if (load_grid == 0)
            {
                fix_disableSelect(tengrid);
                set_ValueFilter(tengrid, filterVal_<%=ma_module %>, sord_<%=ma_module %>, sidx_<%=ma_module %>);
                load_grid = 1;
                if(top_rowid == '0') {
                    setTimeout(function(){click_refreshPage();},200);
                }
            }
            else
            {
                filterVal_<%=ma_module %> = get_ValueFilter(tengrid);
            }
			//checkbox customize
			checkbox_JQgrid(tengrid, 1);
            //giữ focus end
            $('.'+input_focus).focus();
        },
        caption: ' '
    });


    jQuery('#'+tengrid).jqGrid('navGrid', '#pager'+tengrid,
    {
        <%=VNN_Config.get_navGrid(Context, ma_module) %>
    },{
    //edit
        beforeShowForm: function (formid) {
            <%=modifyForm[0][0] %>
            <%=modifyForm[0][1] %>
            <%=modifyForm[0][2] %>
            <%=modifyForm[0][3] %>
        },
        afterShowForm: function (formid) {
            <%=colModel[1]%>
            <%=colModel[5] %>
            <%=colModel[6] %>
            Change_Value(Avariable(),'edit');
        },
        beforeSubmit: function (postdata, formid) {
            formid.prepend('<div class="nhan_loading">&nbsp;</div>');
            return [true, ''];
        },
        afterSubmit: function (response, formid) {
            
            if(thongbaokhimodify(response.responseText,this.id) == false)
            {
                return [false, response.responseText.split('#')[1]];
            }
            else
            {
                <%=colModel[5] %>
                <%=modifyForm[0][4] %>
                add_edit_del_complete('edit'); loadclick(tengrid,'edit',load_stt);
                return [false, ''];
            }
        }
    },{
    //add
        beforeShowForm: function (formid) {
            <%=modifyForm[1][0] %>
            <%=modifyForm[1][1] %>
            <%=modifyForm[1][2] %>
            <%=modifyForm[1][3] %>
        },
        afterShowForm: function (formid) {
            <%=colModel[2]%>
            <%=colModel[3] %>
            <%=colModel[5] %>
            <%=colModel[7] %>
            Change_Value(Avariable(),'add');
            countRows(tengrid, 'sapxep');
        },
        beforeSubmit: function (postdata, formid) {
            formid.prepend('<div class="nhan_loading">&nbsp;</div>');
            return [true, ''];
        },
        afterSubmit: function (response) {
            
            if(thongbaokhimodify(response.responseText,this.id) == false)
            {
                return [false, response.responseText.split('#')[1]];
            }
            else
            {
                <%=colModel[4] %>
                <%=colModel[5] %>
                <%=modifyForm[1][4] %>
                id_new = response.responseText.split('#')[2]; countRows(tengrid, 'sapxep');
                add_edit_del_complete('add'); loadclick(tengrid,null,load_stt); 
                return [false, ''];
            }
        }
    },{
    //del
        beforeShowForm: function (formid) {
            <%=modifyForm[2][0] %>
            <%=modifyForm[2][1] %>
            <%=modifyForm[2][2] %>
            <%=modifyForm[2][3] %>
        },
        afterShowForm: function (formid) {
        },
        beforeSubmit: function (postdata, formid) {
            $('#DelTbl_'+tengrid).prepend('<div class="nhan_loading">&nbsp;</div>');
            return [true, ''];
        },
        afterSubmit: function (response) {
            
            if(thongbaokhimodify(response.responseText,this.id) == false)
            {
                return [false, response.responseText.split('#')[1]];
            }
            else
            {
                <%=modifyForm[2][4] %>
                add_edit_del_complete('del'); loadclick(tengrid, null,load_stt);
                return [false,''];
            }
        }
    }, {
    //search
        beforeShowForm: function (formid) {
            formid.closest('div.ui-jqdialog').dialogCenter();
        }
    }, {
    //view
        beforeShowForm: function (formid) {
            <%=modifyForm[3][0] %>
            <%=modifyForm[3][1] %>
            <%=modifyForm[3][2] %>
            <%=modifyForm[3][3] %>
        },
        afterShowForm: function (formid) {
        },
    },{
    //refesh
    });
    jQuery('#'+tengrid).jqGrid('filterToolbar', { searchOnEnter: false, stringResult: true });
    jQuery('#pager'+ tengrid +'_left table').css('display','none');
    jQuery('#'+tengrid).jqGrid('setFrozenColumns');

    //Start Ham ho tro them cho Grid (sẽ tự update nếu module chính update)
    function Avariable() {
        var column_array = [];
        return column_array;
    }
    //--
    function Change_Value(column_array, action)
    {
        for(var i in column_array) {
            $('#' + column_array[i]).change(function() {
                 action_grid(action, $(this).attr('id'));
            });
        }
        action_grid(action, null);
    }
    //--
    function action_grid(action, column){
        if(action == 'add') {
        

        }
        else if(action == 'edit') {
        

        }
    }
    //--
    function add_edit_del_complete(action){
        if(action = 'add') {
        }
        else if(action = 'edit') {
        }
        else if(action = 'del') {
        }
    }
    //#End Ham ho tro them cho Grid (sẽ tự update nếu module chính update)
</script>
