using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Transaction
{
    public partial class Create : System.Web.UI.Page
    {
        DataOperation _db = new DataOperation();
        private int transId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_ddlCategory1();
                try
                {
                    transId = Convert.ToInt32(Request.QueryString["id"]);
                    if (transId > 0) lblTransId.Text = transId.ToString();
                    LoadEdit(transId);
                }
                catch (Exception exception)
                {
                    //
                }
                

            }
        }

        private void LoadEdit(int transId)
        {
            string strQuery = @"SELECT *
                                FROM [dbo].[Transaction]
                                where TransId="+ transId;
            DataTable dt = _db.GetDataTable(strQuery);
            Load_ddlCategory1();
            ddlCategory1.SelectedValue = dt.Rows[0]["Category1Id"].ToString();
            Load_ddlCategory2();
            ddlCategory2.SelectedValue = dt.Rows[0]["Category2Id"].ToString();
            Load_ddlCategory3();
            ddlCategory3.SelectedValue = dt.Rows[0]["Category3Id"].ToString();
            Load_ddlAccount();
            ddlAccount.SelectedValue = dt.Rows[0]["AccountId"].ToString();
            txtTransComment.Text = dt.Rows[0]["TransComment"]?.ToString() ?? "";
            txtTransTotal.Text = dt.Rows[0]["TransTotal"].ToString();
        }

        private void Load_ddlCategory1()
        {
            string strQuery = @"SELECT -1 as [Id]
                                      , '' as [Name]
                                union all
                                SELECT [Id]
                                      ,[Name]
                                FROM [dbo].[Category]
                                where CategoryLevel=1";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlCategory1.DataSource = dt;
            ddlCategory1.DataBind();
        }
        private void Load_ddlCategory2()
        {
            string strQuery = @"SELECT -1 as [Id]
                                      , '' as [Name]
                                union all
                                SELECT [Id]
                                      ,[Name]
                                FROM [dbo].[Category]
                                where CategoryLevel=2 and ParentCategoryId = " + ddlCategory1.SelectedValue;
            DataTable dt = _db.GetDataTable(strQuery);
            ddlCategory2.DataSource = dt;
            ddlCategory2.DataBind();
        }
        private void Load_ddlCategory3()
        {
            string strQuery = @"SELECT -1 as [Id]
                                      , '' as [Name]
                                union all
                                SELECT [Id]
                                      ,[Name]
                                FROM [dbo].[Category]
                                where CategoryLevel=3 and ParentCategoryId = " + ddlCategory2.SelectedValue;
            DataTable dt = _db.GetDataTable(strQuery);
            ddlCategory3.DataSource = dt;
            ddlCategory3.DataBind();
        }
        private void Load_ddlAccount()
        {
            string strQuery = @"SELECT -1 as [Id]
                                      , '' as [Name]
                                union all
                                select Id,Description+'-'+[Name] as Name
                                from [dbo].[Account] 
                                where AccountTypeId=(
				                                SELECT max(AccountTypeId)
				                                FROM [dbo].[Category] 
				                                where Id=" + ddlCategory3.SelectedValue+" )";
            DataTable dt = _db.GetDataTable(strQuery);
            ddlAccount.DataSource = dt;
            ddlAccount.DataBind();
        }
        protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCategory2.Items.Clear();
            ddlCategory3.Items.Clear();
            ddlAccount.Items.Clear();
            Load_ddlCategory2();
        }

        protected void ddlCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCategory3.Items.Clear();
            ddlAccount.Items.Clear();
            Load_ddlCategory3();
        }

        protected void ddlCategory3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAccount.Items.Clear();
            Load_ddlAccount();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                transId = Convert.ToInt32(Request.QueryString["id"]);
                string strQuery = "";
                string category1 = ddlCategory1.SelectedValue;
                string category2 = ddlCategory2.SelectedValue;
                string category3 = ddlCategory3.SelectedValue;
                string account = ddlAccount.SelectedValue;
                string comment = txtTransComment.Text.Trim();
                string total = txtTransTotal.Text.Trim()==string.Empty ? "null": txtTransTotal.Text.Trim();
                if (transId == 0)
                {
                    strQuery = @"insert into [dbo].[Transaction]
                values(
                        (select isnull(max(TransId),0)+1 from [dbo].[Transaction]),
                    " + category1 + "," + category2 + "," + category3 + "," + account + "," + total +
                                      ",0,'" + DateTime.UtcNow + "','" + comment + "','FALSE')";
                }
                else
                {
                    strQuery = " update [dbo].[Transaction] ";
                    strQuery +=Environment.NewLine + " set Category1Id= "+category1;
                    strQuery += Environment.NewLine + " ,Category2Id= "+category2;
                    strQuery += Environment.NewLine + " ,Category3Id= "+category3;
                    strQuery += Environment.NewLine + " ,AccountId= " + account;
                    strQuery += Environment.NewLine + " ,TransTotal= " + total;
                    strQuery += Environment.NewLine + " ,TransComment= '" + comment+"'";
                    strQuery += Environment.NewLine + " Where TransId= " + transId + "";
                }
                _db.ExecuteNonQuery(strQuery);
                Response.Redirect("Index",true);
            }
            catch (Exception ex)
            {
                //ignore
            }
        }
    }
}