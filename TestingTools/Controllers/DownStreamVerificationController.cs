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
    public class DownStreamVerificationController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /DownStreamVerification/

        //public ActionResult Index()
        //{
        //    var downstreamverifications = db.DownStreamVerifications.Include(d => d.Allocation).Include(d => d.DownStream).Include(d => d.ResultList).Include(d => d.User);
        //    return View(downstreamverifications.ToList());
        //}

        //
        // GET: /DownStreamVerification/Details/5

        public ActionResult Details(int id = 0)
        {
            DownStreamVerification downstreamverification = db.DownStreamVerifications.Find(id);
            if (downstreamverification == null)
            {
                return HttpNotFound();
            }
            return View(downstreamverification);
        }

        //
        // GET: /DownStreamVerification/Create

        public ActionResult Create()
        {
            ViewBag.AllocationId = new SelectList(db.Allocations, "Id", "ScenarioName");
            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName");
            ViewBag.ResultId = new SelectList(db.ResultLists, "Id", "ResultName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId");
            return View();
        }

        //
        // POST: /DownStreamVerification/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DownStreamVerification downstreamverification)
        {
            if (ModelState.IsValid)
            {
                db.DownStreamVerifications.Add(downstreamverification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllocationId = new SelectList(db.Allocations, "Id", "ScenarioName", downstreamverification.AllocationId);
            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName", downstreamverification.DownStreamId);
            ViewBag.ResultId = new SelectList(db.ResultLists, "Id", "ResultName", downstreamverification.ResultId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", downstreamverification.UserId);
            return View(downstreamverification);
        }

        //
        // GET: /DownStreamVerification/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DownStreamVerification downstreamverification = db.DownStreamVerifications.Find(id);
            if (downstreamverification == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllocationId = new SelectList(db.Allocations, "Id", "ScenarioName", downstreamverification.AllocationId);
            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName", downstreamverification.DownStreamId);
            ViewBag.ResultId = new SelectList(db.ResultLists, "Id", "ResultName", downstreamverification.ResultId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", downstreamverification.UserId);
            return View(downstreamverification);
        }

        //
        // POST: /DownStreamVerification/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DownStreamVerification downstreamverification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downstreamverification).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllocationId = new SelectList(db.Allocations, "Id", "ScenarioName", downstreamverification.AllocationId);
            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName", downstreamverification.DownStreamId);
            ViewBag.ResultId = new SelectList(db.ResultLists, "Id", "ResultName", downstreamverification.ResultId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", downstreamverification.UserId);
            return View(downstreamverification);
        }

        //
        // GET: /DownStreamVerification/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DownStreamVerification downstreamverification = db.DownStreamVerifications.Find(id);
            if (downstreamverification == null)
            {
                return HttpNotFound();
            }
            return View(downstreamverification);
        }

        //
        // POST: /DownStreamVerification/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownStreamVerification downstreamverification = db.DownStreamVerifications.Find(id);
            db.DownStreamVerifications.Remove(downstreamverification);
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