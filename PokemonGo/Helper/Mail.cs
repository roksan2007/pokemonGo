using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace PokemonGo.Helper
{
    public static class Mail
    {
        public static void Send(string email, string subject, string mailBody)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("pokemongoapptest2016@gmail.com");
            mail.To.Add(new MailAddress(email));
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = mailBody;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("pokemongoapptest2016@gmail.com", "roksan158902");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                //client.Send(mail);
                Thread T1 = new Thread(delegate () { client.Send(mail); });
                T1.Start();
            }
            catch
            { }
        }
    }
}