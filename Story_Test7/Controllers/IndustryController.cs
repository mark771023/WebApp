using Story_Test7.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Story_Test6.Controllers
{
    public class IndustryController : Controller
    {
        STORY_Test6Entities2 db = new STORY_Test6Entities2();

        // GET: Industry
        public ActionResult Index()
        {
            var Indu = db.Industry.ToList();
            if (Session["Administrator"] != null)
            {
                return View("Index", "_LayoutAdministrator", Indu);
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember", Indu);
            }
            else
            {
                return View("Index", "_Layout", Indu);
            }
        }

        public ActionResult Details(string IndustryID)
        {
            if (IndustryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Indu = db.Industry.Where(c => c.IndustryID == IndustryID).FirstOrDefault();

            if (Indu == null)
            {
                return HttpNotFound();
            }

            if (Session["Administrator"] != null)
            {
                return View("Details", "_LayoutAdministrator", Indu);
            }
            else if (Session["Member"] != null)
            {
                return View("Details", "_LayoutMember", Indu);
            }
            else
            {
                return View("Details", "_Layout", Indu);
            }
            //return View(comm);
        }
        public ActionResult Create()
        {

            if (Session["Administrator"] != null)
            {
                return View("Create", "_LayoutAdministrator");
            }
            else if (Session["Member"] != null)
            {
                return View("Create", "_LayoutMember");
            }
            else
            {
                return View("Index", "_Layout");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Industry Indu)
        {
            if (ModelState.IsValid)
            {
                var IndustryList = db.Industry.ToList();
                int a = IndustryList.Count();
                string IndustryID = "";
                if (a == 0)
                {
                    IndustryID = "I" + (a + 1).ToString().PadLeft(4, '0');
                }
                else
                {
                    var chkIndustryID = IndustryList.OrderByDescending(o => o.IndustryID).Take(1).FirstOrDefault();
                    var b = chkIndustryID.IndustryID.Substring(1, 4);
                    IndustryID = "I" + (Convert.ToInt32(b) + 1).ToString().PadLeft(4, '0');
                }

                Indu.IndustryID = IndustryID;
                db.Industry.Add(Indu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Indu);
        }



    }
}