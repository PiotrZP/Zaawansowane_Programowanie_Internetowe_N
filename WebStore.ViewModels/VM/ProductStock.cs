namespace WebStore.ViewModels.VM
{
    public class ProductStockVm
    {
        public int Id { get; set; }
        //bool IsDeleted { get; set; }
        public virtual ProductVm Product { get; set; } = default!;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
