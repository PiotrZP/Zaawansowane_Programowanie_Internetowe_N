using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;

namespace WebStore.Tests
{

    public static class Extensions
    {
        // Create sample data
        public static async void SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
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

            //Orders
            var order1 = new Order()
            {
                Id = 1,
                DeliveryDate = new DateTime(),
                OrderDate = new DateTime(),
                TotalAmount = 4241.62m,
                TrackingNumber = 895235,
                InvoiceId = 657,
                CustomerId = 1
            };
            await dbContext.AddAsync(order1);

            var order2 = new Order()
            {
                Id = 2,
                DeliveryDate = new DateTime(),
                OrderDate = new DateTime(),
                TotalAmount = 5625.73m,
                TrackingNumber = 732574,
                InvoiceId = 321,
                CustomerId = 3
            };
            await dbContext.AddAsync(order2);

            //Invoices
            var invoice1 = new Invoice()
            {
                Id = 1,
                TotalPrice = 10,
                InvoiceDate = new DateTime()
            };
            await dbContext.AddAsync(invoice1);

            var invoice2 = new Invoice()
            {
                Id = 2,
                TotalPrice = 20,
                InvoiceDate = new DateTime()
            };
            await dbContext.AddAsync(invoice2);

          //Stores

            var store1 = new StationaryStore()
            {
                Id = 1
            };
            await dbContext.AddAsync(store1);

            var store2 = new StationaryStore()
            {
                Id = 2
            };
            await dbContext.AddAsync(store2);

            // Addresses

            var address1 = new Address()
            {
                Id = 1,
                City = "Czestochowa",
                ZipCode = "42-200",
                Street = "Czestochowska",
                BuildingNumber = 10,
                ApartmentNumber = 1
            };
            await dbContext.AddAsync(address1);

            var address2 = new Address()
            {
                Id = 2,
                City = "Krakow",
                ZipCode = "31-510",
                Street = "Krakowska",
                BuildingNumber = 20,
                ApartmentNumber = 2
            };
            await dbContext.AddAsync(address2);

            var address3 = new Address()
            {
                Id = 3,
                City = "New York",
                ZipCode = "10-100",
                Street = "Nowojorska",
                BuildingNumber = 30,
                ApartmentNumber = 3
            };
            await dbContext.AddAsync(address3);

            // save changes
            await dbContext.SaveChangesAsync();
        }
    }
}