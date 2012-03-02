using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "MVC + Bootstrap = POWER!!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Masonry()
        {
            return View();
        }

        public ActionResult Carousel()
        {
            return View();
        }
    }
}
