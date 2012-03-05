using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        static string m_Content =
@"# Edit this Page with MarkdownDeep

This demo project shows how to use MarkdownDeep in a typical ASP.NET MVC application.

* Click the *Edit this Page* link below to make changes to this page with MarkdownDeep's editor
* Use the links in the top right for more info.
* Look at the file `MarkdownDeepController.cs` for implementation details.

MarkdownDeep is written by [Topten Software](http://www.toptensoftware.com).  The project home for MarkdownDeep is [here](http://www.toptensoftware.com/markdowndeep).

";

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

        public ActionResult Prettify()
        {
            return View();
        }

        public ActionResult Markdown()
        {
            var md = new MarkdownDeep.Markdown();
            md.SafeMode = true;
            md.ExtraMode = true;

            // Transform the content into HTML and pass to the view
            ViewData["content"] = md.Transform(m_Content);
            return View();
        }

        public ActionResult Edit()
        {
            ViewData["content"] = m_Content;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        // content parameter is just markdown text, not html code
        public ActionResult Edit(string content)
        {
            m_Content = content;
            return RedirectToAction("Markdown");
        }
    }
}
