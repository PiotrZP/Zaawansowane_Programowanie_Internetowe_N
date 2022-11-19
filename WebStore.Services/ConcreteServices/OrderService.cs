using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Webstore.Model;
using WebStore.DAL.EF;
using WebStore.Services.Interface;
using WebStore.ViewModels.Vm;

namespace WebStore.Services.ConcreteServices
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
         : base(dbContext, mapper, logger)
        {
        }

        public OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm)
        {
            try 
            {
                if(addOrUpdateOrderVm == null)
                {
                    throw new ArgumentException ("View model parameter is null");
                }

                var productEntity = Mapper.Map<Order> (addOrUpdateOrderVm);

                if(addOrUpdateOrderVm.Id.HasValue || addOrUpdateOrderVm.Id == 0)
                {
                    DbContext.Orders.Update (productEntity);
                }
                else
                {
                    DbContext.Orders.Add (productEntity);
                }

                DbContext.SaveChanges();
                var orderVm = Mapper.Map<OrderVm> (productEntity);
                return orderVm;

            } 
            catch (Exception ex)
            {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public OrderVm GetOrder(Expression<Func<Order, bool>> filterExpression)
        {
            try
            {
                if(filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }
                var productEntity = DbContext.Orders.FirstOrDefault (filterExpression);
                var orderVm = Mapper.Map<OrderVm> (productEntity);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>> ? filterExpression = null)
        {
            try
            {
                var orderQuery = DbContext.Orders.AsQueryable();
                if(filterExpression != null)
                {
                    orderQuery = orderQuery.Where(filterExpression);
                }
                var orderVms = Mapper.Map<IEnumerable<OrderVm>> (orderQuery);
                return orderVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

          public bool DeleteOrder(Expression<Func<Order, bool>> filterExpression)
        {
            return true;
        }
    }
}