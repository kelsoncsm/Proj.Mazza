using Proj.Mazza.Domain.Aggregations.Products.Repositories;

using Cyrela.Onboarding.Infrastructure.Data.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Proj.Mazza.Domain.Aggregations.Users.Repositories;
using Proj.Mazza.Application.Contracts;
using Proj.Mazza.Application.QueryHandlers;

namespace Cyrela.Onboarding.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IProductQueryHandler, ProductQueryHandler>();


            return services;
        }
    }
}