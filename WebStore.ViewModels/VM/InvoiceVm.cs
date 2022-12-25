namespace WebStore.ViewModels.VM
{
    public class InvoiceVm
    {
        public int Id { get; set; }

        public decimal TotalPrice {get; set;}

        public DateTime InvoiceDate { get; set; }
    }
}