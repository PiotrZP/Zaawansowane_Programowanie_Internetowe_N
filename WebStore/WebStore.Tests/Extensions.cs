using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.Models;

namespace WebStore.Tests;
public static class Extensions
{
    // Create sample data
    public static async void SeedData(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<WSDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider
         .GetRequiredService<RoleManager<IdentityRole<int>>>();
        // other seed data ...
        //Suppliers
        var supplier1 = new Supplier()
        {
            Id = 1,
            FirstName = "Adam",
            LastName = "Bednarski",
            UserName = "supp1@eg.eg",
            Email = "supp1@eg.eg",
            RegistrationDate = new DateTime(2010, 1, 1),
        };
        await userManager.CreateAsync(supplier1, "User1234");
        //Categories
        var category1 = new Category()
        {
            Id = 1,
            Name = "Computers",
            Tag = "#computer"
        };
        await dbContext.AddAsync(category1);

        //Products
        var p1 = new Product()
        {
            Id = 1,
            CategoryId = category1.Id,
            SupplierId = supplier1.Id,
            Description = "Bardzo praktyczny monitor 32 cale",
            ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 },
            Name = "Monitor Dell 32",
            Price = 1000,
            Weight = 20,
        };
        await dbContext.AddAsync(p1);

        var p2 = new Product()
        {
            Id = 2,
            CategoryId = category1.Id,
            SupplierId = supplier1.Id,
            Description = "Precyzyjna mysz do pracy",
            ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x70 },
            Name = "Mysz Logitech",
            Price = 500,
            Weight = 0.5f,
        };
        await dbContext.AddAsync(p2);

        // orders
        var o1 = new Order()
        {
            Id = 1,
            TotalAmount = 1,
            TrackingNumber = 1233,
            DeliveryDate = new DateTime(2010, 1, 1),
            OrderDate = new DateTime(2010, 1, 2),
            StationaryStoreId = 1,
            CustomerId = 1,
            Invoiceid = 1
        };
        await dbContext.AddAsync(o1);

        var o2 = new Order()
        {
            Id = 2,
            TotalAmount = 3,
            TrackingNumber = 1244,
            DeliveryDate = new DateTime(2010, 1, 1),
            OrderDate = new DateTime(2010, 1, 2),
            StationaryStoreId = 1,
            CustomerId = 1,
            Invoiceid = 1
        };
        await dbContext.AddAsync(o2);

        var o3 = new Order()
        {
            Id = 3,
            TotalAmount = 1,
            TrackingNumber = 1234,
            DeliveryDate = new DateTime(2023, 1, 1),
            OrderDate = new DateTime(2020, 1, 1),
            StationaryStoreId = 1,
            CustomerId = 3,
            Invoiceid = 1,
        };
        await dbContext.AddAsync(o3);

        // stationary stores
        var st1 = new StationaryStore()
        {
            Id = 1,
            Name = "Store 1"
        };

        var st2 = new StationaryStore()
        {
            Id = 2,
            Name = "Store 2"
        };
        await dbContext.AddRangeAsync(st1, st2);

        // store addresses
        var stA1 = new Address()
        {
            Id = 1,
            StationaryStoreId = 1,
            City = "StoreCity",
            StreetName = "Szkolna",
            StreetNumber = 5,
            PostCode = "42-200"
        };

        var stA2 = new Address()
        {
            Id = 2,
            StationaryStoreId = 2,
            City = "StoreCity",
            StreetName = "Główna",
            StreetNumber = 15,
            PostCode = "42-201"
        };
        await dbContext.AddRangeAsync(stA1, stA2);

        // customers
        var c1 = new Customer()
        {
            FirstName = "Jan",
            LastName = "Client",
            UserName = "cs1@eg.eg",
            Email = "cs1@eg.eg",
            RegistrationDate = new DateTime(2020, 1, 1),
        };
        var a = userManager.CreateAsync(c1, "pasS123").Result.Errors.ToList();


        // store employees
        var stE1 = new StationaryStoreEmployee()
        {
            Id = 3,
            StationaryStoreId = 1,
            Position = "Worker",
            Salary = 3000,
            FirstName = "Jan",
            LastName = "Kowalski",
            UserName = "emp1@eg.eg",
            Email = "emp1@eg.eg",
            RegistrationDate = new DateTime(2020, 1, 1),
        };
        await userManager.CreateAsync(stE1, "pasS123");

        var stE2 = new StationaryStoreEmployee()
        {
            Id = 4,
            StationaryStoreId = 1,
            Position = "Manager",
            Salary = 500,
            FirstName = "Stanisław",
            LastName = "Nowak",
            UserName = "emp2@eg.eg",
            Email = "emp2@eg.eg",
            RegistrationDate = new DateTime(2020, 1, 1),
        };
        await userManager.CreateAsync(stE2, "pasS123");

        // invoices 
        var i1 = new Invoice()
        {
            Id = 1,
            Date = new DateTime(2022, 3, 1),
        };
        await dbContext.AddAsync(i1);

        // save changes
        await dbContext.SaveChangesAsync();
    }
}