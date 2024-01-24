using Member.Application_.Services.Interface;
using Member.Infrastructure.Persistence.Contexts;
using Member.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Member.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreContext>(options =>
               options.UseSqlServer(defaultConnectionString));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}

