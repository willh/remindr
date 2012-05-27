// -----------------------------------------------------------------------
// <copyright file="Reminders.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Remindr.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MongoDB.Driver;
    using Remindr.Model.Database;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Reminders
    {
        public static List<Reminder> GetRemindersForMobileNumber(string mobileNumber)
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            QueryComplete mongoQuery = Query.EQ("_mobileNumber", mobileNumber);
            MongoCursor<Reminder> mongoCursor = reminderCollection.Find(mongoQuery);
            List<Reminder> reminderReturnList = new List<Reminder>();
            foreach (Reminder reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);                
            }

            return reminderReturnList;
        }


        public static List<Reminder> GetRemindersForDate(DateTime queryDate)
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
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

        public static Reminder GetReminderById(string id)
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            QueryComplete mongoQuery = Query.EQ("_id", id);
            return reminderCollection.FindOne(mongoQuery);            
        }

        public static void CancelReminder(string id)
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            QueryComplete mongoQuery = Query.EQ("_id", id);
            reminderCollection.FindOne(mongoQuery).DeleteFromDb();
        }

        public static void CalculateNextReminderDate(Reminder reminder)
        {
            if (reminder._schedule.Equals("daily"))
            {
                reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(1);
            }
            else if (reminder._schedule.Equals("weekly"))
            {
                reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(7);
            }
            else if (reminder._schedule.Equals("custom"))
            {
                reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(1);
                while (reminder._schedule.IndexOf(reminder._nextScheduledReminder.DayOfWeek.ToString()) == -1)
                {
                    reminder._nextScheduledReminder = reminder._nextScheduledReminder.AddDays(1);
                }
            }

            if (reminder._schedule == null || reminder._endReminderDate == null || reminder._nextScheduledReminder > reminder._endReminderDate)
            {
                reminder.DeleteFromDb();
            }
            else
            {
                reminder.SaveToDb();
            }
        }

        private static MongoCollection<Reminder> GetCollection()
        {
            return MongoAccess.GetReminderCollection();
        }

        private static MongoCollection<ReminderLog> GetLogCollection()
        {
            return MongoAccess.GetReminderLogCollection();
        }

        public static List<ReminderLog> GetHistoryForNumber(string mobileNumber)
        {
            MongoCollection<ReminderLog> reminderLogCollection = GetLogCollection();
            QueryComplete mongoQuery = Query.EQ("_mobileNumber", mobileNumber);
            MongoCursor<ReminderLog> mongoCursor = reminderLogCollection.Find(mongoQuery);
            List<ReminderLog> reminderReturnList = new List<ReminderLog>();
            foreach (ReminderLog reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);                
            }

            return reminderReturnList;
        }

        public static List<Reminder> GetPendingReminders()
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            MongoCursor<Reminder> mongoCursor = reminderCollection.FindAll();
            List<Reminder> reminderReturnList = new List<Reminder>();
            foreach (Reminder reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);
            }

            return reminderReturnList;
        }

        public static List<ReminderLog> GetAllSentReminders()
        {
            MongoCollection<ReminderLog> reminderLogCollection = GetLogCollection();
            MongoCursor<ReminderLog> mongoCursor = reminderLogCollection.FindAll();
            List<ReminderLog> reminderLogReturnList = new List<ReminderLog>();
            foreach (ReminderLog reminderLog in mongoCursor)
            {
                reminderLogReturnList.Add(reminderLog);
            }

            return reminderLogReturnList;
        }
    }
}
