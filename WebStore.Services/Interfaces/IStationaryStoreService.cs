using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IStationaryStoreService
    {
        StationaryStoreVm AddOrUpdateStationaryStore(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm);
        StationaryStoreVm GetStationaryStore(Expression<Func<StationaryStore, bool>> filterExpresion);
        IEnumerable<StationaryStoreVm> GetStationaryStores(Expression<Func<StationaryStore, bool>>? filterExpresion = null);
        bool DeleteStationaryStore(Expression<Func<StationaryStore, bool>> filterExpression);
    }
}