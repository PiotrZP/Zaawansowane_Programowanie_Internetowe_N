using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.DataModels;

public class ProductStock
{
    [Key]
    public int Id { get; set; }
    public virtual Product Product { get; set; } = default!;
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}