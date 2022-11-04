using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModels;

namespace WebStore.DAL.EF;

public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int>
{
    public virtual DbSet<Order> Orders { get; set; } = default!;
    public virtual DbSet<Address> Addresses { get; set; } = default!;
    public virtual DbSet<Category> Categories { get; set; } = default!;
    public virtual DbSet<Invoice> Invoices { get; set; } = default!;
    public virtual DbSet<OrderProduct> OrderProduct { get; set; } = default!;
    public virtual DbSet<Product> Products { get; set; } = default!;
    public virtual DbSet<ProductStock> ProductStock { get; set; } = default!;
    public virtual DbSet<StationaryStore> StationaryStores { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>(0)
            .HasValue<Customer>(1)
            .HasValue<Supplier>(2)
            .HasValue<StationaryStoreEmployee>(3);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(o => o.Order)
            .WithMany(op => op.OrderProducts)
            .HasForeignKey(ord => ord.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
