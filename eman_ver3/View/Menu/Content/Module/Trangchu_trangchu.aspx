<%@ Page Language="C#" %>

<table class="cl_table_noidung" valign="top" >
    <!-- cong cu them sua xoa mac dinh -->
    <tr class="cl_tr_thanhcongcu">
        <td colspan="6" valign="top" >
            <div class="sub_trangthu" align="center" style="padding:30px 0 0 0;background:none; border:none">
            </div>
        </td>
    </tr>
    <!-- #load noi dung theo module -->
</table>

<script type="text/javascript"> 
    var img = '<img style="margin-top:10%" src="' + logo_trangchu + '" alt=""' +
    //' height="' + (window.innerHeight - 117) + 'px"' +
    ' />';

    $('.sub_trangthu').append(img);
    $('.sub_trangthu').css('height', window.innerHeight - 85); 
</script>