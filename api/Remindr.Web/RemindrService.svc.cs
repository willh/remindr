using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Remindr.Twilio;

namespace api
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RemindrService
    {
        [WebGet(UriTemplate = "/SendTextMessage/{sendTo}/{message}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public bool SendTextMessage(string sendTo, string message)
        {
            var textService = new TextService();

            try
            {
                textService.SendMessage(sendTo, message);    
            } 
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
