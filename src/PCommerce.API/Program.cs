using PCommerce.API;
using PCommerce.Application;
using PCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();