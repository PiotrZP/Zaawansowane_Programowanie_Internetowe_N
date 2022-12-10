namespace WebStore.ViewModels.VM
{
    public class CustomerVm
    {
        public virtual IList<OrderVm> Orders { get; set; } = default!;
        public virtual IList<AddressVm> Addresses { get; set; } = default!;
        public virtual AddressVm BillingAddress { get; set; } = default!;
        public virtual AddressVm ShippingAddress { get; set; } = default!;
    }
}