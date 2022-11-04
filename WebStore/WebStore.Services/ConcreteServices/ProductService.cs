using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices;
public class ProductService : BaseService, IProductService
{
    public ProductService(WSDbContext dbContext, IMapper mapper, ILogger logger)
    : base(dbContext, mapper, logger) { }

    public ProductVm AddOrUpdateProduct(AddOrUpdateProductVm addOrUpdateProductVm)
    {
        try
        {
            if (addOrUpdateProductVm == null)
                throw new ArgumentNullException("View model parameter is null");

            var productEntity = Mapper.Map<Product>(addOrUpdateProductVm);

            if (addOrUpdateProductVm.Id.HasValue || addOrUpdateProductVm.Id == 0)
                DbContext.Product.Update(productEntity);
            else
                DbContext.Product.Add(productEntity);

            DbContext.SaveChanges();

            var productVm = Mapper.Map<ProductVm>(productEntity);

            return productVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
    public ProductVm GetProduct(Expression<Func<Product, bool>> filterExpression)
    {
        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException("Filter expression parameter is null");
            var productEntity = DbContext.Product.FirstOrDefault(filterExpression);
            var productVm = Mapper.Map<ProductVm>(productEntity);
            return productVm;
        }

        catch (Exception ex)
        {
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
    public IEnumerable<ProductVm> GetProducts(Expression<Func<Product, bool>>? filterExpression = null)
    {
        try
        {
            var productsQuery = DbContext.Product.AsQueryable();
            if (filterExpression != null)
                productsQuery = productsQuery.Where(filterExpression);
            var productVms = Mapper.Map<IEnumerable<ProductVm>>(productsQuery);

            return productVms;
        }

        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public async Task DeleteProduct(int productId)
    {
        try
        {
            var productEntity = DbContext.Product
                .FirstOrDefault(x => x.Id == productId);

            if (productEntity == null)
            {
                throw new Exception("Product not found");
            }

            DbContext.Product.Remove(productEntity);

            await DbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
