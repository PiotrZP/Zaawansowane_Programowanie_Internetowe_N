namespace WebStore.ViewModels.VM
{
    public class StationaryStoreAddressVm
    {
        public virtual StationaryStoreVm StationaryStore { get; set; } = default!;
        public int StationaryStoreId { get; set; }
    }
}