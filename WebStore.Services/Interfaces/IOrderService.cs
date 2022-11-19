using System.Linq.Expressions;
using Webstore.Model;
using WebStore.ViewModels.Vm;

namespace WebStore.Services.Interface
{
    public interface IOrderService
    {
        OrderVm AddOrUpdateOrder(AddOrUpdateOrderVm addOrUpdateOrderVm);
        OrderVm GetOrder(Expression<Func<Order,bool>> filterExpression);
        IEnumerable<OrderVm> GetOrders(Expression<Func<Order,bool>> ? filterExpression = null);

        bool DeleteOrder(Expression<Func<Order, bool>> filterExpression);
    }
}