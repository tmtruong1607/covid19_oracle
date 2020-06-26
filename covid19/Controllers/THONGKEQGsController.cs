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
    public class THONGKEQGsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: THONGKEQGs
        public ActionResult Index()
        {
            var tHONGKEQGs = db.THONGKEQGs.Include(t => t.QUOCGIA);
            //tHONGKEQGs.OrderByDescending(s => s.TONGSOCAMAC);
            var res = tHONGKEQGs.Where(s => s.TONGSOCAMAC != null).ToList();
            ViewBag.tg = db.THONGKETGs.ToList();
            ViewBag.tt = db.TINTUCs.ToList();
            ViewBag.qg = res.OrderByDescending(s => s.TONGSOCAMAC).ToList();
            return View();
        }

        // GET: THONGKEQGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGKEQG tHONGKEQG = db.THONGKEQGs.Find(id);
            if (tHONGKEQG == null)
            {
                return HttpNotFound();
            }
            return View(tHONGKEQG);
        }

        // GET: THONGKEQGs/Create
        public ActionResult Create()
        {
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG");
            return View();
        }

        // POST: THONGKEQGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAQG,TONGSOCAMAC,TONGSOCACHET,TONGSOCAKHOI")] THONGKEQG tHONGKEQG)
        {
            if (ModelState.IsValid)
            {
                db.THONGKEQGs.Add(tHONGKEQG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", tHONGKEQG.MAQG);
            return View(tHONGKEQG);
        }

        // GET: THONGKEQGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGKEQG tHONGKEQG = db.THONGKEQGs.Find(id);
            if (tHONGKEQG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", tHONGKEQG.MAQG);
            return View(tHONGKEQG);
        }

        // POST: THONGKEQGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAQG,TONGSOCAMAC,TONGSOCACHET,TONGSOCAKHOI")] THONGKEQG tHONGKEQG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHONGKEQG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAQG = new SelectList(db.QUOCGIAs, "MAQG", "TENQG", tHONGKEQG.MAQG);
            return View(tHONGKEQG);
        }

        // GET: THONGKEQGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGKEQG tHONGKEQG = db.THONGKEQGs.Find(id);
            if (tHONGKEQG == null)
            {
                return HttpNotFound();
            }
            return View(tHONGKEQG);
        }

        // POST: THONGKEQGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THONGKEQG tHONGKEQG = db.THONGKEQGs.Find(id);
            db.THONGKEQGs.Remove(tHONGKEQG);
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
