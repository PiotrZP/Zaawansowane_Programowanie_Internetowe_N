using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.Models;

namespace WebStore.DAL.Configuration;
public class StationaryStoreConfiguration : IEntityTypeConfiguration<StationaryStore>
{
    public void Configure(EntityTypeBuilder<StationaryStore> builder)
    {
        builder.ToTable("StationaryStore");

        builder.HasMany(x => x.Orders)
            .WithOne(y => y.StationaryStore)
            .HasForeignKey(y => y.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Addresses)
            .WithOne(y => y.StationaryStore)
            .HasForeignKey(y => y.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.StationaryStoreEmployees)
            .WithOne(y => y.StationaryStore)
            .HasForeignKey(y => y.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Invoices)
            .WithOne(y => y.StationaryStore)
            .HasForeignKey(y => y.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
