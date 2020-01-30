using WebApiCore.Domain;
using WebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiCore.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Navbar(string controller, string action)
        {
            var data = new Data();

            var navbar = data.itemsPerUser(controller, action, User.Identity.Name);

            return PartialView("_navbar", navbar);
        }
    }
}