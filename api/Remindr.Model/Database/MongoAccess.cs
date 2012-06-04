using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Remindr.Model.Database
{

    public static class MongoAccess
    {            
        private static String _connectionString = ConfigurationManager.AppSettings["MONGOHQ_URL"];
        private static MongoServer _mongoServer = MongoServer.Create(_connectionString);
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
