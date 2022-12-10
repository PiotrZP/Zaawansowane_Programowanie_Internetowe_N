using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.DataModels;

public class Address
{
    [Key]
    public int Id { get; set; }
    bool IsDeleted { get; set; }
    public string StreetName { get; set; } = default!;
    public string BuildingNumber { get; set; } = default!;
    public int? ApartmentNumber { get; set; }
    public string City { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; } = default!;
    [ForeignKey("StationaryStore")]
    public int? StationaryStoreId { get; set; }
    public virtual StationaryStore? StationaryStore { get; set; } = default!;
}
