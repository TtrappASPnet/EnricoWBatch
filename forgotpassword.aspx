<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="OvationTest.forgotpassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="HotelFgotPW" runat="server">
<uc3:OvationRFPMetatags ID="OvationRFPMetatags1" ViewStateMode="Disabled" runat="server" />
    <title></title>
        <uc4:OvationCommonCSSJscript ID="OvationCommonCSSJscript1" ViewStateMode="Disabled"
        runat="server" />
</head>
<body>
    <form id="forgotPWFM" runat="server">
    <uc5:ovationrfpglobalscrptmgr ID="OvationRFPGlobalScrptMgr1" runat="server" />
     <div id="container">
        <uc1:OvationRFPHeader ID="OvationRFPHeader1" runat="server" />
        <div id="middle">
            <div id="content" class="clearfix">
                <div id="chooseOption-photo">
                </div>
                <div id="right">
                <asp:SiteMapPath ID="loginPath" CssClass="SiteMapLinks"  runat="server" />
                    <div class="ContainersFormTop">
                    </div>
                    <div class="ContainersFormContent">
                        <div class="ContainerContent">
                        <!-- begin content -->
                            <h2>
                                <img src="Images/forgotLoginTitle.png" title="Did you forget your login information?" /></h2>
                            <!-- START CONTENT CONTAINER -->
                            <asp:PasswordRecovery ID="OvationForGotPassword"  runat="server" 
                                onverifyinguser="OvationForGotPassword_VerifyingUser" 
                                onsendingmail="OvationForGotPassword_SendingMail">
                                <UserNameTemplate>
                                    <asp:Label ID="FailureText" ForeColor="Red" runat="server" />
                                    <asp:Label ID="UserNameInstructionText" ForeColor="Red" runat="server" />
                                    <br />
                                    <p>Enter your email address to receive by email your username and password.</p>
                                    <fieldset>
                                    <br />
                                        <div class="editor-field">
                                            <label>
                                                Business Email Address</label>
                                            <asp:TextBox ID="UserName" ToolTip="Please enter your business e-mail address" runat="server" /><asp:RequiredFieldValidator
                                                ID="UserNameval" runat="server" ErrorMessage="The Firm Email Address field is required."
                                                ControlToValidate="UserName" SetFocusOnError="True" />
                                        </div>
                                        <div class="button-wrapper">
                                            <asp:Button ID="OvationLoginBtn" runat="server" Width="250" CommandName="Submit" CssClass="submit-btn"
                                                CausesValidation="true" Text="Send my information" />
                                        </div>
                                    </fieldset>
                                </UserNameTemplate>
                            </asp:PasswordRecovery>
                            <br />
                            <br />
                            <br />
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
