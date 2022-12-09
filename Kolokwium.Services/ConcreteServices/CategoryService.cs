using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.Models;
using Kolokwium.ViewModels.Interfaces;
using Kolokwium.ViewModels.VM;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public CategoryVm AddOrUpdateCategory(AddOrUpdateCategoryVm addOrUpdateCategoryVm)
        {
            // check if
            if (addOrUpdateCategoryVm == null) throw new ArgumentNullException("View model param is null");

            // set mapper
            var categoryEntity = Mapper.Map<Category>(addOrUpdateCategoryVm);

            // check for update else Add
            if (addOrUpdateCategoryVm.Id.HasValue || addOrUpdateCategoryVm.Id == 0) DbContext.Categories.Update(categoryEntity);
            else DbContext.Categories.Add(categoryEntity);

            DbContext.SaveChanges();

            // reaturn categories
            var categoryVm = Mapper.Map<CategoryVm>(categoryEntity);

            return categoryVm;
        }

        public bool DeleteCategory(Expression<Func<Category, bool>> filterExpression)
        {
            try
            {
                // check filterExpression
                if (filterExpression == null) throw new ArgumentNullException("View model param is null");
                // set DbContext FirstOrDefault
                var categoryEntity = DbContext.Categories.FirstOrDefault(filterExpression);
                // check id enitiy is not null
                if (categoryEntity != null)
                {
                    // Remove categoryEntity
                    DbContext.Categories.Remove(categoryEntity);
                    // SaveDb
                    DbContext.SaveChanges();
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<CategoryVm> GetCategories(Expression<Func<Category, bool>>? filterExpression = null)
        {
            try
            {
                // 1. make as queryable
                var categoryQuery = DbContext.Categories.AsQueryable();
                // check filter expression if not null and do Where
                if (filterExpression != null) categoryQuery = categoryQuery.Where(filterExpression);
                // add Mapper entity
                var categoryVm = Mapper.Map<IEnumerable<CategoryVm>>(categoryQuery);
                return categoryVm;

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
                // check filterExpression
                if (filterExpression == null) throw new ArgumentNullException("View model param is null");
                // set DbContext FirstOrDefault
                var categoryEntity = DbContext.Categories.FirstOrDefault(filterExpression);
                // retrive from CategoryVm Mapper
                var categoryVm = Mapper.Map<CategoryVm>(categoryEntity);
                return categoryVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}