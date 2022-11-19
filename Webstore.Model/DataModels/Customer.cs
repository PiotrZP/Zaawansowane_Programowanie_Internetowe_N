namespace WebStore.Model.DataModels;

public class Customer : User
{
    public virtual IList<BillingAddress> BillingAddresses { get; set; } = default!;
    public virtual IList<ShippingAddress> ShippingAddresses { get; set; } = default!;
    public virtual IList<Order> Orders { get; set; } = default!;
}