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
        // GET: SimpleBind
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult Create(Product p)  //參數為Product Clas, p物件的類別為product, 與simple的差異
        {         

            ViewBag.PId = p.PId;  
            ViewBag.PName = p.PName;
            ViewBag.Price = p.Price;

            return View();
        }
    

    
}
}