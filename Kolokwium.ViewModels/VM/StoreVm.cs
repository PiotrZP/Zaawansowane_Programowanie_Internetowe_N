using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class StoreVm
    {
        public int StationaryStoreId { get; set; }
        public int AgreementNumber { get; set; } = default!;
        public ICollection<OrderVm> Orders { get; set; } = default!;
        public AddressVm Addresses { get; set; } = default!;
        public ICollection<StationaryStoreEmployeeVm> Employees { get; set; } = default!;

    }
}