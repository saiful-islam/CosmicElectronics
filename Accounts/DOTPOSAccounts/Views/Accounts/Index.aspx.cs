using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Accounts
{
    public partial class Index : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAccountType();
                GridViewLoad();
            }
        }
        private void LoadAccountType()
        {
            string query = "EXEC [dbo].[SP_AccountType]";
            DataTable dt = _db.GetDataTable(query);
            ddlAccountType.DataSource = dt;
            ddlAccountType.DataBind();
        }
        public void GridViewLoad()
        {
            string strQuery = "exec [dbo].[SP_AccountListFilter] @filterText='" + txtFilter.Text.Trim() + "' , @accType=" + ddlAccountType.SelectedValue;
            DataTable dt = _db.GetDataTable(strQuery);
            gvAccounts.DataSource = dt;
            gvAccounts.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GridViewLoad();
        }

        protected void gvAccounts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strQuery = "";
            string accId = gvAccounts.Rows[e.RowIndex].Cells[0].Text;
            strQuery = " update [dbo].[Account] ";
            strQuery += Environment.NewLine + " set IsDeleted= 'True'";
            strQuery += Environment.NewLine + " Where Id= " + accId;
            _db.ExecuteNonQuery(strQuery);
            Response.Redirect("Index", true);
        }

        protected void gvAccounts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string accId = gvAccounts.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("Create.aspx?id=" + accId, true);
        }
    }
}