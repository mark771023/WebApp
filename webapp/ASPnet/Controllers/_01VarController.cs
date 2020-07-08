using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _01VarController : Controller
    {
        public string Index()
        {
            //字串
            string w = "Hello World!!";
            w = "12345678";
            return w;

        }
        public string boolIndex(bool gender)
        {
            //布林
            bool w = gender;
            
            if (w)
                return "男生";

            return "女生";

        }
        public string stringIndex(bool gender, string name)
        {

            string g = "";

            g = gender ? "男" : "女";

            return "<h1>"+name + "您好!您的性別是" + g + "生!!</h1>";

        }

        public void NumberIndex()
        {
            //數值
            byte a = 123;  //0~255的整數值(8位元正整數)
            sbyte b = 127;  //-128~127含正負數的8位元整數
            short c = 234; //正負數16位元(-32768~32767)
            int d = 1111;  //正負數32位元(-2,147,683,648~2,147,683,647)
            long e = 45677; //正負數64位元
            
            /////////////////////////////////////////////////////////////////

            ushort f = 234; //正數16位元(0~65,535)
            uint g = 1111;  //正數32位元
            ulong h = 45677; //正數64位元

            //////////////////////////////////////////////////

            float i = 123.34f;  //單精準度浮點數
            double j = 123.34;  //雙精準度浮點數

        }
    }
}

//變數命名原則
//1.不可以用保留字
//2.開頭必須是英文字母或底線
//3.同一支程式區塊內,變數名稱不可重複,大小寫視為不同

//變數命名原則
//1.使用有意義的名稱
//2.使用匈牙利命名法
//string strStudentNo = "12345678";
//int intNumber = 123;