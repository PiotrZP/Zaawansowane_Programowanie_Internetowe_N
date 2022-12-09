using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(WSDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }
        public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            try
            {
                if (addOrUpdateAddressVm == null)
                    throw new ArgumentNullException("View model parametr is null");
                var addressEntity = Mapper.Map<Address>(addOrUpdateAddressVm);
                if (addOrUpdateAddressVm.Id.HasValue || addOrUpdateAddressVm.Id == 0)
                    DbContext.Address.Update(addressEntity);
                else
                    DbContext.Address.Add(addressEntity);
                DbContext.SaveChanges();
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public AddressVm GetAddress(Expression<Func<Address, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentException("Filter expression parameter is null");
                var addressEntity = DbContext.Address.FirstOrDefault(filterExpression);
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpressions = null)
        {
            try
            {
                var addresQuery = DbContext.Address.AsQueryable();
                if (filterExpressions != null)
                    addresQuery = addresQuery.Where(filterExpressions);
                var addressVms = Mapper.Map<IEnumerable<AddressVm>>(addresQuery);
                return addressVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
            bool IAddressService.DeleteAddress(Expression<Func<Address, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}