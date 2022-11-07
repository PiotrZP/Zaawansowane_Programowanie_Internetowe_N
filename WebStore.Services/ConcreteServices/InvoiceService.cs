using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Services.ConcreteServices;

public class InvoiceService : BaseService, IInvoiceService
{
    public InvoiceService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger){ }

    public InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm) {
        try {
            if (addOrUpdateInvoiceVm == null)
                throw new ArgumentNullException ("View model parameter is null");

            var invoiceEntity = Mapper.Map<Invoice> (addOrUpdateInvoiceVm);

            if (addOrUpdateInvoiceVm.InvoiceId.HasValue || addOrUpdateInvoiceVm.InvoiceId == 0)
                DbContext.Invoices.Update (invoiceEntity);
            else
                DbContext.Invoices.Add (invoiceEntity);

            DbContext.SaveChanges ();
            var invoiceVm = Mapper.Map<InvoiceVm> (invoiceEntity);
            return invoiceVm;
        } catch (Exception ex) {
            Logger.LogError (ex, ex.Message);
            throw;
        }
    }
    public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression){
        try {
            if (filterExpression == null)
                throw new ArgumentNullException ("Filter expression parameter is null");
            var invoiceEntity = DbContext.Invoices.FirstOrDefault (filterExpression);
            var productVm = Mapper.Map<InvoiceVm> (invoiceEntity);
            return productVm;
        } catch (Exception ex) {
            Logger.LogError (ex, ex.Message);
            throw;
        }
    }
}
