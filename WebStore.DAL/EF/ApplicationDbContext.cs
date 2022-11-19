using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModels;
using WebStore.DAL.EF;

namespace WebStore.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public virtual DbSet<Address> Addresses { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
        public virtual DbSet<Invoice> Invoices { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<ProductStock> ProductStocks { get; set; } = default!;

        public virtual DbSet<StationaryStore> StationaryStores { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .ToTable("Users")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>(0)
                .HasValue<Customer>(1)
                .HasValue<Supplier>(2)
                .HasValue<StationeryStoreEmployee>(3);
            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.ProductId, op.OrderId });
            builder.Entity<OrderProduct>()
                .HasOne(p => p.Product)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(ord => ord.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(ord => ord.OrderId)
                .OnDelete(DeleteBehavior.Restrict);



            // builder.Entity<Customer>()
            //     .ToTable("Customer")
            //     .HasMany(c => c.Orders)
            //     .WithOne(o => o.Customer)
            //     .HasForeignKey(x => x.CustomerId);

            // builder.Entity<Customer>()
            //     .HasMany(a => a.BillingAddress)
            //     .WithOne()
            // builder.Entity<Order>()
            //     .ToTable("Order")
            //     .HasOne(c => c.Customer)
            //     .WithMany(o => o.Orders)
            //     .HasForeignKey(x => x.Id);

            // builder.Entity<Supplier>()
            //     .ToTable("Supplier")
            //     .HasMany(s => s.Products)
            //     .WithOne(p => p.Supplier)
            //     .HasForeignKey(x => x.Id);

            // builder.Entity<Product>()
            //     .ToTable("Product")
            //     .HasMany(x => x.ProductStocks)
            //     .WithOne(s => s.Product)
            //     .HasPrincipalKey(x => x.Id);
            // builder.Entity<Address>().ToTable("tbl_Adresses");
            // builder.Entity<Category>().ToTable("tbl_Categories");
            // builder.Entity<Invoice>().ToTable("tbl_Invoices");
            // builder.Entity<Order>().ToTable("tbl_Orders");
            // builder.Entity<OrderProduct>().ToTable("tbl_OrderProducts");
            // builder.Entity<Product>().ToTable("tbl_Product");
            // builder.Entity<ProductStock>().ToTable("tbl_ProductStocks");
            // builder.Entity<StationaryStore>().ToTable("tbl_StationaryStore");

        }

    }
}