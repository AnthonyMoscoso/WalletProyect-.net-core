using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.Email
{
    public interface IEmailManager
    {
        void SendEmailTo(string emailFrom,string emailTo,string header,string content,string smpt);
    }
}
