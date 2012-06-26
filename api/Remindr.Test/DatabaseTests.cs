// -----------------------------------------------------------------------
// TODO: Rewrite all of this to take advantage of DI
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Remindr.Model.Database;
using MongoDB.Driver.Builders;
using Remindr.Model;
using Remindr.Model.Ninject;
using System.Configuration;

namespace Remindr.Test
{
    [TestClass]
    public class DatabaseTests
    {
        static IDatabaseAccess _databaseAccess = NinjectProvider.GetInstance<IDatabaseAccess>();
        private static String _testMobileNumber = ConfigurationManager.AppSettings["TestMobileNumber"];

        [TestMethod]
        public void CanRetrieveCollectionsFromDatabase()
        {
            // This should either be moved to Mongo tests or made DB generic

            /*
            MongoCollection<Reminder> reminderCollection = _databaseAccess.GetReminderCollection();
            Assert.IsNotNull(reminderCollection);
          * */
        }

        [TestMethod]
        public void CanAddObjectToDatabase()
        {
            Reminder testReminder = new Reminder(_testMobileNumber, "test message", DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc), "daily", null, DateTime.Now.AddDays(20), "appointment");
            _databaseAccess.InsertReminder(testReminder);
            var query = Query.EQ("_mobileNumber", _testMobileNumber);
            List<Reminder> reminders = _databaseAccess.GetRemindersForMobileNumber(_testMobileNumber);
            Assert.AreEqual(1, reminders.Count());
            _databaseAccess.DeleteAllReminders();            
        }

        [TestMethod]
        public void CanDeleteObjectFromDatabase()
        {
            Reminder testReminder = new Reminder("deleteTestNumber", "test message", DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc), "daily", null, DateTime.Now.AddDays(20), "appointment");
            _databaseAccess.InsertReminder(testReminder);
            var query = Query.EQ("_mobileNumber", "deleteTestNumber");
            _databaseAccess.DeleteReminder(testReminder);
            List<Reminder> reminders = _databaseAccess.GetRemindersForMobileNumber("deleteTestNumber");
            Assert.AreEqual(0, reminders.Count());
        }

        [TestMethod]
        public void CanAddDaysToSchedule()
        {
            /*
            DateTime originalDateTime = DateTime.Now;
            Reminder testReminder = new Reminder(_testMobileNumber, "test message", originalDateTime, "daily", null, originalDateTime, "appointment");
            _databaseAccess.InsertReminder(testReminder);            
            Reminders.CalculateNextReminderDate(testReminder);
            Assert.AreEqual(originalDateTime.AddDays(1), testReminder._nextScheduledReminder);
            MongoAccess.DeleteReminderCollection();
             * */
        }

        [TestMethod]
        public void CanAddWeekToSchedule()
        {
            /*
            DateTime originalDateTime = DateTime.Now;
            Reminder testReminder = new Reminder(_testMobileNumber, "test message", originalDateTime, "weekly", null, originalDateTime, "appointment");
            testReminder.InsertToDb();
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            Reminders.CalculateNextReminderDate(testReminder);            
            Assert.AreEqual(originalDateTime.AddDays(7), testReminder._nextScheduledReminder);
            MongoAccess.DeleteReminderCollection();
             */
        }
    }
}
