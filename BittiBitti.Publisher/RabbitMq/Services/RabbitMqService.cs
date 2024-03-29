﻿using BittiBitti.Core.Models.MessageBrokers;
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
        public void BasicPublish<T>(T obj) where T : NotifyModel
        {

            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "furkan";
            factory.Password = "furkan123";
            factory.VirtualHost = "/";
            factory.HostName = "89.252.184.189";
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;
            var notifyModel = obj as NotifyModel;
            using (var connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: notifyModel.RoutingKey,
                    durable: false, // data storage type
                    exclusive: false, // are other connections can connect the queue 
                    autoDelete: false,
                    arguments: null // exchange parameters 
                );
                string stringfyObject = JsonConvert.SerializeObject(obj);
                var body = Encoding.UTF8.GetBytes(stringfyObject);

                channel.BasicPublish(
                    exchange: "",
                                routingKey: notifyModel.RoutingKey,
                                body: body
                            );
            }
        }
    }
}
