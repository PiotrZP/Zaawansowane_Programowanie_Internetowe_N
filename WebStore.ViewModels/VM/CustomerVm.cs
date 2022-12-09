namespace WebStore.ViewModels.VM;
public class CustomerVm : UserVm
{
    public AddressVm ShippingAddresses { get; set; } = default!;
    public AddressVm BillingAddress { get; set; } = default!;
    public IList<AddressVm> Addresses { get; set; } = default!;
    public IList<OrderVm> Orders { get; set; } = default!;
}