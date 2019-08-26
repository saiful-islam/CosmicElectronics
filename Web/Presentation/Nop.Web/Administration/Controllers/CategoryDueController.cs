using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Admin.Controllers
{
    public class CategoryDueController : Controller
    {
        // GET: CategoryDue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderDueList()
        {
            return View();
        }
        public ActionResult TodaySale()
        {
            return View();
        }
    }

    public class CategoryTodaySale
    {
        public string CategoryName;
        public decimal TotalOrder;
        public decimal TotalDue;
        public decimal TotalPayment;
    }
}