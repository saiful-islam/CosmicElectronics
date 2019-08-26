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
    public partial class CategoryWiseDue : System.Web.UI.Page
    {
        DataOperationNop _db= new DataOperationNop();       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewLoad();
            }
        }
        public void GridViewLoad()
        {
            string strQuery = "exec [dbo].[SP_CategoryWiseDue] ";
            DataTable dt = _db.GetDataTable(strQuery);
            gvCategoryWiseDue.DataSource = dt;
            gvCategoryWiseDue.DataBind();
        }
    }
}