using WebApiCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApiCore.Controllers
{
    [AuthActionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Charts()
        {
            return View();
        }

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View();
        }

        public ActionResult BootstrapElements()
        {
            return View();
        }

        public ActionResult BootstrapGrid()
        {
            return View();
        }

        public ActionResult BlankPage()
        {
            return View();
        }


    }
}