using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.DataModels;

namespace WebStore.DAL.Configuration;
public class StationaryStoreAddressConfiguration : IEntityTypeConfiguration<StationaryStoreAddress>
{
    public void Configure(EntityTypeBuilder<StationaryStoreAddress> builder)
    {
        builder.ToTable("StationaryStoreAddress");

        builder.HasOne(x => x.StationaryStore)
            .WithMany(y => y.Addresses)
            .HasForeignKey(x => x.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
