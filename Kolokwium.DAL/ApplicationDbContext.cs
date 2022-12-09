using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Kolokwium.Model.Models;


namespace Kolokwium.DAL
{
    // first add UserIdentity
    // add rel OrderProduct
    // add DbSet Prop
    // add virtal lazy loading
    // we dont add users ex. customer, supplayer, stationaryStoreEmployeer
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // one to many rel Order Product
            modelBuilder.Entity<OrderProduct>().HasKey(o => new { o.ProductId, o.OrderId });
            // we will need to add one to many because of FK
            // first start with product to OrderProducts set to productId
            modelBuilder.Entity<OrderProduct>().HasOne(p => p.Product).WithMany(op => op.OrderProducts).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            // second start with order
            modelBuilder.Entity<OrderProduct>().HasOne(o => o.Order).WithMany(op => op.OrderProducts).HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Restrict);
            // stationary employee store one to many
            modelBuilder.Entity<StationaryStoreEmployee>().HasOne(ss => ss.StationaryStore).WithMany(sse => sse.StationaryStoreEmployees).HasForeignKey(ss => ss.StationaryStoreId).OnDelete(DeleteBehavior.Restrict);
            // add UserRoles
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>(0)
            .HasValue<Customer>(1)
            .HasValue<Supplier>(2)
            .HasValue<StationaryStoreEmployee>(3);

            // Seed data in model

            // add Address
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    StreetName = "test",
                    StreetNumber = 12,
                    City = "test",
                    PostCode = 98300
                }
            );

            // add Customer
            modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                FirstName = "William",
                LastName = "Shakespeare",
                BillingAddresId = 1,
                ShippingAddressId = 1,
                RegistrationDate = new DateTime(2010, 1, 1)
            }
        );
            // add Supplier
            modelBuilder.Entity<Supplier>().HasData(
             new Supplier
             {
                 Id = 2,
                 FirstName = "Adam",
                 LastName = "Bednarski",
                 UserName = "supp1@eg.eg",
                 Email = "supp1@eg.eg",
                 RegistrationDate = new DateTime(2010, 1, 1),
             }
         );

            // add Category
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Computers",
                   Tag = "#computer"
               }
            );

            // add Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    SupplierId = 1,
                    Description = "Bardzo praktyczny monitor 32 cale",
                    ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 },
                    Name = "Monitor Dell 32",
                    Price = 1000,
                    Weight = 20,
                }
            );

            // add Invoice
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    TotalPrice = 10,
                    InvoiceDate = new DateTime()
                }
            );

            // add Order
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    DeliveryDate = new DateTime(),
                    OrderDate = new DateTime(),
                    TotalAmount = 1987,
                    TrackingNumber = 1,
                    InvoiceId = 1,
                    CustomerId = 1
                }
            );

            // add store
            modelBuilder.Entity<StationaryStore>().HasData(
                new StationaryStore
                {
                    Id = 1,
                    AgreementNumber = 1
                }
            );

            // add StationaryEmployee
            modelBuilder.Entity<StationaryStoreEmployee>().HasData(
                new StationaryStoreEmployee
                {
                    Id = 3,
                    FirstName = "William",
                    LastName = "Shakespeare",
                    RegistrationDate = new DateTime(2010, 1, 1),
                    AgreementNumber = 1,
                    EmploymeentDate = new DateTime(2010, 1, 1),
                    Position = "Menago",
                    Salary = 100,
                    StationaryStoreId = 1

                }
            );


        }

        public virtual DbSet<Address> Addresses { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
        public virtual DbSet<Invoice> Invoices { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public virtual DbSet<ProductStock> ProductStocks { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<StationaryStore> StationaryStores { get; set; } = default!;
        public virtual DbSet<Customer> Customers { get; set; } = default!;
    }
}
