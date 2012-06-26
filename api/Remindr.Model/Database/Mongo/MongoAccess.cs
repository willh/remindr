using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System;
using System.Configuration;

namespace Remindr.Model.Database
{
    public class MongoAccess : IDatabaseAccess
    {            
        private static String _connectionString = ConfigurationManager.AppSettings["MONGOHQ_URL"];
        private static MongoServer _mongoServer = MongoServer.Create(_connectionString);

        private static MongoDatabase _mongoDatabase = _mongoServer.GetDatabase("Remindr");

        public MongoCollection<Reminder> GetReminderCollection()
        {
            return _mongoDatabase.GetCollection<Reminder>("Reminder");            
        }

        public void DeleteAllReminders()
        {
            _mongoDatabase.DropCollection("Reminder");
        }

        public MongoCollection<ReminderLog> GetReminderLogCollection()
        {
            return _mongoDatabase.GetCollection<ReminderLog>("ReminderLog");
        }

        public string InsertReminder(Reminder reminder)
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            reminderCollection.Insert(reminder);
            return reminder._id.ToString();
        }

        public void SaveReminder(Reminder reminder)
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            reminderCollection.Save(reminder);
        }

        public void DeleteReminder(Reminder reminder)
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            var query = Query.EQ("_id", reminder._id);
            reminderCollection.Remove(query);
        }

        public List<Reminder> GetRemindersForMobileNumber(string mobileNumber)
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            QueryComplete mongoQuery = Query.EQ("_mobileNumber", mobileNumber);
            MongoCursor<Reminder> mongoCursor = reminderCollection.Find(mongoQuery);
            List<Reminder> reminderReturnList = new List<Reminder>();
            foreach (Reminder reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);
            }

            return reminderReturnList;
        }

        public List<Reminder> GetRemindersForDate(DateTime queryDate)
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            QueryComplete mongoQuery = Query.EQ("_nextScheduledReminder", queryDate);
            MongoCursor<Reminder> mongoCursor = reminderCollection.Find(mongoQuery);
            List<Reminder> reminderReturnList = new List<Reminder>();
            foreach (Reminder reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);
                CalculateNextReminderDate(reminder);
            }

            return reminderReturnList;
        }

        public void CalculateNextReminderDate(Reminder reminder)
        {
            if (reminder._schedule != null)
            {
                if (reminder._schedule.ToLower().Equals("daily"))
                {
                    reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(1);
                }
                else if (reminder._schedule.ToLower().Equals("weekly"))
                {
                    reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(7);
                }
                else if (reminder._schedule.ToLower().Equals("custom"))
                {
                    reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(1);
                    while (reminder._schedule.IndexOf(reminder._nextScheduledReminder.DayOfWeek.ToString()) == -1)
                    {
                        reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(1);
                    }
                }
            }

            if (reminder._schedule == null || reminder._endReminderDate == null || reminder._nextScheduledReminder > reminder._endReminderDate)
            {
                DeleteReminder(reminder);                
            }
            else
            {
                SaveReminder(reminder);                
            }
        }

        public Reminder GetReminderById(string id)
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            QueryComplete mongoQuery = Query.EQ("_id", id);
            return reminderCollection.FindOne(mongoQuery);
        }

        public void CancelReminder(string id)
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            QueryComplete mongoQuery = Query.EQ("_id", id);
            DeleteReminder(reminderCollection.FindOne(mongoQuery));            
        }

        public List<ReminderLog> GetHistoryForNumber(string mobileNumber)
        {
            MongoCollection<ReminderLog> reminderLogCollection = GetReminderLogCollection();
            QueryComplete mongoQuery = Query.EQ("_mobileNumber", mobileNumber);
            MongoCursor<ReminderLog> mongoCursor = reminderLogCollection.Find(mongoQuery);
            List<ReminderLog> reminderReturnList = new List<ReminderLog>();
            foreach (ReminderLog reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);
            }

            return reminderReturnList;
        }

        public List<Reminder> GetPendingReminders()
        {
            MongoCollection<Reminder> reminderCollection = GetReminderCollection();
            MongoCursor<Reminder> mongoCursor = reminderCollection.FindAll();
            List<Reminder> reminderReturnList = new List<Reminder>();
            foreach (Reminder reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);
            }

            return reminderReturnList;
        }

        public List<ReminderLog> GetAllSentReminders()
        {
            MongoCollection<ReminderLog> reminderLogCollection = GetReminderLogCollection();
            MongoCursor<ReminderLog> mongoCursor = reminderLogCollection.FindAll();
            List<ReminderLog> reminderLogReturnList = new List<ReminderLog>();
            foreach (ReminderLog reminderLog in mongoCursor)
            {
                reminderLogReturnList.Add(reminderLog);
            }

            return reminderLogReturnList;
        }

        public string InsertReminderLog(ReminderLog reminderLog)
        {
            MongoCollection<ReminderLog> reminderLogCollection = GetReminderLogCollection();
            reminderLogCollection.Insert(reminderLog);
            return reminderLog._id.ToString();
        }
    }    
}
