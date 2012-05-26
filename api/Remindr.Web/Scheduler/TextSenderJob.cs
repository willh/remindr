using Quartz;
using Remindr.Twilio;

namespace api.Scheduler
{
    public class TextSenderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var patients = new[]
                               {
                                   new {Name = "Ruairi", MobileNumber = "+447590488120", Message = "Keep taking ur winning tablets" },
                                   new {Name = "Kyle", MobileNumber = "+447812496877", Message = "Don't forget the methadone today Kyle!!" }
                               };

            var textService = new TextService();

            foreach (var patient in patients)
            {
                textService.SendMessage(patient.MobileNumber, patient.Message);
            }            
        }
    }
}

