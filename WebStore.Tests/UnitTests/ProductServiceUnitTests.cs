using Microsoft.EntityFrameworkCore;
using WebStore.DAL.DatabaseContext;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTests;
public class ProductServiceUnitTests : BaseUnitTests
{
    private readonly IProductService _service;
    private readonly WSDbContext _context;
    public ProductServiceUnitTests(WSDbContext dbContext,
        IProductService productService) : base(dbContext)
    {
        _service = productService;
        _context = dbContext;
    }

    [Fact]
    public void GetProductTest()
    {
        var product = _service.GetProduct(p => p.Name == "Monitor Dell 32");
        Assert.NotNull(product);
    }

    [Fact]
    public void GetMultipleProductsTest()
    {
        var products = _service.GetProducts(p => p.Id >= 1 && p.Id <= 2);
        Assert.NotNull(products);
        Assert.NotEmpty(products);
        Assert.Equal(2, products.Count());
    }

    [Fact]
    public void GetAllProductsTest()
    {
        var products = _service.GetProducts();
        Assert.NotNull(products);
        Assert.NotEmpty(products);
        Assert.Equal(products.Count(), products.Count());
    }

    [Fact]
    public void AddNewProductTest()
    {
        var newProductVm = new AddOrUpdateProductVm()
        {
            Name = "MacBook Pro",
            CategoryId = 1,
            SupplierId = 1,
            ImageBytes = new byte[] {
         0xff,
         0xff,
         0xff,
         0x80
         },
            Price = 6000,
            Weight = 1.1f,
            Description = "MacBook Pro z procesorem M1 8GB RAM, Dysk 256 GB"
        };
        var createdProduct = _service.AddOrUpdateProduct(newProductVm);
        Assert.NotNull(createdProduct);
        Assert.Equal("MacBook Pro", "MacBook Pro");
    }

    [Fact]
    public void UpdateProductTest()
    {
        var updateProductVm = new AddOrUpdateProductVm()
        {
            Id = 1,
            Description = "Bardzo praktyczny monitor 32 cale",
            ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 },
            Name = "Monitor Dell 32",
            Price = 2000,
            Weight = 20,
            CategoryId = 1,
            SupplierId = 1
        };
        var editedProductVm = _service.AddOrUpdateProduct(updateProductVm);
        Assert.NotNull(editedProductVm);
        Assert.Equal("Monitor Dell 32", editedProductVm.Name);
        Assert.Equal(2000, editedProductVm.Price);
    }

    [Fact]
    public async Task DeleteProductTest()
    {
        int productId = 2;

        bool doesProductExistsBefore = await _context.Product.AnyAsync(x => x.Id == productId);
        await _service.DeleteProduct(x => x.Id == productId);
        bool doesProductExistsAfter = await _context.Product.AnyAsync(x => x.Id == productId);

        Assert.True(doesProductExistsBefore);
        Assert.False(doesProductExistsAfter);
    }
}
