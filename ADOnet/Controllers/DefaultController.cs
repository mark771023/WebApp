using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient; //預先建立於參考中

using System.Configuration;

namespace ADOnet.Controllers
{
    public class DefaultController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);  //資料庫靠它連結

        private DataTable querySql(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds.Tables[0];
        }

        //05-1-7 建立一般方法ShowEmployee()-查詢所有員工記錄
        // GET: Default
        public string ShowEmployee()
        {
            string sql="select 員工編號, 姓名, 稱呼, 職稱 from 員工";
            DataTable dt = querySql(sql);          
            string show="";

            foreach (DataRow row in dt.Rows)
            {
                show += "員工編號:" + row["員工編號"] + "<br>";
                show += "姓名:" + row["姓名"] + " <br>";
                show += "職稱:" + row["職稱"] + " <hr>";
            }
            return show;
        }
        //05-1-9 建立一般方法ShowProduct()-查詢單價大於30的產品，並依單價做遞增排序，庫存量做遞減排序 
        public string ShowProduct()
        {
            string sql = "select 產品, 單價, 庫存量 from 產品資料 where 單價>30 order by  單價, 庫存量 desc ";
            DataTable dt = querySql(sql);
            string show = "";           

            foreach (DataRow row in dt.Rows)
            {
                show += "產品" + row["產品"] + "<br>";
                show += "單價:" + row["單價"] + " <br>";
                show += "庫存量:" + row["庫存量"] + " <hr>";
            }
            return show;
        }

        //05-1-11 建立一般方法ShowCustomerByAddress()-找出客戶地址中含有keyword關鍵字的客戶記錄
        public string ShowCustomerByAddress(string keyword)
        {
            string sql = "select 公司名稱, 連絡人, 連絡人職稱,地址 from 客戶 where 地址 like @keyword";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            adp.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];

            string show = "";

            foreach (DataRow row in dt.Rows)
            {
                show += "公司名稱" + row["公司名稱"] + "<br>";
                show += "連絡人:" + row["連絡人"] + row["連絡人職稱"]+ " <br>";
                show += "地址:" + row["地址"] + " <hr>";
            }
            return show;
        }

    }
}
//05-1 ADO.net SqlDataAdapter與DataTable物件
//05-1-1 將Northwind.mdb資料庫放入App_Data資料夾
//05-1-2 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//05-1-3 指定控制器名稱為DefaultController,並開啟DefaultController
//05-1-4 using System.Data、System.Data.SqlClient、System.Configuration
//05-1-5 加入連線設定在Web.config檔裡(也可透過Visual Studio操作自動建立)
//05-1-6 設定Connection物件
//05-1-7 建立一般方法ShowEmployee()-查詢所有員工記錄
//05-1-8 執行並測試 http://localhost:53468/Default/ShowEmployee (port可能不同)
//05-1-9 建立一般方法ShowProduct()-查詢單價大於30的產品，並依單價做遞增排序，庫存量做遞減排序
//05-1-10 執行並測試 http://localhost:53468/Default/ShowProduct (port可能不同)
//05-1-11 建立一般方法ShowCustomerByAddress()-找出客戶地址中含有keyword關鍵字的客戶記錄
//05-1-12 執行並測試 http://localhost:53468/Default/ShowCustomerByAddress?keyword=中山路 (port可能不同)
//05-2-13 進行下列設定:
//        View name:Index
//        Template:Empty (Without model)
//        勾選Use a layout pages
//        按下Add
//05-2-14 撰寫Home/Index View的內容
//05-2-15 在public ActionResult Create()上按右鍵,新增檢視,建立Create View
//05-2-16 進行下列設定:
//        View name:Create
//        Template:Empty (Without model)
//        勾選Use a layout pages
//        按下Add
//05-2-17 撰寫Home/Create View的內容
//05-2-18 執行並測試