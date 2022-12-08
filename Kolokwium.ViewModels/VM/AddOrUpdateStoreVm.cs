using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class AddOrUpdateStoreVm
    {
        public int? Id { get; set; }
        [Required]
        public int AgreementNumber { get; set; } = default!;

    }
}