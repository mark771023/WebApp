using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _06FunctionController : Controller
    {
        // GET: _06Function
        public void fun1()
        {
            int a = 3;
            int b = 5;
            fun2(ref a, ref b);
            Response.Write(a + b);
        }

        public void fun2(ref int a, ref int b)
        {
            a += 10;
            b += 10;
            
        }
    }
}