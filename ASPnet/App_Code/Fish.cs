using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    public class Fish : Animal, IAnimalMove

    {
        public string Move(int m)
        {
            return Name + "游了" + m + "公尺";
        }

    }
}