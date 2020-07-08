using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    public class SuperMan : Human
    {
        public string Fly()
        {
            return "I can fly so height!!";

        }


        public string Fly(int w)
        {
            return "我飛了" + w + "公里遠";

        }


    }
}