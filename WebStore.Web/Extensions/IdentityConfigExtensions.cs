using Microsoft.AspNetCore.Identity;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.Models;

namespace WebStore.Web.Extensions;
public static class IdentityConfigExtensions
{
    public static void AddCoreIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, IdentityRole<int>>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = false;
            }).AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddUserManager<UserManager<User>>()
                .AddEntityFrameworkStores<WSDbContext>()
                .AddDefaultTokenProviders();
    }
}
