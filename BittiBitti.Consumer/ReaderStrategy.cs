using BittiBitti.Consumer.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Consumer
{
    public class ReaderStrategy
    {
        public static Dictionary<string, IConsumerHandler> readerStrategies = new();
        public IConsumerHandler GetHandler(string type)
        {
            if(readerStrategies.Keys.Count == 0)
            {
                readerStrategies.Add("email",new SendEmailHandler());
            }
            return readerStrategies[type];
        }
    }
}
