using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.Models;

namespace WebStore.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public virtual DbSet<Product> Product { get; set; } = default!;
        public virtual DbSet<ProductStock> ProductStocks { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<Address> Addresses { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
        public virtual DbSet<Invoice> Invoices { get; set; } = default!;
        public virtual DbSet<User> User { get; set; } = default!;
        public virtual DbSet<StationaryStore> StationaryStores { get; set; } = default!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>(0)
                .HasValue<Customer>(1)
                .HasValue<Supplier>(2)
                .HasValue<StationaryStoreEmployee>(3);

            builder.Entity<OrderProduct>()
                .HasKey(x1 => new { x1.OrderId, x1.ProductId });

            builder.Entity<OrderProduct>()
                .HasOne(x2 => x2.Product)
                .WithMany(x1 => x1.OrderProducts)
                .HasForeignKey(x2 => x2.ProductId);

            builder.Entity<OrderProduct>()
                .HasOne(x2 => x2.Order)
                .WithMany(x1 => x1.OrderProducts)
                .HasForeignKey(x2 => x2.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductStock>()
                .HasOne(x2 => x2.StationaryStore)
                .WithMany(x1 => x1.ProductStocks)
                .HasForeignKey(x2 => x2.StationaryStoreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductStock>()
                .HasOne(x2 => x2.Product)
                .WithMany(x1 => x1.ProductStocks)
                .HasForeignKey(x2 => x2.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductStock>()
                .HasKey(x => new { x.ProductId, x.StationaryStoreId });
        }

    }
}