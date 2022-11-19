using Microsoft.AspNetCore.Identity;
namespace WebStore.Model.DataModels;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime RegistrationDate { get; set; }
}