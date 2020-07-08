using Story.Models;
//using StoryTest1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoryTest1.Controllers
{
    public class MemberController : Controller
    {

        STORYEntities db = new STORYEntities();

        public ActionResult Index()
        {
            var mem = db.Member.ToList();
            return View(mem);
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
                db.Member.Add(mem);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(mem);
        }

        public ActionResult Delete(string id)
        {
            var mem = db.Member.Where(m => m.MemID == id).FirstOrDefault();
            db.Member.Remove(mem);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Edit(string id)
        {
            var mem = db.Member.Where(m => m.MemID == id).FirstOrDefault();
            //if (Session["id"] == null)
            //    return RedirectToAction("Index");

            return View(mem);
        }

        [HttpPost]
        public ActionResult Edit(Member mem)
        {
            if (ModelState.IsValid)
            {
                //var mem = db.Member.Where(m => m.MemID == id).FirstOrDefault();
                //db.Member.Add(mem);

                db.Member.AddOrUpdate(mem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //public ActionResult Edit(string id)
        //{
        //    var mem = db.Member.Where(m => m.MemID == id).FirstOrDefault();
        //    //db.Member.Remove(mem);
        //    db.Member.Add(mem);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}
    }
}