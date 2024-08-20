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
    public class YemeklerController : Controller
    {
        private yemeksepetiEntities2 db = new yemeksepetiEntities2();

        // GET: Yemekler
        public ActionResult Index()
        {
            return View(db.yemek.ToList());
        }

        // GET: Yemekler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yemek yemek = db.yemek.Find(id);
            if (yemek == null)
            {
                return HttpNotFound();
            }
            return View(yemek);
        }

        // GET: Yemekler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yemekler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yemek_id,yemek_adı,fiyat,restoran_adı")] yemek yemek)
        {
            if (ModelState.IsValid)
            {
                db.yemek.Add(yemek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yemek);
        }

        // GET: Yemekler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yemek yemek = db.yemek.Find(id);
            if (yemek == null)
            {
                return HttpNotFound();
            }
            return View(yemek);
        }

        // POST: Yemekler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "yemek_id,yemek_adı,fiyat,restoran_adı")] yemek yemek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yemek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yemek);
        }

        // GET: Yemekler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yemek yemek = db.yemek.Find(id);
            if (yemek == null)
            {
                return HttpNotFound();
            }
            return View(yemek);
        }

        // POST: Yemekler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yemek yemek = db.yemek.Find(id);
            db.yemek.Remove(yemek);
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
        public ActionResult gridsearch(string sort = "restoran_adı", string sortdir = "asc", string search = "")
        {
            int totalRecord = 0;
            var data = Getsıralama(search, sort, sortdir, out totalRecord);
            ViewBag.Totalrows = totalRecord;
            ViewBag.search = search;

            return View(data);
        }
        public List<yemek> Getsıralama(string search, string sort, string sortdir, out
int totalRecord)
        {
    
            using (yemeksepetiEntities2 db = new yemeksepetiEntities2())
            {
                var v = (from a in db.yemek
                         where

                         a.restoran_adı.Contains(search)||
                         a.yemek_adı.Contains(search)
                         

                         select a
                );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
        }
    }
}
