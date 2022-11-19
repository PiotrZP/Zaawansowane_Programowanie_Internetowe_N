using System.Linq.Expressions;
using Webstore.Model;
using WebStore.Model.DataModels;

namespace WebStore.Services.Interface
{
    public interface IAddressService 
    {
        AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        AddressVm GetAddress(Expression<Func<Address,bool>> filterExpresion);
        IEnumerable<AddressVm> GetAddresses(Expression<Func<Address,bool>>? filterExpresion = null);

          bool DeleteAddress(Expression<Func<Address, bool>> filterExpression);
    }
}