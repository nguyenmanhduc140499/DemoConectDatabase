using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoConectDatabase.Models;
using System.Web.Security;
using System.Security.Cryptography;

namespace DemoConectDatabase.Controllers
{
    // Kiem tra duong dan cos thuoc he thong hay k
    public class AccountController : Controller
    {
        LaptringquanlyDBcontext db = new LaptringquanlyDBcontext();
        [HttpGet]
        public ActionResult Register()
        {
            return View(); 
        }
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.PassWord = PasswordEncrytion(acc.PassWord);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
           }
            return View(acc);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (CheckSession() != 0)
            {
                return RedirectToLocal(returnUrl);
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account acc, string returnUrl)
        {
           // try
            {
                if (!string.IsNullOrEmpty(acc.UserName) && !string.IsNullOrEmpty(acc.PassWord))
                {
                    using (var db = new LaptringquanlyDBcontext())
                    {
                        var passToMD5 = PassEncrytion(acc.PassWord);
                        var account = db.Accounts.Where(m => m.UserName.Equals(acc.UserName) && m.PassWord.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UserName, false);
                            Session["idUser"] = acc.UserName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
                    }
                }
                ModelState.AddModelError("", "Username and password is required.");
            }
            //catch
            //{
            //    ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            //}
            return View(acc);
        }
        private string PassEncrytion(string passWord)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(passWord.Trim(),"MD5");
        }
        //Ham xuat khoi chuong trinh
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "HomeEmp", new { Area = "Employes" });
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
        }
        private int CheckSession()
        {
            using (var db = new LaptringquanlyDBcontext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role != null)
                    {
                        if (role.ToString() == "Admin")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "Quản trị")
                        {       
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }
        private string PasswordEncrytion(string userPassword)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword.Trim(), "MD5");
        }
    }
}