using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _02StatementController : Controller
    {
        public void Statement1()
        {
            int a = 10; //宣告變數a為int型態,並且初始化其值為10
            a = 20;  //指定運算 a=20

            a = a + 10; //做加法指定運算  a的值為30

            a += 10;  //a的值為40

            a -= 15;  //a的值為25
            a *= 10;  //a的值為250
            a /= 25;  //a的值為10

            a = a + 1;
            a += 1;
            a++;  //a的值為13

            Response.Write("a=" + a);

            Response.Write("<hr />");
            //浮點數的問題-精準度遺失
            int x = 123;
            float z = 12.14567f;
            float result = 0;
            result= x + z;

            Response.Write("x+z=" + result);

            Response.Write("<hr />");

            float xx = 10000.9f;
            double yy = 9999.3;
           

            Response.Write("xx+yy=" + ((decimal)xx+ (decimal)yy));
            Response.Write("<hr />");
            Response.Write("xx-yy=" + ((decimal)xx - (decimal)yy));
        }


        public string ifStatement(byte age)
        {
            //0-6歲免票,7-20歲半票, 21歲以上全票
            if (age > 20)
                return "全票";
            else if (age > 6)
                return "半票";
            

            return "免票";

        }



        public string switchStatement(string color)
        {
           switch(color)
            {
                case "yellow":
                    return "黃色";
                case "green":
                    return "綠色";
                case "red":
                    return "紅色";

            }

            return "這不是黃綠紅";

        }

        public void forStatement()
        {
           // var Rainbow = new Array("紅", "橙", "黃", "綠", "藍", "靛", "紫");
           // var RainbowColor = new Array("Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet");

            string[] arrRainbow = { "紅", "橙", "黃", "綠", "藍", "靛", "紫" };
            string[] arrColor = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };

            for(int i=0;i<arrRainbow.Length;i++)
            {
                Response.Write("<span style='color:"+arrColor[i]+";font-size:3rem'>"+arrRainbow[i]+"</span>");
            }
            
        }

        public void foreachStatement()
        {
            // var Rainbow = new Array("紅", "橙", "黃", "綠", "藍", "靛", "紫");
            // var RainbowColor = new Array("Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet");

            string[] arrRainbow = { "紅", "橙", "黃", "綠", "藍", "靛", "紫" };
            string[] arrColor = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };
            int i = 0;
            foreach (string item in arrRainbow)
            {
                Response.Write("<span style='color:" + arrColor[i] + ";font-size:3rem'>" + item + "</span>");
                i++;
            }

        }


        public void showPoker()
        {
            for(int i=1;i<=52;i++)  
                Response.Write("<img src='../poker_img/"+i+".gif' />");
        }


        public void whileStatement()
        {
            int i = 1;
            while (i<=52)
            {
                Response.Write("<img src='../poker_img/" + i + ".gif' />");
                i++;
            }
        }

        public void doWhileStatement()
        {
            int i = 1;
            do
            {
                Response.Write("<img src='../poker_img/" + i + ".gif' />");
                i++;
            } while (i <= 52);
        }

    }
}

//算數運算與指定運算
//1.算數運算子 +,-,*,/,%
//2.（）小括號
//3.連接符號 +
//4.負號 -
//5.優先權
//  ()
//  * , / , %
//  + , -
//6.留意浮點數運算後遺失精準度的問題

//條件判斷式
//1.if
//2.switch

//回圈
//1.for
//2.foreach
//3.while
//4.do....while