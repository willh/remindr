using System.IO;
using System.Net;
using Remindr.Mvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Remindr.Mvc.Models;
using System.Web.Mvc;

namespace Remindr.Test
{
    
    
    [TestClass()]
    public class RemindrControllerTest
    {

        private TestContext _testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\NHSHackDay\\nhshackday\\api\\Remindr.Mvc", "/")]
        //[UrlToTest("http://localhost:55849/")]
        public void SendTextMessageTest()
        {
            var target = new RemindrController();
            var request = new SendTextMessageRequest
                                                 {
                                                     SendTo = "+447590488120",
                                                     TextMessage = "integration test"
                                                 };

            var actual = target.SendTextMessage(request);

            const bool expected = true;
            Assert.AreEqual(expected, ((Response)actual.Data).Success);
        }
    }
}
