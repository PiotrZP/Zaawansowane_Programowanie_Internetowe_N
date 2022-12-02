namespace WebStore.ViewModels.VM

{
    public class StoreVm
    {
        public int Id { get; set; }
        public virtual AddressVm Address {get; set;} = default!;
        
        public int AddressId { get; set; }
        public virtual IList<OrderVm> Orders {get; set;} = default!;
        public long ArrangementNumber {get; set;} = default!;
        public virtual IList<StationaryStoreEmployeeVm> StationaryStoreEmployees {get; set; } = default!;
    }
}