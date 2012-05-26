using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api
{
    public class TextMessageSendResponse
    {
        public TextMessageSendResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}