using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class SimpleBindController : Controller
    {
        // GET: SimpleBind
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string PId, string PName, int Price)
        {
            ViewBag.PId = PId;
            ViewBag.PName = PName;
            ViewBag.Price = Price;

            return View();
        }
    }
}