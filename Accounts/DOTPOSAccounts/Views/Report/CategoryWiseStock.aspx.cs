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
    public partial class CategoryWiseStock : System.Web.UI.Page
    {
        DataOperationNop _db = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             Load_ddlCategory();   
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string strQuery = @"EXEC dbo.SP_CategoryWiseStock  @categoryId="+ddlCategory.SelectedValue;
            DataTable dt = _db.GetDataTable(strQuery);
            gvCategoryWiseStock.DataSource = dt;
            gvCategoryWiseStock.DataBind();
        }
        private void Load_ddlCategory()
        {
            string strQuery = @"EXEC dbo.SP_GETALLCategory ";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();
        }
    }
}