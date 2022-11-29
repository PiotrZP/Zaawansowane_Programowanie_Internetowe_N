using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    // Table properties e.g
    // public virtual DbSet<Entity> TableName { get; set; }
 //   public virtual DbSet<Post> Posts { get; set; } // example table property
  //  public virtual DbSet<Comment> Comments { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //configuration commands 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Fluent API commands
//        modelBuilder.Entity<User>() // defining a one to many relation in fluent API.
//       .HasMany(c => c.Comments)
//       .WithOne(a => a.Author)
 //      .IsRequired()
 //      .OnDelete(DeleteBehavior.Restrict);
    }
}
