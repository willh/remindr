// -----------------------------------------------------------------------
// <copyright file="MongoAccess.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Remindr.Model.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    using MongoDB.Driver;
    using MongoDB.Bson;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class MongoAccess
    {            
        // TODO : Move connection details to config        
        private static MongoServer _mongoServer = MongoServer.Create(@"mongodb://RemindrUser:1Password2@staff.mongohq.com:10001/");
        private static MongoDatabase _mongoDatabase = _mongoServer.GetDatabase("Remindr");

        public static MongoCollection<Reminder> GetReminderCollection()
        {
            return _mongoDatabase.GetCollection<Reminder>("Reminder");            
        }

        public static void DeleteReminderCollection()
        {
            _mongoDatabase.DropCollection("Reminder");
        }

        public static MongoCollection<ReminderLog> GetReminderLogCollection()
        {
            return _mongoDatabase.GetCollection<ReminderLog>("ReminderLog");
        }
    }    
}
