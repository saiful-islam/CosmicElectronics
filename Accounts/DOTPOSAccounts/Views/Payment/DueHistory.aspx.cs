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
    public partial class DueHistory : System.Web.UI.Page
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
            string query = "EXEC [dbo].[SP_PaymentDue] @PaymentType=1";
            DataTable dt = _db.GetDataTable(query);
            gvDueList.DataSource = dt;
            gvDueList.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "EXEC [dbo].[SP_PaymentDueFilter] @PaymentType=1,@accName='" + txtFilter.Text.Trim() + "'";
            DataTable dt = _db.GetDataTable(query);
            gvDueList.DataSource = dt;
            gvDueList.DataBind();
        }

        protected void gvDueList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strQuery = "";
            string paymentId = gvDueList.Rows[e.RowIndex].Cells[0].Text;
            strQuery = " update [dbo].[PaymentTransaction] ";
            strQuery += Environment.NewLine + " set IsDeleted= 'True'";
            strQuery += Environment.NewLine + " Where PaymentId= " + paymentId;
            _db.ExecuteNonQuery(strQuery);
            Response.Redirect("Index", true);
        }

        protected void gvDueList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string paymentId = gvDueList.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("Create.aspx?id=" + paymentId, true);
        }
    }
}