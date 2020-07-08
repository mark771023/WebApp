using Story_Test6.Models;
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

namespace Story_Test6.Controllers
{
    public class OrderController : Controller
    {
        STORY_Test6Entities3 db = new STORY_Test6Entities3();

        //public object OrdID { get; private set; }

        //private readonly object OID;

        public ActionResult Index()
        {
            string MemID = (Session["Member"] as Member).MemID;

            var Order = db.Order.Where(o => o.MemID == MemID).OrderByDescending(o => o.OrdDate).ToList();

            return View("Index", "_LayoutMember", Order);
        }

        [HttpPost]
        // GET: Order
        public ActionResult ShoppingBuy(string Receiver, string Email, string Address)
        {
            //Order OID = null;

            string MemID = (Session["Member"] as Member).MemID;
            
            string OID = Guid.NewGuid().ToString ();

            Order Order = new Order();

            Order.OrdID = OID;
            Order.MemID = MemID;
            Order.Receiver = Receiver;
            Order.Email = Email;
            Order.Address = Address;
            Order.OrdDate = DateTime.Now;
            db.Order.Add(Order);

            var OrderMapping = db.OrderMapping.Where(m => m.IsApproved == "否" && m.MemID == MemID).ToList();

            foreach (var item in OrderMapping)
            {
                item.OrdID = OID;
                item.IsApproved = "是";
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}