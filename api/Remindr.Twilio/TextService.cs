using System;
using Remindr.Model.Database;
using Twilio;

namespace Remindr.Twilio
{
    public class TextService
    {
        private const string From = "+442071838750";                                // Sandbox from number to be used with free Twilio accounts
        private const string AccountSid = "AC119c9a4d1bba461e9a1f21e39566ffd5";     // Account specific identifer
        private const string AuthToken = "5b9dc9f6743f1ff7d4018dbf501c7b5f";        // Account specific identifer
     
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
            var reminderLog = new ReminderLog(reminder._id, reminder._mobileNumber, reminder._message, reminder._nextScheduledReminder, message.Status, reminder._kind);
            reminderLog.InsertToDb();
        }
    }
}
