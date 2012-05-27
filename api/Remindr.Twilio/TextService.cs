using System;
using Twilio;

namespace Remindr.Twilio
{
    public class TextService
    {
        private const string From = "+442071838750";                                // Sandbox from number to be used with free Twilio accounts
        private const string AccountSid = "AC119c9a4d1bba461e9a1f21e39566ffd5";     // Account specific identifer
        private const string AuthToken = "5b9dc9f6743f1ff7d4018dbf501c7b5f";        // Account specific identifer
     
        public void SendMessage(string sendTo, string message)
        {
            var client = new TwilioRestClient(AccountSid, AuthToken);
            client.SendSmsMessage(From, sendTo, message, LogTextResponse);
        }

        private void LogTextResponse(SMSMessage message)
        {
            Console.WriteLine("Message - Number {0} and Status {1}", message.To, message.Status);
        }
    }
}
