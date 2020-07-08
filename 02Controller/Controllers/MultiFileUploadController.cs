using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _02Controller.Controllers
{
    public class MultiFileUploadController : Controller
    {
        // GET: MultiFileUpload
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photo)
        {

            string fileName = "";

            for (int i = 0; i < photo.Length; i++)
            {
                // 取得目前檔案上傳的HttpPostedFileBase物件
                // 即虛引數的photos[i]可以取得第i 個所上傳的檔案
                if (photo[i] != null)
                {
                    // 若目前檔案上傳的HttpPostedFileBase物件的檔案名稱為不為空白
                    // 即表示第 i 個f物件有指定上傳檔案
                    if (photo[i].ContentLength > 0)
                    {
                        //直接檔名
                        //fileName = photo[i].FileName;
                        //fileName = Path.GetFileName(fileName);

                        //自訂檔名
                        fileName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("上午", "").Replace("下午", "") + (i + 1).ToString() + ".jpg";
                        // 將檔案儲存到網站的Photos資料夾下
                        photo[i].SaveAs(Server.MapPath("~/Photos/" + fileName));
                    }
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
            foreach (FileInfo result in fInfo)
            {
                show += "<a href='../Photos/" + result.Name + "'><img src='../Photos/" + result.Name + "' width='100'></a>";
            }
            show += "<p><a href='Create'>返回Create</a></p>";
            return show;
        }



    }
}