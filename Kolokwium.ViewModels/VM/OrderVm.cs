using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class OrderVm
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }

    }
}