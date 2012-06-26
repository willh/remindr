using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remindr.Model.Database;

namespace Remindr.Model.Services
{
    public interface ITextService
    {
        void SendMessage(Reminder reminder);
    }
}
