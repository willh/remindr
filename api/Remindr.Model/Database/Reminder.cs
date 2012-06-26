using System;

namespace Remindr.Model.Database
{
    public class Reminder
    {        
        public int _id { get; set; }
        public string _mobileNumber { get; set; }
        public string _message { get; set; }
        public DateTime _nextScheduledReminder { get; set; }
        public string _schedule { get; set; }
        public string[] _customSchedule { get; set; }
        public DateTime _endReminderDate { get; set; }
        public string _kind { get; set; }
        
        public Reminder(string mobileNumber, string message, DateTime nextScheduledReminder, string schedule,
                             string[] customSchedule, DateTime endReminderDate, string kind)
        {            
            _mobileNumber = mobileNumber;
            _message = message;
            _nextScheduledReminder = nextScheduledReminder;
            _schedule = schedule;
            _customSchedule = customSchedule;
            _endReminderDate = endReminderDate;
            _kind = kind;
        }

        public Reminder()
        {            
        }
    }
}
