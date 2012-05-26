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
        public static List<Reminder> GetRemindersForDate(DateTime queryDate)
        {
            MongoCollection<Reminder> reminderCollection = GetCollection();
            QueryComplete mongoQuery = Query.EQ("_nextScheduledReminder", queryDate);
            MongoCursor<Reminder> mongoCursor = reminderCollection.Find(mongoQuery);
            List<Reminder> reminderReturnList = new List<Reminder>();
            foreach (Reminder reminder in mongoCursor)
            {
                reminderReturnList.Add(reminder);
            }
            return reminderReturnList;
        }

        private static MongoCollection<Reminder> GetCollection()
        {
            return MongoAccess.GetReminderCollection();
        }
    }
}
