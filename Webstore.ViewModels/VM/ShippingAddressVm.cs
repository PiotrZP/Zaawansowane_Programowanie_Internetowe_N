namespace WebStore.ViewModels.VM;
public class ShippingAddressVm : AddressVm
{
    public int CustomerId { get; set; }
    public CustomerVm Customer { get; set; } = default!;
}
