using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ProyectoPrograWebHHK.Models
{
    public static class Email
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Desechar (Dispose) objetos antes de perder el ámbito", Justification = "<pendiente>")]
        public static bool SendEmail(string to, string body, string subject)
        {
            var email = new MailMessage
            {
                From = new MailAddress("acontrerasc96@hotmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                Priority = MailPriority.Normal,
            };
            email.To.Add(new MailAddress(to));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "example.com";
            smtp.Port = 2525;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("acontrerasc96@hotmail.com", "kakaroto1!");
            try
            {
                smtp.Send(email);
                email.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}