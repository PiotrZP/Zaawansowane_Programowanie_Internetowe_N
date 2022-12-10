
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModels;

namespace WebStore.DAL.DataAccess;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{

    public virtual DbSet<User> User { get; set; } = default!;
    public virtual DbSet<Address> Address { get; set; } = default!;
    public virtual DbSet<OrderProduct> OrderProduct { get; set; } = default!;
    public virtual DbSet<Product> Product { get; set; } = default!;
    public virtual DbSet<ProductStock> ProductStock { get; set; } = default!;
    public virtual DbSet<Order> Order { get; set; } = default!;
    public virtual DbSet<Category> Category { get; set; } = default!;
    public virtual DbSet<Invoice> Invoice { get; set; } = default!;
    public virtual DbSet<StationaryStore> StationaryStore { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Address>().Property<bool>("IsDeleted");
        builder.Entity<Address>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        builder.Entity<Category>().Property<bool>("IsDeleted");
        builder.Entity<Category>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        builder.Entity<Invoice>().Property<bool>("IsDeleted");
        builder.Entity<Invoice>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        builder.Entity<Order>().Property<bool>("IsDeleted");
        builder.Entity<Order>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        builder.Entity<Product>().Property<bool>("IsDeleted");
        builder.Entity<Product>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        builder.Entity<StationaryStore>().Property<bool>("IsDeleted");
        builder.Entity<StationaryStore>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        builder.Entity<User>().Property<bool>("IsDeleted");
        builder.Entity<User>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);

        builder.Entity<Order>().ToTable("Order").HasMany(x => x.OrderProducts).WithOne(y => y.Order).HasForeignKey(y => y.OrderId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Product>().ToTable("Product").HasMany(x => x.OrderProducts).WithOne(y => y.Product).HasForeignKey(y => y.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<StationaryStore>().HasMany(x => x.StationaryStoreEmployees).WithOne(y => y.StationaryStore).HasForeignKey(y => y.StationaryStoreId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<StationaryStore>().HasMany(x => x.Orders).WithOne(y => y.StationaryStore).HasForeignKey(y => y.StationaryStoreId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>(0)
            .HasValue<Customer>(1)
            .HasValue<Supplier>(2)
            .HasValue<StationaryStoreEmployee>(3);

        builder.Entity<OrderProduct>()
            .ToTable("OrderProduct")
            .HasKey(x => new { x.OrderId, x.ProductId });
        builder.Entity<OrderProduct>()
            .HasOne(x => x.Order)
            .WithMany(y => y.OrderProducts)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<OrderProduct>()
            .HasOne(x => x.Product)
            .WithMany(y => y.OrderProducts)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

    }
    public override int SaveChanges()
    {
        UpdateSoftDeleteStatuses();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        UpdateSoftDeleteStatuses();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void UpdateSoftDeleteStatuses()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.CurrentValues["IsDeleted"] = false;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsDeleted"] = true;
                    break;
            }
        }
    }
}