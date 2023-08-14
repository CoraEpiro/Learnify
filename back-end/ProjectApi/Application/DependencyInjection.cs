using AppDomain.Interfaces;
using Application.Mappings;
using Application.Tasks.Commands.Insert.InsertUser;
using Application.Tasks.Commands.Update.UpdateUser.UpdateUsername;
using Application.Tasks.Queries;
using Application.Tasks.Queries.UserQueries.GetPendingUserById;
using Application.Tasks.Queries.UserQueries.GetUserByEmail;
using Application.Tasks.Queries.UserQueries.GetUserById;
using Application.Tasks.Queries.UserQueries.GetUserByUsername;
using Application.Tasks.Queries.UserQueries.GetUserByUsersecret;
using FluentValidation;
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
            services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssemblyContaining<InsertUserCommandValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(CategoryProfile));

            return services;
        }

        
    }
}