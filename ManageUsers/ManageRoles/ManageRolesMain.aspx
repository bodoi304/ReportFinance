<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPhong.Master" AutoEventWireup="true" CodeBehind="ManageRolesMain.aspx.cs" Inherits="ReportFinance.ManageUsers.ManageRoles.ManageRolesMain" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Src="../Common/TreeListFunction.ascx" TagName="TreeListFunction" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="inline-form widget-shadow">
                <div class="form-title">

                    <h4>
                        <asp:Label ID="lblTitle" runat="server" Text="QUẢN LÝ ROLES"></asp:Label></h4>
                </div>
                <div class="form-body">
                    <div data-example-id="simple-form-inline">
                        <div class="form-inline">
                            <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 15px">
                                <asp:MultiView ID="mtView" runat="server">
                                    <asp:View ID="vwRole" runat="server">
                                        <dx:ASPxGridView ID="grd_DSRole" ClientInstanceName="gridRole" runat="server" KeyFieldName="Id"
                                            Width="100%" AutoGenerateColumns="False" OnRowDeleting="grd_DSRole_RowDeleting"
                                            OnRowUpdating="grd_DSRole_RowUpdating" OnRowInserting="grd_DSRole_RowInserting"
                                            OnRowCommand="grd_DSRole_RowCommand" OnPageIndexChanged="grd_DSRole_PageIndexChanged"
                                            OnProcessColumnAutoFilter="grd_DSRole_ProcessColumnAutoFilter"
                                            OnRowValidating="grd_DSRole_RowValidating" OnBeforeColumnSortingGrouping="grd_DSRole_BeforeColumnSortingGrouping">
                                            <ClientSideEvents EndCallback="OnGridNotifyEndCallback" />                                    
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0" ShowDeleteButton="true" Width="100" />

                                                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Caption="ID"
                                                    Width="35px">
                                                    <Settings AllowAutoFilter="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1" Caption="Tên Role"
                                                    Width="30%">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="1" Caption="Mô tả">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Roles" ReadOnly="True"
                                                    VisibleIndex="1" Width="50" >
                                                    <DataItemTemplate>
                                                        <asp:LinkButton ID="btnRole" runat="server"
                                                            CommandArgument='' CommandName="cmdRole"
                                                            Text='Role'></asp:LinkButton>
                                                    </DataItemTemplate>
                                                    <CellStyle CssClass="GridItemCode" HorizontalAlign="Center"></CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Templates>
                                                <EditForm>
                                                    <table class="EditTable" style="width: 100%">
                                                        <tr>
                                                            <td class="LabelTable">Tên Role<span style="color:red">*</span>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <dx:ASPxTextBox runat="server" ID="txtName" Text='<%# Bind("Name") %>' Width="100%" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="LabelTable">Mô tả
                                                            </td>
                                                            <td>
                                                                <dx:ASPxMemo runat="server" ID="txtNote" Text='<%# Bind("Description")%>' Width="100%" Height="100px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div style="text-align: right; padding: 10px">
                                                        <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server" />
                                                        <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server" />
                                                    </div>
                                                </EditForm>
                                            </Templates>
                                        </dx:ASPxGridView>
                                    </asp:View>
                                    <asp:View ID="vwQuyen" runat="server">

                                        <uc1:TreeListFunction ID="TreeListFunction1" runat="server" />


                                    </asp:View>
                                </asp:MultiView>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
