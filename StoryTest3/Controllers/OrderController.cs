using StoryTest3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StoryTest3.Controllers
{
    public class OrderController : Controller
    {
        private STORY_NewEntities2 db = new STORY_NewEntities2();

        // GET: Order
        public ActionResult Index()
        {
            var Ord = db.Order.ToList();
            return View(Ord);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order Ord = db.Order.Find(id);

            if (Ord == null)
            {
                return HttpNotFound();
            }
            return View(Ord);
        }

        public ActionResult Create()
        {
            Order newOrder = new Order();
            newOrder.OrdDate = DateTime.Now;

            return View(newOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order Ord)
        {

            if (ModelState.IsValid)
            {
                var OrderList = db.Order.ToList();
                int a = OrderList.Count();
                string OrdID = "";
                if (a == 0)
                {
                    OrdID = "O" + (a + 1).ToString().PadLeft(4, '0');
                }
                else
                {
                    var chkOrderId = OrderList.OrderByDescending(o => o.OrdID).Take(1).FirstOrDefault();
                    var b = chkOrderId.OrdID.Substring(1, 4);
                    OrdID = "O" + (Convert.ToInt32(b) + 1).ToString().PadLeft(4, '0');
                }

                Ord.OrdID = OrdID;
                db.Order.Add(Ord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Ord);
        }

        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return Content("查無資料,請提供訂單編號");
        //    }
        //    //var Ord = db.Order.Where(m => m.OrdID == OrdID).FirstOrDefault();
        //    Order Ord = db.Order.Find(id);

        //    if (Ord == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(Ord);
        //}

        public ActionResult Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Order Ord = db.Order.Find(id);

            if (Ord == null)
                return HttpNotFound();

            return View(Ord);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            Order Ord = db.Order.Find(id);
            db.Order.Remove(Ord);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(string id)
        {
            Order Ord = db.Order.Find(id);

            //Order Ord = db.Order.Find(OrdID);
            return View(Ord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "OrdID,OrdAmount, OrdTotal,Transport,OrdDate")]Order Ord)
        {
            if (ModelState.IsValid)
            {
                //db.Order.AddOrUpdate(OrdID);
                db.Entry(Ord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}