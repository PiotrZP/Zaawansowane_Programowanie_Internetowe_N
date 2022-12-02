using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.DataModels;

public class Invoice
{
    public int InvoiceId {get; set;}
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice {get; set;} 
    
    public DateTime InvoiceDate { get; set; } 
    public virtual IList<Order> Orders {get; set;} = default!;
}