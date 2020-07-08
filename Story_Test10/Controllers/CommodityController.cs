using Story_Test10.Models;
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

namespace Story_Test9.Controllers
{
    public class CommodityController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();

        // GET: Commodity
        public ActionResult Index()
        {
            var comm = db.Commodity.ToList();
            if (Session["Administrator"] != null)
            {
                return View("Index", "_LayoutAdministrator", comm);
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember", comm);
            }
            else
            {
                return View("Index", "_Layout", comm);
            }
            //return View(comm);
        }

      
        public ActionResult Details(string CommID)
        {
            if (CommID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comm = db.Commodity.Where(c => c.CommID == CommID).FirstOrDefault();

            if (comm == null)
            {
                return HttpNotFound();
            }

            if (Session["Administrator"] != null)
            {
                return View("Details", "_LayoutAdministrator", comm);
            }
            else if (Session["Member"] != null)
            {
                return View("Details", "_LayoutMember", comm);
            }
            else
            {
                return View("Details", "_Layout", comm);
            }
            //return View(comm);
        }

        public ActionResult Create()
        {
            Commodity newPhoto = new Commodity();
            newPhoto.InitDate = DateTime.Now;
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

            //return View(newPhoto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Commodity comm, HttpPostedFileBase MyPicFile)
        {
            //if (MyPicFile != null)
            //{
            //    if (MyPicFile.ContentType.IndexOf("image", System.StringComparison.Ordinal) == -1)
            //    {
            //        ViewBag.Message = "檔案型態有誤!";
            //        return View(services);
            //    }
            //    services.ImageUrl = Utility.SaveUpImage(MyPicFile, ServicePoint.Subject.ToString());
            //    Utility.GenerateThumbnailImage(NewsStyleUriParser.Photo, MyPicFile.InputStream, Server.MapPath("~/upfiles/banner"), "S", 275, 183);
            //}

            ModelState.Remove("CommID");

            //string fileName = "";
            string extensionName = "";
            string filePath = Server.MapPath("/upfiles/Commodity");

            if (Directory.Exists(filePath))
            {

            }
            else
            {
                Directory.CreateDirectory(filePath);
            }
            string newFileName = string.Format("{0:yyyyMMddhhmmsss}_{1}{2}", DateTime.Now, "Commodity", extensionName);
            MyPicFile.SaveAs(Path.Combine(filePath, newFileName + ".jpg"));
            comm.Photo = newFileName + ".jpg";


            if (ModelState.IsValid)
            {
                var CommodityList = db.Commodity.ToList();
                int a = CommodityList.Count();
                string CommID = "";
                if (a == 0)
                {
                    CommID = "C" + (a + 1).ToString().PadLeft(5, '0');
                }
                else
                {
                    var chkCommodityId = CommodityList.OrderByDescending(o => o.InitDate).FirstOrDefault();
                    var b = chkCommodityId.CommID.Substring(1, 5);
                    CommID = "C" + (Convert.ToInt32(b) + 1).ToString().PadLeft(5, '0');
                }
                comm.CommID = CommID;
                db.Commodity.Add(comm);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(comm);
        }


        public ActionResult Delete(string CommID)
        {
            var comm = db.Commodity.Where(c => c.CommID == CommID).FirstOrDefault();
            db.Commodity.Remove(comm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string CommID)
        {
            var comm = db.Commodity.Where(c => c.CommID == CommID).FirstOrDefault();

            if (Session["Administrator"] != null)
            {
                return View("Edit", "_LayoutAdministrator", comm);
            }
            else if (Session["Member"] != null)
            {
                return View("Edit", "_LayoutMember", comm);
            }
            else
            {
                return View("Edit", "_Layout", comm);
            }
            //return View(comm);
        }

        [HttpPost]
        public ActionResult Edit(Commodity comm)
        {
            if (ModelState.IsValid)
            {
                db.Commodity.AddOrUpdate(comm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult _PostGalleryComm(int number = 0)
        {

            List<Commodity> comm;
            if (number == 0)
            {
                comm = db.Commodity.OrderByDescending(c => c.InitDate).ThenByDescending(c => c.CommID).ToList();
                //select * from Photos order by CreatedDate desc, PhotoID desc
            }
            else
            {
                comm = db.Commodity.OrderByDescending(c => c.InitDate).ThenByDescending(c => c.CommID).Take(number).ToList();
                //select top 2 * from Photos order by CreatedDate desc, PhotoID desc
            }
            return PartialView("_PostGalleryComm", comm);
        }






    }
}