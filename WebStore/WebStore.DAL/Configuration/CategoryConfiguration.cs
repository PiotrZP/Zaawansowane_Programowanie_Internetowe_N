using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.Models;

namespace WebStore.DAL.Configuration;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasMany(x => x.Products)
            .WithOne(y => y.Category)
            .HasForeignKey(y => y.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
