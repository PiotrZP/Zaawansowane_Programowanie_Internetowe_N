using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateCategoryVm
    {
        public int? Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Tag { get; set; } = default!;

    }
}