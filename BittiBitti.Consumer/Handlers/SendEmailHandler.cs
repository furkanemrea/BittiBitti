using BittiBitti.Application.Features.Users.Commands.RegisterUserCommand;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Consumer.Handlers
{
    public class SendEmailHandler : IConsumerHandler
    {
        public void Handle(string notifyModelContent)
        {


            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("kod.yazilimm@gmail.com");
            message.To.Add(new MailAddress("furkanemrealtintas@gmail.com"));
            message.Subject = "Test";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "<h1>Merhaba</h1>";
            smtp.Port = 587;
            smtp.Host = "smtp.google.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("kod.yazilimm@gmail.com", "159357FEA"); // will get from Appsetting.json by type
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send("kod.yazilimm@gmail.com", "furkanemrealtintas@gmail.com", "Hello world", "testbody");

                //cki.Send(message);
            }
            catch (SmtpException ex)
                {

            }
        }
    }
}
