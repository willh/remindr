// -----------------------------------------------------------------------
// <copyright file="Reminder.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Remindr.Model.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Reminder
    {
        private ObjectId _Id;
        private string _mobileNumber;
        private string _message;
        DateTime _nextScheduledReminder;
        string _schedule;
        string[] _customSchedule;
        DateTime _endReminderDate;
        
        public Reminder(string mobileNumber, string message, DateTime nextScheduledReminder, string schedule,
                             string[] customSchedule, DateTime endReminderDate)
        {            
            _mobileNumber = mobileNumber;
            _message = message;
            _nextScheduledReminder = nextScheduledReminder;
            _schedule = schedule;
            _customSchedule = customSchedule;
            _endReminderDate = endReminderDate;
        }

        private MongoCollection<Reminder> GetCollection()
        {
            return MongoAccess.GetReminderCollection();
        }

        public void SaveToDb()
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            reminderCollection.Save(this);
        }
    }


}
