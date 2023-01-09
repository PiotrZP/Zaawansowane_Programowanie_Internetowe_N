using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModels;

namespace WebStore.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Michal_ZymekAppDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderProduct>? OrderProducts { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductStock>? ProductStocks { get; set; }
        public DbSet<StationaryStore>? StationaryStores { get; set; }
        public DbSet<StationaryStoreEmployee>? StationaryStoreEmployees { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(c => c.Customer)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Supplier>()
            .HasMany(c => c.Products)
            .WithOne(c => c.Supplier)
            .HasForeignKey(c => c.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Product>()
            .HasMany(c => c.ProductStocks)
            .WithOne(c => c.Product)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Customer>()
            .HasMany(c => c.Addresses)
            .WithOne(c => c.Customer)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Invoice>()
            .HasMany(c => c.Orders)
            .WithOne(c => c.Invoice)
            .HasForeignKey(c => c.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<StationaryStore>()
            .HasMany(c => c.Addresses)
            .WithOne(c => c.StationaryStore)
            .HasForeignKey(c => c.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<StationaryStore>()
            .HasMany(c => c.StationaryStoreEmployees)
            .WithOne(c => c.StationaryStore)
            .HasForeignKey(c => c.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<OrderProduct>()
           .HasKey(op => new { op.OrderId, op.ProductId });


            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}