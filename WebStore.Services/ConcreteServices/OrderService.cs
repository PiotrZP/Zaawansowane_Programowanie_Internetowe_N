using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Data;
using WebStore.Model.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm)
        {
            try
            {
                if (addOrUpdateOrderVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var orderEntity = Mapper.Map<Order>(addOrUpdateOrderVm);
                if (addOrUpdateOrderVm.Id.HasValue || addOrUpdateOrderVm.Id == 0)
                    DbContext.Orders.Update(orderEntity);
                else
                    DbContext.Orders.Add(orderEntity);
                DbContext.SaveChanges();
                return Mapper.Map<OrderVm>(orderEntity);
            }

            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public OrderVm GetOrder(Expression<Func<Order, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var orderEntity = DbContext.Orders.FirstOrDefault(filterExpression);
                var orderVm = Mapper.Map<OrderVm>(orderEntity);
                return orderVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpression = null)
        {
            try
            {
                var ordersQuery = DbContext.Orders.AsQueryable();
                if (filterExpression != null)
                    ordersQuery = ordersQuery.Where(filterExpression);
                var orderVms = Mapper.Map<IEnumerable<OrderVm>>(ordersQuery);
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
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var orderEntity = DbContext.Orders.FirstOrDefault(filterExpression);
                if (orderEntity != null)
                {
                    DbContext.Orders.Remove(orderEntity);
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