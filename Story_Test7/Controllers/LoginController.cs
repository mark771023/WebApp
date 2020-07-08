using Story_Test7.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Story_Test6.Controllers
{
    public class LoginController : Controller
    {
        STORY_Test6Entities2 db = new STORY_Test6Entities2();


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Account, string Password)
        {

            var member = db.Member.Where(m => m.Account == Account && m.Password == Password).FirstOrDefault();
            Session["member"] = "";

            //if (member == null)
            //{
            //    ViewBag.Message = "帳密錯誤，登入失敗";
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            if (member != null)
            {
                Session["Welcome"] = member.Name + "  歡迎登入";
                Session["MemID"] = member.MemID;
                Session["member"] = member;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session["member"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}