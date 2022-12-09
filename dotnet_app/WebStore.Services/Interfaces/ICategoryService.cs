using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface ICategoryService
    {
        CategoryVm AddOrUpdateCategory(AddOrUpdateCategoryVm addOrUpdateCategoryVm);
        CategoryVm GetCategory(Expression<Func<Category, bool>> filterExpression);
        IEnumerable<CategoryVm> GetCategories(Expression<Func<Category, bool>>? filterExpression = null);
        bool DeleteCategory(Expression<Func<Category, bool>> filterExpression);
    }
}