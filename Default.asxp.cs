using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace OvationTest
{
    public partial class _Default : System.Web.UI.Page
    {
        // find the rest of the code this works with in tabclicks.cs
        public string Season { get; set; }
        public string RatesEndDate { get; set; }
        public string RatesRmCategory { get; set; }
        public string RatesRates { get; set; }
        public string Cuurency { get; set; }


        // global database connection strings
        string RFPDBconnStr = System.Configuration.ConfigurationManager.ConnectionStrings["OvationBetaDB"].ConnectionString;
        string myquery = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            startDefault();
            Hotel_brief_descipt.Attributes.Add("Onkeypress", "return check_content();");
            Sabre_PCode.Attributes.Add("onkeydown", "javascript:return jsNumbers_SabreP(event);");
            Apollo_Pcode.Attributes.Add("onkeydown", "javascript:return jsNumbers_ApolloP(event);");
            Sabre_Chain_Code.Attributes.Add("onkeypress", "javascript:return SabreChainlettersOnly(event);");
            Apollo_Chain_Code.Attributes.Add("onkeypress", "javascript:return ApolloChainlettersOnly(event);");

        }


        protected void startDefault()
        {
            // uncomment this line to test decryption HttpContext.Current.Response.Write(Decrypt(myquery));

            myquery = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

            var Num = 0;
            bool isNum = int.TryParse(myquery.ToString(), out Num);

            formstatusBarContainer.Visible = false;

            // see if querystring is valid
            if (myquery.Length > 0 && isNum == true)
            {

                string Submitted = string.Empty;

                using (SqlConnection checkSubmit_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand checkSubmit_cmd = new SqlCommand("dbo.sp_RFP_GetIfRFPSubmiited", checkSubmit_Conn))
                    {
                        checkSubmit_cmd.CommandText = "dbo.sp_RFP_GetIfRFPSubmiited";
                        checkSubmit_cmd.CommandType = CommandType.StoredProcedure;
                        checkSubmit_cmd.CommandTimeout = 0;

                        checkSubmit_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation"));

                        checkSubmit_Conn.Open();


                        // check to see if RFP was submitted //
                        using (SqlDataReader checkSubmit_Reader = checkSubmit_cmd.ExecuteReader())
                        {

                            if (checkSubmit_Reader.Read())
                            {

                                Submitted = checkSubmit_Reader["blnIsSubmitted"].ToString();

                            }

                        }
                    }

                }

                // if it was then show user altenate message
                if (Submitted == "true")
                {

                    OvationTabs.Visible = false;
                    OvationMultiPage.Visible = false;

                    alreadysubmitted.Text = @"The RFP was already submitted, if you would like to fill out another one please <a href=""http://dev.ovationtravel.com/OvationRFP"">click here to do</a>";

                    return;

                }

                OvationTabs.Visible = true;
                OvationMultiPage.Visible = true;
                RFPqueryError.Visible = false;
                // define varibles
                string OvationMembersName = string.Empty;
                string OvatonMHID = string.Empty;
                string OvationHID = string.Empty;
                string CountrySelected = string.Empty;

                TheYear.Value = DateTime.Now.Year.ToString();
                whatRFPID.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation");
                logo_left.NavigateUrl = "#";
                //selectHotelInfo();
                LinktoHelpOne.NavigateUrl = string.Empty;
                LinktoHelpTwo.NavigateUrl = string.Empty;
                LinktoHelpThree.NavigateUrl = string.Empty;
                LinktoHelpOne.Attributes.Add("OnClick", "javascript:open_win();");
                LinktoHelpTwo.Attributes.Add("OnClick", "javascript:open_win();");
                LinktoHelpThree.Attributes.Add("OnClick", "javascript:open_win();");


                using (SqlConnection GetSelectedCountry_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand GetSelectedCountry_cmd = new SqlCommand("dbo.sp_RFP_GetCountryOnLOad", GetSelectedCountry_Conn))
                    {
                        GetSelectedCountry_cmd.CommandText = "dbo.sp_RFP_GetCountryOnLOad";
                        GetSelectedCountry_cmd.CommandType = CommandType.StoredProcedure;
                        GetSelectedCountry_cmd.CommandTimeout = 0;

                        GetSelectedCountry_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                        GetSelectedCountry_Conn.Open();

                        using (SqlDataReader GetSelectedCountry_Reader = GetSelectedCountry_cmd.ExecuteReader())
                        {
                            if (GetSelectedCountry_Reader.Read())
                            {
                                CountrySelected = GetSelectedCountry_Reader["szCountry"].ToString();
                            }
                        }
                    }

                }

                if (this.IsPostBack == false)
                {
                    Hotelcountry.SelectedValue = CountrySelected.ToString();
                    //ViewState["hName"] = Hotel_Name.Text;
                    ///Hotel_Name.Text = ViewState["hName"].ToString();
                }

                //MembershipUser userInfo = Membership.GetUser(Page.User.Identity.Name);

                //// open database
                //using (SqlConnection Userloggin_Conn = new SqlConnection(RFPDBconnStr))
                //{
                //    using (SqlCommand Userloggin_cmd = new SqlCommand("dbo.sp_RFP_GetNameofUserID", Userloggin_Conn))
                //    {
                //        Userloggin_cmd.CommandText = "dbo.sp_RFP_GetNameofUserID";
                //        Userloggin_cmd.CommandType = CommandType.StoredProcedure;
                //        Userloggin_cmd.CommandTimeout = 0;

                //        SqlParameter Userloggin_Param = Userloggin_cmd.CreateParameter();
                //        Userloggin_Param.ParameterName = "@szRegisterEmail";
                //        Userloggin_Param.Direction = ParameterDirection.Input;
                //        Userloggin_Param.SqlDbType = SqlDbType.NVarChar;
                //        Userloggin_Param.Value = userInfo.ToString();

                //        Userloggin_cmd.Parameters.Add(Userloggin_Param);

                //        Userloggin_Conn.Open();

                //        using (SqlDataReader Userloggin_Reader = Userloggin_cmd.ExecuteReader())
                //        {
                //            if (Userloggin_Reader.Read())
                //            {
                //                //OvationMembersName = Userloggin_Reader["szRegisterName"].ToString();
                //                //OvationMemName.Value = OvationMembersName;
                //                //OvatonMHID = myID.Value;
                //               // MyIDTwo.Value = Userloggin_Reader.GetInt32(Userloggin_Reader.GetOrdinal("lID")).ToString();  //Session["seasonStart"].ToString();

                //                //this.OvationLogWelcome.Visible = false;
                //                //this.welcomeName.Text = Userloggin_Reader["szRegisterName"].ToString(); ;

                //            }
                //        }
                //    }
                //} // close up databse and release all resources

                //showID.Text = myID.Value;


            }
            else
            {
                //throw new ArgumentException("Invalid query string");
                OvationTabs.Visible = false;
                OvationMultiPage.Visible = false;
                RFPqueryError.Visible = true;
                this.logo_left.NavigateUrl = "#";
                //HttpContext.Current.Response.Write("That RFP Does not exist");

            }

        }


        //protected void LoginStatus_top_LoggedOut(object sender, EventArgs e)
        //{
        //    // HiddenField therfpidField = this.Parent.FindControl("whatRFPID") as HiddenField;
        //    // therfpidField.Value = string.Empty;
        //    // Session.Clear();//clear session
        //    // Session.Abandon();//Abandon session
        //    // Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        //    // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    // Response.Cache.SetNoStore();
        //    FormsAuthentication.SignOut();
        //    //FormsAuthentication.RedirectToLoginPage();

        //    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Cache.SetNoStore();
        //    HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
        //}


        protected void RadioButtonList_IsVirtuoso_included_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (RadioButtonList_IsVirtuoso_included.SelectedValue.ToString() == "No")
            {
                whatisVirtuosoamenity_Pnl.Visible = false;

                Ammenities_ensurePnl.Visible = false;

            }
            else if (RadioButtonList_IsVirtuoso_included.SelectedValue.ToString() == "Yes")
            {
                whatisVirtuosoamenity_Pnl.Visible = true;
                Ammenities_ensurePnl.Visible = true;
            }
        }

        protected void Amenites_property_renovation_2014_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Amenites_property_renovation_2014.SelectedValue.ToString() == "No")
            {
                renovationDates_detailsPnl.Visible = false;
            }
            else if (Amenites_property_renovation_2014.SelectedValue.ToString() == "Yes")
            {

                renovationDates_detailsPnl.Visible = true;
            }
        }

        // MARKETING PACKS CUSTOM VALIDATOR FOR RADIO BUTTONS PACKAGE
        protected void Package_CstmVal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = platinum_Package.Checked || gold_Package.Checked || silver_Package.Checked;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ----------------------------------------------- start ----------------------------------------------------
        /////////////  rates section for ammenties section, this includes all functions //////////////////////////////
        // rates block here which controls the rates section in ammenites
        // ////////////////////////////////////////////////////////////
        /////////////  rates section for ammenties section, this includes all functions //////////////////////////////
        // ----------------------------------------------- end ----------------------------------------------------
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // decript of querystring method /////////////////////////////////////////////////////////////////////
        public string Decrypt(string value, string key)
        {
            string dataValue = "";
            string calcHash = "";
            string storedHash = "";

            MACTripleDES mac3des = new MACTripleDES();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            mac3des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));

            try
            {

                dataValue = Encoding.UTF8.GetString(Convert.FromBase64String(value.Split('-')[0]));
                storedHash = Encoding.UTF8.GetString(Convert.FromBase64String(value.Split('-')[1]));
                calcHash = Encoding.UTF8.GetString(mac3des.ComputeHash(Encoding.UTF8.GetBytes(dataValue)));

                if (storedHash != calcHash)
                {
                    //Data was corrupted

                    //throw new ArgumentException("Hash value does not match");
                    //This error is immediately caught below
                    OvationTabs.Visible = false;
                    OvationMultiPage.Visible = false;
                    RFPqueryError.Visible = true;
                }
            }
            catch (Exception ex)
            {

                //dataValue = "0";
                //throw new ArgumentException("Invalid query string");

                OvationTabs.Visible = false;
                OvationMultiPage.Visible = false;
                RFPqueryError.Visible = true;



            }

            return dataValue;

        }


    }
}
