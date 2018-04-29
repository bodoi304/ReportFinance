<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPhong.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="ReportFinance.Login.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bg {
            /* The image used */
            /* Full height */
           
            width: 100%;
            /* Center and scale the image nicely */
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 100%;">

        <div class="bg">
            <img src="images/backgroundDashboard.jpg"   width="100%"  height="100%" /></div>
    </div>
</asp:Content>
