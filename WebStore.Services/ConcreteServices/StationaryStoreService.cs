using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class StationaryStoreService : BaseService, IStationaryStoreService
    {
        public StationaryStoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }
        public StationaryStoreVm AddOrUpdateStationaryStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
        {
            try
            {
                if (addOrUpdateStationaryStoreVm == null)
                    throw new ArgumentNullException("View model parametr is null");
                var stationaryStoreEntity = Mapper.Map<StationaryStore>(addOrUpdateStationaryStoreVm);
                if (addOrUpdateStationaryStoreVm.Id != 0)
                    DbContext.StationaryStores.Update(stationaryStoreEntity);
                else
                    DbContext.StationaryStores.Add(stationaryStoreEntity);
                DbContext.SaveChanges();
                var stationaryStoreVm = Mapper.Map<StationaryStoreVm>(stationaryStoreEntity);
                return stationaryStoreVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public StationaryStoreVm GetStationaryStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentException("Filter expression parameter is null");
                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                var stationaryStoreVm = Mapper.Map<StationaryStoreVm>(stationaryStoreEntity);
                return stationaryStoreVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<StationaryStoreVm> GetStationaryStores(Expression<Func<StationaryStore, bool>>? filterExpressions = null)
        {
            try
            {
                var stationaryStoreQuery = DbContext.StationaryStores.AsQueryable();
                if (filterExpressions != null)
                    stationaryStoreQuery = stationaryStoreQuery.Where(filterExpressions);
                var stationaryStoreVms = Mapper.Map<IEnumerable<StationaryStoreVm>>(stationaryStoreQuery);
                return stationaryStoreVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public bool DeleteStationaryStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault(filterExpression);
                if (stationaryStoreEntity != null)
                {
                    DbContext.StationaryStores.Remove(stationaryStoreEntity);
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