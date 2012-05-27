using System;
using Quartz;
using Remindr.Model;
using Remindr.Twilio;

namespace Remindr.Mvc.Scheduler
{
    public class TextSenderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var reminders = Reminders.GetRemindersForDate(DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc));
            
            var textService = new TextService();

            foreach (var reminder in reminders)
            {
                textService.SendMessage(reminder._mobileNumber, reminder._message);
            }            
        }
    }
}

