using System;

namespace OvationTest
{
    public partial class _Default
    {
        protected void RadioButtonList_IsProperty_Virtuoso_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList_IsProperty_Virtuoso.SelectedValue.ToString() == "No")
            {
                istheVirtuosoamenityincludedPNL.Visible = false;
                whatisVirtuosoamenity_Pnl.Visible = false;
                Ammenities_ensurePnl.Visible = false;
            }
            else if (RadioButtonList_IsProperty_Virtuoso.SelectedValue.ToString() == "Yes")
            {
                istheVirtuosoamenityincludedPNL.Visible = true;
                whatisVirtuosoamenity_Pnl.Visible = true;
                Ammenities_ensurePnl.Visible = true;
            }
            else if (RadioButtonList_IsProperty_Virtuoso.SelectedValue.ToString() == "Yes" && RadioButtonList_IsVirtuoso_included.SelectedValue.ToString() == "No")
            {
                istheVirtuosoamenityincludedPNL.Visible = true;
                whatisVirtuosoamenity_Pnl.Visible = false;
                Ammenities_ensurePnl.Visible = false;

            }
        }
    }
}
