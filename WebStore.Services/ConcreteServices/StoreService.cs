using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
  public class StoreService : BaseService, IStoreService
  {
    public StoreService(WSDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
    {
    }

    public StationaryStoreVm AddOrUpdateStationaryStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
    {
      try
      {
        if (addOrUpdateStationaryStoreVm == null)
          throw new ArgumentNullException("View model parametr is null");
        var storeEntity = Mapper.Map<StationaryStore>(addOrUpdateStationaryStoreVm);
        if (addOrUpdateStationaryStoreVm.Id.HasValue || addOrUpdateStationaryStoreVm.Id == 0)
          DbContext.StationaryStore.Update(storeEntity);
        else
          DbContext.StationaryStore.Add(storeEntity);
        DbContext.SaveChanges();
        var StationaryStoreVm = Mapper.Map<StationaryStoreVm>(storeEntity);
        return StationaryStoreVm;
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
        var storeEntity = DbContext.StationaryStore.FirstOrDefault(filterExpression);
        var StationaryStoreVm = Mapper.Map<StationaryStoreVm>(storeEntity);
        return StationaryStoreVm;
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
        var storesQuery = DbContext.StationaryStore.AsQueryable();
        if (filterExpression != null)
          storesQuery = storesQuery.Where(filterExpression);
        var StationaryStoreVms = Mapper.Map<IEnumerable<StationaryStoreVm>>(storesQuery);
        return StationaryStoreVms;
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
}




