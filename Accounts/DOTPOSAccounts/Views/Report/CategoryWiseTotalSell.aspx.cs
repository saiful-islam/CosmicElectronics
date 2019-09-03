using System;
using System.Collections.Generic;
using System.Data;
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
            DataTable dt = _db.GetDataTable(strQuery);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel panel = new Panel();
                panel.ID = "1";
                Label div = new Label();
                div.Text = @"<div class='panel panel-default'>
                                <div class='panel-heading'>
                                    <h3>Category: Cookeries</h3>
                                    <table class='table table-striped'>
                                        <tr>
                                            <td>
                                                <h3>Today Order:
                                                    <asp:Label ID='lblOrderCookeries' Text='0'></asp:Label></h3>
                                            </td>
                                            <td>
                                                <h3>Today Payment:
                                                    <asp:Label ID='lblPaymentCookeries' Text='0'></asp:Label></h3>
                                            </td>
                                            <td>
                                                <h3>Today Due:
                                                    <asp:Label ID='lblDueCookeries' Text='0'></asp:Label></h3>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class='panel - body'>";



                panel.Controls.Add(div);

                GridView gridView = new GridView();
                gridView.ID = "gv1";
                panel.Controls.Add(gridView);


                Label div2 = new Label();
                div2.Text = @"</div>
                        </div>";

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