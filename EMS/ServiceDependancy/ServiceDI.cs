using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

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
            return services;
        }
    }
}