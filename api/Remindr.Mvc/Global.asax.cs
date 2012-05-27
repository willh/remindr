using System.Web.Mvc;
using System.Web.Routing;
using Quartz;
using Quartz.Impl;
using Remindr.Mvc.Scheduler;

namespace Remindr.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            SetupSchedulers();
        }

        private void SetupSchedulers()
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