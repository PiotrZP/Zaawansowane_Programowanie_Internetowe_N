using System.Linq.Expressions;
using Webstore.Model;
using WebStore.Model.DataModels;
using WebStore.ViewModels.Vm;

namespace WebStore.Services.Interface
{
    public interface IInvoiceService
    {
        InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm);
        InvoiceVm GetInvoice(Expression<Func<Invoice,bool>> filterExpression);
        IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice,bool>> ? filterExpression = null);

        IEnumerable<InvoiceVm> DeleteInvoice(Expression<Func<Invoice, bool>> filterExpression);

    }
}