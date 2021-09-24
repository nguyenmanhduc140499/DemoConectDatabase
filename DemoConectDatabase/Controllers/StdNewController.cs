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
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
            //lấy dữ liệu từ client gửi lên và lưu vào database
            var countStudent = db.Student.Count();
            if(countStudent == 0)
            {
                std.StudentID = "ST001";
            }
            return RedirectToAction("Index");
        }
    }
}