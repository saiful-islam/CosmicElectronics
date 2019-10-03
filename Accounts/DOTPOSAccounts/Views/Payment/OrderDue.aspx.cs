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
    public class DataColumnComparer : IEqualityComparer<DataColumn>
    {
        public bool Equals(DataColumn x, DataColumn y) { return x.Caption == y.Caption; }

        public int GetHashCode(DataColumn obj) { return obj.Caption.GetHashCode(); }

    }
    public partial class OrderDue : System.Web.UI.Page
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
            string query = @"select a.Description as Code,a.Name, 
	                                a.Address,a.Mobile
                            from [dbo].[Account] a
                            where a.AccountTypeId="+ ddlAccountType.SelectedValue;
            DataTable dtAccounts = _db.GetDataTable(query);

            query = " EXEC dbo.SP_GET_CUSTOMER_ORDER";
            DataTable dtSales = _nop.GetDataTable(query);

            DataTable result = FullOuterJoinDataTables(dtAccounts, dtSales);

            gvPaymentList.DataSource = result;
            gvPaymentList.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string query = "EXEC [dbo].[SP_PaymentDueByAccountFilter] @PaymentType=2,@accName='" + txtFilter.Text.Trim() + "', @accountTypeId=" + ddlAccountType.SelectedValue;
            DataTable dt = _db.GetDataTable(query);
            gvPaymentList.DataSource = dt;
            gvPaymentList.DataBind();
        }
        DataTable FullOuterJoinDataTables(params DataTable[] datatables) // supports as many datatables as you need.
        {
            DataTable result = datatables.First().Clone();

            var commonColumns = result.Columns.OfType<DataColumn>();

            foreach (var dt in datatables.Skip(1))
            {
                commonColumns = commonColumns.Intersect(dt.Columns.OfType<DataColumn>(), new DataColumnComparer());
            }

            result.PrimaryKey = commonColumns.ToArray();

            foreach (var dt in datatables)
            {
                result.Merge(dt, false, MissingSchemaAction.AddWithKey);
            }

            return result;
        }
    }
}