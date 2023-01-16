namespace WebStore.ViewModels.VM
{
    public class CustomerAddressVm
    {

        public virtual CustomerVm Customer { get; set; } = default!;
        public int CustomerId { get; set; }
    }
}