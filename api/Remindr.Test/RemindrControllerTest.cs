using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Remindr.Mvc.Controllers;
using Remindr.Mvc.Models;

namespace Remindr.Test
{
    
    [TestClass()]
    public class RemindrControllerTest
    {
        private TestContext _testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        [TestMethod()]
        public void SendTextMessageTest()
        {
            var target = new RemindrController();
            var request = new SendTextMessageRequest
                                                 {
                                                     SendTo = ConfigurationManager.AppSettings["TestMobileNumber"],
                                                     TextMessage = "integration test"
                                                 };

            var actual = target.SendTextMessage(request);

            const bool expected = true;
            Assert.AreEqual(expected, ((Response)actual.Data).Success);
        }
    }
}
