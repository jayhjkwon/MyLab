using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult First()
        {
            return View();
        }

        public ActionResult Second()
        {
            return View();
        }

        public ActionResult Third()
        {
            return View();
        }

        public ActionResult Fourth()
        {
            return View();
        }

        
        public JsonResult GetPeopleViaAjax()
        {
            var people = new List<Person>
                             {
                                 new Person {Name = "권효중", Address = "Songdo"},
                                 new Person {Name = "이수진", Address = "Seoul"},
                                 new Person {Name = "박지성", Address = "London"}
                             };

            return Json(people, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(List<Person> people)
        {
            var message = people.Aggregate("결과값\r\n", 
                (current, person) => current + string.Format("{0} {1} {2}", person.Name, person.Address, Environment.NewLine));
            
            return Json(message);
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
