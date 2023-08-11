using AppDomain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using AppDomain.Common.Config;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<LearnifyDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        var bcryptConfig = new BCryptConfig();
        configuration.GetSection("BCrypt").Bind(bcryptConfig);
        services.AddSingleton(bcryptConfig);
        services.AddSingleton<ICryptService,CryptService>();
        services.AddScoped<IUserRepository,UserRepository>();

        return services;
    }
}