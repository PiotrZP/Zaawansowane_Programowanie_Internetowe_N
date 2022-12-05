using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }
        public CustomerVm AddOrUpdateCustomer(AddOrUpdateCustomerVm addOrUpdateCustomerVm)
        {
            try
            {
                if (addOrUpdateCustomerVm == null)
                    throw new ArgumentNullException("View model parametr is null");
                var customerEntity = Mapper.Map<Customer>(addOrUpdateCustomerVm);
                if (addOrUpdateCustomerVm.Id.HasValue || addOrUpdateCustomerVm.Id == 0)
                    DbContext.Customers.Update(customerEntity);
                else
                    DbContext.Customers.Add(customerEntity);
                DbContext.SaveChanges();
                var addressVm = Mapper.Map<CustomerVm>(customerEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public CustomerVm GetCustomer(Expression<Func<Customer, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentException("Filter expression parameter is null");
                var customerEntity = DbContext.Customers.FirstOrDefault(filterExpression);
                var addressVm = Mapper.Map<CustomerVm>(customerEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<CustomerVm> GetCustomers(Expression<Func<Customer, bool>>? filterExpressions = null)
        {
            try
            {
                var customerQuery = DbContext.Customers.AsQueryable();
                if (filterExpressions != null)
                    customerQuery = customerQuery.Where(filterExpressions);
                var customerVms = Mapper.Map<IEnumerable<CustomerVm>>(customerQuery);
                return customerVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        bool ICustomerService.DeleteCustomer(Expression<Func<Customer, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}