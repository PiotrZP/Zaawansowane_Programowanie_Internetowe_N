using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Product
    {
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Description { get; set; }
        public int Id { get; set; }
        public byte[]? ImageBytes { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public float Weight { get; set; }
        public IList<ProductStock>? ProductStocks { get; set; }
        public IList<OrderProduct>? OrderProducts { get; set; }
    }
}