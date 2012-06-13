using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Remindr.Model;
using Nancy;

namespace Remindr.Api.Modules
{
    public class HistoryModule : Nancy.NancyModule
    {
        public HistoryModule() : base("history")
        {
            Get["/"] = parameters => Response.AsJson(Reminders.GetAllSentReminders());

            Get["/{number}"] = parameters =>
            {
                string number = "+44" + parameters.number.TrimStart('0');
                return Response.AsJson(Reminders.GetHistoryForNumber(number));
            };
        }
    }
}