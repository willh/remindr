using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remindr.Mvc.Models;

namespace Remindr.Mvc.Controllers
{
    [HandleError]
    public class RemindrController : Controller
    {
        public JsonResult SendTextMessage(SendTextMessageRequest request)
        {
            var response = new Response { Success = true };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
