using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM

{
    public class AddOrUpdateOrderVm
    {
        public int? Id { get; set; }

        [Required]
        public int CustomerId { get; set; } = default!;

        public DateTime DeliveryDate { get; set; } = default!;

        [Required]
        public DateTime OrderDate {get;set;} = default!;

        [Required]
        public decimal TotalAmount {get;set;} = default!;

        public long TrackingNumber {get;set;} = default!;

        public int Invoiceid {get;set;} = default!;

    }
}