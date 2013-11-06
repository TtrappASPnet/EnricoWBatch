<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OvationTest.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <uc3:OvationRFPMetatags ID="OvationRFPMetatags1" runat="server" />
    <title>Ovation and Lawyers Travel - Login to your account</title>
    <uc4:OvationCommonCSSJscript ID="OvationCommonCSSJscript1"
        runat="server" />
</head>
<body id="ovationLoginPage">
    <form id="OvationLogin" runat="server">
    <uc5:ovationrfpglobalscrptmgr ID="OvationRFPGlobalScrptMgr1" runat="server" />
    <div id="container">
        <uc1:OvationRFPHeader ID="OvationRFPHeader1" runat="server" />
        <div id="middle">
            <div id="content" class="clearfix">
                <div id="login-photo">
                </div>
                <div id="right">
                 <asp:SiteMapPath ID="loginPath" CssClass="SiteMapLinks"  runat="server" />
                    <div class="ContainersFormTop">
                    </div>
                    <div class="ContainersFormContent">
                        <div class="ContainerContent">
                            <h1>
                                <img src="Images/hotel_login_logo.png" title="Hotel Login" alt="Hotel Login" /></h1>
                            <!-- START CONTENT CONTAINER -->
                            <asp:Panel ID="verifypnl" Visible="false" CssClass="errors" runat="server">
                            <p><asp:Literal ID="verifymsg" runat="server" /></p>
                            </asp:Panel>
                            <asp:Label ID="FailureText" ForeColor="Red" Visible="false" runat="server" />
                            <br />
                            <p class="login-act">
                                Don't have an account? Please <a href="register.aspx" class="register-link">register</a></p>
                            <br />
                            <!-- asp login -->
                            <asp:Login ID="HotelClientLogin" EnableViewState="true" runat="server" 
                                Width="857px" RememberMeSet="false"
                                FailureText="Your login failed please try again" 
                                DestinationPageUrl="~/Default.aspx" OnLoginError="HotelClientLogin_LoginError" 
                                onloggedin="HotelClientLogin_LoggedIn">
                                <LayoutTemplate>
                                    <fieldset>
                                        <div class="editor-field">
                                            <label>
                                                Business Email Address</label>
                                            <asp:TextBox ID="UserName" ToolTip="Please enter your business e-mail address" runat="server" /><asp:RequiredFieldValidator
                                                ID="UserNameval" runat="server" ErrorMessage="The Firm Email Address field is required."
                                                ControlToValidate="UserName" SetFocusOnError="True" />
                                        </div>
                                        <div class="editor-field">
                                            <label for="Password">
                                                Password</label>
                                            <asp:TextBox ID="Password" ToolTip="Please enter your password" runat="server" TextMode="Password" /><asp:RequiredFieldValidator
                                                ID="passwordVal" runat="server" ErrorMessage="The Password field is required."
                                                ControlToValidate="Password" SetFocusOnError="True" />
                                        </div>
                                        <div class="editor-checkbox">
                                            <label class="label_check">
                                                <asp:CheckBox ID="RememberMe" runat="server" />
                                                Remember Me?
                                            </label>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="button-wrapper">
                                            <asp:Button ID="OvationLoginBtn" runat="server" CommandName="Login" CssClass="submit-btn" CausesValidation="true"
                                                Text="Log In" />
                                        </div>
                                        <br />
                                        <div class="forgot-password-link">
                                            <a href="forgotpassword.aspx">Forgot Password?</a>
                                        </div>
                                    </fieldset>
                                </LayoutTemplate>
                            </asp:Login>
                            <!-- asp login ------------------------------------------------------------------------------>
                            <!-- END CONTENT CONTAINER -->
                        </div>
                    </div>
                    <div class="ContainersFormBottom">
                    </div>
                </div>
            </div>
        </div>
        <uc2:OvationRFPBottom ID="OvationRFPBottom1" runat="server" />
    </div>
    </form>
</body>
</html>
