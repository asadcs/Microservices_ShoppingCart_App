using Discount.API.Repositories.Interfaces;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Hosting;
using Discount.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddControllers();

//var host = CreateHostBuilder(args).Build();
//host.MigrateDatabase<Program>();
//host.Run();


//builder.Services.AddHealthChecks()
//              .AddNpgSql(Configuration["DatabaseSettings:ConnectionString"]);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

partial class Program
{
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices((hostContext, services) =>
                {
                    // Configure your services here
                });

                webBuilder.Configure((hostContext, app) =>
                {
                    // Configure your app's pipeline here
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        // Configure your endpoints here
                    });
                });
            });

}
