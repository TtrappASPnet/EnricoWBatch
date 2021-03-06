using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace OvationTest
{
    public partial class login : System.Web.UI.Page
    {

        // declare class varibles
        // global database connection strings
        string constrVerifyReg = System.Configuration.ConfigurationManager.ConnectionStrings["OvationBetaDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            //Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
           // Response.Cache.SetNoStore(); 

            //string verifyme = HttpContext.Current.Request.QueryString["verify"];

            //if (!string.IsNullOrEmpty(verifyme))
            //{
            //    // sub for searching db for correct verify code
            //    findnewRegAndUpdate(verifyme);
            //}
            //else
            //{
            //    verifypnl.Visible = false;
            //}
        }


        protected void findnewRegAndUpdate(string verifycode)
        {
            using (SqlConnection Verifyreg_Conn = new SqlConnection(constrVerifyReg))
            {
                using (SqlCommand Verifyreg_cmd = new SqlCommand("dbo.sp_RFP_GetverifyCode", Verifyreg_Conn))
                {
                    Verifyreg_cmd.CommandText = "dbo.sp_RFP_GetverifyCode";
                    Verifyreg_cmd.CommandType = CommandType.StoredProcedure;
                    Verifyreg_cmd.CommandTimeout = 0;

                    SqlParameter Verifyreg_Param = Verifyreg_cmd.CreateParameter();
                    Verifyreg_Param.ParameterName = "@szLinkToken";
                    Verifyreg_Param.Direction = ParameterDirection.Input;
                    Verifyreg_Param.SqlDbType = SqlDbType.NVarChar;
                    Verifyreg_Param.Value = verifycode;

                    Verifyreg_cmd.Parameters.Add(Verifyreg_Param);

                    Verifyreg_Conn.Open();

                    using(SqlDataReader verifyReader = Verifyreg_cmd.ExecuteReader())
                    {
                        if (verifyReader.HasRows)
                        {
                            if (verifyReader.Read())
                            {
                                if (verifyReader["szLinkToken"].ToString() == verifycode)
                                {
                                    // we have a record, put update user in aspnet DB to user active and update registration table 
                                    // if validation code is correct but user cannot be found in aspnet db then there is a fail safe
                                    // see if statement --> if(Verifyuser != null)

                                    MembershipUser Verifyuser = Membership.GetUser(verifyReader["szRegisterEmail"].ToString()); // testiing use this account --> ttrapp@ovation.com <-- verifyReader["szRegisterEmail"].ToString()
                                    bool isApproved = true;

                                    if (Verifyuser != null)
                                    {
                                       Verifyuser.IsApproved = isApproved;
                                       Membership.UpdateUser(Verifyuser);
                                       UpdateRegTableIsVerified(verifyReader["szLinkToken"].ToString());
                                       verifypnl.Visible = true;
                                       verifymsg.Text = "<strong>" + verifyReader["szRegisterName"].ToString() + "</strong>, thank you for registering with Ovation and Lawyers Travel, your account has been verified, you can now log in and begin filling out the RFP form.";

                                    }
                                    else
                                    {
                                       verifypnl.Visible = true;
                                       verifymsg.Text = "<strong>" + verifyReader["szRegisterName"].ToString() + @"</strong>, something went wrong with your validation link, please <a href=""javascript:OpenWindow('contact.aspx','ContactOvation')"">contact us</a> for further assistance.";

                                    }
                                }
                            }
                        }
                        else
                        {
                            // no records exist
                            verifypnl.Visible = true;
                            verifymsg.Text = @"Validation code was not correct, please try again or <a href=""javascript:OpenWindow('contact.aspx','ContactOvation')"">contact us</a> for assistance";
                        }
                    }

                }
            }
        }

        protected void UpdateRegTableIsVerified(string UpdateWithverifycode)
        {
            using (SqlConnection UpdateReg_Conn = new SqlConnection(constrVerifyReg))
            {
                using (SqlCommand UpdateReg_cmd = new SqlCommand("dbo.sp_RFP_RegUpdateVerified", UpdateReg_Conn))
                {
                    UpdateReg_cmd.CommandText = "dbo.sp_RFP_RegUpdateVerified";
                    UpdateReg_cmd.CommandType = CommandType.StoredProcedure;
                    UpdateReg_cmd.CommandTimeout = 0;

                    SqlParameter UpdateReg_Param = UpdateReg_cmd.CreateParameter();
                    UpdateReg_Param.ParameterName = "@szLinkToken";
                    UpdateReg_Param.Direction = ParameterDirection.Input;
                    UpdateReg_Param.SqlDbType = SqlDbType.NVarChar;
                    UpdateReg_Param.Value = UpdateWithverifycode;

                    UpdateReg_cmd.Parameters.Add(UpdateReg_Param);

                    UpdateReg_Conn.Open();

                    UpdateReg_cmd.ExecuteNonQuery();
                }
            }
        }

        protected void HotelClientLogin_LoginError(object sender, EventArgs e)
        {
            //There was a problem logging in the user

            //See if this user exists in the database
            MembershipUser userInfo = Membership.GetUser(HotelClientLogin.UserName);

            if (userInfo == null)
            {
                //The user entered an invalid username...
                verifypnl.Visible = false;
                FailureText.Visible = true;
                FailureText.Text = "Your login information is incorrect please try again.<br />";
            }
            else
            {
                //See if the user is locked out or not approved
                if (!userInfo.IsApproved)
                {
                    FailureText.Visible = true;
                    FailureText.Text = "An email has been sent to you with a link to verify your account. <br />Please check your email and click on the link provided so your account can be verified and approved.<br />";
                    verifypnl.Visible = false;
                }
                else if (userInfo.IsLockedOut)
                {
                    FailureText.Visible = true;
                    FailureText.Text = "Your account has been locked out because of a maximum number of incorrect login attempts. You will NOT be able to login until you contact a site administrator and have your account unlocked.<br />";
                    verifypnl.Visible = false;
                }
                //else if (Roles.IsUserInRole(userInfo.UserName, "Hotels") == false && userInfo.IsApproved == true)
                //{
                //    FailureText.Visible = true;
                //    FailureText.Text = "Somthing went wrong please contact us<br />";
                //    verifypnl.Visible = false;
                //}
                else
                {
                    //The password was incorrect (don't show anything, the Login control already describes the problem)
                    FailureText.Visible = true;
                    FailureText.Text = "Password not correct please try again<br />";
                    verifypnl.Visible = false;
                }
            }
        }

        protected void HotelClientLogin_LoggedIn(object sender, EventArgs e)
        {
            //if (Roles.IsUserInRole(HotelClientLogin.UserName, "Hotels"))
            //{
                // define varibles
                string OvationMembersName = string.Empty;
                string OvatonMHID = string.Empty;
                string OvationHID = string.Empty;
                //rfprevlink.Text = HttpUtility.HtmlEncode(EncryptMe(whatRFPID.Value, "OvaRFPKey"));


                MembershipUser userInfo = Membership.GetUser(HotelClientLogin.UserName);


                // open database
                using (SqlConnection Userloggin_Conn = new SqlConnection(constrVerifyReg))
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
                        Userloggin_Param.Value = userInfo.ToString();

                        Userloggin_cmd.Parameters.Add(Userloggin_Param);

                        Userloggin_Conn.Open();

                        using (SqlDataReader Userloggin_Reader = Userloggin_cmd.ExecuteReader())
                        {
                            if (Userloggin_Reader.Read())
                            {
                                //OvationMembersName = Userloggin_Reader["szRegisterName"].ToString();
                                //OvationMemName.Value = OvationMembersName;
                                //OvatonMHID = myID.Value;
                                //Session["seasonStart"] = Userloggin_Reader.GetInt32(Userloggin_Reader.GetOrdinal("lID"));
                                //MyIDTwo.Value = Userloggin_Reader.GetInt32(Userloggin_Reader.GetOrdinal("lID")).ToString();  //Session["seasonStart"].ToString();
                                //TheYear.Value = DateTime.Now.Year.ToString();

                                // check to see if ID is in AmmenRmseasons table if not insert one record
                                // insertseasonID((string)Session["seasonStart"]);
                                insertRFPID(Convert.ToInt32(Userloggin_Reader.GetInt32(Userloggin_Reader.GetOrdinal("lID")).ToString()));

                            }
                        }
                    }
                } // close up databse and release all resources

                //showID.Text = myID.Value;
                //HttpContext.Current.Response.Redirect("~/default.aspx?ORFP=63");

            //}

        }

        protected void insertRFPID(int UserID)
        {

            //Guid newRFPID = Guid.NewGuid();

            using (SqlConnection insertRFPID_Conn = new SqlConnection(constrVerifyReg))
            {

                // start cmd object
                using (SqlCommand insertRFPID_cmd = new SqlCommand("dbo.sp_RFP_InsertNewRFPID", insertRFPID_Conn))
                {
                    insertRFPID_cmd.CommandText = "dbo.sp_RFP_InsertNewRFPID";
                    insertRFPID_cmd.CommandType = CommandType.StoredProcedure;
                    insertRFPID_cmd.CommandTimeout = 0;

                    SqlParameter insertRFPID_Param = insertRFPID_cmd.CreateParameter();
                    insertRFPID_Param.ParameterName = "@LRegID";
                    insertRFPID_Param.Direction = ParameterDirection.Input;
                    insertRFPID_Param.SqlDbType = SqlDbType.Int;
                    insertRFPID_Param.Value = UserID;

                    insertRFPID_cmd.Parameters.Add(insertRFPID_Param);


                    insertRFPID_Param = insertRFPID_cmd.CreateParameter();
                    insertRFPID_Param.ParameterName = "@ReturnRFPID";
                    insertRFPID_Param.Direction = ParameterDirection.ReturnValue;
                    insertRFPID_Param.SqlDbType = SqlDbType.Int;

                    insertRFPID_cmd.Parameters.Add(insertRFPID_Param);

                    insertRFPID_Conn.Open();

                    // execute entry
                    insertRFPID_cmd.ExecuteNonQuery();

                    int NewRFPID = Convert.ToInt32(insertRFPID_cmd.Parameters["@ReturnRFPID"].Value);

                    // insert seaon to atleast have one on load
                    insertseasonID(NewRFPID); // this is the rfpID
                    insertHotelPartialOneID(NewRFPID);
                    insertPropertyID(NewRFPID);
                    insertContactID(NewRFPID);

                    //insertFPID(newRFPID.ToString());

                    // if new set to RFP ID
                    //Session["mynewRFP"] = NewRFPID.ToString();

                    HttpContext.Current.Response.Redirect("splash.aspx?ORFP=" + NewRFPID.ToString());
                    // "OvationNewRFP0987654321"
                    //whatRFPID.Value = NewRFPID.ToString();



                }

            }
            ////////////////////////////////////////////////////////////////return; ////////////////////////////////////////////////
            /////////////////////////// uncomment thsi for pre-population based on query string not to give them a blank RFP ///////
            //////////////////////////  and also may hace to be moved to default onpaload even /////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // open start db connection object
            // first check to see that we have an RFP ID
            //using (SqlConnection GetMyrfip_Conn = new SqlConnection(constrVerifyReg))
            //{
            //    using (SqlCommand GetMyrfip_cmd = new SqlCommand("dbo.sp_RFP_CheckRFPID", GetMyrfip_Conn))
            //    {
            //        GetMyrfip_cmd.CommandText = "dbo.sp_RFP_CheckRFPID";
            //        GetMyrfip_cmd.CommandType = CommandType.StoredProcedure;
            //        GetMyrfip_cmd.CommandTimeout = 0;

            //        SqlParameter GetMyrfip_Param = GetMyrfip_cmd.CreateParameter();
            //        GetMyrfip_Param.ParameterName = "@LRegID";
            //        GetMyrfip_Param.Direction = ParameterDirection.Input;
            //        GetMyrfip_Param.SqlDbType = SqlDbType.Int;
            //        GetMyrfip_Param.Value = UserID;

            //        GetMyrfip_cmd.Parameters.Add(GetMyrfip_Param);

            //        GetMyrfip_Conn.Open();

            //        using (SqlDataReader GetMyrfip_Reader = GetMyrfip_cmd.ExecuteReader())
            //        {
            //            // if reader does not read data then insert into table
            //            if (!GetMyrfip_Reader.Read()) // 
            //            {

            //                // open start db connection object
            //                // if not insert a new rfp ID
            //                using (SqlConnection insertRFPID_Conn = new SqlConnection(constrVerifyReg))
            //                {

            //                    // start cmd object
            //                    using (SqlCommand insertRFPID_cmd = new SqlCommand("dbo.sp_RFP_InsertNewRFPID", insertRFPID_Conn))
            //                    {
            //                        insertRFPID_cmd.CommandText = "dbo.sp_RFP_InsertNewRFPID";
            //                        insertRFPID_cmd.CommandType = CommandType.StoredProcedure;
            //                        insertRFPID_cmd.CommandTimeout = 0;

            //                        SqlParameter insertRFPID_Param = insertRFPID_cmd.CreateParameter();
            //                        insertRFPID_Param.ParameterName = "@LRegID";
            //                        insertRFPID_Param.Direction = ParameterDirection.Input;
            //                        insertRFPID_Param.SqlDbType = SqlDbType.Int;
            //                        insertRFPID_Param.Value = UserID;

            //                        insertRFPID_cmd.Parameters.Add(insertRFPID_Param);


            //                        insertRFPID_Param = insertRFPID_cmd.CreateParameter();
            //                        insertRFPID_Param.ParameterName = "@ReturnRFPID";
            //                        insertRFPID_Param.Direction = ParameterDirection.ReturnValue;
            //                        insertRFPID_Param.SqlDbType = SqlDbType.Int;

            //                        insertRFPID_cmd.Parameters.Add(insertRFPID_Param);

            //                        insertRFPID_Conn.Open();

            //                        // execute entry
            //                        insertRFPID_cmd.ExecuteNonQuery();

            //                        int NewRFPID = Convert.ToInt32(insertRFPID_cmd.Parameters["@ReturnRFPID"].Value);

            //                        // insert seaon to atleast have one on load
            //                        insertseasonID(NewRFPID); // this is the rfpID
            //                        insertHotelPartialOneID(NewRFPID);
            //                        insertPropertyID(NewRFPID);
            //                        insertContactID(NewRFPID);

            //                        //insertFPID(newRFPID.ToString());

            //                        // if new set to RFP ID
            //                        //whatRFPID.Value = NewRFPID.ToString();



            //                    }

            //                }
            //            }
            //            else
            //            {
            //                // we have an RFP set session to RFPID
            //                //whatRFPID.Value = GetMyrfip_Reader.GetInt32(GetMyrfip_Reader.GetOrdinal("LRFPID")).ToString();
            //                insertseasonID(GetMyrfip_Reader.GetInt32(GetMyrfip_Reader.GetOrdinal("LRFPID")));

            //            }


            //        }

            //    }
            //}////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }



        // sub to popuate season table with one season on new login
        protected void insertseasonID(int seasonID)
        {

            // open start db connection object
            using (SqlConnection insertseasonID_Conn = new SqlConnection(constrVerifyReg))
            {

                // start cmd object
                using (SqlCommand insertseasonID_cmd = new SqlCommand("dbo.sp_RFP_insertNewRMSeason", insertseasonID_Conn))
                {
                    insertseasonID_cmd.CommandText = "dbo.sp_RFP_insertNewRMSeason";
                    insertseasonID_cmd.CommandType = CommandType.StoredProcedure;
                    insertseasonID_cmd.CommandTimeout = 0;

                    SqlParameter insertseasonID_Param = insertseasonID_cmd.CreateParameter();
                    insertseasonID_Param.ParameterName = "@LRFPID";
                    insertseasonID_Param.Direction = ParameterDirection.Input;
                    insertseasonID_Param.SqlDbType = SqlDbType.Int;
                    insertseasonID_Param.Value = seasonID;

                    insertseasonID_cmd.Parameters.Add(insertseasonID_Param);

                    insertseasonID_Conn.Open();

                    // execute entry
                    insertseasonID_cmd.ExecuteNonQuery();

                }

            }
        }

        //// insert new hotel partial one row
        protected void insertHotelPartialOneID(int HotelPartialID)
        {
            // open start db connection object
            using (SqlConnection insertHotelPartialOneID_Conn = new SqlConnection(constrVerifyReg))
            {
                // start cmd object
                using (SqlCommand insertHotelPartialOneID_Conn_cmd = new SqlCommand("INSERT INTO dbo.Tbl_Hotel_PHC_HotelInfoPartialOne(LRFPID,szYear)VALUES(@LRFPID,@szYear)", insertHotelPartialOneID_Conn))
                {
                    insertHotelPartialOneID_Conn_cmd.CommandType = CommandType.Text;
                    insertHotelPartialOneID_Conn_cmd.CommandTimeout = 0;

                    insertHotelPartialOneID_Conn.Open();

                    insertHotelPartialOneID_Conn_cmd.Parameters.AddWithValue("@LRFPID", HotelPartialID);
                    insertHotelPartialOneID_Conn_cmd.Parameters.AddWithValue("@szYear", DateTime.Now.Year);
                    insertHotelPartialOneID_Conn_cmd.ExecuteNonQuery();

                }

            }
        }

        // insert new contact table row
        protected void insertContactID(int ContactID)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = 0;
            numIterations = rand.Next(500, 10000);
            //Response.Write(numIterations.ToString());

            // open start db connection object
            using (SqlConnection insertContactID_Conn = new SqlConnection(constrVerifyReg))
            {
                // start cmd object
                using (SqlCommand insertContactID_cmd = new SqlCommand("INSERT INTO dbo.Tbl_Hotel_PHC_Contacts(mhid,LRFPID,szYear)VALUES(@mhid,@LRFPID,@szYear)", insertContactID_Conn))
                {
                    insertContactID_cmd.CommandType = CommandType.Text;
                    insertContactID_cmd.CommandTimeout = 0;

                    insertContactID_Conn.Open();

                    insertContactID_cmd.Parameters.AddWithValue("@mhid", numIterations + ContactID);
                    insertContactID_cmd.Parameters.AddWithValue("@LRFPID", ContactID);
                    insertContactID_cmd.Parameters.AddWithValue("@szYear", DateTime.Now.Year);
                    insertContactID_cmd.ExecuteNonQuery();

                }

            }
        }

        // insert new property table row
        protected void insertPropertyID(int PropID)
        {
            //HttpContext.Current.Response.Write(PropID);
            Random rand_prop = new Random((int)DateTime.Now.Ticks);
            int numIterations_prop = 0;
            numIterations_prop = rand_prop.Next(500, 10000);

            //return;
            // open start db connection object
            using (SqlConnection insertProp_Conn = new SqlConnection(constrVerifyReg))
            {
                // start cmd object
                using (SqlCommand insertProp_cmd = new SqlCommand("INSERT INTO dbo.Tbl_Hotel_PHC_Property(mhid,LRFPID,szYear)VALUES(@mhid,@LRFPID,@szYear)", insertProp_Conn))
                {
                    insertProp_cmd.CommandType = CommandType.Text;
                    insertProp_cmd.CommandTimeout = 0;

                    insertProp_Conn.Open();

                    insertProp_cmd.Parameters.AddWithValue("@mhid", numIterations_prop + PropID);
                    insertProp_cmd.Parameters.AddWithValue("@LRFPID", PropID);
                    insertProp_cmd.Parameters.AddWithValue("@szYear", DateTime.Now.Year.ToString());
                    insertProp_cmd.ExecuteNonQuery();

                }

            }
        }

        //public string EncryptMe(string value, string key)
        //{

        //    MACTripleDES mac3des = new MACTripleDES();
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    mac3des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
        //    return Convert.ToBase64String(Encoding.UTF8.GetBytes(value)) + '-' + Convert.ToBase64String(mac3des.ComputeHash(Encoding.UTF8.GetBytes(value)));


        //}

    }
}
