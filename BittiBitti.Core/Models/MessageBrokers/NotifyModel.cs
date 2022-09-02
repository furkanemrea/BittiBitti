using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Core.Models.MessageBrokers
{
    public  class NotifyModel
    {
        public string Type { get; set; }
        public string RoutingKey { get; set; }
        public NotifyModel(string type,string routingKey)
        {
            this.Type= type;
            this.RoutingKey = routingKey;
        }

    }
}
