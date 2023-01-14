namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateOrderVm
    {
        public int? Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public long TrackingNumber { get; set; }
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        //public int StationaryStoreId { get; set; }
    }
}