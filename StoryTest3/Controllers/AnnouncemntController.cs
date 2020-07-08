using StoryTest3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StoryTest3.Controllers
{
    public class AnnouncemntController : Controller
    {
        private STORY_NewEntities2 db = new STORY_NewEntities2();

        // GET: Announcemnt
        public ActionResult Index()
        {
            var Ann = db.Announcement.ToList();
            return View(Ann);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Announcement Ann = db.Announcement.Find(id);

            if (Ann == null)
            {
                return HttpNotFound();
            }
            return View(Ann);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Announcement Ann)
        {

            if (ModelState.IsValid)
            {
                var AnnouncementList = db.Announcement.ToList();
                int a = AnnouncementList.Count();
                string PostID = "";
                if (a == 0)
                {
                    PostID = "A" + (a + 1).ToString().PadLeft(4, '0');
                }
                else
                {
                    var chkPostID = AnnouncementList.OrderByDescending(o => o.PostID).Take(1).FirstOrDefault();
                    var b = chkPostID.PostID.Substring(1, 4);
                    PostID = "O" + (Convert.ToInt32(b) + 1).ToString().PadLeft(4, '0');
                }

                Ann.PostID = PostID;
                db.Announcement.Add(Ann);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Ann);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Announcement Ann = db.Announcement.Find(id);

            if (Ann == null)
                return HttpNotFound();

            return View(Ann);
        }

        [HttpPost]
        [ActionName("Delete")] //DeleteConfirmed
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Announcement Ann = db.Announcement.Find(id);
            db.Announcement.Remove(Ann);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Edit(string id)
        {
            Announcement Ann = db.Announcement.Find(id);
            return View(Ann);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(id).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}