using Microsoft.Extensions.DependencyInjection;
using Ecommers.Apliction.Iservises.product;
using Ecommers.Apliction.servisses.product;

namespace Ecommers.Apliction
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddAplicationServises(this IServiceCollection services)
        {
            services.AddAutoMapper(_ => { }, typeof(ServicesRegistration).Assembly);
            services.AddScoped<IProductserves, ProductServices>();
            return services;
        }
    }
}
