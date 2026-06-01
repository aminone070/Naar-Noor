using Microsoft.OpenApi.Models;
using System.Reflection;

namespace NaarNoor.API.Configuration;

/// <summary>
/// Swagger/OpenAPI service registration
/// </summary>
public static class SwaggerServiceConfiguration
{
    public static void AddSwaggerServiceConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Naar & Noor API",
                Version = "v1",
                Description = "Restaurant management API - Authentic Himalayan cuisine",
                Contact = new OpenApiContact
                {
                    Name = "Naar & Noor",
                    Url = new Uri("https://naar-noor.vercel.app")
                }
            });

            // Include XML comments for better endpoint documentation
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }
        });
    }
}
