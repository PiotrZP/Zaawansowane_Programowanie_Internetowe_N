using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.Vm
{
    public class AddOrUpdateAddressVm
    {       
        public int? Id {get; set;}
        public int? StationaryStoreId {get; set;}    

        [Required]
        public string City {get; set;} = default!;
        
        [Required]
        public string Street {get; set;}= default!;
        
        [Required]
        public int ZipCode {get;set;}
    }
}