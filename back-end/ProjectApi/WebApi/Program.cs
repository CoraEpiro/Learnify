using AppDomain;
using Application;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Learnify.Config;
using Learnify.Context;
using Learnify.Interfaces;
using Learnify.Services;
using Learnify.Validations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDomain();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LearnifyDbContext>(
    options =>
       options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AuthenticationValidator>();

var bcryptConfig = new BCryptConfig();
builder.Configuration.GetSection("BCrypt").Bind(bcryptConfig);
builder.Services.AddSingleton(bcryptConfig);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICryptService, CryptService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();