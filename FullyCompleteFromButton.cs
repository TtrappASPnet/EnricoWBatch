using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Web;
using System.Collections;

namespace OvationTest
{
    public partial class _Default
    {
        protected void agreeServerVal(object source, ServerValidateEventArgs args)
        {
            args.IsValid = agreeTerms.Checked;
        }

        protected void FromFullyCompleteBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CompleteFrom.Selected = true;
                finishedRFP.Visible = true;
                WincloseCodeBlock.Visible = false;

                using (SqlConnection ElectronicSig_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand ElectronicSig_cmd = new SqlCommand("UPDATE dbo.Tbl_Hotel_PHC_HotelInfoPartialOne SET szElectronicSig = @szElectronicSig, szElectronicSigCmt = @szElectronicSigCmt WHERE LRFPID = @LRFPID", ElectronicSig_Conn))
                    {
                        ElectronicSig_cmd.CommandType = CommandType.Text;
                        ElectronicSig_cmd.CommandTimeout = 0;

                        ElectronicSig_Conn.Open();

                        ElectronicSig_cmd.Parameters.AddWithValue("@LRFPID", whatRFPID.Value.ToString());
                        ElectronicSig_cmd.Parameters.AddWithValue("@szElectronicSig", Electronic_Sig_title.Text.ToString());
                        ElectronicSig_cmd.Parameters.AddWithValue("@szElectronicSigCmt", Electronic_Sig_comments.Text.ToString());
                        ElectronicSig_cmd.ExecuteNonQuery();
                    }

                }


                //progressBarTxtElectronicSig.Text = "Electronic Signiture | Complete";
                //progressBarTxtElectronicSig.ForeColor = System.Drawing.Color.Black;
          
                //progressBarTxtRFPForm.Text = "2014 RFP | Complete";
                //progressBarTxtRFPForm.ForeColor = System.Drawing.Color.Black;
               // RadTab startHere_Tab = OvationTabs.FindTabByValue("2014RFPform");
               // startHere_Tab.Visible = true;

                //memnameCompleted.Text = "<strong>" + OvationMemName.Value.ToString() + "</strong>";

                //MembershipUser userInfo = Membership.GetUser(Page.User.Identity.Name);

                // Declare some strings //////////////////////////////////////////////////////////////
                string SabrePCode = string.Empty;
                string SalesContactName = string.Empty;
                string SabreChainCode = string.Empty;
                string SalesContactTitle = string.Empty;
                string ApolloPcode = string.Empty;
                string SalesContactTelephone = string.Empty;
                string ApolloChainCode = string.Empty;
                string SalesContactFax = string.Empty;
                string HotelName = string.Empty;
                string SalesContactEmail = string.Empty;
                string HotelAddrOne = string.Empty;
                string Hotelgeneralmgr = string.Empty;
                string HotelAddrTwo = string.Empty;
                string DirectorofSales = string.Empty;
                string Hotelcity = string.Empty;
                string HotelWebSite = string.Empty;
                string HotelInfoStateStr = string.Empty;
                string HotelcountryStr = string.Empty;
                string Hotelzippostcode = string.Empty;
                string HotelMainphone = string.Empty;
                string AAAatingStr = string.Empty;
                string MobileStaRateStr = string.Empty;
                string Hotelbriefdescipt = string.Empty;
                string EnviromentProgram = string.Empty;
                string avtiveRecycle = string.Empty;
                string Property_Responsible_Cleaners = string.Empty;
                string Property_WaterConserve = string.Empty;
                string percentage = string.Empty;
                string Floating_Bar_Dynamic = string.Empty;
                string AmmenRatesComment = string.Empty;
                string VatType = string.Empty;
                string WoulextendRateYN = string.Empty;
                string ConRat = string.Empty;
                string ConfloorLowRate = string.Empty;
                string ConaverageRate = string.Empty;
                string ConhighRate = string.Empty;
                string CorpRate = string.Empty;
                string RackRate = string.Empty;
                string AssocRate = string.Empty;
                string RecruitmentRate = string.Empty;
                string AmenitiesOffered = string.Empty;
                string IsProperty_Virtuoso = string.Empty;
                string IsVirtuoso_included = string.Empty;
                string VirtuosoAmenity = string.Empty;
                string ensureClientVirtuosoAmenity = string.Empty;
                string internetGuestRoom = string.Empty;
                string internetpublicspace = string.Empty;
                string AmenitiesBathroom = string.Empty;
                string Amenitesresturants = string.Empty;
                string AmenitesBarLounge = string.Empty;
                string AmenProPNoSmokeYN = string.Empty;
                string propertyrenovation2014 = string.Empty;
                string propertyrenovationDates_details = string.Empty;
                string Num_roomshotel = string.Empty;
                string Num_suiteshotel = string.Empty;
                string noToWalk = string.Empty;
                string AffilationDetails = string.Empty;
                string whatMarketPack = string.Empty;
                string Sigtitle = string.Empty;
                string SigComments = string.Empty;

