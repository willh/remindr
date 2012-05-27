using System;
using System.Web.Mvc;
using Remindr.Model.Database;
using Remindr.Mvc.Models;
using Remindr.Twilio;
using System.Globalization;

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
                var reminderDate = DateTime.Parse(appointment.reminderDate);

                if (appointment.oneDayNotification)
                {
                    var reminder = new Reminder
                                       {
                                           _message = appointment.message,
                                           _mobileNumber = appointment.mobile,
                                           _nextScheduledReminder = reminderDate.AddDays(-1)
                                       };
                    reminder.SaveToDb();
                }

                if (appointment.oneWeekNotification)
                {
                    var reminder = new Reminder
                                       {
                                           _mobileNumber = appointment.mobile,
                                           _message = appointment.message,
                                           _nextScheduledReminder = reminderDate.AddDays(-7)
                                       };
                    reminder.SaveToDb();
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.GetType() + e.Message;
            }

            return Json(response);
        }

    }
}
