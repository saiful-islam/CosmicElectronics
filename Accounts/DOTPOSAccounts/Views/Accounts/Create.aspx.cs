using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Accounts
{
    public partial class Create : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        private int accId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_ddlAccountType();
                try
                {
                    accId = Convert.ToInt32(Request.QueryString["id"]);
                    if (accId > 0) lblAccountId.Text = accId.ToString();
                    LoadEdit(accId);
                }
                catch (Exception exception)
                {
                    //
                }
            }
        }

        private void Load_ddlAccountType()
        {
            string strQuery = @"SELECT [Id]
                                      ,[Name]
                                  FROM [dbo].[AccountType]
                                  where IsActive='True'  
                                  order by [DisplayOrder]";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlAccountType.DataSource = dt;
            ddlAccountType.DataBind();
        }

        private void LoadEdit(int accId)
        {
            string strQuery = @"SELECT *
                                FROM [dbo].[Account]
                                where Id=" + accId;
            DataTable dt = _db.GetDataTable(strQuery);
            Load_ddlAccountType();
            ddlAccountType.SelectedValue = dt.Rows[0]["AccountTypeId"].ToString();
            txtAccountName.Text = dt.Rows[0]["Name"]?.ToString() ?? "";
            txtMobile.Text = dt.Rows[0]["Mobile"]?.ToString() ?? "";
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"]?.ToString() ?? "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                accId = Convert.ToInt32(Request.QueryString["id"]);
                string strQuery = "";
                string accountTypeId = ddlAccountType.SelectedValue;
                string name = txtAccountName.Text.Trim();
                string address = txtAddress.Text.Trim();
                string desc = txtDescription.Text.Trim();
                string mobile = txtMobile.Text.Trim();
                if (accId == 0)
                {
                    strQuery = @"insert into [dbo].[Account]
                values(
                        (select isnull(max(Id),0)+1 from [dbo].[Account]),
                    '" + name + "','" + mobile + "','" + address + "','" + desc + "','" + accountTypeId + "','True','False')";
                }
                else
                {
                    strQuery = " update [dbo].[Account] ";
                    strQuery += Environment.NewLine + " set Name= '" + name+"'";
                    strQuery += Environment.NewLine + " ,Mobile= '" + mobile + "'";
                    strQuery += Environment.NewLine + " ,Address= '" + address + "'";
                    strQuery += Environment.NewLine + " ,Description= '" + desc + "'";
                    strQuery += Environment.NewLine + " ,AccountTypeId= " + accountTypeId;
                    strQuery += Environment.NewLine + " Where Id= " + accId ;
                }
                _db.ExecuteNonQuery(strQuery);
                Response.Redirect("Index", true);
            }
            catch (Exception ex)
            {
                //ignore
            }
        }
    }
}