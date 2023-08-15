using AppDomain;
using Application;
using FluentValidation.AspNetCore;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDomain();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation();

builder.Services.AddConfigs(builder.Configuration);
builder.Services.AuthenticationAndAuthorization(builder.Configuration);
builder.Services.AddSwagger();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressInferBindingSourcesForParameters = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();