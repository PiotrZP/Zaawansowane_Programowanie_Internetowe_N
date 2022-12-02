using System.Linq.Expressions;
using WebStore.Model.Models;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces;
public interface IProductService
{
    public ProductVm AddOrUpdateProduct(AddOrUpdateProductVm addOrUpdateProductVm);
    public ProductVm GetProduct(Expression<Func<Product, bool>> filterExpression);
    public IEnumerable<ProductVm> GetProducts(Expression<Func<Product, bool>>? filterExpression = null);
    public Task DeleteProduct(Expression<Func<Product, bool>> filterExpression);
}
