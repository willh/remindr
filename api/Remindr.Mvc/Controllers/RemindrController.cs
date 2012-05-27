using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remindr.Model.Database;
using Remindr.Mvc.Models;
using Remindr.Twilio;

namespace Remindr.Mvc.Controllers
{
    [HandleError]
    public class RemindrController : Controller
    {

        [HttpGet]
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

        [HttpPost]
        public JsonResult Appointment(Appointment appointment)
        {
            var response = new Response { Success = true };
            try
            {
                if (appointment.oneDayNotification)
                {
                    var reminder = new Reminder();
                    reminder._message = appointment.message;
                    reminder._mobileNumber = appointment.mobile;
                    reminder._nextScheduledReminder = appointment.reminderDate.AddDays(-1);
                    reminder.SaveToDb();
                }

                if (appointment.oneWeekNotification)
                {
                    var reminder = new Reminder();
                    reminder._mobileNumber = appointment.mobile;
                    reminder._message = appointment.message;
                    reminder._nextScheduledReminder = appointment.reminderDate.AddDays(-7);
                    reminder.SaveToDb();
                }
            }
            catch (Exception)
            {
                response.Success = false;
            }

            return Json(response);
        }

    }
}
