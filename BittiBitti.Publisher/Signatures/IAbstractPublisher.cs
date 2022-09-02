using BittiBitti.Core.Models.MessageBrokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Publisher.Signatures
{
    public interface IAbstractPublisher
    {
        void BasicPublish<T>(T obj) where T : NotifyModel;
    }
}
