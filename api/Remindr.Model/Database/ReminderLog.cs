﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Remindr.Model.Database
{
    public class ReminderLog
    {
        public string _id { get; set; }
        public string _originalId { get; set; }
        public string _mobileNumber { get; set; }
        public string _message { get; set; }
        public DateTime _messageDate { get; set; }
        public string _status { get; set; }
        public string _kind { get; set; }

        public ReminderLog(string originalId, string mobileNumber, string message, DateTime messageDate, string status, string kind)
        {
            _originalId = originalId;
            _mobileNumber = mobileNumber;
            _message = message;
            _messageDate = messageDate;
            _status = status;            
            _kind = kind;
        }
    }
}
