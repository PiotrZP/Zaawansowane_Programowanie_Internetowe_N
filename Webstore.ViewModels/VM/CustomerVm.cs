namespace WebStore.ViewModels.VM;
public class CustomerVm : UserVm
{
    public IList<BillingAddressVm> BillingAddresses { get; set; } = default!;
    public IList<ShippingAddressVm> ShippingAddresses { get; set; } = default!;
    public IList<OrderVm> Orders { get; set; } = default!;
}