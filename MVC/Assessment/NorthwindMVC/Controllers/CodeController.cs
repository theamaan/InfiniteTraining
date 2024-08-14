using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindMVC.Models;

namespace NorthwindMVC.Controllers
{
    public class CodeController : Controller
    {
        private northwindEntities db = new northwindEntities();

        // GET: Code
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers
                .Where(c => c.Country == "Germany")
                .ToList();
            return View(customers);
        }
        public ActionResult CustomerWithOrderId()
        {
            var customerDetails = db.Orders
                .Where(o => o.OrderID == 10248)
                .Select(o => o.Customer)
                .FirstOrDefault();
            return View(customerDetails);
        }
    }
}