using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADOnet.Controllers
{
    public class HomeController : Controller
    {
        //05-2-6 設定Connection與SqlCommand物件
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString2"].ConnectionString);
        SqlCommand Cmd = new SqlCommand(); //建立空的SMD物件
        SqlDataAdapter adp = new SqlDataAdapter();

        //05-2-9 建立一般方法executeSql()-可傳入SQL字串來輯編資料表
        private void executeSql(string sql)
        {
            Cmd.CommandText = sql;
            Cmd.Connection = Conn;        

            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        //05-2-7 建立一般方法querySql()-可傳入SQL字串並傳回DataTable物件
        private DataTable querySql(string sql)
        {
            Cmd.CommandText = sql;
            Cmd.Connection = Conn;
            adp.SelectCommand = Cmd;

            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds.Tables[0];
        }

        //05-2-8 建立Index() Action回傳DataTable資料給View
        // GET: Home
        public ActionResult Index()
        {
            string sql = "select * from tStudent";            
            DataTable dt = querySql(sql);

            return View(dt);
        }

        //05-2-10 建立GET與POST Create Action
        public ActionResult Create()
        {
            if (Session["id"] == null)
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fStuId, string fName, string fEmail, int fScore)
        {
            string sql = "insert into tStudent values(@fStuId,@fName,@fEmail,@fScore)";

            Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            Cmd.Parameters.AddWithValue("@fName", fName);
            Cmd.Parameters.AddWithValue("@fEmail", fEmail);
            Cmd.Parameters.AddWithValue("@fScore", fScore);

            executeSql(sql);

            return RedirectToAction("Index");
        }

        //05-2-11 建立POST Delete Action
        public ActionResult Delete(string fStuId)
        {
            if (Session["id"] == null)
                return RedirectToAction("Index");

            string sql = "delete from tStudent where fStuId=@fStuId";            
            Cmd.Parameters.AddWithValue("@fStuId", fStuId);          
            executeSql(sql);

            return RedirectToAction("Index");
        }

        //05-2-19 建立POST Edit Action
        public ActionResult Edit(string fStuId)
        {
            if (Session["id"] == null)
                return RedirectToAction("Index");

            string sql = "select * from tStudent where fStuId=@fStuId";
            Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            DataTable dt = querySql(sql);

            return View(dt);
        }

        [HttpPost]      
        public ActionResult Edit(string fStuId, string fName, string fEmail, int fScore)
        {
            string sql = "update tStudent set fName=@fName,fEmail=@fEmail,fScore=@fScore where fStuId=@fStuId";

            Cmd.Parameters.AddWithValue("@fStuId", fStuId);
            Cmd.Parameters.AddWithValue("@fName", fName);
            Cmd.Parameters.AddWithValue("@fEmail", fEmail);
            Cmd.Parameters.AddWithValue("@fScore", fScore);

            executeSql(sql);

            return RedirectToAction("Index");
        }

    }
}