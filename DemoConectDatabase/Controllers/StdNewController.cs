using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoConectDatabase.Models;
namespace DemoConectDatabase.Controllers
{
    public class StdNewController : Controller
    {
        LaptringquanlyDBcontext db = new LaptringquanlyDBcontext();
        StringProcess genKey = new StringProcess();
        // GET: StdNew
        public ActionResult Index()
        {
            return View(db.Student.ToList());
        }
        public ActionResult Create()
        {
            var stdID = "";
            var countStudent = db.Student.Count();
            if (countStudent == 0)
            {
                stdID= "ST001";
            }
            else
            {// lấy giá trị studentID mới nhất
                var studenID = db.Student.ToList().OrderByDescending(m => m.StudentID).FirstOrDefault().StudentID;
                //sinh ra studentID tự động
                stdID = genKey.AutoGeneredKey(studenID);
            }
            ViewBag.studentID = stdID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                //Lưu thông tin vào database
                db.Student.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(std);
        }
    }
}