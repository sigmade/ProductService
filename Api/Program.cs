using Core.UseCases.GetProduct;
using Infrastructure.Repositories;
using Core.Contracts.DiscountClient;
using Core.Contracts.ProductRepository;
using Infrastructure.Clients.DIscountClient; // added

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IDiscountClient, DiscountClient>(); // added
        builder.Services.AddScoped<IGetProductUseCase, GetProductUseCase>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
