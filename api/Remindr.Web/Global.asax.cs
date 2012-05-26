using System;
using Quartz;
using Quartz.Impl;
using api.Scheduler;

namespace api
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            var scheduler = factory.GetScheduler();
            scheduler.Start();

            // Change this later to check for all implementations of a marker iterface like IScheduleJobs
            var perMinuteScheduler = new PerMinuteScheduler();
            perMinuteScheduler.Schedule(scheduler);
        }

    }
}