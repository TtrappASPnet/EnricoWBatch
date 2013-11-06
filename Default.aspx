<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Default.aspx.cs" Inherits="OvationTest._Default"
    Debug="false" Trace="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <meta name="apple-touch-fullscreen" content="yes" />
  <meta name="viewport" content="width=device-width" />
  <meta name="ROBOTS" content="NONE" />
  <meta name="GOOGLEBOT" content="NOARCHIVE" />	
  <meta name="title" content="" />
  <meta name="description" content="Join one of the world's fastest-growing, premier travel management companies." />
  <meta name="keywords" content="" />
  <%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />--%>
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Welcome to Ovation and Lawyers Travel Peferfed Hotels Program</title>
    <link type="text/css" rel="stylesheet" href="css/OvationRFP.css" />
    <script type="text/javascript" src="Scripts/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="Scripts/jquery.textchange.min.js"></script>
		<script type="text/javascript">

		    //		    var _gaq = _gaq || [];
		    //		    _gaq.push(['_setAccount', 'UA-22843078-1']);
		    //		    _gaq.push(['_trackPageview']);

		    //		    (function () {
		    //		        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
		    //		        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
		    //		        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
		    //		    })();

		    function OpenWindow(url, name) {
		        var wnd = window.radopen(url, name);
		        wnd.set_iconUrl("images/radlaerticon.jpg");
		        wnd._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
		        wnd.center();
		    }

		    function open_win() {
		        window.open("http://dev.ovationtravel.com/ovationrfp/info.aspx", "_blank", "toolbar=yes, location=yes, directories=no, status=no, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=yes, width=1050, height=600");
		    }
        </script>
      <telerik:RadCodeBlock ID="WincloseCodeBlock" Visible="true" runat="server">
      <script type="text/javascript">
          ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

          var validNavigation = false;

          function wireUpEvents() {
              /**
              * For a list of events that triggers onbeforeunload on IE
              * check http://msdn.microsoft.com/en-us/library/ms536907(VS.85).aspx
              *
              * onbeforeunload for IE and chrome
              * check http://stackoverflow.com/questions/1802930/setting-onbeforeunload-on-body-element-in-chrome-and-ie-using-jquery
              */
              var dont_confirm_leave = 0; //set dont_confirm_leave to 1 when you want the user to be able to leave withou confirmation
              var leave_message = 'Your 2014 RFP has not been saved yet, are you sure you want to close this window?'
              function goodbye(e) {
                  if (!validNavigation) {
                      if (dont_confirm_leave !== 1) {
                          if (!e) e = window.event;
                          //e.cancelBubble is supported by IE - this will kill the bubbling process.
                          e.cancelBubble = true;
                          e.returnValue = leave_message;
                          //e.stopPropagation works in Firefox.
                          if (e.stopPropagation) {
                              e.stopPropagation();
                              e.preventDefault();
                          }
                          //return works for Chrome and Safari
                          return leave_message;
                      }
                  }
              }
              window.onbeforeunload = goodbye;

              // Attach the event keypress to exclude the F5 refresh
              $(document).bind('keypress', function (e) {
                  if (e.keyCode == 116) {
                      validNavigation = true;
                  }
              });

              // Attach the event click for all links in the page
              $("a").bind("click", function () {
                  validNavigation = true;
              });

              // Attach the event submit for all forms in the page
              $("form").bind("submit", function () {
                  validNavigation = true;
              });

              // Attach the event click for all inputs in the page
              $(window).bind('popstate', function () {
                  validNavigation = true;
              });

          }

          // Wire up the events as soon as the DOM tree is ready
          $(document).ready(function () {
              wireUpEvents();
          });
      </script>
      </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="HotelInfoCodeBlock" Visible="true" runat="server">
      <%--  <script type="text/javascript">
            window.alert = function (stringHotel) {
                var oWnderrorHotel = radalert("" + stringHotel + "", 550, null, 'The following fields are required');
                oWnderrorHotel.set_iconUrl("images/radlaerticon.jpg");
                oWnderrorHotel._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
            }
        </script>--%>
        <script type="text/javascript">
            //-------------------------------------------
            // Function to only allow numeric data entry
            //-------------------------------------------
            function jsNumbers_SabreP(e) {
                var evt = (e) ? e : window.event;
                var key = (evt.keyCode) ? evt.keyCode : evt.which;
                if (key != null) {
                    key = parseInt(key, 10);
                    if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                        if (!jsIsUserFriendlyChar(key, "Numbers")) {
                            var oWnd = radalert("<strong><%=OvationMemName.Value %></strong> only numbers are allowed in Sabre Property Code.", 450, 150, 'Sabre Property Code Numbers Only');
                            oWnd.set_iconUrl("images/radlaerticon.jpg");
                            oWnd._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
                            oWnd.add_close(document.getElementById('<%=Sabre_PCode.ClientID %>').focus());
                            return false;

                        }
                    }
                    else {
                        if (evt.shiftKey) {
                            return false;
                        }
                    }
                }
                return true;
            }

            //-------------------------------------------
            // Function to only allow numeric data entry
            //-------------------------------------------
            function jsNumbers_ApolloP(e) {
                var evtAp = (e) ? e : window.event;
                var keyAp = (evtAp.keyCode) ? evtAp.keyCode : evtAp.which;
                if (keyAp != null) {
                    keyAp = parseInt(keyAp, 10);
                    if ((keyAp < 48 || keyAp > 57) && (keyAp < 96 || keyAp > 105)) {
                        if (!jsIsUserFriendlyChar(keyAp, "Numbers")) {
                            var oWndApollo = radalert("Only numbers are allowed in Apollo Property Code.", 450, 150, 'Apollo Property Code Numbers Only');
                            oWndApollo.set_iconUrl("images/radlaerticon.jpg");
                            oWndApollo._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
                            oWndApollo.add_close(document.getElementById('<%=Apollo_Pcode.ClientID %>').focus());
                            return false;

                        }
                    }
                    else {
                        if (evtAp.shiftKey) {
                            return false;
                        }
                    }
                }
                return true;
            }

            //------------------------------------------
            // Function to check for user friendly keys
            //------------------------------------------
            function jsIsUserFriendlyChar(val, step) {
                // Backspace, Tab, Enter, Insert, and Delete
                if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                    return true;
                }
                // Ctrl, Alt, CapsLock, Home, End, and Arrows
                if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                    return true;
                }
                if (step == "Decimals") {
                    if (val == 190 || val == 110) {
                        return true;
                    }
                }
                // The rest
                return false;
            }
            function SabreChainlettersOnly(evt) {
                evt = (evt) ? evt : event;
                var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
          ((evt.which) ? evt.which : 0));
                if (charCode > 31 && (charCode < 65 || charCode > 90) &&
          (charCode < 97 || charCode > 122)) {
                    //alert("Enter letters only.");
                    var oWndSabreChain = radalert("Only letters are allowed in Sabre Chain Code.", 450, 150, 'Sabre Chain Code Letters Only');
                    oWndSabreChain.set_iconUrl("images/radlaerticon.jpg");
                    oWndSabreChain._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
                    oWndSabreChain.add_close(document.getElementById('<%=Sabre_Chain_Code.ClientID %>').focus());
                    return false;
                }
                return true;
            }
            function ApolloChainlettersOnly(evt) {
                evt = (evt) ? evt : event;
                var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
          ((evt.which) ? evt.which : 0));
                if (charCode > 31 && (charCode < 65 || charCode > 90) &&
          (charCode < 97 || charCode > 122)) {
                    //alert("Enter letters only.");
                    var oWndApolloChain = radalert("Only letters are allowed in Apollo Chain Code.", 450, 150, 'Apollo Chain Code Letters Only');
                    oWndApolloChain.set_iconUrl("images/radlaerticon.jpg");
                    oWndApolloChain._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
                    oWndApolloChain.add_close(document.getElementById('<%=Apollo_Chain_Code.ClientID %>').focus());
                    return false;
                }
                return true;
            }
            function check_content() {
                var text = document.getElementById('<%=Hotel_brief_descipt.ClientID %>').value;
                if (text.length >= 4000) {
                    ///alert('Length should not be greater than 3');
                    var oWndtoolong = radalert("Maximum 4000 charactors allowed.", 450, 150, 'Description Too Long');
                    oWndtoolong.set_iconUrl("images/radlaerticon.jpg");
                    oWndtoolong._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
                    oWndtoolong.add_close(document.getElementById('<%=Hotel_brief_descipt.ClientID %>').focus());
                    document.getElementById('<%=Hotel_brief_descipt.ClientID %>').Value = "";
                    return false;
                } else {
                    return true;
                }
            } 
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="AmenitiesCodeBlock" Visible="true" runat="server">
        <script type="text/javascript">
            // for room catgory rates in rates and amenities section use as needed in other sections
            //-------------------------------------------
            // Function to only allow numeric data entry
            //-------------------------------------------
            function jsNumbers(e) {
                var evt = (e) ? e : window.event;
                var key = (evt.keyCode) ? evt.keyCode : evt.which;
                if (key != null) {
                    key = parseInt(key, 10);
                    if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                        if (!jsIsUserFriendlyChar(key, "Numbers")) {
                            return false;
                        }
                    }
                    else {
                        if (evt.shiftKey) {
                            return false;
                        }
                    }
                }
                return true;
            }

            //-------------------------------------------
            // Function to only allow decimal data entry
            //-------------------------------------------
            function jsDecimals(e) {
                var evt = (e) ? e : window.event;
                var key = (evt.keyCode) ? evt.keyCode : evt.which;
                if (key != null) {
                    key = parseInt(key, 10);
                    if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                        if (!jsIsUserFriendlyChar(key, "Decimals")) {
                            return false;
                        }
                    }
                    else {
                        if (evt.shiftKey) {
                            return false;
                        }
                    }
                }
                return true;
            }

            //------------------------------------------
            // Function to check for user friendly keys
            //------------------------------------------
            function jsIsUserFriendlyChar(val, step) {
                // Backspace, Tab, Enter, Insert, and Delete
                if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                    return true;
                }
                // Ctrl, Alt, CapsLock, Home, End, and Arrows
                if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                    return true;
                }
                if (step == "Decimals") {
                    if (val == 190 || val == 110) {
                        return true;
                    }
                }
                // The rest
                return false;
            }     
        </script>
        <script type="text/javascript">
             function confirmLinkDeleteSeason(button) {
                function CallbackSeason(arg) {
                    if (arg) {
                        //obtains a __doPostBack() with the correct UniqueID as rendered by the framework
                        eval(button.href);

                        //can be used in a simpler environment so that event validation is not triggered.
                        //__doPostBack(button.id, "");
                    }
                }
                var cnses = radconfirm("This will delete all categories and this season, are sure you want to do this?", CallbackSeason, 450, 120, null, "Delete Season and Categories");
                    cnses.set_iconUrl("images/radlaerticon.jpg");
                    cnses._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";

            }
            function confirmLinkDeleteRmRt(button) {
                function CallbackRoomRate(arg) {
                    if (arg) {
                        //obtains a __doPostBack() with the correct UniqueID as rendered by the framework
                        eval(button.href);

                        //can be used in a simpler environment so that event validation is not triggered.
                        //__doPostBack(button.id, "");
                    }
                }
                var cnsesRates = radconfirm("Are you sure you want to delele this room catergory and rate?", CallbackRoomRate, 480, 10, null, "Delete Room Category and Rates");
                cnsesRates.set_iconUrl("images/radlaerticon.jpg");
                cnsesRates._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";

            }
        </script>
        <script type="text/javascript">
