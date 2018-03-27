using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace BookingSystemApi.Helper
{
    public static class EmailHelper
    {

        public static bool SendMail(string to, string messageBody, string subject)
        {
            bool isResult = false;
            try
            {
                MailMessage mail = new MailMessage("ershailendra57@gmail.com", to);
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("ershailendra57@gmail.com", "9891313017");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                // client.DeliveryMethod = SmtpDeliveryMethod.Network;
                // client.UseDefaultCredentials = false;
                
                mail.Subject = subject;
                mail.Body = messageBody;
                client.Send(mail);
                isResult = true;
            }
            catch (System.Exception ex)
            {
                //write exception log
                Console.WriteLine("error while sending the mail="+ex);
            }
            return isResult;
        }
    }
}
