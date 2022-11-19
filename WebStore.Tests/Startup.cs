using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Services.Configuration;
using WebStore.Model.DataModels;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;

namespace WebStore.Tests;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));

        services.AddEntityFrameworkInMemoryDatabase()
            .AddDbContext<WSDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

        services.AddIdentity<User, IdentityRole<int>>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
        })
            .AddRoleManager<RoleManager<IdentityRole<int>>>()
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<WSDbContext>();

        services.AddTransient(typeof(ILogger), typeof(Logger<Startup>));

        // service binding
        services.AddTransient<IProductService, ProductService>();

        // ... other bindings...
        services.SeedData();
    }
}