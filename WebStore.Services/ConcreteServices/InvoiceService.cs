using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        public InvoiceService(WSDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) { }
        public InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm)
        {
            try
            {
                if (addOrUpdateInvoiceVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var invoiceEntity = Mapper.Map<Invoice>(addOrUpdateInvoiceVm);
                if (addOrUpdateInvoiceVm.Id.HasValue || addOrUpdateInvoiceVm.Id == 0)
                    DbContext.Invoice.Update(invoiceEntity);
                else
                    DbContext.Invoice.Add(invoiceEntity);
                DbContext.SaveChanges();
                var invoiceVm = Mapper.Map<InvoiceVm>(invoiceEntity);
                return invoiceVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> fileterExpression)
        {
            try
            {
                if (fileterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var invoiceEntity = DbContext.Invoice.FirstOrDefault(fileterExpression);
                var invoiceVm = Mapper.Map<InvoiceVm>(invoiceEntity);
                return invoiceVm;
            }

            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>>? fileterExpression = null)
        {
            try
            {
                var invoiceQuery = DbContext.Invoice.AsQueryable();
                if (fileterExpression != null)
                    invoiceQuery = invoiceQuery.Where(fileterExpression);
                var invoiceVm = Mapper.Map<IEnumerable<InvoiceVm>>(invoiceQuery);
                return invoiceVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
            bool IInvoiceService.DeleteInvoice(Expression<Func<Invoice, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}