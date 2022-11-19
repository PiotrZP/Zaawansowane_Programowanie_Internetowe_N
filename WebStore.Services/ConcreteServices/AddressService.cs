using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interface;
using WebStore.ViewModels.Vm;

namespace WebStore.Services.ConcreteServices
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
        : base(dbContext, mapper, logger)
        {
        }

        public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            try
            {
                if(addOrUpdateAddressVm == null)
                {
                    throw new ArgumentException("View model parameter is NULL");
                }

                var addressEntity = Mapper.Map<StationaryStoreAddress>(addOrUpdateAddressVm);

                if(addOrUpdateAddressVm.Id.HasValue || addOrUpdateAddressVm.Id == 0)
                {
                    DbContext.Addresses.Update(addressEntity);
                }
                else
                {
                    DbContext.Addresses.Add(addressEntity);
                }

                DbContext.SaveChanges();
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex,ex.Message);
                throw;
            }
        }

        public AddressVm GetAddress(Expression<Func<Address, bool>> filterExpresion)
        {
            try
            {
                if(filterExpresion == null)
                {
                    throw new ArgumentNullException("Filter Expresion is null");
                }

                var addressEntity = DbContext.Addresses.FirstOrDefault(filterExpresion);
                var addressVm = Mapper.Map<AddressVm>(addressEntity);
                return addressVm;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpresion = null)
        {
            try
            {
                var addressQuery = DbContext.Addresses.AsQueryable();
                if(filterExpresion != null)
                {
                    addressQuery = addressQuery.Where(filterExpresion);
                }
                var addressVms = Mapper.Map<IEnumerable<AddressVm>>(addressQuery);
                return addressVms;

            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<AddressVm> DeleteAddress(Expression<Func<Address, bool>> filterExpression)
        {
            try
            {
                if(filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }
                var addressEntity = DbContext.Addresses.FirstOrDefault (filterExpression);
                
                if(addressEntity == null)
                {
                    throw new ArgumentException("Incorrect filter expression");
                }

                DbContext.Addresses.Remove(addressEntity);
                DbContext.SaveChanges();
                return GetAddresses();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        } 

    }

}