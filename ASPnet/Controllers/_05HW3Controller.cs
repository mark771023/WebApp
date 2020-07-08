using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _05HW3Controller : Controller
    {
        // GET: _05HW3

        //主程式
        public void Poker_Main()
        {
            string[] poker = new string[52];  //52個長度的陣列(0~51)
            PlayGame(poker);
            Shuffle(poker);
            Deal_the_Card(poker);
        }

        //弄一副牌出來
        public void PlayGame(string[] poker)
        {
            for (int i = 0; i < poker.Length; i++)
            {
                poker[i] = (i + 1).ToString();
            }
        }

        //洗牌
        public void Shuffle(string[] poker)
        {
            Random r = new Random();
            int t = 0;
            string temp = "";
            for (int i = 0; i < poker.Length; i++)
            {
                t = r.Next(52);
                temp = poker[i];
                poker[i] = poker[t];
                poker[t] = temp;

            }
        }

        //發牌

        public void Deal_the_Card(string[] poker)
        {
            string p1 = "", p2 = "", p3 = "", p4 = "";
            string result = "";
            for (int i = 0; i < poker.Length; i++)
            {
                result = "<img src = '../poker_img/" + poker[i] + ".gif'>";
                switch (i % 4)
                {
                    case 0:
                        p1 += result;
                        break;
                    case 1:
                        p2 += result;
                        break;
                    case 2:
                        p3 += result;
                        break;
                    case 3:
                        p4 += result;
                        break;
                }

            }

            Response.Write("玩家1:" + p1 + "<br />玩家2:" + p2 + "<br />玩家3:" + p3 + "<br />玩家4:" + p4);
        }
    //public void Index()
    //    {
    //        string[] poker = new string[52];  //52個長度的陣列(0~51)

    //        //弄一副牌出來
    //        for(int i = 0; i < poker.Length; i++)
    //        {
    //            poker[i] = (i + 1).ToString();
    //        }

    //        //測試弄一副牌出來
    //        //for (int i = 0; i < poker.Length; i++)
    //        //{
    //        //    Response.Write("<img src='../poker_img/"+poker[i]+".gif'>");
    //        //}

    //        //洗牌
    //        Random r = new Random();
    //        int t = 0;
    //        string temp = "";
    //        for(int i=0;i<poker.Length;i++)
    //        {
    //            t = r.Next(52);
    //            temp = poker[i];
    //            poker[i] = poker[t];
    //            poker[t] = temp;

    //        }

    //        //測試洗牌
    //        //for (int i = 0; i < poker.Length; i++)
    //        //{
    //        //    Response.Write("<img src='../poker_img/" + poker[i] + ".gif'>");
    //        //}
    //        //Response.Write("<hr>");
            
    //        //發牌
    //        string p1 = "", p2 = "", p3 = "", p4 = "";
    //        string result ="";
    //        for (int i = 0; i < poker.Length; i++)
    //        {
    //            result= "<img src = '../poker_img/" + poker[i] + ".gif'>";
    //            switch (i%4)
    //            {
    //                case 0:
    //                    p1 += result;
    //                    break;
    //                case 1:
    //                    p2 += result;
    //                    break;
    //                case 2:
    //                    p3 += result;
    //                    break;
    //                case 3:
    //                    p4 += result;
    //                    break;
    //            }

    //        }

    //        Response.Write("玩家1:"+ p1 + "<br />玩家2:" + p2 + "<br />玩家3:" + p3 + "<br />玩家4:"+p4);


    //    }
    }
}