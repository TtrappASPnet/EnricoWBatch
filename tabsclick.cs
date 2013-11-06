using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace OvationTest
{
    public partial class _Default
    {

        protected void OvationTabs_TabClick(object sender, RadTabStripEventArgs e)
        {
            string CountrySelectedTab = string.Empty;

            switch (e.Tab.Value)
            {
                // this is hotel info
                case "Hotel_Info":

                    // ---------------------- progress bar -----------------------------
                    //progressTextHotelInfo.Text = "Hotel Information | Incomplete";
                    //progressTextHotelInfo.ForeColor = System.Drawing.Color.Red;
                    //progressbarAmmen.Text = "2014 Rates & Amenities | Incomplete";
                    //progressbarAmmen.ForeColor = System.Drawing.Color.Red;
                    //progressBarTxtMarketingPackages.Text = "Marketing Packages | Incomplete";
                    //progressBarTxtMarketingPackages.ForeColor = System.Drawing.Color.Red;
                    //progressBarTxtElectronicSig.Text = "Electronic Signiture | Incomplete";
                    //progressBarTxtElectronicSig.ForeColor = System.Drawing.Color.Red;
                    //progressBarTxtRFPForm.Text = "2014 RFP | Incomplete";
                    //progressBarTxtRFPForm.ForeColor = System.Drawing.Color.Red;
                    // progressBar.Width = Unit.Pixel(225);
                    // progressbarAmmen.Visible = false;
                    // ----------------------------------------------------------------

                    using (SqlConnection GetSelectedCountryTab_Conn = new SqlConnection(RFPDBconnStr))
                    {
                        using (SqlCommand GetSelectedCountryTab_cmd = new SqlCommand("SELECT szCountry FROM Tbl_Hotel_PHC_HotelInfoPartialOne WHERE (LRFPID = @LRFPID)", GetSelectedCountryTab_Conn))
                        {
                            GetSelectedCountryTab_cmd.CommandType = CommandType.Text;
                            GetSelectedCountryTab_cmd.CommandTimeout = 0;

                            GetSelectedCountryTab_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                            GetSelectedCountryTab_Conn.Open();

                            using (SqlDataReader GetSelectedCountryTab_Reader = GetSelectedCountryTab_cmd.ExecuteReader())
                            {
                                if (GetSelectedCountryTab_Reader.Read())
                                {
                                    CountrySelectedTab = GetSelectedCountryTab_Reader["szCountry"].ToString();
                                }
                            }
                        }

                    }

                    selectHotelInfo();
                    UpdateHotelInfo();
                    updateAmmeneites();
                    updateMarkeing();


                    HotelInfoCodeBlock.Visible = true;
                    //MktgCodeBlock.Visible = false;
                    AmenitiesCodeBlock.Visible = false;
                    ElectronicSigCodeBlock.Visible = false;
                    Hotel_brief_descipt.Attributes.Add("Onkeypress", "return check_content();");
                    Sabre_PCode.Attributes.Add("onkeydown", "javascript:return jsNumbers_SabreP(event);");
                    Apollo_Pcode.Attributes.Add("onkeydown", "javascript:return jsNumbers_ApolloP(event);");
                    Sabre_Chain_Code.Attributes.Add("onkeypress", "javascript:return SabreChainlettersOnly(event);");
                    Apollo_Chain_Code.Attributes.Add("onkeypress", "javascript:return ApolloChainlettersOnly(event);");

                    if (string.IsNullOrEmpty(CountrySelectedTab))
                    {
                        Hotelcountry.SelectedValue = "United States";
                    }
                    else
                    {
                        Hotelcountry.SelectedValue = CountrySelectedTab.ToString();
                    }

                    break;

                // this is rates and ammenities 
                case "Rates_Amenities":

                    //--------------- progress bar -------------------------------------
                    //progressTextHotelInfo.Text = "Hotel Information | Complete";
                    //progressTextHotelInfo.ForeColor = System.Drawing.Color.Black;
                    //progressbarAmmen.Visible = true;
                    //progressbarAmmen.Text = "2014 Rates & Amenities | Incomplete";
                    //progressbarAmmen.ForeColor = System.Drawing.Color.Red;
                    //progressBarTxtMarketingPackages.Text = "Marketing Packages | Incomplete";
                    //progressBarTxtMarketingPackages.ForeColor = System.Drawing.Color.Red;
                    // progressBarTxtElectronicSig.Text = "Electronic Signiture | Incomplete";
                    //progressBarTxtElectronicSig.ForeColor = System.Drawing.Color.Red;
                    // progressBarTxtRFPForm.Text = "2014 RFP | Incomplete";
                    // progressBarTxtRFPForm.ForeColor = System.Drawing.Color.Red;
                    //progressBar.Width = Unit.Pixel(450);
                    // -----------------------------------------------------------------

                    // update hotel info //////////////////////////////////////////
                    UpdateHotelInfo();
                    updateAmmeneites();
                    updateMarkeing();
                    getammenities();


                    HotelInfoCodeBlock.Visible = false;
                    AmenitiesCodeBlock.Visible = true;
                    //MktgCodeBlock.Visible = false;
                    ElectronicSigCodeBlock.Visible = false;
                    Ammenities_Num_roomshotel.Attributes.Add("onkeydown", "javascript:return jsNumbers(event);");


                    break;

                // this is marketing packages 
                case "Marketing_pkgs":

                    // ---------------- progress bar ----------------------------------
                    //progressTextHotelInfo.Text = "Hotel Information | Complete";
                    //progressTextHotelInfo.ForeColor = System.Drawing.Color.Black;
                    //progressbarAmmen.Visible = true;
                    //progressbarAmmen.Text = "2014 Rates & Amenities | Complete";
                    //progressbarAmmen.ForeColor = System.Drawing.Color.Black;
                    // progressBarTxtMarketingPackages.Text = "Marketing Packages | Incomplete";
                    // progressBarTxtMarketingPackages.ForeColor = System.Drawing.Color.Red;
                    // progressBarTxtElectronicSig.Text = "Electronic Signiture | Incomplete";
                    // progressBarTxtElectronicSig.ForeColor = System.Drawing.Color.Red;
                    // progressBarTxtRFPForm.Text = "2014 RFP | Incomplete";
                    // progressBarTxtRFPForm.ForeColor = System.Drawing.Color.Red;
                    // progressBar.Width = Unit.Pixel(675);
                    // ----------------------------------------------------------------

                    selectMarketing();
                    UpdateHotelInfo();
                    updateAmmeneites();
                    updateMarkeing();
                    

                    HotelInfoCodeBlock.Visible = false;
                    AmenitiesCodeBlock.Visible = false;
                    //MktgCodeBlock.Visible = true;
                    ElectronicSigCodeBlock.Visible = false;

                    break;

                // this is electronic signiture
                case "Electronic_Sig":

                    UpdateHotelInfo();
                    updateAmmeneites();
                    updateMarkeing();
                    selectElectronicSig();


                    
                string SalesContactName_Mgk = string.Empty;
                string SalesContactTitle_Mgk = string.Empty;
                string SalesContactTelephone_Mgk = string.Empty;
                string SalesContactFax_Mgk = string.Empty;
                string HotelName_Mgk = string.Empty;
                string SalesContactEmail_Mgk = string.Empty;
                string HotelAddrOne_Mgk = string.Empty;
                string Hotelgeneralmgr_Mgk = string.Empty;
                string HotelAddrTwo_Mgk = string.Empty;
                string DirectorofSales_Mgk = string.Empty;
                string Hotelcity_Mgk = string.Empty;
                string HotelWebSite_Mgk = string.Empty;
                string HotelInfoStateStr_Mgk = string.Empty;
                string HotelcountryStr_Mgk = string.Empty;
                string Hotelzippostcode_Mgk = string.Empty;
                string HotelMainphone_Mgk = string.Empty;
                string AAAatingStr_Mgk = string.Empty;
                string MobileStaRateStr_Mgk = string.Empty;
                string Hotelbriefdescipt_Mgk = string.Empty;
                string EnviromentProgram_Mgk = string.Empty;
                string avtiveRecycle_Mgk = string.Empty;
                string Property_Responsible_Cleaners_Mgk = string.Empty;
                string Property_WaterConserve_Mgk = string.Empty;

                /// ammeneties section //////////////////////
                string percentage_Mgk = string.Empty;
                string LRAchoice_Mkt = string.Empty;
                string Floating_Bar_Dynamic_Mgk = string.Empty;
                string WoulextendRateYN_Mgk = string.Empty;
                string IsProperty_Virtuoso_Mgk = string.Empty;
                string internetGuestRoom_Mgk = string.Empty;
                string internetPublicSpace_Mgk = string.Empty;
                string propertyrenovation2014_Mgk = string.Empty;
                //string PropRenovationDetails_Mkt = string.Empty;
                string Nosmoking_Mgk = string.Empty;
                string Num_roomshotel_Mgk = string.Empty;
                string noToWalk_Mgk = string.Empty;

                /// marketing section
                string whatMarketPack_Mgk = string.Empty;


                using (SqlConnection RFPreviewMkgt_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand RFPreviewMkgt_cmd = new SqlCommand("SELECT Tbl_Hotel_PHC_HotelInfoPartialOne.szSabrePropertyNo, Tbl_Hotel_PHC_HotelInfoPartialOne.szApolloPropertyNo, Tbl_Hotel_PHC_HotelInfoPartialOne.szSabreChainCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szApolloChainCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szAddress, Tbl_Hotel_PHC_HotelInfoPartialOne.szAddressTwo, Tbl_Hotel_PHC_HotelInfoPartialOne.szCity, Tbl_Hotel_PHC_HotelInfoPartialOne.szState, Tbl_Hotel_PHC_HotelInfoPartialOne.szZipCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szCountry, Tbl_Hotel_PHC_HotelInfoPartialOne.szElectronicSig, Tbl_Hotel_PHC_HotelInfoPartialOne.szElectronicSigCmt, tbl_Hotel_PHC_Contacts.szName, tbl_Hotel_PHC_Contacts.szTitle, tbl_Hotel_PHC_Contacts.szHotelPhone, tbl_Hotel_PHC_Contacts.szPhone, tbl_Hotel_PHC_Contacts.szFax, tbl_Hotel_PHC_Contacts.szEmail, tbl_Hotel_PHC_Contacts.szDirector, tbl_Hotel_PHC_Property.szPrefHotelName, tbl_Hotel_PHC_Property.szGeneralMgr, tbl_Hotel_PHC_Property.szWebSite, tbl_Hotel_PHC_Property.szDiamondRating, tbl_Hotel_PHC_Property.szStarRating, tbl_Hotel_PHC_Property.szDiscountOff, tbl_Hotel_PHC_Property.szLastRoomAvail, tbl_Hotel_PHC_Property.szVat, tbl_Hotel_PHC_Property.szExtendGroupNegRate, tbl_Hotel_PHC_Property.szConsortiaRate, tbl_Hotel_PHC_Property.szLowestConsortiaRate, tbl_Hotel_PHC_Property.szAverageConsortiaRate, tbl_Hotel_PHC_Property.szHighestConsortiaRate, tbl_Hotel_PHC_Property.szCorpRate, tbl_Hotel_PHC_Property.szRackRate, tbl_Hotel_PHC_Property.szAsscociationRate, tbl_Hotel_PHC_Property.szRecruitRatesSeptDec, tbl_Hotel_PHC_Property.szInternetIncRate, tbl_Hotel_PHC_Property.szRenovations, tbl_Hotel_PHC_Property.szRenovationsDesc, tbl_Hotel_PHC_Property.szRoomCnt, tbl_Hotel_PHC_Property.szSuiteCnt, tbl_Hotel_PHC_Property.szGuaranteeNotToWalkOurGuests, tbl_Hotel_PHC_Property.szHotelGrpAffiliation, tbl_Hotel_PHC_Property.szEnvCertPrg, tbl_Hotel_PHC_Property.szRecyclingPrg, tbl_Hotel_PHC_Property.szUtilEnvRespCleaners, tbl_Hotel_PHC_Property.szActiveWaterCnsvPrg, tbl_Hotel_PHC_Property.szIncentive, tbl_Hotel_PHC_Property.szAmenitiesIncluded, tbl_Hotel_PHC_Property.szIsPropVirtuosoMem, tbl_Hotel_PHC_Property.szIsVirtuosoAmmenInc, tbl_Hotel_PHC_Property.szVirtuosoAmmen, tbl_Hotel_PHC_Property.szEnsureAmenty, tbl_Hotel_PHC_Property.szITinPublicSpaceInc, tbl_Hotel_PHC_Property.szItinGuestRoomInc, tbl_Hotel_PHC_Property.szHotelDesc, tbl_Hotel_PHC_Property.szRestaurant, tbl_Hotel_PHC_Property.szBarLounge, tbl_Hotel_PHC_Property.szToiletries, tbl_Hotel_PHC_Property.szDirectorOfSales FROM Tbl_Hotel_PHC_OvationRFPS INNER JOIN Tbl_Hotel_PHC_HotelInfoPartialOne ON Tbl_Hotel_PHC_OvationRFPS.LRFPID = Tbl_Hotel_PHC_HotelInfoPartialOne.LRFPID INNER JOIN tbl_Hotel_PHC_Contacts ON Tbl_Hotel_PHC_HotelInfoPartialOne.LRFPID = tbl_Hotel_PHC_Contacts.LRFPID INNER JOIN tbl_Hotel_PHC_Property ON tbl_Hotel_PHC_Contacts.LRFPID = tbl_Hotel_PHC_Property.LRFPID WHERE (Tbl_Hotel_PHC_OvationRFPS.LRFPID = @LRFPID)", RFPreviewMkgt_Conn))
                    {

                        //RFPreview_cmd.CommandText = "dbo.sp_RFP_GetRFPreviewbyID";
                        RFPreviewMkgt_cmd.CommandType = CommandType.Text;
                        RFPreviewMkgt_cmd.CommandTimeout = 0;

                        RFPreviewMkgt_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                        RFPreviewMkgt_Conn.Open();

                        using (SqlDataReader RFPreviewMkgt_Reader = RFPreviewMkgt_cmd.ExecuteReader())
                        {

                            if (RFPreviewMkgt_Reader.Read())
                            {
                                HotelName_Mgk = RFPreviewMkgt_Reader["szPrefHotelName"].ToString();
                                HotelAddrOne_Mgk = RFPreviewMkgt_Reader["szAddress"].ToString();
                                Hotelcity_Mgk = RFPreviewMkgt_Reader["szCity"].ToString();
                                HotelInfoStateStr_Mgk = RFPreviewMkgt_Reader["szState"].ToString();
                                HotelcountryStr_Mgk = RFPreviewMkgt_Reader["szCountry"].ToString();
                                Hotelzippostcode_Mgk = RFPreviewMkgt_Reader["szZipCode"].ToString();
                                HotelMainphone_Mgk = RFPreviewMkgt_Reader["szHotelPhone"].ToString();
                                SalesContactName_Mgk = RFPreviewMkgt_Reader["szName"].ToString();
                                SalesContactTitle_Mgk = RFPreviewMkgt_Reader["szTitle"].ToString();
                                SalesContactTelephone_Mgk = RFPreviewMkgt_Reader["szPhone"].ToString();
                                SalesContactFax_Mgk = RFPreviewMkgt_Reader["szFax"].ToString();
                                SalesContactEmail_Mgk = RFPreviewMkgt_Reader["szEmail"].ToString();
                                Hotelgeneralmgr_Mgk = RFPreviewMkgt_Reader["szGeneralMgr"].ToString();
                                DirectorofSales_Mgk = RFPreviewMkgt_Reader["szDirectorOfSales"].ToString();
                                HotelWebSite_Mgk = RFPreviewMkgt_Reader["szWebSite"].ToString();
                                AAAatingStr_Mgk = RFPreviewMkgt_Reader["szDiamondRating"].ToString();
                                MobileStaRateStr_Mgk = RFPreviewMkgt_Reader["szStarRating"].ToString();
                                Hotelbriefdescipt_Mgk = RFPreviewMkgt_Reader["szHotelDesc"].ToString();
                                avtiveRecycle_Mgk = RFPreviewMkgt_Reader["szRecyclingPrg"].ToString();
                                EnviromentProgram_Mgk = RFPreviewMkgt_Reader["szUtilEnvRespCleaners"].ToString();
                                Property_WaterConserve_Mgk = RFPreviewMkgt_Reader["szActiveWaterCnsvPrg"].ToString();

                                /// ammeneties section //////////////////////////////////////////////////
                                LRAchoice_Mkt = RFPreviewMkgt_Reader["szLastRoomAvail"].ToString();
                                percentage_Mgk = RFPreviewMkgt_Reader["szDiscountOff"].ToString();
                                WoulextendRateYN_Mgk = RFPreviewMkgt_Reader["szExtendGroupNegRate"].ToString();
                                IsProperty_Virtuoso_Mgk = RFPreviewMkgt_Reader["szIsPropVirtuosoMem"].ToString();
                                internetGuestRoom_Mgk = RFPreviewMkgt_Reader["szItinGuestRoomInc"].ToString();
                                internetPublicSpace_Mgk = RFPreviewMkgt_Reader["szITinPublicSpaceInc"].ToString();
                                propertyrenovation2014_Mgk = RFPreviewMkgt_Reader["szRenovations"].ToString();
                                //PropRenovationDetails_Mkt = RFPreviewMkgt_Reader["szRenovationsDesc"].ToString();
                                Num_roomshotel_Mgk = RFPreviewMkgt_Reader["szRoomCnt"].ToString();
                                noToWalk_Mgk = RFPreviewMkgt_Reader["szGuaranteeNotToWalkOurGuests"].ToString();

                                /// marketing
                                whatMarketPack_Mgk = RFPreviewMkgt_Reader["szIncentive"].ToString();
                            }
                        }
                    }
                }

                using (SqlConnection NoSmokeMkg_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand NoSmokeMkg_cmd = new SqlCommand("SELECT tbl_Hotel_PHC_Features.szFeature, tbl_Hotel_PHC_Features_Property.LRFPID FROM  tbl_Hotel_PHC_Features_Property INNER JOIN tbl_Hotel_PHC_Features ON tbl_Hotel_PHC_Features_Property.lFeatureID = tbl_Hotel_PHC_Features.lFeatureID WHERE (tbl_Hotel_PHC_Features.szFeature = 'Non-smoking Hotel' OR tbl_Hotel_PHC_Features.szFeature = 'Smoking Hotel') AND (tbl_Hotel_PHC_Features_Property.LRFPID = @LRFPID)", NoSmokeMkg_Conn))
                    {
                        NoSmokeMkg_cmd.CommandType = CommandType.Text;
                        NoSmokeMkg_cmd.CommandTimeout = 0;

                        NoSmokeMkg_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation"));

                        NoSmokeMkg_Conn.Open();

                        using (SqlDataReader NoSmokeMkg_Reader = NoSmokeMkg_cmd.ExecuteReader())
                        {
                            if (NoSmokeMkg_Reader.Read())
                            {

                                Nosmoking_Mgk = NoSmokeMkg_Reader["szFeature"].ToString();
                            }
                        }
                    }

                }
                /// regex for email /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string expression_Mgk = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" + @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" + @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
                Match match_Mgk = Regex.Match(Sales_Contact_Email.Text.ToString(), expression_Mgk, RegexOptions.IgnoreCase);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // hotel Info section error //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //string hotinfoTitle = @"<br /><img src=""Images/HotelInfoTitle.png"" style=""padding-left: 20px;"" />";
                if (string.IsNullOrEmpty(HotelName_Mgk) || string.IsNullOrEmpty(HotelAddrOne_Mgk) || string.IsNullOrEmpty(Hotelcity_Mgk) || HotelInfoStateStr_Mgk.ToString() == "Please Choose a State" || HotelcountryStr_Mgk.ToString() == "Please Choose a Country" || string.IsNullOrEmpty(Hotelzippostcode_Mgk) || string.IsNullOrEmpty(HotelMainphone_Mgk) || string.IsNullOrEmpty(SalesContactName_Mgk) || string.IsNullOrEmpty(SalesContactTitle_Mgk) || string.IsNullOrEmpty(SalesContactTelephone_Mgk) || string.IsNullOrEmpty(SalesContactFax_Mgk) || string.IsNullOrEmpty(SalesContactEmail_Mgk) || match_Mgk.Success == false || string.IsNullOrEmpty(Hotelgeneralmgr_Mgk) || string.IsNullOrEmpty(DirectorofSales_Mgk) || string.IsNullOrEmpty(HotelWebSite_Mgk) || string.IsNullOrEmpty(AAAatingStr_Mgk) || string.IsNullOrEmpty(MobileStaRateStr_Mgk) || string.IsNullOrEmpty(Hotelbriefdescipt_Mgk) || string.IsNullOrEmpty(avtiveRecycle_Mgk) || string.IsNullOrEmpty(EnviromentProgram_Mgk) || string.IsNullOrEmpty(Property_WaterConserve_Mgk) || string.IsNullOrEmpty(LRAchoice_Mkt) || string.IsNullOrEmpty(percentage_Mgk) || string.IsNullOrEmpty(WoulextendRateYN_Mgk) || string.IsNullOrEmpty(IsProperty_Virtuoso_Mgk) || string.IsNullOrEmpty(internetGuestRoom_Mgk) || string.IsNullOrEmpty(internetPublicSpace_Mgk) || string.IsNullOrEmpty(Nosmoking_Mgk) || string.IsNullOrEmpty(propertyrenovation2014_Mgk) || string.IsNullOrEmpty(Num_roomshotel_Mgk) || string.IsNullOrEmpty(noToWalk_Mgk) || string.IsNullOrEmpty(whatMarketPack_Mgk))
                {

                    RFPSEctionsErrors.Selected = true;


                    //HotelInfoError.Visible = true;
                    //RFPSEctionsErrors.Visible = true;
                    // errorNoerror.Text = "we have an error";
                    //rfpsubmiterror.Visible = true;
                    //noerror.Visible = false;

                    // /////////////////////////////////////////////////////////////////////

                    // hotel name //////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(HotelName_Mgk))
                    {

                        OhotelName.Visible = true;

                    }
                    else
                    {

                        OhotelName.Visible = false;
                    }

                    // Hotel address One //////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(HotelAddrOne_Mgk))
                    {

                        OaddressOne.Visible = true;
                    }
                    else
                    {

                        OaddressOne.Visible = false;

                    }

                    // Hotel city //////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(Hotelcity_Mgk))
                    {

                        OHCity.Visible = true;
                    }
                    else
                    {
                        OHCity.Visible = false;

                    }

                    // Hotel state /////////////////////////////////////////////////////////
                    if (HotelInfoStateStr_Mgk.ToString() == "Please Choose a State")
                    {
                        OHState.Visible = true;
                    }
                    else
                    {
                        OHState.Visible = false;

                    }

                    // Hotel Country ///////////////////////////////////////////////////////
                    if (HotelcountryStr_Mgk.ToString() == "Please Choose a Country")
                    {
                        OHcountry.Visible = true;
                    }
                    else
                    {
                        OHcountry.Visible = false;
                    }

                    // hotel zip code /////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(Hotelzippostcode_Mgk))
                    {
                        OHZipC.Visible = true;
                    }
                    else
                    {
                        OHZipC.Visible = false;
                    }

                    /// hotel main phone ///////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(HotelMainphone_Mgk))
                    {
                        OHmainPhone.Visible = true;
                    }
                    else
                    {
                        OHmainPhone.Visible = false;
                    }

                    // Hotel sales contact name ////////////////////////////////////////////
                    if (string.IsNullOrEmpty(SalesContactName_Mgk))
                    {
                        OHSalesConName.Visible = true;
                    }
                    else
                    {
                        OHSalesConName.Visible = false;
                    }

                    // sales contact title ////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(SalesContactTitle_Mgk))
                    {
                        OHSaleConTit.Visible = true;
                    }
                    else
                    {
                        OHSaleConTit.Visible = false;
                    }

                    // Hotel sales contact phone //////////////////////////////////////////
                    if (string.IsNullOrEmpty(SalesContactTelephone_Mgk))
                    {
                        OHSalesContactPhone.Visible = true;
                    }
                    else
                    {
                        OHSalesContactPhone.Visible = false;
                    }

                    // Hotel sales contact fax
                    if (string.IsNullOrEmpty(SalesContactFax_Mgk))
                    {
                        OHSalesConfax.Visible = true;
                    }
                    else
                    {
                        OHSalesConfax.Visible = false;
                    }

                    // hotel sales contact email empty and bad email ////////////////////////////////////////////
                    if (string.IsNullOrEmpty(SalesContactEmail_Mgk))
                    {
                        OHSalesConEmlEmpty.Visible = true;
                        OHSalesConEmlBad.Visible = false;
                    }
                    else if (match_Mgk.Success == false)
                    {
                        OHSalesConEmlBad.Text = "<li><strong>" + Sales_Contact_Email.Text.ToString() + "</strong> is not a valid email address</li>";
                        OHSalesConEmlBad.Visible = true;
                        OHSalesConEmlEmpty.Visible = false;
                    }
                    else
                    {
                        OHSalesConEmlEmpty.Visible = false;
                        OHSalesConEmlBad.Visible = false;
                    }

                    /// hotel gen manager
                    if (string.IsNullOrEmpty(Hotelgeneralmgr_Mgk))
                    {
                        OHGenMgr.Visible = true;
                    }
                    else
                    {
                        OHGenMgr.Visible = false;
                    }

                    // director of sales //////////////////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(DirectorofSales_Mgk))
                    {
                        OHDirectSales.Visible = true;
                    }
                    else
                    {
                        OHDirectSales.Visible = false;
                    }

                    // hotel web site ////////////////////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(HotelWebSite_Mgk))
                    {
                        OHwebsite.Visible = true;
                    }
                    else
                    {
                        OHwebsite.Visible = false;
                    }

                    // AAA diamond rating ///////////////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(AAAatingStr_Mgk))
                    {
                        OHAAARating.Visible = true;
                    }
                    else
                    {
                        OHAAARating.Visible = false;
                    }

                    // mobile star rating
                    if (string.IsNullOrEmpty(MobileStaRateStr_Mgk))
                    {
                        OHMobileStar.Visible = true;
                    }
                    else
                    {
                        OHMobileStar.Visible = false;
                    }

                    // hotel brief descrtiption  ///////////////////////////////////////////
                    if (string.IsNullOrEmpty(Hotelbriefdescipt_Mgk))
                    {
                        OHhotelBreifdescript.Visible = true;
                    }
                    else
                    {
                        OHhotelBreifdescript.Visible = false;
                    }

                    // active recycle //////////////////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(avtiveRecycle_Mgk))
                    {
                        OHActiveRecyle.Visible = true;
                    }
                    else
                    {
                        OHActiveRecyle.Visible = false;
                    }

                    // responsible cleaners
                    if (string.IsNullOrEmpty(EnviromentProgram_Mgk))
                    {
                        OHResponsible.Visible = true;
                    }
                    else
                    {
                        OHResponsible.Visible = false;
                    }

                    // water conserve /////////////////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(Property_WaterConserve_Mgk))
                    {
                        OHwaterconserver.Visible = true;
                    }
                    else
                    {
                        OHwaterconserver.Visible = false;
                    }

                    // LRA choice
                    if (string.IsNullOrEmpty(LRAchoice_Mkt))
                    {
                        AmmenLRAYN.Visible = true;
                    }
                    else
                    {
                        AmmenLRAYN.Visible = false;
                    }

                    // ammen percetage
                    if (string.IsNullOrEmpty(percentage_Mgk))
                    {
                        AMpercentage.Visible = true;
                    }
                    else
                    {
                        AMpercentage.Visible = false;

                    }
                    // Ammen would extend rate /////////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(WoulextendRateYN_Mgk))
                    {
                        AMWouldExtend.Visible = true;
                    }
                    else
                    {
                        AMWouldExtend.Visible = false;
                    }

                    // is prop virtuoso
                    if (string.IsNullOrEmpty(IsProperty_Virtuoso_Mgk))
                    {
                        AMIsPropVirtuoso.Visible = true;
                    }
                    else
                    {
                        AMIsPropVirtuoso.Visible = false;
                    }

                    // internet included in guest room
                    if (string.IsNullOrEmpty(internetGuestRoom_Mgk))
                    {
                        AMinternetIncGuestRm.Visible = true;
                    }
                    else
                    {
                        AMinternetIncGuestRm.Visible = false;
                    }

                    // internet included in public space
                    if (string.IsNullOrEmpty(internetPublicSpace_Mgk))
                    {
                        AMinternetPublic.Visible = true;
                    }
                    else
                    {
                        AMinternetPublic.Visible = false;
                    }

                    // is porp non-smoking
                    if (string.IsNullOrEmpty(Nosmoking_Mgk))
                    {
                        AMIsNonSmoking.Visible = true;
                    }
                    else
                    {
                        AMIsNonSmoking.Visible = false;
                    }

                    // prop renovations radio buttonlist
                    if (string.IsNullOrEmpty(propertyrenovation2014_Mgk))
                    {
                        AMRenovations.Visible = true;
                    }
                    else
                    {
                        AMRenovations.Visible = false;
                    }

                    // prop renovations text box is yes  // PropRenovationDetails_Mkt
                    //if (propertyrenovation2014_Mgk.ToString() == "Y" && string.IsNullOrEmpty(PropRenovationDetails_Mkt))
                    //{
                    //    AMrenovationTxt.Visible = true;
                    //}
                    //else
                    //{
                    //    AMrenovationTxt.Visible = false;
                    //}

                    // put here /////////////////////////////////////////

                    // how many hotel has
                    if (string.IsNullOrEmpty(Num_roomshotel_Mgk))
                    {
                        AMNumberRooms.Visible = true;
                    }
                    else
                    {
                        AMNumberRooms.Visible = false;
                    }

                    // no to walk
                    if (string.IsNullOrEmpty(noToWalk_Mgk))
                    {
                        AMnoToWalk.Visible = true;
                    }
                    else
                    {
                        AMnoToWalk.Visible = false;
                    }

                    // marketing packs 
                    if (string.IsNullOrEmpty(whatMarketPack_Mgk))
                    {
                        MarketingPackError.Visible = true;
                    }
                    else
                    {
                        MarketingPackError.Visible = false;
                    }

                }

                else
                {
                    // now validate seasonal rates section //////////////////////////////////////////////// 
                    using (SqlConnection RoomsRatesMkt_Conn = new SqlConnection(RFPDBconnStr))
                    {
                        using (SqlCommand RoomsRatesMkt_cmd = new SqlCommand("SELECT Tbl_Hotel_PHC_AmmenRmSeasons.dtSTdate, Tbl_Hotel_PHC_AmmenRmSeasons.dtEDDate, Tbl_Hotel_PHC_AmmenRmCatRates.szRmTypeCat,Tbl_Hotel_PHC_AmmenRmCatRates.nRmRate, Tbl_Hotel_PHC_AmmenRmCatRates.szCurCode, Tbl_Hotel_PHC_AmmenRmSeasons.szSeaonName FROM Tbl_Hotel_PHC_AmmenRmSeasons INNER JOIN Tbl_Hotel_PHC_AmmenRmCatRates ON Tbl_Hotel_PHC_AmmenRmSeasons.LID = Tbl_Hotel_PHC_AmmenRmCatRates.LSID WHERE(Tbl_Hotel_PHC_AmmenRmSeasons.LRFPID = @LRFPID) order by Tbl_Hotel_PHC_AmmenRmSeasons.LID ASC", RoomsRatesMkt_Conn))
                        {
                            RoomsRatesMkt_cmd.CommandType = CommandType.Text;
                            RoomsRatesMkt_cmd.CommandTimeout = 0;

                            RoomsRatesMkt_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation"));

                            RoomsRatesMkt_Conn.Open();

                            using (SqlDataReader RoomsRatesMkt_Reader = RoomsRatesMkt_cmd.ExecuteReader())
                            {
                                while (RoomsRatesMkt_Reader.Read())
                                {
                                    // HttpContext.Current.Response.Write(RoomsRatesMkt_Reader["szSeaonName"].ToString() + " ");

                                    if (RoomsRatesMkt_Reader["dtEDDate"] != DBNull.Value)
                                    {
                                        RFPSEctionsErrors.Selected = false;
                                        RatesSection.Visible = false;
                                        ElectornicSigView.Selected = true;
                                        ElectronicSigCodeBlock.Visible = true;
                                        finishedRFP.Visible = true;
                                        WincloseCodeBlock.Visible = false;
                                    }
                                    else
                                    {
                                        RFPSEctionsErrors.Selected = true;
                                        RatesSection.Visible = true;
                                    }


                                    if (RoomsRatesMkt_Reader["szRmTypeCat"] != DBNull.Value)
                                    {
                                        RFPSEctionsErrors.Selected = false;
                                        ElectornicSigView.Selected = true;
                                        ElectronicSigCodeBlock.Visible = true;
                                        finishedRFP.Visible = true;

                                    }
                                    else
                                    {
                                        RFPSEctionsErrors.Selected = true;
                                        RatesSection.Visible = true;
                                    }

                                    if (RoomsRatesMkt_Reader["nRmRate"] != DBNull.Value || RoomsRatesMkt_Reader["nRmRate"].ToString() != string.Empty)
                                    {
                                        RFPSEctionsErrors.Selected = false;
                                        ElectornicSigView.Selected = true;
                                        ElectronicSigCodeBlock.Visible = true;
                                        //finishedRFP.Visible = true;
                                        WincloseCodeBlock.Visible = false;
                                    }
                                    else
                                    {
                                        RFPSEctionsErrors.Selected = true;
                                        RatesSection.Visible = true;
                                    }
                                }

                            }
                        }

                    }
              

                }

   

                    // ---------------- progress bar -----------------------------------
                    // progressTextHotelInfo.Text = "Hotel Information | Complete";
                    //  progressTextHotelInfo.ForeColor = System.Drawing.Color.Black;
                    // progressbarAmmen.Visible = true;
                    // progressbarAmmen.Text = "2014 Rates & Amenities | Complete";
                    // progressbarAmmen.ForeColor = System.Drawing.Color.Black;
                    // progressBarTxtMarketingPackages.Text = "Marketing Packages | Complete";
                    // progressBarTxtMarketingPackages.ForeColor = System.Drawing.Color.Black;
                    // progressBarTxtElectronicSig.Text = "Electronic Signiture | Incomplete";
                    // progressBarTxtElectronicSig.ForeColor = System.Drawing.Color.Red;
                    // progressBarTxtRFPForm.Text = "2014 RFP | Incomplete";
                    // progressBarTxtRFPForm.ForeColor = System.Drawing.Color.Red;
                    //progressBar.Width = Unit.Pixel(900);
                    //rfprevlink.Text = whatRFPID.Value;
                    // -----------------------------------------------------------------
                     HotelInfoCodeBlock.Visible = false;
                     AmenitiesCodeBlock.Visible = false;
                     //MktgCodeBlock.Visible = true;
                     ElectronicSigCodeBlock.Visible = true;

                    
                    selectElectronicSig();
                    UpdateHotelInfo();
                    updateAmmeneites();
                    updateMarkeing();

                    break;

            }
        }


        protected void test()
        {
            //string SalesContactNameTab = string.Empty;
            //string SalesContactTitleTab = string.Empty;
            //string SalesContactTelephoneTab = string.Empty;
            //string SalesContactFaxTab = string.Empty;
            //string HotelNameTab = string.Empty;
            //string SalesContactEmailTab = string.Empty;
            //string HotelAddrOneTab = string.Empty;
            //string HotelgeneralmgrTab = string.Empty;
            //string HotelAddrTwoTab = string.Empty;
            //string DirectorofSalesTab = string.Empty;
            //string HotelcityTab = string.Empty;
            //string HotelWebSiteTab = string.Empty;
            //string HotelInfoStateStrTab = string.Empty;
            //string HotelcountryStrTab = string.Empty;
            //string HotelzippostcodeTab = string.Empty;
            //string HotelMainphoneTab = string.Empty;
            //string AAAatingStrTab = string.Empty;
            //string MobileStaRateStrTab = string.Empty;
            //string HotelbriefdesciptTab = string.Empty;
            //string EnviromentProgramTab = string.Empty;
            //string avtiveRecycleTab = string.Empty;
            //string Property_Responsible_CleanersTab = string.Empty;
            //string Property_WaterConserveTab = string.Empty;

            ///// ammeneties section //////////////////////
            //string percentageTab = string.Empty;
            //string Floating_Bar_DynamicTab = string.Empty;
            //string WoulextendRateYNTab = string.Empty;
            //string IsProperty_VirtuosoTab = string.Empty;
            //string internetGuestRoomTab = string.Empty;
            //string propertyrenovation2014Tab = string.Empty;
            //string NosmokingTab = string.Empty;
            //string Num_roomshotelTab = string.Empty;
            //string noToWalkTab = string.Empty;

            ///// marketing section
            //string whatMarketPackTab = string.Empty;


            //    using (SqlConnection RFPreview_Conn = new SqlConnection(RFPDBconnStr))
            //    {
            //        using (SqlCommand RFPreview_cmd = new SqlCommand("SELECT Tbl_Hotel_PHC_HotelInfoPartialOne.szSabrePropertyNo, Tbl_Hotel_PHC_HotelInfoPartialOne.szApolloPropertyNo, Tbl_Hotel_PHC_HotelInfoPartialOne.szSabreChainCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szApolloChainCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szAddress, Tbl_Hotel_PHC_HotelInfoPartialOne.szAddressTwo, Tbl_Hotel_PHC_HotelInfoPartialOne.szCity, Tbl_Hotel_PHC_HotelInfoPartialOne.szState, Tbl_Hotel_PHC_HotelInfoPartialOne.szZipCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szCountry, Tbl_Hotel_PHC_HotelInfoPartialOne.szElectronicSig, Tbl_Hotel_PHC_HotelInfoPartialOne.szElectronicSigCmt, tbl_Hotel_PHC_Contacts.szName, tbl_Hotel_PHC_Contacts.szTitle, tbl_Hotel_PHC_Contacts.szHotelPhone, tbl_Hotel_PHC_Contacts.szPhone, tbl_Hotel_PHC_Contacts.szFax, tbl_Hotel_PHC_Contacts.szEmail, tbl_Hotel_PHC_Contacts.szDirector, tbl_Hotel_PHC_Property.szPrefHotelName, tbl_Hotel_PHC_Property.szGeneralMgr, tbl_Hotel_PHC_Property.szWebSite, tbl_Hotel_PHC_Property.szDiamondRating, tbl_Hotel_PHC_Property.szStarRating, tbl_Hotel_PHC_Property.szDiscountOff, tbl_Hotel_PHC_Property.szLastRoomAvail, tbl_Hotel_PHC_Property.szVat, tbl_Hotel_PHC_Property.szExtendGroupNegRate, tbl_Hotel_PHC_Property.szConsortiaRate, tbl_Hotel_PHC_Property.szLowestConsortiaRate, tbl_Hotel_PHC_Property.szAverageConsortiaRate, tbl_Hotel_PHC_Property.szHighestConsortiaRate, tbl_Hotel_PHC_Property.szCorpRate, tbl_Hotel_PHC_Property.szRackRate, tbl_Hotel_PHC_Property.szAsscociationRate, tbl_Hotel_PHC_Property.szRecruitRatesSeptDec, tbl_Hotel_PHC_Property.szInternetIncRate, tbl_Hotel_PHC_Property.szRenovations, tbl_Hotel_PHC_Property.szRenovationsDesc, tbl_Hotel_PHC_Property.szRoomCnt, tbl_Hotel_PHC_Property.szSuiteCnt, tbl_Hotel_PHC_Property.szGuaranteeNotToWalkOurGuests, tbl_Hotel_PHC_Property.szHotelGrpAffiliation, tbl_Hotel_PHC_Property.szEnvCertPrg, tbl_Hotel_PHC_Property.szRecyclingPrg, tbl_Hotel_PHC_Property.szUtilEnvRespCleaners, tbl_Hotel_PHC_Property.szActiveWaterCnsvPrg, tbl_Hotel_PHC_Property.szIncentive, tbl_Hotel_PHC_Property.szAmenitiesIncluded, tbl_Hotel_PHC_Property.szIsPropVirtuosoMem, tbl_Hotel_PHC_Property.szIsVirtuosoAmmenInc, tbl_Hotel_PHC_Property.szVirtuosoAmmen, tbl_Hotel_PHC_Property.szEnsureAmenty, tbl_Hotel_PHC_Property.szITinPublicSpaceInc, tbl_Hotel_PHC_Property.szItinGuestRoomInc, tbl_Hotel_PHC_Property.szHotelDesc, tbl_Hotel_PHC_Property.szRestaurant, tbl_Hotel_PHC_Property.szBarLounge, tbl_Hotel_PHC_Property.szToiletries, tbl_Hotel_PHC_Property.szDirectorOfSales FROM Tbl_Hotel_PHC_OvationRFPS INNER JOIN Tbl_Hotel_PHC_HotelInfoPartialOne ON Tbl_Hotel_PHC_OvationRFPS.LRFPID = Tbl_Hotel_PHC_HotelInfoPartialOne.LRFPID INNER JOIN tbl_Hotel_PHC_Contacts ON Tbl_Hotel_PHC_HotelInfoPartialOne.LRFPID = tbl_Hotel_PHC_Contacts.LRFPID INNER JOIN tbl_Hotel_PHC_Property ON tbl_Hotel_PHC_Contacts.LRFPID = tbl_Hotel_PHC_Property.LRFPID WHERE (Tbl_Hotel_PHC_OvationRFPS.LRFPID = @LRFPID)", RFPreview_Conn))
            //        {
            //            RFPreview_cmd.CommandType = CommandType.Text;
            //            RFPreview_cmd.CommandTimeout = 0;

            //            RFPreview_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

            //            RFPreview_Conn.Open();

            //            using (SqlDataReader RFPreview_Reader = RFPreview_cmd.ExecuteReader())
            //            {

            //                if (RFPreview_Reader.Read())
            //                {
            //                    HotelNameTab = RFPreview_Reader["szPrefHotelName"].ToString();
            //                    HotelAddrOneTab = RFPreview_Reader["szAddress"].ToString();
            //                    HotelcityTab = RFPreview_Reader["szCity"].ToString();
            //                    HotelInfoStateStrTab = RFPreview_Reader["szState"].ToString();
            //                    HotelcountryStrTab = RFPreview_Reader["szCountry"].ToString();
            //                    HotelzippostcodeTab = RFPreview_Reader["szZipCode"].ToString();
            //                    HotelMainphoneTab = RFPreview_Reader["szHotelPhone"].ToString();
            //                    SalesContactNameTab = RFPreview_Reader["szName"].ToString();
            //                    SalesContactTitleTab = RFPreview_Reader["szTitle"].ToString();
            //                    SalesContactTelephoneTab = RFPreview_Reader["szPhone"].ToString();
            //                    SalesContactFaxTab = RFPreview_Reader["szFax"].ToString();
            //                    SalesContactEmailTab = RFPreview_Reader["szEmail"].ToString();
            //                    HotelgeneralmgrTab = RFPreview_Reader["szGeneralMgr"].ToString();
            //                    DirectorofSalesTab = RFPreview_Reader["szDirectorOfSales"].ToString();
            //                    HotelWebSiteTab = RFPreview_Reader["szWebSite"].ToString();
            //                    AAAatingStrTab = RFPreview_Reader["szDiamondRating"].ToString();
            //                    MobileStaRateStrTab = RFPreview_Reader["szStarRating"].ToString();
            //                    avtiveRecycleTab = RFPreview_Reader["szRecyclingPrg"].ToString();
            //                    EnviromentProgramTab = RFPreview_Reader["szUtilEnvRespCleaners"].ToString();
            //                    Property_WaterConserveTab = RFPreview_Reader["szActiveWaterCnsvPrg"].ToString();

            //                    /// ammeneties section //////////////////////////////////////////////////
            //                    percentageTab = RFPreview_Reader["szDiscountOff"].ToString();
            //                    WoulextendRateYNTab = RFPreview_Reader["szExtendGroupNegRate"].ToString();
            //                    IsProperty_VirtuosoTab = RFPreview_Reader["szIsPropVirtuosoMem"].ToString();
            //                    internetGuestRoomTab = RFPreview_Reader["szItinGuestRoomInc"].ToString();
            //                    propertyrenovation2014Tab = RFPreview_Reader["szRenovations"].ToString();
            //                    Num_roomshotelTab = RFPreview_Reader["szRoomCnt"].ToString();
            //                    noToWalkTab = RFPreview_Reader["szGuaranteeNotToWalkOurGuests"].ToString();

            //                    /// marketing
            //                    whatMarketPackTab = RFPreview_Reader["szIncentive"].ToString();  
            //                }
            //            }
            //        }
            //    }

            //    using (SqlConnection NoSmoke_Conn = new SqlConnection(RFPDBconnStr))
            //    {
            //        using (SqlCommand NoSmoke_cmd = new SqlCommand("SELECT tbl_Hotel_PHC_Features.szFeature, tbl_Hotel_PHC_Features_Property.LRFPID FROM  tbl_Hotel_PHC_Features_Property INNER JOIN tbl_Hotel_PHC_Features ON tbl_Hotel_PHC_Features_Property.lFeatureID = tbl_Hotel_PHC_Features.lFeatureID WHERE (tbl_Hotel_PHC_Features.szFeature = 'Non-smoking Hotel') AND (tbl_Hotel_PHC_Features_Property.LRFPID = @LRFPID)", NoSmoke_Conn))
            //        {
            //            NoSmoke_cmd.CommandType = CommandType.Text;
            //            NoSmoke_cmd.CommandTimeout = 0;

            //            NoSmoke_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation"));

            //            NoSmoke_Conn.Open();

            //            using (SqlDataReader NoSmoke_Reader = NoSmoke_cmd.ExecuteReader())
            //            {
            //                if (NoSmoke_Reader.Read())
            //                {

            //                    NosmokingTab = NoSmoke_Reader["szFeature"].ToString();
            //                }
            //            }
            //        }

            //    }
            //    /// regex for email /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //    string expression = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" + @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" + @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            //    Match match = Regex.Match(Sales_Contact_Email.Text.ToString(), expression, RegexOptions.IgnoreCase);

            //     List<String> ratesVirtualReepeaterTabClick = new List<String>();

            //    using (SqlConnection RoomsRates_Conn = new SqlConnection(RFPDBconnStr))
            //    {
            //        using (SqlCommand RoomsRates_cmd = new SqlCommand("SELECT Tbl_Hotel_PHC_AmmenRmSeasons.dtSTdate, Tbl_Hotel_PHC_AmmenRmSeasons.dtEDDate, Tbl_Hotel_PHC_AmmenRmCatRates.szRmTypeCat,Tbl_Hotel_PHC_AmmenRmCatRates.nRmRate, Tbl_Hotel_PHC_AmmenRmCatRates.szCurCode, Tbl_Hotel_PHC_AmmenRmSeasons.szSeaonName FROM Tbl_Hotel_PHC_AmmenRmSeasons INNER JOIN Tbl_Hotel_PHC_AmmenRmCatRates ON Tbl_Hotel_PHC_AmmenRmSeasons.LID = Tbl_Hotel_PHC_AmmenRmCatRates.LSID WHERE(Tbl_Hotel_PHC_AmmenRmSeasons.LRFPID = @LRFPID)", RoomsRates_Conn))
            //        {
            //            RoomsRates_cmd.CommandType = CommandType.Text;
            //            RoomsRates_cmd.CommandTimeout = 0;

            //            RoomsRates_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation"));

            //            RoomsRates_Conn.Open();


            //            // somw where in here put count of actaul seasons to start //

            //            using (SqlDataReader RoomsRates_Reader = RoomsRates_cmd.ExecuteReader())
            //            {

            //                while (RoomsRates_Reader.Read())
            //                {

            //                    if (RoomsRates_Reader["dtEDDate"] != DBNull.Value)
            //                    {
            //                       RatesEndDate = RoomsRates_Reader["dtEDDate"].ToString();
            //                    }
            //                    else
            //                    {
            //                        RatesEndDate = string.Empty;
            //                    }

            //                    if (RoomsRates_Reader["szRmTypeCat"] != DBNull.Value)
            //                    {
            //                        RatesRmCategory = RoomsRates_Reader["szRmTypeCat"].ToString();
            //                    }
            //                    else
            //                    {
            //                        RatesRmCategory = string.Empty;
            //                    }

            //                    if (RoomsRates_Reader["nRmRate"] != DBNull.Value)
            //                    {

            //                        RatesRates = RoomsRates_Reader["nRmRate"].ToString();

            //                    }
            //                    else
            //                    {
            //                        RatesRates = string.Empty;
            //                    }

            //                    ratesVirtualReepeaterTabClick.Clear();
            //                    // add  to generic list
            //                   // ratesVirtualReepeaterTabClick.Add(Season);
            //                    ratesVirtualReepeaterTabClick.Add(RatesEndDate);
            //                    ratesVirtualReepeaterTabClick.Add(RatesRmCategory);
            //                    ratesVirtualReepeaterTabClick.Add(RatesRates);
            //                }

            //            }
            //        }

            //    }

            //    // first sort our generic list then search for string.empty
            //    ratesVirtualReepeaterTabClick.Sort();

            //    // search our generic list ///////////////////////////////////////////
            //    int indexstart = ratesVirtualReepeaterTabClick.BinarySearch(string.Empty);

            //    // this main if is to show error page view and the sub if is to show individual errors ///////////////////
            //    if (string.IsNullOrEmpty(HotelNameTab) || string.IsNullOrEmpty(HotelAddrOneTab) || string.IsNullOrEmpty(HotelcityTab) || HotelInfoStateStrTab.ToString() == "Please Choose a State" || HotelcountryStrTab.ToString() == "Please Choose a Country" || string.IsNullOrEmpty(HotelzippostcodeTab) || string.IsNullOrEmpty(HotelMainphoneTab) || string.IsNullOrEmpty(SalesContactNameTab) || string.IsNullOrEmpty(SalesContactTitleTab) || string.IsNullOrEmpty(SalesContactTelephoneTab) || string.IsNullOrEmpty(SalesContactFaxTab) || string.IsNullOrEmpty(SalesContactEmailTab) || match.Success == false || string.IsNullOrEmpty(HotelgeneralmgrTab) || string.IsNullOrEmpty(DirectorofSalesTab) || string.IsNullOrEmpty(HotelWebSiteTab) || string.IsNullOrEmpty(AAAatingStrTab) || string.IsNullOrEmpty(MobileStaRateStrTab) || string.IsNullOrEmpty(avtiveRecycleTab) || string.IsNullOrEmpty(EnviromentProgramTab) || string.IsNullOrEmpty(Property_WaterConserveTab) || string.IsNullOrEmpty(percentageTab) || string.IsNullOrEmpty(WoulextendRateYNTab) || string.IsNullOrEmpty(IsProperty_VirtuosoTab) || string.IsNullOrEmpty(internetGuestRoomTab) || string.IsNullOrEmpty(NosmokingTab) || string.IsNullOrEmpty(propertyrenovation2014Tab) || string.IsNullOrEmpty(Num_roomshotelTab) || string.IsNullOrEmpty(noToWalkTab) || string.IsNullOrEmpty(whatMarketPackTab) || indexstart < 0)
            //    {

            //       RFPSEctionsErrors.Selected = true;

            //        // /////////////////////////////////////////////////////////////////////

            //        // hotel name //////////////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(HotelNameTab)) 
            //        {

            //            OhotelName.Visible = true;

            //        }
            //        else
            //        {

            //            OhotelName.Visible = false;
            //        }

            //        // Hotel address One //////////////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(HotelAddrOneTab))
            //        {

            //            OaddressOne.Visible = true;
            //        }
            //        else
            //        {

            //            OaddressOne.Visible = false;

            //        }

            //        // Hotel city //////////////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(HotelcityTab))
            //        {

            //            OHCity.Visible = true;
            //        }
            //        else
            //       {
            //           OHCity.Visible = false;

            //       }

            //        // Hotel state /////////////////////////////////////////////////////////
            //       if (HotelInfoStateStrTab.ToString() == "Please Choose a State")
            //        {

            //            OHState.Visible = true;
            //        }
            //        else
            //       {
            //            OHState.Visible = false;

            //        }

            //        // Hotel Country ///////////////////////////////////////////////////////
            //       if (HotelcountryStrTab.ToString() == "Please Choose a Country")
            //        {

            //            OHcountry.Visible = true;
            //        }
            //        else
            //        {

            //            OHcountry.Visible = false;

            //        }

            //        // hotel zip code /////////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(HotelzippostcodeTab))
            //        {

            //            OHZipC.Visible = true;

            //        }
            //        else
            //        {

            //            OHZipC.Visible = false;

            //        }

            //        /// hotel main phone ///////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(HotelMainphoneTab))
            //        {

            //            OHmainPhone.Visible = true;

            //        }
            //        else
            //        {

            //            OHmainPhone.Visible = false;
            //        }

            //        // Hotel sales contact name ////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(SalesContactNameTab))
            //        {

            //            OHSalesConName.Visible = true;
            //        }
            //        else
            //        {

            //            OHSalesConName.Visible = false;
            //        }

            //        // sales contact title ////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(SalesContactTitleTab))
            //        {
            //            OHSaleConTit.Visible = true;
            //        }
            //        else
            //        {
            //            OHSaleConTit.Visible = false;
            //        }

            //        // Hotel sales contact phone //////////////////////////////////////////
            //       if (string.IsNullOrEmpty(SalesContactTelephoneTab))
            //        {

            //            OHSalesContactPhone.Visible = true;
            //        }
            //        else
            //        {

            //            OHSalesContactPhone.Visible = false;
            //        }

            //        // Hotel sales contact fax
            //       if (string.IsNullOrEmpty(SalesContactFaxTab))
            //        {
            //            OHSalesConfax.Visible = true;
            //        }
            //        else
            //        {
            //            OHSalesConfax.Visible = false;
            //        }

            //        // hotel sales contact email empty and bad email ////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(SalesContactEmailTab))
            //        {
            //            OHSalesConEmlEmpty.Visible = true;
            //            OHSalesConEmlBad.Visible = false;
            //        }
            //        else if (match.Success == false)
            //        {
            //            OHSalesConEmlBad.Text = "<li><strong>" + Sales_Contact_Email.Text.ToString() + "</strong> is not a valid email address</li>";
            //            OHSalesConEmlBad.Visible = true;
            //            OHSalesConEmlEmpty.Visible = false;
            //        }
            //        else
            //        {
            //            OHSalesConEmlEmpty.Visible = false;
            //            OHSalesConEmlBad.Visible = false;
            //        }

            //        /// hotel gen manager
            //       if (string.IsNullOrEmpty(HotelgeneralmgrTab))
            //        {
            //            OHGenMgr.Visible = true;
            //        }
            //        else
            //        {
            //            OHGenMgr.Visible = false;
            //        }

            //        // director of sales //////////////////////////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(DirectorofSalesTab))
            //        {
            //            OHDirectSales.Visible = true;
            //        }
            //        else
            //        {
            //            OHDirectSales.Visible = false;
            //        }

            //        // hotel web site ////////////////////////////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(HotelWebSiteTab))
            //        {
            //            OHwebsite.Visible = true;
            //        }
            //        else
            //        {
            //            OHwebsite.Visible = false;
            //        }

            //        // AAA diamond rating ///////////////////////////////////////////////////////////////////
            //       if (string.IsNullOrEmpty(AAAatingStrTab))
            //        {

            //            OHAAARating.Visible = true;
            //        }
            //        else
            //        {
            //            OHAAARating.Visible = false;
            //        }

            //        // mobile star rating
            //       if (string.IsNullOrEmpty(MobileStaRateStrTab))
            //        {

            //            OHMobileStar.Visible = true;
            //        }
            //        else
            //        {
            //            OHMobileStar.Visible = false;

            //        }

            //        // active recycle //////////////////////////////////////////////////////////////////////
            //        if (string.IsNullOrEmpty(avtiveRecycleTab))
            //        {
            //            OHActiveRecyle.Visible = true;
            //        }
            //        else
            //        {
            //            OHActiveRecyle.Visible = false;
            //        }

            //        // responsible cleaners
            //        if (string.IsNullOrEmpty(EnviromentProgramTab))
            //        {

            //            OHResponsible.Visible = true;
            //        }
            //        else
            //        {

            //            OHResponsible.Visible = false;

            //        }

            //        // water conserve /////////////////////////////////////////////////////////////////////
            //        if (string.IsNullOrEmpty(Property_WaterConserveTab))
            //        {
            //            OHwaterconserver.Visible = true;
            //        }
            //        else
            //        {
            //            OHwaterconserver.Visible = false;
            //        }

            //        // ammen percetage
            //        if (string.IsNullOrEmpty(percentageTab))
            //        {
            //            AMpercentage.Visible = true;

            //        }
            //        else
            //        {
            //            AMpercentage.Visible = false;

            //        }
            //        // Ammen would extend rate /////////////////////////////////////////////////////////////
            //        if (string.IsNullOrEmpty(WoulextendRateYNTab))
            //        {
            //            AMWouldExtend.Visible = true;
            //        }
            //        else
            //        {
            //            AMWouldExtend.Visible = false;
            //        }

            //        // is prop virtuoso
            //        if (string.IsNullOrEmpty(IsProperty_VirtuosoTab))
            //        {
            //            AMIsPropVirtuoso.Visible = true;
            //        }
            //        else
            //        {
            //            AMIsPropVirtuoso.Visible = false;
            //        }

            //        // internet included in guest room
            //        if (string.IsNullOrEmpty(internetGuestRoomTab))
            //        {
            //            AMinternetIncGuestRm.Visible = true;
            //        }
            //        else
            //        {
            //            AMinternetIncGuestRm.Visible = false;
            //        }

            //        // is porp non-smoking
            //        if (string.IsNullOrEmpty(NosmokingTab))
            //       {
            //           AMIsNonSmoking.Visible = true;
            //       }
            //       else
            //       {
            //            AMIsNonSmoking.Visible = false;
            //       }

            //        // prop renovations
            //      // whatMarketPack.ToString() == string.Empty 
            //        if (string.IsNullOrEmpty(propertyrenovation2014Tab))
            //        {
            //            AMRenovations.Visible = true;
            //        }
            //        else
            //        {
            //            AMRenovations.Visible = false;
            //        }

            //        // how many hotel has
            //        if (string.IsNullOrEmpty(Num_roomshotelTab))
            //        {
            //            AMNumberRooms.Visible = true;
            //        }
            //        else
            //        {
            //            AMNumberRooms.Visible = false;
            //        }

            //        // no to walk
            //        if (string.IsNullOrEmpty(noToWalkTab))
            //        {
            //            AMnoToWalk.Visible = true;
            //        }
            //        else
            //        {
            //            AMnoToWalk.Visible = false;
            //        }

            //        // marketing packs 
            //        if (string.IsNullOrEmpty(whatMarketPackTab))
            //        {
            //            MarketingPackError.Visible = true;
            //        }
            //        else
            //        {
            //            MarketingPackError.Visible = false;
            //        }

            //        // rates section
            //        if (indexstart < 0)
            //        {
            //           // RatesSectionList.Visible = false;
            //        }
            //        else
            //        {
            //            //RatesSectionList.Visible = true;
            //        }

            //    }
            //    else
            //    {
            //        RFPSEctionsErrors.Selected = false;
            //        ElectornicSigView.Selected = true;
            //        finishedRFP.Visible = true;

            //    }
        }
        ///////////////////////////////// all select and update operations //////////////////////////
        /// <summary>
        /// /////////////// select hotel info section /////////////////////////////////////////////
        /// </summary>
        protected void selectHotelInfo()
        {
            using (SqlConnection RFPreview_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand RFPreview_cmd = new SqlCommand("SELECT Tbl_Hotel_PHC_HotelInfoPartialOne.szSabrePropertyNo, Tbl_Hotel_PHC_HotelInfoPartialOne.szApolloPropertyNo, Tbl_Hotel_PHC_HotelInfoPartialOne.szSabreChainCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szApolloChainCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szAddress, Tbl_Hotel_PHC_HotelInfoPartialOne.szAddressTwo, Tbl_Hotel_PHC_HotelInfoPartialOne.szCity, Tbl_Hotel_PHC_HotelInfoPartialOne.szState, Tbl_Hotel_PHC_HotelInfoPartialOne.szZipCode, Tbl_Hotel_PHC_HotelInfoPartialOne.szCountry, tbl_Hotel_PHC_Contacts.szName, tbl_Hotel_PHC_Contacts.szTitle, tbl_Hotel_PHC_Contacts.szHotelPhone, tbl_Hotel_PHC_Contacts.szPhone, tbl_Hotel_PHC_Contacts.szFax, tbl_Hotel_PHC_Contacts.szEmail, tbl_Hotel_PHC_Property.szPrefHotelName, tbl_Hotel_PHC_Property.szGeneralMgr, tbl_Hotel_PHC_Property.szWebSite, tbl_Hotel_PHC_Property.szDiamondRating, tbl_Hotel_PHC_Property.szStarRating, tbl_Hotel_PHC_Property.szEnvCertPrg, tbl_Hotel_PHC_Property.szRecyclingPrg, tbl_Hotel_PHC_Property.szUtilEnvRespCleaners, tbl_Hotel_PHC_Property.szActiveWaterCnsvPrg, tbl_Hotel_PHC_Property.szHotelDesc, tbl_Hotel_PHC_Property.szDirectorOfSales FROM Tbl_Hotel_PHC_HotelInfoPartialOne INNER JOIN tbl_Hotel_PHC_Contacts ON Tbl_Hotel_PHC_HotelInfoPartialOne.LRFPID = tbl_Hotel_PHC_Contacts.LRFPID INNER JOIN tbl_Hotel_PHC_Property ON tbl_Hotel_PHC_Contacts.LRFPID = tbl_Hotel_PHC_Property.LRFPID WHERE Tbl_Hotel_PHC_HotelInfoPartialOne.LRFPID = " + Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation") + "", RFPreview_Conn))
                {
                    RFPreview_cmd.CommandType = CommandType.Text;
                    RFPreview_cmd.CommandTimeout = 0;

                    RFPreview_Conn.Open();

                    using (SqlDataReader RFPreview_Reader = RFPreview_cmd.ExecuteReader())
                    {
                        if (RFPreview_Reader.Read())
                        {
                            Sabre_PCode.Text = RFPreview_Reader["szSabrePropertyNo"].ToString();
                            Sales_Contact_Name.Text = RFPreview_Reader["szName"].ToString();
                            Sabre_Chain_Code.Text = RFPreview_Reader["szSabreChainCode"].ToString();
                            Sales_Contact_Title.Text = RFPreview_Reader["szTitle"].ToString();
                            Apollo_Pcode.Text = RFPreview_Reader["szApolloPropertyNo"].ToString();
                            Sales_Contact_Telephone.Text = RFPreview_Reader["szPhone"].ToString();
                            Apollo_Chain_Code.Text = RFPreview_Reader["szApolloChainCode"].ToString();
                            Sales_Contact_Fax.Text = RFPreview_Reader["szFax"].ToString();
                            Hotel_Name.Text = RFPreview_Reader["szPrefHotelName"].ToString();
                            Sales_Contact_Email.Text = RFPreview_Reader["szEmail"].ToString();
                            Hotel_Addr_One.Text = RFPreview_Reader["szAddress"].ToString();
                            Hotel_general_mgr.Text = RFPreview_Reader["szGeneralMgr"].ToString();
                            Hotel_Addr_Two.Text = RFPreview_Reader["szAddressTwo"].ToString();
                            Director_of_Sales.Text = RFPreview_Reader["szDirectorOfSales"].ToString();
                            Hotel_city.Text = RFPreview_Reader["szCity"].ToString();
                            Hotel_Web_Site.Text = RFPreview_Reader["szWebSite"].ToString();

                            // state drop down
                            if (RFPreview_Reader["szState"].ToString() == string.Empty)
                            {
                                HotelInfo_State.SelectedValue = "Please Choose a State";

                            }
                            else
                            {

                                HotelInfo_State.SelectedValue = RFPreview_Reader["szState"].ToString();
                            }

                            /// country dropdown
                            //if (RFPreview_Reader["szCountry"].ToString() == string.Empty)
                            //{
                                //Hotelcountry.SelectedValue = "United States";

                            //}
                            //else
                            //{
                                Hotelcountry.SelectedValue = RFPreview_Reader["szCountry"].ToString();

                            //}

                            //////////////////////////////////////////////////////////////////////
                            Hotel_zip_post_code.Text = RFPreview_Reader["szZipCode"].ToString();
                            Hotel_Main_phone.Text = RFPreview_Reader["szHotelPhone"].ToString();

                            ///////////////////////// diamond rating RBL ////////////////////////
                            if (RFPreview_Reader["szDiamondRating"].ToString() == string.Empty)
                            {
                                AAAating.SelectedValue = null;
                            }
                            else
                            {
                                AAAating.SelectedValue = RFPreview_Reader["szDiamondRating"].ToString();

                            }

                            ////////////////////////// mobile star rating RBL ///////////////////////
                            if (RFPreview_Reader["szStarRating"].ToString() == string.Empty)
                            {
                                MobileStaRate.SelectedValue = null;
                            }
                            else
                            {

                                MobileStaRate.SelectedValue = RFPreview_Reader["szStarRating"].ToString();
                            }
                            /////////////////////////////////////////////////////////////////////////////


                            Hotel_brief_descipt.Text = RFPreview_Reader["szHotelDesc"].ToString();
                            Enviroment_Program.Text = RFPreview_Reader["szEnvCertPrg"].ToString();


                            // recycle RBL ///////////////////////////////////////////////////
                            if (RFPreview_Reader["szRecyclingPrg"].ToString() == string.Empty)
                            {
                                RadioButtonList_avtiveRecycle.SelectedValue = null;
                            }
                            else if (RFPreview_Reader["szRecyclingPrg"].ToString() == "Yes")
                            {
                                RadioButtonList_avtiveRecycle.SelectedValue = "Yes";
                            }
                            else if (RFPreview_Reader["szRecyclingPrg"].ToString() == "No")
                            {

                                RadioButtonList_avtiveRecycle.SelectedValue = "No";
                            }
                            // //////////////////////////////////////////////////////////////

                            // RespCleaners RBL /////////////////////////////////////////////
                            if (RFPreview_Reader["szUtilEnvRespCleaners"].ToString() == string.Empty)
                            {
                                RadioButtonList_Property_Responsible_Cleaners.SelectedValue = null;
                            }
                            else if (RFPreview_Reader["szRecyclingPrg"].ToString() == "Yes")
                            {
                                RadioButtonList_Property_Responsible_Cleaners.SelectedValue = "Yes";
                            }
                            else if (RFPreview_Reader["szRecyclingPrg"].ToString() == "No")
                            {

                                RadioButtonList_Property_Responsible_Cleaners.SelectedValue = "No";
                            }

                            // water conserve RBL ////////////////////////////////////////////////////
                            if (RFPreview_Reader["szActiveWaterCnsvPrg"].ToString() == string.Empty)
                            {
                                RadioButtonList_Property_WaterConserve.SelectedValue = null;
                            }
                            else if (RFPreview_Reader["szActiveWaterCnsvPrg"].ToString() == "Yes")
                            {
                                RadioButtonList_Property_WaterConserve.SelectedValue = "Yes";
                            }
                            else if (RFPreview_Reader["szActiveWaterCnsvPrg"].ToString() == "No")
                            {
                                RadioButtonList_Property_WaterConserve.SelectedValue = "Yes";
                            }

                        }
                        //else
                        //{

                        //    Hotelcountry.SelectedValue = "United States";

                        //}

                    }

                }

            }

        }

        protected void UpdateHotelInfo()
        {
            using (SqlConnection HotelInfoOne_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand HotelInfoOne_cmd = new SqlCommand("dbo.sp_RFP_HotelPatialInfoOne", HotelInfoOne_Conn))
                {
                    HotelInfoOne_cmd.CommandText = "dbo.sp_RFP_HotelPatialInfoOne";
                    HotelInfoOne_cmd.CommandType = CommandType.StoredProcedure;
                    HotelInfoOne_cmd.CommandTimeout = 0;

                    // first param
                    SqlParameter HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@LRFPID";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.Int;
                    HotelInfoOne_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation");

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);

                    // 7th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szAddress";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.NVarChar;
                    HotelInfoOne_Param.Value = Hotel_Addr_One.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);

                    // 7a th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szAddressTwo";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfoOne_Param.Value = Hotel_Addr_Two.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);


                    // 8th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szCity";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.NVarChar;
                    HotelInfoOne_Param.Value = Hotel_city.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);


                    // 9th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szState";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.NVarChar;
                    HotelInfoOne_Param.Value = HotelInfo_State.SelectedValue.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);


                    // 10th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szZipCode";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.NVarChar;
                    HotelInfoOne_Param.Value = Hotel_zip_post_code.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);


                    // 11th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szCountry";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.NVarChar;
                    HotelInfoOne_Param.Value = Hotelcountry.SelectedValue.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);

                    // 2nd param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szSabrePropertyNo";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfoOne_Param.Value = Sabre_PCode.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);

                    // 3rd param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szApolloPropertyNo";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfoOne_Param.Value = Apollo_Pcode.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);


                    // 4th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szSabreChainCode";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfoOne_Param.Value = Sabre_Chain_Code.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);


                    // 5th param
                    HotelInfoOne_Param = HotelInfoOne_cmd.CreateParameter();
                    HotelInfoOne_Param.ParameterName = "@szApolloChainCode";
                    HotelInfoOne_Param.Direction = ParameterDirection.Input;
                    HotelInfoOne_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfoOne_Param.Value = Apollo_Chain_Code.Text.ToString();

                    HotelInfoOne_cmd.Parameters.Add(HotelInfoOne_Param);

                    HotelInfoOne_Conn.Open();

                    // execute entry
                    HotelInfoOne_cmd.ExecuteNonQuery();
                }
            }

            // update table
            using (SqlConnection HotelInfo_Contacts_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand HotelInfo_Contacts_cmd = new SqlCommand("dbo.sp_RFP_insertHotelInfo_Contacts", HotelInfo_Contacts_Conn))
                {
                    HotelInfo_Contacts_cmd.CommandText = "dbo.sp_RFP_insertHotelInfo_Contacts";
                    HotelInfo_Contacts_cmd.CommandType = CommandType.StoredProcedure;
                    HotelInfo_Contacts_cmd.CommandTimeout = 0;

                    // 1st param
                    SqlParameter HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@LRFPID";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.Int;
                    HotelInfo_Contacts_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation");

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);


                    // 2nd param
                    HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@szName";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Contacts_Param.Value = Sales_Contact_Name.Text.ToString();

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);



                    // 3rd param
                    HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@szTitle";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Contacts_Param.Value = Sales_Contact_Title.Text.ToString();

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);


                    // 4th param
                    HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@szHotelPhone";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Contacts_Param.Value = Hotel_Main_phone.Text.ToString();

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);



                    // 5th param
                    HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@szPhone";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Contacts_Param.Value = Sales_Contact_Telephone.Text.ToString();

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);


                    // 6th param
                    HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@szFax";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Contacts_Param.Value = Sales_Contact_Fax.Text.ToString();

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);



                    // 7th param
                    HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@szEmail";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Contacts_Param.Value = Sales_Contact_Email.Text.ToString();

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);


                    // 8th param
                    HotelInfo_Contacts_Param = HotelInfo_Contacts_cmd.CreateParameter();
                    HotelInfo_Contacts_Param.ParameterName = "@szDirector";
                    HotelInfo_Contacts_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Contacts_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Contacts_Param.Value = Director_of_Sales.Text.ToString();

                    HotelInfo_Contacts_cmd.Parameters.Add(HotelInfo_Contacts_Param);


                    HotelInfo_Contacts_Conn.Open();

                    // execute entry
                    HotelInfo_Contacts_cmd.ExecuteNonQuery();
                }
            }

            // update table
            using (SqlConnection HotelInfo_Property_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand HotelInfo_Property_cmd = new SqlCommand("dbo.sp_RFP_insertHotelInfo_Property", HotelInfo_Property_Conn))
                {
                    HotelInfo_Property_cmd.CommandText = "dbo.sp_RFP_insertHotelInfo_Property";
                    HotelInfo_Property_cmd.CommandType = CommandType.StoredProcedure;
                    HotelInfo_Property_cmd.CommandTimeout = 0;

                    // 1st param
                    SqlParameter HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@LRFPID";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.Int;
                    HotelInfo_Property_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation");

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 2nd param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szPrefHotelName";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = Hotel_Name.Text.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 2and param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szGeneralMgr";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = Hotel_general_mgr.Text.ToString(); 

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 3rd param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szWebSite";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = Hotel_Web_Site.Text.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);



                    // 4th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szDiamondRating";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = AAAating.SelectedValue.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 5th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szStarRating";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = MobileStaRate.SelectedValue.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);



                    // 5th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szHotelDesc";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.NVarChar;
                    HotelInfo_Property_Param.Value = Hotel_brief_descipt.Text.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);



                    // 6th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szEnvCertPrg";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = Enviroment_Program.Text.ToString(); 

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 7th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szRecyclingPrg";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = RadioButtonList_avtiveRecycle.SelectedValue.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 7th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szUtilEnvRespCleaners";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = RadioButtonList_Property_Responsible_Cleaners.SelectedValue.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 8th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szActiveWaterCnsvPrg";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = RadioButtonList_Property_WaterConserve.SelectedValue.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    // 8th param
                    HotelInfo_Property_Param = HotelInfo_Property_cmd.CreateParameter();
                    HotelInfo_Property_Param.ParameterName = "@szDirectorOfSales";
                    HotelInfo_Property_Param.Direction = ParameterDirection.Input;
                    HotelInfo_Property_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_Property_Param.Value = Director_of_Sales.Text.ToString();

                    HotelInfo_Property_cmd.Parameters.Add(HotelInfo_Property_Param);


                    HotelInfo_Property_Conn.Open();

                    // execute entry
                    HotelInfo_Property_cmd.ExecuteNonQuery();


                }
            }


        }

        //////////////////////////////////////////////////////////////
        // select ammenities /////////////////////////////////////////
        protected void getammenities()
        {

            using (SqlConnection AmmenitesSelect_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand AmmenitesSelect_cmd = new SqlCommand("SELECT szDiscountOff, szLastRoomAvail, szAddCmtnsRats, szVat, szExtendGroupNegRate, szConsortiaRate, szLowestConsortiaRate, szAverageConsortiaRate, szHighestConsortiaRate, szCorpRate, szRackRate, szAsscociationRate, szRecruitRatesSeptDec, szRenovations, szRenovationsDesc, szRoomCnt, szSuiteCnt, szGuaranteeNotToWalkOurGuests, szHotelGrpAffiliation, szAmenitiesIncluded, szIsPropVirtuosoMem, szIsVirtuosoAmmenInc, szVirtuosoAmmen, szEnsureAmenty, szITinPublicSpaceInc, szItinGuestRoomInc, szRestaurant, szBarLounge, szToiletries FROM tbl_Hotel_PHC_Property WHERE LRFPID = " + Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation"), AmmenitesSelect_Conn))
                {
                    AmmenitesSelect_cmd.CommandType = CommandType.Text;
                    AmmenitesSelect_cmd.CommandTimeout = 0;

                    AmmenitesSelect_Conn.Open();

                    using (SqlDataReader AmmenitesSelect_Reader = AmmenitesSelect_cmd.ExecuteReader())
                    {
                        if (AmmenitesSelect_Reader.Read())
                        {

                            ////////////////////// ammeneties /////////////////////////////////////////////////
                            percentageRecieveOffRate.Text = AmmenitesSelect_Reader["szDiscountOff"].ToString();

                            ////////////////////////// Last Room available RBL ////////////////////////////////
                            if (AmmenitesSelect_Reader["szLastRoomAvail"].ToString() == string.Empty)
                            {
                                Radiolist_Floating_Bar_Dynamic.SelectedValue = null;
                            }
                            else if (AmmenitesSelect_Reader["szLastRoomAvail"].ToString() == "Y")
                            {
                                Radiolist_Floating_Bar_Dynamic.SelectedValue = "Y";
                            }
                            else if (AmmenitesSelect_Reader["szLastRoomAvail"].ToString() == "N")
                            {
                                Radiolist_Floating_Bar_Dynamic.SelectedValue = "N";
                            }
                            //////////////////////////////////////////////////////////////////////////////////

                            AddCmntsRates.Text = AmmenitesSelect_Reader["szAddCmtnsRats"].ToString();

                            // Vat RBL ///////////////////////////////////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szVat"].ToString() == string.Empty)
                            {
                                RadioButtonList_VatType.SelectedValue = null;
                            }
                            else if (AmmenitesSelect_Reader["szVat"].ToString() == "Y")
                            {
                                RadioButtonList_VatType.SelectedValue = "Y";
                            }
                            else if (AmmenitesSelect_Reader["szVat"].ToString() == "N")
                            {
                                RadioButtonList_VatType.SelectedValue = "N";
                            }
                            ////////////////////////////////////////////////////////////////////////////////////

                            // ExtendGroupNegRate RBL /////////////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szExtendGroupNegRate"].ToString() == string.Empty)
                            {
                                RadioButtonList_WoulextendRateYN.SelectedValue = null;
                            }
                            else if (AmmenitesSelect_Reader["szExtendGroupNegRate"].ToString() == "Yes")
                            {
                                RadioButtonList_WoulextendRateYN.SelectedValue = "Yes";

                            }
                            else if (AmmenitesSelect_Reader["szExtendGroupNegRate"].ToString() == "No")
                            {
                                RadioButtonList_WoulextendRateYN.SelectedValue = "No";
                            }
                            //////////////////////////////////////////////////////////////////////////

                            ConsortaRate.Text = AmmenitesSelect_Reader["szConsortiaRate"].ToString();
                            Consortia_floor_Low_Rate.Text = AmmenitesSelect_Reader["szLowestConsortiaRate"].ToString();
                            Consortia_average_mediaum_Rate.Text = AmmenitesSelect_Reader["szAverageConsortiaRate"].ToString();
                            Consortia_high_Rate.Text = AmmenitesSelect_Reader["szHighestConsortiaRate"].ToString();
                            Corp_Rate.Text = AmmenitesSelect_Reader["szCorpRate"].ToString();
                            Rack_Rate.Text = AmmenitesSelect_Reader["szRackRate"].ToString();
                            Assoc_Rate.Text = AmmenitesSelect_Reader["szAsscociationRate"].ToString();
                            Ovation_Recruitment_Rate.Text = AmmenitesSelect_Reader["szRecruitRatesSeptDec"].ToString();
                            Amenities_Offered_to_Ovation.Text = AmmenitesSelect_Reader["szAmenitiesIncluded"].ToString();

                            // IsPropVirtuosoMem RBL /////////////////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szIsPropVirtuosoMem"].ToString() == string.Empty)
                            {
                                RadioButtonList_IsProperty_Virtuoso.SelectedValue = null;
                                istheVirtuosoamenityincludedPNL.Visible = true;
                            }
                            else if (AmmenitesSelect_Reader["szIsPropVirtuosoMem"].ToString() == "Yes")
                            {
                                RadioButtonList_IsProperty_Virtuoso.SelectedValue = "Yes";
                                istheVirtuosoamenityincludedPNL.Visible = true;
                            }
                            else if (AmmenitesSelect_Reader["szIsPropVirtuosoMem"].ToString() == "No")
                            {
                                RadioButtonList_IsProperty_Virtuoso.SelectedValue = "No";
                                istheVirtuosoamenityincludedPNL.Visible = false;
                            }
                            //////////////////////////////////////////////////////////////////////////////

                            // Is VirtuosoAmmen Included RBL ////////////////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szIsVirtuosoAmmenInc"].ToString() == string.Empty)
                            {
                                RadioButtonList_IsVirtuoso_included.SelectedValue = null;
                                whatisVirtuosoamenity_Pnl.Visible = true;
                                Ammenities_ensurePnl.Visible = true;
                                Ammenities_VirtuosoAmenity.Text = string.Empty;
                                Ammenities_ensureClient_VirtuosoAmenity.Text = string.Empty;

                            }
                            else if (AmmenitesSelect_Reader["szIsVirtuosoAmmenInc"].ToString() == "Yes")
                            {

                                RadioButtonList_IsVirtuoso_included.SelectedValue = "Yes";
                                whatisVirtuosoamenity_Pnl.Visible = true;
                                Ammenities_ensurePnl.Visible = true;
                                Ammenities_VirtuosoAmenity.Text = AmmenitesSelect_Reader["szVirtuosoAmmen"].ToString();
                                Ammenities_ensureClient_VirtuosoAmenity.Text = AmmenitesSelect_Reader["szEnsureAmenty"].ToString();

                            }
                            else if (AmmenitesSelect_Reader["szIsVirtuosoAmmenInc"].ToString() == "No")
                            {
                                RadioButtonList_IsVirtuoso_included.SelectedValue = "No";
                                whatisVirtuosoamenity_Pnl.Visible = false;
                                Ammenities_ensurePnl.Visible = false;
                            }
                            //////////////////////////////////////////////////////////////////////////////

                            // internet Inc in guest Rm RBL //////////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szItinGuestRoomInc"].ToString() == string.Empty)
                            {
                                internet_Access_inc_NegRate_GuestRoom.SelectedValue = null;
                            }
                            else if (AmmenitesSelect_Reader["szItinGuestRoomInc"].ToString() == "Yes")
                            {
                                internet_Access_inc_NegRate_GuestRoom.SelectedValue = "Yes";
                            }
                            else if (AmmenitesSelect_Reader["szItinGuestRoomInc"].ToString() == "No")
                            {
                                internet_Access_inc_NegRate_GuestRoom.SelectedValue = "No";
                            }
                            //////////////////////////////////////////////////////////////////////////////

                            // internet Inc in public space RBL //////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szITinPublicSpaceInc"].ToString() == string.Empty)
                            {
                                internet_Access_inc_NegRate_publicspace.SelectedValue = null;
                            }
                            else if (AmmenitesSelect_Reader["szITinPublicSpaceInc"].ToString() == "Yes")
                            {
                                internet_Access_inc_NegRate_publicspace.SelectedValue = "Yes";
                            }
                            else if (AmmenitesSelect_Reader["szITinPublicSpaceInc"].ToString() == "No")
                            {
                                internet_Access_inc_NegRate_publicspace.SelectedValue = "No";
                            }
                            //////////////////////////////////////////////////////////////////////////////


                            Amenities_WhatBrandFor_GuestRoom_Bathroom.Text = AmmenitesSelect_Reader["szToiletries"].ToString();
                            Amenites_property_resturants_names.Text = AmmenitesSelect_Reader["szRestaurant"].ToString();
                            Amenites_property_Bar_Lounge_names.Text = AmmenitesSelect_Reader["szBarLounge"].ToString();


                            // Renovations RBL ///////////////////////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szRenovations"].ToString() == string.Empty)
                            {
                                Amenites_property_renovation_2014.SelectedValue = null;
                                renovationDates_detailsPnl.Visible = true;
                                Amenites_property_renovationDates_details.Text = string.Empty;

                            }
                            else if (AmmenitesSelect_Reader["szRenovations"].ToString() == "Yes")
                            {
                                Amenites_property_renovation_2014.SelectedValue = "Yes";
                                renovationDates_detailsPnl.Visible = true;
                                Amenites_property_renovationDates_details.Text = AmmenitesSelect_Reader["szRenovationsDesc"].ToString();
                            }
                            else if (AmmenitesSelect_Reader["szRenovations"].ToString() == "No")
                            {
                                Amenites_property_renovation_2014.SelectedValue = "No";
                                renovationDates_detailsPnl.Visible = false;
                            }
                            /////////////////////////////////////////////////////////////////////////////

                            Ammenities_Num_roomshotel.Text = AmmenitesSelect_Reader["szRoomCnt"].ToString();
                            Ammenities_Num_suiteshotel.Text = AmmenitesSelect_Reader["szSuiteCnt"].ToString();


                            // no to walk RBL //////////////////////////////////////////////////////////////
                            if (AmmenitesSelect_Reader["szGuaranteeNotToWalkOurGuests"].ToString() == string.Empty)
                            {
                                Amenities_noToWalk.SelectedValue = null;
                            }
                            else if (AmmenitesSelect_Reader["szGuaranteeNotToWalkOurGuests"].ToString() == "Yes")
                            {
                                Amenities_noToWalk.SelectedValue = "Yes";
                            }
                            else if (AmmenitesSelect_Reader["szGuaranteeNotToWalkOurGuests"].ToString() == "No")
                            {
                                Amenities_noToWalk.SelectedValue = "No";
                            }
                            ///////////////////////////////////////////////////////////////////////////////

                            Aemnites_Affilation_Details.Text = AmmenitesSelect_Reader["szHotelGrpAffiliation"].ToString();

                        }
                        //else
                        //{
                        //    // do somthing

                        //}


                    }


                }

            }

            checkboxes();


        }


        //////////////////////////////////////////////////////////////
        /// <summary>
        /// //////// check boxes for ammeneties section 
        /// </summary>
        protected void checkboxes()
        {
            // Check boxes in ammenitties and radio button list /////////////////////////////////////////////////////////////////////////////
            int mhid = 0;
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
            using (SqlConnection GetFeaturesBlockOne_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand GetFeaturesBlockOne_cmd = new SqlCommand("SELECT lFeatureID from dbo.Tbl_Hotel_PHC_Features_Property WHERE mhid = @mhid AND LRFPID = @LRFPID", GetFeaturesBlockOne_Conn))
                {
                    GetFeaturesBlockOne_cmd.CommandType = CommandType.Text;
                    GetFeaturesBlockOne_cmd.CommandTimeout = 0;

                    GetFeaturesBlockOne_cmd.Parameters.AddWithValue("@mhid", mhid);
                    GetFeaturesBlockOne_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                    GetFeaturesBlockOne_Conn.Open();

                    using (SqlDataReader GetFeaturesBlockOne_Reader = GetFeaturesBlockOne_cmd.ExecuteReader())
                    {

                        //Amenities_Property_offering.DataSource = GetFeaturesBlockOne_Reader;
                        // Amenities_Property_offering.DataBind();
                        while (GetFeaturesBlockOne_Reader.Read())
                        {
                            ListItem Amenities_PropertyOne = Amenities_Property_offering.Items.FindByValue(GetFeaturesBlockOne_Reader["lFeatureID"].ToString());
                            ListItem Amenities_PropertyTwo = Amenities_Rooms_Equipped_With.Items.FindByValue(GetFeaturesBlockOne_Reader["lFeatureID"].ToString());

                            if (Amenities_PropertyOne != null)
                            {
                                Amenities_PropertyOne.Selected = true;
                            }

                            if (Amenities_PropertyTwo != null)
                            {
                                Amenities_PropertyTwo.Selected = true;
                            }



                        }

                        if (GetFeaturesBlockOne_Reader.Read())
                        {

                            Amenites_property_non_smoking.SelectedValue = GetFeaturesBlockOne_Reader["lFeatureID"].ToString();
                        }
                    }
                }

            }

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void updateAmmeneites()
        {
            int mymhid = 0;

            using (SqlConnection HotelInfo_PropertyUpdate_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand HotelInfo_PropertyUpdate_cmd = new SqlCommand("dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo", HotelInfo_PropertyUpdate_Conn))
                {
                    HotelInfo_PropertyUpdate_cmd.CommandText = "dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo";
                    HotelInfo_PropertyUpdate_cmd.CommandType = CommandType.StoredProcedure;
                    HotelInfo_PropertyUpdate_cmd.CommandTimeout = 0;

                    // st param
                    SqlParameter HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@LRFPID";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);

                    // nd parem
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szDiscountOff";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = percentageRecieveOffRate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    // rd parem
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szLastRoomAvail";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Radiolist_Floating_Bar_Dynamic.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szAddCmtnsRats";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.NVarChar;
                    HotelInfo_PropertyUpdate_Param.Value = AddCmntsRates.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szVat";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_VatType.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szExtendGroupNegRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_WoulextendRateYN.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szConsortiaRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = ConsortaRate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szLowestConsortiaRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Consortia_floor_Low_Rate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szAverageConsortiaRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Consortia_average_mediaum_Rate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szHighestConsortiaRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Consortia_high_Rate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szCorpRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Corp_Rate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szRackRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Rack_Rate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szAsscociationRate";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Assoc_Rate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szRecruitRatesSeptDec";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Ovation_Recruitment_Rate.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szAmenitiesIncluded";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Amenities_Offered_to_Ovation.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szIsPropVirtuosoMem";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_IsProperty_Virtuoso.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szIsVirtuosoAmmenInc";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = RadioButtonList_IsVirtuoso_included.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szVirtuosoAmmen";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Ammenities_VirtuosoAmenity.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szEnsureAmenty";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Ammenities_ensureClient_VirtuosoAmenity.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szItinGuestRoomInc";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = internet_Access_inc_NegRate_GuestRoom.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szITinPublicSpaceInc";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = internet_Access_inc_NegRate_publicspace.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szToiletries";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Amenities_WhatBrandFor_GuestRoom_Bathroom.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szRestaurant";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Amenites_property_resturants_names.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szBarLounge";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Amenites_property_Bar_Lounge_names.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szRenovations";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Amenites_property_renovation_2014.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szRenovationsDesc";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Amenites_property_renovationDates_details.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szRoomCnt";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Ammenities_Num_roomshotel.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szSuiteCnt";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Ammenities_Num_suiteshotel.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szGuaranteeNotToWalkOurGuests";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Amenities_noToWalk.SelectedValue.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);



                    //th param
                    HotelInfo_PropertyUpdate_Param = HotelInfo_PropertyUpdate_cmd.CreateParameter();
                    HotelInfo_PropertyUpdate_Param.ParameterName = "@szHotelGrpAffiliation";
                    HotelInfo_PropertyUpdate_Param.Direction = ParameterDirection.Input;
                    HotelInfo_PropertyUpdate_Param.SqlDbType = SqlDbType.VarChar;
                    HotelInfo_PropertyUpdate_Param.Value = Aemnites_Affilation_Details.Text.ToString();

                    HotelInfo_PropertyUpdate_cmd.Parameters.Add(HotelInfo_PropertyUpdate_Param);


                    HotelInfo_PropertyUpdate_Conn.Open();

                    HotelInfo_PropertyUpdate_cmd.ExecuteNonQuery();

                }

                // first get mhid
                using (SqlCommand HotelInfo_PropertyGetmhid_cmd = new SqlCommand("SELECT mhid from dbo.Tbl_Hotel_PHC_Property WHERE LRFPID = @LRFPID", HotelInfo_PropertyUpdate_Conn))
                {
                    HotelInfo_PropertyGetmhid_cmd.CommandType = CommandType.Text;
                    HotelInfo_PropertyGetmhid_cmd.CommandTimeout = 0;

                    HotelInfo_PropertyGetmhid_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));

                    using (SqlDataReader GetMymhid_Reader = HotelInfo_PropertyGetmhid_cmd.ExecuteReader())
                    {
                        if (GetMymhid_Reader.Read())
                        {
                            mymhid = GetMymhid_Reader.GetInt32(GetMymhid_Reader.GetOrdinal("mhid"));
                        }
                    }
                }
            }

            using (SqlConnection FeaturesPropertyIjnsert_Conn = new SqlConnection(RFPDBconnStr))
            {

                FeaturesPropertyIjnsert_Conn.Open();

                // delete so we can start over like an update
                using (SqlCommand FeaturesPropertyIjnsert_cmd = new SqlCommand("DELETE FROM dbo.tbl_Hotel_PHC_Features_Property WHERE LRFPID = @LRFPID", FeaturesPropertyIjnsert_Conn))
                {
                    //FeaturesPropertyIjnsert_cmd.CommandText = "dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo";
                    FeaturesPropertyIjnsert_cmd.CommandType = CommandType.Text;
                    FeaturesPropertyIjnsert_cmd.CommandTimeout = 0;

                    //FeaturesPropertyIjnsert_Conn.Open();

                    /// radio button no smoking
                    FeaturesPropertyIjnsert_cmd.Parameters.Clear();
                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                    FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
                }

                // return;

                // insert in Features Property table ///
                using (SqlCommand FeaturesPropertyIjnsert_cmd = new SqlCommand("INSERT INTO dbo.tbl_Hotel_PHC_Features_Property(mhid,LRFPID,szYear,lFeatureID)VALUES(@mhid,@LRFPID,@szYear,@lFeatureID)", FeaturesPropertyIjnsert_Conn))
                {
                    //FeaturesPropertyIjnsert_cmd.CommandText = "dbo.sp_RFP_UpDate_PropertyTbl_AfterinsertHotelinfo";
                    FeaturesPropertyIjnsert_cmd.CommandType = CommandType.Text;
                    FeaturesPropertyIjnsert_cmd.CommandTimeout = 0;

                    foreach (ListItem feature in Amenities_Property_offering.Items)
                    {
                        if (feature.Selected)
                        {
                            // do inset
                            // first check box list
                            FeaturesPropertyIjnsert_cmd.Parameters.Clear();
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@mhid", mymhid);
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@szYear", TheYear.Value.ToString());
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@lFeatureID", feature.Value);
                            FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
                        }


                    }
                    foreach (ListItem featureEquip in Amenities_Rooms_Equipped_With.Items)
                    {
                        if (featureEquip.Selected)
                        {
                            // second check box list
                            FeaturesPropertyIjnsert_cmd.Parameters.Clear();
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@mhid", mymhid);
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@szYear", TheYear.Value.ToString());
                            FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@lFeatureID", featureEquip.Value);
                            FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
                        }

                    }

                    /// radio button no smoking
                    FeaturesPropertyIjnsert_cmd.Parameters.Clear();
                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@mhid", mymhid);
                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@szYear", TheYear.Value.ToString());
                    FeaturesPropertyIjnsert_cmd.Parameters.AddWithValue("@lFeatureID", Amenites_property_non_smoking.SelectedValue);
                    FeaturesPropertyIjnsert_cmd.ExecuteNonQuery();
                }
            }

        }
        protected void selectMarketing()
        {
            using (SqlConnection MarketingSelect_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand MarketingSelect_cmd = new SqlCommand("SELECT szIncentive FROM tbl_Hotel_PHC_Property WHERE LRFPID = " + Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation") + "", MarketingSelect_Conn))
                {
                    MarketingSelect_cmd.CommandType = CommandType.Text;
                    MarketingSelect_cmd.CommandTimeout = 0;

                    MarketingSelect_Conn.Open();

                    using (SqlDataReader MarketingSelect_Reader = MarketingSelect_cmd.ExecuteReader())
                    {
                        if (MarketingSelect_Reader.Read())
                        {

                            if (MarketingSelect_Reader["szIncentive"].ToString() == "1")
                            {
                                platinum_Package.Checked = true;
                            }
                            else if (MarketingSelect_Reader["szIncentive"].ToString() == "2")
                            {
                                gold_Package.Checked = true;
                            }
                            else if (MarketingSelect_Reader["szIncentive"].ToString() == "3")
                            {
                                silver_Package.Checked = true;
                            }

                        }
                    }

                }
            }
        }

        // update marketing ///////////////////////////////////////////////////////////////////////////
        protected void updateMarkeing()
        {

            string marketingpacksUpdate = string.Empty;

            if (platinum_Package.Checked == true)
            {
                marketingpacksUpdate = "1";
            }
            else if (gold_Package.Checked == true)
            {
                marketingpacksUpdate = "2";
            }
            else if (silver_Package.Checked == true)
            {
                marketingpacksUpdate = "3";
            }

            using (SqlConnection MarketingUpdate_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand MarketingUpdate_cmd = new SqlCommand("UPDATE dbo.tbl_Hotel_PHC_Property SET szIncentive = @szIncentive WHERE LRFPID = @LRFPID", MarketingUpdate_Conn))
                {
                    MarketingUpdate_cmd.CommandType = CommandType.Text;
                    MarketingUpdate_cmd.CommandTimeout = 0;

                    MarketingUpdate_Conn.Open();

                    MarketingUpdate_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                    MarketingUpdate_cmd.Parameters.AddWithValue("@szIncentive", marketingpacksUpdate.ToString());
                    MarketingUpdate_cmd.ExecuteNonQuery();
                }
            }

        }

        // select electronic signiture //////////////////////////////////////////////////////////
        protected void selectElectronicSig()
        {

            using (SqlConnection RFPreview_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand RFPreview_cmd = new SqlCommand("SELECT szElectronicSig, szElectronicSigCmt FROM Tbl_Hotel_PHC_HotelInfoPartialOne WHERE LRFPID = " + Decrypt(HttpContext.Current.Request.QueryString["ORFP"].ToString(), "trappOvation") + "", RFPreview_Conn))
                {
                    RFPreview_cmd.CommandType = CommandType.Text;
                    RFPreview_cmd.CommandTimeout = 0;

                    RFPreview_Conn.Open();

                    using (SqlDataReader RFPreview_Reader = RFPreview_cmd.ExecuteReader())
                    {
                        if (RFPreview_Reader.Read())
                        {
                            Electronic_Sig_title.Text = RFPreview_Reader["szElectronicSig"].ToString();
                            Electronic_Sig_comments.Text = RFPreview_Reader["szElectronicSigCmt"].ToString();
                        }
                    }
                }
            }

        }
    }
}
