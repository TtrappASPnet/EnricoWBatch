using System;
using Telerik.Web.UI;

namespace OvationTest
{
    public partial class _Default
    {
        protected void RatesAmenitiesNextBtn_Click(object sender, EventArgs e)
        {

            updateAmmeneites();

            //return;

            //progressTextHotelInfo.Text = "Hotel Information | Complete";
            // progressTextHotelInfo.ForeColor = System.Drawing.Color.Black;
            //progressbarAmmen.Text = "2014 Rates & Amenities | Complete";
            //progressbarAmmen.ForeColor = System.Drawing.Color.Black;

            //RadTab HotelInformationTab = OvationTabs.FindTabByValue("Hotel_Info");
            RadTab RatesAmenities_Tab = OvationTabs.FindTabByValue("Rates_Amenities");
            RadTab Marketing_pkgs_Tab = OvationTabs.FindTabByValue("Marketing_pkgs");

            // HotelInformationTab.Enabled = false;
            //RatesAmenities_Tab.Enabled = false;
            // Marketing_pkgs_Tab.Enabled = true;
            Marketing_pkgs_Tab.Selected = true;
            marketingPCKsView.Selected = true;

            HotelInfoCodeBlock.Visible = false;
            AmenitiesCodeBlock.Visible = false;
            //MktgCodeBlock.Visible = true;
            ElectronicSigCodeBlock.Visible = false;

        }

