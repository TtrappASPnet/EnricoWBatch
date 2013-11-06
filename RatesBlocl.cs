using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace OvationTest
{
    public partial class _Default
    {
        //  MAIN REPEATER DATABOUND EVENT ROOMCATEGORY FROUP
        protected void roomcategoryGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // declare our varibles
            Repeater catsRates = e.Item.FindControl("MultipleDates") as Repeater;
            Literal UserSeasonID = e.Item.FindControl("txtSeason") as Literal;
            HiddenField UserSeasonHiddenID = e.Item.FindControl("seaonNumber") as HiddenField;
            LinkButton AddseasonBtn = e.Item.FindControl("AddNewCategoryNoReapeat") as LinkButton;
            //LinkButton HiddenLinkButton = e.Item.FindControl("UpdateStartDateEndDate") as LinkButton;
            RadDatePicker SeasonEndDatePicker = e.Item.FindControl("RMCatEndDte_Start") as RadDatePicker;
            RadDatePicker SeasonStartDatePicker = e.Item.FindControl("RMCatStDte_Start") as RadDatePicker;
            RequiredFieldValidator firtRowValid = e.Item.FindControl("RMCatStDte_Start_Val") as RequiredFieldValidator;
            RequiredFieldValidator firtRowValidTwo = e.Item.FindControl("RMCatEndDte_Start_Val") as RequiredFieldValidator;
            HiddenField readSeason = e.Item.FindControl("testreadSeason") as HiddenField;


            // second repeater to bind that has the categories in them and rates 

            //RepeaterItem innerRepeaterTwo = ((RepeaterItem)(catsRates.NamingContainer));

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // get index number and add 1 to the number and then add it to hidden feild
                int seasNum = e.Item.ItemIndex + 1;
                readSeason.Value = "Season #" + seasNum;
                ////////////////////////////////////////////////////////////////////////////

                // bind literal here to show what season number //
                UserSeasonID.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Start Date & End Date for Season # ";
                // un-comment for testing
                UserSeasonHiddenID.Value = DataBinder.Eval(e.Item.DataItem, "LID").ToString();
                CalST.Value = SeasonStartDatePicker.UniqueID;

                ///// here we check is last end date is 12/31/2014 if it is, next start date will be 1/1/2015 so we update database table and column too 1/1/2014
               ///// and do an ajaxified style update, for some reason add new season pops up again a new post back makes it goes away, prob something to do with repater.databind() method.
                
                if (Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "dtSTdate")) == Convert.ToDateTime("1/1/2015 12:00:00 AM"))
                {
                    using (SqlConnection update_seasonName_Conn = new SqlConnection(RFPDBconnStr))
                    {
                        using (SqlCommand update_seasonName_cmd = new SqlCommand("UPDATE Tbl_Hotel_PHC_AmmenRmSeasons SET dtSTdate = @dtSTdate WHERE(LID = @LID) AND (LRFPID = @LRFPID)", update_seasonName_Conn))
                        {
                            update_seasonName_cmd.CommandType = CommandType.Text;
                            update_seasonName_cmd.CommandTimeout = 0;

                            update_seasonName_Conn.Open();

                            update_seasonName_cmd.Parameters.AddWithValue("@LID", UserSeasonHiddenID.Value.ToString());
                            update_seasonName_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                            update_seasonName_cmd.Parameters.AddWithValue("@dtSTdate", Convert.ToDateTime("1/1/2014 12:00:00"));
                            update_seasonName_cmd.ExecuteNonQuery();



                            roomcategoryGroup.DataBind();

                            //RadAjaxPanel1.ResponseScripts.Add("alert('hi we need to post pack here to refresh the repeater....LOL');");
                            RadAjaxPanel1.ResponseScripts.Add(string.Format("__doPostBack('{0}', '');", RadAjaxPanel1.ClientID));
                            //RadAjaxPanel1.ResponseScripts.Add("OvationformLoader.show(RadAjaxPanel1.ClientID);");

                        }
                    }


                }

                // bind data to date picker with dbselected date
                SeasonStartDatePicker.DbSelectedDate = DataBinder.Eval(e.Item.DataItem, "dtSTdate", "{0:M/dd/yyyy}");

                ///////////////////////////////// update SeaonName column to reflect season # 1, season #2 etc /////////////////////////////
                using (SqlConnection update_seasonName_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand update_seasonName_cmd = new SqlCommand("UPDATE Tbl_Hotel_PHC_AmmenRmSeasons SET szSeaonName = @szSeaonName WHERE(LID = @LID) AND (LRFPID = @LRFPID)", update_seasonName_Conn))
                    {
                        update_seasonName_cmd.CommandType = CommandType.Text;
                        update_seasonName_cmd.CommandTimeout = 0;

                        update_seasonName_Conn.Open();

                        update_seasonName_cmd.Parameters.AddWithValue("@LID", UserSeasonHiddenID.Value.ToString());
                        update_seasonName_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                        update_seasonName_cmd.Parameters.AddWithValue("@szSeaonName", readSeason.Value.ToString());
                        update_seasonName_cmd.ExecuteNonQuery();


                    }
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (e.Item.ItemIndex == 0)  // roomcategoryGroup.Items.Count - 1
                {
                    lastID.Value = DataBinder.Eval(e.Item.DataItem, "LID").ToString();
                    Lastseason.Value = DataBinder.Eval(e.Item.DataItem, "LID").ToString();
                    //HttpContext.Current.Response.Write(SeasonStartDatePicker.DbSelectedDate);

                }


                if (e.Item.ItemIndex > 0)
                {
                    // hide link button on first record
                    //deleteseasonBtn.Visible = true;
                    //deleteseasonBtn.Attributes.Add("onClick", "confirmLinkDeleteSeason(this); return false;");
                    lastID.Value = DataBinder.Eval(e.Item.DataItem, "LID").ToString();

                }


                //////////////////////////////////////////////////////////////////
                // inner reapeater Bind - no records but show header template //// 
                // select statement get records from db //////////////////////////
                //////////////////////////////////////////////////////////////////

                // open database
                using (SqlConnection InnerRepeatRmCat_Conn = new SqlConnection(RFPDBconnStr))
                {
                    // start command object
                    using (SqlCommand InnerRepeatRmCat_cmd = new SqlCommand("dbo.sp_RFP_GetRmCatRebind", InnerRepeatRmCat_Conn))
                    {

                        InnerRepeatRmCat_cmd.CommandText = "dbo.sp_RFP_GetRmCatRebind";
                        InnerRepeatRmCat_cmd.CommandType = CommandType.StoredProcedure;
                        InnerRepeatRmCat_cmd.CommandTimeout = 0;

                        // first paraemter
                        SqlParameter InnerRepeatRmCat_Param = InnerRepeatRmCat_cmd.CreateParameter();
                        InnerRepeatRmCat_Param.ParameterName = "@LSID";
                        InnerRepeatRmCat_Param.Direction = ParameterDirection.Input;
                        InnerRepeatRmCat_Param.SqlDbType = SqlDbType.Int;
                        InnerRepeatRmCat_Param.Value = DataBinder.Eval(e.Item.DataItem, "LID").ToString();

                        InnerRepeatRmCat_cmd.Parameters.Add(InnerRepeatRmCat_Param);


                        // second paraemter
                        InnerRepeatRmCat_Param = InnerRepeatRmCat_cmd.CreateParameter();
                        InnerRepeatRmCat_Param.ParameterName = "@LRFPID";
                        InnerRepeatRmCat_Param.Direction = ParameterDirection.Input;
                        InnerRepeatRmCat_Param.SqlDbType = SqlDbType.Int;
                        InnerRepeatRmCat_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                        InnerRepeatRmCat_cmd.Parameters.Add(InnerRepeatRmCat_Param);

                        InnerRepeatRmCat_Conn.Open();

                        // start data reader
                        using (SqlDataReader InnerRepeatRmCat_Reader = InnerRepeatRmCat_cmd.ExecuteReader())
                        {
                            //Bind repeater
                            catsRates.DataSource = InnerRepeatRmCat_Reader;
                            catsRates.DataBind();
                        }
                    }
                    //close up db and release resources
                }

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {

                AddseasonBtn.CommandArgument = lastID.Value.ToString();//UserSeasonHiddenID.Value.ToString();
                // HttpContext.Current.Response.Write("Hello from footer");
                //Iamdone

            }

        }

        // main repeater room categories item command
        protected void roomcategoryGroup_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField addNewCatHidden = e.Item.FindControl("IDforRoomRateLSID") as HiddenField;

            switch (e.CommandName)
            {
                case "InsertSeason":
                    // insert new season
                    InsertNewSeason(e);
                    break;
                case "DoneRates":

                      //Page.Validate("seasonRmCatVal");
                      Page.Validate("DatesinRates_Blank");
                      Page.Validate("DatesinRatesEndDate_Blank");
                      Page.Validate("DatesinRatesCompare");

                      if (Page.IsValid)
                      {
                          Ovationscriptmgr.SetFocus(percentageRecieveOffRate.ClientID);
                      }
                    break;
                case "AddNewRMCategory":
                    // add new room category and rate
                    AddAnotherRoomAndRate(e);
                    break;

            }
        }

        void InsertNewSeason(RepeaterCommandEventArgs e)
        {
            Page.Validate("DatesinRates_Blank");
            Page.Validate("DatesinRatesEndDate_Blank");
            Page.Validate("DatesinRatesCompare");


            if (Page.IsValid)
            {
                // ADD NEW SEASON
                RmSeasonData.InsertParameters["LRFPID"].DefaultValue = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");
                RmSeasonData.InsertParameters["LID"].DefaultValue = e.CommandArgument.ToString();
                RmSeasonData.Insert();
                // rebind the repeater
                roomcategoryGroup.DataBind();

                
            }
            else
            {
                //senderPickerEnd.Clear();
                //senderPickerEnd.DateInput.DisplayText = "In-Valid";
                //senderPickerEnd.DateInput.CssClass = "enddateError";
            }

        }

        void AddAnotherRoomAndRate(RepeaterCommandEventArgs e)
        {
            // declare our repeater to rebind to
            Repeater DatesRates = e.Item.FindControl("MultipleDates") as Repeater;

            // first insert or add the new category and rate
            using (SqlConnection addnewRmCatRate_Conn = new SqlConnection(RFPDBconnStr))
            {

                // start cmd object
                using (SqlCommand addnewRmCatRate_cmd = new SqlCommand("dbo.sp_RFP_AddRmCatRate", addnewRmCatRate_Conn))
                {
                    addnewRmCatRate_cmd.CommandText = "dbo.sp_RFP_AddRmCatRate";
                    addnewRmCatRate_cmd.CommandType = CommandType.StoredProcedure;
                    addnewRmCatRate_cmd.CommandTimeout = 0;

                    // first paraemter
                    SqlParameter addnewRmCatRate_Param = addnewRmCatRate_cmd.CreateParameter();
                    addnewRmCatRate_Param.ParameterName = "@LRFPID";
                    addnewRmCatRate_Param.Direction = ParameterDirection.Input;
                    addnewRmCatRate_Param.SqlDbType = SqlDbType.Int;
                    addnewRmCatRate_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                    addnewRmCatRate_cmd.Parameters.Add(addnewRmCatRate_Param);

                    // second parameter
                    addnewRmCatRate_Param = addnewRmCatRate_cmd.CreateParameter();
                    addnewRmCatRate_Param.ParameterName = "@LSID";
                    addnewRmCatRate_Param.Direction = ParameterDirection.Input;
                    addnewRmCatRate_Param.SqlDbType = SqlDbType.Int;
                    addnewRmCatRate_Param.Value = e.CommandArgument.ToString();

                    addnewRmCatRate_cmd.Parameters.Add(addnewRmCatRate_Param);

                    addnewRmCatRate_Conn.Open();

                    // execute entry
                    addnewRmCatRate_cmd.ExecuteNonQuery();

                }

            }

            //// now do a select and rebind what we just inserted
            using (SqlConnection InnerRepeatRmCat_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand InnerRepeatRmCat_cmd = new SqlCommand("dbo.sp_RFP_GetRmCatRebind", InnerRepeatRmCat_Conn))
                {

                    InnerRepeatRmCat_cmd.CommandText = "dbo.sp_RFP_GetRmCatRebind";
                    InnerRepeatRmCat_cmd.CommandType = CommandType.StoredProcedure;
                    InnerRepeatRmCat_cmd.CommandTimeout = 0;

                    // first paraemter
                    SqlParameter InnerRepeatRmCat_Param = InnerRepeatRmCat_cmd.CreateParameter();
                    InnerRepeatRmCat_Param.ParameterName = "@LSID";
                    InnerRepeatRmCat_Param.Direction = ParameterDirection.Input;
                    InnerRepeatRmCat_Param.SqlDbType = SqlDbType.Int;
                    InnerRepeatRmCat_Param.Value = e.CommandArgument.ToString();

                    InnerRepeatRmCat_cmd.Parameters.Add(InnerRepeatRmCat_Param);


                    // second paraemter
                    InnerRepeatRmCat_Param = InnerRepeatRmCat_cmd.CreateParameter();
                    InnerRepeatRmCat_Param.ParameterName = "@LRFPID";
                    InnerRepeatRmCat_Param.Direction = ParameterDirection.Input;
                    InnerRepeatRmCat_Param.SqlDbType = SqlDbType.Int;
                    InnerRepeatRmCat_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                    InnerRepeatRmCat_cmd.Parameters.Add(InnerRepeatRmCat_Param);

                    InnerRepeatRmCat_Conn.Open();

                    using (SqlDataReader InnerRepeatRmCat_Reader = InnerRepeatRmCat_cmd.ExecuteReader())
                    {
                        DatesRates.DataSource = InnerRepeatRmCat_Reader;
                        DatesRates.DataBind();
                    }
                }
            }
        }

        protected void RMCatStDte_Start_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {


            RadDatePicker senderPickerStart = sender as RadDatePicker;
            RepeaterItem ParentRepeater = ((RepeaterItem)(senderPickerStart.NamingContainer));
            HiddenField SeasonHiddenID = ParentRepeater.FindControl("seaonNumber") as HiddenField;
            RadDatePicker EndDatePicker = ParentRepeater.FindControl("RMCatEndDte_Start") as RadDatePicker;


            Page.Validate("DatesinRates_Blank");


            if (Page.IsValid == true)
            {


                // script manager set focus
                //Control ContainerforScrptMgr = this.FindControl("OvationRFPGlobalScrptMgr1");
                //RadScriptManager OvationControls = (RadScriptManager)ContainerforScrptMgr.FindControl("Ovationscriptmgr");

                senderPickerStart.DateInput.CssClass = string.Empty;

                // uncomment this for testing
                //HttpContext.Current.Response.Write("start date " + e.NewDate.Value.Date.ToShortDateString()  + " " + SeasonHiddenID.Value.ToString());

                using (SqlConnection update_Hotel_room_Rate_currency_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand update_Hotel_room_Rate_currency_cmd = new SqlCommand("UPDATE Tbl_Hotel_PHC_AmmenRmSeasons SET dtSTdate = @dtSTdate WHERE(LID = @LID) AND (LRFPID = @LRFPID)", update_Hotel_room_Rate_currency_Conn))
                    {
                        update_Hotel_room_Rate_currency_cmd.CommandType = CommandType.Text;
                        update_Hotel_room_Rate_currency_cmd.CommandTimeout = 0;

                        update_Hotel_room_Rate_currency_Conn.Open();

                        update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@LID", SeasonHiddenID.Value.ToString());
                        update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                        update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@dtSTdate", e.NewDate.Value.Date.ToShortDateString());
                        update_Hotel_room_Rate_currency_cmd.ExecuteNonQuery();

                        Ovationscriptmgr.SetFocus(EndDatePicker.DateInput.ClientID);

                    }
                }

            }
            else
            {

                senderPickerStart.DateInput.CssClass = "enddateError";
            }

        }

        protected void RMCatEndDte_Start_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            RadDatePicker senderPickerEnd = sender as RadDatePicker;

            if (senderPickerEnd.SelectedDate == null)
            {
                Page.Validate("DatesinRatesEndDate_Blank");
            }
            else
            {
                Page.Validate("DatesinRatesCompare");

            }


            if (Page.IsValid == true)
            {
                // parent repeater

                RepeaterItem ParentRepeater = ((RepeaterItem)(senderPickerEnd.NamingContainer));
                //RepeaterItem childrepeaterItem = ((RepeaterItem)(senderPickerEnd.NamingContainer.NamingContainer));
                //TextBox RoomCatBox = childrepeaterItem.FindControl("Hotel_room_category") as TextBox;
                HiddenField SeasonHiddenIDEnd = ParentRepeater.FindControl("seaonNumber") as HiddenField;

                //HttpContext.Current.Response.Write(childrepeaterItem);

                senderPickerEnd.DateInput.CssClass = string.Empty;

                // child repeater
                //Repeater childrepeater = ParentRepeater.FindControl("MultipleDates") as Repeater;
                //RepeaterItem childrepeaterItem = ((RepeaterItem)(childrepeater.NamingContainer)) as RepeaterItem;
                //TextBox RoomCatBox = childrepeaterItem.FindControl("Hotel_room_category") as TextBox;

                // script manager set focus
               // Control ContainerforScrptMgr = this.FindControl("OvationRFPGlobalScrptMgr1");
                //RadScriptManager OvationControls = (RadScriptManager)ContainerforScrptMgr.FindControl("Ovationscriptmgr");

                // uncomment this for testing
                //HttpContext.Current.Response.Write("end date " + e.NewDate.Value.Date.ToShortDateString() + " " + SeasonHiddenIDEnd.Value.ToString());
                //HttpContext.Current.Response.Write(childrepeater.ClientID);

                using (SqlConnection update_Hotel_room_Rate_currency_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand update_Hotel_room_Rate_currency_cmd = new SqlCommand("UPDATE Tbl_Hotel_PHC_AmmenRmSeasons SET dtEDDate = @dtEDDate WHERE(LID = @LID) AND (LRFPID = @LRFPID)", update_Hotel_room_Rate_currency_Conn))
                    {
                        update_Hotel_room_Rate_currency_cmd.CommandType = CommandType.Text;
                        update_Hotel_room_Rate_currency_cmd.CommandTimeout = 0;

                        update_Hotel_room_Rate_currency_Conn.Open();

                        update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@LID", SeasonHiddenIDEnd.Value.ToString());
                        update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@LRFPID", Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation"));
                        update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@dtEDDate", e.NewDate.Value.Date.ToShortDateString());
                        update_Hotel_room_Rate_currency_cmd.ExecuteNonQuery();

                       // OvationControls.SetFocus(RoomCatBox.ClientID);



                    }
                }

            }
            else
            {

                senderPickerEnd.Clear();
                //senderPickerEnd.DateInput.DisplayText = "In-Valid";
                senderPickerEnd.DateInput.CssClass = "enddateError";
                // senderPickerEnd.Focus();
            }
        }


        // multiple dates nested repeater databound 
        protected void MultipleDates_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // declaare our varibles
            Repeater catsRates = e.Item.FindControl("MultipleDates") as Repeater;

            Literal CSSClassRmCat = e.Item.FindControl("romatlblCssClass") as Literal;
            LinkButton DeleteRmCatRate = e.Item.FindControl("DelRoomCatRate") as LinkButton;
            TextBox TheCategoryBox = e.Item.FindControl("Hotel_room_category") as TextBox;
            TextBox RatesTextBox = e.Item.FindControl("Hotel_room_category_Rate") as TextBox;
            HiddenField RmCatHiddenID = e.Item.FindControl("roomCatID") as HiddenField;
            HiddenField RmRateHiddenID = e.Item.FindControl("roomRateID") as HiddenField;
            DropDownList CurCode = e.Item.FindControl("currencyCodes") as DropDownList;

            //RequiredFieldValidator firtRowValidTwoInner = e.Item.FindControl("RMCatEndDte_Start_Val") as RequiredFieldValidator;


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //TheCategoryBox.Attributes.Add("onkeydown", "doPostBack(this)");
                RatesTextBox.Attributes.Add("onkeydown", "javascript:return jsDecimals(event);");
                RmCatHiddenID.Value = DataBinder.Eval(e.Item.DataItem, "LID").ToString();
                RmRateHiddenID.Value = DataBinder.Eval(e.Item.DataItem, "LID").ToString();

                // bind and rebind currency drop down in inner repeater - rebind is for on selected index changed we up db and need to rebind
                DataSet ds = new DataSet();
                ds.ReadXml(MapPath("~/Resources/countryCurrency.xml"));

                //get the dataview of table "Country", which is default table name
                DataView dv = ds.Tables["CurrencyRegion"].DefaultView;
                //or we can use:
                //DataView dv = ds.Tables[0].DefaultView;

                //Now sort the DataView vy column name "Name"
                dv.Sort = "Name";

                //now define datatext field and datavalue field of dropdownlist
                CurCode.DataTextField = "Name";
                CurCode.DataValueField = "ID";

                //now bind the dropdownlist to the dataview
                CurCode.DataSource = dv;
                CurCode.DataBind();

                // select default value of USD for american dollar
                CurCode.SelectedValue = "USD";

                CurCode.SelectedValue = DataBinder.Eval(e.Item.DataItem, "szCurCode").ToString();
                //CurCode.
                //CurCode.Attributes.Add("onMouseOver", "Open_ddl('" + CurCode.ClientID + "');");
                //CurCode.Attributes.Add("onMouseOut", "Close_ddl('" + CurCode.ClientID + "');");

                //ListItemCollection lic = new ListItemCollection();
                //lic = CurCode.Items;
                //foreach (ListItem li in lic)
                //{
                //    // here you can set any css property
                //    li.Attributes.Add("Style", "height:1px");

                //}


                if (e.Item.ItemIndex == 0)
                {
                    CSSClassRmCat.Text = "innerreapterRoomCat";

                    if (Lastseason.Value.ToString() == DataBinder.Eval(e.Item.DataItem, "LSID").ToString())
                    {
                        DeleteRmCatRate.Visible = false;
                    }
                    else
                    {
                        // this is the first record that shows automatically 
                        // with season so don't show delete category or rate button

                        //DeleteRmCatRate.Enabled = false;
                    }

                    DeleteRmCatRate.Attributes.Add("onClick", "confirmLinkDeleteSeason(this); return false;");
                    DeleteRmCatRate.CommandName = "DeletewholeSeason";

                }
                else if (e.Item.ItemIndex > 0)
                {
                    // we have more then index = 0 now show delete button
                    CSSClassRmCat.Text = "innerreapterRoomCatExtraEntry";
                    DeleteRmCatRate.CommandName = "DeleteRMCategory";
                    DeleteRmCatRate.Attributes.Add("onClick", "confirmLinkDeleteRmRt(this); return false;");
                    //DeleteRmCatRate.Enabled = true;
                }

            }

        }

        protected void MultipleDates_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // Declare Varibles here
            TextBox RatesTextBox = e.Item.FindControl("Hotel_room_category_Rate") as TextBox;
            TextBox CatTxtBoxItem = e.Item.FindControl("Hotel_room_category") as TextBox;


            switch (e.CommandName)
            {
                case "DeleteRMCategory":
                    // delete Room Category and rate
                    CategoriesRatesDelete(e);
                    break;
                case "DeletewholeSeason":
                    // delete season
                    DeleteTheSeasonAndCat(e);
                    break;

            }

        }


        void DeleteTheSeasonAndCat(RepeaterCommandEventArgs e)
        {
            string[] argumentSeason = e.CommandArgument.ToString().Split(new char[] { ',' });
            string catID = argumentSeason[0];
            string SeasonID = argumentSeason[1];

            using (SqlConnection DeleteRmSeasonAndCatRate_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand DeleteRmSeasonAndCatRate_cmd = new SqlCommand("dbo.sp_RFP_DeleteRmSeason_CatRate", DeleteRmSeasonAndCatRate_Conn))
                {

                    DeleteRmSeasonAndCatRate_cmd.CommandText = "dbo.sp_RFP_DeleteRmSeason_CatRate";
                    DeleteRmSeasonAndCatRate_cmd.CommandType = CommandType.StoredProcedure;
                    DeleteRmSeasonAndCatRate_cmd.CommandTimeout = 0;


                    // second paraemter
                    SqlParameter DeleteRmCatRate_Param = DeleteRmSeasonAndCatRate_cmd.CreateParameter();
                    DeleteRmCatRate_Param.ParameterName = "@LRFPID";
                    DeleteRmCatRate_Param.Direction = ParameterDirection.Input;
                    DeleteRmCatRate_Param.SqlDbType = SqlDbType.Int;
                    DeleteRmCatRate_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                    DeleteRmSeasonAndCatRate_cmd.Parameters.Add(DeleteRmCatRate_Param);


                    // second paraemter
                    DeleteRmCatRate_Param = DeleteRmSeasonAndCatRate_cmd.CreateParameter();
                    DeleteRmCatRate_Param.ParameterName = "@LSID";
                    DeleteRmCatRate_Param.Direction = ParameterDirection.Input;
                    DeleteRmCatRate_Param.SqlDbType = SqlDbType.Int;
                    DeleteRmCatRate_Param.Value = SeasonID.ToString();

                    DeleteRmSeasonAndCatRate_cmd.Parameters.Add(DeleteRmCatRate_Param);

                    DeleteRmSeasonAndCatRate_Conn.Open();

                    // execute entry
                    DeleteRmSeasonAndCatRate_cmd.ExecuteNonQuery();

                    // bind main repeater to get inner repeater to bind too
                    roomcategoryGroup.DataBind();
                }
            }

            //HttpContext.Current.Response.Write("the season was deleted");

        }
        // sub for command in inner repeater to 
        // delete room category and rate in season # 
        void CategoriesRatesDelete(RepeaterCommandEventArgs e)
        {
            string[] arguments = e.CommandArgument.ToString().Split(new char[] { ',' });
            string catID = arguments[0];
            string SeasonID = arguments[1];

            using (SqlConnection DeleteRmCatRate_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand DeleteRmCatRate_cmd = new SqlCommand("dbo.sp_RFP_DeleteRmCatRateSingle", DeleteRmCatRate_Conn))
                {

                    DeleteRmCatRate_cmd.CommandText = "dbo.sp_RFP_DeleteRmCatRateSingle";
                    DeleteRmCatRate_cmd.CommandType = CommandType.StoredProcedure;
                    DeleteRmCatRate_cmd.CommandTimeout = 0;

                    // first paraemter
                    SqlParameter DeleteRmCatRate_Param = DeleteRmCatRate_cmd.CreateParameter();
                    DeleteRmCatRate_Param.ParameterName = "@LID";
                    DeleteRmCatRate_Param.Direction = ParameterDirection.Input;
                    DeleteRmCatRate_Param.SqlDbType = SqlDbType.Int;
                    DeleteRmCatRate_Param.Value = catID.ToString();

                    DeleteRmCatRate_cmd.Parameters.Add(DeleteRmCatRate_Param);


                    // second paraemter
                    DeleteRmCatRate_Param = DeleteRmCatRate_cmd.CreateParameter();
                    DeleteRmCatRate_Param.ParameterName = "@LRFPID";
                    DeleteRmCatRate_Param.Direction = ParameterDirection.Input;
                    DeleteRmCatRate_Param.SqlDbType = SqlDbType.Int;
                    DeleteRmCatRate_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                    DeleteRmCatRate_cmd.Parameters.Add(DeleteRmCatRate_Param);

                    DeleteRmCatRate_Conn.Open();

                    // execute entry
                    DeleteRmCatRate_cmd.ExecuteNonQuery();

                    // bind main repeater to get inner repeater to bind too
                    roomcategoryGroup.DataBind();
                }
            }
        }

        protected void Hotel_room_category_TextChanged(object sender, EventArgs e)
        {
            TextBox senderBoxCat = sender as TextBox;
            RepeaterItem innerRepeater = ((RepeaterItem)(senderBoxCat.NamingContainer));
            HiddenField CatID = innerRepeater.FindControl("roomCatID") as HiddenField;
            TextBox RateTexBox = innerRepeater.FindControl("Hotel_room_category_Rate") as TextBox;
           // Control ContainerforScrptMgr = this.FindControl("OvationRFPGlobalScrptMgr1");
            //RadScriptManager OvationControls = (RadScriptManager)ContainerforScrptMgr.FindControl("Ovationscriptmgr");




            ////Page.Validate("AmmenValGroup");
            //if (innerRepeater.ItemIndex == 0)
            //{
            //    if (senderBoxCat.Text == string.Empty)
            //    {
            //        Page.Validate("seasonRmCatVal");
            //        Page.Validate("seasonRmRateVal");
            //    }
            //}
            //else if (innerRepeater.ItemIndex > 0)
            //{
            //    if (senderBoxCat.Text == string.Empty)
            //    {
            //        Page.Validate("seasonRmCatVal");
            //        Page.Validate("seasonRmRateVal");
            //    }
            //}


            //if (Page.IsValid == true)
            //{
                //if (innerRepeater.ItemIndex == 0)
                //{
                //    senderBoxCat.CssClass = string.Empty;
                //}
                //else if (innerRepeater.ItemIndex > 0)
                //{
                //    senderBoxCat.CssClass = string.Empty;
                //}

                using (SqlConnection update_Hotel_room_category_Conn = new SqlConnection(RFPDBconnStr))
                {
                    using (SqlCommand update_Hotel_room_category_cmd = new SqlCommand("dbo.sp_RFP_UpdateRMCat", update_Hotel_room_category_Conn))
                    {
                        update_Hotel_room_category_cmd.CommandText = "dbo.sp_RFP_UpdateRMCat";
                        update_Hotel_room_category_cmd.CommandType = CommandType.StoredProcedure;
                        update_Hotel_room_category_cmd.CommandTimeout = 0;

                        // first paraemter
                        SqlParameter update_Hotel_room_category_Param = update_Hotel_room_category_cmd.CreateParameter();
                        update_Hotel_room_category_Param.ParameterName = "@LID";
                        update_Hotel_room_category_Param.Direction = ParameterDirection.Input;
                        update_Hotel_room_category_Param.SqlDbType = SqlDbType.Int;
                        update_Hotel_room_category_Param.Value = CatID.Value;

                        update_Hotel_room_category_cmd.Parameters.Add(update_Hotel_room_category_Param);


                        // second paraemter
                        update_Hotel_room_category_Param = update_Hotel_room_category_cmd.CreateParameter();
                        update_Hotel_room_category_Param.ParameterName = "@LRFPID";
                        update_Hotel_room_category_Param.Direction = ParameterDirection.Input;
                        update_Hotel_room_category_Param.SqlDbType = SqlDbType.Int;
                        update_Hotel_room_category_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                        update_Hotel_room_category_cmd.Parameters.Add(update_Hotel_room_category_Param);

                        // third paraemter
                        update_Hotel_room_category_Param = update_Hotel_room_category_cmd.CreateParameter();
                        update_Hotel_room_category_Param.ParameterName = "@szRmTypeCat";
                        update_Hotel_room_category_Param.Direction = ParameterDirection.Input;
                        update_Hotel_room_category_Param.SqlDbType = SqlDbType.NVarChar;
                        update_Hotel_room_category_Param.Value = senderBoxCat.Text.ToString();

                        update_Hotel_room_category_cmd.Parameters.Add(update_Hotel_room_category_Param);

                        //Open db coonection
                        update_Hotel_room_category_Conn.Open();

                        // execute entry
                        update_Hotel_room_category_cmd.ExecuteNonQuery();

                        // set focus on rate text box now

                        //RadAjaxPanel1.ResponseScripts.Add("document.getElementById('" + RateTexBox.ClientID + "').focus();");

                        Ovationscriptmgr.SetFocus(RateTexBox.ClientID);
                        // bind main repeater to get inner repeater to bind too
                        roomcategoryGroup.DataBind();

                        

                       

                        
                        



                    }
                }

                CatID.Value = string.Empty;
            //}
            //else
            //{
            //    //HttpContext.Current.Response.Write("Not valid cat");
            //    if (innerRepeater.ItemIndex == 0)
            //    {

            //        senderBoxCat.CssClass = "enddateError";
            //        OvationControls.SetFocus(senderBoxCat.ClientID);

            //    }
            //    else if (innerRepeater.ItemIndex > 0)
            //    {

            //        senderBoxCat.CssClass = "enddateError";
            //        OvationControls.SetFocus(senderBoxCat.ClientID);
            //    }
            //}
        }


        protected void Hotel_room_category_Rate_TextChanged(object sender, EventArgs e)
        {
           // Page.Validate("seasonRmRateVal");
            //Page.Validate("DatesinRates");

            //if (Page.IsValid == true)
           // {
                // declare our varibales
                TextBox senderBoxRate = sender as TextBox;
                RepeaterItem innerRepeaterTwo = ((RepeaterItem)(senderBoxRate.NamingContainer));
                HiddenField CatIDRate = innerRepeaterTwo.FindControl("roomRateID") as HiddenField;
                //TextBox RoomCat = innerRepeaterTwo.FindControl("Hotel_room_category") as TextBox;
                DropDownList Curencyddl = innerRepeaterTwo.FindControl("currencyCodes") as DropDownList;
               // Control ContainerforScrptMgr = this.FindControl("OvationRFPGlobalScrptMgr1");
               // RadScriptManager OvationControls = (RadScriptManager)ContainerforScrptMgr.FindControl("Ovationscriptmgr");

                // uncomment for testing
                //HttpContext.Current.Response.Write(senderBoxRate.Text.ToString() + " " + senderBoxRate.ID + " " + CatIDRate.Value + " " + MyIDTwo.Value.ToString());

                //return;
                if (senderBoxRate.Text != string.Empty)
                {
                    using (SqlConnection update_Hotel_room_Rate_Conn = new SqlConnection(RFPDBconnStr))
                    {
                        using (SqlCommand update_Hotel_room_Rat_cmd = new SqlCommand("dbo.sp_RFP_updateRMRate", update_Hotel_room_Rate_Conn))
                        {
                            update_Hotel_room_Rat_cmd.CommandText = "dbo.sp_RFP_updateRMRate";
                            update_Hotel_room_Rat_cmd.CommandType = CommandType.StoredProcedure;
                            update_Hotel_room_Rat_cmd.CommandTimeout = 0;

                            // first paraemter
                            SqlParameter update_Hotel_room_Rat_cmd_Param = update_Hotel_room_Rat_cmd.CreateParameter();
                            update_Hotel_room_Rat_cmd_Param.ParameterName = "@LID";
                            update_Hotel_room_Rat_cmd_Param.Direction = ParameterDirection.Input;
                            update_Hotel_room_Rat_cmd_Param.SqlDbType = SqlDbType.Int;
                            update_Hotel_room_Rat_cmd_Param.Value = CatIDRate.Value;

                            update_Hotel_room_Rat_cmd.Parameters.Add(update_Hotel_room_Rat_cmd_Param);


                            // second paraemter
                            update_Hotel_room_Rat_cmd_Param = update_Hotel_room_Rat_cmd.CreateParameter();
                            update_Hotel_room_Rat_cmd_Param.ParameterName = "@LRFPID";
                            update_Hotel_room_Rat_cmd_Param.Direction = ParameterDirection.Input;
                            update_Hotel_room_Rat_cmd_Param.SqlDbType = SqlDbType.Int;
                            update_Hotel_room_Rat_cmd_Param.Value = Decrypt(HttpContext.Current.Request.QueryString["ORFP"], "trappOvation");

                            update_Hotel_room_Rat_cmd.Parameters.Add(update_Hotel_room_Rat_cmd_Param);

                            // third paraemter
                            update_Hotel_room_Rat_cmd_Param = update_Hotel_room_Rat_cmd.CreateParameter();
                            update_Hotel_room_Rat_cmd_Param.ParameterName = "@nRmRate";
                            update_Hotel_room_Rat_cmd_Param.Direction = ParameterDirection.Input;
                            update_Hotel_room_Rat_cmd_Param.SqlDbType = SqlDbType.Decimal;
                            update_Hotel_room_Rat_cmd_Param.Value = senderBoxRate.Text;

                            update_Hotel_room_Rat_cmd.Parameters.Add(update_Hotel_room_Rat_cmd_Param);

                            //Open db coonection
                            update_Hotel_room_Rate_Conn.Open();

                            // execute entry
                            update_Hotel_room_Rat_cmd.ExecuteNonQuery();

                            Ovationscriptmgr.SetFocus(Curencyddl.ClientID);
                            // bind main repeater to get inner repeater to bind too

                            RadAjaxPanel1.ResponseScripts.Add("document.getElementById('" + Curencyddl.ClientID + "').focus();");

                            roomcategoryGroup.DataBind();



                        }
                    }
                }
                else
                {
                    //senderBoxRate.Text = "0.00";
                    // may  want to update db

                }

            }
        //}


        protected void currencyCodesInnerRepeater_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList senderCurrencyRate = sender as DropDownList;
            RepeaterItem innerRepeaterThree = ((RepeaterItem)(senderCurrencyRate.NamingContainer));
            HiddenField CurrencyID = innerRepeaterThree.FindControl("roomRateID") as HiddenField;
            DropDownList Curencyddl = innerRepeaterThree.FindControl("currencyCodes") as DropDownList;

            using (SqlConnection update_Hotel_room_Rate_currency_Conn = new SqlConnection(RFPDBconnStr))
            {
                using (SqlCommand update_Hotel_room_Rate_currency_cmd = new SqlCommand("UPDATE dbo.Tbl_Hotel_PHC_AmmenRmCatRates SET szCurCode = @szCurCode WHERE LID = @LID AND LRFPID = @LRFPID", update_Hotel_room_Rate_currency_Conn))
                {
                    update_Hotel_room_Rate_currency_cmd.CommandType = CommandType.Text;
                    update_Hotel_room_Rate_currency_cmd.CommandTimeout = 0;

                    update_Hotel_room_Rate_currency_Conn.Open();

                    update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@LID", CurrencyID.Value.ToString());
                    update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@LRFPID", whatRFPID.Value.ToString());
                    update_Hotel_room_Rate_currency_cmd.Parameters.AddWithValue("@szCurCode", Curencyddl.SelectedValue.ToString());
                    update_Hotel_room_Rate_currency_cmd.ExecuteNonQuery();

                }
            }
        }

        //protected void RadAjaxPanel1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        //{

           // roomcategoryGroup.DataBind();

        //}
    }
}
