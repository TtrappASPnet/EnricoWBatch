using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text.RegularExpressions;
using Telerik.Web.UI;

namespace OvationTest
{
    public partial class _Default
    {
        // marketing button click sub
        protected void MarketingPacksNextBtn_Click(object sender, EventArgs e)
        {
            // define our next tab to be selected on full validation of form /////////////
            RadTab EelectronicTabMktButton = OvationTabs.FindTabByValue("Electronic_Sig");

            updateMarkeing();
            //selectMarketing();
            UpdateHotelInfo();
            updateAmmeneites();


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
               


                EelectronicTabMktButton.Selected = true;
                //progressTextHotelInfo.Text = "Hotel Information | Complete";
                //progressTextHotelInfo.ForeColor = System.Drawing.Color.Black;
                //progressbarAmmen.Text = "2014 Rates & Amenities | Complete";
                //progressbarAmmen.ForeColor = System.Drawing.Color.Black;
                //progressBarTxtMarketingPackages.Text = "Marketing Packages | Complete";
                //progressBarTxtMarketingPackages.ForeColor = System.Drawing.Color.Bla

        }

    }
}
