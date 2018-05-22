using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Donor2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";

            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.Title = "Registration Page";
            return View();

        }
    }
}
