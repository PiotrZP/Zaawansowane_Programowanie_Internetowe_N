 using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels
{
    public class Address
    {

        public int Id { get; set; }
       //public virtual Customer Customer { get; set; } = default!;
        //[ForeignKey("Customer")]
        //public int? CustomerId { get; set; }

        //public virtual IList<Customer> Customers { get; set; } = default!;

        //public virtual IList<Adress> CustomersShipp { get; set; } = default!;

        public virtual StationaryStore StationaryStore { get; set; } = default!;
        [ForeignKey("StationaryStore")]
        public int? StationaryStoreId { get; set; }

        public string City { get; set; } = default!;

        public string ZipCode { get; set; } = default!;

        public string Street { get; set; } = default!;

        public string StreetNumber { get; set; } = default!;

        public string BuildingNumber { get; set; }= default!;

        public string ApartmentNumber { get; set; }= default!;

    }
}