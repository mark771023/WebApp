using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //04-1-3 建立一般方法ShowAryDesc()-整數陣列遞減排序
        public string ShowArrayDesc()
        {
            int[] score = { 78, 99, 20, 100, 66, 64 };
            string show = "";

            //Linq查詢運算式語法
            //var result=from m in score
            //            orderby m descending
            //            select m;

            //Linq擴充方法
            var result = score.OrderByDescending(m => m);


            //SQL Select DML
            //select score from tb1
            //order by score desc

            //select sum(score) from tb1


            show = "遞減排序:";
            foreach (var m in result)
            {
                show += m + ", ";

            }
            show += "<br>";
            show += "總合:" + result.Sum(); //使用Linq的Sum方法進行加總

            return show;

        }

        //04-1-5 建立一般方法ShowAryAsc()-整數陣列遞增排序
        public string ShowArrayAsc()
        {
            int[] score = { 78, 99, 20, 100, 66, 64 };
            string show = "";

            //Linq查詢運算式語法
            var result = from m in score
                         orderby m ascending
                         select m;

            //Linq擴充方法
            //var result = score.OrderBy(m => m);


            //SQL Select DML
            //select score from tb1
            //order by score

            //select sum(score) from tb1


            show = "遞增排序:";
            foreach (var m in result)
            {
                show += m + ", ";

            }
            show += "<br>";
            show += "平均:" + result.Average();

            return show;

        }

        //04-1-9 在HomeController中建立一般方法LoginMember()
        public string LoginMember(string UId, string Pwd)
        {
            //Member member = new Member();
            //member.UId = "tom";
            //member.Pwd = "123";
            //member.Name = "湯姆";

            //Member member2 = new Member();
            //member2.UId = "jpsper";
            //member2.Pwd = "456";
            //member2.Name = "賈思伯";

            Member[] members = new Member[]
            {
                 new Member{ UID = "tom",Pwd = "123",Name = "湯姆"},
                 new Member{ UID = "jpsper",Pwd = "456",Name = "賈思伯"},
                 new Member{ UID = "mary",Pwd = "789",Name = "瑪麗"}
            };

            string show = "";

            //SQL DML
            //select * from members
            //where UId=@UId and Pwd=@Pwd

            //Linq查詢運算式寫法
            //var result = (from m in members
            //             where m.UId == UId && m.Pwd == Pwd
            //             select m).FirstOrDefault();

            //Linq擴充方法寫法
            var result = members.Where(m => m.UID == UId && m.Pwd == Pwd).FirstOrDefault();

            if (result != null)
            {
                show = result.Name + "歡迎進入系統";
            }
            else
            {
                show = "帳號或密碼錯誤!!";
            }

            return show;

        }

    }
}

//04-1 Linq練習
//04-1-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//04-1-2 指定控制器名稱為HomeController,並開啟HomeController
//04-1-3 建立一般方法ShowAryDesc()-整數陣列遞減排序
//04-1-4 執行並測試 http://localhost:53468/Home/ShowArrayDesc (port可能不同)
//04-1-5 建立一般方法ShowAryAsc()-整數陣列遞增排序
//04-1-6 執行並測試 http://localhost:53468/Home/ShowArrayAsc (port可能不同)
//04-1-7 在Controllers資料夾上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入Member.cs
//04-1-8 在Member class中輸入下列欄位
//04-1-9 在HomeController中建立一般方法LoginMember()
//04-1-10 執行並測試 http://localhost:53468/Home/LoginMember?uid=tom&pwd=123 (port可能不同)



//04-2 Entity FrameWork
//04-2-1 建立NorthWind.mdb資料庫Model
//       在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//       來自資料庫的EF Designer
//       連接NorthWind.mdf資料庫,連線名稱不修改,按下一步按鈕
//       選擇Entity Framework 6.x, 按下一步按鈕
//       資料表"全選", 按完成鈕
//       若跳出詢問方法按確定鈕
//04-2-3 在專案上按右鍵,建置
//04-2-4 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//04-2-5 指定控制器名稱為LinqController,並開啟LinqController
//04-2-6 using _04EF.Models
//04-2-7 於LinqController建立DB物件
//04-2-8 建立一般方法ShowEmployee()-查詢所有員工記錄
//04-2-9 執行並測試 http://localhost:53468/Linq/ShowEmployee (port可能不同)
//04-2-10 建立一般方法ShowCustomerByAddress()-找出客戶地址中含有keyword關鍵字的客戶記錄
//04-2-11 執行並測試 http://localhost:53468/Linq/ShowCustomerByAddress?keywork=xxxxx (port可能不同)
//04-2-12 建立一般方法ShowProduct()-查詢單價大於30的產品，並依單價做遞增排序，庫存量做遞減排序
//04-2-13 執行並測試 http://localhost:53468/Linq/ShowProduct (port可能不同)
//04-2-14 建立一般方法ShowProductInfo()-查詢產品平均價、總合、筆數，最高價和最低價資訊
//04-2-15 執行並測試 http://localhost:53468/Linq/ShowProductInfo (port可能不同)

//04-2-16 建立建立在SQL Server伺服器上的NorthWind.mdb資料庫Model
//        在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//        來自資料庫的EF Designer
//        連接NorthWind.mdf資料庫,連線名稱不修改,按下一步按鈕
//        選擇Entity Framework 6.x, 按下一步按鈕
//        資料表"全選", 按完成鈕
//        若跳出詢問方法按確定鈕
//04-2-17 在專案上按右鍵,建置
//04-2-18 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//04-2-19 指定控制器名稱為Linq2Controller,並開啟LinqController
//04-2-20 using _04EF.Models
//04-2-21 於Linq2Controller建立DB物件
//04-2-22 將LinqController內的4個方法複製至Linq2Controller,並測試結果