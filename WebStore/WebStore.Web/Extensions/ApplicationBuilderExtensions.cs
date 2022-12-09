namespace WebStore.Web.Extensions;
public static class ApplicationBuilderExtensions
{
    public static void ConfigurePipeline(this IApplicationBuilder app, bool IsDevelopment)
    {
        if (!IsDevelopment)
        {
            app.UseDeveloperExceptionPage();
            app.UseHsts();
        }

        app.UseCoreSwagger();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}