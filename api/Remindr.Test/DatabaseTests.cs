using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Remindr.Model.Database;
using MongoDB.Driver.Builders;
using Remindr.Model;

namespace Remindr.Test
{
    [TestClass]
    public class DatabaseTests
    {
        private static String _testMobileNumber = ConfigurationManager.AppSettings["TestMobileNumber"];

        [TestMethod]
        public void CanRetrieveCollectionsFromDatabase()
        {
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            Assert.IsNotNull(reminderCollection);
        }

        [TestMethod]
        public void CanAddObjectToDatabase()
        {
            Reminder testReminder = new Reminder(_testMobileNumber, "test message", DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc), "daily", null, DateTime.Now.AddDays(20), "appointment");
            testReminder.InsertToDb();
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            var query = Query.EQ("_mobileNumber", _testMobileNumber);
            MongoCursor<Reminder> reminderCursor = reminderCollection.Find(query);
            Assert.AreEqual(1, reminderCursor.Count());

            MongoAccess.DeleteReminderCollection();
        }

        [TestMethod]
        public void CanDeleteObjectFromDatabase()
        {
            Reminder testReminder = new Reminder("deleteTestNumber", "test message", DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc), "daily", null, DateTime.Now.AddDays(20), "appointment");
            testReminder.InsertToDb();
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            var query = Query.EQ("_mobileNumber", "deleteTestNumber");            
            testReminder.DeleteFromDb();
            MongoCursor<Reminder> reminderCursor = reminderCollection.Find(query);
            Assert.AreEqual(0, reminderCursor.Count());
        }

        [TestMethod]
        public void CanAddDaysToSchedule()
        {            
            DateTime originalDateTime = DateTime.Now;
            Reminder testReminder = new Reminder(_testMobileNumber, "test message", originalDateTime, "daily", null, originalDateTime, "appointment");
            testReminder.InsertToDb();
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            Reminders.CalculateNextReminderDate(testReminder);
            Assert.AreEqual(originalDateTime.AddDays(1), testReminder._nextScheduledReminder);
            MongoAccess.DeleteReminderCollection();
        }

        [TestMethod]
        public void CanAddWeekToSchedule()
        {
            DateTime originalDateTime = DateTime.Now;
            Reminder testReminder = new Reminder(_testMobileNumber, "test message", originalDateTime, "weekly", null, originalDateTime, "appointment");
            testReminder.InsertToDb();
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            Reminders.CalculateNextReminderDate(testReminder);            
            Assert.AreEqual(originalDateTime.AddDays(7), testReminder._nextScheduledReminder);
            MongoAccess.DeleteReminderCollection();
        }
    }
}
