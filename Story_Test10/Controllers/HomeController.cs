using Story_Test10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Story_Test9.Controllers
{
    public class HomeController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();
        public ActionResult Index()
        {
            if (Session["Administrator"] != null)
            {
                return View("Index", "_LayoutAdministrator");
            }
            else if (Session["Member"] != null)
            {
                return View("Index", "_LayoutMember");
            }
            else
            {
                return View("Index", "_Layout");
            }
        }

        public ActionResult About()
        {

            ViewBag.Message = "哈囉你好嗎!!";
            if (Session["Administrator"] != null)
            {
                return View("About", "_LayoutAdministrator");
            }
            else if (Session["Member"] != null)
            {
                return View("About", "_LayoutMember");
            }
            else
            {
                return View("About", "_Layout");
            }

            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if (Session["Administrator"] != null)
            {
                return View("Contact", "_LayoutAdministrator");
            }
            else if (Session["Member"] != null)
            {
                return View("Contact", "_LayoutMember");
            }
            else
            {
                return View("Contact", "_Layout");
            }

            //return View();
        }

    }
}