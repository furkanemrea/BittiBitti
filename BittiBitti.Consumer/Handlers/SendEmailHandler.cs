using BittiBitti.Application.Features.Users.Commands.RegisterUserCommand;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Consumer.Handlers
{
    public class SendEmailHandler : IConsumerHandler
    {
        public void Handle(string message)
        {
            RegisterUserNotifyModel notifyModel = JsonConvert.DeserializeObject<RegisterUserNotifyModel>(message);

            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("furkanemrealtintas@gmail.com"); // will get from Appsetting.json by type
            mesaj.To.Add(notifyModel.MailTo);
            mesaj.Subject = notifyModel.Subject;
            mesaj.Body = notifyModel.MailBody;

            SmtpClient a = new SmtpClient();
            a.Credentials = new System.Net.NetworkCredential("furkanemrealtintas@gmail.com", "pass"); // will get from Appsetting.json by type
            a.Port = 587;
            a.Host = "furkanemrealtintas@gmail.com"; // will get from Appsetting.json by type
            a.EnableSsl = true;
            object userState = message;
            try
            {
                a.SendAsync(mesaj, (object)message);
            }

            catch (SmtpException ex)
            {

            }
        }
    }
}
