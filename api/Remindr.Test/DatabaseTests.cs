// -----------------------------------------------------------------------
// <copyright file="DatabaseTests.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Remindr.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MongoDB.Driver;
    using Remindr.Model.Database;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanRetrieveCollectionsFromDatabase()
        {
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            Assert.IsNotNull(reminderCollection);
        }

        [TestMethod]
        public void CanAddObjectToDatabase()
        {
            Reminder testReminder = new Reminder("07812496877", "test message", DateTime.Now, "daily", null, DateTime.Now);
            testReminder.InsertToDb();
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            var query = Query.EQ("_mobileNumber", "07812496877");
            MongoCursor<Reminder> reminderCursor = reminderCollection.Find(query);
            Assert.AreEqual(1, reminderCursor.Count());

            testReminder.DeleteFromDb();
        }

        [TestMethod]
        public void CanDeleteObjectFromDatabase()
        {
            Reminder testReminder = new Reminder("deleteTestNumber", "test message", DateTime.Now, "daily", null, DateTime.Now);
            testReminder.InsertToDb();
            MongoCollection<Reminder> reminderCollection = MongoAccess.GetReminderCollection();
            var query = Query.EQ("_mobileNumber", "deleteTestNumber");            
            testReminder.DeleteFromDb();
            MongoCursor<Reminder> reminderCursor = reminderCollection.Find(query);
            Assert.AreEqual(0, reminderCursor.Count());
        }
    }
}
