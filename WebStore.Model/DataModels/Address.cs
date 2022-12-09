namespace WebStore.Model.DataModels;
public class Address
{
    public int Id { get; set; }
    public string City { get; set; } = default!;
    public string StreetName { get; set; } = default!;
    public int StreetNumber { get; set; } = default!;
    public string PostCode { get; set; } = default!;
    public int? StationaryStoreId { get; set; }
    public virtual StationaryStore? StationaryStore { get; set; } = default!;
    public int? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; } = default!;
    public int? BillingCustomerId { get; set; }
    public virtual Customer? BillingCustomer { get; set; } = default!;
    public int? ShippingCustomerId { get; set; }
    public virtual Customer? ShippingCustomer { get; set; } = default!;
}