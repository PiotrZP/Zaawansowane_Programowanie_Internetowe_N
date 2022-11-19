namespace WebStore.ViewModels.VM;
public class StationaryStoreAddressVm : AddressVm
{
    public int StationaryStoreId { get; set; }
    public StationaryStoreVm StationaryStore { get; set; } = default!;
}
