using System.Linq.Expressions;
using WebStore.Model.Models;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces;
public interface IStoreService
{
    public StationaryStoreVm AddOrUpdateStationaryStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm);
    public StationaryStoreVm GetStationaryStore(Expression<Func<StationaryStore, bool>> filterExpression);
    public IEnumerable<StationaryStoreVm> GetStationaryStores(Expression<Func<StationaryStore, bool>>? filterExpression = null);
    public Task DeleteStationaryStore(Expression<Func<StationaryStore, bool>> filterExpression);
}
