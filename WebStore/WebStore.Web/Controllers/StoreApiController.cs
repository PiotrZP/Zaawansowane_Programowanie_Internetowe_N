using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers;

public class StoreApiController : BaseApiController
{
    private readonly IStoreService _service;
    public StoreApiController(ILogger logger, IMapper mapper, IStoreService stationaryStoreService) : base(logger, mapper)
    {
        _service = stationaryStoreService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var stationaryStorees = _service.GetStationaryStores();
            return Ok(stationaryStorees);
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
            var stationaryStore = _service.GetStationaryStore(p => p.Id == id);
            return Ok(stationaryStore);
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
            var result = _service.DeleteStationaryStore(p => p.Id == id);
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
            return Ok(_service.AddOrUpdateStationaryStore(addOrUpdateStationaryStoreVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}
