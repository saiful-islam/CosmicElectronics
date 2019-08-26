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
    public partial class TransationByCategory : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void GridViewLoad()
        {
            string strQuery = "exec [dbo].[SP_TransationByCategory]  @date1='"+txtFromDate.Text.Trim()+"',@date2='"+txtToDate.Text.Trim()+"'";
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