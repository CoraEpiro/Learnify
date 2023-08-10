using AppDomain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
