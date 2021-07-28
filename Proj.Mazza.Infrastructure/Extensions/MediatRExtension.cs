using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cyrela.Onboarding.Infrastructure.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
      
            services.AddMediatR(AppDomain.CurrentDomain.Load("Proj.Mazza.Application"));

            return services;
        }
    }
}