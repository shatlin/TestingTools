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
    public class CycleController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var cycles = db.Cycles.Include(c => c.Project);
            return View(cycles.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Cycle cycle = db.Cycles.Find(id);
            if (cycle == null)
            {
                return HttpNotFound();
            }
            return View(cycle);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cycle cycle)
        {
            if (ModelState.IsValid)
            {
                db.Cycles.Add(cycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", cycle.ProjectId);
            return View(cycle);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cycle cycle = db.Cycles.Find(id);
            if (cycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", cycle.ProjectId);
            return View(cycle);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cycle cycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cycle).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", cycle.ProjectId);
            return View(cycle);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cycle cycle = db.Cycles.Find(id);
            if (cycle == null)
            {
                return HttpNotFound();
            }
            return View(cycle);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cycle cycle = db.Cycles.Find(id);
            db.Cycles.Remove(cycle);
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