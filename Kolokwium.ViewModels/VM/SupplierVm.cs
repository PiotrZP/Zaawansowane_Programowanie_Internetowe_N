using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class SupplierVm : UserVm
    {
        public ICollection<ProductVm> Products { get; set; } = default!;
    }
}