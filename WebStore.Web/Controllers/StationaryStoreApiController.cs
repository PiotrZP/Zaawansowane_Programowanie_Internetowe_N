using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interface;
using WebStore.ViewModels.Vm;
namespace WebStore.Web.Controllers;
public class StoreApiController : BaseApiController
{
    private readonly IStationaryStoreService _service;
    public StoreApiController(ILogger logger, IMapper mapper, IStationaryStoreService storeService) : base(logger, mapper)
    {
        _service = storeService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var stores = _service.GetStationaryStores();
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
            var store = _service.GetStationaryStore(p => p.Id == id);
            return Ok(store);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateStationaryStoreVm addOrUpdateStoreVm)
    {
        return PostOrPutHelper(addOrUpdateStoreVm);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateStationaryStoreVm addOrUpdateStoreVm)
    {
        return PostOrPutHelper(addOrUpdateStoreVm);
    }

    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _service.DeleteStore(p => p.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }

    private IActionResult PostOrPutHelper(AddOrUpdateStationaryStoreVm addOrUpdateStoreVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_service.AddOrUpdateStationaryStore(addOrUpdateStoreVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}