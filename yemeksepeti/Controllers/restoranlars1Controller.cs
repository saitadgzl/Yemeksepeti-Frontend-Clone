using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yemeksepeti.Models;
using System.Linq.Dynamic.Core;

namespace yemeksepeti.Controllers
{
    public class RestorantlarController : Controller
    {
        private yemeksepetiEntities2 db = new yemeksepetiEntities2();

        // GET: Restorantlar
        public ActionResult Index()
        {
            return View(db.restoranlar.ToList());
        }

        // GET: Restorantlar/Details/5
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

        // GET: Restorantlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restorantlar/Create
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

        // GET: Restorantlar/Edit/5
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

        // POST: Restorantlar/Edit/5
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

        // GET: Restorantlar/Delete/5
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

        // POST: Restorantlar/Delete/5
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
        public ActionResult gridsearch(string sort = "restoranadı", string sortdir = "asc", string search = "")
        {
            int totalRecord = 0;
            var data = Getsıralama(search, sort, sortdir, out totalRecord);
            ViewBag.Totalrows = totalRecord;
            ViewBag.search = search;

            return View(data);
        }
        public List<restoranlar> Getsıralama(string search, string sort, string sortdir, out
int totalRecord)
        {
            //burada AlbümEntities veritabanı içeriğini oluşturmaktadır
            using (yemeksepetiEntities2 db = new yemeksepetiEntities2())
            {
                var v = (from a in db.restoranlar
                         where

                         a.restoranadı.Contains(search) ||
                         a.acıklama.Contains(search)


                         select a
                );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
        }
    }
}
