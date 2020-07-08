using Story_Test11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Story_Test11.Controllers
{
    public class AdministratorLoginController : Controller
    {
        STORY_Test11Entities db = new STORY_Test11Entities();

        // GET: AdministratorLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string AdminAccount, string AdminPwd)
        {

            var administrator = db.Administrator.Where(a => a.AdminAccount == AdminAccount && a.AdminPwd == AdminPwd).FirstOrDefault();
            Session["administrator"] = "";
            if (administrator != null)
            {
                Session["WelCome"] = "歡迎偉大的管理員  " + administrator.AdminName + "  登入";
                Session["administrator"] = administrator;
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
            Session["administrator"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}