                using (SqlConnection RFPreview_Conn = new SqlConnection(RFPDBconnStr))
                {

                    using (SqlCommand RFPreview_cmd = new SqlCommand("dbo.sp_RFP_GetRFPreviewbyID", RFPreview_Conn))
                    {

                        RFPreview_cmd.CommandText = "dbo.sp_RFP_GetRFPreviewbyID";
                        RFPreview_cmd.CommandType = CommandType.StoredProcedure;
                        RFPreview_cmd.CommandTimeout = 0;

                        SqlParameter RFPreview_Param = RFPreview_cmd.CreateParameter();
                        RFPreview_Param.ParameterName = "@LRFPID";
                        RFPreview_Param.Direction = ParameterDirection.Input;
                        RFPreview_Param.SqlDbType = SqlDbType.Int;
                        RFPreview_Param.Value = whatRFPID.Value.ToString();

                        RFPreview_cmd.Parameters.Add(RFPreview_Param);

                        RFPreview_Conn.Open();

                        using (SqlDataReader RFPreview_Reader = RFPreview_cmd.ExecuteReader())
                        {
                            if (RFPreview_Reader.Read())
                            {
                                SabrePCode = RFPreview_Reader["szSabrePropertyNo"].ToString();
                                SalesContactName = RFPreview_Reader["szName"].ToString();
                                SabreChainCode = RFPreview_Reader["szSabreChainCode"].ToString();
                                SalesContactTitle = RFPreview_Reader["szTitle"].ToString();
                                ApolloPcode = RFPreview_Reader["szApolloPropertyNo"].ToString();
                                SalesContactTelephone = RFPreview_Reader["szPhone"].ToString();
                                ApolloChainCode = RFPreview_Reader["szApolloChainCode"].ToString();
                                SalesContactFax = RFPreview_Reader["szFax"].ToString();
                                HotelName = RFPreview_Reader["szPrefHotelName"].ToString();
                                SalesContactEmail = RFPreview_Reader["szEmail"].ToString();
                                HotelAddrOne = RFPreview_Reader["szAddress"].ToString();
                                Hotelgeneralmgr = RFPreview_Reader["szGeneralMgr"].ToString();
                                HotelAddrTwo = RFPreview_Reader["szAddressTwo"].ToString();
                                DirectorofSales = RFPreview_Reader["szDirectorOfSales"].ToString();
                                Hotelcity = RFPreview_Reader["szCity"].ToString();
                                HotelWebSite = RFPreview_Reader["szWebSite"].ToString();
                                HotelInfoStateStr = RFPreview_Reader["szState"].ToString();
                                HotelcountryStr = RFPreview_Reader["szCountry"].ToString();
                                Hotelzippostcode = RFPreview_Reader["szZipCode"].ToString();
                                HotelMainphone = RFPreview_Reader["szHotelPhone"].ToString();
                                AAAatingStr = RFPreview_Reader["szDiamondRating"].ToString();
                                MobileStaRateStr = RFPreview_Reader["szStarRating"].ToString();
                                Hotelbriefdescipt = RFPreview_Reader["szHotelDesc"].ToString();
                                EnviromentProgram = RFPreview_Reader["szEnvCertPrg"].ToString();

                                //////////// RecyclingPrg
                                if (RFPreview_Reader["szRecyclingPrg"].ToString() == string.Empty)
                                {
                                    avtiveRecycle = string.Empty;
                                }
                                else if (RFPreview_Reader["szRecyclingPrg"].ToString() == "Y")
                                {
                                    avtiveRecycle = "Yes";
                                }
                                else if (RFPreview_Reader["szRecyclingPrg"].ToString() == "N")
                                {
                                    avtiveRecycle = "No";
                                }

                                ////////////////////// EnvRespCleaners
                                if (RFPreview_Reader["szUtilEnvRespCleaners"].ToString() == string.Empty)
                                {
                                    Property_Responsible_Cleaners = string.Empty;
                                }
                                else if (RFPreview_Reader["szUtilEnvRespCleaners"].ToString() == "Y")
                                {
                                    Property_Responsible_Cleaners = "Yes";
                                }
                                else if (RFPreview_Reader["szUtilEnvRespCleaners"].ToString() == "N")
                                {
                                    Property_Responsible_Cleaners = "No";
                                }

                                /////////////////////////// ActiveWaterCnsvPrg
                                if (RFPreview_Reader["szActiveWaterCnsvPrg"].ToString() == string.Empty)
                                {
                                    Property_WaterConserve = string.Empty;
                                }
                                else if (RFPreview_Reader["szActiveWaterCnsvPrg"].ToString() == "Y")
                                {
                                    Property_WaterConserve = "Yes";
                                }
                                else if (RFPreview_Reader["szActiveWaterCnsvPrg"].ToString() == "N")
                                {
                                    Property_WaterConserve = "No";
                                }
                                ////////////////////////////////////////////////////////////////////////

                                percentage = RFPreview_Reader["szDiscountOff"].ToString();

                                // LRA or LA
                                if (string.IsNullOrEmpty(RFPreview_Reader["szLastRoomAvail"].ToString()))
                                {
                                    Floating_Bar_Dynamic = string.Empty;
                                }
                                else if (RFPreview_Reader["szLastRoomAvail"].ToString() == "Y")
                                {
                                    Floating_Bar_Dynamic = "Yes";
                                }
                                else
                                {
                                    Floating_Bar_Dynamic = "No";
                                }

                                AmmenRatesComment = RFPreview_Reader["szAddCmtnsRats"].ToString();

                                // vat type ////////////////////////////////////////////////////////////
                                if (string.IsNullOrEmpty(RFPreview_Reader["szVat"].ToString()))
                                {
                                    VatType = string.Empty;
                                }
                                else if (RFPreview_Reader["szVat"].ToString() == "Y")
                                {
                                    VatType = "Yes";
                                }
                                else
                                {
                                    VatType = "No";
                                }

                                //////////////////////// ExtendGroupNegRate
                                if (RFPreview_Reader["szExtendGroupNegRate"].ToString() == string.Empty)
                                {
                                    WoulextendRateYN = string.Empty;
                                }
                                else if (RFPreview_Reader["szExtendGroupNegRate"].ToString() == "Y")
                                {
                                    WoulextendRateYN = "Yes";
                                }
                                else
                                {
                                    WoulextendRateYN = "No";

                                }

                                ConRat = RFPreview_Reader["szConsortiaRate"].ToString();
                                ConfloorLowRate = RFPreview_Reader["szLowestConsortiaRate"].ToString();
                                ConaverageRate = RFPreview_Reader["szAverageConsortiaRate"].ToString();
                                ConhighRate = RFPreview_Reader["szHighestConsortiaRate"].ToString();
                                CorpRate = RFPreview_Reader["szCorpRate"].ToString();
                                RackRate = RFPreview_Reader["szRackRate"].ToString();
                                AssocRate = RFPreview_Reader["szAsscociationRate"].ToString();
                                RecruitmentRate = RFPreview_Reader["szRecruitRatesSeptDec"].ToString();
                                AmenitiesOffered= RFPreview_Reader["szAmenitiesIncluded"].ToString();


                                // IsPropVirtuosoMem RBL /////////////////////////////////////////////////////
                                if (RFPreview_Reader["szIsPropVirtuosoMem"].ToString() == string.Empty)
                                {
                                    IsProperty_Virtuoso = string.Empty;
                                }
                                else if (RFPreview_Reader["szIsPropVirtuosoMem"].ToString() == "Y")
                                {
                                    IsProperty_Virtuoso = "Yes";
                                }
                                else if (RFPreview_Reader["szIsPropVirtuosoMem"].ToString() == "N")
                                {
                                    IsProperty_Virtuoso = "No";
                                }

                                //////////////////////////////////////////////////////////////////////////////
                                // IsVirtuosoAmmenInc RBL ////////////////////////////////////////////////////
                                if (RFPreview_Reader["szIsVirtuosoAmmenInc"].ToString() == string.Empty)
                                {
                                    IsVirtuoso_included = string.Empty;
                                    VirtuosoAmenity = RFPreview_Reader["szVirtuosoAmmen"].ToString();
                                    ensureClientVirtuosoAmenity = RFPreview_Reader["szEnsureAmenty"].ToString();
                                }
                                else if (RFPreview_Reader["szIsVirtuosoAmmenInc"].ToString() == "Y")
                                {
                                    IsVirtuoso_included = "Yes";
                                    VirtuosoAmenity = RFPreview_Reader["szVirtuosoAmmen"].ToString();
                                    ensureClientVirtuosoAmenity = RFPreview_Reader["szEnsureAmenty"].ToString();

                                }
                                else if (RFPreview_Reader["szIsVirtuosoAmmenInc"].ToString() == "N")
                                {
                                    IsVirtuoso_included = "No";
                                    VirtuosoAmenity = RFPreview_Reader["szVirtuosoAmmen"].ToString();
                                    ensureClientVirtuosoAmenity = RFPreview_Reader["szEnsureAmenty"].ToString();
                                }

                                ///////////////////////////////////////////////////////////////////////////////////////
                                ///////////////////////////////  internet in guest room////////////////////////////////
                                if (RFPreview_Reader["szItinGuestRoomInc"].ToString() == string.Empty)
                                {
                                    internetGuestRoom = string.Empty;

                                }
                                else if (RFPreview_Reader["szItinGuestRoomInc"].ToString() == "Y")
                                {
                                    internetGuestRoom = "Yes";
                                }
                                else if (RFPreview_Reader["szItinGuestRoomInc"].ToString() == "N")
                                {
                                    internetGuestRoom = "No";
                                }

                                //////////////////////////////////////////////////////////////////////////////////////////
                                //////////////////////////////// internet in public space/////////////////////////////////
                                if (RFPreview_Reader["szITinPublicSpaceInc"].ToString() == string.Empty)
                                {
                                    internetpublicspace = string.Empty;
                                }
                                else if (RFPreview_Reader["szITinPublicSpaceInc"].ToString() == "Y")
                                {
                                    internetpublicspace = "Yes";
                                }
                                else if (RFPreview_Reader["szITinPublicSpaceInc"].ToString() == "N")
                                {
                                    internetpublicspace = "No";
                                }
                                //////////////////////////////////////////////////////////////////////////////////////////

                                AmenitiesBathroom = RFPreview_Reader["szToiletries"].ToString();
                                Amenitesresturants = RFPreview_Reader["szRestaurant"].ToString();
                                AmenitesBarLounge = RFPreview_Reader["szBarLounge"].ToString();
                                
                                //////////////////////////////////////////////////////////////////////////////////////////
                                //////////////////////////// property renovations ////////////////////////////////////////
                                if (RFPreview_Reader["szRenovations"].ToString() == string.Empty)
                                {
                                    propertyrenovation2014 = string.Empty;
                                    propertyrenovationDates_details = RFPreview_Reader["szRenovationsDesc"].ToString();
                                }
                                else if (RFPreview_Reader["szRenovations"].ToString() == "Y")
                                {
                                    propertyrenovation2014 = "Yes";
                                    propertyrenovationDates_details = RFPreview_Reader["szRenovationsDesc"].ToString();

                                }
                                else if (RFPreview_Reader["szRenovations"].ToString() == "N")
                                {
                                    propertyrenovation2014 = "No";
                                    propertyrenovationDates_details = RFPreview_Reader["szRenovationsDesc"].ToString();
                                }
                                ////////////////////////////////////////////////////////////////////////////////////////

                                Num_roomshotel = RFPreview_Reader["szRoomCnt"].ToString();
                                Num_suiteshotel = RFPreview_Reader["szSuiteCnt"].ToString();

                                ////////////////////////////////////////////////////////////////////////////////////////
                                ////////////////////////// GuaranteeNotToWalkOurGuests RBL /////////////////////////////
                                if (RFPreview_Reader["szGuaranteeNotToWalkOurGuests"].ToString() == string.Empty)
                                {
                                    noToWalk = string.Empty;
                                }
                                else if (RFPreview_Reader["szGuaranteeNotToWalkOurGuests"].ToString() == "Y")
                                {
                                    noToWalk = "Yes";
                                }
                                else if (RFPreview_Reader["szGuaranteeNotToWalkOurGuests"].ToString() == "N")
                                {
                                    noToWalk = "No";
                                }
                                
                                ////////////////////////////////////////////////////////////////////////////////////////

                                AffilationDetails = RFPreview_Reader["szHotelGrpAffiliation"].ToString();

                                ////////////////////////////////////////////////////////////////////////////////////////
                                if (RFPreview_Reader["szIncentive"].ToString() == string.Empty)
                                {
                                    whatMarketPack = string.Empty;
                                }
                                else if (RFPreview_Reader["szIncentive"].ToString() == "1")
                                {
                                    whatMarketPack = "Platinum Package";
                                }
                                else if (RFPreview_Reader["szIncentive"].ToString() == "2")
                                {
                                    whatMarketPack = "Gold Package";
                                }
                                else if (RFPreview_Reader["szIncentive"].ToString() == "3")
                                {
                                    whatMarketPack = "Silver Package";
                                }

                                Sigtitle = RFPreview_Reader["szElectronicSig"].ToString();
                                SigComments = RFPreview_Reader["szElectronicSigCmt"].ToString();

                            }

                        }
                    }
                }

