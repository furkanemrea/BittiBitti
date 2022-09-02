using BittiBitti.Consumer.Handlers;
using BittiBitti.Core.Models.MessageBrokers;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReaderStrategy readerStrategy = new ReaderStrategy();
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "furkan";
            factory.Password = "furkan123";
            factory.VirtualHost = "/";
            factory.HostName = "89.252.184.189";
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;
            using (var connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    string message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    NotifyModel notifyModel = JsonConvert.DeserializeObject<NotifyModel>(message);
                    IConsumerHandler consumerHandler = readerStrategy.GetHandler(notifyModel.Type);
                    consumerHandler.Handle(message);
                };
                channel.BasicConsume(queue: "test", autoAck: true, consumer: consumer);
                Console.ReadLine();
            }



        }
    }
}
