namespace WebStore.Model.DataModels;
public class StationaryStoreEmployee : User
{
   public int AggreementNumber {get; set;} 
   public DateTime Employment {get; set;} 
   public string Position {get; set;} = default!;
   public string Salary {get; set;} = default!;
   public virtual StationaryStore StationaryStore {get; set;} = default!;
   public int StationaryStoreId {get; set;} = default!;
    

}