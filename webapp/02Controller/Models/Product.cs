using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02Controller.Models
{
    //02-3-6 建立GET與POST的Create方法
    public class Product  //類別名稱(Entity Name)
    {
        public string PId { get; set; }  //PId編號屬性
        public string PName { get; set; } //PName編號屬性
        public int Price { get; set; } //Price編號屬性
    }
}