using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.DatabaseContext;
using WebStore.Model.DataModels;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;
namespace WebStore.Tests.UnitTests
{
  public class InvoiceServiceUnitTests : BaseUnitTests
  {
    private readonly IInvoiceService _invoiceService;
    public InvoiceServiceUnitTests(WSDbContext dbContext,
    IInvoiceService invoiceService) : base(dbContext)
    {
      _invoiceService = invoiceService;
    }
    [Fact]
    public void GetInvoiceTest()
    {
      var invoice = _invoiceService.GetInvoice(i => i.TotalPrice == 100);
      Assert.NotNull(invoice);
    }
    [Fact]
    public void GetMultipleInvoicesTest()
    {
      var invoices = _invoiceService.GetInvoices(i => i.Id >= 1 && i.Id <= 2);
      Assert.NotNull(invoices);
      Assert.NotEmpty(invoices);
      Assert.Equal(2, invoices.Count());
    }
    [Fact]
    public void GetAllInvoicesTest()
    {
      var invoices = _invoiceService.GetInvoices();
      Assert.NotNull(invoices);
      Assert.NotEmpty(invoices);
      Assert.Equal(invoices.Count(), invoices.Count());
    }
    [Fact]
    public void AddNewInvoiceTest()
    {
      var newInvoiceVm = new AddOrUpdateInvoiceVm()
      {
        TotalPrice = 1000,
        Date = new DateTime(2022, 11, 11),
        StationaryStoreId = 3
      };
      var createdInvoice = _invoiceService.AddOrUpdateInvoice(newInvoiceVm);
      Assert.NotNull(createdInvoice);
      Assert.Equal(1000, createdInvoice.TotalPrice);
    }
    [Fact]
    public void UpdateInvoiceTest()
    {
      var updateInvoiceVm = new AddOrUpdateInvoiceVm()
      {
        Id = 1,
        TotalPrice = 10000,
        Date = new DateTime(2022, 11, 11),
        StationaryStoreId = 1
      };
      var editedInvoiceVm = _invoiceService.AddOrUpdateInvoice(updateInvoiceVm);
      Assert.NotNull(editedInvoiceVm);
      Assert.Equal(10000, editedInvoiceVm.TotalPrice);
      Assert.Equal(1, editedInvoiceVm.StationaryStoreId);
    }
  }
}