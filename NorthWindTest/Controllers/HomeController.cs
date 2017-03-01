using NorthWindTest.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace NorthWindTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult GetCustomerList()
        {
            try
            {

                string lst = ServicesFactory.CustomerService.GetCustomersReturnJson();

                return Content(lst);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);


            }
        }
    }
}