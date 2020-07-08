using STORY_New.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace STORY_New.Controllers
{
    public class MemberController : Controller
    {
        STORY_NewEntities db = new STORY_NewEntities();
        // GET: Member
        public ActionResult Index()
        {
            var Mem = db.Member.ToList();
            return View(Mem);
        }

        //public ActionResult Details(int? id) 
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Member Mem = db.Member.Find(id);
        //    if (Mem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(Mem);
        //}
        public ActionResult Create()
        {
            //if (Session["MemID"] == null)
            //    return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member Mem)
        {

            if (ModelState.IsValid)
            {
                var MembersList = db.Member.ToList();
                int a = MembersList.Count();
                string MemID = "";
                if (a == 0)
                {
                    MemID = "M" + (a + 1).ToString().PadLeft(4, '0');
                }
                else
                {
                    var chkMemberId = MembersList.OrderByDescending(o => o.InitDate).FirstOrDefault();
                    var b = chkMemberId.MemID.Substring(1, 4);
                    MemID = "M" + (Convert.ToInt32(b) + 1).ToString().PadLeft(4, '0');
                }

                Mem.MemID = MemID;
                db.Member.Add(Mem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Mem);
        }

        public ActionResult Delete(string MemID)
        {
            var Mem = db.Member.Where(m => m.MemID == MemID).FirstOrDefault();
            db.Member.Remove(Mem);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(string MemID)
        {
            var Mem = db.Member.Where(m => m.MemID == MemID).FirstOrDefault();
            return View(Mem);
        }

        [HttpPost]
        public ActionResult Edit(Member Mem)
        {
            if (ModelState.IsValid)
            {
                db.Member.AddOrUpdate(Mem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}