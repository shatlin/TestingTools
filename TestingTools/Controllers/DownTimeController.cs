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
    public class DownTimeController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var downtimes = db.DownTimes.Include(d => d.Cycle).Include(d => d.System);
            return View(downtimes.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            DownTime downtime = db.DownTimes.Find(id);
            if (downtime == null)
            {
                return HttpNotFound();
            }
            return View(downtime);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName");
            ViewBag.SystemId = new SelectList(db.Systems1, "Id", "SystemName");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DownTime downtime)
        {
            if (ModelState.IsValid)
            {
                db.DownTimes.Add(downtime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName", downtime.CycleId);
            ViewBag.SystemId = new SelectList(db.Systems1, "Id", "SystemName", downtime.SystemId);
            return View(downtime);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DownTime downtime = db.DownTimes.Find(id);
            if (downtime == null)
            {
                return HttpNotFound();
            }
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName", downtime.CycleId);
            ViewBag.SystemId = new SelectList(db.Systems1, "Id", "SystemName", downtime.SystemId);
            return View(downtime);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DownTime downtime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downtime).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "CycleName", downtime.CycleId);
            ViewBag.SystemId = new SelectList(db.Systems1, "Id", "SystemName", downtime.SystemId);
            return View(downtime);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DownTime downtime = db.DownTimes.Find(id);
            if (downtime == null)
            {
                return HttpNotFound();
            }
            return View(downtime);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownTime downtime = db.DownTimes.Find(id);
            db.DownTimes.Remove(downtime);
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