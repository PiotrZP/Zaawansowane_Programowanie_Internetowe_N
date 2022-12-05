using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class StoreVm
    {
        public int StationaryStoreId { get; set; }
        public int AddressId { get; set; } = default!;
        public long AgreementNumber { get; set; } = default!;
    }
}