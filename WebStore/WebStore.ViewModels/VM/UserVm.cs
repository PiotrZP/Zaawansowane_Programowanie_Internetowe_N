namespace WebStore.ViewModels.VM;
public class UserVm
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime RegistrationDate { get; set; }
}
