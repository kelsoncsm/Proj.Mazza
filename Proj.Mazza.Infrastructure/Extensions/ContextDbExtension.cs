using System;
using Cyrela.Onboarding.Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cyrela.Onboarding.Infrastructure.Extensions
{
    public static class ContextDbExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<OnboardingContext>(options
                => options
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}