//            var timeout;
//            function doPostBack(t) {
//                //alert(t.name);
//                $(t.name).bind('textchange', function () {
//                    clearTimeout(timeout);
//                    $('#ajaxFired').html('<strong>Typing...</strong>');
//                    timeout = setTimeout(function () {
//                        $('#ajaxFired').html('<strong>Saved</strong>: ' + $(t).val());
//                    }, 100);
//                });
//            }
           // function doPostBack(t) {
               // $('#' + t.name).keyup(function (event) {
                   // if (event.keyCode == 13) {
                        //var message = $('#' + t.name).val();
                       // alert(message);
                    //} else {
                        //return true;
                    //}
               // });
            /}  //endTextMessage keyup
            //document.getElementById(' + t.name + ').onchange();
            //function doPostBack(t) {
                //if (t.value != "") {
                //__doPostBack(t.name, "");
                //alert(t.name);
               // alert(t.name);
                //}
               // return t.name;
            //}
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="ElectronicSigCodeBlock" Visible="true" runat="server">
        <script type="text/javascript">
           window.alert = function (stringElecSig) {
               var oWnderrorSig = radalert("" + stringElecSig + "", 550, 100, 'The following fields are required');
                oWnderrorSig.set_iconUrl("images/radlaerticon.jpg");
                oWnderrorSig._titleIconElement.style.background = "transparent url('images/radlaerticon.jpg') no-repeat scroll 0px 0px";
                oWnderrorSig.add_close(document.getElementById('<%=Electronic_Sig_title.ClientID %>').focus());


            }

        </script>
            <script type="text/javascript">
                $(document).ready(function () {
                    HighlightControlToValidate();
                    $('#<%=FromFullyCompleteBtn.ClientID %>').click(function () {
                        if (typeof (Page_Validators) != "undefined") {
                            for (var i = 0; i < Page_Validators.length; i++) {
                                if (!Page_Validators[i].isvalid) {
                                    $('#' + Page_Validators[i].controltovalidate).addClass('RFPerrors');
                                }
                                else {
                                    $('#' + Page_Validators[i].controltovalidate).removeClass('RFPerrors');
                                }
                            }
                        }
                    });
                });

                function HighlightControlToValidate() {
                    if (typeof (Page_Validators) != "undefined") {
                        for (var i = 0; i < Page_Validators.length; i++) {
                            $('#' + Page_Validators[i].controltovalidate).blur(function () {
                                var validatorctrl = getValidatorUsingControl($(this).attr("ID"));
                                if (validatorctrl != null && !validatorctrl.isvalid) {
                                    $(this).addClass('RFPerrors');
                                }
                                else {
                                    $(this).removeClass('RFPerrors');
                                }
                            });
                        }
                    }
                }
                function getValidatorUsingControl(controltovalidate) {
                    var length = Page_Validators.length;
                    for (var j = 0; j < length; j++) {
                        if (Page_Validators[j].controltovalidate == controltovalidate) {
                            return Page_Validators[j];
                        }
                    }
                    return null;
                }   
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadCodeBlock ID="finishedRFP" Visible="false" EnableViewState="false" runat="server">
              <script type="text/javascript">

                  function preventBack() {
                      //window.alert("back button");
                      window.history.forward();

                  }
                  setTimeout("preventBack()", 0);
                  window.onunload = function () {
                      null
                  }

              </script>
    </telerik:RadCodeBlock>
</head>
<body id="OvationHotelforms">
    <form id="Hotelforms" runat="server">
    <telerik:RadScriptManager ID="Ovationscriptmgr" runat="server">
        <scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </scripts>
</telerik:RadScriptManager>
<telerik:RadWindowManager ID="OvationWinMgr" CenterIfModal="true" Modal="true" ShowContentDuringLoad="false"
    Animation="Fade" AnimationDuration="150" Skin="Sitefinity" 
    EnableShadow="true" Behaviors="Close"
    runat="server" DestroyOnClose="false">
    <Windows>
        <telerik:RadWindow ID="ContactOvation"  runat="server" Width="990px" Height="625px" VisibleStatusbar="false" />
    </Windows>
<%--<PromptTemplate>
        <div class="rwDialogPopup radprompt">
            <div class="rwDialogText">
                {1}
            </div>
            <div>
                <script type="text/javascript">
                    function RadWindowprompt_detectenter(id, ev, input) {
                        if (!ev) ev = window.event;
                        if (ev.keyCode == 13) {
                            var but = input.parentNode.parentNode.getElementsByTagName("A")[0];
                            if (but) {
                                if (but.click) but.click();
                                else if (but.onclick) {
                                    but.focus(); var click = but.onclick; but.onclick = null; if (click) click.call(but);
                                }
                            }
                            return false;
                        }
                        else return true;
                    }  
                </script>
                <input onkeydown="return RadWindowprompt_detectenter('{0}', event, this);" type="text"
                    class="rwDialogInput" id="radprompt_text_{0}" value="{2}" />
            </div>
            <div>
                <a onclick="$find('{0}').close(this.parentNode.parentNode.getElementsByTagName('input')[0].value);"
                    class="rwPopupButton" href="javascript:void(0);"><span class="rwOuterSpan"><span
                        class="rwInnerSpan">##LOC[OK]##</span></span></a> <a onclick="$find('{0}').close(null);"
                            class="rwPopupButton" href="javascript:void(0);"><span class="rwOuterSpan"><span
                                class="rwInnerSpan">##LOC[Cancel]##</span></span></a>
            </div>
        </div>
    </PromptTemplate>--%>
       <ConfirmTemplate>
        <div class="rwDialogPopup radconfirm">
            <div class="rwDialogText">
                {1}
            </div>
            <div>
                <a onclick="$find('{0}').close(true);" class="rwPopupButton" href="javascript:void(0);">
                    <span class="rwOuterSpan"><span class="rwInnerSpan">##LOC[Yes]##</span></span></a>
                <a onclick="$find('{0}').close(false);" class="rwPopupButton" href="javascript:void(0);">
                    <span class="rwOuterSpan"><span class="rwInnerSpan">##LOC[No]##</span></span></a>
            </div>
        </div>
    </ConfirmTemplate>
