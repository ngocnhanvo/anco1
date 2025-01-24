<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<link rel="shortcut icon" href="images/logo/anco_logo.ico"/>
	<title>eMan</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/layout-default.css" rel="stylesheet" type="text/css" />
	<link href="css/VNN_css/Content.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
	<link href="css/bootstrap-awesome.css" rel="stylesheet" type="text/css" />
    <link href="css/VNN_css/Login.css" rel="stylesheet" type="text/css" />
	<script src="js/Public_script/jquery-1.10.2.js" type="text/javascript"></script>
	<script src="js/VNN_script/GridFunction_Admin.js" type="text/javascript"></script>
    <script src="https://unpkg.com/html5-qrcode"></script>
</head>
    <body>
        <div id="qrcodeBG">
            <div id="qr-reader">

            </div>
            <input type="button" id="btnThoatVid" value="ngưng quét mã QRCode và thoát màn hình này" />
        </div>
	    <div id="wapper-layout" class="ui-layout-center">
		    <div style="background-color: #fff;" id="main0" class="ui-layout-north toolbar">
			    <div align="center" style="background: url('images/bg-logo.png') no-repeat center center; position: relative; top: -8px; left: 10px; height: 105px; width: 200px;"> 
                    <img class="img_updatelinq" style="margin-top: 10px; height: 75px;" src="<%=logo %>"/>
			    </div>
		    </div>
		    <div class="ui-layout-center" style="background: #efefef; width:100%;">
			    <div style="background-color: #fff;">
				    <div id="main1" style="">
					    <div style="display:table; margin: 0px auto;">
						    <table style="float:left">
							    <tr>
								    <td colspan="3">
									    <div class="panel_lang" style="height:20px;">
										    <div style="float:right"></div>
										    <div style="float:right"></div>
										    <div style="clear:both;"></div>
									    </div>
								    </td>
							    </tr>
							    <tr>
								    <td colspan="3"></td>
							    </tr>
							    <tr>
								    <td colspan="3"></td>
							    </tr>
							    <tr>
								    <td></td>
								    <td style="font-size:11px; text-align:left; color:#3883cc">
										<div class="nhan_div"><a class="nhan_a">Lấy đơn hàng từ phần mềm AncoTrading</a></div>
										<div class="nhan_div"><a class="nhan_a">Quản lý kế hoạch đặt hàng của bộ phận kế hoạch</a></div>
									    <div class="nhan_div"><a class="nhan_a">Quản lý đặt hàng phân xưởng của bộ phận kế hoạch</a></div>
										<div class="nhan_div"><a class="nhan_a">Tạo YC mua ngoài TP/BTP của phòng kế hoạch</a></div>
									    <div class="nhan_div"><a class="nhan_a">Tạo YC mua vật tư của bộ phận kế hoạch</a></div>
									    <div class="nhan_div"><a class="nhan_a">Đặt mua vật tư khác của xưởng</a></div>
									    <div class="nhan_div"><a class="nhan_a">Quản lý kế hoạch mua VT,BTP,TP của phòng VT-KT</a></div>
									    <div class="nhan_div"><a class="nhan_a">Quản lý nhập kho VT,BTP,TP của phòng VT – KT</a></div>
										<div class="nhan_div"><a class="nhan_a">Quản lý kho, lịch sử nhập xuất kho</a></div>
									    <div class="nhan_div"><a class="nhan_a">Quản lý sản xuất của phân xưởng</a></div>
									    <div class="nhan_div"><a class="nhan_a">Cập nhật tiến độ sản xuất của phân xưởng</a></div>
										<div class="nhan_div"><a class="nhan_a">Quản lý xuất VT,PK,BTP ra phân xưởng</a></div>
									    <div class="nhan_div"><a class="nhan_a">Quản lý xuất bán hàng hóa</a></div>
									    <div class="nhan_div_a" style="margin: 8px 0 0 0;"><span>Cùng nhiều tính năng ưu việt khác</span></div>
								    </td>
							    </tr>
							    <tr> </tr>
						    </table>
						    <form name="form1" style="float:left" method="post" runat="server" action="Login.aspx" id="form1">
							    <table id="tb_from">
								    <tr>
									    <td colspan="3" style="font-weight: 800;font-size: 15px;padding: 17px 16px 3px 16px;">Vui lòng đăng nhập để vào hệ thống</td>
								    </tr>
								    <tr>
									    <td>
										    <div style="height:10px"></div>
									    </td>
								    </tr>
								    <tr id="trMaTaiKhoan1" runat="server">
									    <td>
										    <asp:TextBox TabIndex="1" placeholder="Nhập tài khoản" ID="txtTaiKhoan" runat="server"></asp:TextBox>
									    </td>
								    </tr>
								    <tr id="trMaTaiKhoan2" runat="server">
									    <td>
										    <div style="height:1px"></div>
									    </td>
								    </tr>
								    <tr id="trMatKhau1" runat="server">
									    <td>
										    <asp:TextBox TabIndex="2" placeholder="Nhập mật khẩu" ID="txtMatKhau" TextMode="Password" runat="server"></asp:TextBox>
									    </td>
								    </tr>
								    <tr id="trMatKhau2" runat="server">
									    <td>
										    <div style="height:1px"></div>
									    </td>
								    </tr>
                                    <tr id="trMaXacThuc1" runat="server">
									    <td style="position:relative">
										    <asp:TextBox TabIndex="3" autocomplete="off" placeholder="Nhập mã xác thực" ID="txtMaXacThuc" runat="server"></asp:TextBox>
									        <img id="btnVideo" src="images/icon/video.png" />
                                        </td>
								    </tr>
								    <tr id="trMaXacThuc2" runat="server">
									    <td>
										    <div style="height:1px"></div>
									    </td>
								    </tr>
								    <tr id="trMaXacThuc3" runat="server">
									    <td>
										    <asp:Button TabIndex="4" ID="btnLogin" CssClass="fm-button ui-state-default ui-corner-all fm-button-icon-left ui-state-hover" runat="server" Text="Đăng nhập" OnClientClick="setTimeout(()=>{ this.disabled = true; },10);" OnClick="btnLogin_Click" />
									    </td>
								    </tr>
                                    <tr id="trMaXacThuc4" runat="server">
									    <td>
										    <asp:Button TabIndex="4" ID="btnVerify" CssClass="fm-button ui-state-default ui-corner-all fm-button-icon-left ui-state-hover" runat="server" Text="Xác nhận" OnClientClick="setTimeout(()=>{ this.disabled = true; },10);" OnClick="btnVerify_Click" />

                                            <span id="thoigianxacthuc"></span>
									    </td>
								    </tr>

								    <tr>
									    <td colspan="3">
										    <asp:Label ID="lblCaption" runat="server" Text=""></asp:Label>
									    </td>
								    </tr>
							    </table>
						    </form>
					    </div>
					    <div style="clear:both"> </div>
				    </div>
			    </div>
		    </div>
        </div>

         <script type="text/javascript">
            let time = new Date('<%=Session["time"]%>');
            let inter = setInterval(function () {
                let now = new Date();
                let total = Math.round(120 - ((now - time) / 1000));

                if (total <= 0) {
                    clearInterval(inter);
                    total = '';
                    alert('Login again, please');
                    window.location.href = '';
                }
                else {
                    total = total + ' giây';
                }

                $('#thoigianxacthuc').html(total);
            }, 1000);

            $('#btnVideo').click(function () {
                $('#qrcodeBG').show();

                var html5QrcodeScanner = new Html5QrcodeScanner("qr-reader", { fps: 10, qrbox: 250 });
                html5QrcodeScanner.render(onScanSuccess);
             });

             $('#btnThoatVid').click(function () {
                 let $btn = $('#html5-qrcode-button-camera-stop');
                 if ($btn.attr('id')) {
                     $btn.click();
                 }
                 $('#qrcodeBG').hide();
             });

             let lastResult, countResults = 0;
             function onScanSuccess(decodedText, decodedResult) {
                if (decodedText !== lastResult) {
                    ++countResults;
                    lastResult = decodedText;
                    if (decodedResult.decodedText) {
                        $('#txtMaXacThuc').val(decodedResult.decodedText);
                        $('#btnThoatVid').click();
                        $('#btnVerify').click();
                    }
                }
            }
        </script>
    </body>
</html>