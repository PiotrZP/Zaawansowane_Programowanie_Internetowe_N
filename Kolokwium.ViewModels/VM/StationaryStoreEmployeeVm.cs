using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class StationaryStoreEmployeeVm : UserVm
    {

        public string Position { get; set; } = default!;
        public Decimal Salary { get; set; } = default!;
        public StoreVm StationaryStore { get; set; } = default!;
    }
}