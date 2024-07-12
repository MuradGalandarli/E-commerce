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
           
            if(result != null)
            {
                return Ok(result);
            }         
         
            return NotFound();    

        }
     //   [HttpPost]


    





        }
    }
