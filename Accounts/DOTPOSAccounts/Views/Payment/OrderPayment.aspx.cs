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
    public partial class OrderPayment : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        DataOperationNop _nop = new DataOperationNop();
        string orderID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    orderID = Request.QueryString["id"];
                    loadPreviousPayment(orderID);
                    LoadDue(orderID);
                }
                catch (Exception ex)
                {
                    //ignore
                }
            }
        }

        private void loadPreviousPayment(string orderID)
        {
            string strQuery = @"SELECT [PaidDate] 
                            ,[PaidToday] 
                            FROM [dbo].[Payment] od
                        where od.OrderId=" + orderID;
            DataTable dt = _nop.GetDataTable(strQuery);
            gvPayment.DataSource = dt;
            gvPayment.DataBind();
        }

        private void LoadDue(string orderID)
        {
            lblOrderId.Text = orderID;
            

            string query = "EXEC [dbo].[SP_GET_CUSTOMER_ORDER]";
            DataTable dtSales = _nop.GetDataTable(query);

            var salesResult = from Leftrow in dtSales.AsEnumerable()
                         where Leftrow.Field<int>("OrderId") == Convert.ToInt32(orderID)
                         select Leftrow;
            string filter = "";
            foreach (var r in salesResult)
            {
                filter = r.Field<string>("Code");
            }
            query = @"EXEC [dbo].[SP_PaymentDueByAccountFilter] @PaymentType=2,@accountTypeId=0, @accName='" + filter + "'";
            DataTable dtAccounts = _db.GetDataTable(query);

            var Result = from Leftrow in dtAccounts.AsEnumerable()
                         join Rightrow in dtSales.AsEnumerable() on Leftrow["Code"] equals Rightrow["Code"] into r
                         from Rightrow in r.DefaultIfEmpty()
                         where Rightrow.Field<int>("OrderId") == Convert.ToInt32(orderID)
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
            foreach (var r in Result)
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

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            btnPayment.Visible = false;
            try
            {
                decimal paymentToday = Convert.ToDecimal(txtPayment.Text.ToString().Trim() == string.Empty ? "0" : txtPayment.Text.ToString());
                
                string _query = "EXEC SP_InsertPayment @id=" + lblOrderId.Text + ",@paymentToday=" + paymentToday + ",@DueDate=null;";
                _nop.ExecuteNonQuery(_query);
              
                _query = @"EXEC DueList @OrderId = " + lblOrderId.Text;

                DataTable dt = _nop.GetDataTable(_query);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        _query = "update dbo.[order] set PaymentStatusId = 30, PaidDateUtc=getdate() where Id = " + lblOrderId.Text;
                        _nop.ExecuteNonQuery(_query);
                    }
                }
                loadPreviousPayment(lblOrderId.Text);
                LoadDue(lblOrderId.Text);
                txtPayment.Text = "";
                btnPayment.Visible = true;
            }
            catch (Exception exc)
            {
                // ignored
            }
        }
    }
}