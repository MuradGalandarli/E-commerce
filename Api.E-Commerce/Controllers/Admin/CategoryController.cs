using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            this._categoryService = _categoryService;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetCategoryAllList()
        {
            var result = await _categoryService.GetList();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }
        [HttpPost("addCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var result = await _categoryService.Add(category);
            if (result != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpPut("updateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var result = await _categoryService.Update(category);
            if (result != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }
        [HttpGet("getById {id}")]
    public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpDelete("DeleteCategory{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var reult = await _categoryService.Delete(id);
            if (reult)
            {
                return Ok();
            }
            return NotFound();
        }


       


        }
    }
