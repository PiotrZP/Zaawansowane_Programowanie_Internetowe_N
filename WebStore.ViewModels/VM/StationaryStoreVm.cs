namespace WebStore.ViewModels.VM;
public class StationaryStoreVm
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public IList<OrderVm> Orders { get; set; } = default!;
    public IList<AddressVm> Addresses { get; set; } = default!;
    public IList<StationaryStoreEmployeeVm> Employees { get; set; } = default!;
    public IList<InvoiceVm> Invoices { get; set; } = default!;
}