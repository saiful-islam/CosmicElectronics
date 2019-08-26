using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Transaction
{
    public partial class TodayTransaction : System.Web.UI.Page
    {
        DataOperation _db=new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string query = "exec [dbo].[SP_CashInOut] @date='" + DateTime.UtcNow + "'";
                DataTable dt = _db.GetDataTable(query);
                lblTodayCost.Text = dt.Rows[0][0].ToString();
                lblTodayCashIn.Text = dt.Rows[0][1].ToString();
                GridViewLoad();
            }
        }
        public void GridViewLoad()
        {
            string strQuery = "exec [dbo].[SP_TransationList] @date='" + DateTime.UtcNow + "'";
            DataTable dt = _db.GetDataTable(strQuery);
            gvTransactions.DataSource = dt;
            gvTransactions.DataBind();
        }
    }
}