</telerik:RadWindowManager>
       <telerik:RadAjaxManager ID="OvationRFPajxMgr" runat="server">
        <AjaxSettings>
           <telerik:AjaxSetting AjaxControlID="RadioButtonList_IsProperty_Virtuoso">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="istheVirtuosoamenityincludedPNL" />
                    <telerik:AjaxUpdatedControl ControlID="whatisVirtuosoamenity_Pnl" />
                    <telerik:AjaxUpdatedControl ControlID="Ammenities_ensurePnl" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadioButtonList_IsVirtuoso_included">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="whatisVirtuosoamenity_Pnl" />
                    <telerik:AjaxUpdatedControl ControlID="Ammenities_ensurePnl" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Amenites_property_renovation_2014">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="renovationDates_detailsPnl" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div id="container">
              <div id="top">
        <div id="header">
          <div id="social-media">
            <span>Follow us on</span>
            <a title="Visit us on Facebook" href="http://www.facebook.com/pages/The-Lawyers-Travel-Service/166225030062306" id="facebook-icon" class="social-media-icon facebook-icon" rel="external"></a>
            <a title="Follow us on Twitter" href="http://twitter.com/#!/LawyersTravel" id="twitter-icon" class="social-media-icon twitter-icon" rel="external"></a>
            <a title="Visit our LinkenIn page" href="http://www.linkedin.com/groups?gid=3662555&mostPopular=" id="linkedin" class="social-media-icon linkedin-icon" rel="external"></a>
          </div>
          <asp:HyperLink ID="logo_left" ImageUrl="~/images/phpp.png"  ToolTip="Preferred Hotel Partners Program" runat="server" />
  	<a id="logo_right" href="http://www.lawyerstravel.com/" target="_blank"><img alt="Ovation Corporate Travel and Lawyers Travel" title="Ovation Corporate Travel and Lawyers Travel" src="images/logos.png" /></a>
          <div id="main-nav">
              <ul>
                                                 <li><a  href="javascript:OpenWindow('contact.aspx','ContactOvation')" title='Contact us'>Contact Us</a></li>
             <%--      <asp:LoginView ID="OvationTravelHeaderLogView" runat="server">
                   <LoggedInTemplate>
                       <RoleGroups>
                           <asp:RoleGroup Roles="Hotels">
                               <ContentTemplate>
                                   <li><asp:LoginStatus ID="LoginStatus_top" runat="server" ToolTip="Login to your account" OnLoggedOut="LoginStatus_top_LoggedOut" /></li>

                               </ContentTemplate>
                           </asp:RoleGroup>
                       </RoleGroups>
                       </LoggedInTemplate>
                       <AnonymousTemplate>
                           <li><a href='register.aspx' title="Register with Ovation">Register</a></li>
                           <li><a href='login.aspx' title="Login to your account">Login</a></li>
                           <li><a  href="javascript:OpenWindow('contact.aspx','ContactOvation')" title='Contact us'>Contact Us</a></li>
                       </AnonymousTemplate>
                   </asp:LoginView>--%>
             </ul>
          </div>
          <asp:Panel ID="OvationLogWelcome" CssClass="logginWelcome" Visible="false" runat="server">
          <span>Welcome: <strong><asp:literal ID="welcomeName" runat="server" /></strong></span>
          </asp:Panel>
          
        </div>
      </div>
        <div id="middle">
            <div id="content" class="clearfix">
                <div id="home-photo">
                </div>
                <div id="right">
                <asp:HiddenField ID="myID" runat="server" />
                <asp:HiddenField ID="OvationMemName" runat="server" />
                <asp:HiddenField ID="MyIDTwo" runat="server" />
                <asp:HiddenField ID="TheYear" runat="server" />
                <asp:HiddenField ID="whatRFPID" runat="server" />
                <asp:Literal ID="showID" runat="server" />
                <!-- status or progress bar look in code behind to make visible -->
                    <asp:Panel ID="formstatusBarContainer" Visible="false" Style="padding-bottom: 35px;
                        margin-left: 18px;" runat="server">
                        <asp:Panel ID="formBarOutLine" Style="width: 900px;height:15px;" runat="server">
                        <asp:Label ID="progressTextHotelInfo" Width="185px" Text="Hotel Information | Incomplete" runat="server" /> 
                        <asp:Label ID="progressbarAmmen" Width="200px" Text="2014 Rates & Amenitie | Incomplete" runat="server" />
                        <asp:Label ID="progressBarTxtMarketingPackages" Width="200px" Text="Marketing Packages | Incomplete" runat="server" />
                        <asp:Label ID="progressBarTxtElectronicSig" Width="175px" Text="Electronic Signiture | Incomplete" runat="server" />
                        <asp:Label ID="progressBarTxtRFPForm" Width="120px" Text="2014 RFP | Incomplete" runat="server" />
                        <asp:Panel ID="progressBar" Width="900px" Height="15px" BorderColor="LightGray" BorderStyle="Solid" BorderWidth="1px" style="background: url('Images/tabselected.png')"
                        runat="server" />
                    </asp:Panel>
                    </asp:Panel>
                     <!-- status or progress bar look in code behind to make visible -->
                     <asp:Panel ID="RFPqueryError" Visible="false" runat="server">
                     <p>The RFP does not exist, please try again, <a href="http://dev.ovationtravel.com/OvationRFP">click here to do</a></p>
                     </asp:Panel>
                    <telerik:RadTabStrip ID="OvationTabs" AutoPostBack="true" OnTabClick="OvationTabs_TabClick" runat="server" SelectedIndex="0"
                        MultiPageID="OvationMultiPage" Height="23px" Skin="Simple" 
                        UnSelectChildren="True" Width="918px" ClickSelectedTab="true">
                        <Tabs>

                                    <telerik:RadTab runat="server" Text="Section 1: Hotel Information" CssClass="OvationTab" HoveredCssClass="tabhover"
                                        SelectedCssClass="tabselected" Value="Hotel_Info" PageViewID="HotelInfoView" />
                                    <telerik:RadTab runat="server" Text="Section 2: Rates & Amenities" CssClass="OvationTab"
                                        HoveredCssClass="tabhover" Value="Rates_Amenities" SelectedCssClass="tabselected"
                                        PageViewID="RatesAmenitiesView" />
                                    <telerik:RadTab runat="server" Text="Section 3: Marketing Packages" CssClass="OvationTab" HoveredCssClass="tabhover"
                                        SelectedCssClass="tabselected" Value="Marketing_pkgs" PageViewID="marketingPCKsView" />
                                    <telerik:RadTab runat="server" Text="Section 4: Sign and Submit" CssClass="OvationTab" HoveredCssClass="tabhover"
                                        Value="Electronic_Sig" SelectedCssClass="tabselected" />
                                </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="OvationMultiPage" RenderSelectedPageOnly="true" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="HotelInfoView" runat="server">
                            <div class="ContainersFormTop">
                            </div>
                            <div class="ContainersFormContent">
                                <div style="padding-left:60px;">
                                    <img src="Images/HotelInfoTitle.png" title="Hotel Information" alt="Hotel Information" />
                                    <div class="MoreInfoBTN" style="margin-right:35px;">
                                        <asp:HyperLink ID="LinktoHelpOne" Style="padding-top:5px; padding-bottom:5px;"
                                            Text="Information You <br>Need to Know" ToolTip="For informatiopn you need to know about our program click here"
                                            runat="server" />
                                    </div>
                                    </div> 
                                    <br />                                                                 
                                    <p style="margin-left:65px;">
                                        <strong>*</strong> Indicates Required Fields</p>
                                    <br />
                                    <br />
                                <table border="0" cellpadding="2" cellspacing="2" class="Global_RFP_form_colOne">
                                    <tr>
                                        <td style="width:146px;">
                                            <label for="Hotel_Name">
                                                 * Hotel Name</label>
                                        </td>
                                        <td style="width:-3px;">
                                        <asp:TextBox ID="Hotel_Name" runat="server" TabIndex="1" />
    
                                        </td>
                                        <td style="width:290px;">
                                            &nbsp;
                                        </td>
                                        <td style="width:201px;">
                                            <label for="Sales_Contact_Name">
                                                * Sales Contact Name</label>
                                        </td>
                                        <td style="width:293px;">
                                            <asp:TextBox ID="Sales_Contact_Name" runat="server" TabIndex="13" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Hotel_Addr_One">
                                                * Address 1</label>
     
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Hotel_Addr_One" runat="server" TabIndex="2" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label for="Sales_Contact_Title">
                                                * Sales Contact Title</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Sales_Contact_Title" runat="server" TabIndex="14" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Hotel_Addr_Two">
                                                 &nbsp;&nbsp;Address 2</label>
                                        </td>
                                        <td>
                                        <asp:TextBox ID="Hotel_Addr_Two" TabIndex="3" runat="server" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label for="Sales_Contact_Telephone">
                                                * Sales Contact Telephone</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Sales_Contact_Telephone" runat="server" TabIndex="15" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Hotel_city">
                                                * City</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Hotel_city" runat="server" TabIndex="4" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label for="Sales_Contact_Fax">
                                                * Sales Contact Fax</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Sales_Contact_Fax" runat="server" TabIndex="16" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="HotelInfo_State">
                                                * State</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="HotelInfo_State" TabIndex="5" runat="server">
                                                <asp:ListItem Text="Please Choose a State" Value="Please Choose a State" />
                                                <asp:ListItem Text="Does not apply" Value="Non US State" />
                                                <asp:ListItem Text="Alabama" Value="Alabama" />
                                                <asp:ListItem Text="Alaska" Value="Alaska" />
                                                <asp:ListItem Text="Arizona" Value="Arizona" />
                                                <asp:ListItem Text="Arkansas" Value="Arkansas" />
                                                <asp:ListItem Text="California" Value="California" />
                                                <asp:ListItem Text="Colorado" Value="Colorado" />
                                                <asp:ListItem Text="Connecticut" Value="Connecticut" />
                                                <asp:ListItem Text="Delaware" Value="Delaware" />
                                                <asp:ListItem Text="Florida" Value="Florida" />
                                                <asp:ListItem Text="Georgia" Value="Georgia" />
                                                <asp:ListItem Text="Hawaii" Value="Hawaii" />
                                                <asp:ListItem Text="Idaho" Value="Idaho" />
                                                <asp:ListItem Text="Illinois" Value="Illinois" />
                                                <asp:ListItem Text="Indiana" Value="Indiana" />
                                                <asp:ListItem Text="Iowa" Value="Iowa" />
                                                <asp:ListItem Text="Kansas" Value="Kansas" />
                                                <asp:ListItem Text="Kentucky" Value="Kentucky" />
                                                <asp:ListItem Text="Louisiana" Value="Louisiana" />
                                                <asp:ListItem Text="Maine" Value="Maine" />
                                                <asp:ListItem Text="Maryland" Value="Maryland" />
                                                <asp:ListItem Text="Massachusetts" Value="Massachusetts" />
                                                <asp:ListItem Text="Michigan" Value="Michigan" />
                                                <asp:ListItem Text="Minnesota" Value="Minnesota" />
                                                <asp:ListItem Text="Mississippi" Value="Mississippi" />
                                                <asp:ListItem Text="Missouri" Value="Missouri" />
                                                <asp:ListItem Text="Montana" Value="Montana" />
                                                <asp:ListItem Text="Nebraska" Value="Nebraska" />
                                                <asp:ListItem Text="Nevada" Value="Nevada" />
                                                <asp:ListItem Text="New Hampshire" Value="New Hampshire" />
                                                <asp:ListItem Text="New Jersey" Value="New Jersey" />
                                                <asp:ListItem Text="New Mexico" Value="New Mexico" />
                                                <asp:ListItem Text="New York" Value="New York" />
                                                <asp:ListItem Text="North Carolina" Value="North Carolina" />
                                                <asp:ListItem Text="North Dakota" Value="North Dakota" />
                                                <asp:ListItem Text="Ohio" Value="Ohio" />
                                                <asp:ListItem Text="Oklahoma" Value="Oklahoma" />
                                                <asp:ListItem Text="Oregon" Value="Oregon" />
                                                <asp:ListItem Text="Pennsylvania" Value="Pennsylvania" />
                                                <asp:ListItem Text="Rhode Island" Value="Rhode Island" />
                                                <asp:ListItem Text="South Carolina" Value="South Carolina" />
                                                <asp:ListItem Text="South Dakota" Value="South Dakota" />
                                                <asp:ListItem Text="Tennessee" Value="Tennessee" />
                                                <asp:ListItem Text="Texas" Value="Texas" />
                                                <asp:ListItem Text="Utah" Value="Utah" />
                                                <asp:ListItem Text="Vermont" Value="Vermont" />
                                                <asp:ListItem Text="Virginia" Value="Virginia" />
                                                <asp:ListItem Text="Washington" Value="Washington" />
                                                <asp:ListItem Text="West Virginia" Value="West Virginia" />
                                                <asp:ListItem Text="Wisconsin" Value="Wisconsin" />
                                                <asp:ListItem Text="Wyoming" Value="Wyoming" />
                                                <asp:ListItem Text="American Samoa" Value="American Samoa" />
                                                <asp:ListItem Text="District of Columbia" Value="District of Columbia" />
                                                <asp:ListItem Text="Guam" Value="Guam" />
                                                <asp:ListItem Text="Northern Mariana Islands" Value="Northern Mariana Islands" />
                                                <asp:ListItem Text="Puerto Rico" Value="Puerto Rico" />
                                                <asp:ListItem Text="The United States Virgin Islands" Value="The United States Virgin Islands" />
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label for="Sales_Contact_Email">
                                                * Sales Contact Email</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Sales_Contact_Email" runat="server" TabIndex="17" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Hotel_Addr_One">
                                                * Country</label>
                                        </td>
                                        <td>
                                            <cc1:CountryState ID="Hotelcountry" runat="server" ValueList="countryNames" TabIndex="6" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label for="Hotel_general_mgr">
                                                * General Manager</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Hotel_general_mgr" runat="server" TabIndex="18" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Hotel_Addr_Two">
                                               * Zip/Post Code</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Hotel_zip_post_code"  runat="server" TabIndex="7" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label for="Director_of_Sales">
                                                * Director of Sales</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Director_of_Sales" runat="server" TabIndex="19" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:24px;">
                                            <label for="Hotel_Main_phone">
                                                * Hotel Main Phone</label>
                                        </td>
                                        <td>
                                         <asp:TextBox ID="Hotel_Main_phone"  runat="server" TabIndex="8" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label for="Hotel_Web_Site">
                                                * Hotel Web Site</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Hotel_Web_Site" runat="server" TabIndex="20" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Sabre_PCode">
                                                &nbsp;&nbsp;Sabre Property Code</label>
                                        </td>
                                        <td>
                                          <asp:textbox ID="Sabre_PCode" runat="server" MaxLength="7" TabIndex="9" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Sabre_Chain_Code">
                                                &nbsp;&nbsp;Sabre Chain Code</label>
                                        </td>
                                        <td>
                                           <asp:textbox ID="Sabre_Chain_Code" runat="server" MaxLength="2" TabIndex="10" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Apollo_Pcode">
                                                &nbsp;&nbsp;Apollo Property Code</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Apollo_Pcode" runat="server" MaxLength="7" TabIndex="11" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="Apollo_Chain_Code">
                                               &nbsp;&nbsp;Apollo Chain Code</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Apollo_Chain_Code" runat="server" MaxLength="2" TabIndex="12" /> 
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                    </tr>
                                </table>
                                <table class="Hotel_Column_AAArateing" border="0">
                                    <tr>
                                        <td>
                                            <label for="AAAating" style="margin-top:.43em;display:block;width:140px;font-size:11px;letter-spacing:1px;line-height:1.3;">
                                                * AAA Diamond Rating</label>
                                                <br />
                                                <br />
                                                <asp:RadioButtonList ID="AAAating" runat="server" TabIndex="21" RepeatLayout="flow"
                                                    CssClass="RBL" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1" />
                                                    <asp:ListItem Text="2" />
                                                    <asp:ListItem Text="3" />
                                                    <asp:ListItem Text="4" />
                                                    <asp:ListItem Text="5" />
                                                    <asp:ListItem Value="NR" Text="Not Rated" />
                                                </asp:RadioButtonList>
   
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table class="Hotel_Column_AAArateing" border="0">
                                    <tr>
                                        <td>
                                            <label for="MobileStaRate" style="margin-top:.43em;display:block;width:129px;font-size:11px;letter-spacing:1px;line-height 1.3;">
                                                * Mobile Star Rating</label>
                                                <br />
                                                <br />
                                                <asp:RadioButtonList ID="MobileStaRate" TabIndex="22" runat="server"
                                                    RepeatLayout="flow" CssClass="RBL" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1" />
                                                    <asp:ListItem Text="2" />
                                                    <asp:ListItem Text="3" />
                                                    <asp:ListItem Text="4" />
                                                    <asp:ListItem Text="5" />
                                                    <asp:ListItem Value="NR" Text="Not Rated" />
                                                </asp:RadioButtonList>
 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" class="HotelInfo_colOne_B ">
                                    <tr>
                                        <td>
                                            <label for="Hotel_brief_descipt">
                                                * Provide Us with a brief description of your property</label>
                                            <br />
                                            <asp:TextBox ID="Hotel_brief_descipt" runat="server" TextMode="MultiLine" MaxLength="4000" TabIndex="23"
                                                Rows="5" Width="500px" BackColor="White" BorderColor="#CECECE" BorderStyle="Solid" BorderWidth="1px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                 <h1 style="padding-left:60px;">
                                    <img src="Images/CorpResponTitle.png" title="Corporate RESPONSIBILITY" alt="Corporate RESPONSIBILITY" /></h1>
                                <table class="corpRespons" border="0">
                                    <tr>
                                        <td>
                                            <label for="Enviroment_Program">
                                                What current enviromental certification programs(s) (e.g. Energy Star, GreenLeaf,
                                                LEED etc. do you participate in?
                                            </label>
                                            <br />
                                            <asp:TextBox ID="Enviroment_Program" TabIndex="24" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table class="corpResponsTwo" border="0">
                                    <tr>
                                        <td>
                                            <label for="RadioButtonList_avtiveRecycle">
                                                * Does your property have an active recycling program in place?</label><asp:RadioButtonList
                                                    ID="RadioButtonList_avtiveRecycle" runat="server" RepeatLayout="flow" CssClass="RBL" RepeatDirection="Horizontal" TabIndex="25">
                                                    <asp:ListItem Text="Yes" />
                                                    <asp:ListItem Text="No" />
                                                </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table class="corpResponsTwo" border="0">
                                    <tr>
                                        <td>
                                            <label for="RadioButtonList_Property_Responsible_Cleaners">
                                                * Is your property utilizing environmentally responsible cleaners throughout the property
                                                (MSDS Health Hazard Rating 1 or less)?</label>
                                            <br />
                                            <asp:RadioButtonList ID="RadioButtonList_Property_Responsible_Cleaners" runat="server"
                                                RepeatLayout="flow" CssClass="RBL" RepeatDirection="Horizontal" TabIndex="26">
                                                <asp:ListItem Text="Yes" />
                                                <asp:ListItem Text="No" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table class="corpResponsTwo" border="0">
                                    <tr>
                                        <td>
                                            <label for="RadioButtonList_Property_WaterConserve">
                                                * Does your property have an active water conservation program in place such as a
                                                linen reuse option to multiple night guests and/or water conservation fixtures</label>
                                            <br />
                                            <asp:RadioButtonList ID="RadioButtonList_Property_WaterConserve" runat="server" RepeatLayout="flow"
                                                CssClass="RBL" RepeatDirection="Horizontal" TabIndex="27">
                                                <asp:ListItem Text="Yes" />
                                                <asp:ListItem Text="No" />
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <div id="HotelInfowrapper" class="HoteltabbedFormsBtn">
                                    <asp:Button ID="HotelInfoNextBtn" runat="server" CssClass="formsections-btn"
                                        Text="Save Hotel Information"  CausesValidation="false" OnClick="HotelInfoNextBtn_Click" TabIndex="28"
                                         />
                                </div>
                                <br />
                            </div>
                            <div class="ContainersFormBottom">
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RatesAmenitiesView" runat="server">
                            <div class="ContainersFormTop">
                            </div>
                            <div class="ContainersFormContent">
                                <div class="ContainerContent">
                                    <div style="padding-left:20px;">
                                        <img src="Images/2014rates_ameneites.png" title="2014 Rates & Amenities" alt="2014 Rates & Amenities" />
                                    <div class="MoreInfoBTN">
                                        <asp:HyperLink ID="LinktoHelpTwo" Style="padding-top:5px;padding-bottom:5px;"
                                            Text="Information You <br>Need to Know" ToolTip="For informatiopn you need to know about our program click here"
                                            runat="server" />
                                    </div>
                                        </div>
                                        <br />
                                        <br />
                                        <p style="margin-left:20px;font-size:16px;">
                                            <strong>*</strong> Indicates Required Fields</p>
                                        <br />
<%--                                        <asp:ValidationSummary ID="RatesAmenitiesValSum" CssClass="errors" ValidationGroup="AmmenValGroup" DisplayMode="List" ShowSummary="false" ShowMessageBox="true" Width="750px" runat="server" />--%>
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                                <label style="font-size:14px;">
                                                    Ovation and Lawyers Travel Negotiated Preferred Rate(s) for 2014 Preferred Rates
                                                    are 10% Commisionable. Please include room types/categories associated rates. We
                                                    accept seasonal rates, however due to the structure of our hotel program Floating/Bar/Dynamic
                                                    pricing rate model cannot be accepted.
                                                </label>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="rates2014_LeftColumn_F" border="0">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" OnResponseEnd="CreateScripts" LoadingPanelID="OvationformLoader">
                                    <asp:LinkButton ID="rebindRepaterBadDate" Visible="true" runat="server" />
                                    <asp:Literal ID="testme" runat="server" />
                                    <asp:Repeater runat="server" ID="roomcategoryGroup" DataSourceID="RmSeasonData"
                                        Onitemdatabound="roomcategoryGroup_ItemDataBound" 
                                        Onitemcommand="roomcategoryGroup_ItemCommand" ViewStateMode="Enabled">
                                        <HeaderTemplate>
                                            <br />
                                            <table style="margin-left:20px;">
                                            <tr>
                                            <td style="background: url('Images/seaontitle.png');height:40px;">
                                            <br />
                                            <br />
                                            </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="background-color:#DFDFDF;">
                                                    <asp:Literal ID="txtSeason" runat="server" /><%# Container.ItemIndex + 1%>
                                                    <asp:HiddenField ID="testreadSeason" runat="server" />
<%--                                                    <asp:LinkButton ID="Delete_Season" ToolTip="Click here to Delete This Season" runat="server"
                                                        CssClass="Deletecategory-btn" CausesValidation="false" Visible="false" Text="Click here to delete this season"
                                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LID") %>' CommandName="DeleteThisSeason" />--%>
                                                    <br />
                                                    <asp:HiddenField ID="seaonNumber" runat="server" />
                                                </td>
                                            </tr>
                                        <tr>
                                            <td class="rates2014_leftColumn_K" style="background-color:#F1F0ED">
                                                <div style="margin-left:17px;padding-top:5px;">
                                                    <asp:RequiredFieldValidator ID="RMCatStDte_Start_Val_Blank" ControlToValidate="RMCatStDte_Start"
                                                        runat="server" ErrorMessage="Start date cannot be blank" ValidationGroup="DatesinRates_Blank" ForeColor="#582D1F" Display="Dynamic" EnableClientScript="false" SetFocusOnError="true" />
                                                         <asp:RequiredFieldValidator ID="RMCatEndDte_Start_Blank_Val" ControlToValidate="RMCatEndDte_Start"
                                                        runat="server" ErrorMessage="End date cannot be blank" ForeColor="#582D1F" ValidationGroup="DatesinRatesEndDate_Blank" Display="Dynamic" EnableClientScript="false" SetFocusOnError="true" />
                                                    <asp:CompareValidator ID="EndDate_Val" runat="Server" ControlToCompare="RMCatStDte_Start"
                                                        CssClass="stardateEndDateValidator" ControlToValidate="RMCatEndDte_Start" Operator="GreaterThan"
                                                        ErrorMessage="End date must be greater then start date" ForeColor="#582D1F" Type="Date" EnableClientScript="false"
                                                        ValidationGroup="DatesinRatesCompare" Display="Dynamic" SetFocusOnError="true" />
                                                </div>
                                                <div style="padding-top:8px;">
                                                    <div style="display: inline;float:left;padding-top:2px;">
                                                        <label id="startDateText" for="RMCatStDte_Start">
                                                            Start Date:</label>
                                                        <telerik:RadDatePicker ID="RMCatStDte_Start" SkipMinMaxDateValidationOnServer="true" AutoPostBack="true" runat="server" onselecteddatechanged="RMCatStDte_Start_SelectedDateChanged" Width="25px" DatePopupButton-ToolTip="Select a Start Date for This Category"
                                                            FocusedDate="1/1/2014 12:00:00 AM" MinDate="1/1/2014 12:00:00 AM" Calendar-RangeMinDate="1/1/2014 12:00:00 AM"
                                                            Calendar-FocusedDate="1/1/2014 12:00:00 AM" Calendar-RangeMaxDate="12/31/2014 12:00:00 AM"
                                                            DateInput-MaxDate="12/31/2014 12:00:00 AM" DateInput-MinDate="1/1/2014 12:00:00 AM"
                                                            MaxDate="12/31/2014 12:00:00 AM"
                                                            Calendar-EnableKeyboardNavigation="true" >
                                                            </telerik:RadDatePicker>
                                                   </div>
                                                    <div style="display:inline-block;padding-left:5px;">
                                                        <label id="endDateText" for="RMCatEndDte_Start">
                                                            End Date:</label>
                                                        <telerik:RadDatePicker ID="RMCatEndDte_Start" SkipMinMaxDateValidationOnServer="true" DatePopupButton-ToolTip="Select a End Date for This Category"
                                                            runat="server" AutoPostBack="true" onselecteddatechanged="RMCatEndDte_Start_SelectedDateChanged" FocusedDate="1/1/2014 12:00:00 AM" MinDate="1/1/2014 12:00:00 AM"
                                                            Calendar-RangeMinDate="1/1/2014 12:00:00 AM" Calendar-FocusedDate="1/1/2014 12:00:00 AM"
                                                            Calendar-RangeMaxDate="12/31/2014 12:00:00 AM" DateInput-MaxDate="12/31/2014 12:00:00 AM"
                                                            DateInput-MinDate="1/1/2014 12:00:00 AM" MaxDate="12/31/2014 12:00:00 AM" Width="25px"
                                                            DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "dtEDDate", "{0:M/dd/yyyy}") %>'
                                                            Calendar-EnableKeyboardNavigation="true" />
                                                    </div>
                                                    <%--<asp:LinkButton ID="UpdateStartDateEndDate" CommandName="updatetheseasondates" runat="server" />--%>
                                            <asp:Repeater ID="MultipleDates" onitemdatabound="MultipleDates_ItemDataBound" OnItemCommand="MultipleDates_ItemCommand" ViewStateMode="Enabled" runat="server">
                                                <ItemTemplate>
                                                
                                                    <div style="display:inline-block;">
                                                        <%--<asp:RequiredFieldValidator ID="Hotel_room_category_Val" ControlToValidate="Hotel_room_category" runat="server" ErrorMessage="*" ValidationGroup="seasonRmCatVal" Display="Dynamic" EnableClientScript="false" />--%>
                                                        <label class="<asp:literal ID="romatlblCssClass" runat="server" />">
                                                             Room Category:</label>
                                                        <asp:TextBox ID="Hotel_room_category" 
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "szRmTypeCat") %>' AutoPostBack="true"
                                                            Width="150px" runat="server" OnTextChanged="Hotel_room_category_TextChanged" CausesValidation="true"  ValidationGroup="seasonRmCatVal"/>
                                                             <asp:HiddenField ID="roomCatID" runat="server" />
                                                    </div>
                                                    <div style="display:inline-block;">
                                                       <%--<asp:RequiredFieldValidator ID="Hotel_room_category_Rate_Val" ControlToValidate="Hotel_room_category_Rate" runat="server" ErrorMessage="*" ValidationGroup="seasonRmRateVal" Display="Dynamic" EnableClientScript="false" />--%>
                                                       <label class="innerreapterRoomRate">Rate:</label>
                                                        <asp:TextBox ID="Hotel_room_category_Rate" OnTextChanged="Hotel_room_category_Rate_TextChanged"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "nRmRate") %>' AutoPostBack="true"
                                                            Width="50px" runat="server" />
                                                            <asp:DropDownList ID="currencyCodes" OnSelectedIndexChanged="currencyCodesInnerRepeater_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                                        <asp:LinkButton ID="DelRoomCatRate" CssClass="DeleteroomCatDateRate-btn"  Height="14px"
                                                            Width="40px" CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LID") + "," + DataBinder.Eval(Container.DataItem, "LSID")  %>'
                                                            runat="server" Text="Delete" ToolTip="Click to Delete Room Category and Rate" />
                                                        <asp:HiddenField ID="roomRateID" runat="server" />
                                                    </div>
                                                    
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </div>
                                                </td>
                                            </tr>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td class="rates2014_leftColumn_J" style="padding-top:5px;padding-bottom:8px;background-color:#F1F0ED;padding-left:600px;">
                                                    <asp:LinkButton ID="NewRmCatDateRate" CssClass="AddroomCatDateRate-btn" Width="200px"
                                                        CausesValidation="false" CommandName="AddNewRMCategory" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LID") %>'
                                                        runat="server" Text="Add Another Room Category & Rate" ToolTip="Click to Add Room Category and Rate" />
                                                        <asp:HiddenField ID="IDforRoomRateLSID" Value='<%# DataBinder.Eval(Container.DataItem, "LID") %>' runat="server" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <SeparatorTemplate>
                                            <tr ID="sepTR" runat="server">
                                                <td id="sepTD" runat="server" colspan="6" style="background-color:#FFFFFF;height:5px;"></td>
                                            </tr>
                                        </SeparatorTemplate>
                                        <FooterTemplate>
                                            <tr style="background-color:#F1F0ED;">
                                                <td class="rates2014_leftColumn_J" style="padding-top:6px;padding-left:600px;">
                                                    <asp:LinkButton ID="AddNewCategoryNoReapeat" Width="200px" runat="server" Text="Add Another Season"
                                                        ToolTip="Click This Button to Add a New Season" CssClass="AddroomCatDateRate-btn"
                                                        CausesValidation="true" CommandName="InsertSeason" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr style="background: url('Images/seasonalRatesBtmOne.png');">
                                                <td class="rates2014_leftColumn_J" style="padding-top:6px;padding-left:600px;">
                                                    <asp:LinkButton ID="doneRates" CommandName="DoneRates" Width="200px" runat="server" Text="Done With Seasonal Rates"
                                                        ToolTip="Click This Button to save rates section" CssClass="AddroomCatDateRate-btn"
                                                        CausesValidation="true" />
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:HiddenField ID="lastID" runat="server" />
                                    <asp:HiddenField ID="CalST" runat="server" />
                                    <asp:HiddenField ID="Lastseason" runat="server" />
                                  </telerik:RadAjaxPanel>
                                        <asp:SqlDataSource ID="RmSeasonData" ConnectionString="<%$ConnectionStrings:OvationBetaDB %>"
                                    DataSourceMode="DataReader" ProviderName="System.Data.SqlClient" runat="server" 
                                    SelectCommand="dbo.sp_RFP_GetRmSeason" SelectCommandType="StoredProcedure"
                                    InsertCommand="dbo.sp_RFP_AddRmSeasonWithOneRmRateCat" InsertCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:ControlParameter Name="LRFPID" ControlID="whatRFPID"  type="Int32" />
                                            </SelectParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="LRFPID" Type="String" />
                                                <asp:Parameter Name="LID" Type="Int32" />
                                            </InsertParameters>
                                    </asp:SqlDataSource>
                                    
                                    <br />
                                   <table class="rates2014_LeftColumn_F" style="margin-top:10px;margin-left:50px;" border="0">
                                    <tr>
                                    <td></td>
                                    </tr>
                                    </table>
                                    <table class="rates2014_LeftColumn_C" border="0">
                                        <tr>
                                            <td>
                                                <br />
                                                <label style="width:5px;">*</label>
                                                 <asp:RadioButtonList ID="Radiolist_Floating_Bar_Dynamic" runat="server" RepeatLayout="flow"
                                                    CssClass="RBL" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="Y" Text="LRA" />
                                                    <asp:ListItem Value="N" Text="N-LRA" />
                                                </asp:RadioButtonList>
                                                <br />
                                                Additional Comments on Rates
                                                <br />
                                                 <asp:TextBox ID="AddCmntsRates" BackColor="White" BorderColor="#CECECE" BorderStyle="Solid"
                                                    BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5" Width="550px" />

