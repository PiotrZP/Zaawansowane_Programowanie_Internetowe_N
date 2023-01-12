using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class StoreService : BaseService, IStoreService
    {
        public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }


        public StoreVm AddOrUpdateStore(AddOrUpdateStoreVm addOrUpdateStoreVm)
        {
            try
            {
                if (addOrUpdateStoreVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var stationaryStoreEntity = Mapper.Map<StationaryStore>(addOrUpdateStoreVm);
                if (addOrUpdateStoreVm.Id.HasValue || addOrUpdateStoreVm.Id == 0)
                    DbContext.StationaryStores.Update(stationaryStoreEntity);
                else
                    DbContext.StationaryStores.Add(stationaryStoreEntity);
                DbContext.SaveChanges();
                var StoreVm = Mapper.Map<StoreVm>(stationaryStoreEntity);
                return StoreVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var stationaryStoreVm = Mapper.Map<StoreVm>(stationaryStoreEntity);
                return stationaryStoreVm;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null)
        {
            try
            {
                var stationaryStoresQuery = DbContext.StationaryStores.AsQueryable();
                if (filterExpression != null)
                    stationaryStoresQuery = stationaryStoresQuery.Where(filterExpression);
                var stationaryStoreVm = Mapper.Map<IEnumerable<StoreVm>>(stationaryStoresQuery);
                return stationaryStoreVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        bool IStoreService.DeleteStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}
