using Webstore.Model;

namespace WebStore.ViewModels.Vm
{
    public class InvoiceVm
    {
       public int? Id {get; set;}
        public decimal TotalAmount {get; set;}

        public virtual IList<Order> Orders {get; set;} = default!;
    }
}