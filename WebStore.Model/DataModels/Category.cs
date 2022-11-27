using Microsoft.AspNetCore.Identity;
using System;

namespace WebStore.Model.DataModels
{
    public class Category
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;

        public string Tag { get; set; } = default !;

        public virtual IList<Product> Products { get; set; } = default!;

    }
}