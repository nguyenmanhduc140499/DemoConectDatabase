using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoConectDatabase.Models;

namespace DemoConectDatabase.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        LaptringquanlyDBcontext db = new LaptringquanlyDBcontext();
        public ActionResult Index()
        {
            return View(db.Student.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}