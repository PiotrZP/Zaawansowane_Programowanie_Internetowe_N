using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers;

public class CustomerApiController : BaseApiController
{
    private readonly ICustomerService _customerService;
    public CustomerApiController(ILogger logger, IMapper mapper, ICustomerService customerService) : base(logger, mapper)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<CustomerVm> customers = _customerService.GetCustomers();
            return Ok(customers);
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
            var address = _customerService.GetCustomers(a => a.Id == id);
            return Ok(address);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateCustomerVm addOrUpdateCustomerVm)
    {
        return PostOrPutHelper(addOrUpdateCustomerVm);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateCustomerVm addOrUpdateCustomerVm)
    {
        return PostOrPutHelper(addOrUpdateCustomerVm);
    }

    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _customerService.DeleteCustomer(a => a.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    private IActionResult PostOrPutHelper(AddOrUpdateCustomerVm addOrUpdateCustomerVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_customerService.AddOrUpdateCustomer(addOrUpdateCustomerVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }

    // CRUD actions
}

// public class AddressApiController : BaseApiController
// {
//     private readonly IAddressService _customerService;
//     public AddressApiController(ILogger logger, IMapper mapper,
//                 IAddressService addressService) :
//                 base(logger, mapper)
//     {
//         _customerService = addressService;
//     }
//     [HttpGet]
//     public IActionResult Get()
//     {
//         try
//         {
//             var addresses = _customerService.GetCustomers();
//             return Ok(addresses);
//         }
//         catch (Exception ex)
//         {
//             Logger.LogError(ex, ex.Message);
//             return StatusCode(500, "Error occured");
//         }
//     }

// }