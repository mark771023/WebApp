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

        [HttpPost]   /*送資料方式有兩種:get 與 post  如果不標就是get*/
        public ActionResult Create(string PId, string PName, int Price) //C#需要給資料型別
        {
            ViewBag.PId = PId;  //參數取出來丟到viewbag, 並給袋子取名稱
            ViewBag.PName = PName;  
            ViewBag.Price = Price;  

            return View();
        }
    }
}