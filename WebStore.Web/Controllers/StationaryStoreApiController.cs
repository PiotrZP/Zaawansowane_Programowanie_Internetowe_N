using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers;

[Route("api/StationaryStore")]
public class StationaryStoreApiController : BaseApiController
{
    private readonly IStationaryStoreService _stationaryStoreService;
    public StationaryStoreApiController(ILogger logger, IMapper mapper,
                IStationaryStoreService stationaryStoreService) :
                base(logger, mapper)
    {
        _stationaryStoreService = stationaryStoreService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var stationaryStores = _stationaryStoreService.GetStationaryStores();
            return Ok(stationaryStores);
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
            var stationaryStore = _stationaryStoreService.GetStationaryStore(a => a.Id == id);
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
            var result = _stationaryStoreService.DeleteStationaryStore(a => a.Id == id);
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
            return Ok(_stationaryStoreService.AddOrUpdateStationaryStore(addOrUpdateStationaryStoreVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}