namespace WebStore.ViewModels.VM;
public class StationaryStoreVm
{
    public int Id { get; set; }
    public AddressVm Address { get; set; } = default!;
    public IList<OrderVm> Orders { get; set; } = default!;
    public IList<StationaryStoreAddressVm> Addresses { get; set; } = default!;
    public IList<StationaryStoreEmployeeVm> StationaryStoreEmployees { get; set; } = default!;
    public IList<InvoiceVm> Invoices { get; set; } = default!;
}