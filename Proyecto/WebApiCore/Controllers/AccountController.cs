using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebApiCore.Domain;
using WebApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using Microsoft.Owin.Host.SystemWeb;
using WebApiCore.ConnectionClass;

namespace WebApiCore.Controllers
{
    public class AccountController : Controller
    {

        // conexion con base de datos
        ClassConnection con = new ClassConnection();

        IAuthenticationManager Authentication
        {

            get { return HttpContext.GetOwinContext().Authentication; }
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.UserName.Trim() != "" || model.Password.Trim() != "")
            {
                con.Conectar();
                int result = con.loginUser("select dbo.loginUser('" + model.UserName.Trim() + "','" + model.Password.Trim() + "')");
                if (result != -1)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "admin"/*model.UserName*/), }, DefaultAuthenticationTypes.ApplicationCookie);
                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, identity);
                    con.Desconectar();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    con.Desconectar();
                    Messagebox("Usuario o contraseña inválidas.");
                    return View(model);
                    
                }
                
            }
            else
            {
                Messagebox("Ingrese todos los campos.");
                return View(model);

            }

        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private void Messagebox(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }

    }
}