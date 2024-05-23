﻿using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Notes.Application
{
    public static class DependencyIjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
