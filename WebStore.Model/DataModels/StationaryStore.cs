namespace WebStore.Model.DataModels
{
    public class StationaryStore
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Product>? Products { get; set; }
        public IList<Customer>? Customers { get; set; }
        public IList<Address>? Addresses { get; set; }
        public IList<StationaryStoreEmployee>? StationaryStoreEmployees { get; set; }
    }
}