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
    public class ReadyForReleaseListController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /ReadyForReleaseList/

        public ActionResult Index()
        {
            return View(db.ReadyForReleaseLists.ToList());
        }

        //
        // GET: /ReadyForReleaseList/Details/5

        public ActionResult Details(int id = 0)
        {
            ReadyForReleaseList readyforreleaselist = db.ReadyForReleaseLists.Find(id);
            if (readyforreleaselist == null)
            {
                return HttpNotFound();
            }
            return View(readyforreleaselist);
        }

        //
        // GET: /ReadyForReleaseList/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ReadyForReleaseList/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReadyForReleaseList readyforreleaselist)
        {
            if (ModelState.IsValid)
            {
                db.ReadyForReleaseLists.Add(readyforreleaselist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(readyforreleaselist);
        }

        //
        // GET: /ReadyForReleaseList/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReadyForReleaseList readyforreleaselist = db.ReadyForReleaseLists.Find(id);
            if (readyforreleaselist == null)
            {
                return HttpNotFound();
            }
            return View(readyforreleaselist);
        }

        //
        // POST: /ReadyForReleaseList/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReadyForReleaseList readyforreleaselist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(readyforreleaselist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(readyforreleaselist);
        }

        //
        // GET: /ReadyForReleaseList/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReadyForReleaseList readyforreleaselist = db.ReadyForReleaseLists.Find(id);
            if (readyforreleaselist == null)
            {
                return HttpNotFound();
            }
            return View(readyforreleaselist);
        }

        //
        // POST: /ReadyForReleaseList/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReadyForReleaseList readyforreleaselist = db.ReadyForReleaseLists.Find(id);
            db.ReadyForReleaseLists.Remove(readyforreleaselist);
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