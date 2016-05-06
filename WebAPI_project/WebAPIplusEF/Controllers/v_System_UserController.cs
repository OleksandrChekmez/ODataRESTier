using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAPIplusEF;

namespace WebAPIplusEF.Controllers
{
    public class v_System_UserController : Controller
    {
        private Entities db = new Entities();

        // GET: v_System_User
        public ActionResult Index()
        {
            return View(db.v_System_User.ToList());
        }

        // GET: v_System_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_System_User v_System_User = db.v_System_User.Find(id);
            if (v_System_User == null)
            {
                return HttpNotFound();
            }
            return View(v_System_User);
        }

        // GET: v_System_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v_System_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SYSTEM_USER,CURRENT_USER")] v_System_User v_System_User)
        {
            if (ModelState.IsValid)
            {
                db.v_System_User.Add(v_System_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_System_User);
        }

        // GET: v_System_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_System_User v_System_User = db.v_System_User.Find(id);
            if (v_System_User == null)
            {
                return HttpNotFound();
            }
            return View(v_System_User);
        }

        // POST: v_System_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SYSTEM_USER,CURRENT_USER")] v_System_User v_System_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_System_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_System_User);
        }

        // GET: v_System_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_System_User v_System_User = db.v_System_User.Find(id);
            if (v_System_User == null)
            {
                return HttpNotFound();
            }
            return View(v_System_User);
        }

        // POST: v_System_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            v_System_User v_System_User = db.v_System_User.Find(id);
            db.v_System_User.Remove(v_System_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
