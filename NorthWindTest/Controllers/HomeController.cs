using NorthWindTest.Models.ViewModels;
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

        /// <summary>
        /// 測試Get Customer List
        /// </summary>
        /// <returns></returns>
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


        [HttpPost]
        public ActionResult Login(string email, string passwd)
        {
            try
            {
                ViewData["ErrorMsg"] = "敬請期待";
                return View("Index"); 


            }
            catch (Exception ex)
            {
                ViewData["ErrorMsg"] = ex.InnerException.Message;
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Register(AccountViewModel account)
        {
            try
            {
                string tt= account.Email;
                ViewData["ActionType"] = "Register";
                ViewData["ErrorMsg"] = "敬請期待";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMsg"] = ex.InnerException.Message;
                return RedirectToAction("Index", "Home");
            }

        }

    }
}