<%--                                                <asp:RequiredFieldValidator ID="Radiolist_Floating_Bar_Dynamic_Val" ControlToValidate="Radiolist_Floating_Bar_Dynamic"
                                                    runat="server" Text="Please choose <strong>LRA</strong> or <strong>N-LRA</strong>"
                                                    ErrorMessage="Please choose <strong>LRA</strong> or <strong>N-LRA</strong><br /><br />"
                                                    ValidationGroup="AmmenValGroup" Display="Dynamic" SetFocusOnError="false" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                                <label for="percentageRecieveOffRate">
                                                    * If your Floating/Bar/Dynamic Pricing rate model should float below Ovation's negotiated
                                                    rate, what percentage discount will Ovation recieve off the rate?</label>
                                                <br />
                                                <br />
                                                <asp:TextBox ID="percentageRecieveOffRate" BackColor="White" BorderColor="#CECECE" BorderStyle="Solid"
                                                    BorderWidth="1px" runat="server" />
                       <%--                         <asp:RequiredFieldValidator ID="percentageRecieveOffRate_Val" ControlToValidate="percentageRecieveOffRate" Text="" ErrorMessage="<strong>What percentage discount</strong> cannot be blank<br /><br />" runat="server" ValidationGroup="AmmenValGroup" Display="none" SetFocusOnError="true" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="rates2014_LeftColumn_D" border="0">
                                        <tr>
                                            <td>
                                                <br />
                                                <br />
                                                <label>
                                                    (For hotels outside US) Currency
                                                </label>
                                                <asp:RadioButtonList ID="RadioButtonList_VatType" runat="server" 
                                                    CssClass="RBL_two" RepeatDirection="Horizontal" RepeatLayout="flow">
                                                    <asp:ListItem Value="Y" Text="Excl. VAT" />
                                                    <asp:ListItem Value="N" Text="Incl. VAT" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                            <br />
                                                <label for="RadioButtonList_WoulextendRateYN">
                                                    * Would you extend the above Ovation negotiated rates for groups/meetings (a group/meeting
                                                    would be considered a booking over 10 rooms)?</label>
                                                <br />
                                                <br />
                                                <asp:RadioButtonList ID="RadioButtonList_WoulextendRateYN" runat="server" RepeatLayout="flow"
                                                    CssClass="RBL" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" />
                                                    <asp:ListItem Text="No" />
                                                </asp:RadioButtonList>