        protected void testnothing()
        {
            //int mymhid = 0;


            ////Page.Validate();

            ////Page.Validate("seasonRmCatVal");
            ////Page.Validate("seasonRmRateVal");

            ////if (Page.IsValid)
            ////{

            //    using (SqlConnection HotelInfo_PropertyUpdate_Conn = new SqlConnection(RFPDBconnStr))
            //    {
            //        using (SqlCommand HotelInfo_PropertyUpdate_cmd = new SqlCommand("dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo", HotelInfo_PropertyUpdate_Conn))
            //        {
            //            HotelInfo_PropertyUpdate_cmd.CommandText = "dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo";
            //            HotelInfo_PropertyUpdate_cmd.CommandType = CommandType.StoredProcedure;
            //            HotelInfo_PropertyUpdate_cmd.CommandTimeout = 0;

            //            // st param
            //            SqlParameter HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@LRFPID";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);

            //            // nd parem
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szDiscountOff";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = percentageRecieveOffRate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            // rd parem
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szLastRoomAvail";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Radiolist_Floating_Bar_Dynamic.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szVat";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_VatType.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szExtendGroupNegRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_WoulextendRateYN.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szConsortiaRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = ConsortaRate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szLowestConsortiaRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Consortia_floor_Low_Rate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szAverageConsortiaRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Consortia_average_mediaum_Rate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szHighestConsortiaRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Consortia_high_Rate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szCorpRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Corp_Rate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szRackRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Rack_Rate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szAsscociationRate";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Assoc_Rate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szRecruitRatesSeptDec";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Ovation_Recruitment_Rate.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szAmenitiesIncluded";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Amenities_Offered_to_Ovation.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szIsPropVirtuosoMem";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_IsProperty_Virtuoso.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szIsVirtuosoAmmenInc";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_IsVirtuoso_included.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szVirtuosoAmmen";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Ammenities_VirtuosoAmenity.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szEnsureAmenty";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Ammenities_ensureClient_VirtuosoAmenity.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szItinGuestRoomInc";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = internet_Access_inc_NegRate_GuestRoom.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szITinPublicSpaceInc";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = internet_Access_inc_NegRate_publicspace.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szToiletries";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Amenities_WhatBrandFor_GuestRoom_Bathroom.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szRestaurant";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Amenites_property_resturants_names.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szBarLounge";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Amenites_property_Bar_Lounge_names.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szRenovations";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Amenites_property_renovation_2014.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szRenovationsDesc";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Amenites_property_renovationDates_details.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szRoomCnt";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Ammenities_Num_roomshotel.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szSuiteCnt";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Ammenities_Num_suiteshotel.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szGuaranteeNotToWalkOurGuests";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Amenities_noToWalk.SelectedValue.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



            //            //th param
            //            HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
            //            HotelInfo_PropertyUpdate_Param.ParameterName = "@szHotelGrpAffiliation";
            //            HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
            //            HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
            //            HotelInfo_PropertyUpdate_Param.Value = Aemnites_Affilation_Details.Text.ToString();

            //            HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


            //            HotelInfo_PropertyUpdate_Conn.Open();

            //            HotelInfo_PropertyUpdate_cmd.ExecuteNonQuery();

            //        }

            //        // first get mhid
            //        using (SqlCommand HotelInfo_PropertyGetmhid_cmd = new SqlCommand("SELECT mhid from dbo.Tbl_Hotel_PHC_Property WHERE LRFPID = @LRFPID", HotelInfo_PropertyUpdate_Conn))
            //        {
            //            HotelInfo_PropertyGetmhid_cmd.CommandType = CommandType.Text;
            //            HotelInfo_PropertyGetmhid_cmd.CommandTimeout = 0;

            //            HotelInfo_PropertyGetmhid_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

            //            using (SqlDataReader GetMymhid_Reader = HotelInfo_PropertyGetmhid_cmd.ExecuteReader())
            //            {
            //                if (GetMymhid_Reader.Read())
            //                {
            //                    mymhid = GetMymhid_Reader.GetInt32(GetMymhid_Reader.GetOrdinal("mhid"));
            //                }
            //            }
            //        }
            //    }

            //    using (SqlConnection FeaturesPropertyIjnsert_Conn = new SqlConnection(RFPDBconnStr))
            //    {

            //        FeaturesPropertyIjnsert_Conn.Open();

            //        // delete so we can start over like an update
            //        using (SqlCommand FeaturesPropertyIjnsert_cmd = new SqlCommand("DELETE FROM dbo.tbl_Hotel_PHC_Features_Property WHERE LRFPID = @LRFPID", FeaturesPropertyIjnsert_Conn))
            //        {
            //            //FeaturesPropertyIjnsert_cmd.CommandText = "dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo";
            //            FeaturesPropertyIjnsert_cmd.CommandType = CommandType.Text;
            //            FeaturesPropertyIjnsert_cmd.CommandTimeout = 0;

            //            //FeaturesPropertyIjnsert_Conn.Open();

            //            /// radio button no smoking
            //            FeaturesPropertyIjnsert_cmd.Parameters.Clear();
            //            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
            //            FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
            //        }

            //        // return;

            //        // insert in Features Property table ///
            //        using (SqlCommand FeaturesPropertyIjnsert_cmd = new SqlCommand("INSERT INTO dbo.tbl_Hotel_PHC_Features_Property(mhid,LRFPID,szYear,lFeatureID)VALUES(@mhid,@LRFPID,@szYear,@lFeatureID)", FeaturesPropertyIjnsert_Conn))
            //        {
            //            //FeaturesPropertyIjnsert_cmd.CommandText = "dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo";
            //            FeaturesPropertyIjnsert_cmd.CommandType = CommandType.Text;
            //            FeaturesPropertyIjnsert_cmd.CommandTimeout = 0;

            //            foreach (ListItem feature in Amenities_Property_offering.Items)
            //            {
            //                if (feature.Selected)
            //                {
            //                    // do inset
            //                    // first check box list
            //                    FeaturesPropertyIjnsert_cmd.Parameters.Clear();
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@mhid", mymhid);
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@szYear", TheYear.Value.ToString());
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@lFeatureID", feature.Value);
            //                    FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
            //                }


            //            }
            //            foreach (ListItem featureEquip in Amenities_Rooms_Equipped_With.Items)
            //            {
            //                if (featureEquip.Selected)
            //                {
            //                    // second check box list
            //                    FeaturesPropertyIjnsert_cmd.Parameters.Clear();
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@mhid", mymhid);
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@szYear", TheYear.Value.ToString());
            //                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@lFeatureID", featureEquip.Value);
            //                    FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
            //                }

            //            }

            //            /// radio button no smoking
            //            FeaturesPropertyIjnsert_cmd.Parameters.Clear();
            //            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@mhid", mymhid);
            //            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
            //            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@szYear", TheYear.Value.ToString());
            //            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@lFeatureID", Amenites_property_non_smoking.SelectedValue);
            //            FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
            //        }
            //    }
        }
    }
}
