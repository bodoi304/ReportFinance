<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ReportFinance.Login.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Easy Simple Login Form Flat Responsive Widget Template :: w3layouts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Easy Simple Login Form template Responsive, Login form web template,Flat Pricing tables,Flat Drop downs  Sign up Web Templates, Flat Web Templates, Login sign up Responsive web template, SmartPhone Compatible web template, free web designs for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- Custom Theme files -->
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!-- //Custom Theme files -->
    <!-- web font -->
    <link href='//fonts.googleapis.com/css?family=Dosis:400,300,200,500,600,700,800' rel='stylesheet' type='text/css'>
        <script src="/js/pnotify.js"></script>
    <link href="/css/pnotify.css" rel="stylesheet" />
    <!-- //web font -->
</head>
<body>
    <!-- main -->
    <div class="main">
        <div style="display: flex; align-items: center; justify-content: center; ">
           <%-- <div style="flex:100%;  height: 100px">--%>

                <img src="images/loginlogo.png"  />
           <%-- </div>--%>
        </div>
        <form id="form1" runat="server">
            <div class="main-row">
                <div class="agileits-top">

                    <input class="text" type="text" name="Tên Đăng Nhập" placeholder="Tên Đăng Nhập" required>
                    <input class="text" type="password" name="Mật Khẩu" placeholder="Mật Khẩu" required>
                    <input type="submit" value="Đăng nhập">
                    
               <p>   <asp:CheckBox ID="chkGiuDN" runat="server"   /><a style ="font-family: Arial, sans-serif;"> Giữ Đăng Nhập</a></p>
                </div>
            </div>
        </form>
        <!-- copyright -->
        <div class="copyright">
            <%--<p> © 2016 Easy Simple Login Form . All rights reserved | Design by <a href="http://w3layouts.com/" target="_blank">W3layouts</a></p>--%>
        </div>
        <!-- //copyright -->
    </div>
    <!-- //main -->
</body>
</html>
