using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class CategoryVm
    {

        public CategoryVm()
        {
            Products = new HashSet<ProductVm>();
            return;
        }

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Tag { get; set; } = default!;
        public ICollection<ProductVm> Products { get; set; } = default!;
    }
}