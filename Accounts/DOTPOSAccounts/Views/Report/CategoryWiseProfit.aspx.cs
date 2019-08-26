using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Report
{
    public partial class CategoryWiseProfit : System.Web.UI.Page
    {
        DataOperationNop _db = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GridViewLoad()
        {
            string strQuery = "exec [dbo].[SP_CategoryWiseProfit]  @fromDate='" + txtFromDate.Text.Trim() + "',@toDate='" + txtToDate.Text.Trim() + "'";
            DataTable dt = _db.GetDataTable(strQuery);
            gvCategoryWiseProfit.DataSource = dt;
            gvCategoryWiseProfit.DataBind();
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