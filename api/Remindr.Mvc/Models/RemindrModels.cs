using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Remindr.Mvc.Models
{

    public class Response
    {
        public bool Success { get; set; }
    }

    public class SendTextMessageRequest
    {
        public string SendTo { get; set; }
        public string TextMessage { get; set; }
    }

}
