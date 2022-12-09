using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Model.Models
{
    // id
    // Name
    // Tag
    // List of products
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Tag { get; set; } = default!;
        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; }

    }
}