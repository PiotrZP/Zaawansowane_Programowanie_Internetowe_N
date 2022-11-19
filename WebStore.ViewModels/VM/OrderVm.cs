namespace WebStore.ViewModels.VM;
public class OrderVm
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public long TrackingNumber { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime OrderDate { get; set; }
    public int StationaryStoreId { get; set; }
    public StationaryStoreVm StationaryStore { get; set; } = default!;
    public int CustomerId { get; set; }
    public CustomerVm Customer { get; set; } = default!;
    public int Invoiceid { get; set; } = default!;
    public InvoiceVm Invoice { get; set; } = default!;
    public IList<ProductVm> Products { get; set; } = default!;
}