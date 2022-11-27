using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebStore.Model.DataModels
{
    public class Customer : User
    {
        //public virtual IList<Address> Addresses { get; set; } = default!;

        public virtual Address BillingAddress { get; set; } = default!;
        [ForeignKey("BillingAddress")]
        public int? BillingAddressId { get; set; }


        public virtual Address ShippingAddress { get; set; } = default!;
        [ForeignKey("ShippingAddress")]
        public int? ShippingAddressId { get; set; }

        public virtual IList<Order> Orders { get; set; } = default!;

    }
}