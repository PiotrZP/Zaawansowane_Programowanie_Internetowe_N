namespace WebStore.ViewModels.VM

{
    public class OrderVm
    {
        public DateTime DeliveryDate { get; set; } = default!; 
        public DateTime OrderDate { get; set; } = default!; 
        public long TrackingNumber { get; set; } = default!; 
        public IList<OrderProductVm> OrderProducts { get; set; } = default!;

        public int? Id { get; set; }
        
        public string Description { get; set; } =default!;

        public byte[] ImageBytes { get; set; } = default!;

        public string Name { get; set; } = default!;

        public decimal Price { get; set; }

        public float Weight { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }
        public decimal TotalAmount {get;set;} = default!;
    }
}