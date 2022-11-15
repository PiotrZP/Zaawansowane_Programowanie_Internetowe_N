using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Data;
using WebStore.Model.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;


namespace WebStore.Services.ConcreteServices
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            try
            {
                if (addOrUpdateAddressVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var addressEntity = Mapper.Map<Address>(addOrUpdateAddressVm);
                if (addOrUpdateAddressVm.Id.HasValue || addOrUpdateAddressVm.Id == 0)
                    DbContext.Addresses.Update(addressEntity);
                else
                    DbContext.Addresses.Add(addressEntity);
                DbContext.SaveChanges();
                return Mapper.Map<AddressVm>(addressEntity);
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
                    throw new ArgumentNullException("Filter expression parameter is null");
                var addressEntity = DbContext.Addresses.FirstOrDefault(filterExpression);
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpression = null)
        {
            try
            {
                var addressesQuery = DbContext.Addresses.AsQueryable();
                if (filterExpression != null)
                    addressesQuery = addressesQuery.Where(filterExpression);
                var addressVms = Mapper.Map<IEnumerable<AddressVm>>(addressesQuery);
                return addressVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;

            }
        }

        public bool DeleteAddress(Expression<Func<Address, bool>> filterExpression)
        {
            return true;
        }
    }
}