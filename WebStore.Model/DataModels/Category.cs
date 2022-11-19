using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Category
    {
        public string Name { get; set; } = default!;
        public int Id { get; set; }
        public string Tag { get; set; } = default!;
        public virtual IList<Product>? Products { get; set; }

    }
}