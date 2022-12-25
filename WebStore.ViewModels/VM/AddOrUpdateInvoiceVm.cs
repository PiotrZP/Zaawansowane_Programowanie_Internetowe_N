using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM

{
    public class AddOrUpdateInvoiceVm
    {
        public int? Id { get; set; }

        [Required]
        public decimal TotalPrice { get; set; } 

        [Required]
        public DateTime InvoiceDate { get; set; }
    }
}