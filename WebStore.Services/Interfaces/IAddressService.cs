using System.Linq.Expressions;
using WebStore.Model.Models;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces;
public interface IAddressService
{
    public AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
    public AddressVm GetAddress(Expression<Func<Address, bool>> filterExpression);
    public IEnumerable<AddressVm> GetAddresss(Expression<Func<Address, bool>>? filterExpression = null);
    public Task DeleteAddress(Expression<Func<Address, bool>> filterExpression);
}
