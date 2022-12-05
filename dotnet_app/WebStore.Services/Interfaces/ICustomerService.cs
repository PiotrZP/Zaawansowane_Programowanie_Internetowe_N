using System.Linq.Expressions; 
using WebStore.Model.DataModels; 
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces { 
    public interface ICustomerService {
        CustomerVm AddOrUpdateCustomer (AddOrUpdateCustomerVm addOrUpdateCustomerVm);
        CustomerVm GetCustomer (Expression<Func<Customer, bool>> filterExpression);
        IEnumerable<CustomerVm> GetCustomers (Expression<Func<Customer, bool>> ? filterExpression = null);
        bool DeleteCustomer(Expression<Func<Customer, bool>> filterExpression);
    }
}