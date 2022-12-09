namespace WebStore.Model.DataModels;
public class Customer : User
{
    public int? BillingAddressId { get; set; }
    public virtual Address BillingAddress { get; set; } = default!;
    public int? ShippingAddressId { get; set; }
    public virtual Address ShippingAddress { get; set; } = default!;
    public virtual IList<Order> Orders { get; set; } = default!;
    public virtual ICollection<Address> Addresses { get; set; } = default!;
}