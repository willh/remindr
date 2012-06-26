using System;
using System.Configuration;
using Remindr.Model.Database;
using Remindr.Model.Services;
using Twilio;

namespace Remindr.Twilio
{
    public class TextService : ITextService
    {
        private string From = ConfigurationManager.AppSettings["TwilioFromNumber"];
        private string AccountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
        private string AuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
     
        public void SendMessage(Reminder reminder)
        {
            reminder._mobileNumber = FormatNumber(reminder._mobileNumber);
            var client = new TwilioRestClient(AccountSid, AuthToken);
            var smsMessage = client.SendSmsMessage(From, reminder._mobileNumber, reminder._message);
            LogTextResponse(smsMessage, reminder);
        }

        public string FormatNumber(string mobileNumber)
        {
            if (mobileNumber.StartsWith("0"))
            {
                mobileNumber = mobileNumber.Substring(1, mobileNumber.Length - 1);
                mobileNumber = "+44" + mobileNumber;
            }
            else if (!mobileNumber.StartsWith("+"))
            {
                mobileNumber = "+" + mobileNumber;
            }
            return mobileNumber;
        }

        // For testing the api, don't need to create a ReminderLog
        public void SendMessage(string numberTo, string message)
        {
            numberTo = FormatNumber(numberTo);
            var client = new TwilioRestClient(AccountSid, AuthToken);
            client.SendSmsMessage(From, numberTo, message);            
        }

        private void LogTextResponse(SMSMessage message, Reminder reminder)
        {
            var reminderLog = new ReminderLog(reminder._id.ToString(), reminder._mobileNumber, reminder._message, reminder._nextScheduledReminder, message.Status, reminder._kind);            
        }
    }
}
