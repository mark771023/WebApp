using _03View.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _03View.Controllers
{
    public class HTMLHelperController : Controller
    {
        // GET: HTMLHelper
        //03-6-6 建立GET與POST的Create方法
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member, string ValidationCode)
        {
            if (ValidationCode == Session["Code"].ToString())
            {
                string msg = "";
                msg = "您的註冊資料如下:<br>" +
                    "帳號：" + member.UserId + "<br>" +
                    "密碼：" + member.Pwd + "<br>" +
                    "姓名：" + member.Name + "<br>" +
                    "信箱：" + member.Email + "<br>" +
                    "生日：" + member.Birthday.ToShortDateString();

                ViewBag.Msg = msg;
            }
            else
            {
                ViewBag.CodeErr = "驗證碼錯誤!!";
            }
            return View();
        }


        public ActionResult getCode()
        {
            //安排你所要的驗證碼符號內容
            string[] arrLetter = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q",
                "R","S","T","W","X","Y","a","b","c","d","e","f","g","h","j","k","m","n","p","r","s","t","w","x",
                "y","2","3","4","5","6","7","8","9"};

            //隨機產生一組6個字元的驗證碼
            Random r = new Random();
            string strCode = "";
            int a = 0;
            for (int i = 0; i < 6; i++)
            {
                a = r.Next(arrLetter.Length);
                strCode += arrLetter[a];
            }

            Session["Code"] = strCode;

            //產生一張圖片
            Bitmap img = new Bitmap(280, 80);

            Graphics g = Graphics.FromImage(img);

            int intRed = r.Next(0, 256);
            int intGreen = r.Next(0, 256);
            int intBlue = r.Next(0, 256);

            g.Clear(Color.FromArgb(10, intRed, intGreen, intBlue));

            //畫干擾線
            int x1, x2, y1, y2;
            for (int i = 0; i < 50; i++)
            {
                x1 = r.Next(img.Width);
                x2 = r.Next(img.Width);
                y1 = r.Next(img.Height);
                y2 = r.Next(img.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            //畫干擾

            for (int i = 0; i < 500; i++)
            {
                x1 = r.Next(img.Width);

                y1 = r.Next(img.Height);


                img.SetPixel(x1, y1, Color.FromArgb(r.Next(256)));
            }

            //處理文字

            //產生一個隨機產色1
            intRed = r.Next(0, 256);
            intGreen = r.Next(0, 256);
            intBlue = r.Next(0, 256);
            Color color1 = Color.FromArgb(intRed, intGreen, intBlue);
            //產生一個隨機產色2
            intRed = r.Next(0, 256);
            intGreen = r.Next(0, 256);
            intBlue = r.Next(0, 256);
            Color color2 = Color.FromArgb(intRed, intGreen, intBlue);
            //產生一個矩形
            Rectangle MyRect = new Rectangle(0, 0, img.Width, img.Height);

            Font font = new Font("Arial Black", 40, FontStyle.Bold);
            System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(MyRect, color1, color2, 1f);

            //把文字畫進去g裡面
            g.DrawString(strCode, font, brush, 5, 5);

            Image image = img;

            MemoryStream ms = new MemoryStream();

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return File(ms.GetBuffer(), "image/jpeg");
        }


    }
}