using Microsoft.AspNetCore.Identity;
using System;

namespace WebStore.Model.DataModels
{
    public class Supplier : User
    {
        public virtual IList<Product> Products { get; set; } = default!;
    }
}