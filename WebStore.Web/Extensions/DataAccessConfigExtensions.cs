using Microsoft.EntityFrameworkCore;
using WebStore.DAL.DatabaseContext;

namespace WebStore.Web.Extensions;
public static class DataAccessConfigExtensions
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WSDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("WSDatabaseConntection"));
                options.EnableSensitiveDataLogging(true);
            });
    }
}