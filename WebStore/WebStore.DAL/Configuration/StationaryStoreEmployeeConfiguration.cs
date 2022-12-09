using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.Models;

namespace WebStore.DAL.Configuration;
public class StationaryStoreEmployeeConfiguration : IEntityTypeConfiguration<StationaryStoreEmployee>
{
    public void Configure(EntityTypeBuilder<StationaryStoreEmployee> builder)
    {
        builder.HasOne(x => x.StationaryStore)
            .WithMany(y => y.StationaryStoreEmployees)
            .HasForeignKey(x => x.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Salary)
            .HasPrecision(18, 2);
    }
}