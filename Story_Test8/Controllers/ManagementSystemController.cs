using Story_Test8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Story_Test8.Controllers
{
    public class ManagementSystemController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();
        // GET: ManagementSystem
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
            //return View();
        }
    }
}