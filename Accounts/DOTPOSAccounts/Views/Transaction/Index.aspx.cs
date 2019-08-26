using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Transaction
{
    public partial class Index : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string strQuery = "exec [dbo].[SP_TransationList] @date='" + txtFilter.Text.Trim() + "'";
            DataTable dt = _db.GetDataTable(strQuery);
            gvTransactions.DataSource = dt;
            gvTransactions.DataBind();
        }

        protected void gvTransactions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string transId = gvTransactions.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("Create.aspx?id=" + transId, true);
        }

        protected void gvTransactions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strQuery = "";
            string transId = gvTransactions.Rows[e.RowIndex].Cells[0].Text;
            strQuery = " update [dbo].[Transaction] ";
            strQuery += Environment.NewLine + " set IsDeleted= 'True'";
            strQuery += Environment.NewLine + " Where TransId= " + transId;
            _db.ExecuteNonQuery(strQuery);
            Response.Redirect("Index", true);
        }
        protected void btnFilter2_Click(object sender, EventArgs e)
        {
            string strQuery = "exec [dbo].[SP_TransationListByAccount]  @accName='" + txtFilter2.Text.Trim() + "'";
            DataTable dt = _db.GetDataTable(strQuery);
            gvTransactions.DataSource = dt;
            gvTransactions.DataBind();
        }
    }
}