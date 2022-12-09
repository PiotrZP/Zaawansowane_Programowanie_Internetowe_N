using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.ViewModels.VM;
using Kolokwium.Model.Models;
using System.Linq.Expressions;
namespace Kolokwium.ViewModels.Interfaces
{
    public interface ICategoryService
    {
        CategoryVm AddOrUpdateCategory(AddOrUpdateCategoryVm addOrUpdateAddressVm);
        CategoryVm GetCategory(Expression<Func<Category, bool>> filterExpression);
        IEnumerable<CategoryVm> GetCategories(Expression<Func<Category, bool>>? filterExpression = null);
        bool DeleteCategory(Expression<Func<Category, bool>> filterExpression);

    }
}