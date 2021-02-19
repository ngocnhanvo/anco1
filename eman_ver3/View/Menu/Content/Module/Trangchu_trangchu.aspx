<%@ Page Language="C#" %>

<table class="cl_table_noidung" valign="top" >
    <!-- cong cu them sua xoa mac dinh -->
    <tr class="cl_tr_thanhcongcu">
        <td colspan="6">
            <div class="sub_trangthu" style="padding:28px 0 0 8px;background:none; border:none">
                <div style="    
                    background-image: url(images/Menu/Menu_bordertop.png);
                    background-repeat: repeat-x;
                    position: absolute;
                    width: 100%;
                    height: 21px;
                    border-radius: 4px 0px 0px 0px;
                    "
                ></div>
                <iframe id="frameReport" src="extension/report.aspx" style="width: 100%; height: 100%; border: 1px solid rgba(157,159,180,.35); border-radius: 4px 0px 0px 0px;"></iframe>
            </div>
        </td>
    </tr>
    <!-- #load noi dung theo module -->
</table>

<script type="text/javascript"> 
    //var img = '<img style="margin-top:10%" src="' + logo_trangchu + '?ver1" alt=""' +
    ////' height="' + (window.innerHeight - 117) + 'px"' +
    //' />';

    //$('.sub_trangthu').append(img);
    let frameReport = $("#frameReport");
    let loaded = false;
    frameReport.load(function () {
        if (!loaded) {
            let content = frameReport.contents().find("html");
            //content.css('background-image', 'url(../images/Menu/Menu_bordertop.png)');
            //content.css('background-repeat', 'repeat-x');
            loaded = true;
        }
    });
    $('.sub_trangthu').css('height', height_menu_noidung - 30 * transformAll);
</script>