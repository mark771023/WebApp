using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPnet.Models;
using System.Net.Mail;
using System.Net;

namespace ASPnet.Controllers
{
    public class _09EmailAuthController : Controller
    {
        private MyDataEntities db = new MyDataEntities();

        // GET: _09EmailAuth
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Members member)
        {
            member.Auth = false;
            db.Members.Add(member);
            db.SaveChanges();

            SendAuthEmail(member.MId);
            ViewBag.Message = "加入會員完成,請收取驗證信以完成所有加入會員程序";

            return View();
        }

        private void SendAuthEmail(string MId)
        {
            //SmtpClient client = new SmtpClient("msa.hinet.net");

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("YourAccount", "YourPassword");
            client.EnableSsl = true;

            string from = "jhliao0408@gmail.com";
            string to = "jhliao0408@gmail.com";
            string subject = "XX商城加入會員驗證信";

            string body = "請點擊以下超連結以完成驗證\n\nhttp://localhost:55617/_09EmailAuth/AuthEmail?MId=" + MId;


            client.Send(from, to, subject, body);

        }

        public ActionResult AuthEmail(string MId)
        {
            var member = db.Members.Find(MId);
            if (member == null)
            {
                ViewBag.Message = "您可能是從不當的方式進入,請按驗證程序完成流程";
                return View();
            }

            member.Auth = true;
            db.SaveChanges();
            ViewBag.Message = "驗證完成!!";
            return View();

        }

    }
}