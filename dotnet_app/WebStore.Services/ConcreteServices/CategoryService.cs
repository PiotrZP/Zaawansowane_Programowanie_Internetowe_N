using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }
        public CategoryVm AddOrUpdateCategory(AddOrUpdateCategoryVm addOrUpdateCategoryVm)
        {
            try
            {
                if (addOrUpdateCategoryVm == null)
                    throw new ArgumentNullException("View model parametr is null");
                var CategoryEntity = Mapper.Map<Category>(addOrUpdateCategoryVm);
                if (addOrUpdateCategoryVm.Id.HasValue || addOrUpdateCategoryVm.Id == 0)
                    DbContext.Categories.Update(CategoryEntity);
                else
                    DbContext.Categories.Add(CategoryEntity);
                DbContext.SaveChanges();
                var CategoryVm = Mapper.Map<CategoryVm>(CategoryEntity);
                return CategoryVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public CategoryVm GetCategory(Expression<Func<Category, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentException("Filter expression parameter is null");
                var CategoryEntity = DbContext.Categories.FirstOrDefault(filterExpression);
                var CategoryVm = Mapper.Map<CategoryVm>(CategoryEntity);
                return CategoryVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<CategoryVm> GetCategories(Expression<Func<Category, bool>>? filterExpressions = null)
        {
            try
            {
                var addresQuery = DbContext.Categories.AsQueryable();
                if (filterExpressions != null)
                    addresQuery = addresQuery.Where(filterExpressions);
                var CategoryVms = Mapper.Map<IEnumerable<CategoryVm>>(addresQuery);
                return CategoryVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        bool ICategoryService.DeleteCategory(Expression<Func<Category, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}