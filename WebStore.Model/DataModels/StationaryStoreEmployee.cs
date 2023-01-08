namespace WebStore.Model.DataModels
{
    public class StationaryStoreEmployee : User
    {
        public string? name { get; set; }
        public int empoyeeId { get; set; }
        public int StationaryStoreId { get; set; }
        public StationaryStore? StationaryStore { get; set; }
    }
}