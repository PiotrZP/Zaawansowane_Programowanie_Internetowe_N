namespace WebStore.Model.DataModels
{
    public class OrderProduct
    {
        public Order Order { get; set; } = default!;
        public int OrderId { get; set; }
        public Product Product { get; set; } = default!;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}