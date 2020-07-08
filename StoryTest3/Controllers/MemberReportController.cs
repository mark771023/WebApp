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
    public class MemberReportController : Controller
    {
        private STORY_NewEntities2 db = new STORY_NewEntities2();

        // GET: MemberReport
        public ActionResult Index()
        {
            var MemRep = db.MemberReport.ToList();
            return View(MemRep);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MemberReport MemRep = db.MemberReport.Find(id);

            if (MemRep == null)
            {
                return HttpNotFound();
            }
            return View(MemRep);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberReport MemRep)
        {

            if (ModelState.IsValid)
            {
                var MemberReportList = db.MemberReport.ToList();
                int a = MemberReportList.Count();
                string MemRepID = "";
                if (a == 0)
                {
                    MemRepID = "R" + (a + 1).ToString().PadLeft(4, '0');
                }
                else
                {
                    var chkMemRepID = MemberReportList.OrderByDescending(r => r.MemRepID).Take(1).FirstOrDefault();
                    var b = chkMemRepID.MemRepID.Substring(1, 4);
                    MemRepID = "R" + (Convert.ToInt32(b) + 1).ToString().PadLeft(4, '0');
                }

                MemRep.MemRepID = MemRepID;
                db.MemberReport.Add(MemRep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(MemRep);
        }


    }
}