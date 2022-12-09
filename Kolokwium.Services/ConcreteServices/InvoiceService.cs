using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.Models;
using Kolokwium.ViewModels.Interfaces;
using Kolokwium.ViewModels.VM;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        public InvoiceService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm)
        {
            try
            {
                if (addOrUpdateInvoiceVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var invoiceEntity = Mapper.Map<Invoice>(addOrUpdateInvoiceVm);
                if (addOrUpdateInvoiceVm.Id.HasValue || addOrUpdateInvoiceVm.Id == 0)
                    DbContext.
                    Invoices.Update(invoiceEntity);
                else
                    DbContext.Invoices.Add(invoiceEntity);
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

        public bool DeleteInvoice(Expression<Func<Invoice, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null) throw new ArgumentNullException("Filter param is null");
                var invoiceEntity = DbContext.Invoices.FirstOrDefault(filterExpression);
                if (invoiceEntity != null)
                {
                    DbContext.Invoices.Remove(invoiceEntity);
                    DbContext.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>>? filterExpression = null)
        {
            try
            {
                var invoiceQuery = DbContext.Invoices.AsQueryable();
                if (filterExpression != null)
                    invoiceQuery = invoiceQuery.Where(filterExpression);
                var invoiceVms = Mapper.Map<IEnumerable<InvoiceVm>>(invoiceQuery);
                return invoiceVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                    throw new ArgumentNullException("Filter expression parameter is null");
                var invoiceEntity = DbContext.Invoices.FirstOrDefault(filterExpression);
                var invoiceVm = Mapper.Map<InvoiceVm>(invoiceEntity);
                return invoiceVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}