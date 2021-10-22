using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string to, string subject, string body, bool isHtml, string displayNameFrom)
        {

            try
            {

                var mySmtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true
                };

                var basicAuthenticationInfo = new
                    System.Net.NetworkCredential("ahmedahemd123adel.007@gmail.com", "Ahmed.007.adel@");
                mySmtpClient.Credentials = basicAuthenticationInfo;
                //ahmedahemd123adel.007@gmail.com

                var fromEmail = new MailAddress("ahmedahemd123adel.007@gmail.com", displayNameFrom);
                var toEmail = new MailAddress(to);
                var myMail = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    SubjectEncoding = System.Text.Encoding.UTF8,
                    Body = body,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    IsBodyHtml = isHtml
                };

                mySmtpClient.Send(myMail);
            }
            catch (SmtpException exception)
            {
                return false;
            }
            return true;
        }

        //public bool SendEmail(string to, string subject, string body, bool isHtml, string displayNameFrom)
        //{

        //    try
        //    {

        //        var mySmtpClient = new SmtpClient("smtp.gmail.com")
        //        {
        //            Port = 587,
        //            UseDefaultCredentials = false,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            EnableSsl = true
        //        };

        //        var basicAuthenticationInfo = new
        //            System.Net.NetworkCredential("ahmedahemd123adel.007@gmail.com", "Ahmed.007.adel@");
        //        mySmtpClient.Credentials = basicAuthenticationInfo;


        //        var fromEmail = new MailAddress("ahmedahemd123adel.007@gmail.com", displayNameFrom);
        //        var toEmail = new MailAddress(to);
        //        var myMail = new MailMessage(fromEmail, toEmail)
        //        {
        //            Subject = subject,
        //            SubjectEncoding = System.Text.Encoding.UTF8,
        //            Body = body,
        //            BodyEncoding = System.Text.Encoding.UTF8,
        //            IsBodyHtml = isHtml
        //        };

        //        mySmtpClient.Send(myMail);
        //    }
        //    catch (SmtpException exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
