using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class HomeController : Controller
    {
        //02-1-3 建立一般方法ShowAry()-計算陣列總合
        public string ShowAry()
        {
            int[] score = { 78, 99, 20, 100, 66, 64 };
            string show = "";
            int sum = 0;

            foreach(var m in score)
            {
                show += m + ", ";
                sum += m;
            }

            show += "<hr>";
            show += "總分:" + sum;

            return show;
        }

        //02-1-5 建立一般方法ShowImages()-傳回顯示images資料夾裡1.jpg~8.jpg的HTML字串
        public string ShowImages()
        {
            
            string show = "";

            for(int i=1;i<= 8;i++)
            {
                show += "<img src='../images/"+i+".jpg' />";
            }
            return show;
        }

        //02-1-7 建立一般方法ShowImageIndex()-依index參數取得對應圖示與說明
        public string ShowImagesIndex(int index)
        {
            string[] name = { "櫻桃鴨", "鴨油高麗菜", "鴨油麻婆豆腐", "櫻桃鴨握壽司", "片皮鴨捲三星蔥", "三杯鴨", "櫻桃鴨片肉", "慢火白菜燉鴨湯" };
            string show = string.Format("<p align='center'><img src='../images/{0}.jpg' /><br>{1}</p>", index, name[index - 1]);

          
            return show;
        }


        //02-1-9 排序方式的探討-ShowSortAry()、MySort()
        //輸出的結果必須從大到小排序
        public string ShowSortAry()
        {
            int[] score = { 78, 99, 20, 100, 66, 64 };

            //{ 100,99, 78, 66, 64, 20 };

            score = MySort(score);
            string show = "";

            foreach (var m in score)
            {
                show += m + ", ";
               
            }

            return show;
        }

        //02-1-10 Linq語法初探-ShowSortAry2()
        public string ShowSortAry2()
        {
            int[] score = { 78, 99, 20, 100, 66, 64 };

            //Linq
            //Select m from score order by m desc
            var s = from m in score
                    orderby m descending
                    select m;

            string show = "";

            foreach (var m in s)
            {
                show += m + ", ";

            }

            return show;
        }


        //排序的程式
        //氣泡排序法
        private int[] MySort(int[] score)
        {
            int tmp = 0;
            for (int j = score.Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (score[i] < score[i + 1])
                    {
                        tmp = score[i];
                        score[i] = score[i + 1];
                        score[i + 1] = tmp;
                    }
                }
            }

            return score;
        }

    }
}


//02-1 Controller撰寫練習-一般方法
//02-1-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//02-1-2 指定控制器名稱為HomeController,並開啟HomeController
//02-1-3 建立一般方法ShowAry()-計算陣列總合
//02-1-4 執行並測試 http://localhost:53468/Home/ShowAry (port可能不同)
//02-1-5 建立一般方法ShowImages()-傳回顯示images資料夾裡1.jpg~8.jpg的HTML字串
//02-1-6 執行並測試 http://localhost:53468/Home/ShowImages (port可能不同)
//02-1-7 建立一般方法ShowImageIndex()-依index參數取得對應圖示與說明
//02-1-8 執行並測試 http://localhost:53468/Home/ShowImageIndex?index=1 (port可能不同)
//02-1-9 排序方式的探討-ShowSortAry()、MySort()
//02-1-10 Linq語法初探-ShowSortAry2()


//02-2 簡單模型繫結
//02-2-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//02-2-2 指定控制器名稱為SimpleBindController,並開啟SimpleBindController
//02-2-3 建立GET與POST的Create方法
//02-2-4 在public ActionResult Create()上按右鍵,新增檢視,建立Create View
//02-2-5 進行下列設定:
//       View name:Create
//       Template:Empty(without model)
//       不勾選Use a layout pages
//       按下Add
//02-2-6 修改title文字與加入form內容
//02-2-7 執行並測試 http://localhost:53468/SimpleBind/Create (port可能不同)

//02-3 複雜單模型繫結
//02-3-1 在Models上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入Product.cs
//02-3-2 在Product class中輸入下列欄位以建立Model
//02-3-3 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//02-3-4 指定控制器名稱為ComplexBindController,並開啟ComplexBindController
//02-3-5 using _02Controller.Models
//02-3-6 建立GET與POST的Create方法
//02-3-7 在public ActionResult Create()上按右鍵,新增檢視,建立Create View
//02-3-8 進行下列設定:
//       View name:Create
//       Template:Empty(without model)
//       不勾選Use a layout pages
//       按下Add
//02-3-9 修改title文字與加入form內容
//02-3-10 執行並測試 http://localhost:53468/ComplexBind/Create (port可能不同)

//02-4 檔案上傳功能
//02-4-1 建立Photos資料夾
//02-4-2 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//02-4-3 指定控制器名稱為FileUploadController,並開啟FileUploadController
//02-4-4 using System.IO
//02-4-5 建立GET與POST的Create方法
//02-4-6 建立ShowPhotos()一般方法-可顯示Photos資料夾下所有圖檔
//02-4-7 在public ActionResult Create()上按右鍵,新增檢視,建立Create View
//02-4-8 進行下列設定:
//       View name:Create
//       Template:Empty(without model)
//       不勾選Use a layout pages
//       按下Add
//02-4-9 修改title文字與加入form內容
//02-4-10 執行並測試 http://localhost:53468/FileUpload/Create (port可能不同)

//02-5 一次多個檔案上傳功能
//02-5-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//02-5-2 指定控制器名稱為MultiFileUploadController,並開啟MultiFileUploadController
//02-5-3 using System.IO
//02-5-4 建立GET與POST的Create方法
//02-5-5 建立ShowPhotos()一般方法-可顯示Photos資料夾下所有圖檔
//02-5-6 在public ActionResult Create()上按右鍵,新增檢視,建立Create View
//02-5-7 進行下列設定:
//       View name:Create
//       Template:Empty(without model)
//       不勾選Use a layout pages
//       按下Add
//02-5-8 修改title文字與加入form內容
//02-5-9 執行並測試 http://localhost:53468/MultiFileUpload/Create (port可能不同)