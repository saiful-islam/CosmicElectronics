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
            decimal totalOrderCookeries = 0;
            decimal totalPaymentCookeries = 0;
            decimal totalDueCookeries = 0;
            decimal totalOrderFurniture = 0;
            decimal totalPaymentFurniture = 0;
            decimal totalDueFurniture = 0;
            decimal totalOrderFoamPorda = 0;
            decimal totalPaymentFoamPorda = 0;
            decimal totalDueFoamPorda = 0;
            decimal totalOrderElectronics = 0;
            decimal totalPaymentElectronics = 0;
            decimal totalDueElectronics = 0;
            decimal totalOrderDoors = 0;
            decimal totalPaymentDoors = 0;
            decimal totalDueDoors = 0;
            decimal totalOrderPartical = 0;
            decimal totalPaymentPartical = 0;
            decimal totalDuePartical = 0;
            decimal totalOrderShegun = 0;
            decimal totalPaymentShegun = 0;
            decimal totalDueShegun = 0;
            string strQuery = "exec [dbo].[SP_CategoryWiseTotalSell] @sellDate='"+saleDate+"'";
            DataTable dt = _db.GetDataTable(strQuery);

            DataTable dtCookeries= dt.Clone();
            DataTable dtFurniture = dt.Clone();
            DataTable dtFoamPorda= dt.Clone();
            DataTable dtElectronics = dt.Clone();
            DataTable dtDoors = dt.Clone();
            DataTable dtPartical = dt.Clone();
            DataTable dtShegun = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CategoryId"].ToString() == "1") //Cookeries
                {
                    dtCookeries.ImportRow(dt.Rows[i]);
                    totalOrderCookeries += Convert.ToDecimal(dt.Rows[i]["TotalOrder"]);
                    totalPaymentCookeries += Convert.ToDecimal(dt.Rows[i]["TotalPayment"]);
                    totalDueCookeries += Convert.ToDecimal(dt.Rows[i]["TotalDue"]);
                }
                else if (dt.Rows[i]["CategoryId"].ToString() == "2") //Furniture
                {
                    dtFurniture.ImportRow(dt.Rows[i]);
                    totalOrderFurniture += Convert.ToDecimal(dt.Rows[i]["TotalOrder"]);
                    totalPaymentFurniture += Convert.ToDecimal(dt.Rows[i]["TotalPayment"]);
                    totalDueFurniture += Convert.ToDecimal(dt.Rows[i]["TotalDue"]);
                }
                else if (dt.Rows[i]["CategoryId"].ToString() == "3") //Foam & Porda
                {
                    dtFoamPorda.ImportRow(dt.Rows[i]);
                    totalOrderFoamPorda += Convert.ToDecimal(dt.Rows[i]["TotalOrder"]);
                    totalPaymentFoamPorda += Convert.ToDecimal(dt.Rows[i]["TotalPayment"]);
                    totalDueFoamPorda += Convert.ToDecimal(dt.Rows[i]["TotalDue"]);
                }
                else if (dt.Rows[i]["CategoryId"].ToString() == "4") //Electronics
                {
                    dtElectronics.ImportRow(dt.Rows[i]);
                    totalOrderElectronics += Convert.ToDecimal(dt.Rows[i]["TotalOrder"]);
                    totalPaymentElectronics += Convert.ToDecimal(dt.Rows[i]["TotalPayment"]);
                    totalDueElectronics += Convert.ToDecimal(dt.Rows[i]["TotalDue"]);
                }
                else if (dt.Rows[i]["CategoryId"].ToString() == "5") //Doors
                {
                    dtDoors.ImportRow(dt.Rows[i]);
                    totalOrderDoors += Convert.ToDecimal(dt.Rows[i]["TotalOrder"]);
                    totalPaymentDoors += Convert.ToDecimal(dt.Rows[i]["TotalPayment"]);
                    totalDueDoors += Convert.ToDecimal(dt.Rows[i]["TotalDue"]);
                }
                else if (dt.Rows[i]["CategoryId"].ToString() == "9") //Shegun Wood Furniture
                {
                    dtShegun.ImportRow(dt.Rows[i]);
                    totalOrderShegun += Convert.ToDecimal(dt.Rows[i]["TotalOrder"]);
                    totalPaymentShegun += Convert.ToDecimal(dt.Rows[i]["TotalPayment"]);
                    totalDueShegun += Convert.ToDecimal(dt.Rows[i]["TotalDue"]);
                }
                else //Partical Board & Hrdware
                {
                    dtPartical.ImportRow(dt.Rows[i]);
                    totalOrderPartical += Convert.ToDecimal(dt.Rows[i]["TotalOrder"]);
                    totalPaymentPartical += Convert.ToDecimal(dt.Rows[i]["TotalPayment"]);
                    totalDuePartical += Convert.ToDecimal(dt.Rows[i]["TotalDue"]);
                }
            }
            gvCookeries.DataSource = dtCookeries;
            gvCookeries.DataBind();
            lblOrderCookeries.Text = totalOrderCookeries.ToString(CultureInfo.InvariantCulture);
            lblPaymentCookeries.Text = totalPaymentCookeries.ToString(CultureInfo.InvariantCulture);
            lblDueCookeries.Text = totalDueCookeries.ToString(CultureInfo.InvariantCulture);

            gvFurniture.DataSource = dtFurniture;
            gvFurniture.DataBind();
            lblOrderFurniture.Text = totalOrderFurniture.ToString(CultureInfo.InvariantCulture);
            lblPaymentFurniture.Text = totalPaymentFurniture.ToString(CultureInfo.InvariantCulture);
            lblDueFurniture.Text = totalDueFurniture.ToString(CultureInfo.InvariantCulture);

            gvFoam_Porda.DataSource = dtFoamPorda;
            gvFoam_Porda.DataBind();
            lblOrderFoam_Porda.Text = totalOrderFoamPorda.ToString(CultureInfo.InvariantCulture);
            lblPaymentFoam_Porda.Text = totalPaymentFoamPorda.ToString(CultureInfo.InvariantCulture);
            lblDueFoam_Porda.Text = totalDueFoamPorda.ToString(CultureInfo.InvariantCulture);

            gvElectronics.DataSource = dtElectronics;
            gvElectronics.DataBind();
            lblOrderElectronics.Text = totalOrderElectronics.ToString(CultureInfo.InvariantCulture);
            lblPaymentElectronics.Text = totalPaymentElectronics.ToString(CultureInfo.InvariantCulture);
            lblDueElectronics.Text = totalDueElectronics.ToString(CultureInfo.InvariantCulture);

            gvDoors.DataSource = dtDoors;
            gvDoors.DataBind();
            lblOrderDoors.Text = totalOrderDoors.ToString(CultureInfo.InvariantCulture);
            lblPaymentDoors.Text = totalPaymentDoors.ToString(CultureInfo.InvariantCulture);
            lblDueDoors.Text = totalDueDoors.ToString(CultureInfo.InvariantCulture);

            gvPartical.DataSource = dtPartical;
            gvPartical.DataBind();
            lblOrderPartical.Text = totalOrderPartical.ToString(CultureInfo.InvariantCulture);
            lblPaymentPartical.Text = totalPaymentPartical.ToString(CultureInfo.InvariantCulture);
            lblDuePartical.Text = totalDuePartical.ToString(CultureInfo.InvariantCulture);

            gvShegun.DataSource = dtShegun;
            gvShegun.DataBind();
            lblOrderShegun.Text = totalOrderShegun.ToString(CultureInfo.InvariantCulture);
            lblPaymentShegun.Text = totalPaymentShegun.ToString(CultureInfo.InvariantCulture);
            lblDueShegun.Text = totalDueShegun.ToString(CultureInfo.InvariantCulture);
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