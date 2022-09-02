using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Consumer.Handlers
{
    public interface IConsumerHandler
    {
        public void Handle(string message);
    }
}
