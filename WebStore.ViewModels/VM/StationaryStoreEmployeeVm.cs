namespace WebStore.ViewModels.VM
{
    public class StationaryStoreEmployeeVm
    {
        public string Position { get; set; } = default!;
        public decimal Salary { get; set; } = default!;
        public virtual StationaryStoreVm StationaryStore { get; set; } = default!;
        public int? StationaryStoreId { get; set; }
    }
}