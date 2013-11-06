using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace OvationTest
{
    public partial class register : System.Web.UI.Page
    {
        // Declare class variables
        string constrReg = System.Configuration.ConfigurationManager.ConnectionStrings["OvationBetaDB"].ConnectionString;
        SmtpClient RFPmailclientToUse;
        MailMessage RFPRegisterMsg;
       
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OvationRegister_Click(object sender, EventArgs e) // was OvationRegister_Click put for testing --> OvationRegister_Click_testOne
        {
            string passwordQuestion = "fav color";
            string passwordAnswer = "blue";
            string regusernameANDEmail = NewHotlelRegEmail.Text.ToString();
            string regPW = NewHotlelRegPW.Text.ToString();
            string regName = NewHotlelRegName.Text.ToString();
            MembershipCreateStatus result;

            if (Page.IsValid)
            {

                MembershipUser HotelNewUser = Membership.CreateUser(regusernameANDEmail, regPW, regusernameANDEmail, passwordQuestion, passwordAnswer, false, out result); // out result

                ////////////////////////////////
                // un-comment for debugging // 
                //if (HotelNewUser == null)
                //{
                //    throw new MembershipCreateUserException(result);
                //}
                ///////////////////////////////
                
                switch (result)
                {

                    case MembershipCreateStatus.Success:

                        // show thank you panel hide form panel
                        regerror.Visible = false;
                        Regform.Visible = false;
                        thnkyouMsg.Visible = true;
                        thnyouBR.Visible = true;

                        Msg.Text = "Thank you <strong>" + regName + "</strong> for registering with Ovation and Lawyers Travel. A email has been sent you with a verification link.<br /><br />Please click on the verification link to fill out an RFP.";
                        thnyouBR.Text = "<br /><br />";
                        // put user is role of hotels
                        Roles.AddUserToRole(regusernameANDEmail, "Hotels");

                        // insert registration into register table execute sub for further insertion and email user
                        createNewRegister();

                        break;

                    //////// if we have problems then show errors //////////////

                    case MembershipCreateStatus.DuplicateUserName:
                        regerror.Visible = true;
                        ErrorMsg.Text = @"A user with this email address <strong>" + regusernameANDEmail + "</strong> already exists. If you already registered, please <a href=\"login.aspx\">Login</a> here.<br /><br />";
                        break;

                    case MembershipCreateStatus.DuplicateEmail:
                        regerror.Visible = true;
                        ErrorMsg.Text = "There already exists a user with this email address <strong>" + regusernameANDEmail + "</strong>.";
                        break;

                    case MembershipCreateStatus.InvalidEmail:
                        regerror.Visible = true;
                        ErrorMsg.Text = "The email address you provided in invalid.";
                        break;

                    case MembershipCreateStatus.InvalidPassword:
                        regerror.Visible = true;
                        ErrorMsg.Text = "The password you provided is invalid. It must be six characters long.";
                        break;

                    default:
                       regerror.Visible = true;
                       ErrorMsg.Text = @"There was an unknown error; your account was NOT created. please try again, or <a href=""javascript:OpenWindow('contact.aspx','ContactOvation')"">click here</a> to email us for assistance";
                       break;
                }

            }
        }

        protected void OvationRegister_Click_Test(object sender, EventArgs e)
        {
            // -- if (Page.IsValid)
            // -- {
                
                // show and hide panels based on action done
                // -- Regform.Visible = false;
                // -- thnkyouMsg.Visible = true;

                // -- Msg.Text = "Thank you <strong>" + NewHotlelRegName.Text.ToString() + "</strong> for registering with Ovation and Lawyers Travel, we have received your information and will email you when you are approved.";

                // insert new registration 
                // -- createNewRegister();


                // mail function to send thank you email
                // -- RFPmailclientToUse = new SmtpClient();
                // -- RFPRegisterMsg = new MailMessage();

                // -- RFPRegisterMsg.From = new MailAddress("ttrapp@ovationtravel.com","Ovation and Lawyers Travel");
                // -- RFPRegisterMsg.To.Add(new MailAddress("ttrapp@ovationtravel.com", NewHotlelRegName.Text.ToString()));
                // -- RFPRegisterMsg.Subject = "Thank you for registering with Ovation and Lawyers Travel";
                // -- RFPRegisterMsg.Priority = MailPriority.Normal;
                // -- RFPRegisterMsg.IsBodyHtml = false;

                // put the message together
                // -- AlternateView plainView = AlternateView.CreateAlternateViewFromString("Thank you " + NewHotlelRegName.Text + " for registering with Ovation and Lawyers Travel, we will send you an email with information when your account is approved.", null, "text/plain");

                // -- RFPRegisterMsg.AlternateViews.Add(plainView);

                // send the message
                // -- RFPmailclientToUse.Send(RFPRegisterMsg);

                // dispose and clean up resource
                // -- RFPRegisterMsg.Dispose();

            // -- }
        }


        // create new registration I.E not aspnet db entry
        protected void createNewRegister()
        {
            string regusernameANDEmail_entry = NewHotlelRegEmail.Text.ToString();
            string regName_entry = NewHotlelRegName.Text.ToString();
            Guid newHotelRegGUID = Guid.NewGuid();

            // open start 
            //db connection object
            using (SqlConnection newreginsert_Conn = new SqlConnection(constrReg))
            {

                // start cmd object
                using (SqlCommand newreginsert_cmd = new SqlCommand("dbo.sp_RFP_insertNewHotelRegister", newreginsert_Conn))
                {

                    newreginsert_cmd.CommandText = "dbo.sp_RFP_insertNewHotelRegister";
                    newreginsert_cmd.CommandType = CommandType.StoredProcedure;
                    newreginsert_cmd.CommandTimeout = 0;

                    SqlParameter newreginsert_Param = newreginsert_cmd.CreateParameter();
                    newreginsert_Param.ParameterName = "@szRegisterName";
                    newreginsert_Param.Direction = ParameterDirection.Input;
                    newreginsert_Param.SqlDbType = SqlDbType.NVarChar;
                    newreginsert_Param.Value = regName_entry;

                    newreginsert_cmd.Parameters.Add(newreginsert_Param);

                    newreginsert_Param = newreginsert_cmd.CreateParameter();
                    newreginsert_Param.ParameterName = "@szRegisterEmail";
                    newreginsert_Param.Direction = ParameterDirection.Input;
                    newreginsert_Param.SqlDbType = SqlDbType.NVarChar;
                    newreginsert_Param.Value = regusernameANDEmail_entry;

                    newreginsert_cmd.Parameters.Add(newreginsert_Param);

                    newreginsert_Param = newreginsert_cmd.CreateParameter();
                    newreginsert_Param.ParameterName = "@szLinkToken";
                    newreginsert_Param.Direction = ParameterDirection.Input;
                    newreginsert_Param.SqlDbType = SqlDbType.NVarChar;
                    newreginsert_Param.Value = newHotelRegGUID.ToString();

                    newreginsert_cmd.Parameters.Add(newreginsert_Param);


              
                    newreginsert_Param = newreginsert_cmd.CreateParameter();
                    newreginsert_Param.ParameterName = "@blnIsVerified";
                    newreginsert_Param.Direction = ParameterDirection.Input;
                    newreginsert_Param.SqlDbType = SqlDbType.Bit;
                    newreginsert_Param.Value = "False";

                    newreginsert_cmd.Parameters.Add(newreginsert_Param);

                    // open up db
                    newreginsert_Conn.Open();

                    // execute entry
                    newreginsert_cmd.ExecuteNonQuery();

                }

            }

            // mail function to send thank you email


            RFPmailclientToUse = new SmtpClient();
            RFPRegisterMsg = new MailMessage();

            RFPRegisterMsg.From = new MailAddress("acolin@ovationtravel.com", "Ovation and Lawyers Travel 2014 RFP");
            RFPRegisterMsg.To.Add(new MailAddress(regusernameANDEmail_entry, regName_entry));
            RFPRegisterMsg.Bcc.Add(new MailAddress("ttrapp@ovationtravel.com"));
            RFPRegisterMsg.Subject = "Thank you for registering with Ovation and Lawyers Travel";
            RFPRegisterMsg.Priority = MailPriority.Normal;
            RFPRegisterMsg.IsBodyHtml = false;

            // put the message together
            AlternateView plainView = AlternateView.CreateAlternateViewFromString("Thank you " + regName_entry + " for registering with Ovation and Lawyers Travel, Please click this link to verify your account." + Environment.NewLine + Environment.NewLine +
                                                                                  "http://dev.ovationtravel.com/OvationRFP/login.aspx?verify=" + newHotelRegGUID + Environment.NewLine + Environment.NewLine +  "", null, "text/plain");

            RFPRegisterMsg.AlternateViews.Add(plainView);

            // send the message
            RFPmailclientToUse.Send(RFPRegisterMsg);

            // dispose
            //and clean up resource
            RFPRegisterMsg.Dispose();
            RFPmailclientToUse.Dispose();

        }           

    }
}
