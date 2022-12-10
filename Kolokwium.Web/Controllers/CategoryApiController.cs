using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.ViewModels.Interfaces;
using Kolokwium.ViewModels.VM;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Web.Controllers
{
    public class CategoryApiController : BaseController
    {

        //1. add filed
        private readonly ICategoryService _categoryService;
        public CategoryApiController(ILogger logger, IMapper mapper, ICategoryService categoryService) : base(logger, mapper)
        {
            _categoryService = categoryService;
        }

        // get Category
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var category = _categoryService.GetCategories();
                return Ok(category);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error Get Category");
            }
        }
        // Get Category by id
        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _categoryService.GetCategories(i => i.Id == id);
                return Ok(category);
            }
            catch (Exception ex)
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
                var result = _categoryService.DeleteCategory(i => i.Id == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateCategoryVm addOrUpdateCategoryVm)
        {
            return PostOrPutHelper(addOrUpdateCategoryVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateCategoryVm addOrUpdateCategoryVm)
        {
            return PostOrPutHelper(addOrUpdateCategoryVm);
        }

        private IActionResult PostOrPutHelper(AddOrUpdateCategoryVm addOrUpdateCategoryVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(_categoryService.AddOrUpdateCategory(addOrUpdateCategoryVm));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }
    }
}