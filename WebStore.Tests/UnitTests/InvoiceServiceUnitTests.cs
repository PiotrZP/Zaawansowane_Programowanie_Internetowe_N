using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using WebStore.DAL.EF; 
using WebStore.Model.DataModels; 
using WebStore.Services.Interfaces; 
using WebStore.ViewModels.VM; 
using Xunit; 

namespace WebStore.Tests.UnitTests { 
    public class InvoiceServiceUnitTests : BaseUnitTests { 
        private readonly IInvoiceService _invoiceService; 
        public InvoiceServiceUnitTests (ApplicationDbContext dbContext, 
        IInvoiceService invoiceService) : base (dbContext) { 
            _invoiceService = invoiceService; 
        } 
        
        [Fact]
        public void AddInvoiceTest () {
            var newInvoice = new AddOrUpdateInvoiceVm () { 
                Id = 1,
                TotalPrice = 100.00M,
                InvoiceDate = new DateTime(),
                Orders = {},
            }; 
            var createdInvoice = _invoiceService.AddOrUpdateInvoice (newInvoice); 
            Assert.NotNull (createdInvoice);
            Assert.Equal (1, createdInvoice.InvoiceId);
            Assert.Equal (100.00M, createdInvoice.TotalPrice);
        }

        [Fact]
        public void UpdateInvoice () { 
            var editedInvoiceVm = new AddOrUpdateInvoiceVm () { 
                Id = 1,
                TotalPrice = 100.00M,
                InvoiceDate = new DateTime(),
                Orders = {},
            }; 
            var editedOrderVm = _invoiceService.AddOrUpdateInvoice (editedInvoiceVm); 
            Assert.NotNull (editedInvoiceVm); 
            Assert.Equal (1, editedInvoiceVm.Id); 
            Assert.Equal (100.00M, editedOrderVm.TotalPrice); 
        } 

        [Fact]
        public void GetInvoiceTest () { 
            var invoice = _invoiceService.GetInvoice (p => p.TotalPrice == 100.00M);
            Assert.NotNull (invoice); 
        } 
    }
}