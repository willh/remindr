using Quartz;

namespace Remindr.Mvc.Scheduler
{
    public class PerMinuteScheduler
    {
        public void Schedule(IScheduler scheduler)
        {
            var job = JobBuilder.Create<TextSenderJob>().Build();

            var trigger = TriggerBuilder.Create()
                            .WithSimpleSchedule(x => x.WithIntervalInSeconds(60).RepeatForever())
                            .Build();

            scheduler.ScheduleJob(job, trigger);    
        }
    }
}