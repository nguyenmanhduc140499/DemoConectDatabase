using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoConectDatabase.Models;

namespace DemoConectDatabase.Controllers
{
    public class StudentsListController : Controller
    {
        private LaptringquanlyDBcontext db = new LaptringquanlyDBcontext();
        ExcelProcess excelPro = new ExcelProcess();
        public DataTable CopyDataFromExcelFile(HttpPostedFileBase file)
        {
            string fileExtention = file.FileName.Substring(file.FileName.IndexOf("."));
            string _fileName = "danh sach sinh vien" + fileExtention;
            string _path = Path.Combine(Server.MapPath("~/uploadExcel"), _fileName);
            file.SaveAs(_path);
            DataTable dt = excelPro.ReadDataFromExcelFile(_path, true);
            return dt;
        }

        // GET: Employes/StudentsList
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(HttpPostedFileBase file)
        {
            DataTable dt = CopyDataFromExcelFile(file);
            OverWriteFastData(dt);
            return RedirectToAction("Index", "Student");
        }
        // GET: Employes/StudentsList/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Employes/StudentsList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employes/StudentsList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Employes/StudentsList/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Employes/StudentsList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Employes/StudentsList/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Employes/StudentsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LaptrinhquanlyDBContext"].ConnectionString);
        private void OverWriteFastData(DataTable dt)
        {   
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.DestinationTableName = "Student";
            bulkCopy.ColumnMappings.Add(0, "StudentID");
            bulkCopy.ColumnMappings.Add(1, "StudentName");
            con.Open();
            bulkCopy.WriteToServer(dt);
            con.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
