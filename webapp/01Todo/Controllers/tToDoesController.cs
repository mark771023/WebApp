using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _01Todo.Models;

namespace _01Todo.Controllers
{
    public class tToDoesController : Controller
    {
        private dbToDoEntities db = new dbToDoEntities();

        // GET: tToDoes
        public ActionResult Index()
        {
            return View(db.tToDo.ToList());
        }

        // GET: tToDoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tToDo tToDo = db.tToDo.Find(id);
            if (tToDo == null)
            {
                return HttpNotFound();
            }
            return View(tToDo);
        }

        // GET: tToDoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tToDoes/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fId,fTitle,fImage,fDate")] tToDo tToDo)
        {
            if (ModelState.IsValid)
            {
                db.tToDo.Add(tToDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tToDo);
        }

        // GET: tToDoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tToDo tToDo = db.tToDo.Find(id);
            if (tToDo == null)
            {
                return HttpNotFound();
            }
            return View(tToDo);
        }

        // POST: tToDoes/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fId,fTitle,fImage,fDate")] tToDo tToDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tToDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tToDo);
        }

        // GET: tToDoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tToDo tToDo = db.tToDo.Find(id);
            if (tToDo == null)
            {
                return HttpNotFound();
            }
            return View(tToDo);
        }

        // POST: tToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tToDo tToDo = db.tToDo.Find(id);
            db.tToDo.Remove(tToDo);
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
