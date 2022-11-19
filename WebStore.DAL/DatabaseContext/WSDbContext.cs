using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModels;

namespace WebStore.DAL.DatabaseContext;
public class WSDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public WSDbContext(DbContextOptions<WSDbContext> options) : base(options) { }

    public DbSet<User> User => Set<User>();
    public DbSet<BillingAddress> BillingAddress => Set<BillingAddress>();
    public DbSet<ShippingAddress> ShippingAddress => Set<ShippingAddress>();
    public DbSet<Address> Address => Set<Address>();
    public DbSet<Category> Category => Set<Category>();
    public virtual DbSet<Invoice> Invoice => Set<Invoice>();
    public DbSet<Order> Order => Set<Order>();
    public DbSet<OrderProduct> OrderProduct => Set<OrderProduct>();
    public DbSet<Product> Product => Set<Product>();
    public DbSet<StationaryStore> StationaryStore => Set<StationaryStore>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WSDbContext).Assembly);
    }
}