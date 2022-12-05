using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kolokwium.Model.Models;
using Kolokwium.ViewModels.VM;

namespace Kolokwium.ViewModels.Interfaces
{
    public interface ICustomerService
    {
        CustomerVm AddOrUpdateCustomer(AddOrUpdateCustomerVm addOrUpdateCustomerVm);
        CustomerVm GetCustomer(Expression<Func<Customer, bool>> filterExpression);
        IEnumerable<CustomerVm> GetCustomers(Expression<Func<Customer, bool>>? filterExpression = null);
        bool DeleteCustomer(Expression<Func<Customer, bool>> filterExpression);
    }
}