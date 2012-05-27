using System;
using Remindr.Twilio;
using ServiceStack.ServiceInterface;

namespace api
{
    public class RemindrService : RestServiceBase<TextMessageSendOrder>
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
}