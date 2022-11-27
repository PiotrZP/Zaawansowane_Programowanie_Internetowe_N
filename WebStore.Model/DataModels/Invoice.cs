using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System;

namespace WebStore.Model.DataModels
{
    public class Invoice
    {
        public int Id { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = default!;

        public virtual Customer Customer { get; set; } = default!;
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public virtual IList<Order> Orders { get; set;} = default!;
    }
}