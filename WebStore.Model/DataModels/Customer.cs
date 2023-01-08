using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Customer : User
    {
        public IList<Address>? Addresses { get; set; }
        public string? BillingAdress { get; set; }
        public IList<Order>? Orders { get; set; }
        public string? ShippingAdress { get; set; }
    }
}