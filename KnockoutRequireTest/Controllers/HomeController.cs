using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutRequireTest.Controllers
{
    public class HomeController : Controller
    {
        private static List<Task> _tasks = MakeTestData();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("tasks")]
        public JsonResult Tasks()
        {
            return Json(_tasks, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("task")]
        public JsonResult Tasks(string id)
        {
            return Json(_tasks.SingleOrDefault(t=>t.id == id) , JsonRequestBehavior.AllowGet);
        }

        private static List<Task> MakeTestData()
        {
            var tasks = new List<Task>
            {
                new Task{id="1", title="clean your room"},
                new Task{id="2", title="do your homework"}
            };

            return tasks;
        }

        

    }

    public class Task
    {
        public string id { get; set; }
        public string title { get; set; }
    }
}
