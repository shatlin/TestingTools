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
    public class UserRoleController : Controller
    {
        private TestingEntities db = new TestingEntities();

        //
        // GET: /UserRole/

        public ActionResult Index()
        {
            var userroles = db.UserRoles.Include(u => u.Role).Include(u => u.User);
            return View(userroles.ToList());
        }

        //
        // GET: /UserRole/Details/5

        public ActionResult Details(int id = 0)
        {
            UserRole userrole = db.UserRoles.Find(id);
            if (userrole == null)
            {
                return HttpNotFound();
            }
            return View(userrole);
        }

        //
        // GET: /UserRole/Create

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId");
            return View();
        }

        //
        // POST: /UserRole/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRole userrole)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userrole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", userrole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", userrole.UserId);
            return View(userrole);
        }

        //
        // GET: /UserRole/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserRole userrole = db.UserRoles.Find(id);
            if (userrole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", userrole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", userrole.UserId);
            return View(userrole);
        }

        //
        // POST: /UserRole/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRole userrole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userrole).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", userrole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserId", userrole.UserId);
            return View(userrole);
        }

        //
        // GET: /UserRole/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserRole userrole = db.UserRoles.Find(id);
            if (userrole == null)
            {
                return HttpNotFound();
            }
            return View(userrole);
        }

        //
        // POST: /UserRole/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRole userrole = db.UserRoles.Find(id);
            db.UserRoles.Remove(userrole);
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