using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels {
    public class Order {
        [Key]
        public int Id { get; set; } = default !;

        public virtual Customer Customer { get; set; } = default !;
        [ForeignKey ("Customer")]
        public int CustomerId { get; set; }


        public virtual Invoice Invoice { get; set; } = default!;
        [ForeignKey ("Invoice")]
        public int InvoiceId { get; set; } = default!;

        public DateTime DeliveryDate { get; set; } = default !;

        public DateTime OrderDate { get; set; } = default !;

        public long TrackingNumber { get; set; } = default !;

        public virtual IList<OrderProduct> ProductOrders { get; set; } = default !;

        [Column (TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = default !;
    }
}