using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class Customer : User
{
    public virtual IList<Order> Orders { get; set; } = default!;
    public virtual IList<Address> Addresses { get; set; } = default!;
    [NotMapped]
    public virtual Address BillingAddress { get; set; } = default!;
    [NotMapped]
    public virtual Address ShippingAddress { get; set; } = default!;
}