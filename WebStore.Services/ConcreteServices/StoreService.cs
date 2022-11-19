// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using AutoMapper;
// using Microsoft.Extensions.Logging;
// using WebStore.DAL.EF;
// using WebStore.Model.DataModels;
// using WebStore.Services.Interfaces;
// using WebStore.ViewModels.VM;

// namespace WebStore.Services.ConcreteServices
// {
//     public class StoreService : BaseService, IStoreService
//     {
//         public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) { }

//         public StoreVm GetStore(Expression<Func<StationaryStore, bool>> filterExpression)
//         {
//             try
//             {
//                 if (filterExpression == null)
//                     throw new ArgumentNullException("Filter expression parameter is null");
//                 var storeEntity = DbContext.StationaryStores
//             }
//             catch (Exception ex)
//             {
//                 Logger.LogError(ex, ex.Message);
//                 throw;
//             }
//         }

//     }
// }