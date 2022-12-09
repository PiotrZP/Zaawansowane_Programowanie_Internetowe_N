using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.DataModels;


public class Category
{
    [Key]
    public int Id { get; set; }
    bool IsDeleted { get; set; }
    public string Name { get; set; } = default!;
    public string Tag { get; set; } = default!;
    public virtual IList<Product>? Products { get; set; } = default!;
}
