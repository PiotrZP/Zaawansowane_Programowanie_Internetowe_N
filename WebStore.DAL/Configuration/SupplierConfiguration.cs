using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.DataModels;

namespace WebStore.DAL.Configuration;
public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasMany(x => x.Products)
            .WithOne(y => y.Supplier)
            .HasForeignKey(y => y.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

