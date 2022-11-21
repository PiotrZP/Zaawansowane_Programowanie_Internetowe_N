namespace WebStore.ViewModels.VM
{
    public class AddressVm
    {
        public int Id { get; set; }
        bool IsDeleted { get; set; }
        public string StreetName { get; set; } = default!;
        public string BuildingNumber { get; set; } = default!;
        public int? ApartmentNumber { get; set; }
        public string City { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        public int? CustomerId { get; set; }
        public virtual CustomerVm? Customer { get; set; } = default!;
        public int? StationaryStoreId { get; set; }
        public virtual StationaryStoreVm? StationaryStore { get; set; } = default!;
    }
}