namespace WebStore.ViewModels.VM;
public class InvoiceVm
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public IList<OrderVm> Orders { get; set; } = default!;
    public int StationaryStoreId { get; set; }
    public StationaryStoreVm StationaryStore { get; set; } = default!;
}