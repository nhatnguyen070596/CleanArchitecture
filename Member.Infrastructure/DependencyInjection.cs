using System.ComponentModel.DataAnnotations;
using Member.Application_.Reponsitories.Interface;
using Member.Application_.Services.Interface;
using Member.Infrastructure.Persistence.Contexts;
using Member.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Member.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreContext>(options =>
               options.UseSqlServer(defaultConnectionString));
            services.AddAuthorization();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // default lockout setting
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                // setting signin
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredLength = 7;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedAccount = true;
                // Vô hiệu hóa yêu cầu xác thực hai yếu tố
                options.Tokens.AuthenticatorIssuer = null;
            });
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

