<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OvationTest.register" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <uc3:OvationRFPMetatags ID="OvationRFPMetatags1" ViewStateMode="Disabled" runat="server" />
    <title></title>
    <uc4:OvationCommonCSSJscript ID="OvationCommonCSSJscript1" ViewStateMode="Disabled"
        runat="server" />
</head>
<body id="OvationHotelReg">
    <form id="HotelRegistration" runat="server">
    <uc5:ovationrfpglobalscrptmgr ID="OvationRFPGlobalScrptMgr1" runat="server" />
    <div id="container">
        <uc1:OvationRFPHeader ID="OvationRFPHeader1" runat="server" />
        <div id="middle">
            <div id="content" class="clearfix">
                <div id="register-photo">
                </div>
                <div id="right">
                <asp:SiteMapPath ID="loginPath" CssClass="SiteMapLinks"  runat="server" />
                    <div class="ContainersFormTop">
                    </div>
                    <div class="ContainersFormContent">
                        <div class="ContainerContent">
                            <h1>
                                <img src="Images/nhr.png" title="Hotel Registration" alt="Hotel Registration" /></h1>
                            <!-- START CONTENT CONTAINER -->
                            <fieldset>
                            <asp:Panel ID="regerror" class="editor-field" Visible="false" runat="server">
                                <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red" />
                            </asp:Panel>
                           <asp:Panel ID="Regform" runat="server" Visible="true">
                                <div class="editor-field">
                                    <label>
                                        Name</label>
                                    <asp:TextBox ID="NewHotlelRegName" ToolTip="Please enter your name" runat="server" /><asp:RequiredFieldValidator
                                        ID="HnameVal" runat="server" ErrorMessage="Your name cannot be blank" ControlToValidate="NewHotlelRegName"
                                        SetFocusOnError="true" />
                                </div>
                                <div class="editor-field">
                                    <label>
                                        Email</label>
                                    <asp:TextBox ID="NewHotlelRegEmail" ToolTip="Please enter a valid e-mail address"
                                        runat="server" /><asp:RequiredFieldValidator ID="HemailBlankval" runat="server" ErrorMessage="E-mail cannot be blank"
                                            Display="Dynamic" ControlToValidate="NewHotlelRegEmail" SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator ID="HemailRegexVal" runat="server" Display="Dynamic"
                                        ErrorMessage="You must supply a valid e-mail address" ControlToValidate="NewHotlelRegEmail"
                                        SetFocusOnError="true" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z{2-4}|[0-9]{1,3})(\]?)$" />
                                </div>
<%--                                <div class="editor-field">
                                    <label>
                                        Hotel Name</label>
                                    <asp:TextBox ID="NewHotlelRegHN" ToolTip="Please enter hotel name" runat="server" /><asp:RequiredFieldValidator
                                        ID="HotelNameVal" runat="server" ErrorMessage="Hotel name cannot be blank" ControlToValidate="NewHotlelRegHN"
                                        SetFocusOnError="true" />
                                </div>--%>
<%--                                <div class="editor-field">
                                    <label>
                                        Confirm Password</label>
                                    <asp:TextBox ID="NewHotlelRegPW_Confirm" ToolTip="Please confirm password" runat="server" /><asp:RequiredFieldValidator
                                        ID="HusernameVal" runat="server" ErrorMessage="User name cannot be blank" ControlToValidate="NewHotlelRegUN"
                                        SetFocusOnError="true" />
                                </div>--%>
                                <div class="editor-field">
                                    <label>
                                        Create Password</label>
                                    <asp:TextBox ID="NewHotlelRegPW" ToolTip="Please enter a password" TextMode="Password" runat="server" /><asp:RequiredFieldValidator
                                        ID="HpasswordVal" runat="server" Display="Dynamic" ErrorMessage="Password cannot be blank" ControlToValidate="NewHotlelRegPW"
                                        SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator ID="HpasswordVal_Length" ControlToValidate="NewHotlelRegPW" Display="Dynamic"
                                        ValidationExpression="[^ \t\n\r]{6,10}" ErrorMessage="Passwords must be between 6 and 10 characters long"
                                        runat="server" SetFocusOnError="true" />
                                </div>
                               <div class="editor-field">
                                   <label>
                                       Confirm Password</label>
                                   <asp:TextBox ID="NewHotlelRegPW_Confirm" TextMode="Password" ToolTip="Please confirm password" runat="server" /><asp:RequiredFieldValidator
                                       ID="NewHotlelRegPW_Confirm_Val" runat="server" ErrorMessage="confirm password cannot be blank" ControlToValidate="NewHotlelRegPW_Confirm"
                                       SetFocusOnError="true" Display="Dynamic" />
                                   <asp:CompareValidator ID="NewHotlelRegPW_Confirm_Val_compare" runat="server" ControlToCompare="NewHotlelRegPW"
                                       ControlToValidate="NewHotlelRegPW_Confirm" ErrorMessage="Your passwords do not match up"
                                       Display="Dynamic" />
                               </div>
                                <div class="button-wrapper">
                                    <asp:Button ID="OvationRegister" runat="server" CssClass="submit-btn" CausesValidation="true"
                                        Text="Register" ToolTip="Register" OnClick="OvationRegister_Click" />
                                </div>
                                <br />
                                </asp:Panel>
                            </fieldset>
                            <asp:Panel ID="thnkyouMsg" CssClass="errors" Visible="false" runat="server">
                             <asp:Literal ID="Msg" runat="server" />
                            </asp:Panel>
                            <asp:Literal ID="thnyouBR" runat="server" Visible="false" />
                            <!-- END CONTENT CONTAINER -->
                        </div>
                    </div>
                    <div class="ContainersFormBottom">
                    </div>
                </div>
            </div>
        </div>
        <uc2:OvationRFPBottom ID="OvationRFPBottom1" ViewStateMode="Disabled" runat="server" />
    </div>
    </form>
</body>
</html>
