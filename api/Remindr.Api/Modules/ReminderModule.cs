using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Remindr.Twilio;

namespace Remindr.Api.Modules
{
    public class ReminderModule : NancyModule
    {
        public ReminderModule()
        {
            TextService service = new TextService();

            Get["/message/send"] = parameters =>
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
            };
        }
    }
}