<%--                                                <asp:RequiredFieldValidator ID="RadioButtonList_WoulextendRateYN_Val" ControlToValidate="RadioButtonList_WoulextendRateYN" runat="server" Text="Please choose <strong>Yes</strong> or <strong>No</strong>" ErrorMessage="Please choose <strong>Yes</strong> or <strong>No</strong> for would you extend the above Ovation negotiated rates for groups/meetings<br /><br />" ValidationGroup="AmmenValGroup" Display="Dynamic" SetFocusOnError="false" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                            <br />
                                                <label for="ConsortaRate">
                                                    Consortia Rate</label>
                                                <br />
                                                <asp:TextBox ID="ConsortaRate" BackColor="White" BorderColor="#CECECE" BorderStyle="Solid"
                                                    BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5" Width="550px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="rates2014_LeftColumn_E" border="0">
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <label>
                                                    If your 2014 consortia rates are based on a Floating/BAR/Dynamic Pricing rate model,
                                                    please provide us with the following:</label>
                                                    <br />
                                                    <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:460px;">
                                                <label for="Consortia_floor_Low_Rate">
                                                    What is the lowest the consortia rate will float down to (floor or low rate)?</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Consortia_floor_Low_Rate" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="Consortia_average_mediaum_Rate">
                                                    What is the average the consortia rate will float to (average or medium rate)?</label>
                                            </td>
                                            <td class="style1">
                                                <asp:TextBox ID="Consortia_average_mediaum_Rate" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="Consortia_high_Rate">
                                                    What is the highest the consortia rate will float up to (ceiling or high rate)</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Consortia_high_Rate" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <table class="rates2014_LeftColumn_F" border="0">
                                        <tr>
                                            <td>
                                                <label for="Corp_Rate">
                                                    Corporate Rate</label>
                                            </td>
                                            <td>
                                                <label for="Rack_Rate">
                                                    Rack Rate</label>
                                            </td>
                                            <td>
                                                <label for="Assoc_Rate">
                                                    Association Rate</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="Corp_Rate" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Rack_Rate" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Assoc_Rate" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_LeftColumn_E" border="0">
                                        <tr>
                                            <td>
                                                <label for="Ovation_Recruitment_Rate">
                                                    Ovation and Lawyers Travel Recruitment Rate >> Valid September - December 2014 for
                                                    recruitment travel only (US hotels only)</label>
                                                    <br />
                                                    <br />
                                                <asp:TextBox ID="Ovation_Recruitment_Rate" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                                <label for="Amenities_Offered_to_Ovation">
                                                    Amenities Offered to Ovation and Lawyers Travel Clients NOT OFFERED TO ALL GUESTS
                                                    i.e. breakfast; guaranteed early check in and/or late check out; no surcharge on
                                                    800# and/or credit card calls; complimentary spa treatment; food credit; complimentary
                                                    meeting space
                                                </label>
                                                <br />
                                                <asp:TextBox ID="Amenities_Offered_to_Ovation" BackColor="White" BorderColor="#CECECE" BorderStyle="Solid"
                                                    BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5" Width="550px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <table class="Ammenities" border="0">
                                    <tr>
                                        <td>
                                        <br />
                                            <label for="RadioButtonList_IsProperty_Virtuoso">* Is the property a Virtuoso member:</label><asp:RadioButtonList ID="RadioButtonList_IsProperty_Virtuoso" OnSelectedIndexChanged="RadioButtonList_IsProperty_Virtuoso_OnSelectedIndexChanged" AutoPostBack="true"  runat="server" RepeatLayout="flow"
                                                CssClass="RBL" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Yes" />
                                                <asp:ListItem Text="No" />
                                            </asp:RadioButtonList>
