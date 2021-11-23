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
    public class ChildrenController : Controller
    {
        private LaptringquanlyDBcontext db = new LaptringquanlyDBcontext();

        // GET: Children
        public ActionResult Index()
        {
            return View(db.Childrens.ToList());
        }

        // GET: Children/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Childrens.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // GET: Children/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeopleID,PeopleName,ChildrenID,Age")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Peopleinheritances.Add(children);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(children);
        }

        // GET: Children/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Childrens.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeopleID,PeopleName,ChildrenID,Age")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Entry(children).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(children);
        }

        // GET: Children/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Childrens.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Children children = db.Childrens.Find(id);
            db.Peopleinheritances.Remove(children);
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
