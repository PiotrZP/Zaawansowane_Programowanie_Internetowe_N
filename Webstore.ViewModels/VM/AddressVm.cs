namespace WebStore.ViewModels.VM;
public abstract class AddressVm
{
    public int Id { get; set; }
    public string City { get; set; } = default!;
    public string StreetName { get; set; } = default!;
    public int StreetNumber { get; set; } = default!;
    public string PostCode { get; set; } = default!;
}