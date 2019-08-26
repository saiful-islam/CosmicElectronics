using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nop.Admin.Models.Common;

namespace Nop.Admin.Controllers
{
    public class DailyCashController : Controller
    {
        // GET: DailyCash
        public ActionResult Index()
        {
            CostCashInCalculation();
            return View();
        }
        public void CostCashInCalculation()
        {
            DataOperation dataOperation = new DataOperation();
            string _query = "EXEC [dbo].[SP_CashInOut] @date='" + DateTime.UtcNow + "';";
            DataTable dt = dataOperation.GetDataTableAccounts(_query);
            _query = "EXEC [dbo].[TotalCostInput] @Cost=" + dt.Rows[0][0];
            dataOperation.ExecuteNonQuery(_query);
            _query = "EXEC [dbo].[TotalCashInput] @Cash=" + dt.Rows[0][1];
            dataOperation.ExecuteNonQuery(_query);

        }
        public ActionResult CostCashIn()
        {
            return View();
        }
        public ActionResult CostInput()
        {
            try
            {
                string cost = Request["txtCost"].ToString();
                if (cost.Trim() != "")
                {
                    string _query = "EXEC [dbo].[TotalCostInput] @Cost=" + cost;
                    DataOperation _dataOperation = new DataOperation();
                    _dataOperation.ExecuteNonQuery(_query);
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
            return View("CostCashIn");
        }
        public ActionResult CashInput()
        {
            try
            {
                string cash = Request["txtCashIn"].ToString();
                if (cash.Trim() != "")
                {
                    string _query = "EXEC [dbo].[TotalCashInput] @Cash=" + cash;
                    DataOperation _dataOperation = new DataOperation();
                    _dataOperation.ExecuteNonQuery(_query);
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
            return View("CostCashIn");
        }
    }
}