
<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UTLAgent.Pages.Default" %>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>UTL | Login Page</title>
 <link href="~/assets/css/nunito.css" rel="stylesheet">
<style>
	body {
  font: 13px/20px "Lucida Grande", Tahoma, Verdana, sans-serif;
  color: #404040;
  background: #0ca3d2;
}

	.text-danger{
		color:#ff0000;
	}

	.error{
		font-size: 14px !important;
	}

.login {
  position: relative;
  margin-top:120px !important;
  margin: 30px auto;
  padding: 20px 20px 20px;
  width: 310px;
  background: white;
  border-radius: 3px;
  -webkit-box-shadow: 0 0 200px rgba(255, 255, 255, 0.5), 0 1px 2px rgba(0, 0, 0, 0.3);
  box-shadow: 0 0 200px rgba(255, 255, 255, 0.5), 0 1px 2px rgba(0, 0, 0, 0.3);
}

.login:before {
  content: '';
  position: absolute;
  top: -8px;
  right: -8px;
  bottom: -8px;
  left: -8px;
  z-index: -1;
  background: rgba(0, 0, 0, 0.08);
  border-radius: 4px;
}

.login h1 {
  margin: -20px -20px 21px;
  line-height: 40px;
  font-size: 15px;
  font-weight: bold;
  color: #555;
  text-align: center;
  text-shadow: 0 1px white;
  background: #f3f3f3;
  border-bottom: 1px solid #cfcfcf;
  border-radius: 3px 3px 0 0;
  background-image: -webkit-linear-gradient(top, whiteffd, #eef2f5);
  background-image: -moz-linear-gradient(top, whiteffd, #eef2f5);
  background-image: -o-linear-gradient(top, whiteffd, #eef2f5);
  background-image: linear-gradient(to bottom, whiteffd, #eef2f5);
  -webkit-box-shadow: 0 1px whitesmoke;
  box-shadow: 0 1px whitesmoke;
}
.nunito-font{
	font-family: "Nunito", sans-serif !important;
}

.login p {
  margin: 20px 0 0;
}

.login p:first-child {
  margin-top: 0;
}

.login input[type=text], .login input[type=password] {
  width: 278px;
}
.login-error{
	
	padding: 10px;
	text-align: left;
	color: #A94442;
	width:auto !important;
	background-color: #F2DEDE;
	border-radius: 3px;

}
.login-div
{
  margin-top: 15px !important;
  width:auto !important;
}

.login p.remember_me {
  float: left;
  line-height: 31px;
}

.login p.remember_me label {
  font-size: 12px;
  color: #777;
  cursor: pointer;
}

.login p.remember_me input {
  position: relative;
  bottom: 1px;
  margin-right: 4px;
  vertical-align: middle;
}

.login p.submit {
  text-align: right;
}

.login-help {
  margin: 20px 0;
  font-size: 11px;
  color: white;
  text-align: center;
  text-shadow: 0 1px #2a85a1;
}

.login-help a {
  color: #cce7fa;
  text-decoration: none;
}

.login-help a:hover {
  text-decoration: underline;
}

:-moz-placeholder {
  color: #c9c9c9 !important;
  font-size: 13px;
}

::-webkit-input-placeholder {
  color: #ccc;
  font-size: 13px;
}

input {
  font-family: 'Lucida Grande', Tahoma, Verdana, sans-serif;
  font-size: 14px;
}

input[type=text], .password {
  margin: 5px;
  padding: 0 10px;
  width: 200px;
  height: 34px;
  color: #404040;
  background: white;
  border: 1px solid;
  border-color: #c4c4c4 #d1d1d1 #d4d4d4;
  border-radius: 2px;
  outline: 5px solid #eff4f7;
  -moz-outline-radius: 3px;
  -webkit-box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.12);
  box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.12);
}

input[type=text]:focus, input[type=password]:focus {
  border-color: #7dc9e2;
  outline-color: #dceefc;
  outline-offset: 0;
}

.submit {
  padding: 0 18px;
  height: 29px;
  margin-left:40px !important;
  font-size: 12px;
  font-weight: bold;
  color: #527881;
  text-shadow: 0 1px #e3f1f1;
  background: #cde5ef;
  border: 1px solid;
  border-color: #b4ccce #b3c0c8 #9eb9c2;
  border-radius: 16px;
  outline: 0;
  -webkit-box-sizing: content-box;
  -moz-box-sizing: content-box;
  box-sizing: content-box;
  background-image: -webkit-linear-gradient(top, #edf5f8, #cde5ef);
  background-image: -moz-linear-gradient(top, #edf5f8, #cde5ef);
  background-image: -o-linear-gradient(top, #edf5f8, #cde5ef);
  background-image: linear-gradient(to bottom, #edf5f8, #cde5ef);
  -webkit-box-shadow: inset 0 1px white, 0 1px 2px rgba(0, 0, 0, 0.15);
  box-shadow: inset 0 1px white, 0 1px 2px rgba(0, 0, 0, 0.15);
}

.submit:active {
  background: #cde5ef;
  border-color: #9eb9c2 #b3c0c8 #b4ccce;
  -webkit-box-shadow: inset 0 0 3px rgba(0, 0, 0, 0.2);
  box-shadow: inset 0 0 3px rgba(0, 0, 0, 0.2);
}

.password {
  line-height: 34px;
}
</style>

</head> 
<body>
<div class="login">
  <h1>UTL AGENT APP</h1>
  <form runat="server">
	 
	<asp:TextBox ID="UsernameTxt" runat="server" placeholder="Username or email" CssClass="nunito-font"></asp:TextBox>
	  <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password" placeholder="Password" CssClass="password nunito-font"></asp:TextBox>

	<p class="remember_me">
	  <label>
		  <asp:CheckBox runat="server" Text="Remember me on this computer" CssClass="remember_me"/>
	  </label>
	</p>
	 
	  <p>
		  <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Clicked"  CssClass="submit ml-4"/>
	  </p>
	   
	  <div class="mt-5 login-div nunito-font">
			<asp:Label ID="ErrorTxt" runat="server" Text="" CssClass="error"></asp:Label>
				</div>
		   
	  
   
  </form>
</div>

<div class="login-help">
  <p>Forgot your password? <a href="#">Click here to reset it</a>.</p>
</div>
	 <script src="<%= ResolveUrl("~/assets/js/jquery-3.3.1.js")%>")%>"></script>
	<script type="text/javascript">
		$(document).ready(function () {
			var errorTxt = $(".error").html();
			if (errorTxt.length > 0) {
				$('.login-div').addClass('login-error');
				$('.error').addClass('nunito-font');
			}
		});
	</script>
</body>
</html>