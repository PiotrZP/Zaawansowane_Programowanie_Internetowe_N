namespace WebStore.ViewModels.VM;
public class AddressVm
{
    public int Id { get; set; }
    public string City { get; set; } = default!;
    public string StreetName { get; set; } = default!;
    public int StreetNumber { get; set; } = default!;
    public string PostCode { get; set; } = default!;
    public int? CustomerId { get; set; }
    public int? StationaryStoreId { get; set; }
    public int? ShippingCustomerId { get; set; }
    public int? BillingCustomerId { get; set; }
}