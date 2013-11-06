using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using xls = Telerik.Web.UI.ExportInfrastructure;


namespace OvationTest
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //backtoRFP.NavigateUrl = "~/default.aspx?ORFP=" + HttpContext.Current.Request.QueryString["ORFP"];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RadGrid1.ExportSettings.Excel.Format = GridExcelExportFormat.Biff;
            RadGrid1.MasterTableView.ExportToExcel();
        }

        protected void RadGrid1_BiffExporting(object sender, GridBiffExportingEventArgs e)
        {
            xls.Table tbl = e.ExportStructure.Tables[0];
            //tbl.Rows[1].Height = 30;
            tbl.Columns[1].Width = 25;
            tbl.Columns[1].Style.HorizontalAlign = HorizontalAlign.Left;
            tbl.Columns[2].Width = 25;
            tbl.Columns[2].Style.HorizontalAlign = HorizontalAlign.Left;
            tbl.Columns[3].Width = 25;
            tbl.Columns[3].Style.HorizontalAlign = HorizontalAlign.Left;
            tbl.Columns[4].Width = 35;
            tbl.Columns[4].Style.HorizontalAlign = HorizontalAlign.Left;
        }

    }
}
