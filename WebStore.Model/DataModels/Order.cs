using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;


public class Order
{
   public virtual Customer Customer {get; set;} = default!;
   [ForeignKey("Customer")]
   public int CustomerId { get; set; }
   public DateTime DeliveryDate {get; set;}  
   public int Id {get; set; }
   public DateTime OrderDate {get; set;}
   [Column(TypeName = "decimal(18,2)")]
   public decimal TotalAmount {get; set;} 
   public long TrackingNumber {get; set; }
   public virtual Invoice Invoice { get; set; } = default!;
   [ForeignKey("Invoice")]
   public int InvoiceId { get; set; }
   public virtual IList<OrderProduct> OrderProducts { get; set; } = default!;

}