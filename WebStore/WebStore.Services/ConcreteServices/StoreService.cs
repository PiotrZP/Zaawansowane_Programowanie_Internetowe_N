using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices;
public class StoreService : BaseService, IStoreService
{
    public StoreService(WSDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }

    public StationaryStoreVm AddOrUpdateStationaryStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
    {
        try
        {
            if (addOrUpdateStationaryStoreVm == null)
                throw new ArgumentNullException("View model parameter is null");

            var stationaryStoreEntity = Mapper.Map<StationaryStore>(addOrUpdateStationaryStoreVm);

            if (addOrUpdateStationaryStoreVm.Id.HasValue || addOrUpdateStationaryStoreVm.Id == 0)
                DbContext.StationaryStore.Update(stationaryStoreEntity);
            else
                DbContext.StationaryStore.Add(stationaryStoreEntity);

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
                throw new ArgumentNullException("Filter expression parameter is null");
            var stationaryStoreEntity = DbContext.StationaryStore.FirstOrDefault(filterExpression);
            var stationaryStoreVm = Mapper.Map<StationaryStoreVm>(stationaryStoreEntity);
            return stationaryStoreVm;
        }

        catch (Exception ex)
        {
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
    public IEnumerable<StationaryStoreVm> GetStationaryStores(Expression<Func<StationaryStore, bool>>? filterExpression = null)
    {
        try
        {
            var stationaryStoresQuery = DbContext.StationaryStore.AsQueryable();
            if (filterExpression != null)
                stationaryStoresQuery = stationaryStoresQuery.Where(filterExpression);
            var stationaryStoreVms = Mapper.Map<IEnumerable<StationaryStoreVm>>(stationaryStoresQuery);

            return stationaryStoreVms;
        }

        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public async Task DeleteStationaryStore(Expression<Func<StationaryStore, bool>> filterExpression)
    {
        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException("Filter expression parameter is null");

            var stationaryStoreEntity = DbContext.StationaryStore
                .FirstOrDefault(filterExpression);

            if (stationaryStoreEntity == null)
            {
                throw new Exception("StationaryStore not found");
            }

            DbContext.StationaryStore.Remove(stationaryStoreEntity);

            await DbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
