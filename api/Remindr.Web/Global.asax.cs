using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace api
{

    public class HelloAppHost : AppHostBase
    {
        //Tell Service Stack the name of your application and where to find your web services
        public HelloAppHost() : base("Hello Web Services", typeof(HelloService).Assembly) { }

        public override void Configure(Container container)
        {
            //register user-defined REST-ful urls
            Routes
              .Add<HelloService>("/hello")
              .Add<HelloService>("/hello/{Name}");
        }
    }

    public class Global : System.Web.HttpApplication
    {

        


        protected void Application_Start(object sender, EventArgs e)
        {
            //new RemindrServiceAppHost().Init();
            new HelloAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}