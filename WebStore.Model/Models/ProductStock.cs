using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.Models;

public class ProductStock
{
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    [ForeignKey("StationaryStore")]
    public int StationaryStoreId { get; set; }
    public virtual StationaryStore StationaryStore { get; set; } = default!;
    public int Quantity { get; set; } = default!;
}
