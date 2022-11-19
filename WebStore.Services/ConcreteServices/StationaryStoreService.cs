using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interface;
using WebStore.ViewModels.Vm;

namespace WebStore.Services.ConcreteServices
{
    public class StationaryStoreService : BaseService, IStationaryStoreService
    {
        public StationaryStoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
        : base(dbContext, mapper, logger)
        {
        }

        public StationaryStoreVm AddOrUpdateStationaryStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm)
        {
                        try 
            {
                if(addOrUpdateStationaryStoreVm == null)
                {
                    throw new ArgumentException ("View model parameter is null");
                }
                    
                var stationaryStoreEntity = Mapper.Map<StationaryStore> (addOrUpdateStationaryStoreVm);

                if(addOrUpdateStationaryStoreVm.Id.HasValue || addOrUpdateStationaryStoreVm.Id == 0)
                {
                    DbContext.StationaryStores.Update (stationaryStoreEntity);
                }
                else
                {
                    DbContext.StationaryStores.Add (stationaryStoreEntity);
                }

                DbContext.SaveChanges();
                var stationaryStoreVm = Mapper.Map<StationaryStoreVm> (stationaryStoreEntity);
                return stationaryStoreVm;

            } 
            catch (Exception ex)
            {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StationaryStoreVm> GetStationaryStores(Expression<Func<StationaryStore, bool>>? filterExpression = null)
        {
            try
            {
                var stationaryStoreQuery = DbContext.StationaryStores.AsQueryable();
                if(filterExpression != null)
                {
                    stationaryStoreQuery = stationaryStoreQuery.Where(filterExpression);
                }
                var stationaryStoreVms = Mapper.Map<IEnumerable<StationaryStoreVm>> (stationaryStoreQuery);
                return stationaryStoreVms;
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
                if(filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }
                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault (filterExpression);
                var stationaryStoreVm = Mapper.Map<StationaryStoreVm> (stationaryStoreEntity);
                return stationaryStoreVm;
            }
            catch (Exception ex)
            {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<StationaryStoreVm> DeleteStationaryStore(Expression<Func<StationaryStore, bool>> filterExpression)
        {
            try
            {
                if(filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }
                var stationaryStoreEntity = DbContext.StationaryStores.FirstOrDefault (filterExpression);
                
                if(stationaryStoreEntity == null)
                {
                    throw new ArgumentException("Incorrect filter expression");
                }

                DbContext.StationaryStores.Remove(stationaryStoreEntity);
                DbContext.SaveChanges();
                return GetStationaryStores();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        //TODO: Add service - Add element to list 
        //TODO: Add service - Remove element from list
    }
}