                int itemsRates = 0;
                ArrayList ratesVirtualReepeater = new ArrayList();
                string listofitemsRates = string.Empty;

                using (SqlConnection RoomsRates_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand RoomsRates_cmd = new SqlCommand("SELECT Tbl_Hotel_PHC_AmmenRmSeasons.dtSTdate, Tbl_Hotel_PHC_AmmenRmSeasons.dtEDDate, Tbl_Hotel_PHC_AmmenRmCatRates.szRmTypeCat,Tbl_Hotel_PHC_AmmenRmCatRates.nRmRate, Tbl_Hotel_PHC_AmmenRmCatRates.szCurCode, Tbl_Hotel_PHC_AmmenRmSeasons.szSeaonName FROM Tbl_Hotel_PHC_AmmenRmSeasons INNER JOIN Tbl_Hotel_PHC_AmmenRmCatRates ON Tbl_Hotel_PHC_AmmenRmSeasons.LID = Tbl_Hotel_PHC_AmmenRmCatRates.LSID WHERE(Tbl_Hotel_PHC_AmmenRmSeasons.LRFPID = @LRFPID) ORDER BY Tbl_Hotel_PHC_AmmenRmSeasons.LID ASC", RoomsRates_Conn))
                    {
                        RoomsRates_cmd.CommandType = CommandType.Text;
                        RoomsRates_cmd.CommandTimeout = 0;

                        RoomsRates_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                        RoomsRates_Conn.Open();


                        // somw where in here put count of actaul seasons to start //

                        using (SqlDataReader RoomsRates_Reader = RoomsRates_cmd.ExecuteReader())
                        {

                            while (RoomsRates_Reader.Read())
                            {
                                // add to array list
                                // Convert.ToDateTime(RoomsRates_Reader["dtEDDate"].ToString()).ToShortDateString() <--- check for nothing and see if we can validate
                                ratesVirtualReepeater.Add(RoomsRates_Reader["szSeaonName"].ToString() + " Start Date: " + Convert.ToDateTime(RoomsRates_Reader["dtSTdate"].ToString()).ToShortDateString() + " End Date: " + Convert.ToDateTime(RoomsRates_Reader["dtEDDate"].ToString()).ToShortDateString() + Environment.NewLine + "Category: " + RoomsRates_Reader["szRmTypeCat"].ToString() + " Rate: " + RoomsRates_Reader["nRmRate"].ToString() + " Currency: " + RoomsRates_Reader["szCurCode"].ToString());
                                //HttpContext.Current.Response.Write("<br />" + thepropFeature);

                            }

                        }
                    }

                }

                for (itemsRates = 0; itemsRates <= ratesVirtualReepeater.Count - 1; itemsRates++)
                {
                    //We step through the arraylist, one at a time
                    listofitemsRates += ratesVirtualReepeater[itemsRates].ToString() + Environment.NewLine + Environment.NewLine;
                }

                // un-comment for testing
                //HttpContext.Current.Response.Write(listofitemsRates);

                //return;

                // non smoking yes or no
                using (SqlConnection NosmokeSubmit_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand NosmokeSubmit_cmd = new SqlCommand("SELECT DISTINCT lFeatureID FROM tbl_Hotel_PHC_Features_Property WHERE (LRFPID = @LRFPID) AND (lFeatureID = 21 OR lFeatureID = 22)", NosmokeSubmit_Conn))
                    {
                        NosmokeSubmit_cmd.CommandType = CommandType.Text;
                        NosmokeSubmit_cmd.CommandTimeout = 0;

                        NosmokeSubmit_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                        NosmokeSubmit_Conn.Open();

                        using (SqlDataReader NosmokeSubmit_Reader = NosmokeSubmit_cmd.ExecuteReader())
                        {
                            if (NosmokeSubmit_Reader.Read())
                            {
                                AmenProPNoSmokeYN = NosmokeSubmit_Reader["lFeatureID"].ToString();

                                if (string.IsNullOrEmpty(NosmokeSubmit_Reader["lFeatureID"].ToString()))
                                {
                                    AmenProPNoSmokeYN = string.Empty;
                                }
                                else if (NosmokeSubmit_Reader["lFeatureID"].ToString() == "21")
                                {
                                    AmenProPNoSmokeYN = "Yes";
                                }
                                else if (NosmokeSubmit_Reader["lFeatureID"].ToString() == "22")
                                {
                                    AmenProPNoSmokeYN = "No";
                                }

                            }
                        }
                    }
                }

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // Check boxes in ammenitties and radio button list /////////////////////////////////////////////////////////////////////////////
                
                // declare all varibles needed
                int mhid = 0;
                int items = 0;
                ArrayList thepropFeature = new ArrayList();
                string listofitems = string.Empty;

                // get correct MHID based on RFPID
                using (SqlConnection FeaturesGetmhid_Conn = new SqlConnection(RFPDBconnStr))
                {

                    using (SqlCommand FeaturesGetmhid_cmd = new SqlCommand("SELECT mhid from dbo.Tbl_Hotel_PHC_Property WHERE LRFPID = @LRFPID", FeaturesGetmhid_Conn))
                    {
                        FeaturesGetmhid_cmd.CommandType = CommandType.Text;
                        FeaturesGetmhid_cmd.CommandTimeout = 0;

                        FeaturesGetmhid_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                        FeaturesGetmhid_Conn.Open();

                        using (SqlDataReader FeaturesGetmhid_Reader = FeaturesGetmhid_cmd.ExecuteReader())
                        {
                            if (FeaturesGetmhid_Reader.Read())
                            {
                                mhid = FeaturesGetmhid_Reader.GetInt32(FeaturesGetmhid_Reader.GetOrdinal("mhid"));

                            }
                        }
                    }

                }

                // now use Correct MHID and RFPID to get what features we have based on MHID and RFPID
                using (SqlConnection GetFeaturesBlockOne_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand GetFeaturesBlockOne_cmd = new SqlCommand("SELECT tbl_Hotel_PHC_Features.szFeature, tbl_Hotel_PHC_Features.szType FROM tbl_Hotel_PHC_Features_Property INNER JOIN tbl_Hotel_PHC_Features ON tbl_Hotel_PHC_Features_Property.lFeatureID = tbl_Hotel_PHC_Features.lFeatureID WHERE (tbl_Hotel_PHC_Features_Property.mhid = @mhid) AND (tbl_Hotel_PHC_Features_Property.LRFPID = @LRFPID) AND (tbl_Hotel_PHC_Features.szFeature <> 'Non-smoking Hotel') AND (tbl_Hotel_PHC_Features.szFeature <> 'Smoking Hotel')", GetFeaturesBlockOne_Conn))
                    {
                        GetFeaturesBlockOne_cmd.CommandType = CommandType.Text;
                        GetFeaturesBlockOne_cmd.CommandTimeout = 0;

                        GetFeaturesBlockOne_cmd.Parameters.AddWithValue("@mhid", mhid);
                        GetFeaturesBlockOne_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                        GetFeaturesBlockOne_Conn.Open();

                        using (SqlDataReader GetFeaturesBlockOne_Reader = GetFeaturesBlockOne_cmd.ExecuteReader())
                        {

                            while (GetFeaturesBlockOne_Reader.Read())
                            {
                                // add to array list
                                thepropFeature.Add(GetFeaturesBlockOne_Reader["szFeature"].ToString() + " " + GetFeaturesBlockOne_Reader["szType"].ToString().Replace("P", "- Property Offering").Replace("R", "- Room Equipped with") + Environment.NewLine);

                            }

                        }
                    }

                }

                // now break up array list to string to put in to email
                for (items = 0; items <= thepropFeature.Count - 1; items++)
                {
                    //We step through the arraylist, one at a time
                    listofitems += thepropFeature[items].ToString() + Environment.NewLine;
                }

                ///// end check box list
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                // un-comment fopr testing
                //HttpContext.Current.Response.Write(listofitems);
                //return;

                SmtpClient RFPmailclientToUse = new SmtpClient();
                MailMessage RFPRegisterMsg = new MailMessage();

                RFPRegisterMsg.From = new MailAddress("acolin@ovationtravel.com", "Ovation and Lawyers Travel 2014 RFP");
                RFPRegisterMsg.To.Add(new MailAddress(SalesContactEmail, SalesContactName));
                RFPRegisterMsg.To.Add(new MailAddress("acolin@ovationtravel.com", "Amanda Colin"));
                //RFPRegisterMsg.To.Add(new MailAddress("alc10010@gmail.com", "Amanda Colin")); // outside email gmail account
                RFPRegisterMsg.To.Add(new MailAddress("jfogliano@ovationtravel.com", "Jennifer Achim"));
                RFPRegisterMsg.To.Add(new MailAddress("jcarey@ovationtravel.com", "Jennifer Carey"));
                RFPRegisterMsg.To.Add(new MailAddress("rjohn@ovationtravel.com", "Robert John"));
                RFPRegisterMsg.Bcc.Add(new MailAddress("ttrapp@ovationtravel.com"));
                RFPRegisterMsg.Subject = "2014 RFP submission";
                RFPRegisterMsg.Priority = MailPriority.Normal;
                RFPRegisterMsg.IsBodyHtml = false;

                //// put the message together
                AlternateView plainView = AlternateView.CreateAlternateViewFromString("Thank you for your interest in Ovation and Lawyers Travel 2014 Preferred Hotel Partners Program. This email confirmation includes the information completed in your RFP form submitted for " + HotelName + "." + Environment.NewLine + Environment.NewLine +
                                                                                      "The electronic signature submitted via your proposal represents a binding offer with Ovation and Lawyers Travel." + Environment.NewLine + Environment.NewLine +
                                                                                      "You will be notified of your acceptance by December 2013." + Environment.NewLine + Environment.NewLine +
                                                                                      "We will send you an invoice based on your participation package in January 2014." + Environment.NewLine + Environment.NewLine +
                                                                                      "SECTION 1: HOTEL INFORMATION      " + Environment.NewLine + Environment.NewLine +
                                                                                      "Sabre Property Code: " + SabrePCode + Environment.NewLine + Environment.NewLine +
                                                                                      "Sabre Chain Code: " + SabreChainCode + Environment.NewLine + Environment.NewLine +
                                                                                      "Apollo Property Code: " + ApolloPcode + Environment.NewLine + Environment.NewLine +
                                                                                      "Apollo Chain Code: " + ApolloChainCode + Environment.NewLine + Environment.NewLine +
                                                                                      "Hotel Name: " + HotelName + Environment.NewLine + Environment.NewLine +
                                                                                      "Address 1: " + HotelAddrOne + Environment.NewLine + Environment.NewLine +
                                                                                      "Address 2: " + HotelAddrTwo + Environment.NewLine + Environment.NewLine +
                                                                                      "City: " + Hotelcity + Environment.NewLine + Environment.NewLine +
                                                                                      "State: " + HotelInfoStateStr + Environment.NewLine + Environment.NewLine +
                                                                                      "Country: " + HotelcountryStr + Environment.NewLine + Environment.NewLine +
                                                                                      "Zip/Post Code: " + Hotelzippostcode + Environment.NewLine + Environment.NewLine +
                                                                                      "Hotel Main Phone: " + HotelMainphone + Environment.NewLine + Environment.NewLine +
                                                                                      "Sales Contact Name: " + SalesContactName + Environment.NewLine + Environment.NewLine +
                                                                                      "Sales Contact Title: " + SalesContactTitle + Environment.NewLine + Environment.NewLine +
                                                                                      "Sales Contact Telephone: " + SalesContactTelephone + Environment.NewLine + Environment.NewLine +
                                                                                      "Sales Contact Fax: " + SalesContactFax + Environment.NewLine + Environment.NewLine +
                                                                                      "Sales Contact Email: " + SalesContactEmail + Environment.NewLine + Environment.NewLine +
                                                                                      "General Manager: " + Hotelgeneralmgr + Environment.NewLine + Environment.NewLine +
                                                                                      "Director of Sales: " + DirectorofSales + Environment.NewLine + Environment.NewLine +
                                                                                      "Hotel Web Site: " + HotelWebSite + Environment.NewLine + Environment.NewLine +
                                                                                      "AAA Diamond Rating: " + AAAatingStr + Environment.NewLine + Environment.NewLine +
                                                                                      "Mobile Star Rating: " + MobileStaRateStr + Environment.NewLine + Environment.NewLine +
                                                                                      "Brief description of your property: " + Environment.NewLine + Hotelbriefdescipt + Environment.NewLine + Environment.NewLine +
                                                                                      "Current enviromental certification programs(s): " + EnviromentProgram + Environment.NewLine + Environment.NewLine +
                                                                                      "Active recycling program: " + avtiveRecycle + Environment.NewLine + Environment.NewLine +
                                                                                      "Environmentally responsible cleaners: " + Property_Responsible_Cleaners + Environment.NewLine + Environment.NewLine +
                                                                                      "Active water conservation program: " + Property_WaterConserve + Environment.NewLine + Environment.NewLine +
                                                                                      "SECTION 2: RATES & AMENITIES" + Environment.NewLine + Environment.NewLine +
                                                                                      "Ovation and Lawyers Travel Negotiated Preferred Rate(s) for 2014: " + Environment.NewLine +
                                                                                      listofitemsRates +
                                                                                      "Percentage discount off of the BAR rate: " + percentage + Environment.NewLine + Environment.NewLine +
                                                                                      "Last Room Available: " + Floating_Bar_Dynamic + Environment.NewLine + Environment.NewLine +
                                                                                      "Additional Comments on Rates: " + Environment.NewLine +
                                                                                      AmmenRatesComment + Environment.NewLine + Environment.NewLine +
                                                                                      "Rate including VAT: " + VatType + Environment.NewLine + Environment.NewLine +
                                                                                      "Would your property extend the Ovation negotiated rates to groups:" + WoulextendRateYN + Environment.NewLine + Environment.NewLine +
                                                                                      "Consortia Rate: " + ConRat + Environment.NewLine + Environment.NewLine +
                                                                                      "What is the lowest the consortia rate: " + ConfloorLowRate + Environment.NewLine + Environment.NewLine +
                                                                                      "What is the average the consortia rate: " + ConaverageRate + Environment.NewLine + Environment.NewLine +
                                                                                      "What is the highest the consortia rate: " + ConhighRate + Environment.NewLine + Environment.NewLine +
                                                                                      "Corporate Rate: " + CorpRate + Environment.NewLine + Environment.NewLine +
                                                                                      "Rack Rate: " + RackRate + Environment.NewLine + Environment.NewLine +
                                                                                      "Association Rate: " + AssocRate + Environment.NewLine + Environment.NewLine +
                                                                                      "Ovation and Lawyers Travel Recruitment Rate: " + RecruitmentRate + Environment.NewLine + Environment.NewLine +
                                                                                      "Amenities Offered to Ovation and Lawyers Travel Clients NOT OFFERED TO ALL GUESTS:" + Environment.NewLine +
                                                                                       AmenitiesOffered + Environment.NewLine + Environment.NewLine +
                                                                                      "Is the property a Virtuoso member: " + IsProperty_Virtuoso + Environment.NewLine + Environment.NewLine +
                                                                                      "If yes, is the Virtuoso amenity included: " + IsVirtuoso_included + Environment.NewLine + Environment.NewLine +
                                                                                      "If yes, what is Virtuoso amenity: " + VirtuosoAmenity + Environment.NewLine + Environment.NewLine +
                                                                                      "If yes, how do we ensure clients receive amenity: " + ensureClientVirtuosoAmenity + Environment.NewLine + Environment.NewLine +
                                                                                      "Is Internet Access included in the negotiated rate in Guest Room: " + internetGuestRoom + Environment.NewLine + Environment.NewLine +
                                                                                      "Is Internet access included in the negotiated rate in Public Space: " + internetpublicspace + Environment.NewLine + Environment.NewLine +
                                                                                      "Does your property offer the following and are the rooms equipped with, you chose: " + Environment.NewLine + Environment.NewLine +
                                                                                      listofitems + Environment.NewLine +
                                                                                      "What brand of amenities/products are supplied in your guest room bathrooms: " + Environment.NewLine +
                                                                                      AmenitiesBathroom + Environment.NewLine + Environment.NewLine +
                                                                                      "Please list the restaurant name(s) and cuisine type(s): " + Environment.NewLine +
                                                                                      Amenitesresturants + Environment.NewLine + Environment.NewLine +
                                                                                      "Please list the name(s) of the bar(s)/lounge(s): " + Environment.NewLine +
                                                                                      AmenitesBarLounge + Environment.NewLine + Environment.NewLine +
                                                                                      "Will your property undergo renovations in 2014: " + propertyrenovation2014 + Environment.NewLine + Environment.NewLine +
                                                                                      "If yes, please provide dates and details: " + Environment.NewLine +
                                                                                      propertyrenovationDates_details + Environment.NewLine + Environment.NewLine +
                                                                                      "Is your property a non-smoking hotel: " + AmenProPNoSmokeYN + Environment.NewLine + Environment.NewLine +
                                                                                      "How many rooms does your hotel have: " + Num_roomshotel + Environment.NewLine + Environment.NewLine +
                                                                                      "How many suites does your hotel have: " + Num_suiteshotel + Environment.NewLine + Environment.NewLine +
                                                                                      "Will you guarantee not to walk: " + noToWalk + Environment.NewLine + Environment.NewLine +
                                                                                      "Affiliated with a hotel group: " + AffilationDetails + Environment.NewLine + Environment.NewLine +
                                                                                      "SECTION 3: MARKETING PACKAGES" + Environment.NewLine + Environment.NewLine +
                                                                                      "Marketing Package: " + whatMarketPack + Environment.NewLine + Environment.NewLine +
                                                                                      "SECTION 4: SIGN AND SUBMIT" + Environment.NewLine + Environment.NewLine +
                                                                                      "Digital Signature and Title: " + Sigtitle + Environment.NewLine + Environment.NewLine +
                                                                                      "Comments: " + SigComments + Environment.NewLine + Environment.NewLine +
                                                                                      "------------------------" + Environment.NewLine +
                                                                                      "Amanda Colin" + Environment.NewLine +
                                                                                      "Director of Marketing" + Environment.NewLine +
                                                                                      "Ovation Corporate Travel" + Environment.NewLine +
                                                                                      "Lawyers Travel" + Environment.NewLine +
                                                                                      "71 Fifth Avenue" + Environment.NewLine +
                                                                                      "New York, NY 10003" + Environment.NewLine +
                                                                                      "Phone: 212.329.7204" + Environment.NewLine +
                                                                                      "Fax: 212.726.0910" + Environment.NewLine +
                                                                                      "www.ovationtravel.com" + Environment.NewLine +
                                                                                      "www.lawyerstravel.com", null, "text/plain");

                RFPRegisterMsg.AlternateViews.Add(plainView);

                //RFPmailclientToUse.UseDefaultCredentials = true;
                //// send the message
                RFPmailclientToUse.Send(RFPRegisterMsg);

                //// dispose
                ////and clean up resource
                RFPRegisterMsg.Dispose();
                RFPmailclientToUse.Dispose();

                using (SqlConnection UpdateSubmit_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand UpdateSubmit_cmd = new SqlCommand("UPDATE Tbl_Hotel_PHC_OvationRFPS SET blnIsSubmitted = 'true' WHERE (LRFPID = @LRFPID)", UpdateSubmit_Conn))
                    {
                        UpdateSubmit_cmd.CommandType = CommandType.Text;
                        UpdateSubmit_cmd.CommandTimeout = 0;

                        UpdateSubmit_Conn.Open();

                        UpdateSubmit_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                        UpdateSubmit_cmd.ExecuteNonQuery();

                    }
                }

                
                OvationTabs.Visible = false;
                //OvationMultiPage.Visible = false;
          
                //CompleteFrom.Visible = true;
                

            }

        }

    }
}
