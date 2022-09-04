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
using BittiBitti.Core.Persistence.Repositories;

namespace BittiBitti.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<PostgreDbContext>(options =>
                                                      options.UseNpgsql("Server=89.252.184.189;Port=5432;Database=BittiBitti;User Id=bittibitti;Password=159357;"));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            return services;
        }
    }
}
