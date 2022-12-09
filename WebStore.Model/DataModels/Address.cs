using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Address
    {

        public int? Id { get; set; } = default!;
        public string City { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        public string Street { get; set; } = default!;
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string Country { get; set; } = default!;
    }
}