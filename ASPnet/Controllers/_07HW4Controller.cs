using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _07HW4Controller : Controller
    {
       
        const string eng = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
        public ActionResult GetId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetId(string a)
        {
            Random r = new Random();
            

            string w = eng.Substring(r.Next(26),1);  //假設=h
            int intEng = eng.IndexOf(w) + 10;  //索引位置在7,因此加10為17


            int n1 = intEng / 10;  //n1=1
            int n2 = intEng % 10;  //n2=7

            string gender = r.Next(1, 3).ToString();

            string id = w + gender;
            for (int i = 0; i < 7; i++)
            {
                id += r.Next(10).ToString();
            }
            int sum = 0;

            for (int i = 1; i < 9; i++)
            {
                sum += Convert.ToInt32(id.Substring(i, 1)) * (9 - i);
            }

            sum += n1 + n2 * 9;

            id += (10 - sum % 10).ToString();

            ViewBag.id = id;
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id)
        {

            string result = "";
            if ( ! LengthCheck(ref id))
                result = "格式有誤";
            else if (!LetterCheck(ref id))
            {
                result = "格式有誤";
            }
            else if (!GenderCheck(ref id))
            {
                result = "格式有誤";
            }
            else if (!NumberCheck(ref id))
            {
                result = "格式有誤";
            }
            else if (!RuleCheck(ref id))
            {
                result = "身分證字號不正確";
            }
            else
                result = "身分證字號合法";

            //Response.Write(result);
            ViewBag.Result = result;
            return View();
        }

        bool LengthCheck(ref string id)
        {
            if (id.Length == 10)
                return true;

            return false;
        }

        bool LetterCheck(ref string id)
        {
            string w = id.Substring(0, 1);

            if(eng.Contains(w))
                return true;

            return false;
        }

        bool GenderCheck(ref string id)
        {
            string gender = id.Substring(1, 1);

            if (gender=="1" || gender=="2")
                return true;

            return false;
        }


        bool NumberCheck(ref string id)
        {
            try
            {
                for (int i = 2; i < 10; i++)
                {
                    Convert.ToInt16(id.Substring(i, 1));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool RuleCheck(ref string id)
        {
            string w = id.Substring(0, 1);  //假設=h
            int intEng = eng.IndexOf(w) + 10;  //索引位置在7,因此加10為17


            int n1 = intEng / 10;  //n1=1
            int n2 = intEng % 10;  //n2=7
            int sum = 0;

            for(int i = 1; i < 9; i++) 
            {
                sum += Convert.ToInt32(id.Substring(i, 1)) * (9 - i);
            }

            sum = n1 + n2 * 9 + sum+ Convert.ToInt32(id.Substring(9, 1));
            //sum = n1 + n2 * 9 + sum;

            if (sum % 10 == 0)
                return true;

            return false;
        }

    }
}