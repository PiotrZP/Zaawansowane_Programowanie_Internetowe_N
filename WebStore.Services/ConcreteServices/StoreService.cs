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
        public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) { }

        public StoreVm  AddOrUpdateStore(AddOrUpdateStoreVm addOrUpdateStoreVm){

            try{

            }
            catch(Exception ex){
                Logger.LogError(ex, ex.Message);
                throw;

            }

            if(addOrUpdateStoreVm == null)
                throw new ArgumentNullException("Viev model parameter is null");
            var storeEntity = Mapper.Map<StationaryStore>(addOrUpdateStoreVm);
            if(addOrUpdateStoreVm.Id.HasValue || addOrUpdateStoreVm.Id == 0)
                DbContext.StationaryStores.Update(storeEntity);
            else
                DbContext.StationaryStores.Add(storeEntity);
            DbContext.SaveChanges();
            var storeVm = Mapper.Map<StoreVm>(storeEntity);
            return storeVm;
        }

        public StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var storeEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var StoreVm = Mapper.Map<StoreVm>(storeEntity);
                return StoreVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StoreVm> GetStores(Expression<Func<StationaryStore, bool>>? filterExpression = null){
            try{
                var storesQuerry = DbContext.StationaryStores.AsQueryable();
                if(filterExpression != null)
                    storesQuerry = storesQuerry.Where(filterExpression);
                var storesVms = Mapper.Map<IEnumerable<StoreVm>>(storesQuerry);
                return storesVms; 
            }
            catch (Exception ex){
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public StoreVm DeleteStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var store = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var storeEntity = Mapper.Map<StationaryStore>(store);
                DbContext.StationaryStores.Remove(storeEntity);
                DbContext.SaveChanges();
                var storeVm = Mapper.Map<StoreVm>(storeEntity);
                return storeVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

    }
}