using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.DataModels;

namespace WebStore.DAL.Configuration;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");

        builder.HasOne(x => x.StationaryStore)
            .WithMany(y => y.Orders)
            .HasForeignKey(x => x.StationaryStoreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Customer)
            .WithMany(y => y.Orders)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Invoice)
            .WithMany(y => y.Orders)
            .HasForeignKey(x => x.Invoiceid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.TotalAmount)
            .HasPrecision(18, 2);
    }
}