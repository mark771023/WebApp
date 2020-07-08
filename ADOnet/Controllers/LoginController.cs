using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;

using System.Configuration;

namespace ADOnet.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id, string pwd)
        {
            string sql = "select * from 客戶 where 客戶編號=@id and 郵遞區號=@pwd";

            SqlCommand cmd = new SqlCommand(sql,Conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pwd", pwd);

            SqlDataReader rd;

            Conn.Open();
            rd = cmd.ExecuteReader();

            if(rd.Read())
            {
                //ViewBag.Msg = "登入成功";
                Session["id"] = rd["客戶編號"].ToString();
                Session["Name"] = rd["公司名稱"].ToString();

                Conn.Close();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Msg = "帳號或密碼有誤";
            }

            Conn.Close();


            return View();
        }

        public ActionResult Logout() 
        {
            Session["id"] = null;
            Session["Name"] = null;

            return RedirectToAction("Index", "Home");
        }

    }
}