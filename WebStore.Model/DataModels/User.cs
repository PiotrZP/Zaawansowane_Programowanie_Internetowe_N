using Microsoft.AspNetCore.Identity;
namespace Webstore.Model;

public class User : IdentityUser<int> {
    public string FirstName {get; set;} = default!;
    public string LastName {get; set;} = default!;
    public DateTime RegistrationDate {get; set;}
}