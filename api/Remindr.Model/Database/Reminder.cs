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
        // accessor
        private ObjectId _Id;
        private string _mobileNumber;
        private string _message;
        public DateTime _nextScheduledReminder { get; set; }
        public string _schedule { get; set; }
        public string[] _customSchedule { get; set; }
        public DateTime _endReminderDate { get; set; }
        
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

        public void DeleteFromDb()
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            var query = Query.EQ("_Id", _Id);
            reminderCollection.Remove(query);
        }
    }


}
