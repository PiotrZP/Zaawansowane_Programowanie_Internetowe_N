namespace WebStore.Model.Models;
public class Product
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public byte[] ImageBytes { get; set; } = default!;
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public float Weight { get; set; }
    public virtual Supplier Supplier { get; set; } = default!;
    public int? SupplierId { get; set; }
    public virtual Category Category { get; set; } = default!;
    public int? CategoryId { get; set; } = default!;
    public virtual IList<ProductStock> ProductStocks { get; set; } = default!;
    public virtual IList<OrderProduct> OrderProducts { get; set; } = default!;
}