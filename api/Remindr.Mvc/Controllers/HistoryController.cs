using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remindr.Mvc.Models;
using Remindr.Model;

namespace Remindr.Mvc.Controllers
{
    public class HistoryController : Controller
    {
        [HttpGet]
        public JsonResult GetHistory(GetHistoryRequest request)
        {
            if (!string.IsNullOrEmpty(request.Id))
            {
                return Json(Reminders.GetHistoryForNumber(request.Id), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(request.Number))
            {
                var countryCodeAndNumber = "+44" + request.Number.TrimStart('0');
                return Json(Reminders.GetHistoryForNumber(countryCodeAndNumber), JsonRequestBehavior.AllowGet);
            }

            return Json(Reminders.GetAllSentReminders(), JsonRequestBehavior.AllowGet);
        }
    }
}
