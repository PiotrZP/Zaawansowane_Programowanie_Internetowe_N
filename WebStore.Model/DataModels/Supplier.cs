using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels;

public class Supplier
{
   public IList<Product> Products {get; set;} = default!;
}