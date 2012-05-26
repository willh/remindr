using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Remindr.Twilio;
using ServiceStack.ServiceInterface;

namespace api
{
    public class CustomerDetailsService : RestServiceBase<TextMessageSendOrder>
    {

        public override object OnGet(TextMessageSendOrder request)
        {
            var textService = new TextService();

            try
            {
                textService.SendMessage(request.SendTo, request.Message);
            }
            catch (Exception e)
            {
                return new TextMessageSendResponse(false);
            }

            return new TextMessageSendResponse(true);
        }

    }

    //[ServiceContract(Namespace = "")]
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    //public class RemindrService
    //{
    //    [WebGet(UriTemplate = "/SendTextMessage/{sendTo}/{message}", ResponseFormat = WebMessageFormat.Json)]
    //    [OperationContract]
    //    public bool SendTextMessage(string sendTo, string message)
    //    {
    //        var textService = new TextService();

    //        try
    //        {
    //            textService.SendMessage(sendTo, message);
    //        }
    //        catch (Exception e)
    //        {
    //            return false;
    //        }

    //        return true;
    //    }

    //    // Add more operations here and mark them with [OperationContract]
    //}
}