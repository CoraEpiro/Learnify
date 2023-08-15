using Application.Mappings;
using Application.Tasks.Commands.Insert.InsertUser;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //services.AddValidatorsFromAssemblyContaining<InsertUserCommandValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(CategoryProfile));

            return services;
        }
    }
}