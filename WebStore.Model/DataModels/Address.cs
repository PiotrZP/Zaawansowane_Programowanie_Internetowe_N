 using System.ComponentModel.DataAnnotations.Schema;
 using System.ComponentModel.DataAnnotations;
 using System;
 using Microsoft.AspNetCore.Identity;

 namespace WebStore.Model.DataModels {
     public class Address {

         public int Id { get; set; }

         [Required]
         public string City { get; set; } = default !;
         [Required]
         public string ZipCode { get; set; } = default !;
         [Required]
         public string Street { get; set; } = default !;
         [Required]
         public int BuildingNumber { get; set; } = default !;

         public int? ApartmentNumber { get; set; } = default !;

         //public virtual IList<StationaryStore> Employees { get; set; } = default!;

     }
 }