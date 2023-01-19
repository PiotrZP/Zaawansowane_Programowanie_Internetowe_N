using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateAddressVm
    {
        public int? Id { get; set; }
        public int? StationaryStoreId { get; set; }
        public int? CustomerId { get; set; }

        public string StreetName { get; set; } = default!;
        [Required]
        public string BuildingNumber { get; set; } = default!;
        public int? ApartmentNumber { get; set; } = default!;
        [Required]
        public string City { get; set; } = default!;
        [Required]
        public string ZipCode { get; set; } = default!;
    }
}