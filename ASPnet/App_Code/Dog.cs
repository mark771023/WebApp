using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    public class Dog : Animal, IAnimalMove, IAnimalSpeak
    {
        public string Move(int m)
        {
            return Name + "跑了" + m + "公尺";
        }

        public string Speak()
        {
            return "汪汪汪!";
        }

    }
}