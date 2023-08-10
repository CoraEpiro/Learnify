using AppDomain.Interfaces;
using AppDomain.Services;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<LearnifyDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<ICryptService, CryptService>();

        return services;
    }
}