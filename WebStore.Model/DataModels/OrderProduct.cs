using Microsoft.AspNetCore.Identity;
using System;

namespace WebStore.Model.DataModels
{
    public class OrderProduct
    {
        public virtual Order Order { get; set; } = default!;
        public int OrderId { get; set; } = default!;

        public virtual Product Product { get; set; } = default!;

        public int ProductId { get; set; } = default!;

         public int Quantity { get; set; } = default!;

    }
}