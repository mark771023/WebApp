using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    public class Human
    {
        //欄位Field
        string name;
        int age;
        bool gender;
        decimal height;
        decimal weight;

        //建構子(建構式,建構函數,建構函式)
        //constucto
        public Human()
        {
            name = "第一名";
        }

        public Human(string Name)
        {
            name = Name;
        }
        public Human(string Name, int Age)
        {
            name = Name;
            age = Age;
        }

        public Human(string Name, int Age, bool Gender)
        {
            name = Name;
            age = Age;
            gender = Gender;
        }
        public Human(string Name, int Age, bool Gender, decimal H, decimal W)
        {
            name = Name;
            age = Age;
            gender = Gender;
            height = H;
            weight = W;
        }
        //屬性(Property)
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0)
                    age = 0;
                else
                    age = value;
            }
        }
        public bool Gender
        {
            get { return gender; }

        }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }



        //方法
        /// <summary>
        /// 傳回您的名字
        /// </summary>
        /// <returns></returns>
        public string Speack()
        {
            return "我的名字叫做" + name;

        }

        /// <summary>
        /// 請輸入您要說的話
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Speack(string content)
        {
            return name + "說:" + content;

        }
        /// <summary>
        /// 請輸入您目前的等級
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string Speack(int level)
        {
            return name + "的等級已到了第" + level + "級";

        }


        public string Jump()
        {
            return name + "嚇了一跳!!";

        }

        public string Jump(int h)
        {
            return name + "跳了" + h + "公尺高";

        }

        public string Jump(int h, int w)
        {
            return name + "跳了" + h + "公尺高" + w + "公尺遠";

        }


        public string Walk(int m)
        {
            return name + "走了" + m + "公尺遠";

        }
    }
}