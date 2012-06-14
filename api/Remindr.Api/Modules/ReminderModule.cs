using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using Remindr.Api.Models;
using Remindr.Model.Database;
using Remindr.Twilio;

namespace Remindr.Api.Modules
{
    public class ReminderModule : NancyModule
    {
        TextService service = new TextService();
        
        public ReminderModule()
        {
            Get["/message/send"] = SendMessage;

            Post["/medication"] = SetupMedicationReminder;
        }

        private static DateTime ParseDate(string date)
        {
            string[] dateParts = date.Split('/');
            return new DateTime(int.Parse(dateParts[2]), int.Parse(dateParts[1]), int.Parse(dateParts[0]));
        }

        private Nancy.Response SendMessage(dynamic parameters)
        {
            string sendTo = parameters.sendTo;
            string textMessage = parameters.textMessage;

            try
            {
                service.SendMessage(sendTo, textMessage);
                return Response.AsJson(new { success = true });
            }
            catch
            {
                return Response.AsJson(new { success = false });
            }
        }

        private Nancy.Response SetupMedicationReminder(dynamic _)
        {
            Medication medication = this.Bind<Medication>();

            try
            {
                var reminderStartDate = ParseDate(medication.reminderStartDate);
                var reminderEndDate = ParseDate(medication.reminderEndDate);
                var reminder = new Reminder
                {
                    _nextScheduledReminder = reminderStartDate,
                    _endReminderDate = reminderEndDate,
                    _message = medication.message,
                    _schedule = medication.schedule,
                    _mobileNumber = medication.mobileNumber
                };

                reminder.SaveToDb();
     
                return Response.AsJson(new { success = true });
            }
            catch(Exception e)
            {
                return Response.AsJson(new
                {
                    success = false,
                    message = e.Message
                });
            }
        }
    }
}