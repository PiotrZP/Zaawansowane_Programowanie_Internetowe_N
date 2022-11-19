using WebStore.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels.Vm;

namespace WebStore.Web.Controllers
{
    public class AddressApiContorller : BaseApiController
    {
        private readonly IAddressService _addressService;

        public AddressApiContorller(ILogger logger, IMapper mapper, IAddressService addressService)
        : base(logger, mapper)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var addresses = _addressService.GetAddresses();
                return Ok(addresses);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error Occurr");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            try
            {
                var address = _addressService.GetAddress(a => a.Id == id);
                return Ok(address);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error Occurr");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        private IActionResult PostOrPutHelper(AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(_addressService.AddOrUpdateAddress(addOrUpdateAddressVm));
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _addressService.DeleteAddress(a => a.Id == id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }
 
    }
}