using BittiBitti.Application.Services.Repositories;
using BittiBitti.Persistence.Contexts;
using BittiBitti.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BittiBitti.Persistence.Configuration;

namespace BittiBitti.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<PostgreDbContext>(options => options.UseNpgsql("postgres://bittibitti:159357@89.252.184.189:5432/BittiBitti"));
            services.AddScoped<PostgreDbContext>(provider => provider.GetService<PostgreDbContext>());
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
