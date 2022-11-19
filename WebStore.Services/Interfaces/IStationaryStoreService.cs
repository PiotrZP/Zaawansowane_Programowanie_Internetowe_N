using System.Linq.Expressions;
using Webstore.Model;
using WebStore.ViewModels.Vm;

namespace WebStore.Services.Interface
{
    public interface IStationaryStoreService
    {
        StationaryStoreVm AddOrUpdateStationaryStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm);
        StationaryStoreVm GetStationaryStore(Expression<Func<StationaryStore,bool>> filterExpression);
        IEnumerable<StationaryStoreVm> GetStationaryStores (Expression<Func<StationaryStore,bool>>? filterExpression = null);

        bool DeleteStore(Expression<Func<StationaryStore, bool>> filterExpression);
    }
}