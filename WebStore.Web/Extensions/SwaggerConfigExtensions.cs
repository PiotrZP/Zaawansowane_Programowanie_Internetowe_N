using Microsoft.OpenApi.Models;

namespace WebStore.Web.Extensions;
public static class SwaggerConfigExtensions
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStore API", Version = "v1" });
        });
    }
    public static void UseCoreSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStore API v1"));
    }
}
