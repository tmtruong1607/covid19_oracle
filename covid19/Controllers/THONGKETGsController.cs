using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using covid19.Models;

namespace covid19.Controllers
{
    public class THONGKETGsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: THONGKETGs
        public ActionResult Index()
        {
            var tHONGKETG = db.THONGKETGs.ToList();
            return View();
        }

        // GET: THONGKETGs/Details/5
        public ActionResult Details(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGKETG tHONGKETG = db.THONGKETGs.Find(id);
            if (tHONGKETG == null)
            {
                return HttpNotFound();
            }
            return View(tHONGKETG);
        }

        // GET: THONGKETGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THONGKETGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TONGSOCAMAC,TONGSOCACHET,TONGSOCAKHOI,ID")] THONGKETG tHONGKETG)
        {
            if (ModelState.IsValid)
            {
                db.THONGKETGs.Add(tHONGKETG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHONGKETG);
        }

        // GET: THONGKETGs/Edit/5
        public ActionResult Edit(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGKETG tHONGKETG = db.THONGKETGs.Find(id);
            if (tHONGKETG == null)
            {
                return HttpNotFound();
            }
            return View(tHONGKETG);
        }

        // POST: THONGKETGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TONGSOCAMAC,TONGSOCACHET,TONGSOCAKHOI,ID")] THONGKETG tHONGKETG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHONGKETG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHONGKETG);
        }

        // GET: THONGKETGs/Delete/5
        public ActionResult Delete(bool? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGKETG tHONGKETG = db.THONGKETGs.Find(id);
            if (tHONGKETG == null)
            {
                return HttpNotFound();
            }
            return View(tHONGKETG);
        }

        // POST: THONGKETGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(bool id)
        {
            THONGKETG tHONGKETG = db.THONGKETGs.Find(id);
            db.THONGKETGs.Remove(tHONGKETG);
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
