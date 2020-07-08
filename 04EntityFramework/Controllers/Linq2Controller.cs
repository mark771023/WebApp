using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04EntityFramework.Models;

namespace _04EntityFramework.Controllers
{
    public class Linq2Controller : Controller
    {
        //04-2-7 於LinqController建立DB物件
        北風Entities db = new 北風Entities();

        // GET: Linq
        //04-2-8 建立一般方法ShowEmployee()-查詢所有員工記錄
        public string ShowEmployee()
        {
            //Linq
            //var result = from m in db.員工
            //             select m;

            //Linq擴充寫法
            var result = db.員工;

            //select * from 員工

            string show = "";

            foreach (var m in result)
            {
                show += "員工編號:" + m.員工編號 + "<br>";
                show += "姓名:" + m.姓名 + "<br>";
                show += "職稱:" + m.職稱 + "<hr>";
            }

            return show;
        }

        //04-2-10 建立一般方法ShowCustomer()-找出客戶地址中含有keyword關鍵字的客戶記錄
        public string ShowCustomerByAddress(string keyword)
        {
            //Linq
            //var result = from m in db.客戶
            //             where m.地址.Contains(keyword)
            //             select m;

            //擴充寫法
            var result = db.客戶.Where(m => m.地址.Contains(keyword));
            //where 地址 like '%@keyword%'
            //var result = db.客戶.Where(m => m.地址.Contains(keyword));
            //where 地址 like '@keyword%'
            //var result = db.客戶.Where(m => m.地址.Contains(keyword));
            //where 地址 like '%@keyword'

            //var result = db.員工;

            //select * from 員工
            //where 地址 like '%@keyword%'

            string show = "";

            foreach (var m in result)
            {
                show += "公司:" + m.公司名稱 + "<br>";
                show += "姓名:" + m.連絡人 + m.連絡人職稱 + "<br>";
                show += "地址:" + m.地址 + "<hr>";
            }

            return show;
        }

        public string ShowProduct()
        {
            //Linq查詢運算式寫法
            //var result = from m in db.產品資料
            //             where m.單價>30
            //             orderby m.單價 ascending, m.庫存量 descending
            //             select m;

            //Linq擴充方法寫法
            var result = db.產品資料.Where(m => m.單價 > 30).OrderBy(m => m.單價).ThenByDescending(m => m.庫存量);

            //Select *
            //from 產品資料
            //where 單價 > 30
            //order by 單價, 庫存量 desc

            string show = "";

            foreach (var m in result)
            {
                show += "產品:" + m.產品 + "<br>";
                show += "單價:" + m.單價 + "<br>";
                show += "庫存量:" + m.庫存量 + "<hr>";
            }

            return show;
        }

        public string ShowProductInfo()
        {
            //Linq查詢運算式寫法
            //var result = from m in db.產品資料
            //              select m;

            //Linq擴充方法寫法
            var result = db.產品資料;

            string show = "";
            show += "平均單價:" + result.Average(m => m.單價) + "<br>";
            show += "單價總和:" + result.Sum(m => m.單價) + "<br>";
            show += "產品筆數:" + result.Count() + "<br>";
            show += "最低單價:" + result.Min(m => m.單價) + "<br>";
            show += "最高單價:" + result.Max(m => m.單價) + "<br>";

            return show;
        }
    }
}