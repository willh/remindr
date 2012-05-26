using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remindr.Mvc.Models;

namespace Remindr.Mvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public JsonResult RemindrTest()
        {
            var response = new Response {Success = true};
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
