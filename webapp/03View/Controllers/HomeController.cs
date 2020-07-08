using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//03-1-5 using _03View.Models
using _03View.Models;

namespace _03View.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };

            string[] name = { "瑞豐夜市", "新堀江商圈", "六合夜市", "青年夜市", "花園夜市", "大東夜市", "武聖夜市" };

            string[] address = { "813高雄市左營區裕誠路", "800高雄市新興區玉衡里", "800台灣高雄市新興區六合二路",
                "80652高雄市前鎮區凱旋四路758號", "台南市北區海安路三段533號", "台南市東區林森路一段276號",
                "台南市中西區武聖路69巷42號" };


            List<NightMarket> list = new List<NightMarket>();

            for (int i = 0; i < id.Length; i++)
            {
                NightMarket nm = new NightMarket();
                nm.Id = id[i];
                nm.Name = name[i];
                nm.Address = address[i];

                list.Add(nm);
            }


            return View(list);
        }

        public ActionResult RazorTest()
        {
            
            return View();
        }

    }
}

//03-1 建立一個顯示各大夜市的View
//03-1-1 在Models上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入NightMarket.cs
//03-1-2 在NightMarket class中輸入下列欄位以建立Model
//03-1-3 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//03-1-4 指定控制器名稱為HomeController,並開啟HomeController
//03-1-5 using _03View.Models
//03-1-6 在public ActionResult Index()內輸入內容
//03-1-7 在public ActionResult Index()上按右鍵,新增檢視
//03-1-8 進行下列設定:
//       View name:Index
//       Template:List
//       Model class:NightMarket(03View.Models) 
//       勾選Use a layout pages
//       按下Add

//03-2 NightMarket View
//03-2-1 修改英文標題為中文,修改<th>標籤內容為中文字
//03-2-2 增加item.Id, 並將最後一欄註解
//03-2-3 執行以測試結果

//03-3 _Layout的處理
//03-3-1 將_Layout裡有關名稱的三處改為自己想要的字
//03-2-3 執行NightMarket/Index查看結果

//03-4 Razor語法
//03-4-1 在Home Controller 新增RazorTest() Action
//03-4-2 在public ActionResult RazorTest()上按右鍵,新增檢視
//03-4-3 進行下列設定:
//       View name:RazorTest
//       Template:Empty (without model)
//       勾選Use a layout pages
//       按下Add
//03-4-4 Razor語法練習

//03-5 使用Razor修改Home/Index View
//03-5-1 增加兩項<th>標籤
//03-5-2 讀取圖片檔名
//03-5-3 增加圖片及地圖顯示


//03-6 HTML Helper
//03-6-1 在Models上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入Member.cs
//03-6-2 在Member class中輸入下列欄位以建立Model
//03-6-3 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//03-6-4 指定控制器名稱為HTMLHelperController,並開啟HTMLHelperController
//03-6-5 using _03View.Models
//03-6-6 建立GET與POST的Create方法
//03-6-7 在public ActionResult Create()上按右鍵,新增檢視
//03-6-8 進行下列設定:
//       View name:Create
//       Template:Create
//       Model classMember(03View.Models) 
//       勾選Use a layout pages
//       按下Add
//03-6-9 撰寫HTMLHelper/Create View 內容
//03-6-10 執行以測試結果
//03-6-11 撰寫@helper方法
//03-6-12 執行以測試結果

//03-7 分頁做法
//03-7-1 使用NuGet安裝PagedList.Mvc套件
//03-7-2 修改Home Controller 裡Index actoin內容
//03-7-3 修改Paging/Index View 內容
//03-7-4 執行以測試結果

//03-8 Boostrap實現RWD
//03-8-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//03-8-2 指定控制器名稱為BoostrapController,並開啟BoostrapController
//03-8-3 using _03View.Models
//03-8-4 在public ActionResult Index()內輸入內容
//03-8-5 在public ActionResult Index()上按右鍵,新增檢視
//03-8-6 進行下列設定:
//       View name:Index
//       Template:List
//       Model class:NightMarket(03View.Models) 
//       勾選Use a layout pages
//       按下Add



//03-9 圖形驗證碼