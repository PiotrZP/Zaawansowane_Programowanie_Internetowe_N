using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Web.Controllers;
public class InvoiceApiController : BaseApiController
{
    private readonly IInvoiceService _service;
    public InvoiceApiController(ILogger logger, IMapper mapper, IInvoiceService invoiceService) : base(logger, mapper)
    {
        _service = invoiceService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var invoices = _service.GetInvoices();
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    [HttpGet("{id:int:min(1)}")]
    public IActionResult Get(int id)
    {
        try
        {
            var invoice = _service.GetInvoice(p => p.Id == id);
            return Ok(invoice);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateInvoiceVm addOrUpdateInvoiceVm)
    {
        return PostOrPutHelper(addOrUpdateInvoiceVm);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateInvoiceVm addOrUpdateInvoiceVm)
    {
        return PostOrPutHelper(addOrUpdateInvoiceVm);
    }

    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _service.DeleteInvoice(p => p.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    private IActionResult PostOrPutHelper(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_service.AddOrUpdateInvoice(addOrUpdateInvoiceVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}