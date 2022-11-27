using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels
{
    public class Product
    {
        public virtual Supplier Supplier { get; set; } = default!;
        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }

        public virtual Category Category { get; set; } = default!;
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual IList<OrderProduct> ProductOrders {get; set; } =default!;
        
        public virtual IList<ProductStock> ProductStocks { get; set; } = default!;

        public string Description { get; set; } = default!;

        [Key]
         public int Id { get; set; } = default!;

         public byte[] ImageBytes { get; set; } = default!;

         public string Name { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
         public decimal Price { get; set; } = default!;

         public float Weight { get; set; } = default!;

    }
}