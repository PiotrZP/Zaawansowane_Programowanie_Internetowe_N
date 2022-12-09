using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
  public class AddOrUpdateAddressVm
  {
    public int? Id { get; set; }
    public int? StationaryStoreId { get; set; }
    public int? CustomerId { get; set; }
    public string City { get; set; } = default!;
    public string StreetName { get; set; } = default!;
    public int StreetNumber { get; set; } = default!;
    public string PostCode { get; set; } = default!;
  }

}