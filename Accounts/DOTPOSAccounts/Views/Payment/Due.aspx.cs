using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Payment
{
    public partial class Due : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadGrid();
            }
        }
        
        private void LoadGrid()
        {
            string query = "EXEC [dbo].[SP_PaymentDueByAccount] @PaymentType=1";
            DataTable dt = _db.GetDataTable(query);
            gvDueList.DataSource = dt;
            gvDueList.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "EXEC [dbo].[SP_PaymentDueByAccountFilter] @PaymentType=1,@accName='" + txtFilter.Text.Trim()+"'";
            DataTable dt = _db.GetDataTable(query);
            gvDueList.DataSource = dt;
            gvDueList.DataBind();
        }
    }
}