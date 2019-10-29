using IslamTraders_Accounts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IslamTraders_Accounts.Views.Payment
{
    public partial class DuePrint : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        DataOperationNop _nop = new DataOperationNop();
        string customerId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    customerId = Request.QueryString["id"];
                    lblDate.Text = DateTime.Now.ToLongDateString();
                    LoadDue(customerId);
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }
        private void LoadDue(string customerId)
        {
            string filter = customerId;
            string query = @"EXEC [dbo].[SP_PaymentDueByAccountFilter] @PaymentType=2,@accountTypeId=0, @accName='" + filter + "'";
            DataTable dtAccounts = _db.GetDataTable(query);

            query = " EXEC dbo.SP_GET_CUSTOMER_ORDER_TOTAL";
            DataTable dtSales = _nop.GetDataTable(query);

            var Result = from Leftrow in dtAccounts.AsEnumerable()
                         join Rightrow in dtSales.AsEnumerable() on Leftrow["Code"] equals Rightrow["Code"]  into r
                         from Rightrow in r.DefaultIfEmpty() 
                         select new
                         {
                             Code = Leftrow["Code"],
                             Name = Leftrow["Name"],
                             Address = Leftrow["Address"],
                             Mobile = Leftrow["Mobile"],
                             OrderTotal = Convert.ToDecimal(Rightrow == null ? 0: Rightrow["OrderTotal"]) + Convert.ToDecimal(Leftrow["Payment"]),
                             Paid = Convert.ToDecimal(Rightrow == null ? 0 : Rightrow["Paid"]) + Convert.ToDecimal(Leftrow["TotalPaid"]),
                             DUE = Convert.ToDecimal(Rightrow == null ? 0 : Rightrow["DUE"]) + Convert.ToDecimal(Leftrow["Payment_Due"])
                         };
            foreach(var r in Result)
            {
                lblCode.Text = r.Code.ToString();
                lblName.Text = r.Name.ToString();
                lblMobile.Text = r.Mobile.ToString();
                lblAddress.Text = r.Address.ToString();
                lblTotal.Text = r.OrderTotal.ToString();
                lblPaid.Text = r.Paid.ToString();
                lblDue.Text = r.DUE.ToString();
            }
        }
    }
}