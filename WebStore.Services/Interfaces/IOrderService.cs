using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels.VM;
using WebStore.Model.DataModels;

namespace WebStore.Services.Interfaces
{
    public interface IOrderService
    {
        OrderVm AddOrUpdateOrderVm(AddOrUpdateOrderVm orUpdateOrderVm);
        OrderVm GetOrder(Expression<Func<Order, bool>> filterExpression);
        IEnumerable<OrderVm> GetOrders(Expression<Func<Order, bool>>? filterExpression = null);
        bool DeleteOrder(Expression<Func<Order, bool>> filterExpression);
    }
}