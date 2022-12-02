namespace WebStore.ViewModels.VM

{
    public class StationaryStoreEmployeeVm
    {
         public int AggreementNumber {get; set;} 
        public DateTime EmploymentDate {get; set;} 

        public string Position {get; set;} = default!;
        
        public decimal Salary {get; set;} = default!;
    }
}