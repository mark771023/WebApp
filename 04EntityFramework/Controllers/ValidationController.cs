using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04EntityFramework.Models;

namespace _04EntityFramework.Controllers
{
    public class ValidationController : Controller
    {
        dbStudentEntities db = new dbStudentEntities();

        // GET: Validation
        public ActionResult Index()
        {
            var stu = db.tStudent.ToList();

            return View(stu);
        }

        public ActionResult Create()
        {           

            return View();
        }
        [HttpPost]
        public ActionResult Create(student stu)
        {
            if (ModelState.IsValid)
            {         
                db.tStudent.Add(stu);
                db.SaveChanges();

                return RedirectToAction("Index");  //重新導向
            }
            return View(stu);
        }

        public ActionResult Delete(string id)
        {
            //var stu = from m in db.tStudent
            //          where m.fStuId == id
            //          select m;

            var stu = db.tStudent.Where(m => m.fStuId == id).FirstOrDefault();
            db.tStudent.Remove(stu);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}