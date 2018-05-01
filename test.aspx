<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="ReportFinance.test" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


  <dx:ASPxPopupControl ID="PopupControl" runat="server" ShowOnPageLoad="true" ClientInstanceName="modal" HeaderText="Edit Employee" CloseOnEscape="false" CloseAction="None" ShowFooter="true">
            <ContentStyle Paddings-Padding="0" Paddings-PaddingTop="12" />
            <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" MaxWidth="700px" />
            <ContentCollection>
                
                <dx:PopupControlContentControl>
                    <dx:ASPxFormLayout runat="server" ID="formLayout">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="576" />
                        <Items>
                            <dx:LayoutGroup Caption="Employee Details" ColCount="2" GroupBoxDecoration="HeadingLine" Paddings-Padding="0" Paddings-PaddingTop="10">
                                <GroupBoxStyle>
                                    <Caption Font-Bold="true" Font-Size="16" CssClass="groupCaption" />
                                </GroupBoxStyle>
                                <Items>
                                    <dx:LayoutItem Caption="First Name">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox runat="server" ID="tbFirstName" Text="Nancy">
                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Last Name">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox runat="server" ID="tbLastName" Text="Davolio">
                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Birth Date">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxDateEdit runat="server" ID="deBirthDate" Date="1948-12-8">
                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Country">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox runat="server" ID="tbCountry" Text="Austria">
                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="City">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox runat="server" ID="tbCity" Text="Graz">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Address">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox runat="server" ID="tbAddress" Text="Kirchgasse 6">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Notes" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxMemo runat="server" ID="mNotes" Rows="6"
                                                    Text="Nancy received a BA degree in psychology from Colorado State University in 2000. She also completed 'The Art of the Cold Call' course. She is a member of Toastmasters International.">
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <dx:ASPxFormLayout runat="server" ID="footerFormLayout" Width="100%" CssClass="clearPaddings">
                    <Styles LayoutItem-CssClass="clearPaddings" LayoutGroup-CssClass="clearPaddings" />
                    <Items>
                        <dx:LayoutGroup GroupBoxDecoration="None">
                            <Paddings Padding="0" />
                            <Items>
                                <dx:LayoutItem ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <div class="buttonsContainer">
                                                <dx:ASPxButton ID="btnSubmit" runat="server" CssClass="submitButton" Text="Submit" Width="100">
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btnCancel" runat="server" CssClass="cancelButton" Text="Cancel" AutoPostBack="false" Width="100">
                                                    <ClientSideEvents Click="onBtnCancelClick" />
                                                </dx:ASPxButton>
                                            </div>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
            </FooterTemplate>
        </dx:ASPxPopupControl>