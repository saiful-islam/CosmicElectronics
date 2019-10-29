using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;
using System.Data;

namespace IslamTraders_Accounts.Views.Payment
{
    public partial class DealerDue : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        DataOperationNop _nop = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //LoadAccountType();
                LoadGrid();
            }
        }
        //private void LoadAccountType()
        //{
        //    string query = "EXEC [dbo].[SP_AccountType]";
        //    DataTable dt = _db.GetDataTable(query);
        //    ddlAccountType.DataSource = dt;
        //    ddlAccountType.DataBind();
        //}
        private void LoadGrid()
        {
            string filter = txtFilter.Text.Trim();
            string query = @"EXEC [dbo].[SP_PaymentDueByAccountFilter] @PaymentType=2,@accountTypeId=10, @accName='" + filter + "'";
            DataTable dtAccounts = _db.GetDataTable(query);

            query = " EXEC dbo.SP_GET_CUSTOMER_ORDER_TOTAL";
            DataTable dtSales = _nop.GetDataTable(query);

            var Result = from Leftrow in dtAccounts.AsEnumerable()
                         join Rightrow in dtSales.AsEnumerable() on Leftrow["Code"] equals Rightrow["Code"]
                         into r
                         from Rightrow in r.DefaultIfEmpty()
                         select new
                         {
                             Code = Leftrow["Code"],
                             Name = Leftrow["Name"],
                             Address = Leftrow["Address"],
                             Mobile = Leftrow["Mobile"],
                             OrderTotal = Convert.ToDecimal(Rightrow == null ? 0 : Rightrow["OrderTotal"]) + Convert.ToDecimal(Leftrow["Payment"]),
                             Paid = Convert.ToDecimal(Rightrow == null ? 0 : Rightrow["Paid"]) + Convert.ToDecimal(Leftrow["TotalPaid"]),
                             DUE = Convert.ToDecimal(Rightrow == null ? 0 : Rightrow["DUE"]) + Convert.ToDecimal(Leftrow["Payment_Due"])
                         };

            gvPaymentList.DataSource = Result;
            gvPaymentList.DataBind();

        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}