using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Publisher.Signatures
{
    public interface IAbstractPublisher
    {
        Task BasicPublish<T>(T obj, string routingKey);
    }
}
