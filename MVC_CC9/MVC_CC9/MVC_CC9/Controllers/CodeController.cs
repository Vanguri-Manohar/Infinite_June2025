using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CC9.Models;
namespace MVC_CC9.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }

        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                           .Where(o => o.OrderID == 10248)
                           .Select(o => o.Customer).ToList();
                           

            return View(customer);
        }

    }
}