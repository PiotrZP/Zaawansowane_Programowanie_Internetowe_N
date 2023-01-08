namespace WebStore.Model.DataModels
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public IList<Order>? Orders { get; set; }
    }
}