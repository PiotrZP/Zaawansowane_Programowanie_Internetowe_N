using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IAddressService
    {
        AddressVm AddOrUpdateAddress(AddOrUpdateAddressVm addOrUpdateAddressVm);
        AddressVm GetAddress(Expression<Func<Address, bool>> filterExpresion);
        IEnumerable<AddressVm> GetAddresses(Expression<Func<Address, bool>>? filterExpresion = null);
        bool DeleteAddress(Expression<Func<Address, bool>> filterExpression);
    }
}