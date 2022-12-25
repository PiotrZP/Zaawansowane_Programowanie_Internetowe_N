using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels
{
    public class StationaryStore
    {
        public int Id { get; set; }
        //public virtual IList<Address> Address { get; set; } = default!;

        public virtual Address Address { get; set; } = default!;
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public virtual IList<StationaryStoreEmployee> Employees { get; set; } = default!;

    }
}