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
    public class BlockedReasonController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /BlockedReason/

        public ActionResult Index()
        {
            return View(db.BlockedReasonLists.ToList());
        }

        //
        // GET: /BlockedReason/Details/5

        public ActionResult Details(int id = 0)
        {
            BlockedReasonList blockedreasonlist = db.BlockedReasonLists.Find(id);
            if (blockedreasonlist == null)
            {
                return HttpNotFound();
            }
            return View(blockedreasonlist);
        }

        //
        // GET: /BlockedReason/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BlockedReason/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlockedReasonList blockedreasonlist)
        {
            if (ModelState.IsValid)
            {
                db.BlockedReasonLists.Add(blockedreasonlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blockedreasonlist);
        }

        //
        // GET: /BlockedReason/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BlockedReasonList blockedreasonlist = db.BlockedReasonLists.Find(id);
            if (blockedreasonlist == null)
            {
                return HttpNotFound();
            }
            return View(blockedreasonlist);
        }

        //
        // POST: /BlockedReason/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlockedReasonList blockedreasonlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blockedreasonlist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blockedreasonlist);
        }

        //
        // GET: /BlockedReason/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BlockedReasonList blockedreasonlist = db.BlockedReasonLists.Find(id);
            if (blockedreasonlist == null)
            {
                return HttpNotFound();
            }
            return View(blockedreasonlist);
        }

        //
        // POST: /BlockedReason/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlockedReasonList blockedreasonlist = db.BlockedReasonLists.Find(id);
            db.BlockedReasonLists.Remove(blockedreasonlist);
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