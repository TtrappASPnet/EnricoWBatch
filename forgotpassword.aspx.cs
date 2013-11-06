using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


namespace OvationTest
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        //global coonection string
        string forgotconnStr = System.Configuration.ConfigurationManager.ConnectionStrings["OvationBetaDB"].ConnectionString;
        SmtpClient RFPmailclientToUse;

        protected void Page_Load(object sender, EventArgs e)
        {
            // there has been an error
            OvationForGotPassword.UserNameFailureText = "<br />Account does not exist please try again<br />";
        }

        protected void OvationForGotPassword_VerifyingUser(object sender, LoginCancelEventArgs e)
        {
            // get user info
            OvationForGotPassword.UserName = Membership.GetUserNameByEmail(OvationForGotPassword.UserName);
        }

        // function to get users name to personalize
        public string getmypersonalName(string membername)
        {
            string result = membername;

            using (SqlConnection Userloggin_Conn = new SqlConnection(forgotconnStr))
            {

                using (SqlCommand Userloggin_cmd = new SqlCommand("dbo.sp_RFP_GetNameofUserID", Userloggin_Conn))
                {
                    Userloggin_cmd.CommandText = "dbo.sp_RFP_GetNameofUserID";
                    Userloggin_cmd.CommandType = CommandType.StoredProcedure;
                    Userloggin_cmd.CommandTimeout = 0;

                    SqlParameter Userloggin_Param = Userloggin_cmd.CreateParameter();
                    Userloggin_Param.ParameterName = "@szRegisterEmail";
                    Userloggin_Param.Direction = ParameterDirection.Input;
                    Userloggin_Param.SqlDbType = SqlDbType.NVarChar;
                    Userloggin_Param.Value = membername;

                    Userloggin_cmd.Parameters.Add(Userloggin_Param);

                    Userloggin_Conn.Open();

                    using (SqlDataReader Userloggin_Reader = Userloggin_cmd.ExecuteReader())
                    {
                        if (Userloggin_Reader.Read())
                        {
                            result = Userloggin_Reader["szRegisterName"].ToString();

                        }
                    }
                }
            }

            return result;
        }

        // send user name and password to user personalized
        protected void OvationForGotPassword_SendingMail(object sender, MailMessageEventArgs e)
        {

            e.Cancel = true;

            MembershipUser lostinfoUer = Membership.GetUser(OvationForGotPassword.UserName);
            string lostinfoPW = lostinfoUer.GetPassword();

            
             
            RFPmailclientToUse = new SmtpClient();

            e.Message.From = new MailAddress("acolin@ovationtravel.com", "Ovation and Lawyers Travel 2014 RFP");
            e.Message.To.Add(new MailAddress(OvationForGotPassword.UserName, getmypersonalName(lostinfoUer.ToString())));
            e.Message.Subject = "Ovation and Lawyers Travel 2014 RFP your login info";
            e.Message.Priority = MailPriority.High;
            e.Message.IsBodyHtml = false;
            e.Message.Body = getmypersonalName(lostinfoUer.ToString()) + " here is your login information," + Environment.NewLine + 
                                                                         Environment.NewLine +
                                                                         "User Name: " + lostinfoUer + Environment.NewLine + Environment.NewLine +
                                                                         "Password:  " + lostinfoPW + Environment.NewLine + Environment.NewLine +
                                                                         "Go to http://dev.ovationtravel.com/OvationRFP/login.aspx";




            // send the message
            RFPmailclientToUse.Send(e.Message);

            //and clean up resource
            RFPmailclientToUse.Dispose();

            // show success message
            OvationForGotPassword.SuccessText = @"<div class=""errors"" style=""width:800px;margin-top:20px;""><p style=""margin-left:10px;"">"  + getmypersonalName(lostinfoUer.ToString()) + " your information has been sent to the email address you registered with.</p></div>";

            


        }
    }
}
