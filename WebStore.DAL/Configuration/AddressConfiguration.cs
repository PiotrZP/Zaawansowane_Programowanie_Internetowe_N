using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.DataModels;

namespace WebStore.DAL.Configuration;
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CustomerId)
            .IsRequired(false)
            .HasColumnName("CustomerId");

        builder.Property(x => x.StationaryStoreId)
            .IsRequired(false)
            .HasColumnName("StationaryStoreId");

        builder.Property(x => x.BillingCustomerId)
            .IsRequired(false)
            .HasColumnName("BillingCustomerId");

        builder.Property(x => x.ShippingCustomerId)
            .IsRequired(false)
            .HasColumnName("ShippingCustomerId");

        builder.HasOne(x => x.Customer)
            .WithMany(y => y.Addresses)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.BillingCustomer)
            .WithOne(y => y.BillingAddress)
            .HasForeignKey<Address>(x => x.BillingCustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ShippingCustomer)
            .WithOne(y => y.ShippingAddress)
            .HasForeignKey<Address>(x => x.ShippingCustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.StationaryStore)
            .WithMany(y => y.Addresses)
            .HasForeignKey(x => x.StationaryStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}