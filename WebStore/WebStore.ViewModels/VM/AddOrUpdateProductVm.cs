using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM;

public class AddOrUpdateProductVm
{
    public int? Id { get; set; }
    [Required]
    public string Description { get; set; } = default!;
    public byte[]? ImageBytes { get; set; } = default!;
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public float Weight { get; set; }
    public int? CategoryId { get; set; }
    public int? SupplierId { get; set; }
}
