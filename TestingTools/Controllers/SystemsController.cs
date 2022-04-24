using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class SystemsController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /Systems/

        public ActionResult Index()
        {
            return View(db.Systems1.ToList());
        }

        //
        // GET: /Systems/Details/5

        public ActionResult Details(int id = 0)
        {
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return HttpNotFound();
            }
            return View(systems);
        }

        //
        // GET: /Systems/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Systems/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Systems systems)
        {
            if (ModelState.IsValid)
            {
                db.Systems1.Add(systems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systems);
        }

        //
        // GET: /Systems/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return HttpNotFound();
            }
            return View(systems);
        }

        //
        // POST: /Systems/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Systems systems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systems).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systems);
        }

        //
        // GET: /Systems/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return HttpNotFound();
            }
            return View(systems);
        }

        //
        // POST: /Systems/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Systems systems = db.Systems1.Find(id);
            db.Systems1.Remove(systems);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}