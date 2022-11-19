using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class Customer : User {
   public virtual Address? BillingAddress { get; set; }
   [ForeignKey("BillingAdress")]
   public int? BillingAddressId { get; set; }
   public virtual Address? ShippingAddress { get; set; }
   [ForeignKey("ShippingAddress")]
   public int? ShippingAddressId { get; set; }

    public virtual IList<Order> Orders { get; set; } = default !;
    public virtual IList<Address> Addresses { get; set; } = default !;

}