<%--                                            <asp:RequiredFieldValidator ID="RadioButtonList_IsProperty_Virtuoso_Val" ControlToValidate="RadioButtonList_IsProperty_Virtuoso" runat="server" Text="Please choose <strong>Yes</strong> or <strong>No</strong>" ErrorMessage="<br />Please choose <strong>Yes</strong> or <strong>No</strong> for is the property a Virtuoso member<br /><br/>" ValidationGroup="AmmenValGroup" Display="Dynamic" SetFocusOnError="false" />--%>
                                        </td>
                                    </tr>
                                </table>
                                    <table class="Ammenities" border="0">
                                        <tr>
                                            <td>
                                            <asp:Panel ID="istheVirtuosoamenityincludedPNL" runat="server">
                                                <label for="RadioButtonList_Property_WaterConserve">
                                                    If yes, is the Virtuoso amenity included in Ovation's negotiated rate:</label><asp:RadioButtonList ID="RadioButtonList_IsVirtuoso_included"
                                                        runat="server" RepeatLayout="flow" CssClass="RBL" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList_IsVirtuoso_included_OnSelectedIndexChanged" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" />
                                                        <asp:ListItem Text="No" />
                                                    </asp:RadioButtonList>
                                            </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_leftColumn_G" border="0">
                                        <tr>
                                            <td>
                                            <asp:Panel ID="whatisVirtuosoamenity_Pnl" runat="server">
                                                <label for="Ammenities_VirtuosoAmenity">
                                                    If yes, what is Virtuoso amenity:</label><asp:TextBox ID="Ammenities_VirtuosoAmenity" runat="server" />
                                            </asp:Panel>

                                            </td>
                                        </tr>
                                    </table>
                                    <table class="rates2014_LeftColumn_E" border="0">
                                        <tr>
                                            <td>
                                            <asp:Panel ID="Ammenities_ensurePnl" runat="server">
                                                <label for="Ammenities_ensureClient_VirtuosoAmenity">
                                                    If yes, how do we ensure clients receive amenity 
                                                    <br />
                                                    (i.e. note in "SI" field, email
                                                    res mgr)?</label>
                                                <br />
                                                <br />
                                                <asp:TextBox ID="Ammenities_ensureClient_VirtuosoAmenity" runat="server" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="Ammenities_B" border="0">
                                        <tr>
                                            <td>
                                            <br />
                                                <label for="internet_Access_inc_NegRate_GuestRoom">
                                                    * Is Internet Access included in the negotiated rate in Guest Room?</label><asp:RadioButtonList
                                                        ID="internet_Access_inc_NegRate_GuestRoom" runat="server" RepeatLayout="flow"
                                                        CssClass="RBL" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" />
                                                        <asp:ListItem Text="No" />
                                                    </asp:RadioButtonList>
<%--                                                    <asp:RequiredFieldValidator ID="internet_Access_inc_NegRate_GuestRoom_Val" ControlToValidate="internet_Access_inc_NegRate_GuestRoom" runat="server" Text="Please choose <strong>Yes</strong> or <strong>No</strong>" ErrorMessage="Please choose <strong>Yes</strong> or <strong>No</strong> for is Internet Access included in the negotiated rate in Guest Room<br /><br/>" ValidationGroup="AmmenValGroup" Display="Dynamic" SetFocusOnError="false" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="internet_Access_inc_NegRate_GuestRoom">
                                                   * Is Internet access included in the negotiated rate in Public Space?</label><asp:RadioButtonList
                                                        ID="internet_Access_inc_NegRate_publicspace" runat="server" RepeatLayout="flow"
                                                        CssClass="RBL" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" />
                                                        <asp:ListItem Text="No" />
                                                    </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="Ammenities_C" border="0">
                                        <tr>
                                            <td>
                                            <br />
                                                <p>Does your property offer the following:</p>
                                                <br />
                                                <asp:CheckBoxList ID="Amenities_Property_offering" runat="server" RepeatDirection="Horizontal"
                                                    CssClass="RBL_checkbox_B" RepeatColumns="3" RepeatLayout="table">
                                                    <asp:ListItem Value="1">Rooms with Full Kitchen</asp:ListItem>
                                                    <asp:ListItem Value="6">Outdoor Swimming Pool</asp:ListItem>
                                                    <asp:ListItem Value="10">Salon</asp:ListItem>
                                                    <asp:ListItem Value="2">Indoor Swimming Pool</asp:ListItem>
                                                    <asp:ListItem Value="7">Pet Friendly</asp:ListItem>
                                                    <asp:ListItem Value="12">Dry Cleaning</asp:ListItem>
                                                    <asp:ListItem Value="3">Extended Stay Program</asp:ListItem>
                                                    <asp:ListItem Value="8">Fitness Center</asp:ListItem>
                                                    <asp:ListItem Value="13">Laundry</asp:ListItem>
                                                    <asp:ListItem Value="4">Business Center</asp:ListItem>
                                                    <asp:ListItem Value="9">Concierge Services</asp:ListItem>
                                                    <asp:ListItem Value="14">Complimentary newspaper</asp:ListItem>
                                                    <asp:ListItem Value="5">Rooms with Kitchenette</asp:ListItem>
                                                    <asp:ListItem Value="11">Spa</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <br />
                                              <p>Are the rooms equipped with:</p>
                                                <br />
                                                <asp:CheckBoxList ID="Amenities_Rooms_Equipped_With" runat="server" RepeatDirection="Horizontal"
                                                    CssClass="RBL_checkbox_B" RepeatColumns="3" RepeatLayout="table">
                                                    <asp:ListItem Value="15">iPod Docking Station</asp:ListItem>
                                                    <asp:ListItem Value="17">Coffee/Tea Maker</asp:ListItem>
                                                    <asp:ListItem Value="19">Flat Screen TV</asp:ListItem>
                                                    <asp:ListItem Value="16">In-room Safe</asp:ListItem>
                                                    <asp:ListItem Value="18">Mini Refrigerator</asp:ListItem>
                                                    <asp:ListItem Value="20">Mini Bar</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                                <p>
                                                    What brand of amenities/products are supplied in your guest room bathrooms?</p>
                                                <asp:TextBox ID="Amenities_WhatBrandFor_GuestRoom_Bathroom" BackColor="White" BorderColor="#CECECE"
                                                    BorderStyle="Solid" BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5"
                                                    Width="550px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                                <p>
                                                    Please list the restaurant name(s) and cuisine type(s):</p>
                                                <asp:TextBox ID="Amenites_property_resturants_names" BackColor="White" BorderColor="#CECECE"
                                                    BorderStyle="Solid" BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5"
                                                    Width="550px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                                <p>
                                                    Please list the name(s) of the bar(s)/lounge(s):</p>
                                                <asp:TextBox ID="Amenites_property_Bar_Lounge_names" BackColor="White" BorderColor="#CECECE"
                                                    BorderStyle="Solid" BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5"
                                                    Width="550px" />
                                            </td>
                                       </tr>
                                    </table>
                                    <table class="Ammenities" border="0">
                                        <tr>
                                            <td>
                                                <br />
                                                <label for="Amenites_property_non_smoking">
                                                    * Is your property a non-smoking hotel?</label>
                                                <asp:RadioButtonList ID="Amenites_property_non_smoking" runat="server" RepeatLayout="flow"
                                                    CssClass="RBL" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="21" Text="Yes" />
                                                    <asp:ListItem Value="22" Text="No" />
                                                </asp:RadioButtonList>
<%--                                                <asp:RequiredFieldValidator ID="Amenites_property_non_smoking_Val" ControlToValidate="Amenites_property_non_smoking" runat="server" Text="Please choose <strong>Yes</strong> or <strong>No</strong>" ErrorMessage="Please choose <strong>Yes</strong> or <strong>No</strong> is your property a non-smoking hotel<br /><br/>" ValidationGroup="AmmenValGroup" Display="Dynamic" SetFocusOnError="false" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="Amenites_property_renovation_2014">
                                                   * Will your property undergo renovations in 2014?:</label>
                                                <asp:RadioButtonList ID="Amenites_property_renovation_2014" OnSelectedIndexChanged="Amenites_property_renovation_2014_OnSelectedIndexChanged" runat="server" RepeatLayout="flow"
                                                    CssClass="RBL" RepeatDirection="Horizontal" AutoPostBack="true">
                                                    <asp:ListItem Text="Yes" />
                                                    <asp:ListItem Text="No" />
                                                </asp:RadioButtonList>
<%--                                                <asp:RequiredFieldValidator ID="Amenites_property_renovation_2014_Val" ControlToValidate="Amenites_property_renovation_2014" runat="server" Text="Please choose <strong>Yes</strong> or <strong>No</strong>" ErrorMessage="Please choose <strong>Yes</strong> or <strong>No</strong> for will your property undergo renovations in 2014<br /><br/>" ValidationGroup="AmmenValGroup" Display="Dynamic" SetFocusOnError="false" />--%>
                                            </td>
                                            </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_LeftColumn" border="0">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="renovationDates_detailsPnl" runat="server">
                                                <p>
                                                    If yes, please provide dates and details:</p>
                                                <asp:TextBox ID="Amenites_property_renovationDates_details" BackColor="White" BorderColor="#CECECE"
                                                    BorderStyle="Solid" BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5"
                                                    Width="550px" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="rates2014_leftColumn_H" border="0">
                                        <tr>
                                            <td style="width:242px;">
                                                <label for="Ammenities_Num_roomshotel">
                                                   * How many rooms does your hotel have?</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Ammenities_Num_roomshotel" runat="server" />
<%--                                                <asp:RequiredFieldValidator ID="Ammenities_Num_roomshotel_Val" ControlToValidate="Ammenities_Num_roomshotel" runat="server" Text="" ErrorMessage="<strong>How many rooms does your hotel have</strong> cannot be blank<br />"  ValidationGroup="AmmenValGroup" Display="none" SetFocusOnError="true" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:242px;">
                                                <label for="Ammenities_Num_suiteshotel">
                                                    How many suites does your hotel have?</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Ammenities_Num_suiteshotel" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="Ammenities_D" border="0">
                                        <tr>
                                            <td>
                                                <label for="Amenities_noToWalk">
                                                    * Will you guarantee not to walk Ovation and Lawyers Travel guests?</label><asp:RadioButtonList
                                                        ID="Amenities_noToWalk" runat="server" RepeatLayout="flow" CssClass="RBL" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" />
                                                        <asp:ListItem Text="No" />
                                                    </asp:RadioButtonList>
