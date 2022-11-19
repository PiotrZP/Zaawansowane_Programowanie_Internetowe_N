using WebStore.ViewModels.Vm;
using System.Linq.Expressions;
using WebStore.Model.DataModels;

namespace WebStore.Services.Interface
{
    public interface IAddressService 
    {
        AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        AddressVm GetAddress(Expression<Func<Address,bool>> filterExpresion);
        IEnumerable<AddressVm> GetAddresses(Expression<Func<Address,bool>>? filterExpresion = null);
        public IEnumerable<AddressVm> DeleteAddress(Expression<Func<Address, bool>> filterExpression);
    }
}