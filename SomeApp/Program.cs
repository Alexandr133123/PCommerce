using Protos.Product;
using SomeApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddGrpcClient<Product.ProductClient>(c =>
{
    c.Address = new Uri(builder.Configuration.GetValue<string>("UrlConfig:PCommerceUrl")!);
});

builder.Services.AddScoped<ProductService>();

var app = builder.Build();

app.MapGet("/test", async (ProductService service) => await service.TestCallAsync());

app.MapGet("/", () => "Hello World!");

app.Run();