using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class OrderProduct
{
    public virtual Order Order { get; set; } = default!;
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public virtual Product Product { get; set; } = default!;
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}