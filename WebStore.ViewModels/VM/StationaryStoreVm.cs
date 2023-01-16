namespace WebStore.ViewModels.VM
{
    public class StationaryStoreVm
    {
        public int Id { get; set; }
        public virtual AddressVm Address { get; set; } = default!;
        public virtual IList<OrderVm> Orders { get; set; } = default!;
        public virtual IList<InvoiceVm> Invoices { get; set; } = default!;
        public virtual IList<StationaryStoreEmployeeVm> StationaryStoreEmployees { get; set; } = default!;
        public virtual IList<StationaryStoreAddressVm> StationaryStoreAdresses { get; set; } = default!;
    }
}