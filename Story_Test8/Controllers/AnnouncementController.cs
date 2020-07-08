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
    public class AnnouncementController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();
        // GET: Announcement
        public ActionResult Index()
        {
            var post = db.Announcement.ToList();
            if (Session["Administrator"] != null)
            {
                return View("Index", "_LayoutAdministrator", post);
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember", post);
            }
            else
            {
                return View("Index", "_Layout", post);
            }
            //return View(post);
        }
        public ActionResult Details(string PostID)
        {
            if (PostID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = db.Announcement.Where(p => p.PostID == PostID).FirstOrDefault();

            if (post == null)
            {
                return HttpNotFound();
            }

            if (Session["Administrator"] != null)
            {
                return View("Details", "_LayoutAdministrator", post);
            }
            else if (Session["Member"] != null)
            {
                return View("Details", "_LayoutMember", post);
            }
            else
            {
                return View("Details", "_Layout", post);
            }
            //return View(post);
        }
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
            //if (Session["MemID"] == null)
            //    return RedirectToAction("Index");
            //return View();
        }
        [HttpPost]
        public ActionResult Create(Announcement post)
        {

            if (ModelState.IsValid)
            {
                var AnnouncementList = db.Announcement.ToList();
                int a = AnnouncementList.Count();
                string PostID = "";
                if (a == 0)
                {
                    PostID = "P" + (a + 1).ToString().PadLeft(5, '0');
                }
                else
                {
                    var chkPostId = AnnouncementList.OrderByDescending(p => p.PostTime).FirstOrDefault();
                    var b = chkPostId.PostID.Substring(1, 5);
                    PostID = "P" + (Convert.ToInt32(b) + 1).ToString().PadLeft(5, '0');
                }

                post.PostID = PostID;
                db.Announcement.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "Announcement");
            }
            return View(post);
        }
        public ActionResult Delete(string PostID)
        {
            var post = db.Announcement.Where(p => p.PostID == PostID).FirstOrDefault();
            db.Announcement.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(string PostID)
        {
            var post = db.Announcement.Where(p => p.PostID == PostID).FirstOrDefault();

            if (Session["Administrator"] != null)
            {
                return View("Edit", "_LayoutAdministrator", post);
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember", post);
            }
            else
            {
                return View("Index", "_Layout", post);
            }

            //return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Announcement post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult _PostGallery(int number = 0)
        {

            List<Announcement> post;
            if (number == 0)
            {
                post = db.Announcement.OrderByDescending(p => p.PostTime).ThenByDescending(p => p.PostID).ToList();
                //select * from Photos order by CreatedDate desc, PhotoID desc
            }
            else
            {
                post = db.Announcement.OrderByDescending(p => p.PostTime).ThenByDescending(p => p.PostID).Take(number).ToList();
                //select top 2 * from Photos order by CreatedDate desc, PhotoID desc
            }
            return PartialView("_PostGallery", post);
        }
    }
}