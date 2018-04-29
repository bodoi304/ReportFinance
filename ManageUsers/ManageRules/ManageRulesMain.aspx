<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPhong.Master" AutoEventWireup="true" CodeBehind="ManageRulesMain.aspx.cs" Inherits="ReportFinance.ManageUsers.ManageRules.ManageRulesMain" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .Rule1Class {
        }

            .Rule1Class td {
                padding-bottom: 10px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="inline-form widget-shadow">
                <div class="form-title">

                    <h4>
                        <asp:Label ID="lblTitle" runat="server" Text="QUẢN LÝ PHÂN QUYỀN NGƯỜI SỬ DỤNG THEO ROLES"></asp:Label></h4>
                </div>
                <div class="form-body">
                    <div data-example-id="simple-form-inline">
                        <div class="form-inline">
                            <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 15px">
                                <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="upUserRoleRule">
                                    <ProgressTemplate>
                                        <div class="center-screen">
                                            <img src="/images/icon/loading.gif" width="150" /></div>

                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel ID="upUserRoleRule" runat="server">
                                    <ContentTemplate>

                                        <table width="100%" class="Rule1Class">
                                            <tr valign="top">
                                                <td colspan="3">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 25%">Chọn Role để thêm người sử dụng: 
                                                            </td>
                                                            <td>
                                                                <dx:ASPxComboBox ID="cbRoles" runat="server" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cbRoles_SelectedIndexChanged">
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                        </tr>
                                                    </table>


                                                </td>

                                            </tr>
                                            <tr valign="top">
                                                <td class="LabelBold" width="48%">Danh sách người sử dụng của hệ thống
            <asp:Label ID="lblCustoms" runat="server" Text="" CssClass="LabelBold"></asp:Label></td>
                                                <td width="80">&nbsp;
                                                </td>
                                                <td class="LabelBold" width="48%">Danh sách người sử dụng của Role
            <asp:Label ID="lblUser" runat="server" Text="" CssClass="LabelBold"></asp:Label>
                                                </td>

                                            </tr>

                                            <tr valign="top">
                                                <td>
                                                    <table cellpadding="2" cellspacing="0" width="100%">
                                                         <tr>
                                                    <td>
                                                        <dx:ASPxTextBox ID="txtUser" runat="server" Width="100%" placeholder="Tìm kiếm theo tài khoản đăng nhập" OnTextChanged="txtUser_TextChanged" AutoPostBack="True"></dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                        <tr>
                                                            <td>
                                                                <dx:ASPxListBox ID="lbUser" runat="server" ValueType="System.String" Height="350px" Width="100%" SelectionMode="CheckColumn">
                                                                </dx:ASPxListBox>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="80" valign="middle">
                                                    <table cellpadding="5" cellspacing="5" width="100%" border="0">
                                                        <tr>

                                                            <td align="center">
                                                                <dx:ASPxButton ID="btnAddAll" runat="server" Text="&gt;&gt;" Font-Bold="true" Width="40" ToolTip="Thêm tất cả người sử dụng vào Role" OnClick="btnAddAll_Click">
                                                                </dx:ASPxButton>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <dx:ASPxButton ID="btnAddOne" runat="server" Text="&gt;" Font-Bold="true" Width="40" ToolTip="Thêm người sử dụng vào Role" OnClick="btnAddOne_Click">
                                                                </dx:ASPxButton>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <dx:ASPxButton ID="btnRevOne" runat="server" Text="&lt;" Font-Bold="true" Width="40" ToolTip="Bỏ người sử dụng khỏi Role" OnClick="btnRevOne_Click">
                                                                </dx:ASPxButton>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <dx:ASPxButton ID="btnRevAll" runat="server" Text="&lt;&lt;" Font-Bold="true" Width="40" ToolTip="Bỏ tất cả người sử dụng khỏi Role" OnClick="btnRevAll_Click">
                                                                </dx:ASPxButton>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table cellpadding="2" cellspacing="0" width="100%">
                                                                           <tr>
                                                    <td>
                                                        <dx:ASPxTextBox ID="txtUserOfRole" runat="server" Width="100%" placeholder="Tìm kiếm theo tài khoản đăng nhập" AutoPostBack="True" OnTextChanged="txtUserOfRole_TextChanged" ></dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                        <tr>
                                                            <td>
                                                                <dx:ASPxListBox ID="lbUserOfRole" runat="server" ValueType="System.String" Height="350px" Width="100%" SelectionMode="CheckColumn">
                                                                </dx:ASPxListBox>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>
                                </asp:UpdatePanel>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
