using System; 
using System.Collections.Generic; 
using System.Linq.Expressions; 
using WebStore.Model.DataModels; 
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces { 
    public interface IOrderService {
        OrderVm AddOrUpdateOrder (AddOrUpdateOrderVm addOrUpdateOrderVm);
        OrderVm DeleteOrder (DeleteOrderVm deleteOrderVm);
    }
}