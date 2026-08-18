var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "AZ-104 App Service Lab - Deployment Successful");

app.Run();
