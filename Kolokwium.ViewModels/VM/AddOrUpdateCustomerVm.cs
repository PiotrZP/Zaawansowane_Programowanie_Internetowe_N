using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.ViewModels.VM
{
    public class AddOrUpdateCustomerVm
    {
        public int? Id { get; set; }
        public int? BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
    }
}