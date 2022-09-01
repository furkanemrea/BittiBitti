using BittiBitti.Publisher.Signatures;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Publisher.RabbitMq.Services
{
    public class RabbitMqService : IAbstractPublisher
    {
        public async Task BasicPublish<T>(T obj, string routingKey)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName="localhost", UserName="furkan", Password="furkan123" };
            using (var connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: routingKey,
                    durable: false, // data storage type
                    exclusive: false, // are other connections can connect the queue 
                    autoDelete: false,
                    arguments: null // exchange parameters 
                );
                string stringfyObject = JsonConvert.SerializeObject(obj);
                var body = Encoding.UTF8.GetBytes(stringfyObject);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: routingKey,
                    body: body
                );
            }
        }
    }
}
