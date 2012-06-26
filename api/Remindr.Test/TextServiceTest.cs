using System;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Remindr.Model.Database;
using Remindr.Twilio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Configuration;


// TODO : Redo all of this with DI and anon
namespace Remindr.Test
{
    [TestClass]
    public class TextServiceTest
    {
        private string testNumberOne = ConfigurationManager.AppSettings["TestMobileNumber"];
        private string testNumberTwo = ConfigurationManager.AppSettings["AltTestMobileNumber"];

        /*
        [TestMethod]
        public void simple_message_sends_and_reminder_logged()
        {
            var target = new TextService();

            var reminder = new Reminder(testNumberOne, "Simple Message Test", DateTime.Now, "daily", null,
                                        DateTime.Now.AddDays(1), "appointment");

            var splits = Guid.NewGuid().ToString().Split('-');
            reminder._id = new ObjectId(string.Join("", splits).Substring(0, 24)); 

            target.SendMessage(reminder);
            var cursor = MongoAccess.GetReminderLogCollection().Find(Query.EQ("_originalId", reminder._id));
            Assert.AreEqual(1, cursor.Count());
        }

        [TestMethod]
        public void send_multiple_messages_successfully()
        {
            var textService = new TextService();

            var testerOneReminder = new Reminder(testNumberOne, "testerOne Multiple Message Test", DateTime.Now, "daily", null,
                                        DateTime.Now.AddDays(1), "appointment");

            var testerTwoReminder = new Reminder(testNumberTwo, "testerTwo Multiple Message Test", DateTime.Now, "daily", null,
                                        DateTime.Now.AddDays(1), "appointment");

            var patients = new[] {testerOneReminder, testerTwoReminder};

            foreach (var reminder in patients)
            {
                textService.SendMessage(reminder);
            }       
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "String is longer than max allowed size (160).")]
        public void message_longer_than_160_chars_fails()
        {
            var target = new TextService();

            var longMessage = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

             var testerOneReminder = new Reminder(testNumberOne, longMessage, DateTime.Now, "daily", null,
                                        DateTime.Now.AddDays(1), "appointment");

            target.SendMessage(testerOneReminder);
        }
         * */
    }
}
