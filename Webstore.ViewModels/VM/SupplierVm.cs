namespace WebStore.ViewModels.VM;
public class SupplierVm : UserVm
{
    public IList<ProductVm> Products { get; set; } = default!;
}