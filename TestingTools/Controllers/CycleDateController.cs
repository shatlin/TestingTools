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
    public class CycleDateController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /CycleDate/

        public ActionResult Index()
        {
            var cycledates = db.CycleDates.Include(c => c.Cycle);
            return View(cycledates.ToList());
        }

        //
        // GET: /CycleDate/Details/5

        public ActionResult Details(int id = 0)
        {
            CycleDate cycledate = db.CycleDates.Find(id);
            if (cycledate == null)
            {
                return HttpNotFound();
            }
            return View(cycledate);
        }

        //
        // GET: /CycleDate/Create

        public ActionResult Create()
        {
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName");
            return View();
        }

        //
        // POST: /CycleDate/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CycleDate cycledate)
        {
            if (ModelState.IsValid)
            {
                db.CycleDates.Add(cycledate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName", cycledate.CycleId);
            return View(cycledate);
        }

        //
        // GET: /CycleDate/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CycleDate cycledate = db.CycleDates.Find(id);
            if (cycledate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName", cycledate.CycleId);
            return View(cycledate);
        }

        //
        // POST: /CycleDate/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CycleDate cycledate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cycledate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName", cycledate.CycleId);
            return View(cycledate);
        }

        //
        // GET: /CycleDate/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CycleDate cycledate = db.CycleDates.Find(id);
            if (cycledate == null)
            {
                return HttpNotFound();
            }
            return View(cycledate);
        }

        //
        // POST: /CycleDate/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CycleDate cycledate = db.CycleDates.Find(id);
            db.CycleDates.Remove(cycledate);
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