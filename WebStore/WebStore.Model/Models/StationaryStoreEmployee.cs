namespace WebStore.Model.Models;
public class StationaryStoreEmployee : User
{
    public string Position { get; set; } = default!;
    public Decimal Salary { get; set; }
    public int StationaryStoreId { get; set; }
    public virtual StationaryStore StationaryStore { get; set; } = default!;
}