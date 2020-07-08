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
    public class OrderController : Controller
    {
        STORY_Test6Entities db = new STORY_Test6Entities();

        //Get: index/ShoppingCar
        public ActionResult ShoppingCar()        
        {
            string MemID = (Session["Member"] as Member).MemID;

            var OrderMapping = db.OrderMapping.Where(m => m.MemID == MemID && m.IsApproved == "否").ToList();

            return View("ShoppingCar", "_LayoutMember", OrderMapping);
        }

        //Get: index/AddCar
        public ActionResult AddCar(string CommID)
        {
            string MemID = (Session["Member"] as Member).MemID;

            var currentcar = db.OrderMapping.Where(m => m.CommID == CommID && m.IsApproved == "否" && m.MemID == MemID).FirstOrDefault();

            if (currentcar == null)
            {
                var Commodity = db.Commodity.Where(m => m.CommID == CommID).FirstOrDefault();

                OrderMapping OrderM = new OrderMapping();           
                OrderM.MemID = MemID;
                OrderM.CommID = Commodity.CommID;
                OrderM.CommName = Commodity.CommName;
                OrderM.Price = Commodity.Price;
                OrderM.Total = 1;
                OrderM.IsApproved = "否";
                db.OrderMapping.Add(OrderM);

            }
            else
            {
                currentcar.Total += 1;
            }
            db.SaveChanges();
            return RedirectToAction("ShoppingCar");
        }

        //Get: index/DeleteCar
        public ActionResult DeleteCar(int OrdID)
        {
            var OrderMapping = db.OrderMapping.Where(m => m.OrdID == OrdID).FirstOrDefault();
            db.OrderMapping.Remove(OrderMapping);
            db.SaveChanges();

            return RedirectToAction("ShoppingCar");
        }

        // Post: index/ShoppingCar
        [HttpPost]
        public ActionResult ShoppingCar(string Receiver, string Email, string Address)
        {
            //Order OID = null;

            string MemID = (Session["Member"] as Member).MemID;

            string guid = Guid.NewGuid().ToString();

            Order Order = new Order();

            Order.OrdGuid = guid;
            Order.MemID = MemID;
            Order.Receiver = Receiver;
            Order.Email = Email;
            Order.Address = Address;
            Order.OrdDate = DateTime.Now;
            db.Order.Add(Order);

            var OrderMapping = db.OrderMapping.Where(m => m.IsApproved == "否" && m.MemID == MemID).ToList();

            foreach (var item in OrderMapping)
            {
                item.OrdGuid = guid;
                item.IsApproved = "是";
            }

            db.SaveChanges();

            return RedirectToAction("OrderList");
        }

        //Get:Order/OrderList
        public ActionResult OrderList()
        {
            string MemID = (Session["Member"] as Member).MemID;

            var Order = db.Order.Where(m => m.MemID == MemID).OrderByDescending(m => m.OrdDate).ToList();

            return View("Index", "_LayoutMember", Order);
        }

        // GET: index/OrderDetail
        public ActionResult OrderDetail(string OrdGuid)
        {
            var OrderMapping = db.OrderMapping.Where(m => m.OrdGuid == OrdGuid).ToList();

            return View("OrderDetail", "_LayoutMember", OrderMapping);
        }




    }
}