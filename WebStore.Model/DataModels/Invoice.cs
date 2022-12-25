using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels {
    public class Invoice {
        public int Id { get; set; }

        [Column (TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } = default !;

        public DateTime InvoiceDate { get; set; }

        public virtual IList<Order> Orders {get; set;} = default!;
        /*
        public virtual Order Order { get; set; } = default !;

        [ForeignKey ("Order")]
        public int OrderId { get; set; }
        */
    }
}