using System;
using Quartz;
using Remindr.Model.Services;
using Remindr.Model.Database;
using Remindr.Model.Ninject;

namespace Remindr.Mvc.Scheduler
{
    public class TextSenderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            IDatabaseAccess databaseAccess = NinjectProvider.GetInstance<IDatabaseAccess>();
            var reminders = databaseAccess.GetRemindersForDate(DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc));

            var textService = NinjectProvider.GetInstance<ITextService>();            

            foreach (var reminder in reminders)
            {
                textService.SendMessage(reminder);
            }            
        }
    }
}

