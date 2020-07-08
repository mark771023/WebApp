using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _07WebAPI.Models;

namespace _07WebAPI.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            List<Course> cousres = new List<Course>
            {
                new Course{ Id=1, Name="Asp.net MVC5",Hours=30},
                new Course{ Id=2, Name="Asp.net Webform",Hours=50},
                new Course{ Id=3, Name="PHP",Hours=32},
                new Course{ Id=4, Name="HTML5",Hours=24},
                new Course{ Id=5, Name="Javascript",Hours=60},
                new Course{ Id=6, Name="jQuery",Hours=28},
                new Course{ Id=7, Name="Bootstrap",Hours=50},
                new Course{ Id=8, Name="SQL Server",Hours=48},
                new Course{ Id=9, Name="Android APP",Hours=40},
                new Course{ Id=10, Name="JAVA",Hours=24}
            };

            return View(cousres);
        }

        //[AcceptVerbs("GET","POST")]
        //public IEnumerable<Course> GetCousres()
        //{
        //    return Course;
        //}
    }
}