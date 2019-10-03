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
    public partial class Payment : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAccountType();
                LoadGrid();
            }
        }
        private void LoadAccountType()
        {
            string query = "EXEC [dbo].[SP_AccountType]";
            DataTable dt = _db.GetDataTable(query);
            ddlAccountType.DataSource = dt;
            ddlAccountType.DataBind();
        }
        private void LoadGrid()
        {
            string query = "EXEC [dbo].[SP_PaymentDueByAccountFilter] @PaymentType=2,@accName='" + txtFilter.Text.Trim() + "', @accountTypeId=" + ddlAccountType.SelectedValue;
            DataTable dt = _db.GetDataTable(query);
            gvPaymentList.DataSource = dt;
            gvPaymentList.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "EXEC [dbo].[SP_PaymentDueByAccountFilter] @PaymentType=2,@accName='" + txtFilter.Text.Trim() + "', @accountTypeId="+ddlAccountType.SelectedValue;
            DataTable dt = _db.GetDataTable(query);
            gvPaymentList.DataSource = dt;
            gvPaymentList.DataBind();
        }

        protected void gvPaymentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strQuery = "";
            string paymentId = gvPaymentList.Rows[e.RowIndex].Cells[0].Text;
            strQuery = " update [dbo].[PaymentTransaction] ";
            strQuery += Environment.NewLine + " set IsDeleted= 'True'";
            strQuery += Environment.NewLine + " Where PaymentId= " + paymentId;
            _db.ExecuteNonQuery(strQuery);
            Response.Redirect("Index", true);
        }

        protected void gvPaymentList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string paymentId = gvPaymentList.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("Create.aspx?id=" + paymentId, true);
        }
    }
}