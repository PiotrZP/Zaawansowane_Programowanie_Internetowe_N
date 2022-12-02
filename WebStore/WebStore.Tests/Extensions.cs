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


        // customers
        var c1 = new Customer()
        {
            FirstName = "Jan",
            LastName = "Client",
            UserName = "cs1@eg.eg",
            Email = "cs1@eg.eg",
            RegistrationDate = new DateTime(2020, 1, 1),
        };
        await userManager.CreateAsync(c1, "pasS123");

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

        var st3 = new StationaryStore()
        {
            Id = 3,
            Name = "Store 3"
        };
        await dbContext.AddRangeAsync(st1, st2, st3);

        // invoices 
        var i1 = new Invoice()
        {
            Id = 1,
            TotalPrice = 223,
            Date = new DateTime(2020, 10, 10),
            StationaryStoreId = 1,
        };

        var i2 = new Invoice()
        {
            Id = 2,
            TotalPrice = 1423,
            Date = new DateTime(2021, 2, 2),
            StationaryStoreId = 1,
        };

        var i3 = new Invoice()
        {
            Id = 3,
            TotalPrice = 123,
            Date = new DateTime(2022, 3, 1),
            StationaryStoreId = 2,
        };
        await dbContext.AddRangeAsync(i1, i2, i3);

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
        await dbContext.AddRangeAsync(o1, o2, o3);

        // addresses
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

        var cA1 = new Address()
        {
            Id = 3,
            CustomerId = 1,
            City = "CustomerCity",
            StreetName = "Słoneczna",
            StreetNumber = 151,
            PostCode = "42-221"
        };
        await dbContext.AddRangeAsync(stA1, stA2, cA1);

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

        // save changes
        await dbContext.SaveChangesAsync();
    }
}