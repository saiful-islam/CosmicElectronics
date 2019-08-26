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
    public partial class Create : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        private int PaymentId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_ddlAccountType();
                Load_ddlPaymentType();
                try
                {
                    PaymentId = Convert.ToInt32(Request.QueryString["id"]);
                    if (PaymentId > 0)
                    {
                        lblPaymentId.Text = PaymentId.ToString();
                        LoadEdit(PaymentId);
                    }
                }
                catch (Exception exception)
                {
                    //
                }
            }
        }

        private void LoadEdit(int paymentId)
        {
            string strQuery = @"SELECT *
                                FROM [dbo].[PaymentTransaction]
                                where [PaymentId]=" + paymentId;
            DataTable dt = _db.GetDataTable(strQuery);
            Load_ddlAccountType();
            Load_ddlPaymentType();
            ddlAccountType.SelectedValue = dt.Rows[0]["AccountTypeId"].ToString();
            ddlPaymentType.SelectedValue = dt.Rows[0]["PaymentTypeId"].ToString();
            Load_ddlAccount();
            ddlAccount.SelectedValue = dt.Rows[0]["AccountId"].ToString();
            txtPayment.Text = dt.Rows[0]["Payment"]?.ToString() ?? "";
            txtComment.Text = dt.Rows[0]["Comment"]?.ToString() ?? "";
        }

        private void Load_ddlAccountType()
        {
            string strQuery = @"SELECT -1 as [Id]
                                      , '' as [Name]
                                union all
                                SELECT [Id]
                                      ,[Name]
                                  FROM [dbo].[AccountType]
                                  where IsActive='True'";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlAccountType.DataSource = dt;
            ddlAccountType.DataBind();
        }
        private void Load_ddlPaymentType()
        {
            string strQuery = @"select *
                                from [dbo].[PaymentType]";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlPaymentType.DataSource = dt;
            ddlPaymentType.DataBind();
        }
        private void Load_ddlAccount()
        {
            string strQuery = @"select Id,[Name]
                                from [dbo].[Account]
                                where AccountTypeId="+ddlAccountType.SelectedValue;
            DataTable dt = _db.GetDataTable(strQuery);
            ddlAccount.DataSource = dt;
            ddlAccount.DataBind();
        }

        protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAccount.Items.Clear();
            Load_ddlAccount();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentId = Convert.ToInt32(Request.QueryString["id"]);
                string strQuery = "";
                string accountTypeId = ddlAccountType.SelectedValue;
                string paymentTypeId = ddlPaymentType.SelectedValue;
                string accountId = ddlAccount.SelectedValue;
                string payment = txtPayment.Text.Trim();
                string comment = txtComment.Text.Trim();
                
                if (PaymentId == 0)
                {
                    strQuery = @"insert into [dbo].[PaymentTransaction]
                values(
                        (select max(PaymentId)+1 from [dbo].[PaymentTransaction]),
                    '" + accountId + "','" + accountTypeId + "','" + paymentTypeId + "','" + payment + "',0,'" + DateTime.UtcNow + "','"+comment+"','False')";
                }
                else
                {
                    strQuery = " update [dbo].[PaymentTransaction] ";
                    strQuery += Environment.NewLine + " set AccountId= '" + accountId + "'";
                    strQuery += Environment.NewLine + " ,AccountTypeId= '" + accountTypeId + "'";
                    strQuery += Environment.NewLine + " ,[PaymentTypeId]= '" + paymentTypeId + "'";
                    strQuery += Environment.NewLine + " ,[Payment]= '" + payment + "'";
                    strQuery += Environment.NewLine + " ,[Comment]= '" + comment+"'";
                    strQuery += Environment.NewLine + " Where PaymentId= " + PaymentId;
                }
                _db.ExecuteNonQuery(strQuery);
                if (ddlPaymentType.SelectedValue == "1")
                {
                    Response.Redirect("Due", true);
                }
                else
                {
                    Response.Redirect("Payment", true);
                }
                
            }
            catch (Exception ex)
            {
                //ignore
            }
        }
    }
}