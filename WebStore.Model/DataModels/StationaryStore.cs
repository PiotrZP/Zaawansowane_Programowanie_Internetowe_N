using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class StationaryStore
{
    [Key]
    public int Id { get; set; }
    bool IsDeleted { get; set; }
    public string Name { get; set; } = default!;
    [NotMapped]
    public virtual Address Address { get; set; } = default!;
    public virtual IList<Order> Orders { get; set; } = default!;
    public virtual IList<Invoice> Invoices { get; set; } = default!;
    public virtual IList<StationaryStoreEmployee> StationaryStoreEmployees { get; set; } = default!;
    public virtual IList<Address> Addresses { get; set; } = default!;

}
