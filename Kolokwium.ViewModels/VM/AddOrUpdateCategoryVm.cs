using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Kolokwium.ViewModels.VM
{
    public class AddOrUpdateCategoryVm
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Tag { get; set; } = default!;
        public ICollection<ProductVm> Products { get; set; } = default!;
        public AddOrUpdateCategoryVm()
        {
            Products = new HashSet<ProductVm>();
            return;
        }

    }
}