<%--                                                    <asp:RequiredFieldValidator ID="Amenities_noToWalk_Val" ControlToValidate="Amenities_noToWalk" runat="server" Text="Please choose <strong>Yes</strong> or <strong>No</strong>" ErrorMessage="<br />Please choose <strong>Yes</strong> or <strong>No</strong> for will you guarantee not to walk Ovation and Lawyers Travel guests<br /><br />" ValidationGroup="AmmenValGroup" Display="Dynamic" SetFocusOnError="false" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table class="rates2014_leftColumn_I" border="0">
                                        <tr>
                                            <td>
                                                <label for="Aemnites_Affilation_Details">
                                                    If you are affiliated with a hotel group/collection(i.e. Leading Hotels of the World, Preferred Hotel Group, Hyatt Hotels, Starwood Hotels, etc.), please provide here:</label><br />
                                                    <asp:TextBox ID="Aemnites_Affilation_Details" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="RatesAmenities_buttonWrapper" class="HoteltabbedFormsBtn">
                                        <asp:Button ID="RatesAmenitiesNextBtn" runat="server" CssClass="formsections-btn" CausesValidation="false"
                                            Text="Save Rates and Ammenities" onclick="RatesAmenitiesNextBtn_Click" />
                                            <!-- ValidationGroup="AmmenValGroup" -->
                                    </div>
                                    <br />
                                </div>
                            </div>
                            <div class="ContainersFormBottom">
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="marketingPCKsView" runat="server">
                            <div class="ContainersFormTop">
                            </div>
                            <div class="ContainersFormContent">
                                <div class="ContainerContent">
                                    <div>
                                    <a id="marketingfocus"></a>
                                        <img src="Images/mktpcks.png" title="Marketing Packages" alt="Marketing Packages" />
                                        <div class="MoreInfoBTN">
                                            <asp:HyperLink ID="LinktoHelpThree" Style="padding-top:5px; padding-bottom:5px;" Text="Information You <br>Need to Know"
                                                Target="_blank" ToolTip="For informatiopn you need to know about our program click here"
                                                runat="server" />
                                        </div>
                                        </div>
                                      <span style="font-size:14px;">To be considered for the 2014 Preferred Hotel Partners Program, please choose either the Platinum, 
                                      <br />
                                      Gold or Silver package. The details of these packages are outlined below. These marketing opportunities
                                      <br />
                                      are only available to properties that have been selected to be a part of our 2014 Preferred Hotel Partners Program.</span>
                                      <br />
                                    <div id="validation_dialog_marketing">
<%--                                        <asp:ValidationSummary ID="MaktpcksValSum" CssClass="marketingpacksError" ValidationGroup="MarketPacksValGroup"
                                            DisplayMode="List"
                                            ShowSummary="false" ShowMessageBox="true" Width="750px" runat="server" />--%>
                                    </div>
                                      <br />
                                      <asp:CustomValidator id="Package_CstmVal" runat="server" ErrorMessage="in order to be considered for the 2014 Preferred Hotel Partners Program, please choose <strong>Platinum</strong>, <strong>Gold</strong> or <strong>Silver</strong> Package." ValidationGroup="MarketPacksValGroup" Display="none" ClientValidationFunction="MarketingPacks_ClientValidate" OnServerValidate="Package_CstmVal_ServerValidate" />
                                    <table class="marketpacks">
                                        <tr>
                                            <td colspan="4" align="center">
                                                <br />
                                                <span style="font-size:29px;font-family:LTC_twentienth_Century_MD;">MARKETING PACKAGES AVAILABLE</span>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:247;font-weight:bold;font-size:14px;" align="center">
                                            <br />
                                                Please make your selection
                                            </td>
                                            <td style="width:100px;" align="center">
                                            <asp:RadioButton ID="platinum_Package" GroupName="marketPacks" runat="server" />
                                                <br />
                                                <span style="font-weight:bold;font-size:18px;font-family:LTC_twentienth_Century_MD;">Platinum  
                                                <br />
                                                $6,599</span>
                                            </td>
                                            <td style="width:100px;" align="center">
                                             <asp:RadioButton ID="gold_Package" GroupName="marketPacks" runat="server" />
                                                <br />
                                                <span style="font-weight:bold;font-size:18px;font-family:LTC_twentienth_Century_MD;">Gold 
                                                <br />
                                                $3,599</span>
                                            </td>
                                            <td style="width:100px;" align="center">
                                            <asp:RadioButton ID="silver_Package" GroupName="marketPacks" runat="server" />
                                                <br />
                                                <span style="font-weight:bold;font-size:18px;font-family:LTC_twentienth_Century_MD;">Silver 
                                                <br />
                                                $1,699</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Listing in printed Directory</strong>
                                                <br />
                                               Your property will be listed in our
                                                2014 hotel directory with your corresponding negotiated rate
                                                </div>
                                                <br /> 
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Listing on Hotel Program Online Database</strong> Ovation and Lawyers Travel
                                                will list your hotel, contact information, the corresponding contracted rate and
                                                additional pertinent information on our company wide online database
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Sabre GDS Hotel Boost Listing</strong>
                                                <br /> 
                                                When travel consultants are searching availability in a certain city, a pop up window will appear on the Sabre screen
                                                listing only hotels participating in the Preferred Hotel Partners Program in that
                                                city
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Agents Incentivized $ Per Booking at Your Property</strong> 
                                                <br />
                                                Ovation and Lawyers Travel will pay our travel consultants for every booking at your property
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>$3</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>$2</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>$1</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Metrics Summary Reports</strong> 
                                                <br />
                                                Reports indicating how many room nights
                                                Ovation and Lawyers Travel has produced at your property
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <strong>Quarterly & Anytime On Request </strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <strong>Quarterly On Request  </strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <strong>Semi-Annually On Request</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Maps</strong>
                                                <br />
                                                Ovation and Lawyers Travel's travel professionals receive city maps flagged with
                                                our office locations and only those hotels participating in the 2013 Preferred Hotel
                                                Partners Program
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Top Lead List</strong>
                                                <br />
                                                Receive Ovation and Lawyers Travel's top corporate travel offices that book room
                                                nights in your geographic market including lead travel consultant and account manager
                                                contact information. The Enhanced Top Lead List includes all office locations, account
                                                manager information and travel consultants servicing top accounts booking into your
                                                geographic market
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Enhanced Top Lead List</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Enhanced Top Lead
                                                    <br />
                                                    List</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Top Lead List</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Sabre GDS Hotel Boost Logo</strong> 
                                                <br />
                                                Your property’s logo will appear on
                                                all travel consultant’s Sabre screens when pulling up availability in your hotel’s
                                                city for 2 weeks
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>4</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>2</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Hotel Scoop Featured Ads</strong>
                                                <br />
                                                Hotel-focused travel professional newsletter, delivered to 400 travel professionals
                                                that features hotel partners on timely subjects, promotions and updates on rates
                                                and amenities
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>4</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>2</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Ovation Club E-Newsletter Featured Ads</strong>
                                                <br />
                                                Ad in email newsletter that is distributed to Ovation and Lawyers Travel clientele.
                                                Travel decision makers including managers, administrators, CFOs and premium business
                                                travelers read this weekly e-newsletter because it focuses on the pertinent travel
                                                issues that effect them and their firm/company's travel program
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>4</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>2</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Email Blast Featured Ads</strong>
                                                <br />
                                                Special promotion communications to 400 travel professionals featuring only your
                                                property; ideal for high priority or time-sensitive messages
                                                </div>
                                                <br />

                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>4</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>2</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Competitive Set Analysis Report</strong>
                                                <br />
                                                Ovation and Lawyers Travel will run reports indicating non-preferred hotel bookings
                                                going into your competitive set
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Hotel of the Month Website Page</strong>
                                                <br />
                                                As Hotel of the Month, your hotel will be featured on Ovation and Lawyers Travel
                                                website as Hotel of the Month with marketing messages and pictures
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Banner Ad</strong>
                                                <br />
                                                1 month of a banner ad on our online booking system
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Travel Itinerary Emailed Confirmations</strong>
                                                <br />
                                                1 month of your property's marketing message on all traveler itinerary emailed confirmations
                                                (approximately 20,000 confirmations) with link to our Website's "Hotel of the Month"
                                                featured page
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <div style="padding-left:10px;white-space:normal;padding-right:5px;font-size:12px;">
                                                <strong>Plasma Screen Ad</strong>
                                                <br />
                                                As Hotel of the Month, your hotel will be featured for 1 month on the plasma screen
                                                at reception in Ovation and Lawyers Travel's HQ
                                                </div>
                                                <br />
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>Y</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                            <td align="center">
                                                <br />
                                                <br />
                                                <strong>N</strong>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="MarketingPacksButnWrapper" class="HoteltabbedFormsBtn_marketingPacks">
                                        <asp:Button ID="MarketingPacksNextBtn" runat="server" CssClass="formsections-btn" CausesValidation="false"
                                            Text="Save Marketing Package" onclick="MarketingPacksNextBtn_Click" />
                                           <!-- ValidationGroup="MarketPacksValGroup" -->
                                    </div>
                                    <br />
                                </div>
                            </div>
                            <div class="ContainersFormBottom">
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="ElectornicSigView" runat="server">
                            <div class="ContainersFormTop">
                            </div>
                            <div class="ContainersFormContent">
                                <div class="ContainerContent">
                                    <div style="padding-left:20px;">
                                    <asp:Literal ID="errorNoerror" runat="server" />
                                    <asp:Panel ID="rfpsubmiterror" Visible="false" runat="server">
                                    error
                                    </asp:Panel>
                                    <asp:Panel ID="noerror" Visible="false" runat="server">
                                    no error
                                    </asp:Panel>
                                    <asp:ValidationSummary ID="ValidationSummary1" CssClass="errors" ValidationGroup="HotelInfoValGroup" DisplayMode="List" ShowSummary="false" ShowMessageBox="true" Width="750px" runat="server" />
                                        <img src="Images/electronicSigTitle.png" title="Electronic Signiture" alt="Electronic Signiture" /></div>
                                        <!-- content here -->
                                        <asp:ValidationSummary ID="ElectronicSigValSummary" ShowSummary="false" ShowMessageBox="true" DisplayMode="List" ValidationGroup="ElectronicSigValGroup" runat="server" />
                                                <br />
                                                <ul style="list-style: disc;line-height 26px; margin-left:25px;">
                                        <li style="font-size: 14px;">The rates are guaranteed not to increase during effective
                                            date period</li>
                                        <li style="font-size: 14px;">The digital signature submitted in this RFP form represents
                                            a binding agreement with Ovation Corporate Travel and Lawyers Travel.</li>
                                        <li style="font-size: 14px;">The hotel agrees to pay the fee for each hotel selected
                                            and participating in the 2014 Preferred Hotel Partners Program.</li>
                                        <li style="font-size: 14px;">Failure to pay timely commission and marketing package
                                            fees will result in removal from the Preferred Hotel Partners Program.</li>
                                        <li style="font-size: 14px;">Should your property undergo a change in management, the
                                            original management company who completed this RFP is responsible to pay the participation
                                            fee due in full.</li>
                                        <li style="font-size: 14px;">The timely completion of this contract does not guarantee
                                            inclusion in the program.</li>
                                        <li style="font-size: 14px;">All rates are 10% commissionable.</li>
                                        <li style="font-size: 14px;">All negotiated rates must be loaded in the GDS no later
                                            than January 14, 2014.</li>
                                        <li style="font-size: 14px;">The rate header for our negotiated rates should read: "OVATION
                                            AND LAWYERS TRAVEL"</li>
                                        <li style="font-size: 14px;">Travel consultants will identify themselves as "Ovation"
                                            and/or "Lawyers Travel" when contacting the hotel.</li>
                                        <li style="font-size: 14px;">The signer of this contract must inform the hotel reservations
                                            department of the contracted rates.</li>
                                        <li style="font-size: 14px;">If you are accepted into our 2014 Preferred Hotel Partners
                                            Program, you will be notified in December 2013. We will send you an invoice based
                                            on your participation package in January 2014.</li>
                                    </ul>
                                    <br />

                                    <asp:CheckBox ID="agreeTerms" CssClass="RBL_checkbox_terms" CausesValidation="true" Text="I Agree to The Terms" runat="server" />
                                    <cc3:CheckBoxValidator ID="CheckBoxValidator1" runat="server" ControlToValidate="agreeTerms" ForeColor="#582D1F" Font-Size="14px" ValidationGroup="ElectronicSigValGroup" Display="Dynamic" Text="Please Accept The Terms of your RFP Response" ErrorMessage="Please Accept The Terms of your RFP Response<br /><br />" />
                                    <br />
                                    <br />
                                        <p style="padding-left:20px;font-size:16px;">By typing your digital signature below and submitting this form, this becomes a binding agreement with Ovation Corporate Travel and Lawyers Travel.</p>
                                        <br />
                                    <table class="electronicSig" border="0">
                                        <tr>
                                            <td>
                                                <label for="Electronic_Sig_title">
                                                    Digital Signature and Title (your name and title)</label>
                                                <br />
                                                <asp:TextBox ID="Electronic_Sig_title" runat="server" />
                                                <asp:RequiredFieldValidator ID="Electronic_Sig_title_Val" ControlToValidate="Electronic_Sig_title" runat="server" Text="" ErrorMessage="Digital Signature Cannot be Blank<br /><br />" ValidationGroup="ElectronicSigValGroup" Display="none" SetFocusOnError="true" />
                                            </td>
                                        </tr>
                                        <tr><td>&nbsp;</td></tr>
                                        <tr>
                                            <td>
                                                <label for="Electronic_Sig_comments" style="font-size:16px;">
                                                    Comments</label>
                                                <br />
                                                <asp:TextBox ID="Electronic_Sig_comments" BackColor="White" BorderColor="#CECECE"
                                                    BorderStyle="Solid" BorderWidth="1px" runat="server" TextMode="MultiLine" Rows="5"
                                                    Width="550px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="EelectronicSigBtnWrapper" class="HoteltabbedFormsBtn_ElectronicSig">
                                        <asp:Button ID="FromFullyCompleteBtn" runat="server" CssClass="electronicSig-btn" CausesValidation="true"
                                             ValidationGroup="ElectronicSigValGroup" Text="Submit RFP Response" OnClick="FromFullyCompleteBtn_Click" />
                                    </div>
                                    <br />
                                    <p style="padding-left:20px;font-size:16px;">A copy of your RFP response will be emailed to the sales contact specified in the hotel information.</p>
                                    <br />
                                    <br />
                                </div>
                            </div>
                            <div class="ContainersFormBottom">
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RFPSEctionsErrors" runat="server">
                            <div class="ContainersFormTop">
                            </div>
                            <div class="ContainersFormContent">
                                <div class="ContainerContent">
                                    <div style="padding-left: 58px;">
                                        <span style="font-size:20px;font-family:LTC_twentienth_Century_MD;color:#582C1F; text-align:center;">BEFORE YOU SIGN AND SUBMIT YOUR RFP RESPONSE PLEASE FILL OUT EACH SECTION PROPERLY</span></div>
                                    <br />
                                     <asp:Panel ID="hotelinfoError" Visible="true" EnableViewState="false" runat="server">
                                     <br />
                                     <img src="Images/HotelInfoTitle.png" style="padding-left: 20px;" />
                                                <ul style="padding-left: 55px; padding-bottom: 30px; list-style: disc; font-size: 14px;">
                                            <asp:Literal ID="OhotelName" Text="<li>Hotel Name cannot be blank</li>" Visible="false"
                                                runat="server" EnableViewState="false" />
                                            <asp:Literal ID="OaddressOne" Text="<li>Address 1 cannot be blank</li>" runat="server"
                                                Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHCity" Text="<li>City cannot be blank</li>" runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHState" Text="<li>Please select a state or does not apply</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHcountry" Text="<li>Please select a country</li>" runat="server"
                                                Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHZipC" Text="<li>Zip/Postal Code cannot be blank</li>" runat="server"
                                                Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHmainPhone" Text="<li>Hotel Main Phone cannot be blank</li>" runat="server"
                                                Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHSalesConName" Text="<li>Sales Contact Name cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHSaleConTit" Text="<li>Sales Contact Title cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHSalesContactPhone" Text="<li>Sales Contact Telephone cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHSalesConfax" Text="<li>Sales Contact Fax cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHSalesConEmlEmpty" Text="<li>Sales Contact Email cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHSalesConEmlBad" Text="<li>Sales Contact Email is In-Valid</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHGenMgr" Text="<li>General Manager cannot be blank</li>" runat="server"
                                                Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHDirectSales" Text="<li>Director of Sales cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHwebsite" Text="<li>Hotel Web Site cannot be blank</li>" runat="server"
                                                Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHAAARating" Text="<li>Please select a AAA Diamond Rating</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHMobileStar" Text="<li>Please select a Mobile Star Rating</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHhotelBreifdescript" Text="<li>Please Provide Us with a brief description of your property</li>"
                                                runat="server" Visible="false" EnableViewState="false" />   
                                            <asp:Literal ID="OHActiveRecyle" Text="<li>Please choose Yes or No for does your property have an active recycling program</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHResponsible" Text="<li>Please choose Yes or No for is your property utilizing environmentally responsible cleaners</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="OHwaterconserver" Text="<li>Please choose Yes or No for Does your property have an active water conservation program</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                                </ul>
                                      </asp:Panel>
                                      <asp:Panel ID="AmmenError" Visible="true" EnableViewState="false" runat="server">
                                        <img src="Images/2014rates_ameneites.png" style="padding-left: 20px;" />
                                        <br />
                                        <ul style="padding-left: 55px; padding-bottom: 30px; list-style: disc; font-size: 14px;">
                                          <asp:Literal ID="RatesSection" Text="<li>In Seasonal Rates either end date Room Category or Room Rates are blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AmmenLRAYN" Text="<li>Please choose LRA or N-LRA</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMpercentage" Text="<li>If your Floating/Bar/Dynamic Pricing rate cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMWouldExtend" Text="<li>Please choose Yes or No for Would you extend the above Ovation negotiated rates</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMIsPropVirtuoso" Text="<li>Please choose Yes or No for Is the property a Virtuoso member</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMinternetIncGuestRm" Text="<li>Please choose Yes or No for Is Internet Access included in the negotiated rate in Guest Room</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMinternetPublic" Text="<li>Please choose Yes or No for Is Internet access included in the negotiated rate in Public Space</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMIsNonSmoking" Text="<li>Please choose Yes or No for Is your property a non-smoking hotel</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMRenovations" Text="<li>Please choose Yes or No for Will your property undergo renovations in 2014</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
