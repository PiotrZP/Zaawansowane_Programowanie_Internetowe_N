using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Address
    {
        public string? StreetAdress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int StationaryStoreId { get; set; }
        public StationaryStore? StationaryStore { get; set; }
    }
}