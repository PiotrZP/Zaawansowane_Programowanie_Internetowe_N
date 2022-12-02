namespace WebStore.Model.Models;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Tag { get; set; } = default!;
    public virtual IList<Product> Products { get; set; } = default!;
}