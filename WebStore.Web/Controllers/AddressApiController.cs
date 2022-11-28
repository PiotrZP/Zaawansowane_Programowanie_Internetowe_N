using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers;

public class AddressApiController : BaseApiController {
    private readonly IAddressService _addressService;
    public AddressApiController(ILogger logger, IMapper mapper, IAddressService addressService) : base(logger,mapper){
        _addressService = addressService;
    }

    [HttpGet("{id:int:min(1)}")]
    public IActionResult Get(int id){
        try{
            var address = _addressService.GetAddress(p => p.Id == id);
            return Ok(address);
        }catch(Exception ex){
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateAddressVm addOrUpdateAddress) {
        return PostOrPutHelper(addOrUpdateAddress);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateAddressVm addOrUpdateAddress) {
        return PostOrPutHelper(addOrUpdateAddress); 
    }

    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id) {
        try{
            var address = _addressService.DeleteAddress(p => p.Id == id);
            return Ok(address);
        }catch(Exception ex){
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    private IActionResult PostOrPutHelper(AddOrUpdateAddressVm addOrUpdateAddress) {
        try {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            return Ok(_addressService.AddOrUpdateAddress(addOrUpdateAddress));

        } catch (Exception ex) {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}