using IslamTraders_Accounts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IslamTraders_Accounts.Views.DesktopReport
{
    public partial class Desktop_CategoryWiseStock : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_ddlCategory();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string strQuery = @"EXEC [desktop].[SP_CategoryWiseStock]  @categoryId=" + ddlCategory.SelectedValue;
            DataTable dt = _db.GetDataTable(strQuery);
            gvCategoryWiseStock.DataSource = dt;
            gvCategoryWiseStock.DataBind();
        }
        private void Load_ddlCategory()
        {
            string strQuery = @"EXEC [desktop].[GETCategory] ";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();
        }
    }
}