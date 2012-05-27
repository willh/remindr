using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remindr.Mvc.Models;
using Remindr.Twilio;

namespace Remindr.Mvc.Controllers
{
    [HandleError]
    public class RemindrController : Controller
    {
        public JsonResult SendTextMessage(SendTextMessageRequest request)
        {
            var response = new Response{ Success = true };

            var textService = new TextService();

            try
            {
                textService.SendMessage(request.SendTo, request.TextMessage);
            }
            catch (Exception e)
            {
                response.Success = false;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
