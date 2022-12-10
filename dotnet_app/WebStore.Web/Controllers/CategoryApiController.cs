using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Web.Controllers;

public class CategoryApiController : BaseApiController
{
    private readonly ICategoryService _categoryService;
    public CategoryApiController(ILogger logger, IMapper mapper,
                ICategoryService categorySerivice) :
                base(logger, mapper)
    {
        _categoryService = categorySerivice;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var stores = _categoryService.GetCategories();
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
            var store = _categoryService.GetCategories(s => s.Id == id);
            return Ok(store);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    [HttpPut]
    public IActionResult Put([FromBody] AddOrUpdateCategoryVm AddOrUpdateCategoryVm)
    {
        return PostOrPutHelper(AddOrUpdateCategoryVm);
    }
    [HttpPost]
    public IActionResult Post([FromBody] AddOrUpdateCategoryVm AddOrUpdateCategoryVm)
    {
        return PostOrPutHelper(AddOrUpdateCategoryVm);
    }
    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var result = _categoryService.GetCategories(s => s.Id == id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return StatusCode(500, "Error occured");
        }
    }
    private IActionResult PostOrPutHelper(AddOrUpdateCategoryVm addOrUpdateCategoryVm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_categoryService.AddOrUpdateCategory(addOrUpdateCategoryVm));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            return StatusCode(500, "Error occured");
        }
    }
}