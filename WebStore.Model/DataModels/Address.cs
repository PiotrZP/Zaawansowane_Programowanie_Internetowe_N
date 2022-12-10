using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class Address
{
    public int? Id { get; set; } = default!;
    public string City { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
    public string Street { get; set; } = default!;
    public int BuildingNumber { get; set; }
    public int? ApartmentNumber { get; set; }
    public string Country { get; set; } = default!;
}