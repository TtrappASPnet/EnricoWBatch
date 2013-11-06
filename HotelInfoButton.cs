using System;
using Telerik.Web.UI;

namespace OvationTest
{
    public partial class _Default
    {
        protected void HotelInfoNextBtn_Click(object sender, EventArgs e)
        {
            RadTab RatesAmenities_Tab = OvationTabs.FindTabByValue("Rates_Amenities");
            
            UpdateHotelInfo();

                //progressTextHotelInfo.Text = "Hotel Information | Complete";
                //progressTextHotelInfo.ForeColor = System.Drawing.Color.Black;

                //RadTab HotelInformationTab = OvationTabs.FindTabByValue("Hotel_Info");
                

                //HotelInformationTab.Enabled = false;
                //RatesAmenities_Tab.Enabled = true;
                RatesAmenities_Tab.Selected = true;
                RatesAmenitiesView.Selected = true;

                HotelInfoCodeBlock.Visible = false;
                AmenitiesCodeBlock.Visible = true;
                //MktgCodeBlock.Visible = false;
                ElectronicSigCodeBlock.Visible = false;
                Ammenities_Num_roomshotel.Attributes.Add("onkeydown", "javascript:return jsNumbers(event);");

        }
    }
}
