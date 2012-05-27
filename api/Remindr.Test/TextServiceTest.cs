using System.Threading;
using Remindr.Twilio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Remindr.Test
{
    [TestClass]
    public class TextServiceTest
    {
        [TestMethod]
        public void simple_message_succeeds()
        {
            var target = new TextService();

            var sendTo = "+447590488120";
            var message = "Test text";

            target.SendMessage(sendTo, message);
        }

        [TestMethod]
        public void send_multiple_messages_successfully()
        {
            var textService = new TextService();

            var patients = new[]
                               {
                                   new {Name = "Ruairi", MobileNumber = "+447590488120", Message = "Keep taking ur winning tablets" },
                                   new {Name = "Kyle", MobileNumber = "+447812496877", Message = "Don't forget the methadone today Kyle!!" }
                               };

            foreach (var reminder in patients)
            {
                textService.SendMessage(reminder.MobileNumber, reminder.Message);
            }       

            Thread.Sleep(10000);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "String is longer than max allowed size (160).")]
        public void message_longer_than_160_chars_fails()
        {
            var target = new TextService();

            var sendTo = "+447590488120";
            var message = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            target.SendMessage(sendTo, message);
        }
    }
}
