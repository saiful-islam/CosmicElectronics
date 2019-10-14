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
            string filter = txtFilter.Text.Trim();
            string query = @"select substring(a.Description,1,1) BookNo,cast(dbo.udf_GetNumeric(a.Description) as int) CustomerSerial,a.Description as Code,a.Name, 
	                                a.Address,a.Mobile
                            from [dbo].[Account] a
                            where (a.Description = '" + filter + "' or a.Mobile like '%" + filter + "%' or a.Name like '%" + filter + "%') and  a.AccountTypeId=" + ddlAccountType.SelectedValue + "  order by BookNo,CustomerSerial";
            DataTable dtAccounts = _db.GetDataTable(query);

            query = " EXEC dbo.SP_GET_CUSTOMER_ORDER";
            DataTable dtSales = _nop.GetDataTable(query);

            ///DataTable result = FullOuterJoinDataTables(dtAccounts, dtSales);
            var Result = from Leftrow in dtAccounts.AsEnumerable()
                         join Rightrow in dtSales.AsEnumerable() on Leftrow["Code"] equals Rightrow["Code"]
                         //into temp
                         //from r in temp.DefaultIfEmpty()
                         select new
                         {
                             Code = Leftrow["Code"],
                             Name = Leftrow["Name"],
                             Address = Leftrow["Address"],
                             Mobile = Leftrow["Mobile"],
                             OrderTotal = Rightrow["OrderTotal"],
                             Paid = Rightrow["Paid"],
                             DUE = Rightrow["DUE"],
                             OrderId = Rightrow["OrderId"]
                             //Paid = r != null ? r["Paid"] : 0,
                             //DUE = r != null ? r["DUE"] : 0,
                             //OrderId = r != null ? r["OrderId"] : 0
                         };
            
            gvPaymentList.DataSource = Result;
            gvPaymentList.DataBind();

            decimal paid=0, due = 0, total = 0;
            foreach(var row in Result)
            {
                total += (decimal)row.OrderTotal;
                paid += (decimal)row.Paid;
                due += (decimal)row.DUE;
            }
            txtOrderTotal.Text = total.ToString();
            txtPaid.Text = paid.ToString();
            txtDue.Text = due.ToString();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadGrid();
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