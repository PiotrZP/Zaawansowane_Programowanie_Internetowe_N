using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class OrderServices : BaseService, IOrderService
    {
        public OrderServices(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger) { }
        public OrderVm AddOrUpdateOrderVm(AddOrUpdateOrderVm addOrUpdateOrderVm)
        {
            try
            {
                if (addOrUpdateOrderVm == null)
                    throw new ArgumentNullException("View model parametr is null");
                var orderEntity = Mapper.Map<Order>(addOrUpdateOrderVm);
                if (addOrUpdateOrderVm.Id != 0)
                    DbContext?.Orders?.Update(orderEntity);
                else
                    DbContext?.Orders?.Add(orderEntity);
                DbContext?.SaveChanges();
                var orderVm = Mapper.Map<OrderVm>(orderEntity);
                return orderVm;
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
                    throw new ArgumentException("Filter expression parameter is null");
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
        public IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpressions = null)
        {
            try
            {
                var orderQuery = DbContext?.Orders?.AsQueryable();
                if (filterExpressions != null)
                    orderQuery = orderQuery.Where(filterExpressions);
                var orderVms = Mapper.Map<IEnumerable<OrderVm>>(orderQuery);
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