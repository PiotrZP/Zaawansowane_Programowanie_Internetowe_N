using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Data;
using WebStore.Model.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;


namespace WebStore.Services.ConcreteServices
{
    public class StoreService : BaseService, IStoreService
    {

        public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public StationaryStoreVm AddOrUpdateStore(AddOrUpdateStoreVm addOrUpdateStoreVm)
        {
            try
            {
                if (addOrUpdateStoreVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var storeEntity = Mapper.Map<StationaryStore>(addOrUpdateStoreVm);
                if (addOrUpdateStoreVm.Id.HasValue || addOrUpdateStoreVm.Id == 0)
                    DbContext.StationaryStores.Update(storeEntity);
                else
                    DbContext.StationaryStores.Add(storeEntity);
                DbContext.SaveChanges();
                return Mapper.Map<StationaryStoreVm>(storeEntity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StationaryStoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var storeEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var storeVm = Mapper.Map<StationaryStoreVm>(storeEntity);
                return storeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<StationaryStoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null)
        {
            try
            {
                var storesQuery = DbContext.StationaryStores.AsQueryable();
                if (filterExpression != null)
                    storesQuery = storesQuery.Where(filterExpression);
                var storesVms = Mapper.Map<IEnumerable<StationaryStoreVm>>(storesQuery);
                return storesVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;

            }
        }

        public bool DeleteStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var storeEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                if (storeEntity != null)
                {
                    DbContext.StationaryStores.Remove(storeEntity);
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
    }
}