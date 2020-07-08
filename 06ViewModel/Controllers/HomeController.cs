using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _06ViewModel.Models;
using System.Data.Entity;

namespace _06ViewModel.Controllers
{
    public class HomeController : Controller
    {

        NorthwindEntities db = new NorthwindEntities();
        // GET: Home
        public ActionResult Index()
        {
            var order = db.訂貨主檔.Include(m => m.員工.姓名);
            //var order = db.訂貨主檔.Join(db.員工, 訂=>訂.收貨人,(訂,員) );

            //Linq
            //var order = (from o in db.訂貨主檔
            //             join s in db.員工
            //             on o.員工編號 equals s.員工編號
            //             select new { o.員工, o.客戶編號, o.收貨人, s.地址, o.送貨國家地區, s.城市 }
            //    );

            //var order = from o in db.訂貨主檔
            //            from s in db.員工
            //             select new { o.員工, o.客戶編號, o.收貨人, s.地址, o.送貨國家地區, s.城市 }
            //   );

            return View(order);
        }
    }
}