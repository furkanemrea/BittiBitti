using BittiBitti.Core.Models.MessageBrokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Commands.RegisterUserCommand
{
    public class RegisterUserNotifyModel: NotifyModel
    {
        public RegisterUserNotifyModel(string type, string routingKey) : base(type, routingKey)
        {
        }

        public string Subject { get; set; }
        public string MailTo { get; set; }
        public string MailBody { get; set; }
    }
}
