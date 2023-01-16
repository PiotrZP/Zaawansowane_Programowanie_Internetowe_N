using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class Customer : User
{
    public virtual IList<Order> Orders { get; set; } = default!;
    public virtual IList<CustomerAddress> CustomerAddresses { get; set; } = default!;
}