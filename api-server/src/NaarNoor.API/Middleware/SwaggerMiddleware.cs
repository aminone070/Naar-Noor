namespace NaarNoor.API.Middleware;

/// <summary>
/// Swagger UI middleware configuration
/// </summary>
public static class SwaggerMiddleware
{
    public static void UseSwaggerMiddleware(this WebApplication app)
    {
        // Enable Swagger JSON endpoint at /swagger/v1/swagger.json
        app.UseSwagger();
        
        // Enable Swagger UI at /api/docs
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Naar & Noor API v1");
            c.RoutePrefix = "api/docs";
            c.DocumentTitle = "Naar & Noor API Documentation";
        });
    }
}
