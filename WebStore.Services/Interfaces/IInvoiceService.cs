using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Model.DataModels;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces
{
    public interface IInvoiceService
    {
        InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm);
        InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpresion);
        IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>>? filterExpresion = null);
        bool DeleteInvoice(Expression<Func<Invoice, bool>> filterExpression);
    }
}