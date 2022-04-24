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
    public class DownStreamUserController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /DownStreamUser/

        public ActionResult Index()
        {
            var downstreamusers = db.DownStreamUsers.Include(d => d.DownStream).Include(d => d.User);
            return View(downstreamusers.ToList());
        }

        //
        // GET: /DownStreamUser/Details/5

        public ActionResult Details(int id = 0)
        {
            DownStreamUser downstreamuser = db.DownStreamUsers.Find(id);
            if (downstreamuser == null)
            {
                return HttpNotFound();
            }
            return View(downstreamuser);
        }

        //
        // GET: /DownStreamUser/Create

        public ActionResult Create()
        {
            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId");
            return View();
        }

        //
        // POST: /DownStreamUser/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DownStreamUser downstreamuser)
        {
            if (ModelState.IsValid)
            {
                db.DownStreamUsers.Add(downstreamuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName", downstreamuser.DownStreamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", downstreamuser.UserId);
            return View(downstreamuser);
        }

        //
        // GET: /DownStreamUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DownStreamUser downstreamuser = db.DownStreamUsers.Find(id);
            if (downstreamuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName", downstreamuser.DownStreamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", downstreamuser.UserId);
            return View(downstreamuser);
        }

        //
        // POST: /DownStreamUser/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DownStreamUser downstreamuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downstreamuser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DownStreamId = new SelectList(db.DownStreams, "Id", "DownStreamName", downstreamuser.DownStreamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", downstreamuser.UserId);
            return View(downstreamuser);
        }

        //
        // GET: /DownStreamUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DownStreamUser downstreamuser = db.DownStreamUsers.Find(id);
            if (downstreamuser == null)
            {
                return HttpNotFound();
            }
            return View(downstreamuser);
        }

        //
        // POST: /DownStreamUser/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownStreamUser downstreamuser = db.DownStreamUsers.Find(id);
            db.DownStreamUsers.Remove(downstreamuser);
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