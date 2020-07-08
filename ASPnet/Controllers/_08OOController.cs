using ASPnet.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _08OOController : Controller
    {
        Human Jack = new Human();

        Animal animal;
        IAnimalSpeak speak;
        IAnimalMove move;

        public void Test()
        {
            //Jack.Name = "Jack Liao";//給值set
            Jack.Age = 24;
            // Jack.Gender = true;

            Human Mary = new Human();
            //Mary.Gender = false;
            Mary.Age = -20;
            //Mary.Name = "Mary Chen";

            //Random r = new Random();
            //r.Next()

            Human John = new Human("John Lee", 30, true, 175, 68);

            SuperMan superMan = new SuperMan();

            //John.Gender = false;

            //Response.Write(Jack.Name+"<br>");//取值get

            Response.Write(superMan.Fly() + "<br>");
            Response.Write(superMan.Fly(20) + "<br>");
            Response.Write(Jack.Name + "<br>");
            //Response.Write(John.Name + "<br>");//取值get


            Fish smallFlower = new Fish();
            //smallFlower.s

        }


        public ActionResult polymophism()
        {
            return View();
        }

        [HttpPost]
        public ActionResult polymophism(string type)
        {
            Dog black = new Dog();
            Cat mimi = new Cat();
            Fish little = new Fish();


            if (type == "d")
            {
                black.Name = "小黑";

                move = black;
                speak = black;
            }
            else if (type == "c")
            {
                move = mimi;
                speak = mimi;
            }
            else
            {
                move = little;
            }


            ViewBag.Result = move.Move(100);

            return View();
        }


    }
}