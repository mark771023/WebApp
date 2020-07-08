using Story_Test8.Models;
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

namespace Story_Test8.Controllers
{
    public class OrderMappingController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();

        // GET: OrderMapping
        public ActionResult Index(string OrdID)
        {
            var OrderOrderMapping = db.OrderMapping.Where(o => o.OrdID == OrdID).ToList();

            return View("Index", "_LayoutMember", OrderOrderMapping);
        }

        //GET : Index/ShoppingCar
        public ActionResult ShoppingCar()
        {
            string MemID = (Session["Member"] as Member).MemID;

            var OrderMapping = db.OrderMapping.Where(m => m.MemID == MemID && m.IsApproved == "否").ToList();

            return View("ShoppingCar", "_LayoutMember", OrderMapping);
        }

        public ActionResult AddCar(string CommID)
        {
            string MemID = (Session["Member"] as Member).MemID;

            var OrderMapping = db.OrderMapping.Where(o => o.CommID == CommID && o.IsApproved == "否" && o.MemID == MemID).FirstOrDefault();

            if (OrderMapping == null)
            {
                var Commodity = db.Commodity.Where(m => m.CommID == CommID).FirstOrDefault();

                OrderMapping OrderM = new OrderMapping();
                OrderM.MemID = MemID;
                OrderM.CommID = Commodity.CommID;
                OrderM.CommName = Commodity.CommName;
                OrderM.Price = Commodity.Price;
                OrderM.Total = 1;
                OrderM.IsApproved = "否";
                db.OrderMapping.Add(OrderMapping);

            }
            else
            {
                OrderMapping.Total += 1;
            }
            db.SaveChanges();
            return RedirectToAction("ShoppingCar");
        }

        public ActionResult DeleteCar(string OrdID)
        {
            var OrderMapping = db.OrderMapping.Where(o => o.OrdID == OrdID).FirstOrDefault();
            db.OrderMapping.Remove(OrderMapping);
            db.SaveChanges();

            return RedirectToAction("ShoppingCar");
        }


    }
}