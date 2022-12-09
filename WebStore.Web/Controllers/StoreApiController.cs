using AutoMapper;
using Microsoft.AspNetCore.Mvc; 
using WebStore.Services.Interfaces; 
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers;

public class StoreApiController : BaseApiController
{ 
        private readonly IStoreService _storeService; 
        public StoreApiController(ILogger logger, IMapper mapper, 
                    IStoreService storeService) : 
                    base(logger, mapper) 
        { 
            _storeService = storeService; 
        } 
        [HttpGet] 
        public IActionResult Get() 
        { 
            try 
            { 
                var stores = _storeService.GetStationaryStores(); 
                return Ok(stores); 
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
                var store = _storeService.GetStationaryStores(s => s.Id == id); 
                return Ok(store); 
            } 
            catch (Exception ex) 
            { 
                Logger.LogError(ex, ex.Message); 
                return StatusCode(500, "Error occured"); 
            } 
        } 
        [HttpPut] 
        public IActionResult Put([FromBody] AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm) 
        { 
            return PostOrPutHelper(addOrUpdateStationaryStoreVm); 
        } 
        [HttpPost] 
        public IActionResult Post([FromBody] AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm) 
        { 
            return PostOrPutHelper(addOrUpdateStationaryStoreVm); 
        } 
        [HttpDelete("{id:int:min(1)}")] 
        public IActionResult Delete(int id) 
        { 
            try 
            { 
                var result = _storeService.DeleteStationaryStore(s => s.Id == id); 
                return Ok(result); 
            } 
            catch (Exception ex) 
            { 
                Logger.LogError(ex, ex.Message); 
                return StatusCode(500, "Error occured"); 
            } 
        } 
        private IActionResult PostOrPutHelper(AddOrUpdateStationaryStoreVm addOrUpdateStationaryStoreVm) 
        { 
            try 
            { 
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState); 
                return Ok(_storeService.AddOrUpdateStationaryStore(addOrUpdateStationaryStoreVm)); 
            } 
            catch (Exception ex) 
            { 
                Logger.LogError(ex.Message, ex); 
                return StatusCode(500, "Error occured"); 
            } 
        } 
    }