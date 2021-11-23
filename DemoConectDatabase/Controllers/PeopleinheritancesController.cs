using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoConectDatabase.Models;

namespace DemoConectDatabase.Controllers
{
    public class PeopleinheritancesController : Controller
    {
        private LaptringquanlyDBcontext db = new LaptringquanlyDBcontext();

        // GET: Peopleinheritances
        public ActionResult Index()
        {
            return View(db.Peopleinheritances.ToList());
        }

        // GET: Peopleinheritances/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peopleinheritance peopleinheritance = db.Peopleinheritances.Find(id);
            if (peopleinheritance == null)
            {
                return HttpNotFound();
            }
            return View(peopleinheritance);
        }

        // GET: Peopleinheritances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peopleinheritances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeopleID,PeopleName")] Peopleinheritance peopleinheritance)
        {
            if (ModelState.IsValid)
            {
                db.Peopleinheritances.Add(peopleinheritance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peopleinheritance);
        }

        // GET: Peopleinheritances/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peopleinheritance peopleinheritance = db.Peopleinheritances.Find(id);
            if (peopleinheritance == null)
            {
                return HttpNotFound();
            }
            return View(peopleinheritance);
        }

        // POST: Peopleinheritances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeopleID,PeopleName")] Peopleinheritance peopleinheritance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleinheritance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peopleinheritance);
        }

        // GET: Peopleinheritances/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peopleinheritance peopleinheritance = db.Peopleinheritances.Find(id);
            if (peopleinheritance == null)
            {
                return HttpNotFound();
            }
            return View(peopleinheritance);
        }

        // POST: Peopleinheritances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Peopleinheritance peopleinheritance = db.Peopleinheritances.Find(id);
            db.Peopleinheritances.Remove(peopleinheritance);
            db.SaveChanges();
            return RedirectToAction("Index");
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
