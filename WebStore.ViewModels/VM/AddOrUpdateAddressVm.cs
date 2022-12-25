using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM

{
    public class AddOrUpdateAddressVm
    {
         public int? Id { get; set; }

         [Required]
         public string City { get; set; } = default !;
         [Required]
         public string ZipCode { get; set; } = default !;
         [Required]
         public string Street { get; set; } = default !;
         [Required]
         public int BuildingNumber { get; set; }

         public int? ApartmentNumber { get; set; }
    }
}