namespace WebStore.Model.DataModels;

public class OrderProduct
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    public int Quantity { get; set; }
}