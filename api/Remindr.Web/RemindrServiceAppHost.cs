using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace api
{
    public class RemindrServiceAppHost : AppHostBase
    {
        public RemindrServiceAppHost() : base("Remindr Services", typeof(RemindrService).Assembly)
        {

        }

        public override void Configure(Container container)
        {
            
        }
    }
}