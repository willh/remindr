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
        public ObjectId _id { get; set; }
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

        private MongoCollection<Reminder> GetCollection()
        {
            return MongoAccess.GetReminderCollection();
        }

        public string InsertToDb()
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            reminderCollection.Insert(this);
            return _id.ToString();
        }

        public void SaveToDb()
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            reminderCollection.Save(this);
        }

        public void DeleteFromDb()
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            var query = Query.EQ("_id", _id);
            reminderCollection.Remove(query);
        }
    }


}
