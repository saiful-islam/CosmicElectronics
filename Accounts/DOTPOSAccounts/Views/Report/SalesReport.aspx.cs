using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Report
{
    public partial class SalesReport : System.Web.UI.Page
    {
        DataOperationNop _db = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GridViewLoad()
        {
            string strQuery = "exec [dbo].[SalesReport]  @start='" + txtFromDate.Text.Trim() + "',@end='" + txtToDate.Text.Trim() + "'";
            DataTable dt = _db.GetDataTable(strQuery);
            gvTransationByCategory.DataSource = dt;
            gvTransationByCategory.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewLoad();
            }
            catch (Exception exception)
            {
                //ig
            }

        }
    }
}