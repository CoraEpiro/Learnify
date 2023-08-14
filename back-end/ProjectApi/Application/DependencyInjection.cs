using AppDomain.Interfaces;
using Application.Tasks.Commands.Insert.InsertUser;
using Application.Tasks.Commands.Update.UpdateUsername;
using Application.Tasks.Queries.GetPendingUserById;
using Application.Tasks.Queries.GetUser;
using Application.Tasks.Queries.GetUserByEmail;
using Application.Tasks.Queries.GetUserById;
using Application.Tasks.Queries.GetUserByUsername;
using Application.Tasks.Queries.GetUserByUsersecret;
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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining<InsertUserCommandValidator>();  - For easy testing
            services.AddValidatorsFromAssemblyContaining<UpdateUsernameCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<GetPendingUserByIdQueryValidator>();
            //services.AddValidatorsFromAssemblyContaining<GetUserQueryValidator>();  - For easy testing
            services.AddValidatorsFromAssemblyContaining<GetUserByIdQueryValidator>();
            services.AddValidatorsFromAssemblyContaining<GetUserByEmailQueryValidator>();
            services.AddValidatorsFromAssemblyContaining<GetUserByUsernameQueryValidator>();
            services.AddValidatorsFromAssemblyContaining<GetUserByUsersecretQueryValidator>();

            return services;
        }
    }
}