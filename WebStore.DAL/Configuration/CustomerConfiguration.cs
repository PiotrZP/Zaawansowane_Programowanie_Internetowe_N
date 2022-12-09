using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.DataModels;

namespace WebStore.DAL.Configuration;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(x => x.Orders)
            .WithOne(y => y.Customer)
            .HasForeignKey(y => y.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}