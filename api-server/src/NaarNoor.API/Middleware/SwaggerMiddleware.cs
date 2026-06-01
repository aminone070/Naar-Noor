namespace NaarNoor.API.Middleware;

/// <summary>
/// Swagger UI middleware
/// </summary>
public static class SwaggerMiddleware
{
    public static void UseSwaggerMiddleware(this WebApplication app)
    {
        app.UseSwagger(c =>
        {
            c.PreSerializeFilters.Add((swagger, httpReq) =>
            {
                swagger.Servers = new List<Microsoft.OpenApi.Models.OpenApiServer>
                {
                    new Microsoft.OpenApi.Models.OpenApiServer
                    {
                        Url = $"{httpReq.Scheme}://{httpReq.Host.Value}",
                        Description = "Current Server"
                    }
                };
            });
        });
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Naar & Noor API v1");
            c.RoutePrefix = "api/docs";
            c.DefaultModelsExpandDepth(1);
        });
    }
}
