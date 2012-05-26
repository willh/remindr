using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace api
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RemindrService
    {
        [WebGet(UriTemplate = "/SendTextMessage/{phoneNumber}/{text}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public bool SendTextMessage(string phoneNumber, string text)
        {
            return true;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
