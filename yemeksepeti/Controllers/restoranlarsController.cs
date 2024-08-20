using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yemeksepeti.Models;

namespace yemeksepeti.Controllers
{
    public class RestorantlarUyeController : Controller
    {
        private yemeksepetiEntities2 db = new yemeksepetiEntities2();

        // GET: RestorantlarUye
        public ActionResult Index()
        {
            return View(db.restoranlar.ToList());
        }

        // GET: RestorantlarUye/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restoranlar restoranlar = db.restoranlar.Find(id);
            if (restoranlar == null)
            {
                return HttpNotFound();
            }
            return View(restoranlar);
        }

        // GET: RestorantlarUye/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestorantlarUye/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,restoranadı,minimumsiparis,restoranpuan,acıklama")] restoranlar restoranlar)
        {
            if (ModelState.IsValid)
            {
                db.restoranlar.Add(restoranlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restoranlar);
        }

        // GET: RestorantlarUye/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restoranlar restoranlar = db.restoranlar.Find(id);
            if (restoranlar == null)
            {
                return HttpNotFound();
            }
            return View(restoranlar);
        }

        // POST: RestorantlarUye/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,restoranadı,minimumsiparis,restoranpuan,acıklama")] restoranlar restoranlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restoranlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restoranlar);
        }

        // GET: RestorantlarUye/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restoranlar restoranlar = db.restoranlar.Find(id);
            if (restoranlar == null)
            {
                return HttpNotFound();
            }
            return View(restoranlar);
        }

        // POST: RestorantlarUye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            restoranlar restoranlar = db.restoranlar.Find(id);
            db.restoranlar.Remove(restoranlar);
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
