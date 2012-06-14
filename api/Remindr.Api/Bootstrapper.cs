using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;

namespace Remindr.Api
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoC.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            pipelines.OnError.AddItemToStartOfPipeline((ctx, exception) => {
                string body = JsonConvert.SerializeObject(new { success = false, message = exception.Message }); 
                
                ctx.Response.WithContentType("text/json");
                ctx.Response.Contents(new MemoryStream(Encoding.Default.GetBytes(body)));

                return ctx.Response;
            }); 
        }
    }
}