using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _04HW2Controller : Controller
    {
        // GET: _04HW2
        public void No1(int n)
        {
            bool flag = false;

            for(int i=2;i<n;i++)
            {
                if (n % i == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                Response.Write(n+"不是質數");
            else
                Response.Write(n + "是質數");

        }
        public void No2(int x, int y)
        {
            int xx = x, yy = y,z=0;

            while (xx%yy!=0) 
            {
                z = xx % yy;
                xx = yy;
                yy = z;
            }


            Response.Write(x+"與"+y + "的最大公因數為"+yy);
        }
        public void No3(int n)
        {
            //n=12345
            int r = 0; //放餘數
            int q = 0; //放商數
            int nn = n;
            int result = 0;

            do
            {
                r = nn % 10;  //取到餘數
                result += r;  //把餘數組合進結果
                q = nn / 10;  //取商數
               
                nn = q;  //把商數做為下一輪的被除數
                if(q!=0)
                    result *= 10;
            } while (q != 0);


            if(result==n)
                Response.Write(n + "是迴文");
            else
                Response.Write(n + "不是迴文");
        }
    }
}