﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class DownStreamController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /DownStream/

        public ActionResult Index()
        {
            return View(db.DownStreams.ToList());
        }

        //
        // GET: /DownStream/Details/5

        public ActionResult Details(int id = 0)
        {
            DownStream downstream = db.DownStreams.Find(id);
            if (downstream == null)
            {
                return HttpNotFound();
            }
            return View(downstream);
        }

        //
        // GET: /DownStream/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DownStream/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DownStream downstream)
        {
            if (ModelState.IsValid)
            {
                db.DownStreams.Add(downstream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(downstream);
        }

        //
        // GET: /DownStream/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DownStream downstream = db.DownStreams.Find(id);
            if (downstream == null)
            {
                return HttpNotFound();
            }
            return View(downstream);
        }

        //
        // POST: /DownStream/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DownStream downstream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downstream).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(downstream);
        }

        //
        // GET: /DownStream/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DownStream downstream = db.DownStreams.Find(id);
            if (downstream == null)
            {
                return HttpNotFound();
            }
            return View(downstream);
        }

        //
        // POST: /DownStream/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownStream downstream = db.DownStreams.Find(id);
            db.DownStreams.Remove(downstream);
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