<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Import Namespace="System.Data.Linq" %>
<%@ Import Namespace="DataAcess" %>

<% 
    var json = new ADmin_JSON();
    var ttc = json.ad_systemconfigJSON().FirstOrDefault();
    string url_server = Request.Url.Host;
    string urlBalse = Security.UrlBase();
    string logo = ttc == null ? urlBalse + " images/logo/imagenotfound.jpg" : urlBalse + ttc.logo + "?ver1";
%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="shortcut icon" href="images/logo/anco_logo.ico"/>
<title>eMan</title>
    <link href="css/layout-default.css" rel="stylesheet" type="text/css" />
	<link href="css/VNN_css/Content.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
	<link href="css/bootstrap-awesome.css" rel="stylesheet" type="text/css" />
    <link href="css/VNN_css/Login.css" rel="stylesheet" type="text/css" />
	<script src="js/Public_script/jquery-1.10.2.js" type="text/javascript"></script>
	<script src="js/VNN_script/GridFunction_Admin.js" type="text/javascript"></script>
</head>
    <body>
	    <div id="wapper-layout" class="ui-layout-center">
		    <div id="main0" class="ui-layout-north toolbar">
			    <div align="center" style="background: url('images/bg-logo.png') no-repeat center center; position: absolute; top: -8px; left: 10px; height: 105px; width: 200px;"> 
                        <img class="img_updatelinq" style="margin-top: 20px;" src="<%=logo %>"/> </div><span class="close"></span>
			    <table style="margin: 24px 0px 0px 200px">
				    <tr>
					    <td> </td>
					    <td> </td>
					    <td> </td>
					    <td> </td>
					    <td> </td>
				    </tr>
			    </table> <span style="position: absolute; top: 21px; right: 0px"> </span>
		    </div>
		    <div class="ui-layout-center" style="background: #efefef; width:100%; min-width:880px">
			    <div style="min-width:750px; background-color: #fff;">
				    <div id="main1" style="width: 880px;margin: 0px auto">
					    <div>
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
								    <tr>
									    <td>
										    <asp:TextBox TabIndex="1" placeholder="Nhập tài khoản" required="" ID="txtTaiKhoan" runat="server"></asp:TextBox>
									    </td>
								    </tr>
								    <tr>
									    <td>
										    <div style="height:1px"></div>
									    </td>
								    </tr>
								    <tr>
									    <td>
										    <asp:TextBox TabIndex="2" placeholder="Nhập mật khẩu" required="" ID="txtMatKhau" TextMode="Password" runat="server"></asp:TextBox>
									    </td>
								    </tr>
								    <tr>
									    <td>
										    <div style="height:1px"></div>
									    </td>
								    </tr>
								    <tr>
									    <td>
										    <asp:Button TabIndex="3" ID="btnLogin" CssClass="fm-button ui-state-default ui-corner-all fm-button-icon-left ui-state-hover" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
									    </td>
								    </tr>
								    <tr>
									    <td colspan="3">
										    <asp:Label ID="lblCaption" ForeColor="Red" runat="server" Text=""></asp:Label>
									    </td>
								    </tr>
								    <tr>
									    <td></td>
									    <td></td>
									    <td><span id="lblMessage" style="color:Red; font-size:11px"></span></td>
								    </tr>
							    </table>
						    </form>
					    </div>
					    <div style="clear:both"> </div>
				    </div>
				    <div id="footer" style="background-color:#003467; margin:0px auto"> <br />
					    <table id="tb_footer" style="width: 880px;margin: 0px auto">
						    <tr>
							    <td style=" padding: 5px 0px 0px 0px"><a style="color:White; font-size:13px;;"></a></td>
							    <td></td>
						    </tr>
						    <tr>
							    <td> <br /></td>
						    </tr>
						    <tr>
							    <td></td>
							    <td></td>
						    </tr>
						    <tr>
							    <td></td>
							    <td></td>
						    </tr>
						    <tr>
							    <td> <br /></td>
						    </tr>
						    <tr>
							    <td></td>
							    <td></td>
						    </tr>
						    <tr>
							    <td></td>
							    <td></td>
						    </tr>
					    </table>
				    </div>
			    </div>
		    </div>
    </body>
</html>