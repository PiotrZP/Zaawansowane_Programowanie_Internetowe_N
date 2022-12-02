using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM

{
    public class GetInvoiceVm
    {
        [Required]
        public int InvoiceId {get;set;}
    }
}