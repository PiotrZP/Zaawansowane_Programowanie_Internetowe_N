namespace WebStore.ViewModels.VM;
public class StationaryStoreEmployeeVm : UserVm
{
    public string Position { get; set; } = default!;
    public Decimal Salary { get; set; } = default!;
    public int StationaryStoreId { get; set; }
    public StationaryStoreVm StationaryStore { get; set; } = default!;
}