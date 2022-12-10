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

        public ICollection<OrderVm> Orders { get; set; } = default!;
        public AddressVm Addresses { get; set; } = default!;
        public ICollection<StationaryStoreEmployeeVm> Employees { get; set; } = default!;
    }
}