var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var message = builder.Configuration["AZ104_MESSAGE"]
              ?? "AZ104_MESSAGE is not configured";

app.MapGet("/", () => $"AZ-104 App Service Lab - {message}");

app.Run();
