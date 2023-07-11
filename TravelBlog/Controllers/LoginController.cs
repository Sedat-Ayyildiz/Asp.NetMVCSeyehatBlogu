using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelBlog.Models.Siniflar;
using Context = TravelBlog.Models.Siniflar.Context;

namespace TravelBlog.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin klnc)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KULLANICI == klnc.KULLANICI && x.SIFRE == klnc.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                Session["KULLANICI"] = bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya Şisfre hatalı !\nLütfen Tekrar deneyiniz.";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}