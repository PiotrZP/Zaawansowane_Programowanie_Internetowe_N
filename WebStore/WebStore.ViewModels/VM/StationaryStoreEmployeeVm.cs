namespace WebStore.ViewModels.VM;
public class StationaryStoreEmployeeVm : UserVm
{
    public int StationaryStoreId { get; set; }
    public string Position { get; set; } = default!;
    public Decimal Salary { get; set; } = default!;
    public StationaryStoreVm StationaryStore { get; set; } = default!;
}