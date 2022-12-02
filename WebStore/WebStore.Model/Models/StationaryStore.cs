namespace WebStore.Model.Models;
public class StationaryStore
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public virtual IList<Order> Orders { get; set; } = default!;
    public virtual IList<Address> Addresses { get; set; } = default!;
    public virtual IList<StationaryStoreEmployee> StationaryStoreEmployees { get; set; } = default!;
    public virtual IList<Invoice> Invoices { get; set; } = default!;
}