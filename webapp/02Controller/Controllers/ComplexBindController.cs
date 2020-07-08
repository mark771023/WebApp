//02-3-5 using _02Controller.Models
using _02Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class ComplexBindController : Controller
    {
        //02-3-6 建立GET與POST的Create方法
        // GET: ComplexBind
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)  //參數為Product class
        {

            ViewBag.PId = p.PId;
            ViewBag.PName = p.PName;
            ViewBag.Price = p.Price;

            return View();
        }

       
    }
}