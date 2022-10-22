using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels
{
    public class StationaryStore : Order
    {
        public virtual Address Address { get; set; } = default!;
        public virtual IList<Order> Orders { get; set; } = default!;

        public virtual Address Addresses { get; set; } = default!;
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public virtual IList<StationeryStoreEmployee> StationeryStoreEmployees { get; set; } = default!;
        
    }
}