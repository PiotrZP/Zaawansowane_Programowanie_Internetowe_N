namespace WebStore.ViewModels.VM;
public class AddOrUpdateInvoiceVm
{
    public int? Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public int StationaryStoreId { get; set; }
}