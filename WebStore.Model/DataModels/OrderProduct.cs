using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class OrderProduct
{
    public int Quantity { get; set; }
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
}
