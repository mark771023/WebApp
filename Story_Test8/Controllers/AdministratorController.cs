using Story_Test8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Story_Test8.Controllers
{
    public class AdministratorController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();

        // GET: Administrator
        public ActionResult Index()
        {
            var Admin = db.Administrator.ToList();
            if (Session["Administrator"] != null)
            {
                return View("Index", "_LayoutAdministrator", Admin);
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember", Admin);
            }
            else
            {
                return View("Index", "_Layout", Admin);
            }
            //return View(Admin);
        }

        // GET: Administrator/Details/5
        public ActionResult Details(string AdminID)
        {
            var Admin = db.Administrator.Where(a => a.AdminID == AdminID).FirstOrDefault();

            if (Admin == null)
            {
                return HttpNotFound();
            }

            if (Session["Administrator"] != null)
            {
                return View("Details", "_LayoutAdministrator", Admin);
            }
            else if (Session["Member"] != null)
            {
                return View("Details", "_LayoutMember");
            }
            else
            {
                return View("Details", "_Layout");
            }
            //return View(mem);
        }

        // GET: Administrator/Create
        public ActionResult Create()
        {
            if (Session["Administrator"] != null)
            {
                return View("Create", "_LayoutAdministrator");
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember");
            }
            else
            {
                return View("Index", "_Layout");
            }
            //return View();
        }

        // POST: Administrator/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,AdminAccount,AdminPwd,AdminName,E_mail,Authority")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {

                db.Administrator.Add(administrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrator);
        }

        // GET: Administrator/Edit/5
        public ActionResult Edit(string AdminID)
        {
            if (AdminID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Admin = db.Administrator.Where(a => a.AdminID == AdminID).FirstOrDefault();

            if (Admin == null)
            {
                return HttpNotFound();
            }
            if (Session["Administrator"] != null)
            {
                return View("Edit", "_LayoutAdministrator", Admin);
            }
            else if ((Session["Member"] != null))
            {
                return View("Index", "_LayoutMember", Admin);
            }
            else
            {
                return View("Index", "_Layout", Admin);
            }
            //return View(administrator);
        }

        // POST: Administrator/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminID,AdminAccount,AdminPwd,AdminName,E_mail,Authority")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrator);
        }

        // GET: Administrator/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrator.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // POST: Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Administrator administrator = db.Administrator.Find(id);
            db.Administrator.Remove(administrator);
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