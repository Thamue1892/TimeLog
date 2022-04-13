using System;
using ServiceFramework.Interface;

namespace ServiceFramework
{
    public class SendMail : IEmail
    {
        public void SendEmail(string sender, string recipient, string mailServer, string subject, string body)
        {
            System.Net.Mail.SmtpClient SmtpMail = null;
            System.Net.Mail.MailMessage myMail = null;
            try
            {
                SmtpMail = new System.Net.Mail.SmtpClient(mailServer);
                myMail = new System.Net.Mail.MailMessage(sender, recipient)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body
                };
                SmtpMail.Send(myMail);
            }
            catch (Exception ex)
            {
                if (myMail != null) myMail.Dispose();
                if (SmtpMail != null) SmtpMail.Dispose();
                Error.LogFileLogger.Error(ex.Message);
                Error.DbLoggerError("WARNING - SendMail :", ex);
            }
        }
    }
}