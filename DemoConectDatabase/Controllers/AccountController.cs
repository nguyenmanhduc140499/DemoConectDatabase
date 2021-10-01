using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoConectDatabase.Models;
using System.Web.Security;

namespace DemoConectDatabase.Controllers
{
    // Kiem tra duong dan cos thuoc he thong hay k
    public class AccountController : Controller
    {
        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (acc.UserName == "admin" && acc.UserPassword == "140499")
                {
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    return RedirectToLocal(returnUrl);
                }
            }
            return View();
        }
        //Ham xuat khoi chuong trinh
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else { return RedirectToAction("Index", "Home"); }
        }
    }
}