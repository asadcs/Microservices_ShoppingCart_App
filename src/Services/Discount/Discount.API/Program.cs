using Discount.API.Repositories.Interfaces;
using Discount.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddControllers();
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
