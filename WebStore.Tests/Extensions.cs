using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.DataAccess;
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

            //Customers
            var customer1 = new Customer()
            {
                Id = 2,
                FirstName = "Jurek",
                LastName = "Klient",
                UserName = "klient1@eg.eg",
                Email = "klient1@eg.eg",
                RegistrationDate = new DateTime(2010, 1, 1),
            };
            await userManager.CreateAsync(customer1, "passC1");
            var customer2 = new Customer()
            {
                Id = 3,
                FirstName = "Stefek",
                LastName = "Klient",
                UserName = "klient2@eg.eg",
                Email = "klient2@eg.eg",
                RegistrationDate = new DateTime(2010, 1, 1),
            };
            await userManager.CreateAsync(customer2, "passC2");

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

            //Stores
            var store1 = new StationaryStore()
            {
                Id = 1,
                Name = "Store1",
            };
            await dbContext.AddAsync(store1);
            var store2 = new StationaryStore()
            {
                Id = 2,
                Name = "Store2",
            };
            await dbContext.AddAsync(store2);
            var store3 = new StationaryStore()
            {
                Id = 3,
                Name = "Store3",
            };
            await dbContext.AddAsync(store3);

            //StoreEmployee
            var employee1 = new StationaryStoreEmployee()
            {
                Id = 4,
                StationaryStoreId = store1.Id,
                Position = "Employee",
                Salary = 1000,
                FirstName = "Maciej",
                LastName = "Pracownik",
                UserName = "pracownik1@eg.eg",
                Email = "pacownik1@eg.eg",
                RegistrationDate = new DateTime(2010, 1, 1),
            };
            await userManager.CreateAsync(employee1, "passE1");
            var employee2 = new StationaryStoreEmployee()
            {
                Id = 5,
                StationaryStoreId = store2.Id,
                Position = "Accountant",
                Salary = 2000,
                FirstName = "Franek",
                LastName = "Pracownik",
                UserName = "pracownik2@eg.eg",
                Email = "pacownik2@eg.eg",
                RegistrationDate = new DateTime(2010, 1, 1),
            };
            await userManager.CreateAsync(employee2, "passE2");

            //Addreses
            var storeAddress1 = new Address()
            {
                Id = 1,
                StationaryStoreId = store1.Id,
                StreetName = "Street1",
                BuildingNumber = "1A",
                City = "City1",
                ZipCode = "11-111"
            };
            await dbContext.AddAsync(storeAddress1);
            var storeAddress2 = new Address()
            {
                Id = 2,
                StationaryStoreId = store2.Id,
                StreetName = "Street2",
                BuildingNumber = "22",
                City = "City2",
                ZipCode = "22-222"
            };
            await dbContext.AddAsync(storeAddress2);
            var customerAddress1 = new Address()
            {
                Id = 3,
                CustomerId = customer1.Id,
                StreetName = "Street3",
                BuildingNumber = "33",
                City = "City3",
                ZipCode = "33-333"
            };
            await dbContext.AddAsync(customerAddress1);
            var customerAddress2 = new Address()
            {
                Id = 4,
                CustomerId = customer1.Id,
                StreetName = "Street4",
                BuildingNumber = "44",
                City = "City4",
                ZipCode = "44-444"
            };
            await dbContext.AddAsync(customerAddress2);

            //Invoices
            var invoice1 = new Invoice()
            {
                Id = 1,
                TotalPrice = 1111,
                Date = new DateTime(2022, 10, 10),
                StationaryStoreId = store1.Id
            };
            await dbContext.AddAsync(invoice1);
            var invoice2 = new Invoice()
            {
                Id = 2,
                TotalPrice = 2222,
                Date = new DateTime(2022, 10, 10),
                StationaryStoreId = store2.Id
            };
            await dbContext.AddAsync(invoice2);
            var invoice3 = new Invoice()
            {
                Id = 3,
                TotalPrice = 3333,
                Date = new DateTime(2022, 10, 11),
                StationaryStoreId = store2.Id
            };
            await dbContext.AddAsync(invoice3);

            //Orders
            var order1 = new Order()
            {
                Id = 1,
                TrackingNumber = 1101022,
                OrderDate = new DateTime(2022, 10, 10),
                DeliveryDate = new DateTime(2022, 10, 12),
                StationaryStoreId = store1.Id,
                CustomerId = customer1.Id,
                InvoiceId = invoice1.Id,
            };
            await dbContext.AddAsync(order1);
            var order2 = new Order()
            {
                Id = 2,
                TrackingNumber = 2101022,
                OrderDate = new DateTime(2022, 10, 10),
                DeliveryDate = new DateTime(2022, 10, 12),
                StationaryStoreId = store2.Id,
                CustomerId = customer2.Id,
                InvoiceId = invoice2.Id,
            };
            await dbContext.AddAsync(order2);

            // save changes
            await dbContext.SaveChangesAsync();
        }
    }
}