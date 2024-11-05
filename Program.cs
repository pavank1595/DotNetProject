// Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Serve static files (HTML, CSS, JS, etc.) from the 'wwwroot' directory.
app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

// Serve a custom HTML page at the root
app.MapGet("/", () =>
{
    var htmlContent = @"
        <!DOCTYPE html>
        <html lang='en'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Simple .NET 8 Web App</title>
            <style>
                body { font-family: Arial, sans-serif; text-align: center; padding: 50px; }
                h1 { color: #0078D4; }
                p { color: #555; }
            </style>
        </head>
        <body>
            <h1>Welcome to My Simple .NET 8 Web Application!</h1>
            <p>This is a basic HTML page served by ASP.NET Core.</p>
        </body>
        </html>";
    return Results.Content(htmlContent, "text/html");
});

app.Run();
