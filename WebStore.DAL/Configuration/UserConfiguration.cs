using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model.Models;
using Enums = WebStore.Model.Enums;

namespace WebStore.DAL.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>((int)Enums.Role.User)
            .HasValue<Customer>((int)Enums.Role.Customer)
            .HasValue<Supplier>((int)Enums.Role.Supplier)
            .HasValue<StationaryStoreEmployee>((int)Enums.Role.StationaryStoreEmployee);

        builder.HasKey(x => x.Id);
    }
}
