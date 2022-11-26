using System.ComponentModel.DataAnnotations;
using Webstore.Model;

namespace WebStore.ViewModels.Vm
{
    public class AddOrUpdateInvoiceVm
    {
        public int? Id {get; set;}

        [Required]
        public decimal TotalAmount {get; set;}

        public IList<Order>? Orders {get; set;} = default!;

       
    }
}