<%--                                            <asp:Literal ID="AMrenovationTxt" Text="<li>You chose Yes for Will your property undergo renovations in 2014, please provide dates and details also.</li>"
                                                runat="server" Visible="false" EnableViewState="false" />--%>
                                            <asp:Literal ID="AMNumberRooms" Text="<li>How many rooms does your hotel have cannot be blank</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                            <asp:Literal ID="AMnoToWalk" Text="<li>Please choose Yes or No for Will you guarantee not to walk Ovation and Lawyers Travel guests</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                        </ul>
                                    </asp:Panel>
                                    <div>
                                        <img src="Images/mktpcks.png" style="padding-left: 20px;" />
                                        <br />
                                        <ul style="padding-left: 55px; padding-bottom: 30px; list-style: disc; font-size: 14px;">
                                            <asp:Literal ID="MarketingPackError" Text="<li>Please choose one of the Marketing Packages Available</li>"
                                                runat="server" Visible="false" EnableViewState="false" />
                                        </ul>
                                        </div>
                                </div>
                            </div>
                            <div class="ContainersFormBottom">
                            </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="CompleteFrom" runat="server">
                            <div class="ContainersFormTop">
                            </div>
                            <div class="ContainersFormContent">
                                <div class="ContainerContent">
                                <%--  <h1 style="padding-left:20px;">
                                        <img src="Images/electronicSigTitle.png" title="Electronic Signiture" alt="Electronic Signiture" /></h1>--%>
                                        <br />
                                    <p style="padding-left:20px;padding-bottom:30px;">
                                        You completed and submitted your 2014 RFP form thank you!!</p>
                                </div>
                            </div>
                            <div class="ContainersFormBottom">
                            </div>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    <asp:Literal ID="alreadysubmitted" runat="server" />
                </div>
            </div>
        </div>
<div id="bottom">
     <div id="footer">
           <div id="footer-nav" class="clearfix">
             <ul>
                 <li><a href="javascript:OpenWindow('contact.aspx','ContactOvation')" title='Contact us'>
                     Contact Us</a></li>
         <%--        <asp:LoginView ID="OvationTravelFooterLogView" runat="server">
              <RoleGroups>
                         <asp:RoleGroup Roles="Hotels">
                             <LoggedInTemplate>
                                 <li>
                                     <asp:LoginStatus ID="LoginStatus_Bottom" OnLoggedOut="LoginStatus_top_LoggedOut" runat="server" ToolTip="Login to your account"/>
                                 </li>

                             </LoggedInTemplate>
                         </asp:RoleGroup>
                     </RoleGroups>
                     <AnonymousTemplate>
                         <li><a href='register.aspx' title="Register with Ovation">Register</a></li>
                         <li><a href='login.aspx' title="Login to your account">Login</a></li>
                         <li><a href="javascript:OpenWindow('contact.aspx','ContactOvation')" title='Contact us'>
                             Contact Us</a></li>
                     </AnonymousTemplate>
                 </asp:LoginView>--%>
             </ul>
           </div>
	   <div id="copyright">&copy; 2013 All rights reserved. PHONE: 800.431.1112</div>
             <div id="footer-message"></div>
             <!-- if we need a footer message put it here -->
           </div>
   </div>
    </div>
    <telerik:RadAjaxLoadingPanel ID="OvationformLoader" Transparency="20" runat="server" Skin="Default" AnimationDuration="0">
     <div><br /><br />One moment please...</div>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxLoadingPanel ID="tabsloader" Transparency="20" runat="server" Skin="Default" AnimationDuration="0" />
    </form>
</body>
</html>
