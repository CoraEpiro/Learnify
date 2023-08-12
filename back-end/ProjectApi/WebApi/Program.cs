using AppDomain;
using Application;
using Application.Tasks.Commands.Insert.InsertUser;
using Application.Tasks.Commands.Update.UpdateUsername;
using Application.Tasks.Queries.GetPendingUserById;
using Application.Tasks.Queries.GetUser;
using Application.Tasks.Queries.GetUserByEmail;
using Application.Tasks.Queries.GetUserById;
using Application.Tasks.Queries.GetUserByUsername;
using Application.Tasks.Queries.GetUserByUsersecret;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDomain();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<InsertUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateUsernameCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetPendingUserByIdCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetUserByIdCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetUserByEmailCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetUserByUsernameCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetUserByUsersecretCommandValidator>();

builder.Services.AddConfigs(builder.Configuration);
builder.Services.AuthenticationAndAuthorization(builder.Configuration);
builder.Services.AddSwagger();

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