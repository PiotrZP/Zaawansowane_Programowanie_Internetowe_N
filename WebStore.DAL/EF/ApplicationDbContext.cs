using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModels;

namespace WebStore.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<ProductStock> ProductStocks { get; set; } = default!;
        public virtual DbSet<Address> Addresses { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
        public virtual DbSet<Invoice> Invoices { get; set; } = default!;
        public virtual DbSet<StationaryStore> StationaryStores { get; set; } = default!;
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<Customer>(1)
            .HasValue<User>(0)
            .HasValue<Supplier>(3)
            .HasValue<StationaryStoreEmployee>(2);

            modelBuilder.Entity<OrderProduct>()
            .HasKey(po => new { po.OrderId, po.ProductId });

            modelBuilder.Entity<OrderProduct>()
            .HasOne(p => p.Product)
            .WithMany(po => po.ProductOrders)
            .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<OrderProduct>()
            .HasOne(o => o.Order)
            .WithMany(po => po.ProductOrders)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}