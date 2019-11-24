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
        DataOperationNop _nop = new DataOperationNop();
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
            DataTable dtAccounts = _db.GetDataTable(query);

            query = " EXEC dbo.SP_GET_CUSTOMER_ORDER";
            DataTable dtSales = _nop.GetDataTable(query);

            var Result = from Leftrow in dtAccounts.AsEnumerable()
                         join Rightrow in dtSales.AsEnumerable() on Leftrow["Code"] equals Rightrow["Code"]
                         into temp
                         from r in temp.DefaultIfEmpty()
                         select new
                         {
                             Code = Leftrow["Code"],
                             Name = Leftrow["Name"],
                             Address = Leftrow["Address"],
                             Mobile = Leftrow["Mobile"],
                             Payment = r != null ? Convert.ToDecimal(Leftrow["Payment"]) + Convert.ToDecimal(r["OrderTotal"]) : Convert.ToDecimal(Leftrow["Payment"]),
                             TotalPaid = r != null ? Convert.ToDecimal(Leftrow["TotalPaid"]) + Convert.ToDecimal(r["Paid"]) : Convert.ToDecimal(Leftrow["TotalPaid"]),
                             Payment_Due = r != null ? Convert.ToDecimal(Leftrow["Payment_Due"]) + Convert.ToDecimal(r["DUE"]) : Convert.ToDecimal(Leftrow["Payment_Due"])
                         };



            gvPaymentList.DataSource = Result;
            gvPaymentList.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadGrid();
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