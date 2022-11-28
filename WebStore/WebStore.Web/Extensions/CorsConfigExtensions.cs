namespace WebStore.Web.Extensions
{
    public static class CorsConfigExtensions
    {
        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000");
                options.AllowCredentials();
                options.AllowAnyHeader();
            });
        }
    }
}
