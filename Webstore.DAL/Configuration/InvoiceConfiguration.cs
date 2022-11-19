using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.DataModels;

namespace WebStore.DAL.Configuration;
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoice");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Orders)
            .WithOne(y => y.Invoice)
            .HasForeignKey(y => y.Invoiceid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.StationaryStore)
            .WithMany(y => y.Invoices)
            .HasForeignKey(y => y.StationaryStoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.TotalPrice)
            .HasPrecision(18, 2);
    }
}