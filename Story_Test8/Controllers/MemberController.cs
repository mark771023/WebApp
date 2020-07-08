using Story_Test8;
using Story_Test8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StoryTest8.Controllers
{
    public class MemberController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();

        public ActionResult Index()
        {
            var mem = db.Member.ToList();

            if (Session["Administrator"] != null)
            {
                return View("Index", "_LayoutAdministrator", mem);
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember", mem);
            }
            else
            {
                return View("Index", "_Layout", mem);
            }
            //return View(mem);
        }
        public ActionResult Details(string MemID)
        {
            //Member mem = db.Member.Find(MemID);
            var mem = db.Member.Where(m => m.MemID == MemID).FirstOrDefault();


            if (mem == null)
            {
                return HttpNotFound();
            }

            if (Session["Administrator"] != null)
            {
                return View("Details", "_LayoutAdministrator", mem);
            }
            else if ((Session["Member"] != null))
            {
                return View("Details", "_LayoutMember", mem);
            }
            else
            {
                return View("Details", "_Layout", mem);
            }
            //return View(mem);
        }
        public ActionResult Create()
        {
            //if (Session["MemID"] == null)
            //    return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member mem)
        {

            if (ModelState.IsValid)
            {
                var MembersList = db.Member.ToList();
                int a = MembersList.Count();
                string MemID = "";
                if (a == 0)
                {
                    MemID = "M" + (a + 1).ToString().PadLeft(5, '0');
                }
                else
                {
                    var chkMemberId = MembersList.OrderByDescending(o => o.InitDate).FirstOrDefault();
                    var b = chkMemberId.MemID.Substring(1, 5);
                    MemID = "M" + (Convert.ToInt32(b) + 1).ToString().PadLeft(5, '0');
                }

                mem.MemID = MemID;
                db.Member.Add(mem);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(mem);
        }

        public ActionResult Delete(string MemID)
        {
            var mem = db.Member.Where(m => m.MemID == MemID).FirstOrDefault();
            db.Member.Remove(mem);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(string MemID)
        {
            var mem = db.Member.Where(m => m.MemID == MemID).FirstOrDefault();

            if (Session["Administrator"] != null)
            {
                return View("Edit", "_LayoutAdministrator", mem);
            }
            else if (Session["Member"] != null)
            {
                return View("Edit", "_LayoutMember", mem);
            }
            else
            {
                return View("Index", "_Layout", mem);
            }
            //return View(mem);
        }

        [HttpPost]
        public ActionResult Edit(Member mem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}