using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StationaryStoreEmployee : User
{
   public int AggreementNumber {get; set;} 
   public DateTime EmploymentDate {get; set;} 

   public string Position {get; set;} = default!;
   
   [Column(TypeName = "decimal(18,2)")]
   public decimal Salary {get; set;} = default!;
   // public virtual StationaryStore StationaryStore {get; set;} = default!;
   // [ForeignKey("StationaryStore")]
   // public int StationaryStoreId {get; set;} = default!;
    

}