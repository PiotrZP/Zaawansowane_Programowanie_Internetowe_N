using System.Linq.Expressions;
using WebStore.Model.DataModels;
using WebStore.ViewModels.Vm;

namespace WebStore.Services.Interface
{
    public interface IInvoiceService
    {
        InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm);
        InvoiceVm GetInvoice(Expression<Func<Invoice,bool>> filterExpression);
        IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice,bool>> ? filterExpression = null);
    }
}