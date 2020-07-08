using STORY_Test6.Models;
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
        STORY_Test6Entities db = new STORY_Test6Entities();

        //顯示購物車
        //Get: index/ShoppingCar
        public ActionResult ShoppingCar()
        {
            //string MemID = (Session["Member"] as Member).MemID;
            string MemID = Session["MemID"].ToString();

            var OrderMapping = db.OrderMapping.Where(m => m.MemID == MemID && m.IsApproved == "否").ToList();

            return View("ShoppingCar", "_LayoutMember", OrderMapping);
        }

        //加入購物車
        //Get: index/AddCar
        public ActionResult AddCar(string CommID)
        {
            //string MemID = (Session["Member"] as Member).MemID;
            string MemID = Session["MemID"].ToString();

            var currentcar = db.OrderMapping.Where(m => m.CommID == CommID && m.IsApproved == "否" && m.MemID == MemID).FirstOrDefault();

            Commodity Comm = db.Commodity.FirstOrDefault(m => m.CommID == CommID);

            if (currentcar == null && Comm != null)
            {
                var Commodity = db.Commodity.Where(m => m.CommID == CommID).FirstOrDefault();

                OrderMapping OrderM = new OrderMapping();
                OrderM.MemID = MemID;
                OrderM.CommID = Commodity.CommID;
                OrderM.CommName = Commodity.CommName;
                OrderM.Price = Commodity.Price;
                OrderM.Total = Commodity.Total;
                OrderM.IsApproved = "否";
                db.OrderMapping.Add(OrderM);
                //new OrderMappin().AddItem(Comm, 1);
            }
            else
            {
                currentcar.Total++;
                //currentcar.Total --;
            }

            db.SaveChanges();
            return RedirectToAction("ShoppingCar");
        }

        //刪除購物車
        //Get: index/DeleteCar
        public ActionResult DeleteCar(int OrdID)
        {
            var OrderM = db.OrderMapping.Where(m => m.OrdID == OrdID).FirstOrDefault();
            db.OrderMapping.Remove(OrderM);
            db.SaveChanges();

            return RedirectToAction("ShoppingCar");
        }

        //填寫購物車資料
        // Post: index/ShoppingCar
        [HttpPost]
        public ActionResult ShoppingCar(string Receiver, string Email, string Address)
        {
            string MemID = Session["MemID"].ToString();

            string guid = Guid.NewGuid().ToString();

            //OrderMapping OrderM = new OrderMapping();
            //OrderMapping OrdM = db.OrderMapping.Find();

            Order Order = new Order();

            Order.OrdGuid = guid;
            Order.MemID = MemID;
            Order.Receiver = Receiver;
            Order.Email = Email;
            Order.Address = Address;
            //Order.OrdAmount = OrdM.Price;
            //Order.OrdTotal = OrdM.Total;
            Order.OrdDate = DateTime.Now;
            db.Order.Add(Order);

            var OrderMapping = db.OrderMapping.Where(m => m.IsApproved == "否" && m.MemID == MemID).ToList();


            foreach (var item in OrderMapping)
            {

                item.OrdGuid = guid;
                //item.OrdAmount = Order.Total;
                //item.OrdTotal = Order.Price;
                item.IsApproved = "是";
            }

            db.SaveChanges();

            return RedirectToAction("OrderList");
        }

        //訂單列表, 目前無法顯示數量與金額
        //Get:Order/OrderList
        public ActionResult OrderList()
        {
            //string MemID = (Session["Member"] as Member).MemID;
            string MemID = Session["MemID"].ToString();

            var Order = db.Order.Where(m => m.MemID == MemID).OrderByDescending(m => m.OrdDate).ToList();

            return View("OrderList", "_LayoutMember", Order);
        }

        //訂單明細
        // GET: index/OrderDetail
        public ActionResult OrderDetail(int OrdID)
        {
            var Order = db.Order.Where(m => m.OrdID == OrdID).ToList();

            return View("OrderDetail", "_LayoutMember", Order);
        }

        //刪除訂單
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteOrder(int OrdID)
        {

            Order Ord = db.Order.Find(OrdID);
            db.Order.Remove(Ord);
            db.SaveChanges();
            return RedirectToAction("OrderList");

        }

        //訂單成立時, 產品列表的產品數量也跟著減少, 目前沒有改變
        [HttpPost]
        public ActionResult ProductTotal(int Total, int OrdTotal)
        {
            //var producttotal = db.Commodity.Where(m => m.Total == Total).FirstOrDefault();
            var producttotal = db.Commodity.Find(Total);
            var order = db.Order.Where(m => m.OrdTotal == Total).FirstOrDefault();
            //var order = db.Order.Find(OrdTotal);

            if (order != null)
            {
                producttotal.Total--;
            }
            //else
            //{
            //    producttotal.Total ++;
            //}

            db.SaveChanges();

            return View("Index", "_LayoutMember", producttotal);
        }

        //商品完售後自動下架, 不顯示於產品列表
        //[HttpPost]
        //public ActionResult SoldOut(int Total)
        //{
        //    var product = db.Commodity.Find(Total);
        //    var order = db.Order.Find(OrdTotal);



        //    return View("Index", "_LayoutMember", product);
        //}

        //買賣家都看得到訂單
        //public ActionResult OrderView()
        //{


        //    Commodity.MemID
        //    Order.MemID

        //    return
        //}


        //購物車列表無商品無法成立訂單
        //public ActionResult OrderPass ()
        //{

        //    return
        //}


        //購物車的價格與數量總計
        //public ActionResult Count()
        //{

        //    return
        //}




    }
}