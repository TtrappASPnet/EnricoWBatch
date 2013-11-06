using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OvationTest
{
    public partial class splash : System.Web.UI.Page
    {
         // declare class varibles
        // global database connection strings
        string constrVerifyReg = System.Configuration.ConfigurationManager.ConnectionStrings["OvationBetaDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                insertRFPID(System.Guid.NewGuid().ToString());
            }


            LinktoHelpOne.Attributes.Add("OnClick", "javascript:open_win();");

        }


        protected void insertRFPID(string UserID)
        {

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
                    insertRFPID_Param.SqlDbType = SqlDbType.VarChar;
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

                    TheRFPID.Value = NewRFPID.ToString();

                    // insert seaon to atleast have one on load
                    insertseasonID(NewRFPID); // this is the rfpID
                    insertHotelPartialOneID(NewRFPID);
                    insertPropertyID(NewRFPID);
                    insertContactID(NewRFPID);



                }

            }



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

            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            // open start db connection object
            using (SqlConnection insertContactID_Conn = new SqlConnection(constrVerifyReg))
            {
                // start cmd object
                using (SqlCommand insertContactID_cmd = new SqlCommand("INSERT INTO dbo.Tbl_Hotel_PHC_Contacts(mhid,LRFPID,szYear)VALUES(@mhid,@LRFPID,@szYear)", insertContactID_Conn))
                {
                    insertContactID_cmd.CommandType = CommandType.Text;
                    insertContactID_cmd.CommandTimeout = 0;

                    insertContactID_Conn.Open();

                    insertContactID_cmd.Parameters.AddWithValue("@mhid", number);
                    insertContactID_cmd.Parameters.AddWithValue("@LRFPID", ContactID);
                    insertContactID_cmd.Parameters.AddWithValue("@szYear", DateTime.Now.Year);
                    insertContactID_cmd.ExecuteNonQuery();

                }

            }
        }

        // insert new property table row
        protected void insertPropertyID(int PropID)
        {

            string numberTwo = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

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

                    insertProp_cmd.Parameters.AddWithValue("@mhid", numberTwo);
                    insertProp_cmd.Parameters.AddWithValue("@LRFPID", PropID);
                    insertProp_cmd.Parameters.AddWithValue("@szYear", DateTime.Now.Year.ToString());
                    insertProp_cmd.ExecuteNonQuery();

                }

            }
        }

        protected void HotelInfoNextBtn_Click(object sender, EventArgs e)
        {

            HttpContext.Current.Response.Redirect("Default.aspx?ORFP=" + HttpUtility.UrlEncode(EcyptDecyptQueryStr.Encrypt(TheRFPID.Value.ToString(), "trappOvation")));
        }

    }


}
