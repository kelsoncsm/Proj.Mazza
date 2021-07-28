using Proj.Mazza.Domain.Aggregations.Products.Repositories;

using Cyrela.Onboarding.Infrastructure.Data.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cyrela.Onboarding.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
           


            return services;
        }
    }
}