namespace WebStore.Model.Models;
public class Supplier : User
{
    public virtual IList<Product> Products { get; set; } = default!;
}