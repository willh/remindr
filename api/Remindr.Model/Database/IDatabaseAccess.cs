using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remindr.Model.Database
{
    public interface IDatabaseAccess
    {
        string InsertReminder(Reminder reminder);
        void SaveReminder(Reminder reminder);
        void DeleteReminder(Reminder reminder);
        List<Reminder> GetRemindersForMobileNumber(string mobileNumber);
        List<Reminder> GetRemindersForDate(DateTime queryDate);
        Reminder GetReminderById(string id);
        void CancelReminder(string id);
        List<ReminderLog> GetHistoryForNumber(string mobileNumber);
        List<Reminder> GetPendingReminders();
        List<ReminderLog> GetAllSentReminders();
        string InsertReminderLog(ReminderLog reminderLog);

        void DeleteAllReminders();
    }
}
