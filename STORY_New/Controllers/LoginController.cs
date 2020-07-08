using STORY_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoryTest2.Controllers
{
    public class LoginController : Controller
    {
        private STORY_NewEntities db = new STORY_NewEntities();

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

            if (member == null)
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
            }
            else
            {
                return RedirectToAction("Index", "Member");
            }
            return View();
        }


        public ActionResult Logout()
        {
            Session["member"] = null;
            return RedirectToAction("Index", "Member");
        }
    }
}