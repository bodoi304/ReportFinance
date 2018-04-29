<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPhong.Master" AutoEventWireup="true" CodeBehind="ManageUsersMain.aspx.cs" Inherits="ReportFinance.ManageUsers.ManageUsers.ManageUsersMain" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="inline-form widget-shadow">
                <div class="form-title">

                    <h4>
                        <asp:Label ID="lblTitle" runat="server" Text="QUẢN LÝ NGƯỜI SỬ DỤNG"></asp:Label></h4>
                </div>
                <div class="form-body">
                    <div data-example-id="simple-form-inline">
                        <div class="form-inline">
                            <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 15px">
                                <dx:ASPxGridView ID="grd_DSUsers" ClientInstanceName="gridUser" runat="server" KeyFieldName="Id"
                                    Width="100%" AutoGenerateColumns="False" OnRowDeleting="grd_DSUsers_RowDeleting"
                                    OnRowUpdating="grd_DSUsers_RowUpdating" OnRowInserting="grd_DSUsers_RowInserting"
                                    OnPageIndexChanged="grd_DSUsers_PageIndexChanged"
                                    OnProcessColumnAutoFilter="grd_DSUsers_ProcessColumnAutoFilter"
                                    OnRowValidating="grd_DSUsers_RowValidating" OnBeforeColumnSortingGrouping="grd_DSUsers_BeforeColumnSortingGrouping" OnRowCommand="grd_DSUsers_RowCommand">
                                    <ClientSideEvents EndCallback="OnGridNotifyEndCallback" />
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0" ShowDeleteButton="true" Width="100" />

                                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Caption="ID"
                                            Width="35px">
                                            <Settings AllowAutoFilter="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Id_Login" VisibleIndex="1" Caption="Tên đăng nhập">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="1" Caption="Email">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PhoneNumber" VisibleIndex="1" Caption="Số điện thoại">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="UserName" VisibleIndex="1" Caption="Tên đầy đủ">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Department" VisibleIndex="1" Caption="Phòng ban">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Position" VisibleIndex="1" Caption="Chức vụ">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="LockoutEnabled" VisibleIndex="1" Caption="Trạng thái khóa"></dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn Caption="Khóa/Mở khóa" ReadOnly="True"
                                            VisibleIndex="1" Width="50">
                                            <DataItemTemplate>
                                                <asp:ImageButton ID="btnKhoaMoKhoa" runat="server" CommandArgument='' CommandName="cmdKhoa" ImageUrl="/images/icon/lock.png" />

                                            </DataItemTemplate>
                                            <CellStyle CssClass="GridItemCode" HorizontalAlign="Center"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Templates>

                                        <EditForm>
                                            <asp:Panel ID="pnLayData" runat="server">
                                                <table class="EditTable" style="width: 100%">
                                                    <tr>
                                                        <td class="LabelTable">Tên đăng nhập:<span style="color: red">*</span>
                                                        </td>
                                                        <td class="LabelContent">
                                                            <dx:ASPxTextBox runat="server" ID="Id_Login" Text='<%# Bind("Id_Login") %>' Width="100%" />
                                                        </td>
                                                        <td class="LabelTable">Email:
                                                        </td>
                                                        <td class="LabelContent">
                                                            <dx:ASPxTextBox runat="server" ID="Email" Text='<%# Bind("Email") %>' Width="100%" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="LabelTable">Số điện thoại:
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox runat="server" ID="PhoneNumber" Text='<%# Bind("PhoneNumber") %>' Width="100%" />
                                                        </td>
                                                        <td class="LabelTable">Tên đầy đủ:
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox runat="server" ID="UserName" Text='<%# Bind("UserName") %>' Width="100%" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="LabelTable">Phòng ban:
                                                        </td>
                                                        <td style="width: 50%">
                                                            <dx:ASPxTextBox runat="server" ID="Department" Text='<%# Bind("Department") %>' Width="100%" />
                                                        </td>
                                                        <td class="LabelTable">Chức vụ:
                                                        </td>
                                                        <td style="width: 50%">
                                                            <dx:ASPxTextBox runat="server" ID="Position" Text='<%# Bind("Position") %>' Width="100%" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="LabelTable">Mật khẩu:
                                                        </td>
                                                        <td style="width: 50%">
                                                            <dx:ASPxTextBox runat="server" ID="Password" Width="100%" Password="true" />
                                                        </td>
                                                        <td class="LabelTable">Xác nhận mật khẩu:
                                                        </td>
                                                        <td style="width: 50%">
                                                            <dx:ASPxTextBox runat="server" ID="PasswordConfirm" Width="100%" Password="true" />
                                                        </td>
                                                    </tr>



                                                </table>
                                            </asp:Panel>
                                            <div style="text-align: right; padding: 10px">
                                                <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server" />
                                                <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server" />
                                            </div>
                                        </EditForm>

                                    </Templates>
                                </dx:ASPxGridView>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
