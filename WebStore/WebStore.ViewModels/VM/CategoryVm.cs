namespace WebStore.ViewModels.VM;
public class CategoryVm
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Tag { get; set; } = default!;
    public IList<ProductVm> Products { get; set; } = default!;
}