using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication27.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test1()
        {
            return View();
        }

        public ActionResult Test2()
        {
            return View();
        }

        public ActionResult Test3()
        {
            return View();
        }

        public ActionResult Test4()
        {
            return View();
        }

        public ActionResult Test5()
        {
            return View();
        }

        public ActionResult Test6()
        {
            return View();
        }

        public ActionResult Test7()
        {
            return View();
        }

        public ActionResult Test8()
        {
            return View();
        }

        public ActionResult Test9()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return View();
        }

        public ActionResult Slider1()
        {
            return View();
        }
    }
}
