namespace WebStore.ViewModels.VM
{
    public class CustomerVm
    {
        public virtual IList<OrderVm> Orders { get; set; } = default!;
        public virtual IList<CustomerAddressVm> CustomerAddresses { get; set; } = default!;
    }
}