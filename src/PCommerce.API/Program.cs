using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PCommerce.API;
using PCommerce.Application;
using PCommerce.Infrastructure;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.MapGet("/", async (PCommerceDbContext context) => await context.Users.FirstOrDefaultAsync());

app.Map("/create-user", async (UserManager<Account> userManager,
    RoleManager<IdentityRole> roleManager,
    PCommerceDbContext context) =>
{
    var createResult = await userManager
        .CreateAsync(new Account
            {
                UserName = "Alex123123",
                Name = "Alexandr", 
                Surname = "Masliy", 
                Patronymic = "Mikhaylovich"
            }
        );

    var user = await userManager.FindByNameAsync("Alex123123");

    await userManager.AddToRoleAsync(user!, "Admin");

    return Results.Ok(createResult);
});

app.Map("/create-admin-role", async (RoleManager<IdentityRole> roleManager) =>
{
    await roleManager.CreateAsync(new IdentityRole("Admin"));

    return Results.Created();
});

app.Run();