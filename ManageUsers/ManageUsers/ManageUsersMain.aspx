<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPhong.Master" AutoEventWireup="true" CodeBehind="ManageUsersMain.aspx.cs" Inherits="ReportFinance.ManageUsers.ManageUsers.ManageUsersMain" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function MasterGrid_DetailRowCollapsing(s, e) {
            var key = gridUser.GetRowKey(e.visibleIndex);
            hf.Set('collapsedRowKey', key);
        }
        function MasterGrid_EndCallback(s, e) {
            if (hf.Contains('collapsedRowKey'))
                hf.Remove('collapsedRowKey');
        }
    </script>
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
                                <dx:ASPxHiddenField ID="HF" runat="server" ClientInstanceName="hf"></dx:ASPxHiddenField>
                                <dx:ASPxGridView ID="grd_DSUsers" ClientInstanceName="gridUser" runat="server" KeyFieldName="Id"
                                    Width="100%" AutoGenerateColumns="False" OnRowDeleting="grd_DSUsers_RowDeleting"
                                    OnRowUpdating="grd_DSUsers_RowUpdating" OnRowInserting="grd_DSUsers_RowInserting"
                                    OnPageIndexChanged="grd_DSUsers_PageIndexChanged"
                                    OnProcessColumnAutoFilter="grd_DSUsers_ProcessColumnAutoFilter"
                                    OnRowValidating="grd_DSUsers_RowValidating" OnBeforeColumnSortingGrouping="grd_DSUsers_BeforeColumnSortingGrouping" OnRowCommand="grd_DSUsers_RowCommand">
                                    <ClientSideEvents DetailRowCollapsing="MasterGrid_DetailRowCollapsing" EndCallback="function(s, e) {
OnGridNotifyEndCallback(s, e);
	MasterGrid_EndCallback(s, e);
}" />
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
                                        <DetailRow>
                                            <dx:ASPxGridView ID="grd_DSRoleOfUser" ClientInstanceName="grd_DSRoleOfUser" runat="server" KeyFieldName="Id"
                                                Width="100%" AutoGenerateColumns="False" OnBeforePerformDataSelect="grd_DSRoleOfUser_BeforePerformDataSelect">

                                                <Columns>

                                                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1" Caption="Tên Role" Width="30%">
                                                        <Settings AllowAutoFilter="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="1" Caption="Mô tả"
                                                        Width="70%">
                                                    </dx:GridViewDataTextColumn>

                                                </Columns>
                                                <Styles>
                                                    <Header CssClass="HeaderGrid"></Header>
                                                </Styles>
                                            </dx:ASPxGridView>

                                        </DetailRow>
                                        <EditForm>
                                                <dx:ASPxFormLayout runat="server" ID="LayOutThemSua">
                                                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="576" />
                                                    <Items>
                                                        <dx:LayoutGroup Caption="TÀI KHOẢN" ColCount="2" GroupBoxDecoration="HeadingLine" Paddings-Padding="0" Paddings-PaddingTop="10">
                                                            <GroupBoxStyle>
                                                                <Caption Font-Bold="true" Font-Size="16" CssClass="groupCaption" />
                                                            </GroupBoxStyle>
                                                            <Items>
                                                                <dx:LayoutItem Caption="Tên đăng nhập *:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="Id_Login" Text='<%# Bind("Id_Login") %>' />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Số điện thoại:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="PhoneNumber" Text='<%# Bind("PhoneNumber") %>' />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Email:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="Email" Text='<%# Bind("Email") %>' Width="100%" />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Phòng ban:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="Department" Text='<%# Bind("Department") %>' Width="100%" />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Tên đầy đủ:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="UserName" Text='<%# Bind("UserName") %>' Width="100%" />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Chức vụ:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="Position" Text='<%# Bind("Position") %>' Width="100%" />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Mật khẩu:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="Password" Width="100%" Password="true" />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Xác nhận mật khẩu:">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox runat="server" ID="PasswordConfirm" Width="100%" Password="true" />
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                            </Items>
                                                        </dx:LayoutGroup>
                                                    </Items>
                                                </dx:ASPxFormLayout>
                              
                                            <div style="text-align: right; padding: 10px;padding-right :50px">
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
