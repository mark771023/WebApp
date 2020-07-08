using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _02Controller.Controllers
{
    public class FileUploadController : Controller
    {
        //02-4-5 建立GET與POST的Create方法
        // GET: FileUpload
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {

            string fileName = "";

            if (photo != null)
            {

                if (photo.ContentLength > 0)
                {
                    fileName = photo.FileName;
                    fileName = Path.GetFileName(fileName);


                    photo.SaveAs(Server.MapPath("~/Photos/" + fileName));
                }
            }
            //return View();
            return RedirectToAction("ShowPhotos");
        }

        public string ShowPhotos() 
        {
            string show = "";

            //建立一個可以操作資料夾的物件
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Photos"));

            //把取得的所有檔案放到FileInfo物件陣列裡
            FileInfo[] fInfo = dir.GetFiles();

            //用迴圈逐一將檔名讀出,並放入img元素的src屬性
            foreach(FileInfo result in fInfo)
            {
                show += "<a href='../Photos/" + result.Name + "'><img src='../Photos/" + result.Name+"' width='100'></a>";
            }
            show += "<p><a href='Create'>返回Create</a></p>";
            return show;
        }


    }
}