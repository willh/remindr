
namespace Remindr.Api.Models
{

    public class Response
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class SendTextMessageRequest
    {
        public string SendTo { get; set; }
        public string TextMessage { get; set; }
    }

    public class Prescription
    {
        public string mobileNumber { get; set; }
        public string reminderDate { get; set; }
        public string message { get; set; }

    }

    public class Medication
    {
        public string mobileNumber { get; set; }
        public string reminderStartDate { get; set; }
        public string reminderEndDate { get; set; }
        public string schedule { get; set; }
        public string message { get; set; }
    }

    public class GetHistoryRequest
    {
        public string Id { get; set; }
        public string Number { get; set; }
    }

    public class Appointment
    {
        public string reminderDate { get; set; }
        public string message { get; set; }
        public string mobile { get; set; }
        public bool oneWeekNotification { get; set; }
        public bool oneDayNotification { get; set; }
    }

}
