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
            var client = new TwilioRestClient(AccountSid, AuthToken);
            var smsMessage = client.SendSmsMessage(From, reminder._mobileNumber, reminder._message);
            LogTextResponse(smsMessage, reminder);
        }

        private void LogTextResponse(SMSMessage message, Reminder reminder)
        {
            var reminderLog = new ReminderLog(reminder._id, reminder._mobileNumber, reminder._message, reminder._nextScheduledReminder, message.Status, reminder._kind);
            reminderLog.InsertToDb();
        }
    }
}
