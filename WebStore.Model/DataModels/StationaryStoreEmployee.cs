using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class StationaryStoreEmployee : User
{
    public string Position { get; set; } = default!;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; } = default!;
    [ForeignKey("StationaryStore")]
    public int? StationaryStoreId { get; set; }
    public virtual StationaryStore StationaryStore { get; set; } = default!;
}