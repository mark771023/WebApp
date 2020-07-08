using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _01Test.Models;

namespace _01Test.Controllers
{
    public class tProductsController : Controller
    {
        private dbProductEntities db = new dbProductEntities();

        // GET: tProducts
        public ActionResult Index()
        {
            return View(db.tProduct.ToList());
        }

        // GET: tProducts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tProduct tProduct = db.tProduct.Find(id);
            if (tProduct == null)
            {
                return HttpNotFound();
            }
            return View(tProduct);
        }

        // GET: tProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tProducts/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fId,fName,fPrice,fImg")] tProduct tProduct)
        {
            if (ModelState.IsValid)
            {
                db.tProduct.Add(tProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tProduct);
        }

        // GET: tProducts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tProduct tProduct = db.tProduct.Find(id);
            if (tProduct == null)
            {
                return HttpNotFound();
            }
            return View(tProduct);
        }

        // POST: tProducts/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fId,fName,fPrice,fImg")] tProduct tProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tProduct);
        }

        // GET: tProducts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tProduct tProduct = db.tProduct.Find(id);
            if (tProduct == null)
            {
                return HttpNotFound();
            }
            return View(tProduct);
        }

        // POST: tProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tProduct tProduct = db.tProduct.Find(id);
            db.tProduct.Remove(tProduct);
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
