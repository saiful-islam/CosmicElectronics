﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Report
{
    public partial class StockEntryReport : System.Web.UI.Page
    {
        DataOperationNop _db = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_ddlCategory();
                Load_ddlManufacturer();
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string strQuery = @"EXEC dbo.SP_GET_StockEntryReport @startDate ='"+ txtStartDate.Text.Trim() + "',@endDate='"+ txtToDate.Text.Trim() + "',@categoryId=" + ddlCategory.SelectedValue + ", @mnfId=" + ddlManufacturer.SelectedValue;
            DataTable dt = _db.GetDataTable(strQuery);
            gvCategoryWiseStock.DataSource = dt;
            gvCategoryWiseStock.DataBind();
        }
        private void Load_ddlCategory()
        {
            string strQuery = @"EXEC dbo.SP_GETALLCategory ";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();
        }
        private void Load_ddlManufacturer()
        {
            string strQuery = @"EXEC dbo.SP_GETALLManufacturer ";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlManufacturer.DataSource = dt;
            ddlManufacturer.DataBind();
        }
    }
}