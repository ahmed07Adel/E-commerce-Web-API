using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
   public interface IEmailService
    {
        public bool SendEmail(string to, string subject, string body, bool isHtml, string displayNameFrom);

    }
}
