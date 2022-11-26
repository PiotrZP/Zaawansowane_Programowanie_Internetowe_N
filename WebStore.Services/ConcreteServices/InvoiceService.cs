using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;
using WebStore.Services.Interface;
using WebStore.ViewModels.Vm;
using System;
using Webstore.Model;

namespace WebStore.Services.ConcreteServices
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        public InvoiceService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
        : base(dbContext, mapper, logger)
        {
        }

        public InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm)
        {
            try
            {
                if(addOrUpdateInvoiceVm == null)
                {
                    throw new ArgumentException("View model parameter is NULL");
                }

                var productEntity = Mapper.Map<Invoice> (addOrUpdateInvoiceVm);

                if(addOrUpdateInvoiceVm.Id.HasValue || addOrUpdateInvoiceVm.Id == 0)
                {
                    DbContext.Invoices.Update (productEntity);
                }
                else
                {
                    DbContext.Invoices.Add (productEntity);
                }

                DbContext.SaveChanges();
                var invoiceVm = Mapper.Map<InvoiceVm> (productEntity);
                return invoiceVm;
            }
            catch (Exception ex)
            {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression)
        {
            try
            {
                if(filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }

                var productEntity = DbContext.Invoices.FirstOrDefault(filterExpression);
                var invoiceVm = Mapper.Map<InvoiceVm> (productEntity);
                return invoiceVm; 
            }
            catch (Exception ex)
            {
                Logger.LogError (ex, ex.Message);
                throw;
            }
        }

        public IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>>? filterExpression = null)
        {
            try
            {
                var invoiceQuery = DbContext.Invoices.AsQueryable();
                if(filterExpression != null)
                {
                    invoiceQuery = invoiceQuery.Where(filterExpression);
                }
                var invoiceVms = Mapper.Map<IEnumerable<InvoiceVm>> (invoiceQuery);
                return invoiceVms;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

          public IEnumerable<InvoiceVm> DeleteInvoice(Expression<Func<Invoice, bool>> filterExpression)
        {
            try
            {
                if(filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }
                var invoiceEntity = DbContext.Invoices.FirstOrDefault (filterExpression);

                if(invoiceEntity == null)
                {
                    throw new ArgumentException("Incorrect filter expression");
                }

                DbContext.Invoices.Remove(invoiceEntity);
                DbContext.SaveChanges();
                return GetInvoices();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        //TODO: Add service - Add order to list
        //TODO: Add service - Add order to list
    }
}