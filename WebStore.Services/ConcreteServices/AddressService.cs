using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices;

public class AddressService : BaseService, IAddressService
{
    public AddressService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger){ }

    
    public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateStoreVm)
    {
        try {
            if (addOrUpdateStoreVm == null)
                throw new ArgumentNullException ("View model parameter is null");
            var addressEntity = Mapper.Map<Address> (addOrUpdateStoreVm);
            if (addOrUpdateStoreVm.Id.HasValue || addOrUpdateStoreVm.Id == 0)
                DbContext.Addresses.Update (addressEntity);
            else
                DbContext.Addresses.Add (addressEntity);
            DbContext.SaveChanges ();
            var addressVm = Mapper.Map<AddressVm> (addressEntity);
            return addressVm;
        } catch (Exception ex) {
            Logger.LogError (ex, ex.Message);
            throw;
        }
    }

    public AddressVm GetAddress(Expression<Func<Address, bool>> ? filterExpression = null)
    {
        try {
            if (filterExpression == null)
                throw new ArgumentNullException ("Filter expression parameter is null");
            var addressEntity = DbContext.Addresses.FirstOrDefault (filterExpression);
            var storeVm = Mapper.Map<AddressVm> (addressEntity);
            return storeVm;
        } catch (Exception ex) {
            {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }
    }

    public async Task DeleteAddress(Expression<Func<Address, bool>> filterExpression)
    {
        try {
            if (filterExpression == null) {
                throw new ArgumentNullException("Filter expression parameter is null");
            }

            var addressEntity = DbContext.Addresses.FirstOrDefault(filterExpression);

            if (addressEntity == null) {
                throw new Exception("Product not found");
            }

            DbContext.Addresses.Remove(addressEntity);

            await DbContext.SaveChangesAsync();

        }catch(Exception ex) {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
    
}
