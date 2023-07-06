using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json",optional :true , reloadOnChange:true);
builder.Services.AddOcelot(builder.Configuration);



//builder.Services.AddOcelot();
//builder.Logging.ClearProviders(); // Optional: Clear any existing logging providers
//builder.Logging.AddConfiguration(Configuration.GetSection("Logging"));
//builder.Logging.AddConsole(); // Add console logging provider
//builder.Logging.AddDebug();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
await app.UseOcelot();
app.Run();
