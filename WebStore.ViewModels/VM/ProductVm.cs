namespace WebStore.ViewModels.VM
{
    public class ProductVm
    {
        public int Id { get; set; }
        bool IsDeleted { get; set; }
        public string Description { get; set; } = default!;
        public byte[] ImageBytes { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public SupplierVm Supplier { get; set; } = default!;
        public int? SupplierId { get; set; }
        public CategoryVm Category { get; set; } = default!;
        public int? CategoryId { get; set; }
        public IList<ProductStockVm> ProductStocks { get; set; } = default!;
        public IList<OrderVm> Orders { get; set; } = default!;
    }
}