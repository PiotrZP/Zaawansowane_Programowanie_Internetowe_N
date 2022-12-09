using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels;

public class CategoryVm
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Tag { get; set; } = default!;
}
