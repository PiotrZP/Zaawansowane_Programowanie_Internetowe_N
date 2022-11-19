namespace WebStore.Model.DataModels;

public class Invoice
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public virtual IList<Order> Orders { get; set; } = default!;
    public int StationaryStoreId { get; set; }
    public virtual StationaryStore StationaryStore { get; set; } = default!;
}