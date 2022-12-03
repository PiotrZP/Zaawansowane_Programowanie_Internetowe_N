using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class InvoiceVm
    {
        public int InvoiceId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}