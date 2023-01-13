using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class OrderVm
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmmount { get; }
        public long TrackingNumber { get; set; }
        public int InvoiceId { get; set; }

    }
}