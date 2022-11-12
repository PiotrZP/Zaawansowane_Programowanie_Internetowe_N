using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.Vm
{
    public class AddOrUpdateProductVm
    {
        public int? Id {get; set;}
        public int? CategoryId {get; set;}
        public int? SupplierId {get; set;}

        [Required]
        public string Description {get; set;} = default!;

        [Required]
        public byte[] ImageBytes {get; set;} = default!;

        [Required]
        public string Name {get; set;} = default!;

        [Required]
        public decimal Price {get; set;}

        [Required]
        public float Weight {get; set;}
        
        [Required]
        public int Quantity {get; set;}
    }
}