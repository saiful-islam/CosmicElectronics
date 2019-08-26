using IslamTraders_Accounts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IslamTraders_Accounts.Views.Report
{
    public partial class CategoryWiseSales : System.Web.UI.Page
    {
        DataOperationNop _db = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GridViewLoad()
        {
            string strQuery = "exec [dbo].[SP_CategoryWiseMonthlySale]  @fromDate='" + txtFromDate.Text.Trim() + "',@toDate='" + txtToDate.Text.Trim() + "'";
            DataTable dt = _db.GetDataTable(strQuery);
            gvCategoryWiseSale.DataSource = dt;
            gvCategoryWiseSale.DataBind();
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