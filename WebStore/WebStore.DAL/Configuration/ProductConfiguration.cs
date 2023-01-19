using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.Models;

namespace WebStore.DAL.Configuration;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.Property(x => x.SupplierId)
        .IsRequired(false);

        builder.HasOne(x => x.Supplier)
            .WithMany(y => y.Products)
            .HasForeignKey(x => x.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Category)
            .WithMany(y => y.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ProductStocks)
            .WithOne(y => y.Product)
            .HasForeignKey(y => y.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.OrderProducts)
            .WithOne(y => y.Product)
            .HasForeignKey(y => y.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Price)
             .HasPrecision(18, 2);
    }
}
