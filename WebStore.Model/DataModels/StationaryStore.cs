using Microsoft.AspNetCore.Identity;
using System;

namespace WebStore.Model.DataModels
{
    public class StationaryStore
    {
        public int Id { get; set; }
        public virtual IList<Address> Address { get; set; } = default!;

        public virtual IList<StationaryStoreEmployee> Employees { get; set; } = default!;

    }
}