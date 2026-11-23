using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Commers.Infrastruser.Data.configration;
using Ecommers.Domain.commov.contractic;
using Commers.Infrastruser.Data.UnitOfWork;

namespace Commers.Infrastruser.infrastruservises
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("The DefaultConnection connection string is missing.");

            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
