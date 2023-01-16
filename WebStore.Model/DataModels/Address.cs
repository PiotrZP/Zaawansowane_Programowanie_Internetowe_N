using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.DataModels;

public class Address
{
    [Key]
    public int Id { get; set; }
    public string StreetName { get; set; } = default!;
    public string BuildingNumber { get; set; } = default!;
    public int? ApartmentNumber { get; set; }
    public string City { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
}