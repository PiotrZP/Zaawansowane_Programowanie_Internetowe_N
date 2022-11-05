using System.ComponentModel.DataAnnotations;
using WebStore.Model.DataModels;

namespace WebStore.ViewModels.Vm
{
    public class AddOrUpdateInvoiceVm
    {
        public int? Id {get; set;}

        [Required]
        public decimal TotalAmount {get; set;}

        //[Required]
        // public IList<Order> Orders {get; set;} = default!;
    }
}