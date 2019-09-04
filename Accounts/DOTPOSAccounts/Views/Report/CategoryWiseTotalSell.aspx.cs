using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Report
{
    public partial class CategoryWiseTotalSell : System.Web.UI.Page
    {
        DataOperationNop _db = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewLoad(DateTime.UtcNow);
                
            }
        }
        public void GridViewLoad(DateTime saleDate)
        {
            string strQuery = "exec [dbo].[SP_CategoryWiseTotalSell] @sellDate='" + saleDate + "'";
            DataTable dtSales = _db.GetDataTable(strQuery);

            strQuery = @"EXEC dbo.SP_GETALLCategory ";
            DataTable dtcategory = _db.GetDataTable(strQuery);
         

            for (int i = 0; i < dtcategory.Rows.Count; i++)
            {
                string ctgName = dtcategory.Rows[i]["Name"].ToString().Trim();
                decimal totalOrder = 0;
                decimal totalPayment = 0;
                decimal totalDue = 0;
                DataTable dtTemp = dtSales.Clone();

                for (int j = 0; j < dtSales.Rows.Count; j++)
                {
                    if (dtSales.Rows[j]["CategoryName"].ToString().Trim() == ctgName)
                    {
                        dtTemp.ImportRow(dtSales.Rows[j]);
                        totalOrder += Convert.ToDecimal(dtSales.Rows[j]["TotalOrder"]);
                        totalPayment += Convert.ToDecimal(dtSales.Rows[j]["TotalPayment"]);
                        totalDue += Convert.ToDecimal(dtSales.Rows[j]["TotalDue"]);
                    }
                }


                Panel panel = new Panel
                {
                    ID = "pnlCtg_" + ctgName
                };
                Label div = new Label
                {
                    Text = @"<div class='panel panel-default'>
                                <div class='panel-heading'>
                                    <h3>Category: " + ctgName + @"</h3>
                                    <table class='table table-striped'>
                                        <tr>
                                            <td>
                                                <h3>Today Order: " + totalOrder + @" </h3>
                                            </td>
                                            <td>
                                                <h3>Today Payment: " + totalPayment + @"</h3>
                                            </td>
                                            <td>
                                                <h3>Today Due: " + totalDue + @"</h3>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class='panel - body'>"
                };

                panel.Controls.Add(div);

                GridView gridView = new GridView();
                gridView.ID = "gv_"+ ctgName;
                gridView.AutoGenerateColumns = false;
                gridView.CellPadding = 4;
                gridView.ForeColor = Color.FromArgb(20, 20, 20);
                gridView.CssClass = "table";
                gridView.AlternatingRowStyle.BackColor = Color.White;
                gridView.EditRowStyle.BackColor = Color.FromArgb(14, 38, 75);
                gridView.FooterStyle.BackColor = Color.FromArgb(80, 124, 209);
                gridView.FooterStyle.ForeColor = Color.White;
                gridView.FooterStyle.Font.Bold = true;
                gridView.HeaderStyle.BackColor = Color.FromArgb(80, 124, 209);
                gridView.HeaderStyle.ForeColor = Color.White;
                gridView.HeaderStyle.Font.Bold = true;
                gridView.PagerStyle.BackColor = Color.FromArgb(36, 97, 191);
                gridView.PagerStyle.ForeColor = Color.White;
                gridView.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
                gridView.RowStyle.BackColor = Color.FromArgb(239, 243, 251);
                gridView.SelectedRowStyle.BackColor = Color.FromArgb(209, 221, 241);
                gridView.SelectedRowStyle.ForeColor = Color.FromArgb(20, 20, 20);
                gridView.SelectedRowStyle.Font.Bold = true;
                gridView.SortedAscendingCellStyle.BackColor = Color.FromArgb(245, 247, 251);
                gridView.SortedAscendingHeaderStyle.BackColor = Color.FromArgb(109, 149, 225);
                gridView.SortedDescendingCellStyle.BackColor = Color.FromArgb(233, 235, 239);
                gridView.SortedDescendingHeaderStyle.BackColor = Color.FromArgb(72, 112, 190);


                BoundField OrderId = new BoundField
                {
                    DataField = "OrderId",
                    HeaderText = "Order Id"
                };

                BoundField Customer = new BoundField
                {
                    DataField = "Customer",
                    HeaderText = "Customer"
                };

                BoundField Address = new BoundField
                {
                    DataField = "Address",
                    HeaderText = "Address"
                };

                BoundField PhoneNumber = new BoundField
                {
                    DataField = "PhoneNumber",
                    HeaderText = "Phone Number"
                };

                BoundField TotalOrder = new BoundField
                {
                    DataField = "TotalOrder",
                    HeaderText = "Total Order"
                };

                BoundField TotalPayment = new BoundField
                {
                    DataField = "TotalPayment",
                    HeaderText = "Total Payment"
                };

                BoundField TotalDue = new BoundField
                {
                    DataField = "TotalDue",
                    HeaderText = "Total Due"
                };

                gridView.Columns.Add(OrderId);
                gridView.Columns.Add(Customer);
                gridView.Columns.Add(Address);
                gridView.Columns.Add(PhoneNumber);
                gridView.Columns.Add(TotalOrder);
                gridView.Columns.Add(TotalPayment);
                gridView.Columns.Add(TotalDue);

                gridView.DataSource = dtTemp;
                gridView.DataBind();
                panel.Controls.Add(gridView);


                Label div2 = new Label();
                div2.Text = @"</div>
                        </div>";
                panel.Controls.Add(div2);

                pnlSalesCategory.Controls.Add(panel);
            }
            
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewLoad(Convert.ToDateTime(txtSaleDate.Text));
            }
            catch
            {
                // ignored
            }
        }
    }
}