<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="OvationTest.logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<uc3:OvationRFPMetatags ID="OvationRFPMetatags1" ViewStateMode="Disabled" runat="server" />
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Expires" content="-1" />
    <title>Ovation and Lawyers Travel - Login to your account</title>
        <uc4:OvationCommonCSSJscript ID="OvationCommonCSSJscript1" ViewStateMode="Disabled"
        runat="server" />
        <script type="text/javascript" language="javascript">
            window.history.forward(1);
            document.attachEvent("onkeydown", my_onkeydown_handler);
            function my_onkeydown_handler() {
                switch (event.keyCode) {
                    case 116: // F5; event.returnValue = false;
                        event.keyCode = 0;
                        window.status = "We have disabled F5";
                        break;
                }
            }
</script>
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
                           <%-- <asp:Panel ID="congratsMsg" CssClass="errors" Visible="false" runat="server">--%>
                            <p style="padding-left:20px;padding-bottom:30px;">
                            <%--<asp:literal ID="memnameCompleted" runat="server" />--%>
                             Thank you, your 2014 RFP has been completed and submitted.
                            </p>
                            <%--</asp:Panel>--%>
  <%--                          <asp:Label ID="FailureText" ForeColor="Red" Visible="false" runat="server" />
                            <br />
                            <p class="login-act">
                                Don't have an account? Please <a href="register.aspx" class="register-link">register</a></p>--%>
                            <br />
                            <!-- asp login -->
                  <%--          <asp:Login ID="HotelClientLogin" OnLoggedIn="HotelClientLogin_LoggedIn" EnableViewState="true" runat="server" Width="857px" RememberMeSet="false"
                                FailureText="Your login failed please try again" DestinationPageUrl="~/Default.aspx" OnLoginError="HotelClientLogin_LoginError">
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
                            </asp:Login>--%>
                            <!-- asp login ------------------------------------------------------------------------------>
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
