using BittiBitti.Publisher.RabbitMq.Services;
using BittiBitti.Publisher.Signatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Publisher
{
    public static class PublisherServiceRegistration
    {
        public static IServiceCollection AddPublisherServices(this IServiceCollection services)
        {
            services.AddTransient<IAbstractPublisher, RabbitMqService>();
            return services;
        }
    }
}
