<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="splash.aspx.cs" Inherits="OvationTest.splash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<uc3:OvationRFPMetatags ID="OvationRFPMetatags1" runat="server" />
        <title>Welcome to Ovation and Lawyers Travel</title>
                <uc4:OvationCommonCSSJscript ID="OvationCommonCSSJscript1" runat="server" />
    <script type="text/javascript">
        function open_win() {
            window.open("http://dev.ovationtravel.com/ovationrfp/info.aspx", "_blank", "toolbar=yes, location=yes, directories=no, status=no, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=yes, width=1050, height=600");
        }                      
    </script>
</head>
<body>
    <form id="form1" runat="server">
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
                            <p style="font-size:28px;font-weight:bold;text-align:center;font-family:LTC_twentienth_Century_MD; height:50px;">
                            Welcome to the 2014 Preferred Hotel Partners Program
                                </p>
                            <div class="MoreInfoBTN" style="margin-right: 35px;">
                                <asp:HyperLink ID="LinktoHelpOne" Style="padding-top: 5px; padding-bottom: 5px;"
                                    Text="Information You <br>Need to Know" ToolTip="For informatiopn you need to know about our program click here"
                                    runat="server" />
                            </div>
                        </div>
                            <br />
                            <br />
                            <p style="font-size:14px;font-weight:bold;margin-left: 60px;">To complete your 2014 RFP response:</p>
                            <br />
                            <ul style="list-style:disc;line-height:26px;margin-left:85px;">
                            <li style="font-size:14px;">Provide your <strong>Hotel Information</strong></li>
                            <li style="font-size:14px;">Define your <strong>Rates and Amenities</strong></li>
                            <li style="font-size:14px;">Choose your <strong>Marketing Package</strong></li>
                            <li style="font-size:14px;">Then <strong>Sign and Submit </strong>your RFP response.</li>
                            </ul>
                            <br />
                            <p style="font-size:12px;margin-left: 60px;">
                                Please be sure to complete all required fields. (* indicates a required field),
                                then digitally sign and submit your RFP response.
                                <br />
                                <br />
                                At any time you can click the "
                                Information You Need to Know” button for additional help and information.</p>
                                <asp:HiddenField ID="TheRFPID" runat="server" />
                                    <div id="HotelInfowrapper" style="margin-left: 40px;" class="spalshBtn">
                                    <asp:Button ID="HotelInfoNextBtn" runat="server" CssClass="formsections-btn"
                                        Text="Click here to Begin" CausesValidation="false" TabIndex="28" onclick="HotelInfoNextBtn_Click"
                                         />
                         </div>
                    </div>
                    <div class="ContainersFormBottom">
                    </div>
                </div>
            </div>
        </div>
        <uc2:OvationRFPBottom ID="OvationRFPBottom1" ViewStateMode="Disabled" runat="server" />
    </div>
  </div>
    </form>
</body>
</html>
