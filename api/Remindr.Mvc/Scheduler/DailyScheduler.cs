using Quartz;

namespace Remindr.Mvc.Scheduler
{
    public class DailyScheduler
    {
        public void Schedule(IScheduler scheduler)
        {
            //var job = JobBuilder.Create<TextSenderJob>().Build();

            //var trigger = TriggerBuilder.Create().StartNow().
            //                WithDailyTimeIntervalSchedule()
            //               .WithSimpleSchedule(x => x. .WithIntervalInSeconds(30).RepeatForever())
            //               .Build();

            //scheduler.ScheduleJob(job, trigger);
        }
    }
}