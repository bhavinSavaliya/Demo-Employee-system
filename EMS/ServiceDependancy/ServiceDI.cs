using Common.Helper;
using DataAccessLayer.Context;
using DataAccessLayer.Implementation;
using DataAccessLayer.Infrastructure;
using Entity.DataModals;
using Microsoft.EntityFrameworkCore;
using Service.Implementation;
using Service.Infrastructure;
using Utility.Service.Implementation;
using Utility.Service.Infrastructure;

namespace EMS.ServiceDependancy
{
    public static class ServiceDI
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            var builder = new ConfigurationBuilder();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<SecureHelper>();
            services.AddScoped<IBaseRepo<Employee>, EmployeeRepo>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITokenGenerationService, TokenGenerationService>();
            services.AddScoped<ISendMailService, SendMailService>();
            return services;
        }
    }
}