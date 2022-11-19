using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Contains class IdentityDbContext
using Microsoft.AspNetCore.Identity; // Contains class IdnetityRole<int>
using Microsoft.EntityFrameworkCore; // Contains class DbContextOpitons
using WebStore.Model.DataModels;


namespace WebStore.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int> // using in brackets class which inherits for class IdentityUser
    {
        //Table Properties
        public virtual DbSet<Order> Orders {get; set;} =default!;
        public virtual DbSet<OrderProduct> OrderProducts {get; set;} =default!;
        public virtual DbSet<Product> Products {get; set;} =default!;
        public virtual DbSet<ProductStock> ProductStocks {get; set;} =default!;
        public virtual DbSet<Address> Addresses {get; set;} =default!;
        public virtual DbSet<Category> Categories {get; set;} =default!;
        public virtual DbSet<Invoice> Invoices {get; set;} =default!;
        public virtual DbSet<StationaryStore> StationaryStores {get; set;} =default!;
        


        //Constructor call commands from class IdnetityDbContext constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
        }
        //Method responsible for configuration of relation between classes and database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Method force download datas from Database only when it is neccesery
            optionsBuilder.UseLazyLoadingProxies();
        }
        //In method is possible deffinition fluent API command, for example describe inheretance after 'User' class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("WebStoreUsers")
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Customer>("Customer")
                .HasValue<Supplier>("Supplier");

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new {op.OrderId, op.ProductId});

            modelBuilder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Product)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>().Property(p => p.CategoryId).IsRequired(false);
            modelBuilder.Entity<Product>().Property(p => p.SupplierId).IsRequired(false);

            modelBuilder.Entity<Order>().Property(o => o.CustomerId).IsRequired(false);
            modelBuilder.Entity<Order>().Property(o => o.InvoiceId).IsRequired(false);

            modelBuilder.Entity<StationaryStoreAddress>().Property(a => a.StationaryStoreId).IsRequired(false);

        }
    }
}