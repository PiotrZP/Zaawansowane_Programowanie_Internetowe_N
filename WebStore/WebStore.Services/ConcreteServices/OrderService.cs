using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices;
public class OrderService : BaseService, IOrderService
{
    public OrderService(WSDbContext context, IMapper mapper, ILogger logger) : base(context, mapper, logger) { }

    public OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm)
    {
        try
        {
            if (addOrUpdateOrderVm == null)
                throw new ArgumentNullException("View model parameter is null");

            var OrderEntity = Mapper.Map<Order>(addOrUpdateOrderVm);

            if (addOrUpdateOrderVm.Id.HasValue || addOrUpdateOrderVm.Id == 0)
                DbContext.Order.Update(OrderEntity);
            else
                DbContext.Order.Add(OrderEntity);

            DbContext.SaveChanges();

            var OrderVm = Mapper.Map<OrderVm>(OrderEntity);

            return OrderVm;
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
            var orderEntity = DbContext.Order.FirstOrDefault(filterExpression);
            var orderVm = Mapper.Map<OrderVm>(orderEntity);
            return orderVm;
        }

        catch (Exception ex)
        {
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
    public IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpression = null)
    {
        try
        {
            var ordersQuery = DbContext.Order.AsQueryable();
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

    public async Task DeleteOrder(Expression<Func<Order, bool>> filterExpression)
    {
        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException("Filter expression parameter is null");

            var orderEntity = DbContext.Order
                .FirstOrDefault(filterExpression);

            if (orderEntity == null)
            {
                throw new Exception("Order not found");
            }

            DbContext.Order.Remove(orderEntity);

            await DbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
