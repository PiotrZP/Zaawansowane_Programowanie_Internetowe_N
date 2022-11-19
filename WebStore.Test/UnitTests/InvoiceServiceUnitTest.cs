using WebStore.DAL.EF; 
using WebStore.Services.Interface; 
using WebStore.ViewModels.Vm; 


namespace WebStore.Test.UnitTest
{
    public class InvoiceServiceUnitTest : BaseUnitTest
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceServiceUnitTest(ApplicationDbContext dbContext, IInvoiceService invoiceService) 
        :base(dbContext)
        {
            _invoiceService = invoiceService;
        }

        [Fact]
        public void GetInvoiceTest()
        {
            
            var invoice = _invoiceService.GetInvoice(i => i.TotalAmount  == 20);
            Assert.NotNull (invoice); 
        }

        [Fact]
        public void GetMultipleInvoicesTest()
        {
            var invoices = _invoiceService.GetInvoices(o => o.Id >= 1 && o.Id <= 2);
            Assert.NotNull(invoices);
            Assert.NotEmpty(invoices);
            Assert.Equal(2, invoices.Count());
        }

        [Fact]
        public void GetAllinvoicesTest()
        {
            var invoices = _invoiceService.GetInvoices();
            Assert.NotNull(invoices);
            Assert.NotEmpty(invoices);
            //TODO: zmiana 
            Assert.Equal(DbContext.Invoices.Count(), invoices.Count());
        }

        [Fact]
        public void AddNewinvoiceTest()
        {
            var newInvoiceVm = new AddOrUpdateInvoiceVm
            {
                TotalAmount = 500
            };
            var createdInvoice = _invoiceService.AddOrUpdateInvoice(newInvoiceVm);
            Assert.NotNull(createdInvoice);
            Assert.Equal(500, createdInvoice.TotalAmount);
        }

        [Fact]
        public void UpdateinvoiceTest()
        {
            var updateinvoiceVm = new AddOrUpdateInvoiceVm()
            {
                Id = 1,
                TotalAmount = 900
            };

            var editedInvoiceVm = _invoiceService.AddOrUpdateInvoice (updateinvoiceVm);
            Assert.NotNull(editedInvoiceVm);
            Assert.Equal(900, editedInvoiceVm.TotalAmount);
        }

        [Fact]
        public void DeleteInvoiceTest()
        {
            var changeInvoices = _invoiceService.DeleteInvoice(i => i.Id == 1);
            Assert.Equal(1, changeInvoices.Count());
        }
    }
}