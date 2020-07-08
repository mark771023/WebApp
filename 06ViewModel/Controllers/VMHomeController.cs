using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//06-2-3 using _06ViewModel.Models及using _06ViewModel.ViewModels
using _06ViewModel.Models;
using _06ViewModel.ViewModels;

namespace _06ViewModel.Controllers
{
    public class VMHomeController : Controller
    {
        //06-2-4 於HomeController建立DB物件
        dbEmployeeEntities db = new dbEmployeeEntities();

        //06-2-5 編輯ActionResult Index()的內容
        public ActionResult Index(int depId=1)
        {
            ViewBag.DeptName= db.tDepartment.Where(m => m.fDepId == depId).FirstOrDefault().fDepName + "部門";

            VMDeptEmp vm = new VMDeptEmp()
            {
                department = db.tDepartment.ToList(),
                employee = db.tEmployee.Where(m => m.fDepId == depId).ToList()
            };

            return View(vm);
        }

        //06-2-6 於HomeController建立GET與POST的Create Action
        public ActionResult Create()
        {
            var dept = db.tDepartment.ToList();
            return View(dept);
        }

        [HttpPost]
        public ActionResult Create(tEmployee emp)
        {
            db.tEmployee.Add(emp);
            db.SaveChanges();
            
            return RedirectToAction("Index",new { depId= emp.fDepId });
        }

        //06-2-7 於HomeController建立POST的Delete Action
        public ActionResult Delete(string fEmpId)
        {
            var emp = db.tEmployee.Where(m => m.fEmpId == fEmpId).FirstOrDefault();
            db.tEmployee.Remove(emp);
            db.SaveChanges();

            return RedirectToAction("Index", new { depId = emp.fDepId });
        }
    }
}


//06-1 建立ViewModel
//06-1-1 建立dbEmployee.mdb資料庫Model
//       在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//       來自資料庫的EF Designer
//       連接dbEmployee.mdf資料庫,連線名稱不修改,按下一步按鈕
//       選擇Entity Framework 6.x, 按下一步按鈕
//       資料表"全選", 按完成鈕
//       若跳出詢問方法按確定鈕
//06-1-2 在專案上按右鍵,建置
//06-1-3 加入ViewModels資料夾
//06-1-4 using _06ViewModel.Models
//06-1-5 建立tDepartment和tEmployee的List物件

//06-2 建立VMHomeController
//06-2-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//06-2-2 指定控制器名稱為VMHomeController,並開啟VMHomeController
//06-2-3 using _06ViewModel.Models及using _06ViewModel.ViewModels
//06-2-4 於VMHomeController建立DB物件
//06-2-5 編輯ActionResult Index()的內容
//06-2-6 於HomeController建立GET與POST的Create Action
//06-2-7 於HomeController建立POST的Delete Action

//06-3 建立各個View
//06-3-1 在public ActionResult Index()上按右鍵,新增檢視,建立Index View
//06-3-2 進行下列設定:
//       View name:Index
//       Template:Empty (Without model)
//       勾選Use a layout pages
//       按下Add
//06-3-3 在最上方加上@model _06ViewModel.ViewModels.VMDepEmp
//06-3-4 將tilte改為中文,<h2>改為在HomeController所建立的ViewBag.DepName
//06-3-5 在Index View中撰寫顯示畫面
//06-3-6 執行及測試
//06-3-7 在public ActionResult Create()上按右鍵,新增檢視,建立CreateView
//06-3-8 進行下列設定:
//       View name:Create
//       Template:Empty (Without model)
//       勾選Use a layout pages
//       按下Add
//06-3-9 加入給下拉選單用的資料
//06-3-10 將英文字改為中文字
//06-3-11 建立員工資料新增表單
//06-3-12 執行及測試