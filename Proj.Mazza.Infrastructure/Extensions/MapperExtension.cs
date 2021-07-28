using System;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Cyrela.Onboarding.Infrastructure.Extensions
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("Proj.Mazza.Application"));

            return services;
        }
    }
}